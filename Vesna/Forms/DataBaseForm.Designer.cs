namespace Vesna.Forms
{
    partial class DataBaseForm
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
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.razmer_usherba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primechanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.b_print = new System.Windows.Forms.Button();
            this.tb_primech = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.razmer_usherba,
            this.primechanie});
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1228, 384);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.OpenInWord);
            // 
            // razmer_usherba
            // 
            this.razmer_usherba.DataPropertyName = "razmer_usherba";
            this.razmer_usherba.HeaderText = "Размер ущерба";
            this.razmer_usherba.Name = "razmer_usherba";
            this.razmer_usherba.ReadOnly = true;
            this.razmer_usherba.Width = 70;
            // 
            // primechanie
            // 
            this.primechanie.DataPropertyName = "primechanie";
            this.primechanie.HeaderText = "primechanie";
            this.primechanie.Name = "primechanie";
            this.primechanie.ReadOnly = true;
            this.primechanie.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Отктыть акт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenInWord);
            // 
            // b_print
            // 
            this.b_print.Location = new System.Drawing.Point(1, 434);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(85, 38);
            this.b_print.TabIndex = 2;
            this.b_print.Text = "Печать";
            this.b_print.UseVisualStyleBackColor = true;
            // 
            // tb_primech
            // 
            this.tb_primech.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_primech.Location = new System.Drawing.Point(92, 390);
            this.tb_primech.Multiline = true;
            this.tb_primech.Name = "tb_primech";
            this.tb_primech.Size = new System.Drawing.Size(1137, 82);
            this.tb_primech.TabIndex = 3;
            // 
            // f_base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 477);
            this.Controls.Add(this.tb_primech);
            this.Controls.Add(this.b_print);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_base";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База взвешиваний";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_print;
        private System.Windows.Forms.TextBox tb_primech;
        private System.Windows.Forms.DataGridViewTextBoxColumn razmer_usherba;
        private System.Windows.Forms.DataGridViewTextBoxColumn primechanie;
    }
}