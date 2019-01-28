namespace Vesna.Forms {
	partial class InitForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitForm));
			this.label_14 = new System.Windows.Forms.Label();
			this.cb_vesi_zavod_nomer = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cb_mesto_prov = new System.Windows.Forms.ComboBox();
			this.cb_imya_ppvk = new System.Windows.Forms.ComboBox();
			this.l_VesiAbout = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.cb_Vid_Dor = new System.Windows.Forms.ComboBox();
			this.cb_Level = new System.Windows.Forms.ComboBox();
			this.cb_Clothes = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label_14
			// 
			this.label_14.AutoSize = true;
			this.label_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.label_14.Location = new System.Drawing.Point(12, 341);
			this.label_14.Name = "label_14";
			this.label_14.Size = new System.Drawing.Size(49, 18);
			this.label_14.TabIndex = 53;
			this.label_14.Text = "Весы:";
			// 
			// cb_vesi_zavod_nomer
			// 
			this.cb_vesi_zavod_nomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_vesi_zavod_nomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.cb_vesi_zavod_nomer.FormattingEnabled = true;
			this.cb_vesi_zavod_nomer.Location = new System.Drawing.Point(164, 338);
			this.cb_vesi_zavod_nomer.Name = "cb_vesi_zavod_nomer";
			this.cb_vesi_zavod_nomer.Size = new System.Drawing.Size(578, 26);
			this.cb_vesi_zavod_nomer.TabIndex = 52;
			this.cb_vesi_zavod_nomer.SelectedIndexChanged += new System.EventHandler(this.cb_vesi_zavod_nomer_SelectedValueChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.label12.Location = new System.Drawing.Point(12, 171);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(127, 18);
			this.label12.TabIndex = 51;
			this.label12.Text = "Место контроля:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.label13.Location = new System.Drawing.Point(12, 137);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(54, 18);
			this.label13.TabIndex = 50;
			this.label13.Text = "ППВК:";
			// 
			// cb_mesto_prov
			// 
			this.cb_mesto_prov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.cb_mesto_prov.FormattingEnabled = true;
			this.cb_mesto_prov.Location = new System.Drawing.Point(164, 168);
			this.cb_mesto_prov.Name = "cb_mesto_prov";
			this.cb_mesto_prov.Size = new System.Drawing.Size(578, 26);
			this.cb_mesto_prov.TabIndex = 49;
			// 
			// cb_imya_ppvk
			// 
			this.cb_imya_ppvk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.cb_imya_ppvk.FormattingEnabled = true;
			this.cb_imya_ppvk.Location = new System.Drawing.Point(164, 134);
			this.cb_imya_ppvk.Name = "cb_imya_ppvk";
			this.cb_imya_ppvk.Size = new System.Drawing.Size(578, 26);
			this.cb_imya_ppvk.TabIndex = 48;
			// 
			// l_VesiAbout
			// 
			this.l_VesiAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.l_VesiAbout.Location = new System.Drawing.Point(160, 382);
			this.l_VesiAbout.Name = "l_VesiAbout";
			this.l_VesiAbout.Size = new System.Drawing.Size(421, 25);
			this.l_VesiAbout.TabIndex = 54;
			this.l_VesiAbout.Text = "Дата поверки  от _____ до _____";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
			this.button2.Location = new System.Drawing.Point(581, 439);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(161, 44);
			this.button2.TabIndex = 56;
			this.button2.Text = "Войти";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.label10.Location = new System.Drawing.Point(12, 222);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(92, 18);
			this.label10.TabIndex = 58;
			this.label10.Text = "Вид дороги:";
			// 
			// cb_Vid_Dor
			// 
			this.cb_Vid_Dor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Vid_Dor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.cb_Vid_Dor.FormattingEnabled = true;
			this.cb_Vid_Dor.Location = new System.Drawing.Point(164, 219);
			this.cb_Vid_Dor.Name = "cb_Vid_Dor";
			this.cb_Vid_Dor.Size = new System.Drawing.Size(578, 26);
			this.cb_Vid_Dor.TabIndex = 57;
			// 
			// cb_Level
			// 
			this.cb_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.cb_Level.FormattingEnabled = true;
			this.cb_Level.Items.AddRange(new object[] {
            "Федерального значения",
            "Регионального, межмуниципального, местного значения, частные дороги "});
			this.cb_Level.Location = new System.Drawing.Point(164, 253);
			this.cb_Level.Name = "cb_Level";
			this.cb_Level.Size = new System.Drawing.Size(578, 26);
			this.cb_Level.TabIndex = 61;
			// 
			// cb_Clothes
			// 
			this.cb_Clothes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Clothes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.cb_Clothes.FormattingEnabled = true;
			this.cb_Clothes.Items.AddRange(new object[] {
            "С твёрдым покрытием",
            "С одеждой переходного типа"});
			this.cb_Clothes.Location = new System.Drawing.Point(164, 287);
			this.cb_Clothes.Name = "cb_Clothes";
			this.cb_Clothes.Size = new System.Drawing.Size(578, 26);
			this.cb_Clothes.TabIndex = 62;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(13, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(730, 28);
			this.label1.TabIndex = 63;
			this.label1.Text = "\"Весна\"";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(13, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(729, 20);
			this.label2.TabIndex = 64;
			this.label2.Text = "                                                                                 " +
    "                                                               ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(13, 416);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(729, 20);
			this.label3.TabIndex = 65;
			this.label3.Text = "                                                                                 " +
    "                                                               ";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(13, 37);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(730, 56);
			this.label4.TabIndex = 66;
			this.label4.Text = "Программа расчета осевых нагрузок \r\nи платы за провоз тяжеловесных грузов \r\nпри п" +
    "роезде по автомобильным дорогам общего пользования.";
			// 
			// InitForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(762, 496);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_Clothes);
			this.Controls.Add(this.cb_Level);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cb_Vid_Dor);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.l_VesiAbout);
			this.Controls.Add(this.label_14);
			this.Controls.Add(this.cb_vesi_zavod_nomer);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.cb_mesto_prov);
			this.Controls.Add(this.cb_imya_ppvk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InitForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "\"Весна\"";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_14;
		private System.Windows.Forms.ComboBox cb_vesi_zavod_nomer;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cb_mesto_prov;
		private System.Windows.Forms.ComboBox cb_imya_ppvk;
		private System.Windows.Forms.Label l_VesiAbout;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cb_Vid_Dor;
		private System.Windows.Forms.ComboBox cb_Level;
		private System.Windows.Forms.ComboBox cb_Clothes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}