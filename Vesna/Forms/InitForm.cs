using System;
using System.Reflection;
using System.Windows.Forms;
using Vesna.Business.Data;
using Vesna.Business.Utils;

namespace Vesna.Forms {
	public partial class InitForm : Form {
		public InitForm() {
			InitializeComponent();
			Text += $" {Assembly.GetExecutingAssembly().GetName().Version}";
			cb_imya_ppvk.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_ppvk", "name_ppvk"));
			cb_vesi_zavod_nomer.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Vesi", "Zavod_nomer"));
			cb_mesto_prov.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Dis_Point", "Disl_point"));
			cb_Vid_Dor.Items.AddRange(SpravochnikUtil.GetItemCollections("TypesRoad", "Description", false));

			cb_imya_ppvk.Text = SpravochnikUtil.GetDefaultValue("sp_ppvk", "name_ppvk");
			cb_vesi_zavod_nomer.Text = SpravochnikUtil.GetDefaultValue("sp_Vesi", "Zavod_nomer");
			cb_mesto_prov.Text = SpravochnikUtil.GetDefaultValue("sp_Dis_Point", "Disl_point");
			cb_Vid_Dor.SelectedIndex = 0;
			cb_Clothes.SelectedIndex = 0;
			cb_Level.SelectedIndex = 1;
		}

		private void button2_Click(object sender, EventArgs e) {
			var mf = new MainForm();
			Program.PpvkName = cb_imya_ppvk.Text;
			Program.ControlPlace = cb_mesto_prov.Text;
			Program.ScaleNumber = cb_vesi_zavod_nomer.Text;
			Program.CurrentRoadType = (RoadType)cb_Vid_Dor.SelectedIndex + 1;
			Program.IsFederalRoad = cb_Level.SelectedIndex == 0;
			Program.IsSoftRoad = cb_Clothes.SelectedIndex == 1;
			Visible = false;
			mf.ShowDialog();
			Visible = true;
		}

		private void cb_vesi_zavod_nomer_SelectedValueChanged(object sender, EventArgs e) {
			l_VesiAbout.Text = SpravochnikUtil.ToStringVesiDate(cb_vesi_zavod_nomer.SelectedItem.ToString());
		}
	}
}
