using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Vesna.Business.Parst;
using Vesna.Properties;

namespace Vesna.Business {
	static class Calculator {

		#region Prop

		/// <summary>
		/// Т-тг
		/// </summary>
		public static float YearIndex {
			get { return Settings.Default.YearIndex; }
			set { Settings.Default.YearIndex = value; }
		}

		/// <summary>
		/// К-ДКЗ
		/// </summary>
		public static float ConstDorojhnoKlimatZon {
			get { return Settings.Default.ConstDorojhnoKlimatZon; }
			set { Settings.Default.ConstDorojhnoKlimatZon = value; }
		}

		/// <summary>
		/// К-кап.рем.
		/// </summary>
		public static float ConstKapitalniyRemont {
			get { return Settings.Default.ConstKapitalniyRemont; }
			set { Settings.Default.ConstKapitalniyRemont = value; }
		}

		/// <summary>
		/// К-сез.
		/// </summary>
		public static float ConstKlimat {
			get { return Settings.Default.Klimat_usloviya ? 1f : 0.35f; }
		}

		/// <summary>
		/// К-пм.
		/// </summary>
		public static float ConstMassInfluence(bool isFedaral) {
			return isFedaral ? 1f : 0.285f;
		}

		/// <summary>
		/// P-исх.
		/// </summary>
		public static float ConstDamageDefault(RoadType roadType) {
			string damageDefault = Program.GetAccess(string.Format("SELECT DamageDefault FROM TypesRoad WHERE Id = {0}", (int)roadType)).Rows[0]["DamageDefault"].ToString();
			return float.Parse(damageDefault);
		}

		public static float ConstH(RoadType roadType) {
			string h = Program.GetAccess(string.Format("SELECT H FROM TypesRoad WHERE Id = {0}", (int)roadType)).Rows[0]["H"].ToString();
			return float.Parse(h);
		}

		public static float ConstA(RoadType roadType) {
			string a = Program.GetAccess(string.Format("SELECT a FROM TypesRoad WHERE Id = {0}", (int)roadType)).Rows[0]["a"].ToString();
			return float.Parse(a);
		}

		public static float ConstB(RoadType roadType) {
			string b = Program.GetAccess(string.Format("SELECT b FROM TypesRoad WHERE Id = {0}", (int)roadType)).Rows[0]["b"].ToString();
			return float.Parse(b);
		}

		public static float ConstC(RoadType roadType) {
			string c = Program.GetAccess(string.Format("SELECT c FROM TypesRoad WHERE Id = {0}", (int)roadType)).Rows[0]["c"].ToString();
			return float.Parse(c);
		}

		public static float ConstD(RoadType roadType) {
			string d = Program.GetAccess(string.Format("SELECT d FROM TypesRoad WHERE Id = {0}", (int)roadType)).Rows[0]["d"].ToString();
			return float.Parse(d);
		}

		public static bool KlimatUsloviya {
			get { return Settings.Default.Klimat_usloviya; }
			set { Settings.Default.Klimat_usloviya = value; }
		}

		public static float ConstKlimatAxisMult {
			get { return Settings.Default.ConstKlimatAxisMult; }
			set { Settings.Default.ConstKlimatAxisMult = value; }
		}

		public static float ConstRegionRoad {
			get { return Settings.Default.ConstRegionRoad; }
			set { Settings.Default.ConstRegionRoad = value; }
		}

#endregion

		public static float GetMaxForAxis(RoadType roadType, AxisBlockType blockType, bool isDouble, bool isPnevno, float distance) {
			string columnStart = string.Empty;
			if (roadType == RoadType.R10Tc) {
				columnStart = "R10";
			} else if (roadType == RoadType.R115Tc) {
				columnStart = "R115";
			} else if (roadType == RoadType.R6Tc) {
				columnStart = "R6";
			} else if (roadType == RoadType.R5Tc) {
				throw new ArgumentException();
			}
			string singleColumn = columnStart + "_Single";
			string pnevmoColumn = columnStart + "_Pnevmo";
			string doubleColumn = columnStart + "_Double";
			DataRow maxAxisRow = Program.GetAccess(string.Format("SELECT TOP 1 * FROM (SELECT * FROM MaxAxis WHERE  {0} <= Distance AND TypeAxisId = {1} ) ORDER BY Distance ASC",
				distance.ToString(NumberFormatInfo.InvariantInfo), (int)blockType)).Rows[0];

			if (isPnevno && !string.IsNullOrEmpty(maxAxisRow[pnevmoColumn].ToString())) {
				return float.Parse(maxAxisRow[pnevmoColumn].ToString());
			}
			if (isDouble && !string.IsNullOrEmpty(maxAxisRow[doubleColumn].ToString())) {
				return float.Parse(maxAxisRow[doubleColumn].ToString());
			}
			return float.Parse(maxAxisRow[singleColumn].ToString());
		}

