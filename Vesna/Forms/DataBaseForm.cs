using System;
using System.ComponentModel;
using System.Windows.Forms;
using Vesna.Business;
using Vesna.Utils;

namespace Vesna.Forms {
	public partial class DataBaseForm : Form {
		public DataBaseForm() {
			InitializeComponent();
			LoadBase();
		}

		/*private void FillPrimech()
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (tb_primech.Text != dataGridView1.SelectedRows[0].Cells[dataGridView1.ColumnCount - 1].Value.ToString())
                {
                    dataGridView1.SelectedRows[0].Cells[dataGridView1.ColumnCount - 1].Value = tb_primech.Text;
                }
            }
        }*/

		private void OpenInWord(object sender, EventArgs e) {
			if (dataGridView1.SelectedRows.Count != 0) {
				int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
				WordExportUtil.Export(new Auto(id));
			}
		}

		private void LoadBase() {
			dataGridView1.DataSource = Program.GetAccess("SELECT * FROM MainTable");
			dataGridView1.Sort(dataGridView1.Columns["id"], ListSortDirection.Descending);
		}

		/*private void f_base_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database_inspectorDataSet.MainTable". При необходимости она может быть перемещена или удалена.
            this.mainTableTableAdapter.Fill(this.database_inspectorDataSet.MainTable);

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0) { tb_primech.Text = dataGridView1.SelectedRows[0].Cells[dataGridView1.ColumnCount - 1].Value.ToString(); }
        }

        private void tb_primech_Leave(object sender, EventArgs e)
        {
            FillPrimech();
        }

        private void f_base_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dataGridView1.Focus();
            FillPrimech();
            //MessageBox.Show(database_inspectorDataSet.MainTable[dataGridView1.SelectedRows[0].Index][dataGridView1.Columns.Count - 1].ToString());
            //database_inspectorDataSet.MainTable.
            //mainTableTableAdapter.Update(database_inspectorDataSet.MainTable);
        }

        private void f_base_FormClosed(object sender, FormClosedEventArgs e)
        {


        }*/
	}
}
