namespace Vesna.Forms
{
    partial class ActForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActForm));
			this.button1 = new System.Windows.Forms.Button();
			this.l_data = new System.Windows.Forms.Label();
			this.tb_model_3 = new System.Windows.Forms.TextBox();
			this.tb_model_2 = new System.Windows.Forms.TextBox();
			this.tb_model_1 = new System.Windows.Forms.TextBox();
			this.tb_reg_3 = new System.Windows.Forms.TextBox();
			this.tb_reg_2 = new System.Windows.Forms.TextBox();
			this.tb_reg_1 = new System.Windows.Forms.TextBox();
			this.tb_sobstv = new System.Windows.Forms.TextBox();
			this.tb_sobstv_pricep_addess = new System.Windows.Forms.TextBox();
			this.tb_obyasn_vodit = new System.Windows.Forms.TextBox();
			this.cb_operat = new System.Windows.Forms.ComboBox();
			this.cb_inspekt = new System.Windows.Forms.ComboBox();
			this.cb_harakter_gruza = new System.Windows.Forms.ComboBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.l_sub = new System.Windows.Forms.Label();
			this.cb_kod_sub = new System.Windows.Forms.ComboBox();
			this.l_nomer_act = new System.Windows.Forms.Label();
			this.b_print = new System.Windows.Forms.Button();
			this.cb_vid_gruza = new System.Windows.Forms.ComboBox();
			this.cb_vid_2 = new System.Windows.Forms.ComboBox();
			this.cb_vid_3 = new System.Windows.Forms.ComboBox();
			this.l_vid_1 = new System.Windows.Forms.Label();
			this.cb_strana = new System.Windows.Forms.ComboBox();
			this.tb_primecanie = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_marsh_dvig = new System.Windows.Forms.TextBox();
			this.cb_driver = new System.Windows.Forms.ComboBox();
			this.l_razm_usherba = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.l_km = new System.Windows.Forms.Label();
			this.b_exit = new System.Windows.Forms.Button();
			this.tb_error_msg = new System.Windows.Forms.TextBox();
			this.cb_mark_1 = new System.Windows.Forms.ComboBox();
			this.pb_foto = new System.Windows.Forms.PictureBox();
			this.cb_mark_2 = new System.Windows.Forms.ComboBox();
			this.cb_mark_3 = new System.Windows.Forms.ComboBox();
			this.tb_adres_sobs = new System.Windows.Forms.TextBox();
			this.tb_kol_poezdok = new System.Windows.Forms.NumericUpDown();
			this.tb_sobstv_pricep = new System.Windows.Forms.TextBox();
			this.tb_sobs_svid = new System.Windows.Forms.TextBox();
			this.tb_sobstv_pricep_svid = new System.Windows.Forms.TextBox();
			this.tb_driver_license = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pb_foto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_kol_poezdok)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(935, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 40);
			this.button1.TabIndex = 23;
			this.button1.Text = "Экспорт в Word";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// l_data
			// 
			this.l_data.AutoSize = true;
			this.l_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_data.Location = new System.Drawing.Point(76, 20);
			this.l_data.Name = "l_data";
			this.l_data.Size = new System.Drawing.Size(61, 13);
			this.l_data.TabIndex = 28;
			this.l_data.Text = "01.01.1111";
			// 
			// tb_model_3
			// 
			this.tb_model_3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_model_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_model_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_model_3.Location = new System.Drawing.Point(377, 103);
			this.tb_model_3.Name = "tb_model_3";
			this.tb_model_3.Size = new System.Drawing.Size(150, 18);
			this.tb_model_3.TabIndex = 48;
			// 
			// tb_model_2
			// 
			this.tb_model_2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_model_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_model_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_model_2.Location = new System.Drawing.Point(377, 84);
			this.tb_model_2.Name = "tb_model_2";
			this.tb_model_2.Size = new System.Drawing.Size(150, 18);
			this.tb_model_2.TabIndex = 47;
			// 
			// tb_model_1
			// 
			this.tb_model_1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_model_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_model_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_model_1.Location = new System.Drawing.Point(377, 65);
			this.tb_model_1.Name = "tb_model_1";
			this.tb_model_1.Size = new System.Drawing.Size(150, 18);
			this.tb_model_1.TabIndex = 46;
			// 
			// tb_reg_3
			// 
			this.tb_reg_3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_reg_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_reg_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_reg_3.Location = new System.Drawing.Point(533, 103);
			this.tb_reg_3.Name = "tb_reg_3";
			this.tb_reg_3.Size = new System.Drawing.Size(147, 18);
			this.tb_reg_3.TabIndex = 51;
			// 
			// tb_reg_2
			// 
			this.tb_reg_2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_reg_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_reg_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_reg_2.Location = new System.Drawing.Point(533, 84);
			this.tb_reg_2.Name = "tb_reg_2";
			this.tb_reg_2.Size = new System.Drawing.Size(147, 18);
			this.tb_reg_2.TabIndex = 50;
			// 
			// tb_reg_1
			// 
			this.tb_reg_1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_reg_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_reg_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_reg_1.Location = new System.Drawing.Point(533, 65);
			this.tb_reg_1.Name = "tb_reg_1";
			this.tb_reg_1.Size = new System.Drawing.Size(147, 18);
			this.tb_reg_1.TabIndex = 49;
			// 
			// tb_sobstv
			// 
			this.tb_sobstv.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_sobstv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_sobstv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_sobstv.Location = new System.Drawing.Point(175, 134);
			this.tb_sobstv.Name = "tb_sobstv";
			this.tb_sobstv.Size = new System.Drawing.Size(505, 18);
			this.tb_sobstv.TabIndex = 55;
			// 
			// tb_sobstv_pricep_addess
			// 
			this.tb_sobstv_pricep_addess.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_sobstv_pricep_addess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_sobstv_pricep_addess.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_sobstv_pricep_addess.Location = new System.Drawing.Point(175, 212);
			this.tb_sobstv_pricep_addess.Name = "tb_sobstv_pricep_addess";
			this.tb_sobstv_pricep_addess.Size = new System.Drawing.Size(505, 18);
			this.tb_sobstv_pricep_addess.TabIndex = 57;
			// 
			// tb_obyasn_vodit
			// 
			this.tb_obyasn_vodit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_obyasn_vodit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_obyasn_vodit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_obyasn_vodit.Location = new System.Drawing.Point(120, 346);
			this.tb_obyasn_vodit.Multiline = true;
			this.tb_obyasn_vodit.Name = "tb_obyasn_vodit";
			this.tb_obyasn_vodit.Size = new System.Drawing.Size(560, 17);
			this.tb_obyasn_vodit.TabIndex = 76;
			// 
			// cb_operat
			// 
			this.cb_operat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_operat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_operat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_operat.FormattingEnabled = true;
			this.cb_operat.Location = new System.Drawing.Point(120, 416);
			this.cb_operat.Name = "cb_operat";
			this.cb_operat.Size = new System.Drawing.Size(256, 21);
			this.cb_operat.TabIndex = 80;
			// 
			// cb_inspekt
			// 
			this.cb_inspekt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_inspekt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_inspekt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_inspekt.FormattingEnabled = true;
			this.cb_inspekt.Location = new System.Drawing.Point(120, 435);
			this.cb_inspekt.Name = "cb_inspekt";
			this.cb_inspekt.Size = new System.Drawing.Size(256, 21);
			this.cb_inspekt.TabIndex = 81;
			// 
			// cb_harakter_gruza
			// 
			this.cb_harakter_gruza.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_harakter_gruza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_harakter_gruza.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_harakter_gruza.FormattingEnabled = true;
			this.cb_harakter_gruza.Items.AddRange(new object[] {
            "Делимый",
            "Неделимый"});
			this.cb_harakter_gruza.Location = new System.Drawing.Point(120, 319);
			this.cb_harakter_gruza.Name = "cb_harakter_gruza";
			this.cb_harakter_gruza.Size = new System.Drawing.Size(216, 21);
			this.cb_harakter_gruza.TabIndex = 104;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Фотограии автомобилей(*.BMP)|*.BMP";
			// 
			// l_sub
			// 
			this.l_sub.AutoSize = true;
			this.l_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_sub.Location = new System.Drawing.Point(319, 259);
			this.l_sub.Name = "l_sub";
			this.l_sub.Size = new System.Drawing.Size(17, 13);
			this.l_sub.TabIndex = 110;
			this.l_sub.Text = "\"\"";
			// 
			// cb_kod_sub
			// 
			this.cb_kod_sub.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_kod_sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_kod_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_kod_sub.FormattingEnabled = true;
			this.cb_kod_sub.Location = new System.Drawing.Point(511, 255);
			this.cb_kod_sub.Name = "cb_kod_sub";
			this.cb_kod_sub.Size = new System.Drawing.Size(67, 21);
			this.cb_kod_sub.TabIndex = 112;
			this.cb_kod_sub.SelectedIndexChanged += new System.EventHandler(this.cb_kod_sub_SelectedIndexChanged);
			// 
			// l_nomer_act
			// 
			this.l_nomer_act.AutoSize = true;
			this.l_nomer_act.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_nomer_act.Location = new System.Drawing.Point(42, 4);
			this.l_nomer_act.Name = "l_nomer_act";
			this.l_nomer_act.Size = new System.Drawing.Size(13, 13);
			this.l_nomer_act.TabIndex = 113;
			this.l_nomer_act.Text = "0";
			// 
			// b_print
			// 
			this.b_print.Location = new System.Drawing.Point(935, 43);
			this.b_print.Name = "b_print";
			this.b_print.Size = new System.Drawing.Size(112, 40);
			this.b_print.TabIndex = 114;
			this.b_print.Text = "Печатать";
			this.b_print.UseVisualStyleBackColor = true;
			this.b_print.Click += new System.EventHandler(this.b_print_Click);
			// 
			// cb_vid_gruza
			// 
			this.cb_vid_gruza.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_vid_gruza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_vid_gruza.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_vid_gruza.FormattingEnabled = true;
			this.cb_vid_gruza.Location = new System.Drawing.Point(482, 318);
			this.cb_vid_gruza.Name = "cb_vid_gruza";
			this.cb_vid_gruza.Size = new System.Drawing.Size(198, 21);
			this.cb_vid_gruza.TabIndex = 117;
			// 
			// cb_vid_2
			// 
			this.cb_vid_2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_vid_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_vid_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_vid_2.FormattingEnabled = true;
			this.cb_vid_2.Items.AddRange(new object[] {
            "Полуприцеп",
            "Прицеп"});
			this.cb_vid_2.Location = new System.Drawing.Point(13, 83);
			this.cb_vid_2.Name = "cb_vid_2";
			this.cb_vid_2.Size = new System.Drawing.Size(158, 21);
			this.cb_vid_2.TabIndex = 120;
			// 
			// cb_vid_3
			// 
			this.cb_vid_3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_vid_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_vid_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_vid_3.FormattingEnabled = true;
			this.cb_vid_3.Items.AddRange(new object[] {
            "Полуприцеп",
            "Прицеп"});
			this.cb_vid_3.Location = new System.Drawing.Point(13, 102);
			this.cb_vid_3.Name = "cb_vid_3";
			this.cb_vid_3.Size = new System.Drawing.Size(158, 21);
			this.cb_vid_3.TabIndex = 121;
			// 
			// l_vid_1
			// 
			this.l_vid_1.AutoSize = true;
			this.l_vid_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_vid_1.Location = new System.Drawing.Point(16, 66);
			this.l_vid_1.Name = "l_vid_1";
			this.l_vid_1.Size = new System.Drawing.Size(17, 13);
			this.l_vid_1.TabIndex = 122;
			this.l_vid_1.Text = "\"\"";
			// 
			// cb_strana
			// 
			this.cb_strana.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_strana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_strana.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_strana.FormattingEnabled = true;
			this.cb_strana.Items.AddRange(new object[] {
            "Российская федерация",
            "Украина",
            "Белоруссия"});
			this.cb_strana.Location = new System.Drawing.Point(56, 257);
			this.cb_strana.Name = "cb_strana";
			this.cb_strana.Size = new System.Drawing.Size(193, 21);
			this.cb_strana.TabIndex = 124;
			this.cb_strana.SelectedValueChanged += new System.EventHandler(this.cb_strana_SelectedValueChanged);
			// 
			// tb_primecanie
			// 
			this.tb_primecanie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_primecanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_primecanie.Location = new System.Drawing.Point(699, 194);
			this.tb_primecanie.Multiline = true;
			this.tb_primecanie.Name = "tb_primecanie";
			this.tb_primecanie.Size = new System.Drawing.Size(348, 62);
			this.tb_primecanie.TabIndex = 125;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(696, 178);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 126;
			this.label1.Text = "Примечание";
			// 
			// tb_marsh_dvig
			// 
			this.tb_marsh_dvig.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_marsh_dvig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_marsh_dvig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_marsh_dvig.Location = new System.Drawing.Point(120, 286);
			this.tb_marsh_dvig.Name = "tb_marsh_dvig";
			this.tb_marsh_dvig.Size = new System.Drawing.Size(362, 18);
			this.tb_marsh_dvig.TabIndex = 128;
			// 
			// cb_driver
			// 
			this.cb_driver.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_driver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_driver.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_driver.FormattingEnabled = true;
			this.cb_driver.Location = new System.Drawing.Point(120, 454);
			this.cb_driver.Name = "cb_driver";
			this.cb_driver.Size = new System.Drawing.Size(256, 21);
			this.cb_driver.TabIndex = 129;
			// 
			// l_razm_usherba
			// 
			this.l_razm_usherba.AutoSize = true;
			this.l_razm_usherba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_razm_usherba.Location = new System.Drawing.Point(123, 396);
			this.l_razm_usherba.Name = "l_razm_usherba";
			this.l_razm_usherba.Size = new System.Drawing.Size(14, 13);
			this.l_razm_usherba.TabIndex = 131;
			this.l_razm_usherba.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(9, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(622, 465);
			this.label2.TabIndex = 133;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// l_km
			// 
			this.l_km.AutoSize = true;
			this.l_km.Location = new System.Drawing.Point(117, 305);
			this.l_km.Name = "l_km";
			this.l_km.Size = new System.Drawing.Size(13, 13);
			this.l_km.TabIndex = 134;
			this.l_km.Text = "0";
			// 
			// b_exit
			// 
			this.b_exit.Location = new System.Drawing.Point(935, 82);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(112, 40);
			this.b_exit.TabIndex = 136;
			this.b_exit.Text = "Закрыть";
			this.b_exit.UseVisualStyleBackColor = true;
			this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
			// 
			// tb_error_msg
			// 
			this.tb_error_msg.Enabled = false;
			this.tb_error_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_error_msg.ForeColor = System.Drawing.Color.Red;
			this.tb_error_msg.Location = new System.Drawing.Point(699, 262);
			this.tb_error_msg.Multiline = true;
			this.tb_error_msg.Name = "tb_error_msg";
			this.tb_error_msg.Size = new System.Drawing.Size(348, 232);
			this.tb_error_msg.TabIndex = 137;
			// 
			// cb_mark_1
			// 
			this.cb_mark_1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_mark_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_mark_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_mark_1.FormattingEnabled = true;
			this.cb_mark_1.Location = new System.Drawing.Point(175, 64);
			this.cb_mark_1.Name = "cb_mark_1";
			this.cb_mark_1.Size = new System.Drawing.Size(196, 21);
			this.cb_mark_1.TabIndex = 138;
			// 
			// pb_foto
			// 
			this.pb_foto.Location = new System.Drawing.Point(699, 4);
			this.pb_foto.Name = "pb_foto";
			this.pb_foto.Size = new System.Drawing.Size(230, 171);
			this.pb_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_foto.TabIndex = 127;
			this.pb_foto.TabStop = false;
			// 
			// cb_mark_2
			// 
			this.cb_mark_2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_mark_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_mark_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_mark_2.FormattingEnabled = true;
			this.cb_mark_2.Location = new System.Drawing.Point(175, 83);
			this.cb_mark_2.Name = "cb_mark_2";
			this.cb_mark_2.Size = new System.Drawing.Size(196, 21);
			this.cb_mark_2.TabIndex = 139;
			// 
			// cb_mark_3
			// 
			this.cb_mark_3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.cb_mark_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cb_mark_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_mark_3.FormattingEnabled = true;
			this.cb_mark_3.Location = new System.Drawing.Point(175, 102);
			this.cb_mark_3.Name = "cb_mark_3";
			this.cb_mark_3.Size = new System.Drawing.Size(196, 21);
			this.cb_mark_3.TabIndex = 140;
			// 
			// tb_adres_sobs
			// 
			this.tb_adres_sobs.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_adres_sobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_adres_sobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_adres_sobs.Location = new System.Drawing.Point(175, 151);
			this.tb_adres_sobs.Name = "tb_adres_sobs";
			this.tb_adres_sobs.Size = new System.Drawing.Size(505, 18);
			this.tb_adres_sobs.TabIndex = 142;
			// 
			// tb_kol_poezdok
			// 
			this.tb_kol_poezdok.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_kol_poezdok.Location = new System.Drawing.Point(584, 287);
			this.tb_kol_poezdok.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.tb_kol_poezdok.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tb_kol_poezdok.Name = "tb_kol_poezdok";
			this.tb_kol_poezdok.Size = new System.Drawing.Size(67, 18);
			this.tb_kol_poezdok.TabIndex = 141;
			this.tb_kol_poezdok.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// tb_sobstv_pricep
			// 
			this.tb_sobstv_pricep.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_sobstv_pricep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_sobstv_pricep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_sobstv_pricep.Location = new System.Drawing.Point(175, 195);
			this.tb_sobstv_pricep.Name = "tb_sobstv_pricep";
			this.tb_sobstv_pricep.Size = new System.Drawing.Size(505, 18);
			this.tb_sobstv_pricep.TabIndex = 143;
			// 
			// tb_sobs_svid
			// 
			this.tb_sobs_svid.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_sobs_svid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_sobs_svid.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_sobs_svid.Location = new System.Drawing.Point(175, 168);
			this.tb_sobs_svid.Name = "tb_sobs_svid";
			this.tb_sobs_svid.Size = new System.Drawing.Size(505, 18);
			this.tb_sobs_svid.TabIndex = 144;
			// 
			// tb_sobstv_pricep_svid
			// 
			this.tb_sobstv_pricep_svid.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_sobstv_pricep_svid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_sobstv_pricep_svid.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_sobstv_pricep_svid.Location = new System.Drawing.Point(175, 229);
			this.tb_sobstv_pricep_svid.Name = "tb_sobstv_pricep_svid";
			this.tb_sobstv_pricep_svid.Size = new System.Drawing.Size(505, 18);
			this.tb_sobstv_pricep_svid.TabIndex = 145;
			// 
			// tb_driver_license
			// 
			this.tb_driver_license.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.tb_driver_license.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_driver_license.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_driver_license.Location = new System.Drawing.Point(533, 454);
			this.tb_driver_license.Name = "tb_driver_license";
			this.tb_driver_license.Size = new System.Drawing.Size(147, 18);
			this.tb_driver_license.TabIndex = 146;
			// 
			// ActForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1054, 513);
			this.ControlBox = false;
			this.Controls.Add(this.tb_driver_license);
			this.Controls.Add(this.tb_sobstv_pricep_svid);
			this.Controls.Add(this.tb_sobstv_pricep);
			this.Controls.Add(this.tb_sobs_svid);
			this.Controls.Add(this.tb_adres_sobs);
			this.Controls.Add(this.tb_kol_poezdok);
			this.Controls.Add(this.cb_mark_3);
			this.Controls.Add(this.cb_mark_2);
			this.Controls.Add(this.cb_mark_1);
			this.Controls.Add(this.tb_error_msg);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.l_km);
			this.Controls.Add(this.l_razm_usherba);
			this.Controls.Add(this.cb_driver);
			this.Controls.Add(this.tb_marsh_dvig);
			this.Controls.Add(this.pb_foto);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tb_primecanie);
			this.Controls.Add(this.cb_strana);
			this.Controls.Add(this.l_vid_1);
			this.Controls.Add(this.cb_vid_3);
			this.Controls.Add(this.cb_vid_2);
			this.Controls.Add(this.cb_vid_gruza);
			this.Controls.Add(this.b_print);
			this.Controls.Add(this.l_nomer_act);
			this.Controls.Add(this.cb_kod_sub);
			this.Controls.Add(this.l_sub);
			this.Controls.Add(this.cb_harakter_gruza);
			this.Controls.Add(this.cb_inspekt);
			this.Controls.Add(this.cb_operat);
			this.Controls.Add(this.tb_obyasn_vodit);
			this.Controls.Add(this.tb_sobstv_pricep_addess);
			this.Controls.Add(this.tb_sobstv);
			this.Controls.Add(this.tb_reg_3);
			this.Controls.Add(this.tb_reg_2);
			this.Controls.Add(this.tb_reg_1);
			this.Controls.Add(this.tb_model_3);
			this.Controls.Add(this.tb_model_2);
			this.Controls.Add(this.tb_model_1);
			this.Controls.Add(this.l_data);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ActForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Форма акта";
			this.Load += new System.EventHandler(this.FormAct_Load);
			((System.ComponentModel.ISupportInitialize)(this.pb_foto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_kol_poezdok)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l_data;
        public System.Windows.Forms.TextBox tb_model_3;
        public System.Windows.Forms.TextBox tb_model_2;
        public System.Windows.Forms.TextBox tb_model_1;
        public System.Windows.Forms.TextBox tb_reg_3;
        public System.Windows.Forms.TextBox tb_reg_2;
        public System.Windows.Forms.TextBox tb_reg_1;
        public System.Windows.Forms.TextBox tb_sobstv;
        public System.Windows.Forms.TextBox tb_sobstv_pricep_addess;
        public System.Windows.Forms.TextBox tb_obyasn_vodit;
        public System.Windows.Forms.ComboBox cb_operat;
        public System.Windows.Forms.ComboBox cb_inspekt;
        public System.Windows.Forms.ComboBox cb_harakter_gruza;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label l_sub;
        public System.Windows.Forms.ComboBox cb_kod_sub;
        private System.Windows.Forms.Label l_nomer_act;
        private System.Windows.Forms.Button b_print;
        public System.Windows.Forms.ComboBox cb_vid_gruza;
        public System.Windows.Forms.ComboBox cb_vid_2;
        public System.Windows.Forms.ComboBox cb_vid_3;
        private System.Windows.Forms.Label l_vid_1;
        public System.Windows.Forms.ComboBox cb_strana;
        private System.Windows.Forms.TextBox tb_primecanie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_foto;
        public System.Windows.Forms.TextBox tb_marsh_dvig;
        public System.Windows.Forms.ComboBox cb_driver;
        private System.Windows.Forms.Label l_razm_usherba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_km;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.TextBox tb_error_msg;
        public System.Windows.Forms.ComboBox cb_mark_1;
        public System.Windows.Forms.ComboBox cb_mark_2;
				public System.Windows.Forms.ComboBox cb_mark_3;
        public System.Windows.Forms.TextBox tb_adres_sobs;
        private System.Windows.Forms.NumericUpDown tb_kol_poezdok;
		public System.Windows.Forms.TextBox tb_sobstv_pricep;
		public System.Windows.Forms.TextBox tb_sobs_svid;
		public System.Windows.Forms.TextBox tb_sobstv_pricep_svid;
		public System.Windows.Forms.TextBox tb_driver_license;
	}
}