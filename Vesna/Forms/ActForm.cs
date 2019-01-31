using System;
using System.Windows.Forms;
using Vesna.Business;
using Vesna.Business.Data;
using Vesna.Business.Utils;

namespace Vesna.Forms {
	public partial class ActForm : Form {
		private Auto _auto;
		private AutoRepository _autoRepository = new AutoRepository();

		public ActForm() {
			InitializeComponent();
		}

		private bool CheckIt() {
			if (ModifierKeys == Keys.Shift) {
				return true;
			}
			bool flag = true;
			tb_error_msg.Text = string.Empty;
			string er = "Заполните обязательные поля:" + Environment.NewLine;

			//if (cb_mesto_prov.Text.Length <= 2) { er += "Место контроля\n" + Environment.NewLine; flag = false; }
			//if (cb_imya_ppvk.Text.Length <= 2) { er += "Название ППВК\n" + Environment.NewLine; flag = false; }
			if (tb_marsh_dvig.Text.Length < 2) {
				er += "Маршрут движения\n" + Environment.NewLine;
				flag = false;
			}
			if (cb_mark_1.Text.Length <= 2) {
				er += "Марка ТС\n" + Environment.NewLine;
				flag = false;
			}
			//if (tb_tab_1_3.Text.Length <= 2) { MessageBox.Show("Заполните модель ТС"); return false; flag = false;}
			if (tb_reg_1.Text.Length <= 2) {
				er += "Регистрационный номер ТС\n" + Environment.NewLine;
				flag = false;
			}
			if (cb_operat.Text.Length <= 2) {
				er += "Оператор ППВК\n" + Environment.NewLine;
				flag = false;
			}
			if (cb_inspekt.Text.Length <= 2) {
				er += "Инспектор ГБДД" + Environment.NewLine;
				flag = false;
			}
			if (cb_driver.Text.Length <= 2) {
				er += "Водитель ТС\n" + Environment.NewLine;
				flag = false;
			}
			if (cb_prin_mery.Text.Length <= 2) {
				er += "Принятые меры\n" + Environment.NewLine;
				flag = false;
			}
			//if (cb_nomer_svid.Text.Length <= 0) { er += "Весовое оборудование\n" + Environment.NewLine; flag = false; }
			if (cb_kod_sub.Text.Length <= 0) {
				er += "Код субъекта\n" + Environment.NewLine;
				flag = false;
			}
			try {
				int.Parse(tb_kol_poezdok.Text);
			} catch {
				er += "Количество поездок - Ошибка ввода" + Environment.NewLine;
				flag = false;
			}

			if (!flag) {
				tb_error_msg.Text = er;
			}
			return flag;
		}

		private void cb_strana_SelectedValueChanged(object sender, EventArgs e) {
			if (cb_strana.Text == "Российская федерация") {
				cb_kod_sub.Visible = true;
				l_sub.Visible = true;
			} else {
				l_sub.Text = string.Empty;
				l_sub.Visible = false;
				cb_kod_sub.Text = string.Empty;
				cb_kod_sub.Visible = false;
			}
		} // отключаем город и код субьекта при выборе другой страны

		private void FormAct_Load(object sender, EventArgs e) {// заполняем комбобоксы
			if (_auto.IsCanEdit) {
				cb_inspekt.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Inspectors", "FIO"));
				cb_operat.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Operators", "FIO"));
				//cb_imya_ppvk.Items.AddRange(f_spr_PPVK.GetItemCollections());
				//cb_nomer_svid.Items.AddRange(f_spr_Vesi.GetItemCollections());
				//cb_mesto_prov.Items.AddRange(f_spr_Disl_point.GetItemCollections());
				cb_kod_sub.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Kod_sub", "Kod"));
				cb_organ.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Organ", "name_Organ"));
				cb_driver.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Driver", "name_Driver"));
				cb_vid_gruza.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Gruz", "name_gruz"));
				object[] col = SpravochnikUtil.GetItemCollections("sp_Mark", "name_Mark");
				cb_mark_1.Items.AddRange(col);
				cb_mark_2.Items.AddRange(col);
				cb_mark_3.Items.AddRange(col);

				cb_inspekt.Text = SpravochnikUtil.GetDefaultValue("sp_Inspectors", "FIO");
				cb_operat.Text = SpravochnikUtil.GetDefaultValue("sp_Operators", "FIO");
				//cb_imya_ppvk.Text = f_spr_PPVK.GetDefaultValue();
				//cb_nomer_svid.Text = f_spr_Vesi.GetDefaultValue();
				//cb_mesto_prov.Text = f_spr_Disl_point.GetDefaultValue();
				cb_kod_sub.Text = SpravochnikUtil.GetDefaultValue("sp_Kod_sub", "Kod");

				if (cb_strana.Text == string.Empty) {
					cb_strana.Text = "Российская федерация";
				}
			}
		}

