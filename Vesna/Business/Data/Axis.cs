using System;

namespace Vesna.Business.Data {
	public class Axis {
		public int Index;
		public float DistanceToNext { get; set; }
		public AxisType Type { get; set; }
		public bool IsUpload { get; set; }
		public float WeightValue { get; set; }
		public float LoadLimit { get; set; }
		public float Damage { get; set; }

		public AxisBlockType BlockType { get; set; }
		public bool IsDouble => Type == AxisType.Double || Type == AxisType.DoubleAndPnevmo;
		public bool IsPnevmo => Type == AxisType.DoubleAndPnevmo || Type == AxisType.SingleAndPnevmo;

		public Axis(int index, float distanceToNext, AxisType type, bool isUpload, float weightValue) {
			Index = index;
			DistanceToNext = distanceToNext;
			Type = type;
			IsUpload = isUpload;
			WeightValue = weightValue;
		}

		public Axis(int index, float distanceToNext, AxisType type, bool isUpload, float weightValue, float loadLimit, float damage)
			: this(index, distanceToNext, type, isUpload, weightValue) {
			LoadLimit = loadLimit;
			Damage = damage;
		}

		public float GetOver() {
			return LoadLimit <= 0 || WeightValue <= LoadLimit ? 0 : (WeightValue - LoadLimit);
		}

		public float GetOverPercent() {
			float over = GetOver();
			return over <= 0 ? 0 : ((over / LoadLimit) * 100);
		}

		public override string ToString() {
			float overPercent = GetOverPercent();
			return $"L:'{LoadLimit}' V:'{WeightValue}' %:{overPercent} D:{Damage} ToNext:'{DistanceToNext}' Type:'{Type}' BlocKType:'{BlockType}";
		}

		public string ToStringForBase() {
			return $"'{DistanceToNext}', '{WeightValue}', '{LoadLimit}', '{(int)Type}', '{Convert.ToInt32(IsUpload)}', '{Damage}' ";
		}
	}
}