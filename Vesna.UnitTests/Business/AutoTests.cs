using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Vesna.Business;
using Vesna.Business.Data;
using Vesna.Properties;

namespace Vesna.UnitTests.Business {
	[TestFixture, Parallelizable]
	public class AutoTests {
		[OneTimeSetUp]
		public void SetUp() {
			var ci = new CultureInfo("Ru-ru");
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
			Program.UpdateBaseFile(@"D:\Projects\Vesna\Vesna\Files\database_inspector.mdb");
		}

		/*[TestCase("4 5 1,3",
		          "10 8 9 10",
		          "20521,79", AutoType.Automobile, RoadType.R10Tc, false, false, 0f, 0f, TestName = "01")]
		[TestCase("4 5 1,3",
		          "10 8 9 10",
		          "42120", AutoType.Automobile, RoadType.R10Tc, true, false, 0f, 0f, TestName = "01-2")]
		[TestCase("3,72 5,92 1,34 1,34 1,34",
		          "6,25 9,45D 7,05 7,40 7,30",
		          "122700", AutoType.Autotrain, RoadType.R5Tc, false, false, 0f, 0f, TestName = "02 ( R5Tc )")] //R5Tc
		[TestCase("4 2,6 6 1,29 1,31",
		          "10 12DP 13DP 14DP 15DP 16DP",
		          "130782",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0f, 0f, TestName = "03")]
		[TestCase("4 1,9 1,3 1,3 1,3 5 1,1",
		          "14P 15PD 16PD 17PD 18PD 19PD 20PD 21PD",
		          "463878",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0f, 0f, TestName = "04")]
		[TestCase("4 1,2 4 1,3 4 1,5 5",
		          "10P 11,5PD 12,5PD 13,5PD 14,5PD 15,5PD 16,5PD 17,5PD",
		          "188822",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0f, 0f, TestName = "05")]
		[TestCase("4 6 1,23 1,22 5 1,33 1,45",
		          "20P 19DP 18D 17D 16D 15P 14P 13P",
		          "341826",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0f, 0f, TestName = "06")]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
		          "17 16D 15D 14D 13D 12D 11D 10D 9D",
		          "514660",
		          AutoType.Autotrain, RoadType.R10Tc, false, true, 0f, 0f, TestName = "07")]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
		          "17 16D 15D 14D 13D 12D 11D 10D 9D",
		          "121864",
		          AutoType.Autotrain, RoadType.R115Tc, false, true, 0f, 0f, TestName = "08")]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
		          "17 16D 15D 14D 13D 12D 11D 10D 9D",
		          "2958040",
		          AutoType.Autotrain, RoadType.R6Tc, false, true, 0f, 0f, TestName = "09 ( R6Tc )")]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
		          "17 16D 15D 14D 13D 12D 11D 10D 9D",
		          "3688278",
		          AutoType.Autotrain, RoadType.R5Tc, false, true, 0f, 0f, TestName = "10 ( R5Tc )")]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
		          "9,5 8,3D 8,2D 6,6D 7D 8D 7,8D 10D 10D",
		          "25398",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0f, 0f, TestName = "11 ( <5% )")]
		[TestCase("4 2,6 6 1,29 1,31",
		          "10 12DP 13DP 14DP 15DP 16DP",
		          "129288",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0.05f, 0.4f, TestName = "12")]
		[TestCase("4 2,1 6 1,29 1,31",
		          "10 12DP 13DP 14DP 15DP 16DP",
		          "135119",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0.05f, 0.4f, TestName = "13")]
		[TestCase("5 5 1,1",
		          "8 8 7,3 5,7",
		          "0",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0.05f, 0.4f, TestName = "14 (Группа осей меньше 13. Одна ось больше 6,5 но меньше 9.)")]
		[TestCase("5 5 1,1",
		          "8 8 9,1 3",
		          "5571",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0.00f, 0.0f, TestName = "15 (Группа осей меньше 13. Одна ось больше 9)")]
		[TestCase("5 5 1,1",
		          "8 8 11 7",
		          "14343",
		          AutoType.Autotrain, RoadType.R10Tc, false, false, 0.00f, 0.0f, TestName = "16 (Группа осей больше 13)")]
		[TestCase("3,2 1,3 2,5 1,3 1,3",
		          "4,9 7,15 6,9 7,45 7,45 7,25",
		          "4401",
		          AutoType.Autotrain, RoadType.R10Tc, true, false, 0.04f, 0.04f, TestName = "17 (2,5 метра между 3 и 4 осью")]*/
		[TestCase("3,2 2,5 1,8",
		          "13 9,85 7 7",
		          "0",
		          AutoType.Autotrain, RoadType.R10Tc, true, true, 0.00f, 0.00f, TestName = "проверка по AytoSchema 1")]
		public void PopulateAutoTest(string distancesString,
		                             string loadsString,
		                             string fullDamage,
		                             AutoType autoType,
		                             RoadType roadType,
		                             bool isFederal,
		                             bool isKlimat,
		                             float inaccuracyScales,
		                             float inaccuracyRoulette) {
			Settings.Default.Klimat_usloviya = isKlimat;
			Settings.Default.YearIndex = 1.9749f;
			Settings.Default.DopustimiyProcentAxis = 5;
			Settings.Default.DopustimiyProcentAxis = 5;
			var auto = new Auto {
				InaccuracyRoulette = inaccuracyRoulette,
				AutoType = autoType,
				Road = {
					RoadType = roadType,
					Distance = 100,
					IsFederalRoad = isFederal,
					IsSoftClothes = false
				},
				Scales = {
					Inaccuracy = inaccuracyScales
				}
			};

			string[] distances = distancesString.Split(' ');
			string[] loads = loadsString.Split(' ');

			for (int i = 0; i < loads.Length; i++) {
				var state = AxisType.Single;
				float distance = i < distances.Length ? float.Parse(distances[i]) : 0;
				float weightValue = float.Parse(string.Concat(loads[i].Where(c => !char.IsLetter(c))));

				if (loads[i].Contains("D")) {
					state = AxisType.Double;
				}
				if (loads[i].Contains("P")) {
					state = state == AxisType.Double ? AxisType.DoubleAndPnevmo : AxisType.SingleAndPnevmo;
				}
				auto.AddNewAxis(state, distance, weightValue);
			}
			Calculator.Populate(auto);

			float damage = float.Parse(fullDamage);
			Assert.AreEqual(Math.Round(auto.FullAutoDamage), Math.Round(damage), $"Масса:{Environment.NewLine}{auto.FullWeightData}{Environment.NewLine}" +
			                                                                     $"Нагрузки:{Environment.NewLine}{string.Join(Environment.NewLine, auto.AxisList.Select(a => a.ToString()))}");
		}
	}
}