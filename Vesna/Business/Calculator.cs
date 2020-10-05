using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Vesna.Business.Data;
using Vesna.Properties;

namespace Vesna.Business {
	static class Calculator {
		public static void Populate(Auto auto) {
			if (!auto.IsCanEdit) {
				return;
			}
			auto.FullWeightData.Value = auto.AxisList.Sum(a => a.WeightValueWithInaccuracy);
			auto.FullWeightData.Limit = GetFullAutoLimit(auto.AutoType, auto.AxisList.Count);
			auto.FullWeightData.Damage = GetFullWeightAutoDamage(auto.FullWeightData.PercentageExceeded);

			AxisBlock[] axisBlocks = SplitAxisOnBlocks(auto);

			AxisBlock[] axisBlocks2 = axisBlocks.Where(a => a.BlockType == AxisBlockType.EightOrMore).ToArray();
			foreach (AxisBlock a in axisBlocks2) {
				a.BlockType = AxisBlockType.Dual;
			}
			PopulateAxisBlockLoadLimitsAndDamage(axisBlocks, auto.Road);

			auto.FullAutoDamage = GetAutoFullDamage(auto.FullWeightData.Damage, auto.AxisList.Select(a => a.Damage), auto.Road.Distance);
		}

		private static AxisBlock[] SplitAxisOnBlocks(Auto auto) {
			var blocks = new List<AxisBlock>();
			for (int i = 0; i < auto.AxisList.Count; i++) {
				int blockCount = 1;
				int j = 0;
				while (i + j < auto.AxisList.Count - 1 && auto.AxisList[i + j].DistanceToNextWithInaccuracy <= 2.5f) {
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

		private static void PopulateAxisBlockLoadLimitsAndDamage(IEnumerable<AxisBlock> axisBlocks, AutoRoad road) {
			RoadType roadType = road.RoadType;

			foreach (AxisBlock axisBlock in axisBlocks) {
				List<Axis> axises = axisBlock.Axises;
				AxisBlockType blockType = axisBlock.BlockType;

				if (roadType == RoadType.R5Tc) {
					axises.ForEach(a => a.LoadLimit = 5);
					axises.ForEach(a => a.Damage = GetAxisDamage(road, a));
					continue;
				}
				string blockInfo =
					$"Группа осей ({string.Join(",", axises.Select(a => a.Index + 1))}){Environment.NewLine}";

				switch (blockType) {
					case AxisBlockType.Single: {
						Axis singleAxis = axises.Single();
						singleAxis.LoadLimit = GetLimitForAxisesBlock(roadType, AxisBlockType.Single, singleAxis.IsDouble, singleAxis.IsPnevmo, distanceToNext: 0);
						singleAxis.Damage = GetAxisDamage(road, singleAxis);
						break;
					}

					case AxisBlockType.Dual:
					case AxisBlockType.Triple: {
						bool blockIsDouble = axises.All(a => a.IsDouble);
						bool blockIsPnevmo = axises.All(a => a.IsPnevmo);
						float blockWeight = axises.Sum(a => a.WeightValueWithInaccuracy);
						float maxAxisWeight = axises.Max(a => a.WeightValueWithInaccuracy);
						float singleAxisLimit = GetLimitForAxisesBlock(road.RoadType, AxisBlockType.Single,
						                                               blockIsDouble, blockIsPnevmo, distanceToNext: 0);

						int distanceCount = axises.Count - 1;
						float averageDistance = axises.Take(distanceCount).Sum(a => a.DistanceToNextWithInaccuracy) / distanceCount;
						float blockLimit = GetLimitForAxisesBlock(roadType, blockType, blockIsDouble, blockIsPnevmo,
						                                          averageDistance);

						if (blockWeight <= blockLimit && maxAxisWeight <= singleAxisLimit) {
							axises.ForEach(a => a.LoadLimit = 0);
							axises.ForEach(a => a.Damage = 0);
						} else {
							float axisLimit = blockLimit / axises.Count;
							axises.ForEach(a => a.LoadLimit = axisLimit);
							axises.ForEach(a => a.Damage = GetAxisDamage(road, a));
						}

						blockInfo +=
							$" - Нагрузка на группу осей (Фактическая/Допустимая): {blockWeight}т./{blockLimit}т.{Environment.NewLine}" +
							$" - Нагрузка на наиболее нагруженную ось (Фактическая/Допустимая): {maxAxisWeight}т./{singleAxisLimit}т.{Environment.NewLine}";
						break;
					}

					case AxisBlockType.MoreThree:
					case AxisBlockType.EightOrMore: {
						for (int i = 0; i < axises.Count; i++) {
							Axis axis = axises[i];
							float dist;
							if (i == 0) {
								dist = axis.DistanceToNextWithInaccuracy;
							} else if (i == axises.Count - 1) {
								dist = axises[i - 1].DistanceToNextWithInaccuracy;
							} else {
								dist = Math.Min(axis.DistanceToNextWithInaccuracy, axises[i - 1].DistanceToNextWithInaccuracy);
							}

							axis.LoadLimit = GetLimitForAxisesBlock(roadType, blockType, axis.IsDouble, axis.IsPnevmo, dist);
							axis.Damage = GetAxisDamage(road, axis);
						}
						break;
					}
					default:
						throw new NotImplementedException();
				}

				axises.ForEach(a => a.BlockInfo = blockInfo);
			}
		}

		private static float GetLimitForAxisesBlock(RoadType roadType, AxisBlockType blockType, bool isDouble, bool isPnevno, float distanceToNext) {
			string distance = distanceToNext.ToString(NumberFormatInfo.InvariantInfo);
			DataRow maxAxisRow = Program.GetAccess("SELECT TOP 1 * FROM (SELECT * FROM MaxAxis" +
			                                       $" WHERE  {distance} <= Distance" +
			                                       $" AND TypeAxisId = {(int)blockType} )" +
			                                       " ORDER BY Distance ASC").Rows[0];
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
			float over = axis.GetOver();
			float overPercent = axis.GetOverPercent();
			if (over <= 0 || overPercent <= Settings.Default.DopustimiyProcentAxis) {
				return 0;
			}

			float damage = -1;
			//Размер вреда, причиняемого тяжеловесными транспортными средствами,
			//при движении таких транспортных средств по автомобильным дорогам федерального значения
			if (road.IsFederalRoad && (road.RoadType == RoadType.R10Tc || road.RoadType == RoadType.R115Tc)) {
				string percent = overPercent.ToString(NumberFormatInfo.InvariantInfo);
				DataRow damageAxisRow = Program.GetAccess("SELECT TOP 1 * FROM "
				                                          + "(SELECT Damage, ProcentLimit FROM DamageAxis "
				                                          + $"WHERE {percent} <= ProcentLimit "
				                                          + $"AND TypeRoadId = {(int)road.RoadType} "
				                                          + "ORDER BY ProcentLimit ASC)").Rows[0];
				damage = float.Parse(damageAxisRow["Damage"].ToString());
				if (damage > -1 && Settings.Default.Klimat_usloviya) {
					damage *= Settings.Default.ConstKlimatAxisMult;
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
			float kd = Settings.Default.ConstDorojhnoKlimatZon;
			float kk = Settings.Default.ConstKapitalniyRemont;
			float kc = Settings.Default.Klimat_usloviya ? 1f : 0.35f;
			float p = ConstDamageDefault(t);
			float a = ConstA(t);
			float b = ConstB(t);
			float h = ConstH(t);

			float over = axis.GetOver();
			if (!road.IsSoftClothes) {
				// для дорог с одеждой капитального и облегченного типа, в том числе для зимнего периода года
				var pOver = (float)Math.Pow(over, 1.92f);
				damage = kd * kk * kc * p * (1 + 0.2f * pOver * (a / h - b));
			} else {
				// для дорог с одеждой переходного типа, в том числе для зимнего периода года
				var pOver = (float)Math.Pow(over, 1.24f);
				damage = kk * kc * p * (1 + 0.14f * pOver * (a / h - b));
			}
			return damage;
		}

		/// <summary>
		/// Размер вреда от превышения допустимой массы транспортного средства
		/// </summary>
		private static float GetFullWeightAutoDamage(float massOverPercent) {
			if (massOverPercent <= Settings.Default.DopustimiyProcentFullMass) {
				return 0;
			}

			DataRow damageMassRow = Program.GetAccess("SELECT TOP 1 * FROM " +
			                                          "(SELECT Damage, ProcentLimit FROM DamageMass " +
			                                          $"WHERE {massOverPercent.ToString(NumberFormatInfo.InvariantInfo)} <= ProcentLimit " +
			                                          "ORDER BY ProcentLimit ASC) ")
			                               .Rows[0];
			float damage = float.Parse(damageMassRow["Damage"].ToString());

			if (damage <= -1) {
				damage = GetFullWeightAutoDamageByFormula(massOverPercent);
			} else {
				damage = damage * Settings.Default.ConstKpmFederalRoad; //К пм
			}
			return (float)(Math.Round(damage, 2));
		}

		/// <summary>
		/// Размер вреда от превышения допустимой массы транспортного средства (ПО ФОРМУЛЕ)
		/// </summary>
		private static float GetFullWeightAutoDamageByFormula(float massOverProcent) {
			if (massOverProcent <= 0) {
				return 0;
			}
			float kk = Settings.Default.ConstKapitalniyRemont; //К кап.рем
			float kp = Settings.Default.ConstKpmFederalRoad; //К пм
			float p = Settings.Default.ConstIshodnoeZnacheieDlyaMassi; //Р исх.пм
			float c = Settings.Default.ConstUchotPrevisheniyaMassi; //Коэффицент учета превышения массы
			return kk * kp * p * (1 + c * massOverProcent);
		}

		private static float GetAutoFullDamage(float massDamage, IEnumerable<float> axisDamages, float distanse) {
			double fullDamage = (massDamage + axisDamages.Sum()) * (distanse / 100f) * Settings.Default.YearIndex;
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

		private static float GetRoadTypeIndex(RoadType roadType, string type) {
			int roadTypeValue = (int)roadType;
			DataTable a = Program.GetAccess(string.Format($"SELECT {type} FROM TypesRoad WHERE Id = {roadTypeValue}"));
			string value = a.Rows[0][type].ToString();
			return float.Parse(value);
		}
	}
}