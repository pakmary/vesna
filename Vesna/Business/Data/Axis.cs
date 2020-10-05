namespace Vesna.Business.Data {
	public class Axis {
		public int Index;
		public AxisType Type { get; }
		public float WeightValue { get; }
		public float WeightValueWithInaccuracy { get; }
		public float DistanceToNext { get; }
		public float DistanceToNextWithInaccuracy { get; }

		public float LoadLimit { get; set; }
		public float Damage { get; set; }

		public AxisBlockType BlockType { get; set; }
		public bool IsSingle => Type == AxisType.Single || Type == AxisType.SingleAndPnevmo;
		public bool IsDouble => Type == AxisType.Double || Type == AxisType.DoubleAndPnevmo;
		public bool IsPnevmo => Type == AxisType.DoubleAndPnevmo || Type == AxisType.SingleAndPnevmo;

		public string BlockInfo { get; set; }

		internal Axis(int index,
		              AxisType type,
		              float weightValue,
		              float weightValueWithInaccuracy,
		              float distanceToNext,
		              float distanceToNextWithInaccuracy,
		              float loadLimit,
		              float damage) {
			Index = index;
			Type = type;
			WeightValue = weightValue;
			WeightValueWithInaccuracy = weightValueWithInaccuracy;
			DistanceToNext = distanceToNext;
			DistanceToNextWithInaccuracy = distanceToNextWithInaccuracy;
			LoadLimit = loadLimit;
			Damage = damage;
		}

		public float GetOver() {
			return LoadLimit <= 0 || WeightValueWithInaccuracy <= LoadLimit ? 0 : (WeightValueWithInaccuracy - LoadLimit);
		}

		public float GetOverPercent() {
			float over = GetOver();
			return over <= 0 ? 0 : ((over / LoadLimit) * 100);
		}

		public override string ToString() {
			float overPercent = GetOverPercent();
			return $"L:'{LoadLimit}' V:'{WeightValue}' %:{overPercent} D:{Damage} ToNext:'{DistanceToNext}' Type:'{Type}' BlocKType:'{BlockType}";
		}
	}
}