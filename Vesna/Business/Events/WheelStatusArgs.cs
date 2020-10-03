using System;
using Vesna.Controls;

namespace Vesna.Business.Events {
	public class WheelStateArgs : EventArgs {
		public WheelStateArgs(int index, WheelControlState lastStatus, WheelControlState newStatus) {
			NewStatus = newStatus;
			LastStatus = lastStatus;
			Index = index;
		}

		public WheelControlState LastStatus { get; }
		public WheelControlState NewStatus { get; }
		public int Index { get; }
	}
}