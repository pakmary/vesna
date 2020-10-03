namespace Vesna
{
    partial class SpravochnikForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Пункты весового контроля");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Точки дислокации");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Весовое оборудование");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Марки ТС");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Организации");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Виды груза");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Инспектора ГИБДД");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Инспектора ППВК");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Водители");
            System.Windows.Forms.TreeNode treeNode10 =
                new System.Windows.Forms.TreeNode(
                    "Справочники", new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5, treeNode6, treeNode7, treeNode8, treeNode9 });
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tv = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 35;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(262, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(642, 519);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // tv
            // 
            this.tv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Пункты весового контроля";
            treeNode2.Name = "Узел3";
            treeNode2.Text = "Точки дислокации";
            treeNode3.Name = "Узел4";
            treeNode3.Text = "Весовое оборудование";
            treeNode4.Name = "Узел5";
            treeNode4.Text = "Марки ТС";
            treeNode5.Name = "Узел6";
            treeNode5.Text = "Организации";
            treeNode6.Name = "Узел7";
            treeNode6.Text = "Виды груза";
            treeNode7.Name = "Узел8";
            treeNode7.Text = "Инспектора ГИБДД";
            treeNode8.Name = "Узел13";
            treeNode8.Text = "Инспектора ППВК";
            treeNode9.Name = "Узел14";
            treeNode9.Text = "Водители";
            treeNode10.Name = "Узел0";
            treeNode10.Text = "Справочники";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode10 });
            this.tv.Size = new System.Drawing.Size(255, 519);
            this.tv.TabIndex = 2;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // SpravochnikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 520);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpravochnikForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_spr_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView tv;

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}