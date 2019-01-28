using System;

namespace Vesna.Business.Parst {
	[Serializable]
	public class AutoRoad {
		public RoadType RoadType { get; set; }
		public string WayText { get; set; }
		public string County { get; set; }
		public string Region { get; set; }
		public int RegionKode  { get; set; }
		public int CountWays { get; set; }
		public bool IsFederalRoad { get; set; }
		public bool IsSoftClothes { get; set; }
		public float Distance { get; set; }

		public AutoRoad() {
			CountWays = 1;
			RegionKode = 36;
		}
	}
}