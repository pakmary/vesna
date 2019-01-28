using System;
using System.Collections.Generic;

namespace Vesna.Business.Parst {
	public class AxisBlock {
		public readonly List<Axis> Axis = new List<Axis>();
		public AxisBlockType BlockType { get; set; }
		public float BlockLimit { get; set; }
	}
}
