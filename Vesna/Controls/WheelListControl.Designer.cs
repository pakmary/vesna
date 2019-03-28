namespace Vesna.Controls {
	partial class WheelListControl {
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.l_massDopus = new System.Windows.Forms.Label();
			this.l_mass = new System.Windows.Forms.Label();
			this.cb_vid_TC = new System.Windows.Forms.ComboBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.l_kol_os = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.b_del_wheel = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tb_Rastoyan = new System.Windows.Forms.NumericUpDown();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.l_ves = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tb_razmerUsherba = new System.Windows.Forms.Label();
			this.videoPictuce1 = new Vesna.VideoPictuceControl();
			this.os10 = new Vesna.Controls.WheelControl();
			this.os9 = new Vesna.Controls.WheelControl();
			this.os8 = new Vesna.Controls.WheelControl();
			this.os7 = new Vesna.Controls.WheelControl();
			this.os6 = new Vesna.Controls.WheelControl();
			this.os5 = new Vesna.Controls.WheelControl();
			this.os4 = new Vesna.Controls.WheelControl();
			this.os3 = new Vesna.Controls.WheelControl();
			this.os2 = new Vesna.Controls.WheelControl();
			this.os1 = new Vesna.Controls.WheelControl();
			this.label14 = new System.Windows.Forms.Label();
			this.l_mass_procent = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tb_Rastoyan)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(22, 431);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 20);
			this.label1.TabIndex = 21;
			this.label1.Text = "фактический:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(22, 451);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 20);
			this.label2.TabIndex = 22;
			this.label2.Text = "допустимый:";
			// 
			// l_massDopus
			// 
			this.l_massDopus.AutoSize = true;
			this.l_massDopus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_massDopus.ForeColor = System.Drawing.Color.Red;
			this.l_massDopus.Location = new System.Drawing.Point(158, 451);
			this.l_massDopus.Name = "l_massDopus";
			this.l_massDopus.Size = new System.Drawing.Size(18, 20);
			this.l_massDopus.TabIndex = 24;
			this.l_massDopus.Text = "0";
			// 
			// l_mass
			// 
			this.l_mass.AutoSize = true;
			this.l_mass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_mass.Location = new System.Drawing.Point(158, 431);
			this.l_mass.Name = "l_mass";
			this.l_mass.Size = new System.Drawing.Size(18, 20);
			this.l_mass.TabIndex = 23;
			this.l_mass.Text = "0";
			// 
			// cb_vid_TC
			// 
			this.cb_vid_TC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_vid_TC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_vid_TC.FormattingEnabled = true;
			this.cb_vid_TC.Location = new System.Drawing.Point(233, 3);
			this.cb_vid_TC.Name = "cb_vid_TC";
			this.cb_vid_TC.Size = new System.Drawing.Size(351, 28);
			this.cb_vid_TC.TabIndex = 10;
			this.cb_vid_TC.SelectedIndexChanged += new System.EventHandler(this.cb_vid_TC_SelectedIndexChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(262, 411);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(143, 20);
			this.label3.TabIndex = 31;
			this.label3.Text = "Количество осей:";
			// 
			// l_kol_os
			// 
			this.l_kol_os.AutoSize = true;
			this.l_kol_os.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_kol_os.Location = new System.Drawing.Point(403, 411);
			this.l_kol_os.Name = "l_kol_os";
			this.l_kol_os.Size = new System.Drawing.Size(18, 20);
			this.l_kol_os.TabIndex = 32;
			this.l_kol_os.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(22, 331);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 20);
			this.label4.TabIndex = 16;
			this.label4.Text = "допустимая:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(22, 373);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(123, 20);
			this.label5.TabIndex = 34;
			this.label5.Text = "превышение%:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(22, 352);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 20);
			this.label6.TabIndex = 2;
			this.label6.Text = "превышение:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(22, 309);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(115, 20);
			this.label7.TabIndex = 0;
			this.label7.Text = "фактическая:";
			// 
			// b_del_wheel
			// 
			this.b_del_wheel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.b_del_wheel.Location = new System.Drawing.Point(10, 228);
			this.b_del_wheel.Name = "b_del_wheel";
			this.b_del_wheel.Size = new System.Drawing.Size(140, 37);
			this.b_del_wheel.TabIndex = 15;
			this.b_del_wheel.Text = "X";
			this.b_del_wheel.UseVisualStyleBackColor = true;
			this.b_del_wheel.Click += new System.EventHandler(this.b_del_wheel_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(588, 6);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(192, 20);
			this.label8.TabIndex = 38;
			this.label8.Text = "Пройденное растояние:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(156, 6);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 20);
			this.label9.TabIndex = 39;
			this.label9.Text = "Тип ТС:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.Location = new System.Drawing.Point(898, 6);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(32, 20);
			this.label11.TabIndex = 41;
			this.label11.Text = "КМ";
			// 
			// tb_Rastoyan
			// 
			this.tb_Rastoyan.DecimalPlaces = 2;
			this.tb_Rastoyan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_Rastoyan.Location = new System.Drawing.Point(786, 3);
			this.tb_Rastoyan.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.tb_Rastoyan.Name = "tb_Rastoyan";
			this.tb_Rastoyan.Size = new System.Drawing.Size(106, 26);
			this.tb_Rastoyan.TabIndex = 12;
			this.tb_Rastoyan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Rastoyan_KeyPress);
			this.tb_Rastoyan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_Rastoyan_MouseClick);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// l_ves
			// 
			this.l_ves.AutoSize = true;
			this.l_ves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_ves.ForeColor = System.Drawing.Color.Red;
			this.l_ves.Location = new System.Drawing.Point(689, 431);
			this.l_ves.Name = "l_ves";
			this.l_ves.Size = new System.Drawing.Size(18, 20);
			this.l_ves.TabIndex = 50;
			this.l_ves.Text = "0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label16.Location = new System.Drawing.Point(9, 411);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(120, 20);
			this.label16.TabIndex = 51;
			this.label16.Text = "Полная масса:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(648, 411);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 20);
			this.button1.TabIndex = 52;
			this.button1.Text = "Включить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(9, 289);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(122, 20);
			this.label10.TabIndex = 53;
			this.label10.Text = "Осевые массы:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.Location = new System.Drawing.Point(580, 411);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(52, 20);
			this.label12.TabIndex = 54;
			this.label12.Text = "Весы:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.Location = new System.Drawing.Point(580, 431);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(107, 20);
			this.label13.TabIndex = 55;
			this.label13.Text = "Текущий вес:";
			// 
			// tb_razmerUsherba
			// 
			this.tb_razmerUsherba.AutoSize = true;
			this.tb_razmerUsherba.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_razmerUsherba.Location = new System.Drawing.Point(898, 412);
			this.tb_razmerUsherba.Name = "tb_razmerUsherba";
			this.tb_razmerUsherba.Size = new System.Drawing.Size(0, 20);
			this.tb_razmerUsherba.TabIndex = 56;
			// 
			// videoPictuce1
			// 
			this.videoPictuce1.BackColor = System.Drawing.Color.White;
			this.videoPictuce1.Location = new System.Drawing.Point(10, 37);
			this.videoPictuce1.Name = "videoPictuce1";
			this.videoPictuce1.Size = new System.Drawing.Size(140, 187);
			this.videoPictuce1.TabIndex = 13;
			// 
			// os10
			// 
			this.os10.BackColor = System.Drawing.Color.LightGray;
			this.os10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os10.Index = 9;
			this.os10.IsUpper = false;
			this.os10.Location = new System.Drawing.Point(1114, 37);
			this.os10.Nagruzka = 0F;
			this.os10.NagruzkaDopust = 0F;
			this.os10.Name = "os10";
			this.os10.RastoyanDoSledOs = 0F;
			this.os10.Size = new System.Drawing.Size(106, 365);
			this.os10.TabIndex = 9;
			this.os10.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os10.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os10.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os9
			// 
			this.os9.BackColor = System.Drawing.Color.LightGray;
			this.os9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os9.Index = 8;
			this.os9.IsUpper = false;
			this.os9.Location = new System.Drawing.Point(1008, 37);
			this.os9.Nagruzka = 0F;
			this.os9.NagruzkaDopust = 0F;
			this.os9.Name = "os9";
			this.os9.RastoyanDoSledOs = 0F;
			this.os9.Size = new System.Drawing.Size(106, 365);
			this.os9.TabIndex = 8;
			this.os9.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os9.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os9.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os8
			// 
			this.os8.BackColor = System.Drawing.Color.LightGray;
			this.os8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os8.Index = 7;
			this.os8.IsUpper = false;
			this.os8.Location = new System.Drawing.Point(902, 37);
			this.os8.Nagruzka = 0F;
			this.os8.NagruzkaDopust = 0F;
			this.os8.Name = "os8";
			this.os8.RastoyanDoSledOs = 0F;
			this.os8.Size = new System.Drawing.Size(106, 365);
			this.os8.TabIndex = 7;
			this.os8.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os8.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os8.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os7
			// 
			this.os7.BackColor = System.Drawing.Color.LightGray;
			this.os7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os7.Index = 6;
			this.os7.IsUpper = false;
			this.os7.Location = new System.Drawing.Point(796, 37);
			this.os7.Nagruzka = 0F;
			this.os7.NagruzkaDopust = 0F;
			this.os7.Name = "os7";
			this.os7.RastoyanDoSledOs = 0F;
			this.os7.Size = new System.Drawing.Size(106, 365);
			this.os7.TabIndex = 6;
			this.os7.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os7.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os7.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os6
			// 
			this.os6.BackColor = System.Drawing.Color.LightGray;
			this.os6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os6.Index = 5;
			this.os6.IsUpper = false;
			this.os6.Location = new System.Drawing.Point(690, 37);
			this.os6.Nagruzka = 0F;
			this.os6.NagruzkaDopust = 0F;
			this.os6.Name = "os6";
			this.os6.RastoyanDoSledOs = 0F;
			this.os6.Size = new System.Drawing.Size(106, 365);
			this.os6.TabIndex = 5;
			this.os6.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os6.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os6.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os5
			// 
			this.os5.BackColor = System.Drawing.Color.LightGray;
			this.os5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os5.Index = 4;
			this.os5.IsUpper = false;
			this.os5.Location = new System.Drawing.Point(584, 37);
			this.os5.Nagruzka = 0F;
			this.os5.NagruzkaDopust = 0F;
			this.os5.Name = "os5";
			this.os5.RastoyanDoSledOs = 0F;
			this.os5.Size = new System.Drawing.Size(106, 365);
			this.os5.TabIndex = 4;
			this.os5.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os5.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os5.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os4
			// 
			this.os4.BackColor = System.Drawing.Color.LightGray;
			this.os4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os4.Index = 3;
			this.os4.IsUpper = false;
			this.os4.Location = new System.Drawing.Point(478, 37);
			this.os4.Nagruzka = 0F;
			this.os4.NagruzkaDopust = 0F;
			this.os4.Name = "os4";
			this.os4.RastoyanDoSledOs = 0F;
			this.os4.Size = new System.Drawing.Size(106, 365);
			this.os4.TabIndex = 3;
			this.os4.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os4.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os4.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os3
			// 
			this.os3.BackColor = System.Drawing.Color.LightGray;
			this.os3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os3.Index = 2;
			this.os3.IsUpper = false;
			this.os3.Location = new System.Drawing.Point(372, 37);
			this.os3.Nagruzka = 0F;
			this.os3.NagruzkaDopust = 0F;
			this.os3.Name = "os3";
			this.os3.RastoyanDoSledOs = 0F;
			this.os3.Size = new System.Drawing.Size(106, 365);
			this.os3.TabIndex = 2;
			this.os3.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os3.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os3.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os2
			// 
			this.os2.BackColor = System.Drawing.Color.LightGray;
			this.os2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os2.Index = 1;
			this.os2.IsUpper = false;
			this.os2.Location = new System.Drawing.Point(266, 37);
			this.os2.Nagruzka = 0F;
			this.os2.NagruzkaDopust = 0F;
			this.os2.Name = "os2";
			this.os2.RastoyanDoSledOs = 0F;
			this.os2.Size = new System.Drawing.Size(106, 365);
			this.os2.TabIndex = 1;
			this.os2.WheelState = Vesna.Controls.WheelControlState.Nothing;
			this.os2.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os2.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// os1
			// 
			this.os1.BackColor = System.Drawing.Color.LightGray;
			this.os1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.os1.Index = 0;
			this.os1.IsUpper = false;
			this.os1.Location = new System.Drawing.Point(160, 37);
			this.os1.Nagruzka = 0F;
			this.os1.NagruzkaDopust = 0F;
			this.os1.Name = "os1";
			this.os1.RastoyanDoSledOs = 0F;
			this.os1.Size = new System.Drawing.Size(106, 365);
			this.os1.TabIndex = 0;
			this.os1.WheelState = Vesna.Controls.WheelControlState.Plus;
			this.os1.WheelStatusChanged += new Vesna.Controls.WheelControl.WheelStatusChangedHandler(this.os_WheelStateChanged);
			this.os1.ButtonAddClick += new System.EventHandler(this.os1_ButtonAddClick);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.Location = new System.Drawing.Point(22, 471);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(123, 20);
			this.label14.TabIndex = 57;
			this.label14.Text = "превышение%:";
			// 
			// l_mass_procent
			// 
			this.l_mass_procent.AutoSize = true;
			this.l_mass_procent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_mass_procent.Location = new System.Drawing.Point(158, 471);
			this.l_mass_procent.Name = "l_mass_procent";
			this.l_mass_procent.Size = new System.Drawing.Size(18, 20);
			this.l_mass_procent.TabIndex = 58;
			this.l_mass_procent.Text = "0";
			// 
			// WheelListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.l_mass_procent);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tb_razmerUsherba);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.l_ves);
			this.Controls.Add(this.videoPictuce1);
			this.Controls.Add(this.tb_Rastoyan);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.b_del_wheel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.l_kol_os);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cb_vid_TC);
			this.Controls.Add(this.l_massDopus);
			this.Controls.Add(this.l_mass);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.os10);
			this.Controls.Add(this.os9);
			this.Controls.Add(this.os8);
			this.Controls.Add(this.os7);
			this.Controls.Add(this.os6);
			this.Controls.Add(this.os5);
			this.Controls.Add(this.os4);
			this.Controls.Add(this.os3);
			this.Controls.Add(this.os2);
			this.Controls.Add(this.os1);
			this.Name = "WheelListControl";
			this.Size = new System.Drawing.Size(1228, 501);
			((System.ComponentModel.ISupportInitialize)(this.tb_Rastoyan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label l_massDopus;
		private System.Windows.Forms.Label l_mass;
		private System.Windows.Forms.ComboBox cb_vid_TC;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label l_kol_os;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button b_del_wheel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		//private VideoPictuce videoPictuce1;
		private System.Windows.Forms.NumericUpDown tb_Rastoyan;
		private VideoPictuceControl videoPictuce1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label l_ves;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private WheelControl os1;
		private WheelControl os2;
		private WheelControl os3;
		private WheelControl os4;
		private WheelControl os5;
		private WheelControl os6;
		private WheelControl os7;
		private WheelControl os8;
		private WheelControl os9;
		private WheelControl os10;
		private System.Windows.Forms.Label tb_razmerUsherba;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label l_mass_procent;
	}
}
