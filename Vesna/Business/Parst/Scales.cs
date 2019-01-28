using System;

namespace Vesna.Business.Parst {

	[Serializable]
	public class AutoScales {
		public string Number { get; set; }
		public DateTime CheckDateFrom { get; set; }
		public DateTime CheckDateTo { get; set; }
	}
}