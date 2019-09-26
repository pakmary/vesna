using System;

namespace Vesna.Business.Data {
	public class FullWeightData {
		public float Value { get; set; }
		public float Limit { get; set; }
		public float Damage { get; set; }

		public float Over {
            get {
                float over = Value > Limit ? Value - Limit : 0;
                return (float) (Math.Round(over, 2));
            }
        }

        public float PercentageExceeded {
            get {
                float limit = Limit;
                float over = Over;
                if (over <= 0 || limit <= 0) {
                    return 0;
                }
                float percentage = (over / limit) * 100;
                return (float)(Math.Round(percentage, 2));
            }
        }

        public bool HasOver => Over > 0;

		public override string ToString() {
			return $"L:'{Limit}' V:'{Value}' %:{PercentageExceeded} D:{Damage} ";
		}
	}
}