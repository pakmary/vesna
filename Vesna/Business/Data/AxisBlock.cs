using System.Collections.Generic;

namespace Vesna.Business.Data {
	public class AxisBlock {
		public readonly List<Axis> Axises = new List<Axis>();
		public AxisBlockType BlockType { get; set; }
		public float BlockLimit { get; set; }
	}
}