		public static float GetMaxForMass(AutoType autoType, int osCount) {
			if (autoType == 0 || osCount <= 2 && autoType == AutoType.Autotrain ||
			    osCount > 5 && autoType == AutoType.Automobile || osCount <= 1 ) {
						throw new ArgumentException("GetDopustimMass arguments error");
			}

			string column = string.Empty;
			if (osCount == 2) {
				column = "Axis2";
			} else if (osCount == 3) {
				column = "Axis3";
			} else if (osCount == 4) {
				column = "Axis4";
			} else if (osCount == 5) {
				column = "Axis5";
			} else if (osCount >= 6) {
				column = "Axis6OrMore";
			}
			DataTable dt = Program.GetAccess(string.Format("SELECT {0} FROM MaxMass " + 
																										 " WHERE AutoTypeId = {1}", column, (int)autoType));
			return float.Parse(dt.Rows[0][column].ToString());
		}

		public static float GetAxisDamage(AutoRoad road, Axis axis) {////SELECT TOP 1 * FROM (SELECT * FROM MaxAxis WHERE  1.3 <= Distance AND TypeAxisId = 2 ) ORDER BY Distance ASC
			if (axis.Over <= 0 || axis.Procent <= Properties.Settings.Default.DopustimiyProcentAxis) {
				return 0;
			}
			
			float damage = -1;
			if (road.IsFederalRoad && (road.RoadType == RoadType.R10Tc || road.RoadType == RoadType.R115Tc)) {
				DataRow damageAxisRow = Program.GetAccess(string.Format(
					"SELECT TOP 1 * FROM " +
					"(SELECT Damage, ProcentLimit FROM DamageAxis WHERE  {0} <= ProcentLimit AND TypeRoadId = {1} ORDER BY ProcentLimit ASC)",
							axis.Procent.ToString(NumberFormatInfo.InvariantInfo), (int)road.RoadType)).Rows[0];
				damage = float.Parse(damageAxisRow["Damage"].ToString());
				if (damage > -1 && KlimatUsloviya) {
					damage *= ConstKlimatAxisMult;
				}
			}
			if (damage <= -1) {
				damage = GetAxisDamageByFormula(road, axis);
			}
			return (float)Math.Round(damage, 2);
		}

		private static float GetAxisDamageByFormula(AutoRoad road, Axis axis) {
			float damage;
			RoadType t = road.RoadType;
			float KD = ConstDorojhnoKlimatZon;
			float KK = ConstKapitalniyRemont;
			float KC = ConstKlimat;
			float P = ConstDamageDefault(t);
			float a = ConstA(t);
			float b = ConstB(t);
			float H = ConstH(t);

			if (!road.IsSoftClothes) {
				var pOver = (float)Math.Pow(axis.Over, 1.92f);
				damage = KD*KK*KC*P*(1 + 0.2f*pOver*(a/H - b));
			} else {
				var pOver = (float)Math.Pow(axis.Over, 1.24f);
				damage = KK*KC*P*(1 + 0.14f*pOver*(a/H + b));
			}
			return damage;
		}

		public static float GetMassDamage(AutoRoad road, float massOverProcent) {
			if (massOverProcent <= Properties.Settings.Default.DopustimiyProcentFullMass) {
				return 0;
			}
			DataRow damageMassRow = Program.GetAccess(string.Format(
				"SELECT TOP 1 * FROM " +
				"(SELECT Damage, ProcentLimit FROM DamageMass WHERE {0} <= ProcentLimit ORDER BY ProcentLimit ASC) ",
				massOverProcent.ToString(NumberFormatInfo.InvariantInfo))).Rows[0];
			float damage = float.Parse(damageMassRow["Damage"].ToString());
			
			if (damage <= -1) {
				damage = GetMassDamageByFormula(road, massOverProcent);
			} else if(!road.IsFederalRoad) {
				damage = damage * ConstRegionRoad;
			}
			return (float)(Math.Round(damage, 2));
		}

		private static float GetMassDamageByFormula(AutoRoad road, float massOverProcent) {
			if (massOverProcent <= 0) {
				return 0;
			}
			RoadType t = road.RoadType;
			float KK = ConstKapitalniyRemont;
			float KP = ConstMassInfluence(road.IsFederalRoad);
			float c = ConstC(t);
			float d = ConstD(t);
			return KK * KP * (c + d * massOverProcent);
		}

		public static float GetFullDamage(float massDamage, IEnumerable<float> axisDamages, float distanse) {
			double fullDamage = (massDamage + axisDamages.Sum()) * (distanse/100f) * YearIndex;
			return (float)Math.Round(fullDamage, 2);
		}
	}
}
