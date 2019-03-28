using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Vesna.Business.Parst;
using Vesna.Controls;

namespace Vesna.Business {

	[Serializable]
	public class Auto {

		#region Prop

		public Guid IdAuto { get; set; }
		public bool IsCanEdit { get; set; }
		public int Id { get; set; }
		public int CarId { get; set; }
		public DateTime Datetime { get; set; }
		public string Ppvk { get; set; }
		public string MestoKontrolya { get; set; }
		public AutoScales Scales { get; set; }
		public Image Foto { get; set; }
		public AutoType AutoType { get; set; }
		public string Mark { get; set; }
		public string Model { get; set; }
		public string RegNumber { get; set; }
		public string Sobstvenik { get; set; }
		public string SobstvenikAddess { get; set; }
		public string OrganName { get; set; }
		public string OrganAddress { get; set; }
		public AutoRoad Road { get; set; }
		public string HarakterGruza { get; set; }
		public string VidGruza { get; set; }

		public Trailer Trailer1 { get; set; }
		public Trailer Trailer2 { get; set; }

		public AutoMass Mass { get; set; }
		public List<Axis> AxisList { get; set; }

		public string VoditelObyasnenie { get; set; }
		public string VoditelUdostoverenie { get; set; }
		public string PrinyatieMery { get; set; }

		public string ImyaOperator { get; set; }
		public string ImyaVodit { get; set; }
		public string ImyaInspektora { get; set; }

		public string Primechanie { get; set; }

		public float SpecIndex { get; set; }
		public float FullDamage { get; set; }

		public bool HasAxisOver {
			get { return AxisList.Any(os => os.LoadValue > os.LoadLimit); }
		}

		#endregion

		#region Ctor
		public Auto() {
			IsCanEdit = true;
			Id = -1;
			CarId = -1;
			AxisList = new List<Axis>();
			Scales = new AutoScales();
			Road = new AutoRoad();
			Trailer1 = new Trailer();
			Trailer2 = new Trailer();
			Mass = new AutoMass();
		}

		public Auto(int id) : this() {
			Load(id);
		}

		#endregion

		public void Populate() {
			if (!IsCanEdit) {
				return;
			}
			Process();
		}

		private void Process() {
			IEnumerable<AxisBlock> axisBlocks = SplitAxisOnBlocks();
			PopulateAxisLoadLimits(axisBlocks);
			Mass.ValueTon = AxisList.Sum(a => a.LoadValue);
			Mass.LimitTon = Calculator.GetMaxForMass(AutoType, AxisList.Count);
			Mass.Damage = Calculator.GetMassDamage(Road, Mass.OverProcent);
			AxisList.ForEach(a => a.Damage = Calculator.GetAxisDamage(Road, a));
			FullDamage = Calculator.GetFullDamage(Mass.Damage, AxisList.Select(a => a.Damage), Road.Distance);
		}

		public void AddOs(WheelControlState wheelState, bool isUpload, float rastoyanDoSled, float nagruzkaFact, float nagruzkaDopust = 0, float damage = 0) {
			if (AxisList.Count < 10) {// максимально 10 осей
				var axis = new Axis();
				AxisList.Add(axis);
				axis.Index = AxisList.Count - 1;
				axis.Type = ConvertToAxisType(wheelState);
				axis.LoadValue = nagruzkaFact;
				axis.LoadLimit = nagruzkaDopust;
				axis.DistanceToNext = rastoyanDoSled;
				axis.IsUpload = isUpload;
				axis.Damage = damage;
			}
		}

