namespace Vesna
{
    partial class SettingForm
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
	        System.Windows.Forms.Label label55;
	        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
	        this.button1 = new System.Windows.Forms.Button();
	        this.label1 = new System.Windows.Forms.Label();
	        this.label2 = new System.Windows.Forms.Label();
	        this.checkBox1 = new System.Windows.Forms.CheckBox();
	        this.button2 = new System.Windows.Forms.Button();
	        this.label3 = new System.Windows.Forms.Label();
	        this.tb_id_car = new System.Windows.Forms.NumericUpDown();
	        this.tb_index_goda = new System.Windows.Forms.NumericUpDown();
	        this.label4 = new System.Windows.Forms.Label();
	        this.cb_com_name = new System.Windows.Forms.ComboBox();
	        this.l_run = new System.Windows.Forms.Label();
	        this.tb_run = new System.Windows.Forms.TextBox();
	        this.b_run = new System.Windows.Forms.Button();
	        this.tb_inaccuracy_scales = new System.Windows.Forms.NumericUpDown();
	        this.label5 = new System.Windows.Forms.Label();
	        this.tb_inaccuracy_roulette = new System.Windows.Forms.NumericUpDown();
	        this.label6 = new System.Windows.Forms.Label();
	        this.tb_dopustFullMass = new System.Windows.Forms.NumericUpDown();
	        this.label7 = new System.Windows.Forms.Label();
	        this.tb_dopustAxis = new System.Windows.Forms.NumericUpDown();
	        label55 = new System.Windows.Forms.Label();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_id_car)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_index_goda)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_inaccuracy_scales)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_inaccuracy_roulette)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_dopustFullMass)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_dopustAxis)).BeginInit();
	        this.SuspendLayout();
	        // 
	        // label55
	        // 
	        label55.AutoSize = true;
	        label55.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        label55.Location = new System.Drawing.Point(13, 242);
	        label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        label55.Name = "label55";
	        label55.Size = new System.Drawing.Size(177, 20);
	        label55.TabIndex = 19;
	        label55.Text = "Допустимый перевес оси (%)";
	        // 
	        // button1
	        // 
	        this.button1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.button1.Location = new System.Drawing.Point(267, 444);
	        this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.button1.Name = "button1";
	        this.button1.Size = new System.Drawing.Size(96, 32);
	        this.button1.TabIndex = 0;
	        this.button1.Text = "ОК";
	        this.button1.UseVisualStyleBackColor = true;
	        this.button1.Click += new System.EventHandler(this.button1_Click);
	        // 
	        // label1
	        // 
	        this.label1.AutoSize = true;
	        this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label1.Location = new System.Drawing.Point(14, 97);
	        this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label1.Name = "label1";
	        this.label1.Size = new System.Drawing.Size(241, 20);
	        this.label1.TabIndex = 1;
	        this.label1.Text = "Компенсационный индекс текущего года";
	        // 
	        // label2
	        // 
	        this.label2.AutoSize = true;
	        this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label2.Location = new System.Drawing.Point(14, 28);
	        this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label2.Name = "label2";
	        this.label2.Size = new System.Drawing.Size(258, 20);
	        this.label2.TabIndex = 3;
	        this.label2.Text = "Периуд климатических условий (распутица)";
	        // 
	        // checkBox1
	        // 
	        this.checkBox1.AutoSize = true;
	        this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.checkBox1.Location = new System.Drawing.Point(370, 32);
	        this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.checkBox1.Name = "checkBox1";
	        this.checkBox1.Size = new System.Drawing.Size(15, 14);
	        this.checkBox1.TabIndex = 4;
	        this.checkBox1.UseVisualStyleBackColor = true;
	        // 
	        // button2
	        // 
	        this.button2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.button2.Location = new System.Drawing.Point(370, 444);
	        this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.button2.Name = "button2";
	        this.button2.Size = new System.Drawing.Size(96, 32);
	        this.button2.TabIndex = 5;
	        this.button2.Text = "Отмена";
	        this.button2.UseVisualStyleBackColor = true;
	        this.button2.Click += new System.EventHandler(this.button2_Click);
	        // 
	        // label3
	        // 
	        this.label3.AutoSize = true;
	        this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label3.Location = new System.Drawing.Point(14, 61);
	        this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label3.Name = "label3";
	        this.label3.Size = new System.Drawing.Size(220, 20);
	        this.label3.TabIndex = 6;
	        this.label3.Text = "Уникальный идентификатор машины";
	        // 
	        // tb_id_car
	        // 
	        this.tb_id_car.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_id_car.Location = new System.Drawing.Point(370, 59);
	        this.tb_id_car.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_id_car.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
	        this.tb_id_car.Name = "tb_id_car";
	        this.tb_id_car.Size = new System.Drawing.Size(96, 25);
	        this.tb_id_car.TabIndex = 8;
	        // 
	        // tb_index_goda
	        // 
	        this.tb_index_goda.DecimalPlaces = 4;
	        this.tb_index_goda.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_index_goda.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
	        this.tb_index_goda.Location = new System.Drawing.Point(370, 95);
	        this.tb_index_goda.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_index_goda.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
	        this.tb_index_goda.Name = "tb_index_goda";
	        this.tb_index_goda.Size = new System.Drawing.Size(96, 25);
	        this.tb_index_goda.TabIndex = 9;
	        // 
	        // label4
	        // 
	        this.label4.AutoSize = true;
	        this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label4.Location = new System.Drawing.Point(14, 357);
	        this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label4.Name = "label4";
	        this.label4.Size = new System.Drawing.Size(136, 20);
	        this.label4.TabIndex = 10;
	        this.label4.Text = "Название COM-порта";
	        // 
	        // cb_com_name
	        // 
	        this.cb_com_name.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.cb_com_name.FormattingEnabled = true;
	        this.cb_com_name.Location = new System.Drawing.Point(370, 353);
	        this.cb_com_name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.cb_com_name.Name = "cb_com_name";
	        this.cb_com_name.Size = new System.Drawing.Size(95, 28);
	        this.cb_com_name.TabIndex = 11;
	        // 
	        // l_run
	        // 
	        this.l_run.AutoSize = true;
	        this.l_run.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.l_run.Location = new System.Drawing.Point(14, 396);
	        this.l_run.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.l_run.Name = "l_run";
	        this.l_run.Size = new System.Drawing.Size(59, 20);
	        this.l_run.TabIndex = 12;
	        this.l_run.Text = "Команда";
	        // 
	        // tb_run
	        // 
	        this.tb_run.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_run.Location = new System.Drawing.Point(90, 392);
	        this.tb_run.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_run.Multiline = true;
	        this.tb_run.Name = "tb_run";
	        this.tb_run.Size = new System.Drawing.Size(340, 46);
	        this.tb_run.TabIndex = 13;
	        // 
	        // b_run
	        // 
	        this.b_run.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.b_run.Location = new System.Drawing.Point(436, 392);
	        this.b_run.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.b_run.Name = "b_run";
	        this.b_run.Size = new System.Drawing.Size(28, 29);
	        this.b_run.TabIndex = 14;
	        this.b_run.UseVisualStyleBackColor = true;
	        this.b_run.Click += new System.EventHandler(this.b_run_Click);
	        // 
	        // tb_inaccuracy_scales
	        // 
	        this.tb_inaccuracy_scales.DecimalPlaces = 4;
	        this.tb_inaccuracy_scales.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_inaccuracy_scales.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
	        this.tb_inaccuracy_scales.Location = new System.Drawing.Point(369, 149);
	        this.tb_inaccuracy_scales.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_inaccuracy_scales.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
	        this.tb_inaccuracy_scales.Name = "tb_inaccuracy_scales";
	        this.tb_inaccuracy_scales.Size = new System.Drawing.Size(96, 25);
	        this.tb_inaccuracy_scales.TabIndex = 16;
	        // 
	        // label5
	        // 
	        this.label5.AutoSize = true;
	        this.label5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label5.Location = new System.Drawing.Point(13, 151);
	        this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label5.Name = "label5";
	        this.label5.Size = new System.Drawing.Size(141, 20);
	        this.label5.TabIndex = 15;
	        this.label5.Text = "Погрешность весов, (т)";
	        // 
	        // tb_inaccuracy_roulette
	        // 
	        this.tb_inaccuracy_roulette.DecimalPlaces = 4;
	        this.tb_inaccuracy_roulette.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_inaccuracy_roulette.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
	        this.tb_inaccuracy_roulette.Location = new System.Drawing.Point(369, 185);
	        this.tb_inaccuracy_roulette.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_inaccuracy_roulette.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
	        this.tb_inaccuracy_roulette.Name = "tb_inaccuracy_roulette";
	        this.tb_inaccuracy_roulette.Size = new System.Drawing.Size(96, 25);
	        this.tb_inaccuracy_roulette.TabIndex = 18;
	        // 
	        // label6
	        // 
	        this.label6.AutoSize = true;
	        this.label6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label6.Location = new System.Drawing.Point(13, 187);
	        this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label6.Name = "label6";
	        this.label6.Size = new System.Drawing.Size(149, 20);
	        this.label6.TabIndex = 17;
	        this.label6.Text = "Погрешность рулетки (м)";
	        // 
	        // tb_dopustFullMass
	        // 
	        this.tb_dopustFullMass.DecimalPlaces = 4;
	        this.tb_dopustFullMass.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_dopustFullMass.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
	        this.tb_dopustFullMass.Location = new System.Drawing.Point(369, 276);
	        this.tb_dopustFullMass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_dopustFullMass.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
	        this.tb_dopustFullMass.Name = "tb_dopustFullMass";
	        this.tb_dopustFullMass.Size = new System.Drawing.Size(96, 25);
	        this.tb_dopustFullMass.TabIndex = 22;
	        // 
	        // label7
	        // 
	        this.label7.AutoSize = true;
	        this.label7.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.label7.Location = new System.Drawing.Point(13, 278);
	        this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
	        this.label7.Name = "label7";
	        this.label7.Size = new System.Drawing.Size(194, 20);
	        this.label7.TabIndex = 21;
	        this.label7.Text = "Допустимый общий перевес (%)";
	        // 
	        // tb_dopustAxis
	        // 
	        this.tb_dopustAxis.DecimalPlaces = 4;
	        this.tb_dopustAxis.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.tb_dopustAxis.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
	        this.tb_dopustAxis.Location = new System.Drawing.Point(369, 240);
	        this.tb_dopustAxis.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.tb_dopustAxis.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
	        this.tb_dopustAxis.Name = "tb_dopustAxis";
	        this.tb_dopustAxis.Size = new System.Drawing.Size(96, 25);
	        this.tb_dopustAxis.TabIndex = 20;
	        // 
	        // SettingForm
	        // 
	        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.BackColor = System.Drawing.Color.Snow;
	        this.ClientSize = new System.Drawing.Size(488, 495);
	        this.Controls.Add(this.tb_dopustFullMass);
	        this.Controls.Add(this.label7);
	        this.Controls.Add(this.tb_dopustAxis);
	        this.Controls.Add(label55);
	        this.Controls.Add(this.tb_inaccuracy_roulette);
	        this.Controls.Add(this.label6);
	        this.Controls.Add(this.tb_inaccuracy_scales);
	        this.Controls.Add(this.label5);
	        this.Controls.Add(this.b_run);
	        this.Controls.Add(this.tb_run);
	        this.Controls.Add(this.l_run);
	        this.Controls.Add(this.cb_com_name);
	        this.Controls.Add(this.label4);
	        this.Controls.Add(this.tb_index_goda);
	        this.Controls.Add(this.tb_id_car);
	        this.Controls.Add(this.label3);
	        this.Controls.Add(this.button2);
	        this.Controls.Add(this.checkBox1);
	        this.Controls.Add(this.label2);
	        this.Controls.Add(this.label1);
	        this.Controls.Add(this.button1);
	        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
	        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	        this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
	        this.MaximizeBox = false;
	        this.Name = "SettingForm";
	        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	        this.Text = "Параметры";
	        this.Load += new System.EventHandler(this.FormSetting_Load);
	        ((System.ComponentModel.ISupportInitialize)(this.tb_id_car)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_index_goda)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_inaccuracy_scales)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_inaccuracy_roulette)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_dopustFullMass)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.tb_dopustAxis)).EndInit();
	        this.ResumeLayout(false);
	        this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tb_id_car;
        private System.Windows.Forms.NumericUpDown tb_index_goda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_com_name;
				private System.Windows.Forms.Label l_run;
				private System.Windows.Forms.TextBox tb_run;
				private System.Windows.Forms.Button b_run;
		private System.Windows.Forms.NumericUpDown tb_inaccuracy_scales;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown tb_inaccuracy_roulette;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown tb_dopustFullMass;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown tb_dopustAxis;
	}
}