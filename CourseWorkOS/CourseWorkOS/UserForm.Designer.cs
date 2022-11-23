namespace CourseWorkOS
{
    partial class UserForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.login_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.password_TB = new System.Windows.Forms.TextBox();
            this.enterFS_B = new System.Windows.Forms.Button();
            this.cancel_B = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.login_TB);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 65);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // login_TB
            // 
            this.login_TB.BackColor = System.Drawing.Color.Lavender;
            this.login_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_TB.Location = new System.Drawing.Point(68, 25);
            this.login_TB.MaxLength = 16;
            this.login_TB.Name = "login_TB";
            this.login_TB.Size = new System.Drawing.Size(391, 25);
            this.login_TB.TabIndex = 0;
            this.login_TB.Leave += new System.EventHandler(this.login_TB_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.password_TB);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 65);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пароль";
            // 
            // password_TB
            // 
            this.password_TB.BackColor = System.Drawing.Color.Lavender;
            this.password_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_TB.Location = new System.Drawing.Point(68, 25);
            this.password_TB.MaxLength = 32;
            this.password_TB.Name = "password_TB";
            this.password_TB.Size = new System.Drawing.Size(391, 25);
            this.password_TB.TabIndex = 0;
            this.password_TB.UseSystemPasswordChar = true;
            // 
            // enterFS_B
            // 
            this.enterFS_B.BackColor = System.Drawing.Color.Lavender;
            this.enterFS_B.FlatAppearance.BorderSize = 0;
            this.enterFS_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterFS_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterFS_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enterFS_B.Location = new System.Drawing.Point(29, 224);
            this.enterFS_B.Name = "enterFS_B";
            this.enterFS_B.Size = new System.Drawing.Size(188, 45);
            this.enterFS_B.TabIndex = 7;
            this.enterFS_B.Text = "Изменить";
            this.enterFS_B.UseVisualStyleBackColor = false;
            this.enterFS_B.Click += new System.EventHandler(this.enterFS_B_Click);
            // 
            // cancel_B
            // 
            this.cancel_B.BackColor = System.Drawing.Color.Lavender;
            this.cancel_B.FlatAppearance.BorderSize = 0;
            this.cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_B.Location = new System.Drawing.Point(283, 224);
            this.cancel_B.Name = "cancel_B";
            this.cancel_B.Size = new System.Drawing.Size(188, 45);
            this.cancel_B.TabIndex = 8;
            this.cancel_B.Text = "Отмена";
            this.cancel_B.UseVisualStyleBackColor = false;
            this.cancel_B.Click += new System.EventHandler(this.cancel_B_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 64);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Группа";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Lavender;
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 23);
            this.comboBox1.MaxLength = 16;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(391, 31);
            this.comboBox1.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::CourseWorkOS.Properties.Resources.work1;
            this.pictureBox3.Location = new System.Drawing.Point(17, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::CourseWorkOS.Properties.Resources.pass;
            this.pictureBox2.Location = new System.Drawing.Point(17, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CourseWorkOS.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(17, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(489, 276);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cancel_B);
            this.Controls.Add(this.enterFS_B);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samantha:Изменение пользователя";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox login_TB;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox password_TB;
        private System.Windows.Forms.Button enterFS_B;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button cancel_B;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}