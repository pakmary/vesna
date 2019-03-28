using System;
using System.Windows.Forms;
using Vesna.Business.Utils;
using Vesna.Properties;

namespace Vesna {
	public partial class SettingForm : Form {
		private readonly Control[] _adminAccessControlList;

		public SettingForm() {
			InitializeComponent();
			_adminAccessControlList = new Control[] {
				tb_inaccuracy_roulette,
				tb_inaccuracy_scales,
				tb_index_goda,
				label1,
				label3,
				label5,
				label6,
				tb_id_car,
				l_run,
				tb_run,
				b_run
			};
		}

		private void FormSetting_Load(object sender, EventArgs e) {
			bool adm = Program.User == "Admin";
			foreach (Control control in _adminAccessControlList) {
				control.Enabled = adm;
			}
			tb_dopustAxis.Text = Settings.Default.DopustimiyProcentAxis.ToString();
			tb_dopustFullMass.Text = Settings.Default.DopustimiyProcentFullMass.ToString();
			tb_index_goda.Text = Settings.Default.YearIndex.ToString();
			checkBox1.Checked = Settings.Default.Klimat_usloviya;
			tb_id_car.Text = SpravochnikUtil.IdentificationNumber.ToString();
			cb_com_name.Text = Settings.Default.COMPortName;
			cb_com_name.Items.AddRange(ComInfo.GetListCOM());
			tb_inaccuracy_scales.Text = Settings.Default.InaccuracyScales.ToString();
			tb_inaccuracy_roulette.Text = Settings.Default.InaccuracyRoulette.ToString();
		}

		private void button1_Click(object sender, EventArgs e) {
			try {
				Settings.Default.DopustimiyProcentAxis = float.Parse(tb_dopustAxis.Text);
				Settings.Default.DopustimiyProcentFullMass = float.Parse(tb_dopustFullMass.Text);

				Settings.Default.YearIndex = float.Parse(tb_index_goda.Text);
				Settings.Default.Klimat_usloviya = checkBox1.Checked;
				SpravochnikUtil.IdentificationNumber = int.Parse(tb_id_car.Text);
				Settings.Default.COMPortName = cb_com_name.Text;
				Settings.Default.InaccuracyScales = float.Parse(tb_inaccuracy_scales.Text);
				Settings.Default.InaccuracyRoulette = float.Parse(tb_inaccuracy_roulette.Text);

				Settings.Default.Save();
				Close();
			} catch (Exception) {
				MessageBox.Show("Ошибка: Неверный параметр");
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			Close();
		}

		private void b_run_Click(object sender, EventArgs e) {
			Program.MakeAccess(tb_run.Text);
		}
	}
}
