using System;
using System.Data;
using System.Windows.Forms;

namespace Vesna {
	public partial class SpravochnikForm : Form {
		private bool _defaultValue = true;
		private string _tableName = string.Empty;
		private DataTable _dataTable;

		public SpravochnikForm() {
			InitializeComponent();
			tv.ExpandAll(); // open treeview
		}

		protected virtual void Fill() {
			_dataTable = Program.GetAccess("SELECT * FROM " + _tableName);
			dataGridView1.DataSource = _dataTable;
			if (dataGridView1.RowCount != 0 && dataGridView1.ColumnCount != 0) {
				dataGridView1.Columns["def"].Visible = _defaultValue;
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
				string cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				Type cellType = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType;
				string colName = dataGridView1.Columns[e.ColumnIndex].Name;
				string rowID = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

				if (cellType == typeof(bool)) {
					if (cell == "True") {
						cell = "1";
					} else if (cell == "False") {
						cell = "0";
					}
				}

				if (rowID == "") {
					Program.MakeAccess($"INSERT INTO {_tableName} default values ");
					rowID = Program.GetAccess($"SELECT TOP 1 id FROM {_tableName} ORDER BY id DESC").Rows[0][0].ToString();
					dataGridView1.Rows[e.RowIndex].Cells["id"].Value = rowID;
					//Program.AddToLog(DateTime.Now, "Добавлена новая запись в базу справочника " + tableName);
				}
				string str = $"UPDATE {_tableName} SET {colName} = '{cell}' WHERE id = {rowID}";
				Program.MakeAccess(str);
				//Program.AddToLog(DateTime.Now, "Внесены изменения в базу справочника " + tableName);
			}
		}

		private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
			if (dataGridView1.Rows.Count == 0 || dataGridView1.SelectedCells.Count == 0) {
				return;
			}
			if (dataGridView1.SelectedRows[0].Cells["def"].ValueType != typeof(bool)) {
				return;
			}

			int rowIndex = dataGridView1.SelectedRows[0].Index;
			foreach (DataGridViewRow r in dataGridView1.Rows) {
				if (!r.IsNewRow) {
					if (r.Index != rowIndex && r.Cells["def"].Value.ToString() != "False") {
						r.Cells["def"].Value = "False";
					}
				}
			}
		}

		private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			if (dataGridView1.Rows.Count != 0) {
				string rowID = dataGridView1.Rows[e.Row.Index].Cells["id"].Value.ToString();
				if (rowID != "") {
					Program.MakeAccess($"DELETE FROM {_tableName} WHERE id= {rowID}");
					//Program.AddToLog(DateTime.Now, "Удалена запись из базы справочника " + tableName);
				}
			}
		}

		private void tv_AfterSelect(object sender, TreeViewEventArgs e) {
			string si = tv.SelectedNode.Text;
			if (si == "Пункты весового контроля") {
				_tableName = "sp_ppvk";
				_defaultValue = true;
				Fill();
				dataGridView1.Columns["name_ppvk"].HeaderText = "Название ППВК";
			} else if (si == "Точки дислокации") {
				_tableName = "sp_Dis_Point";
				_defaultValue = true;
				Fill();
				dataGridView1.Columns["Disl_point"].HeaderText = "Точка дислокации";
			} else if (si == "Весовое оборудование") {
				_tableName = "sp_Vesi";
				_defaultValue = true;
				Fill();
				dataGridView1.Columns["Zavod_nomer"].HeaderText = "Заводской номер весов";
				//dataGridView1.Columns["Svidet_nomer"].HeaderText = "Номер свидет-ва";
				dataGridView1.Columns["DateOT"].HeaderText = "Дата поверки";
				dataGridView1.Columns["DateDO"].HeaderText = "Действителен до";
				dataGridView1.Columns["DateDO"].DisplayIndex = dataGridView1.Columns.Count - 1;
			} else if (si == "Марки ТС") {
				_tableName = "sp_Mark";
				_defaultValue = false;
				Fill();
				dataGridView1.Columns["name_Mark"].HeaderText = "Марка";
			} else if (si == "Организации") {
				_tableName = "sp_Organ";
				_defaultValue = false;
				Fill();
				dataGridView1.Columns["name_Organ"].HeaderText = "Название организации";
			} else if (si == "Виды груза") {
				_tableName = "sp_Gruz";
				_defaultValue = false;
				Fill();
				dataGridView1.Columns["name_gruz"].HeaderText = "Вид груза";
			} else if (si == "Инспектора ГИБДД") {
				_tableName = "sp_Inspectors";
				_defaultValue = true;
				Fill();
				dataGridView1.Columns["FIO"].HeaderText = "Имя инспектора";
			} else if (si == "Инспектора ППВК") {
				_tableName = "sp_Operators";
				_defaultValue = true;
				Fill();
				dataGridView1.Columns["FIO"].HeaderText = "Имя оператора";
			} else if (si == "Водители") {
				_tableName = "sp_Driver";
				_defaultValue = false;
				Fill();
				dataGridView1.Columns["name_Driver"].HeaderText = "Имя водителя";
			}
		}

		private void f_spr_FormClosing(object sender, FormClosingEventArgs e) {
			dataGridView1.EndEdit();
		}
	}
}