		private IEnumerable<AxisBlock> SplitAxisOnBlocks() {
			var blocks = new List<AxisBlock>();
			for (int i = 0; i < AxisList.Count; i++) {
				int blockCount = 1;
				int j = 0;
				while (i + j < AxisList.Count-1 && AxisList[i + j].DistanceToNext <= 2.0) {
					blockCount++;
					j++;
				}
				var blockType = AxisBlockType.Single;
				if (blockCount != 1) {
					if (blockCount == 2) {
						blockType = AxisBlockType.Dual;
					} else if (blockCount == 3) {
						blockType = AxisBlockType.Triple;
					} else if (blockCount > 3 && blockCount < 8) {
						blockType = AxisBlockType.MoreThree;
					} else if (blockCount >= 8) {
						blockType = AxisBlockType.EightOrMore;
					}
				}
				var block = new AxisBlock {BlockType = blockType};
				for (int i2 = 0; i2 < blockCount; i2++) {
					AxisList[i + i2].BlockType = blockType;
					block.Axis.Add(AxisList[i + i2]);
				}
				i = i + j;
				blocks.Add(block);
			}
			return blocks;
		}

		private void PopulateAxisLoadLimits(IEnumerable<AxisBlock> axisBlocks) {
			foreach (AxisBlock axisBlock in axisBlocks) {
				List<Axis> axises = axisBlock.Axis;
				if (Road.RoadType == RoadType.R5Tc) {
					axises.ForEach(a => a.LoadLimit = 5);
					continue;
				}
				if (axisBlock.BlockType == AxisBlockType.Single) {
					Axis singleAxis = axises.Single();
					singleAxis.LoadLimit = Calculator.GetMaxForAxis(Road.RoadType, AxisBlockType.Single, singleAxis.IsDouble,
						singleAxis.IsPnevmo, 0);
					continue;
				}
				for (int i = 0; i < axises.Count; i++) {
					Axis axis = axises[i];
					float dist;
					if (i == 0) {
						dist = axis.DistanceToNext;
					} else if (i == axises.Count - 1) {
						dist = axises[i - 1].DistanceToNext;
					} else {
						dist = Math.Min(axis.DistanceToNext, axises[i - 1].DistanceToNext);
					}

					axisBlock.BlockLimit = Calculator.GetMaxForAxis(Road.RoadType, axisBlock.BlockType, axis.IsDouble, axis.IsPnevmo,
						dist);
					if (axisBlock.BlockType == AxisBlockType.Dual || axisBlock.BlockType == AxisBlockType.Triple) {
						axis.LoadLimit = axisBlock.BlockLimit/axises.Count;
					} else {
						axis.LoadLimit = axisBlock.BlockLimit;
					}
				}
				if (axisBlock.BlockType == AxisBlockType.Dual) {
					Axis[] uploadAxis = axises.Where(a => a.IsUpload).ToArray();
					if (uploadAxis.Length == 1) {
						uploadAxis[0].LoadLimit = axisBlock.BlockLimit * 0.4f;
						axises.Except(new[] { uploadAxis[0] }).First().LoadLimit = axisBlock.BlockLimit * 0.6f;
					}
				}
			}
		}

