using System.Windows.Forms;
using Vesna.Business.Data;
using Vesna.Controls;

namespace Vesna.Business.Utils {
	public static class WheelListChecker {
		public static bool CheckIt(WheelListControl wheelListControl, ComboBox vidTc, NumericUpDown fullDistance) {
			int wheelsCount = wheelListControl.GetWheelCount();
			foreach (WheelControl wheel in wheelListControl.WheelList.GetRange(0, wheelsCount)) {
				if (!wheel.IsFixed) {
					MessageBox.Show("ОШИБКА: Вес на всех осях должен быть зафиксирован");
					return false;
				}
				float weightValue = wheel.ScalesValue;
				if (weightValue == 0) {
					MessageBox.Show("ОШИБКА: Нагрузка на ось не может быть равной нулю");
					return false;
				}
				if (weightValue >= 50) {
					MessageBox.Show("ОШИБКА: Нагрузка на ось больше 50 тонн");
					return false;
				}
				if (wheel.Index != wheelsCount - 1) {
					float distanceToNext = wheel.DistanceToNext;
					if (distanceToNext == 0) {
						MessageBox.Show("ОШИБКА: Расстояние между осями не может быть равным нулю");
						return false;
					}
					if (distanceToNext >= 20) {
						MessageBox.Show("ОШИБКА: Расстояние между осями больше 20 метров");
						return false;
					}
				}
			}

			if (vidTc.SelectedItem.ToString() == string.Empty) {
				MessageBox.Show("ОШИБКА: Не выбран тип ТС");
				return false;
			}
			if ((AutoType)vidTc.SelectedIndex + 1 == AutoType.Automobile) {
				if (wheelsCount <= 1) {
					MessageBox.Show("ОШИБКА: У автомобиля должно быть минимум 2 оси");
					return false;
				}
				if (wheelsCount > 5) {
					MessageBox.Show("ОШИБКА: У автомобиля должно быть меньше 6 осей");
					return false;
				}
			} else if ((AutoType)vidTc.SelectedIndex + 1 == AutoType.Autotrain) {
				if (wheelsCount <= 2) {
					MessageBox.Show("ОШИБКА: У автопоезда должно быть минимум 3 оси");
					return false;
				}
			}
			if (fullDistance.Value.ToString() == "0" || fullDistance.Text == string.Empty) {
				MessageBox.Show("ОШИБКА: Нужно заполнить поле растояние маршрута движения");
				return false;
			}
			return true;
		}
	}
}