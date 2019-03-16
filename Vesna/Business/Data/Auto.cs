using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Vesna.Business.Data {
	public class Auto {
		public bool IsCanEdit { get; set; } = true;
		public int Id { get; set; } = -1;
		public int CarId { get; set; } = -1;
		public DateTime Datetime { get; set; }
		public string Ppvk { get; set; }
		public string MestoKontrolya { get; set; }
		public AutoScales Scales { get; set; } = new AutoScales();
		public Image Foto { get; set; }
		public AutoType AutoType { get; set; }
		public string Mark { get; set; }
		public string Model { get; set; }
		public string RegNumber { get; set; }
		public string Sobstvenik { get; set; }
		public string SobstvenikAddess { get; set; }
		public string SobstvenikSvidetelstvo { get; set; }
		public string SobstvenikPricep { get; set; }
		public string SobstvenikPricepAddess { get; set; }
		public string SobstvenikPricepSvidetelstvo { get; set; }
		public AutoRoad Road { get; set; } = new AutoRoad();
		public string HarakterGruza { get; set; }
		public string VidGruza { get; set; }

		public Trailer Trailer1 { get; set; } = new Trailer();
		public Trailer Trailer2 { get; set; } = new Trailer();

		public FullWeightData FullWeightData { get; set; } = new FullWeightData();
		public List<Axis> AxisList { get; set; } = new List<Axis>();

		public string VoditelObyasnenie { get; set; }

		public string OperatorPVK { get; set; }
		public string Driver { get; set; }
		public string DriverLicense { get; set; }
		public string InspectorGIBDD { get; set; }

		public string Primechanie { get; set; }

		public float SpecIndex { get; set; }
		public float InaccuracyRoulette { get; set; }
		public float FullAutoDamage { get; set; }

		public bool HasAxisOver => AxisList.Any(os => os.WeightValueWithInaccuracy > os.LoadLimit);

		public void AddNewAxis(AxisType axisType, float distanceToNext, float weightValue) 
			=> AddAxis(axisType, distanceToNext, weightValue);

		public void AddLoadedAxis(AxisType axisType, float distanceToNext, float weightValue, float loadLimit, float damage) 
			=> AddAxis(axisType, distanceToNext, weightValue, loadLimit, damage);

		private void AddAxis(AxisType axisType, float distanceToNext, float weightValue, float loadLimit = 0, float damage = 0) {
			if (AxisList.Count < 10) {
				float weightValueWithInaccuracy = Math.Max(weightValue - Scales.Inaccuracy, 0);
				float distanceToNextWithInaccuracy = distanceToNext + InaccuracyRoulette;
				var axis = new Axis(index: AxisList.Count,
				                    type: axisType,
				                    weightValue: weightValue,
				                    weightValueWithInaccuracy: weightValueWithInaccuracy,
				                    distanceToNext: distanceToNext,
				                    distanceToNextWithInaccuracy: distanceToNextWithInaccuracy,
				                    loadLimit: loadLimit,
				                    damage: damage);
				AxisList.Add(axis);
			}
		}
	}
}
