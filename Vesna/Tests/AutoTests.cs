using System;
using System.Linq;
using NUnit.Framework;
using Vesna.Business;
using Vesna.Controls;

namespace Vesna.Tests {
	[TestFixture]
	class AutoTests {

		[TestFixtureSetUp]
		public void SetUp() {
			Program.UpdateBaseFile(@"C:\Users\vadim.pakin\Desktop\Vesna\Vesna\bin\Release\database_inspector.mdb");
		}

		[TestCase("4 5 1,3", "10 8 9 10", 
			"20521,79", AutoType.Automobile, RoadType.R10Tc, false, 100, false)]
		//[TestCase("4 5 1,3", "8 8 8 8", 
		//"20521,79", AutoType.Automobile, RoadType.R10Tc, false, 100, false)]
		[TestCase("4 2,1 6 1,29 1,31", "10 12DP 13DP 14DP 15DP 16DP", 
			"122636,43", AutoType.Autotrain, RoadType.R10Tc, false, 100, false)]
		[TestCase("4 1,9 1,3 1,3 1,3 5 1,1", "14P 15PD 16PDU 17PD 18PD 19PD 20PD 21PD", 
			"463881,86", AutoType.Autotrain, RoadType.R10Tc, false, 100, false)]
		[TestCase("4 1,2 4 1,3 4 1,5 5", "10P 11,5PDU 12,5PDU 13,5PDU 14,5PD 15,5PD 16,5PDU 17,5PDU", 
			"192799,39", AutoType.Autotrain, RoadType.R10Tc, false, 100, false)]
		[TestCase("4 6 1,23 1,22 5 1,33 1,45", "20P 19DPU 18D 17D 16D 15P 14P 13P", 
			"341829,57", AutoType.Autotrain, RoadType.R10Tc, false, 100, false)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", "17 16D 15D 14D 13D 12D 11D 10D 9D", 
			"514662,45", AutoType.Autotrain, RoadType.R10Tc, false, 100, true)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", "17 16D 15D 14D 13D 12D 11D 10D 9D", 
			"121866,39", AutoType.Autotrain, RoadType.R115Tc, false, 100, true)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", "17 16D 15D 14D 13D 12D 11D 10D 9D", 
			"2958042,29", AutoType.Autotrain, RoadType.R6Tc, false, 100, true)]
		[TestCase("5 1,38 6 1,2 1,2 8 1,45 1,5", "9,5 8,3D 8,2D 6,6D 7D 8D 7,8D 10D 10D", "25399,0", AutoType.Autotrain, RoadType.R10Tc, false, 100, false)] // <5%
		public void PopulateAutoTest(string distancesString, string loadsString, string fullDamage, AutoType autoType, RoadType roadType, bool isFederal, float dist, bool isKlimat) {
			Calculator.KlimatUsloviya = isKlimat;
			var auto = new Auto {
				AutoType = autoType,
				Road = {
					RoadType = roadType, 
					Distance = dist,
					IsFederalRoad = isFederal,
					IsSoftClothes = false
				}
			};

			string[] distances = distancesString.Split(' ');
			string[] loads = loadsString.Split(' ');

			for (int i = 0; i < loads.Length; i++) {
				var state = WheelControlState.One;
				float distance = i < distances.Length ? float.Parse(distances[i]) : 0;
				float load = float.Parse(string.Concat(loads[i].Where(c => !char.IsLetter(c))));

				if (loads[i].Contains("D")) {
					state = WheelControlState.Two;
				}
				if (loads[i].Contains("P")) {
					state = state == WheelControlState.Two ? WheelControlState.TwoPnevmo : WheelControlState.OnePnevmo;
				}
				bool isUp = loads[i].Contains("U");
				auto.AddOs(state, isUp, distance, load);
			}
			auto.Populate();

			float damage = float.Parse(fullDamage);
			Assert.AreEqual(Math.Round(auto.FullDamage), Math.Round(damage));
		}
	}
}
