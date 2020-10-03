using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Vesna.Business;
using Vesna.Business.Data;
using Vesna.Business.Events;
using Vesna.Business.Utils;
using Vesna.Properties;

namespace Vesna.Controls {
	public partial class WheelListControl : UserControl {
		private Auto _currentAuto = new Auto();
		public List<WheelControl> WheelList;

		public WheelListControl() {
			InitializeComponent();
			WheelList = new List<WheelControl> { os1, os2, os3, os4, os5, os6, os7, os8, os9, os10 };
		}

		public Auto GetTC() {
			if (PopulateAndUpdate()) {
				return _currentAuto;
			}
			return null;
		}

		public bool PopulateAndUpdate() {
			if (!WheelListChecker.CheckIt(this, cb_vid_TC, tb_Rastoyan)) {
				return false;
			}
			FillAndPopulateTc();
			UpdateView();
			return true;
		}

		private void FillAndPopulateTc() {
			float inaccuracyScales = Settings.Default.InaccuracyScales;
			float inaccuracyRoulette = Settings.Default.InaccuracyRoulette;

			_currentAuto.Foto = videoPictuce1.GetImage();
			_currentAuto.MestoKontrolya = Program.ControlPlace;
			_currentAuto.Ppvk = Program.PpvkName;
			_currentAuto.CarId = SpravochnikUtil.IdentificationNumber;
			_currentAuto.SpecIndex = Settings.Default.YearIndex;
			_currentAuto.InaccuracyRoulette = inaccuracyRoulette;
			_currentAuto.Scales.Number = Program.ScaleNumber;
			_currentAuto.Scales.CheckDateFrom = SpravochnikUtil.GetVesiDate(Program.ScaleNumber, "DateOT");
			_currentAuto.Scales.CheckDateTo = SpravochnikUtil.GetVesiDate(Program.ScaleNumber, "DateDO");
			_currentAuto.Scales.Inaccuracy = inaccuracyScales;
			_currentAuto.Road.RoadType = Program.CurrentRoadType;
			_currentAuto.Road.IsFederalRoad = Program.IsFederalRoad;
			_currentAuto.AutoType = (AutoType)cb_vid_TC.SelectedIndex + 1;
			_currentAuto.Road.Distance = float.Parse(tb_Rastoyan.Text);

			_currentAuto.AxisList.Clear();
			foreach (WheelControl wheel in WheelList.GetRange(0, GetWheelCount())) {
				AxisType axisType = ConvertToAxisType(wheel.WheelState);
				_currentAuto.AddNewAxis(axisType: axisType,
				                        distanceToNext: wheel.DistanceToNext,
				                        weightValue: wheel.ScalesValue);
			}

			Calculator.Populate(_currentAuto);
		}

		private void UpdateView() {
			l_kol_os.Text = _currentAuto.AxisList.Count.ToString();
			l_mass.Text = _currentAuto.FullWeightData.Value.ToString(CultureInfo.InvariantCulture);
			l_massDopus.Text = _currentAuto.FullWeightData.Limit.ToString(CultureInfo.InvariantCulture);
			l_massOver.Text = _currentAuto.FullWeightData.Over.ToString(CultureInfo.InvariantCulture);
			l_massOverPercent.Text =
				_currentAuto.FullWeightData.PercentageExceeded.ToString(CultureInfo.InvariantCulture) + "%";
			foreach (Axis axis in _currentAuto.AxisList) {
				WheelControl wheelControl = GetWheelByIndex(axis.Index);
				wheelControl.SetWeightValueWithInaccuracy(axis.WeightValueWithInaccuracy);
				wheelControl.SetDistanceToNextWithInaccuracy(axis.DistanceToNextWithInaccuracy);
				wheelControl.SetLoadLimit(axis.LoadLimit);
				wheelControl.SetOver(axis.GetOver());
				wheelControl.SetBlockInfo(axis.BlockInfo);
				wheelControl.SetOverPercent(axis.GetOverPercent());
			}
			if (Program.User == "Admin") {
				tb_razmerUsherba.Text = $"Размер ущерба (руб): {_currentAuto.FullAutoDamage}";
			}
		}

		public void FillComboBox() {
			cb_vid_TC.Items.AddRange(SpravochnikUtil.GetItemCollections("TypesAuto", "NameAuto", false));
			cb_vid_TC.SelectedIndex = 0;
		}