		public int Save() {
			if (IsCanEdit) {

				#region Init insert command

				string comAxis = string.Empty;
				string comAxisInBase = string.Empty;
				for (int i = 0; i < AxisList.Count; i++) {
					comAxis += AxisList[i].ToStringForBase() + ",";
					comAxisInBase += string.Format(" r_os_{0},  m_f_os_{0},  m_d_os_{0},  v_os_{0}, is_up_{0}, os_dmg_{0}, ", i + 1);
				}
				string com = "INSERT INTO MainTable ( "
										 + " Car_id, "
										 + " Data, "
					//+ " VidTS, " -->tab_1_tip
										 + " RoadTypeId, "
										 + " punkt_name, "
										 + " address, "
										 + " vesi_date_OT, "
										 + " vesi_date_DO, "
										 + " vesi_zavod_nomer, "
					//foto
					//+ " harakter_narush, "

										 + " AutoTypeId, "
										 + " tab_1_mark, "
										 + " tab_1_model, "
										 + " tab_1_reg, "

										 + " tab_2_tip, "
										 + " tab_2_mark, "
										 + " tab_2_model, "
										 + " tab_2_reg, "

										 + " tab_3_tip, "
										 + " tab_3_mark, "
										 + " tab_3_model, "
										 + " tab_3_reg, "

										 + " sobstvenik, "
										 + " address_sobstvenik, "
										 + " organ, "
										 + " address_org, "
										 + " strana, "
										 + " sub, "
										 + " kog_strani, "


										 + " marshrut, "
										 + " marshrut_dlina, "
										 + " marshrut_kol_poezdok, "
										 + " harakter_gruza, "
										 + " vid_gruza, "

										 + " fakt_massa, "
										 + " dopus_massa, "
										 + " dmg_massa, "
										 + " count_os, "
										 + comAxisInBase

										 + " obyas_vodit, "
					//+ " udostov_vodit, "
										 + " prin_mery, "

										 + " oper_ppvk, "
										 + " vodit, "
										 + " insp_police, "


										 + " primechanie, "

										 + " kom_index, "
										 + " razmer_usherba ) "
										 + " VALUES ( '"
					//+ IsCanEdit + "' , '"
										 + CarId + "' , '"
										 + Datetime.ToString("dd.MM.yyyy HH:mm:ss") + "' , '"

										 + (int)Road.RoadType + "' , '"
										 + Ppvk + "' , '"
										 + MestoKontrolya + "' , '"
										 + Scales.CheckDateFrom + "' , '"
										 + Scales.CheckDateTo + "' , '"
										 + Scales.Number + "' , '"
					//+ Foto + "' , '"
					//+ HarakterNarush + "' , '"

										 + (int)AutoType + "' , '"
										 + Mark + "' , '"
										 + Model + "' , '"
										 + RegNumber + "' , "

										 + Trailer1.ToStringForBase() + " , "
										 + Trailer2.ToStringForBase() + " ,'"

										 + Sobstvenik + "' , '"
										 + SobstvenikAddess + "' , '"
										 + OrganName + "' , '"
										 + OrganAddress + "' , '"
										 + Road.County + "' , '"
										 + Road.Region + "' , '"
										 + Road.RegionKode + "' , '"

										 + Road.WayText + "' , '"
										 + Road.Distance + "' , '"
										 + Road.CountWays + "' , '"
										 + HarakterGruza + "' , '"
										 + VidGruza + "' , '"

										 + Mass.ValueTon + "' , '"
										 + Mass.LimitTon + "' , '"
										 + Mass.Damage + "' , '"
										 + AxisList.Count + "' ,  "
										 + comAxis + " '"

										 + VoditelObyasnenie + "' , '"
					//+ Voditel_udostoverenie + "' , '"
										 + PrinyatieMery + "' , '"

										 + ImyaOperator + "' , '"
										 + ImyaVodit + "' , '"
										 + ImyaInspektora + "' , '"

										 + Primechanie + "' , '"

										 + SpecIndex + "' , '"
										 + FullDamage + "'"
										 + " )";
				#endregion

				var command = new OleDbCommand(com);
				IsCanEdit = false;

				if (Program.MakeAccess(command) >= 0) {
					Id = int.Parse(Program.GetAccess("SELECT TOP 1 id FROM MainTable ORDER BY id DESC ").Rows[0]["id"].ToString());
					try {
						if (Foto != null) {
							string FullPath = string.Format("{0}\\Foto\\{1}.jpg", Application.StartupPath, Id);
							if (!File.Exists(FullPath)) {
								Foto.Save(FullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
							}
						}
					} catch (Exception e) {
						MessageBox.Show(string.Format("Ошибка сохранения изображения\n{0}", e.Message));
						return 1;
					}
					return 0;
				}
				return -1;
			}
			return 0;
		}

		public void Load(int id) {
			IsCanEdit = false;

			#region FillFromBase

			DataTable dt = Program.GetAccess("SELECT * FROM MainTable WHERE id = " + id);

			Id = id;
			CarId = int.Parse(dt.Rows[0]["car_id"].ToString());
			Datetime = TryParseDTOrGetDefault(dt.Rows[0]["Data"].ToString(), "Data");
			//+ " VidTS, " -->tab_1_tip
			Road.RoadType = (RoadType)(int.Parse(dt.Rows[0]["RoadTypeId"].ToString()));
			Ppvk = dt.Rows[0]["punkt_name"].ToString();
			MestoKontrolya = dt.Rows[0]["address"].ToString();
			Scales.CheckDateFrom = TryParseDTOrGetDefault(dt.Rows[0]["vesi_date_OT"].ToString(), "vesi_date_OT");
			Scales.CheckDateTo = TryParseDTOrGetDefault(dt.Rows[0]["vesi_date_DO"].ToString(), "vesi_date_DO");
			Scales.Number = dt.Rows[0]["vesi_zavod_nomer"].ToString();

			string strpath = Application.StartupPath + @"\Foto\" + Id + ".jpg";
			if (File.Exists(strpath)) {
				Foto = Image.FromFile(strpath);
			}
			AutoType = (AutoType)(int.Parse(dt.Rows[0]["AutoTypeId"].ToString()));
			Mark = dt.Rows[0]["tab_1_mark"].ToString();
			Model = dt.Rows[0]["tab_1_model"].ToString();
			RegNumber = dt.Rows[0]["tab_1_reg"].ToString();

			Trailer1.Kind = dt.Rows[0]["tab_2_tip"].ToString();
			Trailer1.Mark = dt.Rows[0]["tab_2_mark"].ToString();
			Trailer1.Model = dt.Rows[0]["tab_2_model"].ToString();
			Trailer1.RegNomer = dt.Rows[0]["tab_2_reg"].ToString();
			Trailer2.Kind = dt.Rows[0]["tab_3_tip"].ToString();
			Trailer2.Mark = dt.Rows[0]["tab_3_mark"].ToString();
			Trailer2.Model = dt.Rows[0]["tab_3_model"].ToString();
			Trailer2.RegNomer = dt.Rows[0]["tab_3_reg"].ToString();

			Sobstvenik = dt.Rows[0]["sobstvenik"].ToString();
			SobstvenikAddess = dt.Rows[0]["address_sobstvenik"].ToString();
			OrganName = dt.Rows[0]["organ"].ToString();
			OrganAddress = dt.Rows[0]["address_org"].ToString();
			Road.County = dt.Rows[0]["strana"].ToString();
			Road.Region = dt.Rows[0]["sub"].ToString();

			Road.WayText = dt.Rows[0]["marshrut"].ToString();
			Road.RegionKode = TryParseIntOrGetDefault(dt.Rows[0]["kog_strani"].ToString(), "kog_strani");
			Road.Distance = TryParseFloatOrGetDefault(dt.Rows[0]["marshrut_dlina"].ToString(), "marshrut_dlina");
			Road.CountWays = TryParseIntOrGetDefault(dt.Rows[0]["marshrut_kol_poezdok"].ToString(), "marshrut_kol_poezdok");

			HarakterGruza = dt.Rows[0]["harakter_gruza"].ToString();
			VidGruza = dt.Rows[0]["vid_gruza"].ToString();

			Mass.ValueTon = TryParseFloatOrGetDefault(dt.Rows[0]["fakt_massa"].ToString(), "fakt_massa");
			Mass.LimitTon = TryParseFloatOrGetDefault(dt.Rows[0]["dopus_massa"].ToString(), "dopus_massa");
			Mass.Damage = TryParseFloatOrGetDefault(dt.Rows[0]["dmg_massa"].ToString());
			int count = TryParseIntOrGetDefault(dt.Rows[0]["count_os"].ToString(), "count_os");
			for (int i = 1; i <= count; i++) {
				int v = int.Parse(dt.Rows[0]["v_os_" + i].ToString());
				float nf = TryParseFloatOrGetDefault(dt.Rows[0]["m_f_os_" + i].ToString());
				float nd = TryParseFloatOrGetDefault(dt.Rows[0]["m_d_os_" + i].ToString());
				float rs = TryParseFloatOrGetDefault(dt.Rows[0]["r_os_" + i].ToString());
				float dmg = TryParseFloatOrGetDefault(dt.Rows[0]["os_dmg_" + i].ToString());
				bool isUp = TryParseBoolOrGetDefault(dt.Rows[0]["is_up_" + i].ToString());
				AddOs((WheelControlState)v, isUp, rs, nf, nd, dmg);
			}
			VoditelObyasnenie = dt.Rows[0]["obyas_vodit"].ToString();
			PrinyatieMery = dt.Rows[0]["prin_mery"].ToString();

			ImyaOperator = dt.Rows[0]["oper_ppvk"].ToString();
			ImyaVodit = dt.Rows[0]["vodit"].ToString();
			ImyaInspektora = dt.Rows[0]["insp_police"].ToString();

			Primechanie = dt.Rows[0]["primechanie"].ToString();

			SpecIndex = TryParseFloatOrGetDefault(dt.Rows[0]["kom_index"].ToString(), "kom_index");
			FullDamage = TryParseFloatOrGetDefault(dt.Rows[0]["razmer_usherba"].ToString(), "razmer_usherba");

			#endregion


			/*Calculator.GetMassDamage();
			for (int i = 0; i < AxisList.Count; i++) {
				Calculator.GetAxisDamage(i);
			}*/
		}

		#region Help

		public string GetHarakterNarush() {
			bool massOver = Mass.HasOver;
			bool osOver = HasAxisOver;

			if (massOver && osOver) {
				return "с превышением предельно допустимой массы транспортных средств и с превышением предельно допустимых осевых нагрузок";
			}
			if (massOver) {
				return "с превышением предельно допустимой массы транспортных средств";
			}
			if (osOver) {
				return "с превышением предельно допустимых осевых нагрузок";
			}
			return "без превышения допустимой массы и допустимых осевых нагрузок";
		}

		private AxisType ConvertToAxisType(WheelControlState wheelState) {
			if(wheelState == WheelControlState.One){
				return AxisType.Single;
			} else if(wheelState == WheelControlState.OnePnevmo){
				return AxisType.SingleAndPnevmo;
			} else if(wheelState == WheelControlState.Two){
				return AxisType.Double;
			} else if(wheelState == WheelControlState.TwoPnevmo){
				return AxisType.DoubleAndPnevmo;
			}
			throw new ArgumentException("ConvertToAxisType error");
		}

		private float TryParseFloatOrGetDefault(string value, string fieldName = "", float def = 0){
			float pValue;
			if (float.TryParse(value, out pValue)) {
				return pValue;
			}
			if (!string.IsNullOrEmpty(fieldName)) {
				MessageBox.Show("Parse Error: " + fieldName);
			}
			return def;
		}

		private int TryParseIntOrGetDefault(string value, string fieldName, int def = 0) {
			int pValue;
			if (int.TryParse(value, out pValue)) {
				return pValue;
			}
			if (!string.IsNullOrEmpty(fieldName)) {
				MessageBox.Show("Parse Error: " + fieldName);
			}
			return def;
		}

		private DateTime TryParseDTOrGetDefault(string value, string fieldName, DateTime def = new DateTime()) {
			DateTime pValue;
			if (DateTime.TryParse(value, out pValue)) {
				return pValue;
			}
			if (!string.IsNullOrEmpty(fieldName)) {
				MessageBox.Show("Parse Error: " + fieldName);
			}
			return def;
		}

		private bool TryParseBoolOrGetDefault(string value, string fieldName = "", bool def = false) {
			bool pValue;
			if (bool.TryParse(value, out pValue)) {
				return pValue;
			}
			if (!string.IsNullOrEmpty(fieldName)) {
				MessageBox.Show("Parse Error: " + fieldName);
			}
			return def;
		}

		#endregion
	}
}
