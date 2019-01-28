using System;

namespace Vesna.VesnaEventArgs {
	public class WheelLoadArgs : EventArgs {
		public WheelLoadArgs(int index, float load) {
			Load = load;
			Index = index;
		}

		public float Load { get; private set; } // readonly
		public int Index { get; private set; } // readonly
	}
}