namespace Vesna.Business.Data {
	public class FullWeightData {
		public float Value { get; set; }
		public float Limit { get; set; }
		public float Damage { get; set; }

		public float Over => Value > Limit ? Value - Limit : 0;

		public float PercentageExceeded {
			get {
				float over = Over;
				return over <= 0 ? 0 : ((over/Limit) * 100);
			}
		}

		public bool HasOver => Over > 0;

		public override string ToString() {
			return $"L:'{Limit}' V:'{Value}' %:{PercentageExceeded} D:{Damage} ";
		}
	}
}