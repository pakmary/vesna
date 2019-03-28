using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Vesna.Business;
using Vesna.Business.Parst;
using Vesna.Utils;
using Vesna.VesnaEventArgs;

namespace Vesna.Controls {
	public partial class WheelListControl : UserControl {
		private Auto _currentAuto = new Auto();
		public float VesNow;
		public List<WheelControl> WheelList;

		public WheelListControl() {
			InitializeComponent();
			WheelList = new List<WheelControl> {os1, os2, os3, os4, os5, os6, os7, os8, os9, os10}; //создаем элементы управления
		}

		public Auto GetTC() {
			if (PopulateAndUpdate()) {
				return _currentAuto;
			}
			return null;
		}

		public bool PopulateAndUpdate() {
			if (!CheckIt()) {
				return false;
			}
			FillAndPopulateTc();
			UpdateView();
			return true;
		}

		private void FillAndPopulateTc() {
			_currentAuto.AxisList.Clear();

			foreach (WheelControl w in WheelList.GetRange(0, GetWheelCount())) {
				_currentAuto.AddOs(w.WheelState, w.IsUpper, w.RastoyanDoSledOs, w.Nagruzka);
			}
			_currentAuto.Foto = videoPictuce1.GetImage();
			_currentAuto.MestoKontrolya = Program.ControlPlace;
			_currentAuto.Ppvk = Program.PPVKName;
			_currentAuto.CarId = SpravochnikUtil.IdentificationNumber;
			_currentAuto.SpecIndex = Calculator.YearIndex;
			_currentAuto.Scales.Number = Program.ScaleNumber;
			_currentAuto.Scales.CheckDateFrom = SpravochnikUtil.GetVesiDate(Program.ScaleNumber, "DateOT");
			_currentAuto.Scales.CheckDateTo = SpravochnikUtil.GetVesiDate(Program.ScaleNumber, "DateDO");
			_currentAuto.Road.RoadType = Program.CurrentRoadType;
			_currentAuto.Road.IsFederalRoad = Program.IsFederalRoad;
			_currentAuto.AutoType = (AutoType)cb_vid_TC.SelectedIndex + 1;
			_currentAuto.Road.Distance = float.Parse(tb_Rastoyan.Text);

			_currentAuto.Populate();
		}

		private void UpdateView() {
			l_kol_os.Text = _currentAuto.AxisList.Count.ToString();
			l_mass.Text = _currentAuto.Mass.ValueTon.ToString();
			l_massDopus.Text = _currentAuto.Mass.LimitTon.ToString();
			l_mass_procent.Text = string.Format("{0}%", Math.Round(_currentAuto.Mass.OverProcent, 1));
			foreach (Axis os in _currentAuto.AxisList) {
				var wheelControl = GetWheelFromIndex(os.Index);
				wheelControl.NagruzkaDopust = os.LoadLimit;
			}
			if (Program.User == "Admin") {
				tb_razmerUsherba.Text = string.Format("Размер ущерба (руб): {0}", _currentAuto.FullDamage);
			}
		}
		
		public bool CheckIt() {
			int wheelsCount = GetWheelCount();
			foreach (WheelControl wheel in WheelList.GetRange(0, GetWheelCount())) {
				if (!wheel.IsFixed) {
					MessageBox.Show("ОШИБКА: Вес на всех осях должен быть зафиксирован");
					return false;
				}
				if (wheel.Nagruzka == 0) {
					MessageBox.Show("ОШИБКА: Нагрузка на ось не может быть равной нулю");
					return false;
				}
				if (wheel.Nagruzka >= 50) {
					MessageBox.Show("ОШИБКА: Нагрузка на ось слишком большая");
					return false;
				}
				if (wheel.Index != wheelsCount - 1) {
					if (wheel.RastoyanDoSledOs == 0) {
						MessageBox.Show("ОШИБКА: Расстояние между осями не может быть равным нулю");
						return false;
					}
					if (wheel.RastoyanDoSledOs >= 20) {
						MessageBox.Show("ОШИБКА: Расстояние между осями слишком большое");
						return false;
					}
				}
			}

			if (cb_vid_TC.SelectedItem.ToString() == string.Empty) {
				MessageBox.Show("ОШИБКА: Не выбран тип ТС");
				return false;
			}
			if ((AutoType)cb_vid_TC.SelectedIndex +1 == AutoType.Automobile) {
				if (wheelsCount <= 1) {
					MessageBox.Show("ОШИБКА: У автомобиля должно быть минимум 2 оси");
					return false;
				}
				if (wheelsCount > 5) {
					MessageBox.Show("ОШИБКА: У автомобиля должно быть меньше 6 осей");
					return false;
				}
			} else if ((AutoType)cb_vid_TC.SelectedIndex + 1 == AutoType.Autotrain) {
				if (wheelsCount <= 2) {
					MessageBox.Show("ОШИБКА: У автопоезда должно быть минимум 3 оси");
					return false;
				}
			}
			if (tb_Rastoyan.Value.ToString() == "0" || tb_Rastoyan.Text == string.Empty) {
				MessageBox.Show("ОШИБКА: Нужно заполнить поле растояние маршрута движения");
				return false;
			}
			return true;
		}

