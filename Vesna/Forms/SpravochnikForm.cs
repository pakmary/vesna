using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Vesna {
	public partial class SpravochnikForm : Form {
		protected bool defVal = true;
		private DataTable dt;
		protected string tableName = "";

		public SpravochnikForm() {
			InitializeComponent();
			tv.ExpandAll(); // open treeview
		}

		protected virtual void Fill() {
			dt = Program.GetAccess("SELECT * FROM " + tableName);
			dataGridView1.DataSource = dt;
			if (dataGridView1.RowCount != 0 && dataGridView1.ColumnCount != 0) {
				dataGridView1.Columns["def"].Visible = defVal;
				dataGridView1.Columns["def"].DisplayIndex = 0;
				dataGridView1.Columns["def"].HeaderText = "Значение по умолчанию";
				dataGridView1.Columns["def"].Width = 90;
				dataGridView1.Columns["id"].Visible = false;
				//dataGridView1.Columns[1].Width = 1200/dataGridView1.ColumnCount;
			}
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == 0) {
				return;
			}
			if (e.RowIndex == -1 || dataGridView1.Rows.Count == 0 || dataGridView1.Columns["id"].Index == e.ColumnIndex) {
				return;
			}
			if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
				string str = string.Empty;
				string cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				Type cell_type = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType;
				string col_name = dataGridView1.Columns[e.ColumnIndex].Name;
				string row_id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

				if (cell_type == typeof(Boolean)) {
					if (cell == "True") {
						cell = "1";
					} else if (cell == "False") {
						cell = "0";
					}
				}

				if (row_id == "") {
					Program.MakeAccess(string.Format("INSERT INTO {0} default values ", tableName));
					row_id = Program.GetAccess(string.Format("SELECT TOP 1 id FROM {0} ORDER BY id DESC", tableName)).Rows[0][0].ToString();
					dataGridView1.Rows[e.RowIndex].Cells["id"].Value = row_id;
					//Program.AddToLog(DateTime.Now, "Добавлена новая запись в базу справочника " + tableName);
				}
				str = string.Format("UPDATE {0} SET {1} = '{2}' WHERE id = {3}", tableName, col_name, cell, row_id);
				Program.MakeAccess(str);
				//Program.AddToLog(DateTime.Now, "Внесены изменения в базу справочника " + tableName);
			}
		}

		private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
			if (dataGridView1.Rows.Count == 0 || dataGridView1.SelectedCells.Count == 0) {
				return;
			}
			if (dataGridView1.SelectedRows[0].Cells["def"].ValueType != typeof (Boolean)) {
				return;
			}

			int row_index = dataGridView1.SelectedRows[0].Index;
			foreach (DataGridViewRow r in dataGridView1.Rows) {
				if (!r.IsNewRow) {
					if (r.Index != row_index && r.Cells["def"].Value.ToString() != "False") {
						r.Cells["def"].Value = "False";
					}
				}
			}
		}

		private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			if (dataGridView1.Rows.Count != 0) {
				string row_id = dataGridView1.Rows[e.Row.Index].Cells["id"].Value.ToString();
				if (row_id != "") {
					Program.MakeAccess("DELETE FROM " + tableName + " WHERE id= " + row_id);
					//Program.AddToLog(DateTime.Now, "Удалена запись из базы справочника " + tableName);
				}
			}
		}

		private void tv_AfterSelect(object sender, TreeViewEventArgs e) {
			string si = tv.SelectedNode.Text;
			if (si == "Пункты весового контроля") {
				tableName = "sp_ppvk";
				defVal = true;
				Fill();
				dataGridView1.Columns["name_ppvk"].HeaderText = "Название ППВК";
			} else if (si == "Точки дислокации") {
				tableName = "sp_Dis_Point";
				defVal = true;
				Fill();
				dataGridView1.Columns["Disl_point"].HeaderText = "Точка дислокации";
			} else if (si == "Весовое оборудование") {
				tableName = "sp_Vesi";
				defVal = true;
				Fill();
				dataGridView1.Columns["Zavod_nomer"].HeaderText = "Заводской номер весов";
				//dataGridView1.Columns["Svidet_nomer"].HeaderText = "Номер свидет-ва";
				dataGridView1.Columns["DateOT"].HeaderText = "Дата поверки";
				dataGridView1.Columns["DateDO"].HeaderText = "Действителен до";
				dataGridView1.Columns["DateDO"].DisplayIndex = dataGridView1.Columns.Count - 1;
			} else if (si == "Марки ТС") {
				tableName = "sp_Mark";
				defVal = false;
				Fill();
				dataGridView1.Columns["name_Mark"].HeaderText = "Марка";
			} else if (si == "Организации") {
				tableName = "sp_Organ";
				defVal = false;
				Fill();
				dataGridView1.Columns["name_Organ"].HeaderText = "Название организации";
			} else if (si == "Виды груза") {
				tableName = "sp_Gruz";
				defVal = false;
				Fill();
				dataGridView1.Columns["name_gruz"].HeaderText = "Вид груза";
			} else if (si == "Инспектора ГИБДД") {
				tableName = "sp_Inspectors";
				defVal = true;
				Fill();
				dataGridView1.Columns["FIO"].HeaderText = "Имя инспектора";
			} else if (si == "Инспектора ППВК") {
				tableName = "sp_Operators";
				defVal = true;
				Fill();
				dataGridView1.Columns["FIO"].HeaderText = "Имя оператора";
			} else if (si == "Водители") {
				tableName = "sp_Driver";
				defVal = false;
				Fill();
				dataGridView1.Columns["name_Driver"].HeaderText = "Имя водителя";
			}
		}

		private void f_spr_FormClosing(object sender, FormClosingEventArgs e) {
			dataGridView1.EndEdit();
		}
	}
}
