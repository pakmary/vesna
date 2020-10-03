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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.lebel10 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.l_loadLimit = new System.Windows.Forms.Label();
			this.l_over = new System.Windows.Forms.Label();
			this.l_overPercent = new System.Windows.Forms.Label();
			this.tb_distanceToNext = new System.Windows.Forms.NumericUpDown();
			this.b_add = new System.Windows.Forms.Button();
			this.tb_scales_value = new System.Windows.Forms.NumericUpDown();
			this.pb_fix = new System.Windows.Forms.PictureBox();
			this.WheelPic = new System.Windows.Forms.PictureBox();
			this.tb_weightValueWithInaccuracy = new System.Windows.Forms.Label();
			this.tb_distanceToNextWithInaccuracy = new System.Windows.Forms.Label();
			this.cbPnevmo = new Vesna.Controls.CheckButtonControl();
			this.cbDouble = new Vesna.Controls.CheckButtonControl();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.tb_distanceToNext)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_scales_value)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_fix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WheelPic)).BeginInit();
			this.SuspendLayout();
			// 
			// lebel10
			// 
			this.lebel10.AutoSize = true;
			this.lebel10.BackColor = System.Drawing.Color.Transparent;
			this.lebel10.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lebel10.ForeColor = System.Drawing.Color.Red;
			this.lebel10.Location = new System.Drawing.Point(-5, 295);
			this.lebel10.Name = "lebel10";
			this.lebel10.Size = new System.Drawing.Size(114, 20);
			this.lebel10.TabIndex = 0;
			this.lebel10.Text = "                                   ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.MediumBlue;
			this.label3.Location = new System.Drawing.Point(-6, 269);
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
			this.label4.Location = new System.Drawing.Point(-7, 322);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "                                   ";
			// 
			// l_loadLimit
			// 
			this.l_loadLimit.AutoSize = true;
			this.l_loadLimit.BackColor = System.Drawing.Color.Transparent;
			this.l_loadLimit.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_loadLimit.ForeColor = System.Drawing.Color.Red;
			this.l_loadLimit.Location = new System.Drawing.Point(3, 291);
			this.l_loadLimit.Name = "l_loadLimit";
			this.l_loadLimit.Size = new System.Drawing.Size(16, 20);
			this.l_loadLimit.TabIndex = 8;
			this.l_loadLimit.Text = "0";
			// 
			// l_over
			// 
			this.l_over.AutoSize = true;
			this.l_over.BackColor = System.Drawing.Color.Transparent;
			this.l_over.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_over.Location = new System.Drawing.Point(3, 317);
			this.l_over.Name = "l_over";
			this.l_over.Size = new System.Drawing.Size(16, 20);
			this.l_over.TabIndex = 11;
			this.l_over.Text = "0";
			this.l_over.Visible = false;
			// 
			// l_overPercent
			// 
			this.l_overPercent.AutoSize = true;
			this.l_overPercent.BackColor = System.Drawing.Color.Transparent;
			this.l_overPercent.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_overPercent.Location = new System.Drawing.Point(3, 344);
			this.l_overPercent.Name = "l_overPercent";
			this.l_overPercent.Size = new System.Drawing.Size(16, 20);
			this.l_overPercent.TabIndex = 12;
			this.l_overPercent.Text = "0";
			this.l_overPercent.Visible = false;
			// 
			// tb_distanceToNext
			// 
			this.tb_distanceToNext.DecimalPlaces = 2;
			this.tb_distanceToNext.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_distanceToNext.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			this.tb_distanceToNext.Location = new System.Drawing.Point(49, 84);
			this.tb_distanceToNext.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			this.tb_distanceToNext.Name = "tb_distanceToNext";
			this.tb_distanceToNext.Size = new System.Drawing.Size(73, 25);
			this.tb_distanceToNext.TabIndex = 13;
			this.tb_distanceToNext.Visible = false;
			this.tb_distanceToNext.Enter += new System.EventHandler(this.tb_Enter);
			this.tb_distanceToNext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
			this.tb_distanceToNext.Leave += new System.EventHandler(this.tb_ras_Leave);
			this.tb_distanceToNext.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_MouseClick);
			// 
			// b_add
			// 
			this.b_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.b_add.Location = new System.Drawing.Point(6, 181);
			this.b_add.Name = "b_add";
			this.b_add.Size = new System.Drawing.Size(110, 50);
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
			this.tb_scales_value.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			this.tb_scales_value.Location = new System.Drawing.Point(6, 233);
			this.tb_scales_value.Name = "tb_scales_value";
			this.tb_scales_value.Size = new System.Drawing.Size(79, 25);
			this.tb_scales_value.TabIndex = 18;
			this.tb_scales_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
			this.tb_scales_value.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_MouseClick);
			// 
			// pb_fix
			// 
			this.pb_fix.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_fix.Location = new System.Drawing.Point(85, 212);
			this.pb_fix.Name = "pb_fix";
			this.pb_fix.Size = new System.Drawing.Size(37, 50);
			this.pb_fix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_fix.TabIndex = 15;
			this.pb_fix.TabStop = false;
			this.pb_fix.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// WheelPic
			// 
			this.WheelPic.Image = global::Vesna.Properties.Resources.one;
			this.WheelPic.Location = new System.Drawing.Point(-1, 39);
			this.WheelPic.Name = "WheelPic";
			this.WheelPic.Size = new System.Drawing.Size(85, 141);
			this.WheelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.WheelPic.TabIndex = 0;
			this.WheelPic.TabStop = false;
			// 
			// tb_weightValueWithInaccuracy
			// 
			this.tb_weightValueWithInaccuracy.AutoSize = true;
			this.tb_weightValueWithInaccuracy.BackColor = System.Drawing.Color.Transparent;
			this.tb_weightValueWithInaccuracy.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_weightValueWithInaccuracy.ForeColor = System.Drawing.Color.MediumBlue;
			this.tb_weightValueWithInaccuracy.Location = new System.Drawing.Point(3, 264);
			this.tb_weightValueWithInaccuracy.Name = "tb_weightValueWithInaccuracy";
			this.tb_weightValueWithInaccuracy.Size = new System.Drawing.Size(16, 20);
			this.tb_weightValueWithInaccuracy.TabIndex = 22;
			this.tb_weightValueWithInaccuracy.Text = "0";
			this.tb_weightValueWithInaccuracy.Visible = false;
			// 
			// tb_distanceToNextWithInaccuracy
			// 
			this.tb_distanceToNextWithInaccuracy.AutoSize = true;
			this.tb_distanceToNextWithInaccuracy.BackColor = System.Drawing.Color.Transparent;
			this.tb_distanceToNextWithInaccuracy.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_distanceToNextWithInaccuracy.ForeColor = System.Drawing.Color.MediumBlue;
			this.tb_distanceToNextWithInaccuracy.Location = new System.Drawing.Point(48, 117);
			this.tb_distanceToNextWithInaccuracy.Name = "tb_distanceToNextWithInaccuracy";
			this.tb_distanceToNextWithInaccuracy.Size = new System.Drawing.Size(16, 20);
			this.tb_distanceToNextWithInaccuracy.TabIndex = 23;
			this.tb_distanceToNextWithInaccuracy.Text = "0";
			this.tb_distanceToNextWithInaccuracy.Visible = false;
			// 
			// cbPnevmo
			// 
			this.cbPnevmo.BackColor = System.Drawing.Color.Silver;
			this.cbPnevmo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbPnevmo.IsOn = false;
			this.cbPnevmo.Location = new System.Drawing.Point(50, 2);
			this.cbPnevmo.Name = "cbPnevmo";
			this.cbPnevmo.OffImage = null;
			this.cbPnevmo.OnImage = null;
			this.cbPnevmo.Size = new System.Drawing.Size(35, 35);
			this.cbPnevmo.TabIndex = 20;
			this.cbPnevmo.StatusChanged += new Vesna.Controls.CheckButtonControl.StatusChangedHandler(this.CheckButton_Click);
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
			this.cbDouble.Size = new System.Drawing.Size(35, 35);
			this.cbDouble.TabIndex = 19;
			this.cbDouble.StatusChanged += new Vesna.Controls.CheckButtonControl.StatusChangedHandler(this.CheckButton_Click);
			// 
			// WheelControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Snow;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.tb_distanceToNextWithInaccuracy);
			this.Controls.Add(this.tb_scales_value);
			this.Controls.Add(this.tb_weightValueWithInaccuracy);
			this.Controls.Add(this.cbPnevmo);
			this.Controls.Add(this.cbDouble);
			this.Controls.Add(this.b_add);
			this.Controls.Add(this.pb_fix);
			this.Controls.Add(this.tb_distanceToNext);
			this.Controls.Add(this.l_overPercent);
			this.Controls.Add(this.l_over);
			this.Controls.Add(this.l_loadLimit);
			this.Controls.Add(this.WheelPic);
			this.Controls.Add(this.lebel10);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Name = "WheelControl";
			this.Size = new System.Drawing.Size(121, 369);
			this.DoubleClick += new System.EventHandler(this.Wheel_DoubleClick);
			this.MouseEnter += new System.EventHandler(this.WheelControl_MouseEnter);
			((System.ComponentModel.ISupportInitialize)(this.tb_distanceToNext)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_scales_value)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_fix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WheelPic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lebel10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox WheelPic;
		private System.Windows.Forms.Label l_loadLimit;
		private System.Windows.Forms.Label l_over;
		private System.Windows.Forms.Label l_overPercent;
		private System.Windows.Forms.PictureBox pb_fix;
		private System.Windows.Forms.Button b_add;
		private System.Windows.Forms.NumericUpDown tb_scales_value;
		private System.Windows.Forms.Label tb_weightValueWithInaccuracy;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label tb_distanceToNextWithInaccuracy;
		private Vesna.Controls.CheckButtonControl cbPnevmo;
		private Vesna.Controls.CheckButtonControl cbDouble;
		private System.Windows.Forms.NumericUpDown tb_distanceToNext;
	}
}
