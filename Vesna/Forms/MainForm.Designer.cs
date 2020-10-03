using Vesna.Controls;

namespace Vesna.Forms {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новоеТСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьБазуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_runAsAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.DocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b_calc = new System.Windows.Forms.Button();
            this.b_act = new System.Windows.Forms.Button();
            this.wheelListControl = new Vesna.Controls.WheelListControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.базаToolStripMenuItem,
            this.DocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1253, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новоеТСToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новоеТСToolStripMenuItem
            // 
            this.новоеТСToolStripMenuItem.Name = "новоеТСToolStripMenuItem";
            this.новоеТСToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.новоеТСToolStripMenuItem.Text = "Новое ТС";
            this.новоеТСToolStripMenuItem.Click += new System.EventHandler(this.новоеТСToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // базаToolStripMenuItem
            // 
            this.базаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьБазуToolStripMenuItem,
            this.справочникиToolStripMenuItem1,
            this.настройкиToolStripMenuItem,
            this.m_runAsAdmin});
            this.базаToolStripMenuItem.Name = "базаToolStripMenuItem";
            this.базаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.базаToolStripMenuItem.Text = "Сервис";
            // 
            // открытьБазуToolStripMenuItem
            // 
            this.открытьБазуToolStripMenuItem.Name = "открытьБазуToolStripMenuItem";
            this.открытьБазуToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.открытьБазуToolStripMenuItem.Text = "База актов";
            this.открытьБазуToolStripMenuItem.Click += new System.EventHandler(this.открытьБазуToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem1
            // 
            this.справочникиToolStripMenuItem1.Name = "справочникиToolStripMenuItem1";
            this.справочникиToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.справочникиToolStripMenuItem1.Text = "Справочники";
            this.справочникиToolStripMenuItem1.Click += new System.EventHandler(this.справочникиToolStripMenuItem1_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // m_runAsAdmin
            // 
            this.m_runAsAdmin.Name = "m_runAsAdmin";
            this.m_runAsAdmin.Size = new System.Drawing.Size(211, 22);
            this.m_runAsAdmin.Text = "Войти администратором";
            this.m_runAsAdmin.Click += new System.EventHandler(this.m_runAsAdmin_Click);
            // 
            // DocToolStripMenuItem
            // 
            this.DocToolStripMenuItem.Name = "DocToolStripMenuItem";
            this.DocToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.DocToolStripMenuItem.Text = "Документы";
            // 
            // b_calc
            // 
            this.b_calc.BackColor = System.Drawing.Color.Snow;
            this.b_calc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_calc.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_calc.Location = new System.Drawing.Point(12, 542);
            this.b_calc.Name = "b_calc";
            this.b_calc.Size = new System.Drawing.Size(135, 32);
            this.b_calc.TabIndex = 2;
            this.b_calc.Text = "Рассчитать";
            this.b_calc.UseVisualStyleBackColor = false;
            this.b_calc.Click += new System.EventHandler(this.b_calc_Click);
            // 
            // b_act
            // 
            this.b_act.BackColor = System.Drawing.Color.Snow;
            this.b_act.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_act.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_act.ForeColor = System.Drawing.Color.Red;
            this.b_act.Location = new System.Drawing.Point(171, 542);
            this.b_act.Name = "b_act";
            this.b_act.Size = new System.Drawing.Size(135, 32);
            this.b_act.TabIndex = 3;
            this.b_act.Text = "Создать акт";
            this.b_act.UseVisualStyleBackColor = false;
            this.b_act.Click += new System.EventHandler(this.b_act_Click);
            // 
            // wheelListControl
            // 
            this.wheelListControl.BackColor = System.Drawing.Color.White;
            this.wheelListControl.Location = new System.Drawing.Point(9, 27);
            this.wheelListControl.Name = "wheelListControl";
            this.wheelListControl.Size = new System.Drawing.Size(1225, 509);
            this.wheelListControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1253, 585);
            this.Controls.Add(this.b_act);
            this.Controls.Add(this.b_calc);
            this.Controls.Add(this.wheelListControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "\"Весна\"";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem новоеТСToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьБазуToolStripMenuItem;
		private WheelListControl wheelListControl;
		private System.Windows.Forms.Button b_calc;
		private System.Windows.Forms.Button b_act;
		private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DocToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem m_runAsAdmin;
	}
}