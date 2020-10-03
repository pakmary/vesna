using System.Collections.Generic;

namespace Vesna.Business.Data {
	public class AxisBlock {
		public List<Axis> Axises { get; } = new List<Axis>();
		public AxisBlockType BlockType { get; set; }
		//public float BlockLimit { get; set; }
	}
}
