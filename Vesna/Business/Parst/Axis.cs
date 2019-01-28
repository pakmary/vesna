using System;

namespace Vesna.Business.Parst {
	[Serializable]
	public class Axis {
		public int Index;
		public float DistanceToNext { get; set; }
		public AxisType Type { get; set; }
		public bool IsUpload { get; set; }
		public float LoadValue { get; set; }
		public float LoadLimit { get; set; }
		public float Damage { get; set; }
		public AxisBlockType BlockType { get; set; }

		public float Over {
			get { return LoadLimit <= 0 || LoadValue <= LoadLimit ? 0 : (LoadValue - LoadLimit); }
		}

		public float Procent {
			get {
				float over = Over;
				return over <= 0 ? 0 : ((over / LoadLimit) * 100);
			}
		}

		public bool IsFirstOs {
			get { return Index == 0; }
		}

		public bool IsDouble {
			get { return Type == AxisType.Double || Type == AxisType.DoubleAndPnevmo; }
		}

		public bool IsPnevmo {
			get { return Type == AxisType.DoubleAndPnevmo || Type == AxisType.SingleAndPnevmo; }
		}

		public override string ToString() {
			return string.Format("L:'{0}' V:'{1}' %:{2} D:{5} ToNext:'{3}' Type:'{4}' BlocKType:'{6}", LoadLimit, LoadValue, Procent, DistanceToNext, Type, Damage, BlockType);
		}

		public string ToStringForBase() {
			return string.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}' ", DistanceToNext, LoadValue, LoadLimit, (int)Type, Convert.ToInt32(IsUpload), Damage);
		}
	}
}