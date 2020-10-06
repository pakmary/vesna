namespace Vesna
{
    partial class VideoPictuceControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
	        this.pictureBox1 = new System.Windows.Forms.PictureBox();
	        this.b_action = new System.Windows.Forms.Button();
	        this.comboBox1 = new System.Windows.Forms.ComboBox();
	        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
	        this.SuspendLayout();
	        // 
	        // pictureBox1
	        // 
	        this.pictureBox1.Anchor =
		        ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) |
		                                              System.Windows.Forms.AnchorStyles.Right)));
	        this.pictureBox1.BackColor = System.Drawing.Color.Snow;
	        this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.pictureBox1.Location = new System.Drawing.Point(0, 0);
	        this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
	        this.pictureBox1.Name = "pictureBox1";
	        this.pictureBox1.Size = new System.Drawing.Size(133, 109);
	        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
	        this.pictureBox1.TabIndex = 0;
	        this.pictureBox1.TabStop = false;
	        this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
	        // 
	        // b_action
	        // 
	        this.b_action.Anchor =
		        ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
	        this.b_action.BackColor = System.Drawing.Color.Snow;
	        this.b_action.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.b_action.Location = new System.Drawing.Point(0, 134);
	        this.b_action.Margin = new System.Windows.Forms.Padding(2);
	        this.b_action.Name = "b_action";
	        this.b_action.Size = new System.Drawing.Size(132, 22);
	        this.b_action.TabIndex = 1;
	        this.b_action.Text = "Обзор";
	        this.b_action.UseVisualStyleBackColor = false;
	        this.b_action.Click += new System.EventHandler(this.b_action_Click);
	        // 
	        // comboBox1
	        // 
	        this.comboBox1.Anchor =
		        ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
	        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	        this.comboBox1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	        this.comboBox1.FormattingEnabled = true;
	        this.comboBox1.Location = new System.Drawing.Point(0, 111);
	        this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
	        this.comboBox1.Name = "comboBox1";
	        this.comboBox1.Size = new System.Drawing.Size(133, 28);
	        this.comboBox1.TabIndex = 2;
	        this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
	        // 
	        // openFileDialog1
	        // 
	        this.openFileDialog1.FileName = "openFileDialog1";
	        // 
	        // VideoPictuceControl
	        // 
	        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 10F);
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.BackColor = System.Drawing.Color.White;
	        this.Controls.Add(this.comboBox1);
	        this.Controls.Add(this.b_action);
	        this.Controls.Add(this.pictureBox1);
	        this.Margin = new System.Windows.Forms.Padding(2);
	        this.Name = "VideoPictuceControl";
	        this.Size = new System.Drawing.Size(100, 167);
	        this.Load += new System.EventHandler(this.VideoPictuce_Load);
	        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
	        this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button b_action;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