		public void FillComboBox() {
			cb_vid_TC.Items.AddRange(SpravochnikUtil.GetItemCollections("TypesAuto", "NameAuto", false));
			cb_vid_TC.SelectedIndex = 0;
		}

		#region Help
		
		public int GetWheelCount() {
			return WheelList.Count(w => w.WheelState != WheelControlState.Nothing && w.WheelState != WheelControlState.Plus);
		}

		public WheelControl GetWheelFromIndex(int index) {
			return WheelList.FirstOrDefault(c => c.Index == index);
		}

		public void Clear() {
			_currentAuto = new Auto();
			videoPictuce1.SetImage(null);
			l_mass.Text = "0";
			l_massDopus.Text = "0";
			l_mass_procent.Text = "0";
			tb_Rastoyan.Text = "0";
			l_kol_os.Text = "0";
			tb_razmerUsherba.Text = "";
			DelAllWheel();
		}

		public void AddWheel(float rasDoSledOs = 0, float nagruz = 0, float nagruzDop = 0, WheelControlState stat = WheelControlState.One) {
			WheelControl lastw = WheelList.Find(w => w.WheelState == WheelControlState.Plus);
			if (lastw != null) {
				lastw.WheelState = stat;
				lastw.Nagruzka = nagruz;
				lastw.NagruzkaDopust = nagruzDop;
				lastw.RastoyanDoSledOs = rasDoSledOs;
			}
		}

		public void DeleteWheel() {
			int i = GetWheelCount();
			if (i != 0) {
				WheelList[i - 1].WheelState = WheelControlState.Plus;
			}
		}

		public void DelAllWheel() {
			int c = GetWheelCount();
			for (int i = 0; i < c; i++) {
				DeleteWheel();
			}
		}

		#endregion

		#region Events

		private void os_WheelStateChanged(object sender, WheelStateArgs e) {
			if (e.LastStatus == WheelControlState.Plus
				&& e.NewStatus != WheelControlState.Nothing
				&& e.NewStatus != WheelControlState.Plus
				&& e.Index != 10) {//если ось была добавлена

				foreach (WheelControl c in WheelList) {
					if (c.Index == e.Index - 1) {//ищем предыдущую ось
						c.tb_ras.Visible = true;
					}
					if (c.Index == e.Index + 1) {//ищем след ось
						c.WheelState = WheelControlState.Plus;
					}
				}
			}
			if (e.NewStatus == WheelControlState.Plus) {//если ось была удалена
				foreach (WheelControl c in WheelList) {
					if (c.Index > e.Index && c.WheelState != WheelControlState.Nothing) {
						c.WheelState = WheelControlState.Nothing;
					}
					if (c.Index >= e.Index - 1) {//ищем предыдущую ось
						c.tb_ras.Visible = false;
					}
				}
			}
		}

		private void cb_vid_TC_SelectedIndexChanged(object sender, EventArgs e) {
			if (_currentAuto != null) {
				_currentAuto.AutoType = (AutoType)cb_vid_TC.SelectedIndex+1;
			}
		}

		private void b_del_wheel_Click(object sender, EventArgs e) {
			DeleteWheel();
		}

		private void tb_Rastoyan_MouseClick(object sender, MouseEventArgs e) {
			if (!String.IsNullOrEmpty(tb_Rastoyan.Text)) {
				tb_Rastoyan.Select(0, tb_Rastoyan.Text.Length);
			}
		}

		private void tb_Rastoyan_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == '.') {
				e.KeyChar = ',';
			}
		}

		private void timer1_Tick(object sender, EventArgs e) {
			if (!DesignMode) {
				int count = GetWheelCount();
				float nag = ComInfo.GetVes().Ves;
				l_ves.Text = nag.ToString(CultureInfo.InvariantCulture);
				if (count > 0 && !WheelList[count - 1].IsFixed) {
					WheelList[count - 1].Nagruzka = nag;
				}
			}
		}

		private void os1_ButtonAddClick(object sender, EventArgs e) {
			if (GetWheelCount() == 0 || GetWheelFromIndex(((WheelControl) sender).Index - 1).IsFixed) {
				AddWheel();
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			if (!DesignMode) {
				ComInfo.Open();
			}
		}

		#endregion
	}
}
