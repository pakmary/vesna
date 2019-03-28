using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Vesna.Business.Data;
using Vesna.Properties;

namespace Vesna.Business {
	static class Calculator {
		private static float YearIndex => Settings.Default.YearIndex;
		private static float ConstDorojhnoKlimatZon => Settings.Default.ConstDorojhnoKlimatZon;
		private static float ConstKapitalniyRemont => Settings.Default.ConstKapitalniyRemont;
		private static bool KlimatUsloviya => Settings.Default.Klimat_usloviya;
		private static float ConstKlimatAxisMult => Settings.Default.ConstKlimatAxisMult;
		private static float ConstRegionRoad => Settings.Default.ConstRegionRoad;
		private static float ConstKlimat => Settings.Default.Klimat_usloviya ? 1f : 0.35f;
		private static float ConstMassInfluence(bool isFedaral) => isFedaral ? 1f : 0.285f;
		
		private static float ConstDamageDefault(RoadType roadType) {
			string damageDefault = Program.GetAccess("SELECT DamageDefault " 
			                                         + "FROM TypesRoad " 
			                                         + $"WHERE Id = {(int)roadType}").Rows[0]["DamageDefault"].ToString();
			return float.Parse(damageDefault);
		}

		private static float ConstH(RoadType roadType) => GetRoadTypeIndex(roadType, "H");
		private static float ConstA(RoadType roadType) => GetRoadTypeIndex(roadType, "a");
		private static float ConstB(RoadType roadType) => GetRoadTypeIndex(roadType,"b");
		private static float ConstC(RoadType roadType) => GetRoadTypeIndex(roadType, "c");
		private static float ConstD(RoadType roadType) => GetRoadTypeIndex(roadType, "d");

		public static void Populate(Auto auto) {
			if (!auto.IsCanEdit) {
				return;
			}
			AxisBlock[] axisBlocks = SplitAxisOnBlocks(auto);
			PopulateAxisLoadLimits(axisBlocks, auto.Road.RoadType);

			auto.FullWeightData.Value = auto.AxisList.Sum(a => a.WeightValueWithInaccuracy);
			auto.FullWeightData.Limit = GetFullAutoLimit(auto.AutoType, auto.AxisList.Count);
			auto.FullWeightData.Damage = GetFullAutoDamage(auto.Road, auto.FullWeightData.PercentageExceeded);

			auto.AxisList.ForEach(a => a.Damage = GetAxisDamage(auto.Road, a));

			auto.FullAutoDamage = GetAutoFullDamage(auto.FullWeightData.Damage, auto.AxisList.Select(a => a.Damage), auto.Road.Distance);
		}

