namespace Vesna.Controls {
	partial class WheelControl {
		/// <summary> 
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.l_nagDop = new System.Windows.Forms.Label();
			this.l_pereves = new System.Windows.Forms.Label();
			this.l_procent = new System.Windows.Forms.Label();
			this.tb_ras = new System.Windows.Forms.NumericUpDown();
			this.b_add = new System.Windows.Forms.Button();
			this.tb_scales_value = new System.Windows.Forms.NumericUpDown();
			this.pb_fix = new System.Windows.Forms.PictureBox();
			this.WheelPic = new System.Windows.Forms.PictureBox();
			this.cbUpper = new Vesna.Controls.CheckButtonControl();
			this.cbPnevmo = new Vesna.Controls.CheckButtonControl();
			this.cbDouble = new Vesna.Controls.CheckButtonControl();
			this.tb_nagruz = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tb_ras)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_scales_value)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_fix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WheelPic)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(-4, 256);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "                                   ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(-5, 233);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "                                   ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(-6, 279);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "                                   ";
			// 
			// l_nagDop
			// 
			this.l_nagDop.AutoSize = true;
			this.l_nagDop.BackColor = System.Drawing.Color.Transparent;
			this.l_nagDop.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_nagDop.ForeColor = System.Drawing.Color.Red;
			this.l_nagDop.Location = new System.Drawing.Point(3, 252);
			this.l_nagDop.Name = "l_nagDop";
			this.l_nagDop.Size = new System.Drawing.Size(16, 20);
			this.l_nagDop.TabIndex = 8;
			this.l_nagDop.Text = "0";
			// 
			// l_pereves
			// 
			this.l_pereves.AutoSize = true;
			this.l_pereves.BackColor = System.Drawing.Color.Transparent;
			this.l_pereves.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_pereves.Location = new System.Drawing.Point(3, 275);
			this.l_pereves.Name = "l_pereves";
			this.l_pereves.Size = new System.Drawing.Size(16, 20);
			this.l_pereves.TabIndex = 11;
			this.l_pereves.Text = "0";
			this.l_pereves.Visible = false;
			// 
			// l_procent
			// 
			this.l_procent.AutoSize = true;
			this.l_procent.BackColor = System.Drawing.Color.Transparent;
			this.l_procent.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_procent.Location = new System.Drawing.Point(3, 298);
			this.l_procent.Name = "l_procent";
			this.l_procent.Size = new System.Drawing.Size(16, 20);
			this.l_procent.TabIndex = 12;
			this.l_procent.Text = "0";
			this.l_procent.Visible = false;
			// 
			// tb_ras
			// 
			this.tb_ras.DecimalPlaces = 2;
			this.tb_ras.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_ras.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.tb_ras.Location = new System.Drawing.Point(42, 93);
			this.tb_ras.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.tb_ras.Name = "tb_ras";
			this.tb_ras.Size = new System.Drawing.Size(63, 25);
			this.tb_ras.TabIndex = 13;
			this.tb_ras.Visible = false;
			this.tb_ras.Enter += new System.EventHandler(this.tb_Enter);
			this.tb_ras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
			this.tb_ras.Leave += new System.EventHandler(this.tb_ras_Leave);
			this.tb_ras.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_MouseClick);
			// 
			// b_add
			// 
			this.b_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.b_add.Location = new System.Drawing.Point(5, 157);
			this.b_add.Name = "b_add";
			this.b_add.Size = new System.Drawing.Size(94, 43);
			this.b_add.TabIndex = 16;
			this.b_add.Text = "+";
			this.b_add.UseVisualStyleBackColor = false;
			this.b_add.Visible = false;
			this.b_add.Click += new System.EventHandler(this.b_add_Click);
			// 
			// tb_scales_value
			// 
			this.tb_scales_value.DecimalPlaces = 3;
			this.tb_scales_value.Enabled = false;
			this.tb_scales_value.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_scales_value.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.tb_scales_value.Location = new System.Drawing.Point(-1, 202);
			this.tb_scales_value.Name = "tb_scales_value";
			this.tb_scales_value.Size = new System.Drawing.Size(73, 25);
			this.tb_scales_value.TabIndex = 18;
			this.tb_scales_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
			this.tb_scales_value.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_MouseClick);
			// 
			// pb_fix
			// 
			this.pb_fix.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_fix.Location = new System.Drawing.Point(73, 184);
			this.pb_fix.Name = "pb_fix";
			this.pb_fix.Size = new System.Drawing.Size(32, 43);
			this.pb_fix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_fix.TabIndex = 15;
			this.pb_fix.TabStop = false;
			this.pb_fix.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// WheelPic
			// 
			this.WheelPic.Image = global::Vesna.Properties.Resources.one;
			this.WheelPic.Location = new System.Drawing.Point(-1, 34);
			this.WheelPic.Name = "WheelPic";
			this.WheelPic.Size = new System.Drawing.Size(73, 122);
			this.WheelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.WheelPic.TabIndex = 0;
			this.WheelPic.TabStop = false;
			// 
			// cbUpper
			// 
			this.cbUpper.BackColor = System.Drawing.Color.Silver;
			this.cbUpper.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbUpper.IsOn = false;
			this.cbUpper.Location = new System.Drawing.Point(73, 2);
			this.cbUpper.Name = "cbUpper";
			this.cbUpper.OffImage = null;
			this.cbUpper.OnImage = null;
			this.cbUpper.Size = new System.Drawing.Size(30, 30);
			this.cbUpper.TabIndex = 21;
			this.cbUpper.StatusChanged += new Vesna.Controls.CheckButtonControl.StatusChangedHander(this.CheckButton_Click);
			// 
			// cbPnevmo
			// 
			this.cbPnevmo.BackColor = System.Drawing.Color.Silver;
			this.cbPnevmo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbPnevmo.IsOn = false;
			this.cbPnevmo.Location = new System.Drawing.Point(37, 2);
			this.cbPnevmo.Name = "cbPnevmo";
			this.cbPnevmo.OffImage = null;
			this.cbPnevmo.OnImage = null;
			this.cbPnevmo.Size = new System.Drawing.Size(30, 30);
			this.cbPnevmo.TabIndex = 20;
			this.cbPnevmo.StatusChanged += new Vesna.Controls.CheckButtonControl.StatusChangedHander(this.CheckButton_Click);
			// 
			// cbDouble
			// 
			this.cbDouble.BackColor = System.Drawing.Color.Silver;
			this.cbDouble.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbDouble.IsOn = false;
			this.cbDouble.Location = new System.Drawing.Point(1, 2);
			this.cbDouble.Name = "cbDouble";
			this.cbDouble.OffImage = null;
			this.cbDouble.OnImage = null;
			this.cbDouble.Size = new System.Drawing.Size(30, 30);
			this.cbDouble.TabIndex = 19;
			this.cbDouble.StatusChanged += new Vesna.Controls.CheckButtonControl.StatusChangedHander(this.CheckButton_Click);
			// 
			// tb_nagruz
			// 
			this.tb_nagruz.AutoSize = true;
			this.tb_nagruz.BackColor = System.Drawing.Color.Transparent;
			this.tb_nagruz.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_nagruz.Location = new System.Drawing.Point(3, 229);
			this.tb_nagruz.Name = "tb_nagruz";
			this.tb_nagruz.Size = new System.Drawing.Size(16, 20);
			this.tb_nagruz.TabIndex = 22;
			this.tb_nagruz.Text = "0";
			this.tb_nagruz.Visible = false;
			// 
			// WheelControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Snow;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.tb_scales_value);
			this.Controls.Add(this.tb_nagruz);
			this.Controls.Add(this.cbUpper);
			this.Controls.Add(this.cbPnevmo);
			this.Controls.Add(this.cbDouble);
			this.Controls.Add(this.b_add);
			this.Controls.Add(this.pb_fix);
			this.Controls.Add(this.tb_ras);
			this.Controls.Add(this.l_procent);
			this.Controls.Add(this.l_pereves);
			this.Controls.Add(this.l_nagDop);
			this.Controls.Add(this.WheelPic);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Name = "WheelControl";
			this.Size = new System.Drawing.Size(104, 320);
			this.DoubleClick += new System.EventHandler(this.Wheel_DoubleClick);
			this.MouseEnter += new System.EventHandler(this.WheelControl_MouseEnter);
			this.MouseHover += new System.EventHandler(this.WheelControl_MouseHover);
			((System.ComponentModel.ISupportInitialize)(this.tb_ras)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_scales_value)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_fix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WheelPic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox WheelPic;
		private System.Windows.Forms.Label l_nagDop;
		private System.Windows.Forms.Label l_pereves;
		private System.Windows.Forms.Label l_procent;
		public System.Windows.Forms.NumericUpDown tb_ras;
		private System.Windows.Forms.PictureBox pb_fix;
		private System.Windows.Forms.Button b_add;
		private System.Windows.Forms.NumericUpDown tb_scales_value;
		private Controls.CheckButtonControl cbDouble;
		private Controls.CheckButtonControl cbPnevmo;
		private Controls.CheckButtonControl cbUpper;
		private System.Windows.Forms.Label tb_nagruz;
	}
}
