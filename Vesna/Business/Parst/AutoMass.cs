using System;

namespace Vesna.Business.Parst {
	[Serializable]
	public class AutoMass {
		public float ValueTon { get; set; }
		public float LimitTon { get; set; }
		public float Damage { get; set; }

		public float OverTon {
			get { return ValueTon > LimitTon ? ValueTon - LimitTon : 0; }
		}

		public float OverProcent {
			get {
				float over = OverTon;
				return over <= 0 ? 0 : ((over/LimitTon)*100);
			}
		}

		public bool HasOver {
			get { return OverTon > 0; }
		}

		public override string ToString() {
			return string.Format("L:'{0}' V:'{1}' %:{2} D:{3} ", LimitTon, ValueTon, OverProcent, Damage);
		}
	}
}