		public int GetWheelCount() {
			return WheelList.Count(w => w.WheelState != WheelControlState.Nothing && w.WheelState != WheelControlState.Plus);
		}

		private WheelControl GetWheelByIndex(int index) {
			return WheelList.FirstOrDefault(c => c.Index == index);
		}

		public void Clear() {
			_currentAuto = new Auto();
			videoPictuce1.SetImage(null);
			l_mass.Text = "0";
			l_massDopus.Text = "0";
			l_massOver.Text = "0";
			l_massOverPercent.Text = "0";
			tb_Rastoyan.Text = "0";
			l_kol_os.Text = "0";
			tb_razmerUsherba.Text = "";
			DeleteAllWheel();
		}

		private void AddWheel() {
			WheelControl lastWheel = WheelList.Find(w => w.WheelState == WheelControlState.Plus);
			if (lastWheel != null) {
				lastWheel.WheelState = WheelControlState.One;
				lastWheel.ClearWheelValues();
			}
		}

		private void DeleteLastWheel() {
			int i = GetWheelCount();
			if (i != 0) {
				WheelList[i - 1].WheelState = WheelControlState.Plus;
			}
		}

		private void DeleteAllWheel() {
			int c = GetWheelCount();
			for (int i = 0; i < c; i++) {
				DeleteLastWheel();
			}
		}

		private void os_WheelStateChanged(object sender, WheelStateArgs e) {
			if (e.LastStatus == WheelControlState.Plus && e.NewStatus != WheelControlState.Nothing && e.NewStatus != WheelControlState.Plus && e.Index != 10) {
				//если ось была добавлена
				foreach (WheelControl c in WheelList) {
					if (c.Index == e.Index - 1) {
						//ищем предыдущую ось
						c.tb_distanceToNext.Visible = c.tb_distanceToNextWithInaccuracy.Visible = true;
					}
					if (c.Index == e.Index + 1) {
						//ищем след ось
						c.WheelState = WheelControlState.Plus;
					}
				}
			}
			if (e.NewStatus == WheelControlState.Plus) {
				//если ось была удалена
				foreach (WheelControl c in WheelList) {
					if (c.Index > e.Index && c.WheelState != WheelControlState.Nothing) {
						c.WheelState = WheelControlState.Nothing;
					}
					if (c.Index >= e.Index - 1) {
						//ищем предыдущую ось
						c.tb_distanceToNext.Visible = c.tb_distanceToNextWithInaccuracy.Visible = false;
					}
				}
			}
		}

		private void cb_vid_TC_SelectedIndexChanged(object sender, EventArgs e) {
			if (_currentAuto != null) {
				_currentAuto.AutoType = (AutoType)cb_vid_TC.SelectedIndex + 1;
			}
		}

		private void b_del_wheel_Click(object sender, EventArgs e) {
			DeleteLastWheel();
		}

		private void tb_Rastoyan_MouseClick(object sender, MouseEventArgs e) {
			if (!string.IsNullOrEmpty(tb_Rastoyan.Text)) {
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
				float scalesValue = ComInfo.GetVes().Ves;

				l_ves.Text = scalesValue.ToString(CultureInfo.InvariantCulture);
				int count = GetWheelCount();
				if (count > 0 && !WheelList[count - 1].IsFixed) {
					WheelList[count - 1].ScalesValue = scalesValue;
				}
			}
		}

		private void os1_ButtonAddClick(object sender, EventArgs e) {
			if (GetWheelCount() == 0 || GetWheelByIndex(((WheelControl)sender).Index - 1).IsFixed) {
				AddWheel();
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			if (!DesignMode) {
				ComInfo.Open();
			}
		}

		private AxisType ConvertToAxisType(WheelControlState wheelState) {
			if (wheelState == WheelControlState.One) {
				return AxisType.Single;
			}
			if (wheelState == WheelControlState.OnePnevmo) {
				return AxisType.SingleAndPnevmo;
			}
			if (wheelState == WheelControlState.Two) {
				return AxisType.Double;
			}
			if (wheelState == WheelControlState.TwoPnevmo) {
				return AxisType.DoubleAndPnevmo;
			}
			throw new ArgumentException("ConvertToAxisType error");
		}
	}
}