		#region //события изменения комбобоксов

		private void cb_kod_sub_SelectedIndexChanged(object sender, EventArgs e) {
			if (cb_kod_sub.Text != string.Empty) {
				l_sub.Text = SpravochnikUtil.GetSubWithKode(cb_kod_sub.Text);
			}
		}

		/*private void cb_nomer_svid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_nomer_svid.Text != "")
            {
                l_ves_data.Text = f_spr_Vesi.GetDateOT(cb_nomer_svid.Text);
            }
        }*/

		#endregion

		private void SetCanEditAct(bool f) {
			foreach (Control c in Controls) {
				if ((c is TextBox || c is ComboBox) && !c.Equals(tb_primecanie)) {
					c.Enabled = f;
				}
			}
		}

		public void FillCurTCFromAct() {
			_auto.Datetime = DateTime.Parse(l_data.Text);
			/*curTC.Vesi.SvidetelstvoNomer = this.cb_nomer_svid.Text;
            curTC.Vesi.DatePoverkiOT = DateTime.Parse(l_ves_data.Text);//.ToString("dd.MM.yyyy HH:mm:ss");
            curTC.MestoKontrolya = this.cb_mesto_prov.Text;
            curTC.HarakterNarush = this.cb_hatakter_narush.Text;
            curTC.PPVK = this.cb_imya_ppvk.Text;*/

			_auto.Mark = this.cb_mark_1.Text;
			_auto.Model = this.tb_model_1.Text;
			_auto.RegNumber = this.tb_reg_1.Text;

			_auto.Trailer1.Kind = this.cb_vid_2.Text;
			_auto.Trailer1.Mark = this.cb_mark_2.Text;
			_auto.Trailer1.Model = this.tb_model_2.Text;
			_auto.Trailer1.RegNomer = this.tb_reg_2.Text;

			_auto.Trailer2.Kind = this.cb_vid_3.Text;
			_auto.Trailer2.Mark = this.cb_mark_3.Text;
			_auto.Trailer2.Model = this.tb_model_3.Text;
			_auto.Trailer2.RegNomer = this.tb_reg_3.Text;

			_auto.Sobstvenik = this.tb_sobstv.Text;
			_auto.SobstvenikAddess = this.tb_adres_sobs.Text;
			_auto.OrganName = this.cb_organ.Text;
			_auto.OrganAddress = this.tb_adres_organ.Text;

			_auto.Road.County = this.cb_strana.Text;
			_auto.Road.Region = this.l_sub.Text;
			_auto.Road.RegionKode = int.Parse(this.cb_kod_sub.Text);

			_auto.VidGruza = this.cb_vid_gruza.Text;

			_auto.Road.WayText = this.tb_marsh_dvig.Text;
			_auto.Road.CountWays = int.Parse(this.tb_kol_poezdok.Text);

			_auto.HarakterGruza = this.cb_harakter_gruza.Text;
			_auto.VoditelObyasnenie = this.tb_obyasn_vodit.Text;
			_auto.PrinyatieMery = this.cb_prin_mery.Text;

			_auto.ImyaOperator = this.cb_operat.Text;
			_auto.ImyaInspektora = this.cb_inspekt.Text;
			_auto.ImyaVodit = this.cb_driver.Text;

			_auto.Primechanie = this.tb_primecanie.Text;
		}

