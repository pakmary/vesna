namespace Vesna.VesnaEventArgs {
	public class WheelDistanceArgs : System.EventArgs {
		public WheelDistanceArgs(int index, float distanceToNextAxis) {
			DistanceToNextAxis = distanceToNextAxis;
			Index = index;
		}

		public float DistanceToNextAxis { get; private set; } // readonly
		public int Index { get; private set; } // readonly
	}
}