		private static AxisBlock[] SplitAxisOnBlocks(Auto auto) {
			var blocks = new List<AxisBlock>();
			for (int i = 0; i < auto.AxisList.Count; i++) {
				int blockCount = 1;
				int j = 0;
				while (i + j < auto.AxisList.Count - 1 && auto.AxisList[i + j].DistanceToNext <= 2.0) {
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
				var block = new AxisBlock { BlockType = blockType };
				for (int i2 = 0; i2 < blockCount; i2++) {
					auto.AxisList[i + i2].BlockType = blockType;
					block.Axises.Add(auto.AxisList[i + i2]);
				}
				i = i + j;
				blocks.Add(block);
			}
			return blocks.ToArray();
		}

		private static void PopulateAxisLoadLimits(IEnumerable<AxisBlock> axisBlocks, RoadType roadType) {
			foreach (AxisBlock axisBlock in axisBlocks) {
				List<Axis> axises = axisBlock.Axises;
				if (roadType == RoadType.R5Tc) {
					axises.ForEach(a => a.LoadLimit = 5);
					continue;
				}
				if (axisBlock.BlockType == AxisBlockType.Single) {
					Axis singleAxis = axises.Single();
					singleAxis.LoadLimit = GetLimitForAxisesBlock(roadType, AxisBlockType.Single, singleAxis.IsDouble, singleAxis.IsPnevmo, 0);
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

					axisBlock.BlockLimit = GetLimitForAxisesBlock(roadType, axisBlock.BlockType, axis.IsDouble, axis.IsPnevmo, dist);
					if (axisBlock.BlockType == AxisBlockType.Dual || axisBlock.BlockType == AxisBlockType.Triple) {
						axis.LoadLimit = axisBlock.BlockLimit / axises.Count;
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

		private static float GetLimitForAxisesBlock(RoadType roadType, AxisBlockType blockType, bool isDouble, bool isPnevno, float distanceToNext) {
			string distance = distanceToNext.ToString(NumberFormatInfo.InvariantInfo);
			DataRow maxAxisRow = Program.GetAccess($"SELECT TOP 1 * FROM (SELECT * FROM MaxAxis" +
			                                       $" WHERE  {distance} <= Distance" +
			                                       $" AND TypeAxisId = {(int)blockType} )" +
			                                       $" ORDER BY Distance ASC").Rows[0];
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
			string singleColumn = $"{columnStart}_Single";
			string pnevmoColumn = $"{columnStart}_Pnevmo";
			string doubleColumn = $"{columnStart}_Double";
			if (isPnevno && !string.IsNullOrEmpty(maxAxisRow[pnevmoColumn].ToString())) {
				return float.Parse(maxAxisRow[pnevmoColumn].ToString());
			}
			if (isDouble && !string.IsNullOrEmpty(maxAxisRow[doubleColumn].ToString())) {
				return float.Parse(maxAxisRow[doubleColumn].ToString());
			}
			return float.Parse(maxAxisRow[singleColumn].ToString());
		}

		private static float GetFullAutoLimit(AutoType autoType, int osCount) {
			if (autoType == 0
			    || osCount <= 2 && autoType == AutoType.Autotrain
			    || osCount > 5 && autoType == AutoType.Automobile
			    || osCount <= 1) {
				throw new ArgumentException("Method GetLimitForAuto()");
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
			DataTable dt = Program.GetAccess($"SELECT {column} FROM MaxMass WHERE AutoTypeId = {(int)autoType}");
			return float.Parse(dt.Rows[0][column].ToString());
		}

		private static float GetAxisDamage(AutoRoad road, Axis axis) {////SELECT TOP 1 * FROM (SELECT * FROM MaxAxis WHERE  1.3 <= Distance AND TypeAxisId = 2 ) ORDER BY Distance ASC
			float over = axis.GetOver();
			float overPercent = axis.GetOverPercent();
			if (over <= 0 || overPercent <= Settings.Default.DopustimiyProcentAxis) {
				return 0;
			}
			
			float damage = -1;
			if (road.IsFederalRoad && (road.RoadType == RoadType.R10Tc || road.RoadType == RoadType.R115Tc)) {
				string percent = overPercent.ToString(NumberFormatInfo.InvariantInfo);
				DataRow damageAxisRow = Program.GetAccess("SELECT TOP 1 * FROM " 
				                                          + "(SELECT Damage, ProcentLimit FROM DamageAxis " 
				                                          + $"WHERE {percent} <= ProcentLimit " 
				                                          + $"AND TypeRoadId = {(int)road.RoadType} " 
				                                          + "ORDER BY ProcentLimit ASC)").Rows[0];
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

			float over = axis.GetOver();
			if (!road.IsSoftClothes) {
				var pOver = (float)Math.Pow(over, 1.92f);
				damage = KD*KK*KC*P*(1 + 0.2f*pOver*(a/H - b));
			} else {
				var pOver = (float)Math.Pow(over, 1.24f);
				damage = KK*KC*P*(1 + 0.14f*pOver*(a/H + b));
			}
			return damage;
		}

		private static float GetFullAutoDamage(AutoRoad road, float massOverPercent) {
			if (massOverPercent <= Settings.Default.DopustimiyProcentFullMass) {
				return 0;
			}

			DataRow damageMassRow = Program.GetAccess(string.Format(
				"SELECT TOP 1 * FROM " +
				"(SELECT Damage, ProcentLimit FROM DamageMass WHERE {0} <= ProcentLimit ORDER BY ProcentLimit ASC) ",
				massOverPercent.ToString(NumberFormatInfo.InvariantInfo))).Rows[0];
			float damage = float.Parse(damageMassRow["Damage"].ToString());
			
			if (damage <= -1) {
				damage = GetMassDamageByFormula(road, massOverPercent);
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

		private static float GetAutoFullDamage(float massDamage, IEnumerable<float> axisDamages, float distanse) {
			double fullDamage = (massDamage + axisDamages.Sum()) * (distanse / 100f) * YearIndex;
			return (float)Math.Round(fullDamage, 2);
		}

		private static float GetRoadTypeIndex(RoadType roadType, string type) {
			int roadTypeValue = (int)roadType;
			DataTable a = Program.GetAccess(string.Format($"SELECT {type} FROM TypesRoad WHERE Id = {roadTypeValue}"));
			string value = a.Rows[0][type].ToString();
			return float.Parse(value);
		}
	}
}
