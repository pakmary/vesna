using System;

namespace Vesna.Business.Data {
	public class Trailer {
		public string Kind { get; set; }
		public string Mark { get; set; }
		public string Model { get; set; }
		public string RegNomer { get; set; }

		public string ToStringForBase() {
			return string.Format("'{0}','{1}','{2}','{3}'", Kind, Mark, Model, RegNomer);
		}
	}
}