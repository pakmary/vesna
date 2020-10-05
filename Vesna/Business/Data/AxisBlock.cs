using System;

namespace Vesna.Business.Data {
	public class AxisBlock {
		public AxisBlockType BlockType { get; }
		public Axis[] Axises { get; }

		public AxisBlock(AxisBlockType blockType, Axis[] axises) {
			BlockType = blockType;
			Axises = axises;
			Array.ForEach(axises, a => a.BlockType = blockType);
		}
	}
}
