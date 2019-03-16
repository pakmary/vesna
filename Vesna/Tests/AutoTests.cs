using System;
using System.Linq;
using NUnit.Framework;
using Vesna.Business;
using Vesna.Business.Data;
using Vesna.Properties;

namespace Vesna.Tests {
	[TestFixture]
	class AutoTests {
		[OneTimeSetUp]
		public void SetUp() {
			Program.UpdateBaseFile(@"D:\Projects\Vesna\Misc\database_inspector.mdb");
		}

		[TestCase("4 5 1,3",
			"10 8 9 10",
			"20521,79", 
			AutoType.Automobile, 
			RoadType.R10Tc, 
			false, 100,
			false,
			0f, 
			0f)]
		//[TestCase("4 5 1,3", "8 8 8 8", 
		//"20521,79", AutoType.Automobile, RoadType.R10Tc, false, 100, false)]
		[TestCase("4 2,6 6 1,29 1,31", 
			"10 12DP 13DP 14DP 15DP 16DP",
			"122636,43",
			AutoType.Autotrain, 
			RoadType.R10Tc, 
			false, 
			100, 
			false, 
			0f, 
			0f)]
		[TestCase("4 1,9 1,3 1,3 1,3 5 1,1", 
			"14P 15PD 16PD 17PD 18PD 19PD 20PD 21PD",
			"463881,86",
			AutoType.Autotrain,
			RoadType.R10Tc, 
			false, 
			100, 
			false, 
			0f,
			0f)]
		[TestCase("4 1,2 4 1,3 4 1,5 5",
			"10P 11,5PD 12,5PD 13,5PD 14,5PD 15,5PD 16,5PD 17,5PD",
			"188824", 
			AutoType.Autotrain, 
			RoadType.R10Tc, 
			false, 
			100, 
			false, 
			0f, 
			0f)]
		[TestCase("4 6 1,23 1,22 5 1,33 1,45", 
			"20P 19DP 18D 17D 16D 15P 14P 13P",
			"341829,57", 
			AutoType.Autotrain, 
			RoadType.R10Tc, 
			false, 
			100, 
			false, 
			0f, 
			0f)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", 
			"17 16D 15D 14D 13D 12D 11D 10D 9D",
			"514662,45", 
			AutoType.Autotrain, 
			RoadType.R10Tc, 
			false, 100, 
			true, 
			0f, 
			0f)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", 
			"17 16D 15D 14D 13D 12D 11D 10D 9D",
			"121866,39", 
			AutoType.Autotrain, 
			RoadType.R115Tc, 
			false, 
			100, 
			true, 
			0f, 
			0f)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", 
			"17 16D 15D 14D 13D 12D 11D 10D 9D",
			"2958042,29", 
			AutoType.Autotrain, 
			RoadType.R6Tc, 
			false, 
			100, 
			true, 
			0f, 
			0f)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
			"17 16D 15D 14D 13D 12D 11D 10D 9D",
			"5989566",
			AutoType.Autotrain,
			RoadType.R5Tc,
			false,
			100,
			true,
			0f,
			0f)] //R5Tc
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5",
			"9,5 8,3D 8,2D 6,6D 7D 8D 7,8D 10D 10D",
			"25399,0",
			AutoType.Autotrain,
			RoadType.R10Tc,
			false, 100,
			false,
			0f,
			0f)] // <5%
		[TestCase("4 2,6 6 1,29 1,31", 
			"10 12DP 13DP 14DP 15DP 16DP",
			"121185",
			AutoType.Autotrain,
			RoadType.R10Tc, 
			false, 
			100, 
			false, 
			0.05f, 
			0.4f)]
		[TestCase("4 2,1 6 1,29 1,31",
			"10 12DP 13DP 14DP 15DP 16DP",
			"127015",
			AutoType.Autotrain,
			RoadType.R10Tc,
			false,
			100,
			false,
			0.05f,
			0.4f)]
		public void PopulateAutoTest(string distancesString,
		                             string loadsString,
		                             string fullDamage,
		                             AutoType autoType,
		                             RoadType roadType,
		                             bool isFederal,
		                             float dist,
		                             bool isKlimat,
		                             float inaccuracyScales,
		                             float inaccuracyRoulette) {
			Settings.Default.Klimat_usloviya = isKlimat;
			var auto = new Auto {
				InaccuracyRoulette = inaccuracyRoulette,
				AutoType = autoType,
				Road = {
					RoadType = roadType,
					Distance = dist,
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
			Assert.AreEqual(Math.Round(auto.FullAutoDamage), Math.Round(damage));
		}
	}
}
