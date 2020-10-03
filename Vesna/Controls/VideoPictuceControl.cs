using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using Vesna.Business.Utils;

namespace Vesna {
	public partial class VideoPictuceControl : UserControl {
		private bool _big;

		public VideoPictuceControl() {
			InitializeComponent();
			//Video.Start(comboBox1.SelectedIndex);
		}

		private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs) {
			var img = (Bitmap)eventArgs.Frame.Clone();
			pictureBox1.Image = img;
		}

		private void VideoPictuce_Load(object sender, EventArgs e) {
			comboBox1.Items.Add("Из файла");
			comboBox1.Items.AddRange(VideoUtil.GetCamList());
			comboBox1.SelectedIndex = 0;
		}

		private void b_action_Click(object sender, EventArgs e) {
			if (b_action.Text == "Обзор") {
				if (openFileDialog1.ShowDialog() == DialogResult.OK) {
					pictureBox1.Image = ResizeImg(Image.FromFile(openFileDialog1.FileName), 300, 300);
				}
			} else if (b_action.Text == "Снимок") {
				VideoUtil.CloseVideoSource();
				b_action.Text = "Видео";
			} else if (b_action.Text == "Видео") {
				VideoUtil.Start(comboBox1.SelectedIndex - 1);
				VideoUtil.VideoSource.NewFrame += videoSource_NewFrame;
				b_action.Text = "Снимок";
			}
		}

		public Image ResizeImg(Image b, int nWidth, int nHeight) {
			var result = new Bitmap(nWidth, nHeight);
			using (Graphics g = Graphics.FromImage(result)) {
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.DrawImage(b, 0, 0, nWidth, nHeight);
				g.Dispose();
			}
			return result;
		}

		public Image GetImage() {
			return pictureBox1.Image;
		}

		public void SetImage(Image img) {
			pictureBox1.Image = img;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (comboBox1.Text == "Из файла") {
				b_action.Text = "Обзор";
			} else if (VideoUtil.VideoSource == null) {
				b_action.Text = "Видео";
			} else {
				b_action.Text = "Снимок";
			}
		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e) {
			if (!_big) {
				Height *= 2;
				Width *= 3;
				_big = true;
			} else if (_big) {
				Height /= 2;
				Width /= 3;
				_big = false;
			}
		}
	}
}