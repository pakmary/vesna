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
		private static float ConstKlimat => Settings.Default.Klimat_usloviya ? 1f : 0.35f;
		private static float ConstMassInfluence(bool isFedaral) => isFedaral ? Settings.Default.ConstKpmFederalRoad : Settings.Default.ConstKpmRegionRoad;

		public static void Populate(Auto auto) {
			if (!auto.IsCanEdit) {
				return;
			}
			auto.FullWeightData.Value = auto.AxisList.Sum(a => a.WeightValueWithInaccuracy);
			auto.FullWeightData.Limit = GetFullAutoLimit(auto.AutoType, auto.AxisList.Count);
			auto.FullWeightData.Damage = GetFullWeightAutoDamage(auto.Road, auto.FullWeightData.PercentageExceeded);

			AxisBlock[] axisBlocks = SplitAxisOnBlocks(auto);
			PopulateAxisBlockLoadLimits(axisBlocks, auto.Road.RoadType);
			PopulateAxisBlockDamage(axisBlocks, auto.Road);

			auto.FullAutoDamage = GetAutoFullDamage(auto.FullWeightData.Damage, auto.AxisList.Select(a => a.Damage), auto.Road.Distance);
		}

		private static AxisBlock[] SplitAxisOnBlocks(Auto auto) {
			var blocks = new List<AxisBlock>();
			for (int i = 0; i < auto.AxisList.Count; i++) {
				int blockCount = 1;
				int j = 0;
				while (i + j < auto.AxisList.Count - 1 && auto.AxisList[i + j].DistanceToNext <= 2.5f) {
					blockCount++;
					j++;
				}
				AxisBlockType blockType;
				if (blockCount == 1) {
					blockType = AxisBlockType.Single;
				} else if (blockCount == 2) {
					blockType = AxisBlockType.Dual;
				} else if (blockCount == 3) {
					blockType = AxisBlockType.Triple;
				} else if (blockCount > 3 && blockCount < 8) {
					blockType = AxisBlockType.MoreThree;
				} else {
					blockType = AxisBlockType.EightOrMore;
				}
				var block = new AxisBlock { BlockType = blockType };
				for (int i2 = 0; i2 < blockCount; i2++) {
					Axis axis = auto.AxisList[i + i2];
					axis.BlockType = blockType;
					block.Axises.Add(axis);
				}
				i = i + j;
				blocks.Add(block);
			}
			return blocks.ToArray();
		}

		private static void PopulateAxisBlockLoadLimits(IEnumerable<AxisBlock> axisBlocks, RoadType roadType) {
			foreach (AxisBlock axisBlock in axisBlocks) {
				List<Axis> axises = axisBlock.Axises;
				if (roadType == RoadType.R5Tc) {
					axises.ForEach(a => a.LoadLimit = 5);
					continue;
				}
				if (axisBlock.BlockType == AxisBlockType.Single) {
					Axis singleAxis = axises.Single();
					singleAxis.LoadLimit = GetLimitForAxisesBlock(roadType, AxisBlockType.Single, singleAxis.IsDouble, singleAxis.IsPnevmo, distanceToNext: 0);
				} else if (axisBlock.BlockType == AxisBlockType.Dual || axisBlock.BlockType == AxisBlockType.Triple) {
					bool blockIsDouble = axises.All(a => a.IsDouble);
					bool blockIsPnevmo = axises.All(a => a.IsPnevmo);
					int distanceCount = axises.Count - 1;
					float averageDistance = axises.Take(distanceCount).Sum(a => a.DistanceToNext) / distanceCount;

					float blockLimit = GetLimitForAxisesBlock(roadType, axisBlock.BlockType, blockIsDouble, blockIsPnevmo, averageDistance);
					float axisLimit = blockLimit / axises.Count;
					
					axises.ForEach(a => a.LoadLimit = axisLimit);
				} else if (axisBlock.BlockType == AxisBlockType.MoreThree || axisBlock.BlockType == AxisBlockType.EightOrMore) {
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

						var blockLimit = GetLimitForAxisesBlock(roadType, axisBlock.BlockType, axis.IsDouble, axis.IsPnevmo, dist);
						axis.LoadLimit = blockLimit;
					}
				} else {
					throw new NotImplementedException();
				}
			}
		}

		private static void PopulateAxisBlockDamage(AxisBlock[] axisBlocks, AutoRoad road) {
			foreach (AxisBlock axisBlock in axisBlocks) {
				AxisBlockType blockType = axisBlock.BlockType;
				List<Axis> axises = axisBlock.Axises;
				if (blockType == AxisBlockType.Single) {
					Axis axis = axises.Single();
					axis.Damage = GetAxisDamage(road, axis);
				} else if (blockType == AxisBlockType.Dual || blockType == AxisBlockType.Triple) {
					bool blockIsDouble = axises.All(a => a.IsDouble);
					bool blockIsPnevmo = axises.All(a => a.IsPnevmo);
					float blockWeight = axises.Sum(a => a.WeightValueWithInaccuracy);
					float blockLimit = axises.Sum(a => a.LoadLimit);
					float maxAxisWeight = axises.Max(a => a.WeightValueWithInaccuracy);
					float singleAxisLimit = GetLimitForAxisesBlock(road.RoadType, AxisBlockType.Single, blockIsDouble, blockIsPnevmo, distanceToNext: 0);
					if (blockWeight <= blockLimit && maxAxisWeight <= singleAxisLimit) {
						axises.ForEach(a => a.Damage = 0);
					} else {
						axises.ForEach(a => a.Damage = GetAxisDamage(road, a));
					}
				} else if (blockType == AxisBlockType.MoreThree || blockType == AxisBlockType.EightOrMore) {
					axises.ForEach(a => a.Damage = GetAxisDamage(road, a));
				} else {
					throw new NotImplementedException();
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
				if (blockType == AxisBlockType.Single) {
					return 5;
				}
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

		/// <summary>
		/// Размер вреда от превышения допустимых осевых нагрузок на ось
		/// </summary>
		private static float GetAxisDamage(AutoRoad road, Axis axis) {
			////SELECT TOP 1 * FROM (SELECT * FROM MaxAxis WHERE  1.3 <= Distance AND TypeAxisId = 2 ) ORDER BY Distance ASC
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

		/// <summary>
		/// Размер вреда от превышения допустимых осевых нагрузок на ось (ПО ФОРМУЛЕ)
		/// </summary>
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
				damage = KD * KK * KC * P * (1 + 0.2f * pOver * (a / H - b));
			} else {
				var pOver = (float)Math.Pow(over, 1.24f);
				damage = KK * KC * P * (1 + 0.14f * pOver * (a / H + b));
			}
			return damage;
		}

		/// <summary>
		/// Размер вреда от превышения допустимой массы транспортного средства
		/// </summary>
		private static float GetFullWeightAutoDamage(AutoRoad road, float massOverPercent) {
			if (massOverPercent <= Settings.Default.DopustimiyProcentFullMass) {
				return 0;
			}

			DataRow damageMassRow = Program.GetAccess("SELECT TOP 1 * FROM " +
			                                          $"(SELECT Damage, ProcentLimit FROM DamageMass " +
			                                          $"WHERE {massOverPercent.ToString(NumberFormatInfo.InvariantInfo)} <= ProcentLimit " +
			                                          $"ORDER BY ProcentLimit ASC) ")
			                               .Rows[0];
			float damage = float.Parse(damageMassRow["Damage"].ToString());

			if (damage <= -1) {
				damage = GetFullWeightAutoDamageByFormula(road, massOverPercent);
			} else {
				damage = damage * ConstMassInfluence(road.IsFederalRoad);
			}
			return (float)(Math.Round(damage, 2));
		}

		/// <summary>
		/// Размер вреда от превышения допустимой массы транспортного средства (ПО ФОРМУЛЕ)
		/// </summary>
		private static float GetFullWeightAutoDamageByFormula(AutoRoad road, float massOverProcent) {
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

		private static float ConstDamageDefault(RoadType roadType) {
			string damageDefault = Program.GetAccess("SELECT DamageDefault "
			                                         + "FROM TypesRoad "
			                                         + $"WHERE Id = {(int)roadType}").Rows[0]["DamageDefault"].ToString();
			return float.Parse(damageDefault);
		}

		private static float ConstH(RoadType roadType) => GetRoadTypeIndex(roadType, "H");
		private static float ConstA(RoadType roadType) => GetRoadTypeIndex(roadType, "a");
		private static float ConstB(RoadType roadType) => GetRoadTypeIndex(roadType, "b");
		private static float ConstC(RoadType roadType) => GetRoadTypeIndex(roadType, "c");
		private static float ConstD(RoadType roadType) => GetRoadTypeIndex(roadType, "d");

		private static float GetRoadTypeIndex(RoadType roadType, string type) {
			int roadTypeValue = (int)roadType;
			DataTable a = Program.GetAccess(string.Format($"SELECT {type} FROM TypesRoad WHERE Id = {roadTypeValue}"));
			string value = a.Rows[0][type].ToString();
			return float.Parse(value);
		}
	}
}
