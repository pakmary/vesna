using System;

namespace Vesna.Business.Data {
	public class AutoScales {
		public string Number { get; set; }
		public DateTime CheckDateFrom { get; set; }
		public DateTime CheckDateTo { get; set; }
		public float Inaccuracy { get; set; }
	}
}