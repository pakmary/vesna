using System;
using System.Globalization;
using System.Windows.Forms;
using Vesna.Business.Events;

namespace Vesna.Controls {
	public partial class WheelControl : UserControl {
		public bool IsFixed;
		private WheelControlState _wheelState;

		public delegate void WheelStatusChangedHandler(object o, WheelStateArgs e);
		public event WheelStatusChangedHandler WheelStatusChanged;
		public event EventHandler ButtonAddClick;

		public int Index { get; set; }

		public WheelControlState WheelState {
			get => _wheelState;
			set {
				WheelControlState lastState = _wheelState;
				SetState(value);
				WheelStatusChanged?.Invoke(this, new WheelStateArgs(Index, lastState, _wheelState));
			}
		}
		
		public float ScalesValue {
			get => GetValueOrDefault(tb_scales_value);
			set => tb_scales_value.Text = value.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
		}

		public float DistanceToNext {
			get => GetValueOrDefault(tb_distanceToNext);
			set => tb_distanceToNext.Text = value.ToString(CultureInfo.InvariantCulture);
		}

		public WheelControl() {
			InitializeComponent();
			if (!DesignMode) {
				cbPnevmo.OffImage = Properties.Resources.wheelPnevmoOff;
				cbPnevmo.OnImage = Properties.Resources.wheelPnevmo;
				cbDouble.OffImage = Properties.Resources.wheelDualOff;
				cbDouble.OnImage = Properties.Resources.wheelDual;
			}
		}

		public void SetWeightValueWithInaccuracy(float weightValueWithInaccuracy) {
			tb_weightValueWithInaccuracy.Text = weightValueWithInaccuracy.ToString(CultureInfo.InvariantCulture);
		}

		public void SetDistanceToNextWithInaccuracy(float distanceToNextWithInaccuracy) {
			tb_distanceToNextWithInaccuracy.Text = distanceToNextWithInaccuracy.ToString(CultureInfo.InvariantCulture);
		}

        public void SetLoadLimit(float loadLimit) {
            l_loadLimit.Text = loadLimit <= 0
                ? "-"
                : loadLimit.ToString(CultureInfo.InvariantCulture);
        }

        public void SetBlockInfo(string blockInfo) {
            if(string.IsNullOrEmpty(blockInfo)) {
                return;
            }
            toolTip1.SetToolTip(this, blockInfo);
        }

        public void SetOver(float over) {
			l_over.Text = Math.Round(over, 2).ToString(CultureInfo.InvariantCulture);
		}

		public void SetOverPercent(float overPercent) {
			string tempProc = Math.Round(overPercent, 1).ToString(CultureInfo.InvariantCulture);
			l_overPercent.Text = $"{tempProc}%";
		}

		private void SetState(WheelControlState value) {
			_wheelState = value;
			bool flag = true;
			b_add.Visible = false;
			if (value == WheelControlState.One) {
				WheelPic.Image = Properties.Resources.one;
				pb_fix.Image = IsFixed ? Properties.Resources.fix_true : Properties.Resources.fix;
			} else if (value == WheelControlState.OnePnevmo) {
				WheelPic.Image = Properties.Resources.one_pnevmo;
				pb_fix.Image = IsFixed ? Properties.Resources.fix_true : Properties.Resources.fix;
			} else if (value == WheelControlState.Two) {
				WheelPic.Image = Properties.Resources.two;
				pb_fix.Image = IsFixed ? Properties.Resources.fix_true : Properties.Resources.fix;
			} else if (value == WheelControlState.TwoPnevmo) {
				WheelPic.Image = Properties.Resources.two_pnevmo;
				pb_fix.Image = IsFixed ? Properties.Resources.fix_true : Properties.Resources.fix;
			} else if (value == WheelControlState.Nothing) {
				ClearWheel();
				flag = false;
			} else if (value == WheelControlState.Plus) {
				ClearWheel();
				b_add.Visible = true;
				flag = false;
			}
			cbDouble.Visible = cbPnevmo.Visible = flag;
			tb_weightValueWithInaccuracy.Visible = flag;
			pb_fix.Enabled = l_overPercent.Visible = l_over.Visible = l_loadLimit.Visible = tb_scales_value.Visible = flag;
		}

		private float GetValueOrDefault(Control control) {
			if (control.Text != string.Empty) {
				try {
					return float.Parse(control.Text);
				} catch {
					// ignored
				}
			}
			return 0;
		}

		private void CheckButton_Click(object sender, EventArgs e) {
			if (_wheelState == WheelControlState.Nothing || _wheelState == WheelControlState.Plus) {
				return;
			}
			WheelState = cbDouble.IsOn
				? (cbPnevmo.IsOn ? WheelControlState.TwoPnevmo : WheelControlState.Two)
				: (cbPnevmo.IsOn ? WheelControlState.OnePnevmo : WheelControlState.One);
		}

		private void ClearWheel() {
			ClearWheelValues();
			tb_scales_value.Enabled = false;
			WheelPic.Image = null;
			pb_fix.Image = null;
			IsFixed = false;
			cbDouble.IsOn = false;
			cbPnevmo.IsOn = false;
		}

		public void ClearWheelValues() {
			tb_distanceToNext.Text = "0";
			tb_distanceToNextWithInaccuracy.Text = "0";
			tb_scales_value.Text = "0";
			tb_weightValueWithInaccuracy.Text = "0";
			l_loadLimit.Text = "0";
			l_over.Text = "0";
			l_overPercent.Text = "0%";
		}

		private void tb_ras_Leave(object sender, EventArgs e) {
            var value = tb_distanceToNext.Text.Replace('.', ',');
            DistanceToNext = float.Parse(value);
        }

		private void tb_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '.') {
                e.KeyChar = ',';
            }
            //if (((NumericUpDown)sender).SelectionLength > 5) { return; }
            if (sender is NumericUpDown numCtrl) {
                if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == ',' && numCtrl.Text.IndexOf(",") == -1 && numCtrl.Text.Length != 0)) {
                    if (e.KeyChar != (char)Keys.Back) {
                        e.Handled = true;
                    }
                }
            }
        }

		private void tb_Enter(object sender, EventArgs e) {
			if (sender is Label) {
				tb_distanceToNext.Select(0, tb_distanceToNext.Text.Length);
				//tb_nag.Select(0, tb_nag.Text.Length);
			}
		}

		private void tb_MouseClick(object sender, MouseEventArgs e) {
			if (sender is NumericUpDown down) {
				if (!string.IsNullOrEmpty(down.Text)) {
					down.Select(0, down.Text.Length);
				}
			}
		}
		
		private void pictureBox2_Click(object sender, EventArgs e) {
			pb_fix.Image = Properties.Resources.fix_true;
			IsFixed = true;
		}

		private void b_add_Click(object sender, EventArgs e) {
			ButtonAddClick?.Invoke(this, new EventArgs());
		}

		private void Wheel_DoubleClick(object sender, EventArgs e) {
			if (ModifierKeys == Keys.Shift) {
				tb_scales_value.Enabled = true;
			}
		}

		private void WheelControl_MouseEnter(object sender, EventArgs e) {
			if (Program.User == "Admin") {
				tb_scales_value.Enabled = true;
				IsFixed = true;
			}
		}
	}
}