		public void LoadActFromAuto(Auto auto) {
			_auto = auto;
			l_nomer_act.Text = _auto.Id.ToString();
			if (_auto.Id == -1) {
				l_nomer_act.Text = "Новый";
			}
			SetCanEditAct(_auto.IsCanEdit);

			pb_foto.Image = _auto.Foto;
			//this.cb_nomer_svid.Text = curTC.Vesi.SvidetelstvoNomer;
			//this.l_ves_data.Text = curTC.Vesi.DatePoverkiOT.ToString("dd.MM.yyyy HH:mm:ss");
			//this.cb_mesto_prov.Text = curTC.MestoKontrolya;
			//this.cb_hatakter_narush.Text = curTC.HarakterNarush;
			l_data.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			//this.cb_imya_ppvk.Text = curTC.PPVK;
			//this.l_vid_dor.Text = curTC.VidDorogi;
			//this.pb_foto.Image = curTC.Foto;

			l_vid_1.Text = SpravochnikUtil.GetAutoName(_auto.AutoType);
			//this.cb_mark_1.Text = curTC.VidMark;
			//this.tb_model_1.Text = curTC.VidModel;
			//this.tb_reg_1.Text = curTC.VidRegNomer;

			//this.cb_vid_2.Text = curTC.Pricep1.Vid;
			//this.cb_mark_2.Text = curTC.Pricep1.Mark;
			//this.tb_model_2.Text = curTC.Pricep1.Model;
			//this.tb_reg_2.Text = curTC.Pricep1.RegNomer;

			//this.cb_vid_3.Text = curTC.Pricep2.Vid;
			//this.cb_mark_3.Text = curTC.Pricep2.Mark;
			//this.tb_model_3.Text = curTC.Pricep2.Model;
			//this.tb_reg_3.Text = curTC.Pricep2.RegNomer;

			//this.cb_organ.Text = curTC.OrganName;
			//this.tb_sobstv.Text = curTC.Sobstvenik;
			//this.tb_adres.Text = curTC.OrganAddress;

			//this.cb_strana.Text = curTC.Strana;
			//this.l_sub.Text = curTC.Subekt;
			//this.cb_kod_sub.Text = curTC.KodSubekta.ToString();

			//this.cb_vid_gruza.Text = curTC.VidGruza;

			//this.tb_marsh_dvig.Text = curTC.Marshrut.MarshrutString;
			l_km.Text = _auto.Road.Distance.ToString();
			//this.tb_kol_poezdok.Text = curTC.Marshrut.KolichestvoPoezdok.ToString();

			//this.l_dopus.Text = curTC.MassaDopustimaya.ToString();
			//this.l_mass_f.Text = curTC.MassaFakticheskaya.ToString();

			/*for (int i = 0; i < curTC.Osi.Count  ; i++) 
            {
                if (i != 9) { Controls["l_os_" + (i + 1)].Text = curTC.Osi[i].RastoyanDoSled.ToString(); }
                Controls["l_tab_1_" + (i+1)].Text = curTC.Osi[i].NagruzkaFact.ToString();
                Controls["l_tab_2_" + (i+1)].Text = curTC.Osi[i].NagruzkaDopust.ToString(); 
            }*/

			//this.cb_harakter_gruza.Text = curTC.HarakterGruza;
			//this.tb_obyasn_vodit.Text = curTC.Voditel_obyasnenie;
			//this.cb_prin_mery.Text = curTC.PrinyatieMery;

			//this.cb_operat.Text = curTC.ImyaOperator;
			//this.cb_inspekt.Text = curTC.ImyaInspektora;
			//this.cb_driver.Text = curTC.ImyaVodit;

			//this.tb_primecanie.Text = curTC.Primechanie;

			l_razm_usherba.Text = _auto.FullAutoDamage.ToString();
			//this.l_kom_index.Text =  curTC.SpecIndex.ToString();

		}

		private void b_exit_Click(object sender, EventArgs e) {
			if (FillAndSaveTc() >= 0) {
				Close();
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			if (_auto.IsCanEdit) {
				if (FillAndSaveTc() >= 0) {
					WordExportUtil.Export(_auto);
				}
			}
		}

		private int FillAndSaveTc() {
			if (CheckIt()) {
				FillCurTCFromAct();
				int r = _autoRepository.Save(_auto);
				SetCanEditAct(_auto.IsCanEdit);
				l_nomer_act.Text = _auto.CarId + "." + _auto.Id;
				return r;
			}
			return -1;
		}

		private void b_print_Click(object sender, EventArgs e) {
			if (FillAndSaveTc() >= 0) {
				WordExportUtil.Print(_auto);
			}
		}
	}
}
