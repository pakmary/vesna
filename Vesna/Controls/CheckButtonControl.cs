using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vesna.Controls {
	public partial class CheckButtonControl : UserControl {
		public delegate void StatusChangedHander(object sender, EventArgs args);

		public event StatusChangedHander StatusChanged;

		private bool _isOn;
		public bool IsOn {
			get { return _isOn; }
			set {
				_isOn = value;
				if (StatusChanged != null) {
					StatusChanged.Invoke(this, new EventArgs());
				}
			}
		}

		public Image OnImage { get; set; }
		public Image OffImage { get; set; }

		public CheckButtonControl() {
			InitializeComponent();
		}

		private void UpdateState() {
			pictureBox1.Image = IsOn ? OnImage : OffImage;
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
			IsOn = !IsOn;
			UpdateState();
		}

		private void CheckButtonControl_Load(object sender, EventArgs e) {
			UpdateState();
		}

		private void CheckButtonControl_VisibleChanged(object sender, EventArgs e) {
			UpdateState();
		}
	}
}
