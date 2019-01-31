using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vesna.Business.Data;
using Vesna.Business.Utils;

namespace Vesna.Forms {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
			//wheelsControl1.CreateNewTC();
			if (!DesignMode) {
				wheelListControl.FillComboBox();
			}
		}

		private void CreateAct() {
			var fa = new ActForm();
			Auto tc = wheelListControl.GetTC();
			if (tc != null) {
				fa.LoadActFromAuto(tc);
				fa.ShowDialog();
				wheelListControl.Clear();
			}
		}

		private void Calculate() {
			wheelListControl.PopulateAndUpdate();
		}

		private void LoadFileDocuments() {
			var dir = new DirectoryInfo($@"{Application.StartupPath}\Files\Docs");
			if (!dir.Exists) {
				return;
			}
			foreach (FileInfo f in dir.GetFiles()) {
				Image icon = null;
				try {
					icon = Icon.ExtractAssociatedIcon(f.FullName).ToBitmap();
				} catch {
					// ignored
				}
				var menu = new ToolStripMenuItem(
					f.Name, 
					icon, 
					(o, ev) => Process.Start($@"{Application.StartupPath}\Files\Docs\{((ToolStripMenuItem)o).Text}"));
				DocToolStripMenuItem.DropDownItems.Add(menu);
			}
		}

		#region Events

		private void MainForm_Load(object sender, EventArgs e) {
			LoadFileDocuments();
		}	
		
		private void b_act_Click(object sender, EventArgs e) {
			CreateAct();
		}

		private void b_calc_Click(object sender, EventArgs e) {
			Calculate();
		}

		private void новоеТСToolStripMenuItem_Click(object sender, EventArgs e) {
			wheelListControl.Clear();
		}

		private void открытьБазуToolStripMenuItem_Click(object sender, EventArgs e) {
			new DataBaseForm().ShowDialog();
		}

		private void настройкиToolStripMenuItem_Click(object sender, EventArgs e) {
			new SettingForm().ShowDialog();
		}

		private void справочникиToolStripMenuItem1_Click(object sender, EventArgs e) {
			new SpravochnikForm().ShowDialog();
		}
	
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			VideoUtil.CloseVideoSource();
		}
		
		#endregion

		private void m_runAsAdmin_Click(object sender, EventArgs e) {
			var login = new LoginForm();
			login.ShowDialog();
		}
	}
}
