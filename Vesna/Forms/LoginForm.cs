using System;
using System.Windows.Forms;

namespace Vesna.Forms {
	public partial class LoginForm : Form {
		public LoginForm() {
			InitializeComponent();
		}

		private bool CheckUser() {
			if (textBox1.Text == "retro") {
				return true;
			}
			return false;
		}

		private void button1_Click(object sender, EventArgs e) {
			if (!CheckUser()) {
				MessageBox.Show("Неверный пароль");
				return;
			}
			Program.User = "Admin";
			Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
