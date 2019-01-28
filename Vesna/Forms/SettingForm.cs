using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vesna.Business;
using Vesna.Utils;

namespace Vesna {
	public partial class SettingForm : Form {
		public SettingForm() {
			InitializeComponent();
		}

		private void FormSetting_Load(object sender, EventArgs e) {
			bool adm = Program.User == "Admin";

			tb_index_goda.Enabled = label1.Enabled = label3.Enabled = tb_id_car.Enabled = l_run.Enabled = tb_run.Enabled = b_run.Enabled = adm;
			tb_index_goda.Text = Calculator.YearIndex.ToString();
			checkBox1.Checked = Calculator.KlimatUsloviya;
			tb_id_car.Text = SpravochnikUtil.IdentificationNumber.ToString();
			cb_com_name.Text = Properties.Settings.Default.COMPortName;
			cb_com_name.Items.AddRange(ComInfo.GetListCOM());
		}

		private void button1_Click(object sender, EventArgs e) {
			Calculator.YearIndex = float.Parse(tb_index_goda.Text);
			Calculator.KlimatUsloviya = checkBox1.Checked;
			SpravochnikUtil.IdentificationNumber = int.Parse(tb_id_car.Text);
			Properties.Settings.Default.COMPortName = cb_com_name.Text;

			Properties.Settings.Default.Save();
			Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			Close();
		}

		private void b_run_Click(object sender, EventArgs e) {
			Program.MakeAccess(tb_run.Text);
		}
	}
}
