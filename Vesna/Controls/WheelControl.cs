using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Vesna.VesnaEventArgs;
using Point = System.Drawing.Point;

namespace Vesna.Controls {
	public partial class WheelControl : UserControl {

		#region Свойства и Делегаты

		private Point UpOnPoint = new Point(0, 33);
		private Point UpOffPoint = new Point(0, 43);

		public int Index { get; set; }

		public delegate void WheelStatusChangedHandler(object o, WheelStateArgs e);
		public event WheelStatusChangedHandler WheelStatusChanged;
		public delegate void WheelNagruzkaChangedHandler(object o, WheelLoadArgs e);
		public event WheelNagruzkaChangedHandler WheelNagruzkaChanged;
		public delegate void WheelRastoyanChangedHandler(object o, WheelDistanceArgs e);
		public event WheelRastoyanChangedHandler WheelRastoyanChanged;
		public event EventHandler ButtonAddClick;

		public bool IsFixed = false;
		private WheelControlState _wheelState;

		public WheelControlState WheelState {
			get { return _wheelState; }
			set {
				var e = new WheelStateArgs(Index, _wheelState, value);
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
				cbDouble.Visible = cbPnevmo.Visible = cbUpper.Visible = 
						pb_fix.Enabled = l_procent.Visible = l_pereves.Visible = l_nagDop.Visible = tb_nag.Visible = flag;

				if (WheelStatusChanged != null) {
					WheelStatusChanged(this, e);
				}
			}
		}

		public float Nagruzka {
			get {
				if (tb_nag.Text == "") {
					return 0;
				}
				try {
					return float.Parse(tb_nag.Text);
				} catch {}
				return 0;
			}
			set {
				var e = new WheelLoadArgs(Index, value);
				tb_nag.Text = value.ToString(CultureInfo.InvariantCulture).Replace(".", ",");

				if (WheelNagruzkaChanged != null) {
					WheelNagruzkaChanged(this, e);
				} //событие -  изменение нагрузки
			}
		}

		public float NagruzkaDopust {
			get {
				if (l_nagDop.Text == string.Empty) {
					return 0;
				}
				try {
					return float.Parse(l_nagDop.Text);
				} catch {}
				return 0;
			}
			set {
				l_nagDop.Text = value.ToString();
				if (value < Nagruzka) //при изменении допустимой массы автомотически меняется процент и перевесом
				{
					double temp_perev = Math.Round(Nagruzka - value, 2);
					double temp_proc = Math.Round(((temp_perev/value)*100), 1);
					l_pereves.Text = temp_perev.ToString();
					l_procent.Text = temp_proc + "%";
				} else {
					l_pereves.Text = "0";
					l_procent.Text = "0";
				}
			}
		}

		public float RastoyanDoSledOs {
			get {
				if (tb_ras.Text == string.Empty) {
					return 0;
				}
				try {
					return float.Parse(tb_ras.Text);
				} catch {}
				return 0;
			}
			set {
				var e = new WheelDistanceArgs(Index, value);
				tb_ras.Text = value.ToString(CultureInfo.InvariantCulture);
				if (WheelRastoyanChanged != null) {
					WheelRastoyanChanged(this, e);
				} //событие -  изменение растояния
			}
		}

		public bool IsUpper {
			get { return cbUpper.IsOn; }
			set { cbUpper.IsOn = value; }
		}

		#endregion

		public WheelControl() {
			InitializeComponent();
			if (!DesignMode) {
				cbUpper.OffImage = Properties.Resources.wheelUpOff;
				cbUpper.OnImage = Properties.Resources.wheelUp;
				cbPnevmo.OffImage = Properties.Resources.wheelPnevmoOff;
				cbPnevmo.OnImage = Properties.Resources.wheelPnevmo;
				cbDouble.OffImage = Properties.Resources.wheelDualOff;
				cbDouble.OnImage = Properties.Resources.wheelDual;
			}
		}

		private void CheckButton_Click(object sender, EventArgs e) {
			if (_wheelState == WheelControlState.Nothing || _wheelState == WheelControlState.Plus) {
				return;
			}
			WheelState = cbDouble.IsOn
				? (cbPnevmo.IsOn ? WheelControlState.TwoPnevmo : WheelControlState.Two)
				: (cbPnevmo.IsOn ? WheelControlState.OnePnevmo : WheelControlState.One);
			WheelPic.Location = cbUpper.IsOn ? UpOnPoint : UpOffPoint;
		}

		private void ClearWheel() {
			Nagruzka = 0;
			NagruzkaDopust = 0;
			RastoyanDoSledOs = 0;
			tb_nag.Enabled = false;
			WheelPic.Image = null;
			pb_fix.Image = null;
			IsFixed = false;
			cbDouble.IsOn = false;
			cbPnevmo.IsOn = false;
			cbUpper.IsOn = false;
			WheelPic.Location = UpOffPoint;
		}

		private void Fix() {
			IsFixed = true;
		}

		private void tb_ras_Leave(object sender, EventArgs e) {
			tb_ras.Text = tb_ras.Text.Replace('.', ',');
			RastoyanDoSledOs = float.Parse(tb_ras.Text);
		}

		private void tb_nag_Leave(object sender, EventArgs e) {
			tb_nag.Text = tb_nag.Text.Replace('.', ',');
			Nagruzka = float.Parse(tb_nag.Text);
		}

		private void tb_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == '.') {
				e.KeyChar = ',';
			}
			//if (((NumericUpDown)sender).SelectionLength > 5) { return; }
			var numCtrl = sender as NumericUpDown;
			if (numCtrl != null) {
				if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar == ',' && numCtrl.Text.IndexOf(",") == -1 && numCtrl.Text.Length != 0)) {
					if (e.KeyChar != (char) Keys.Back) {
						e.Handled = true;
					}
				}
			}
		}

		private void tb_Enter(object sender, EventArgs e) {
			if (sender is Label) {
				tb_ras.Select(0, tb_ras.Text.Length);
				//tb_nag.Select(0, tb_nag.Text.Length);
			}
		}

		private void tb_MouseClick(object sender, MouseEventArgs e) {
			if (sender is NumericUpDown) {
				if (!String.IsNullOrEmpty(((NumericUpDown) sender).Text)) {
					((NumericUpDown) sender).Select(0, ((NumericUpDown) sender).Text.ToString().Length);
				}
			}
		}

		private void Wheel_DoubleClick(object sender, EventArgs e) {
			if (ModifierKeys == Keys.Shift) {
				tb_nag.Enabled = true;
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e) {
			pb_fix.Image = Properties.Resources.fix_true;
			Fix();
		}

		private void b_add_Click(object sender, EventArgs e) {
			if (ButtonAddClick != null) {
				ButtonAddClick(this, new EventArgs());
			}
		}

		private void WheelControl_MouseHover(object sender, EventArgs e) {

		}

		private void WheelControl_MouseEnter(object sender, EventArgs e) {
			if (Program.User == "Admin") {
				tb_nag.Enabled = true;
				Fix();
			}
		}
	}
}
