using System;
using Vesna.Controls;

namespace Vesna.Business.Events {
	public class WheelStateArgs : EventArgs {
		public WheelStateArgs(int index, WheelControlState lastStatus, WheelControlState newStatus) {
			NewStatus = newStatus;
			LastStatus = lastStatus;
			Index = index;
		}

		public WheelControlState LastStatus { get; private set; } // readonly
		public WheelControlState NewStatus { get; private set; } // readonly
		public int Index { get; private set; } // readonly
	}
}