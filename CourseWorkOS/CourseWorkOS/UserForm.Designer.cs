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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.password_TB = new System.Windows.Forms.TextBox();
            this.enterFS_B = new System.Windows.Forms.Button();
            this.cancel_B = new System.Windows.Forms.Button();
            this.role_GB = new System.Windows.Forms.GroupBox();
            this.isAdmin = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.role_GB.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(395, 65);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            // login_TB
            // 
            this.login_TB.BackColor = System.Drawing.Color.Lavender;
            this.login_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_TB.Location = new System.Drawing.Point(68, 25);
            this.login_TB.MaxLength = 16;
            this.login_TB.Name = "login_TB";
            this.login_TB.Size = new System.Drawing.Size(321, 25);
            this.login_TB.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.password_TB);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 65);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пароль";
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
            // password_TB
            // 
            this.password_TB.BackColor = System.Drawing.Color.Lavender;
            this.password_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_TB.Location = new System.Drawing.Point(68, 25);
            this.password_TB.MaxLength = 32;
            this.password_TB.Name = "password_TB";
            this.password_TB.Size = new System.Drawing.Size(321, 25);
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
            this.enterFS_B.Location = new System.Drawing.Point(29, 160);
            this.enterFS_B.Name = "enterFS_B";
            this.enterFS_B.Size = new System.Drawing.Size(188, 45);
            this.enterFS_B.TabIndex = 7;
            this.enterFS_B.Text = "Регистрация";
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
            this.cancel_B.Location = new System.Drawing.Point(248, 160);
            this.cancel_B.Name = "cancel_B";
            this.cancel_B.Size = new System.Drawing.Size(188, 45);
            this.cancel_B.TabIndex = 8;
            this.cancel_B.Text = "Отмена";
            this.cancel_B.UseVisualStyleBackColor = false;
            this.cancel_B.Click += new System.EventHandler(this.cancel_B_Click);
            // 
            // role_GB
            // 
            this.role_GB.BackColor = System.Drawing.Color.Transparent;
            this.role_GB.Controls.Add(this.isAdmin);
            this.role_GB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.role_GB.Location = new System.Drawing.Point(413, 12);
            this.role_GB.Name = "role_GB";
            this.role_GB.Size = new System.Drawing.Size(73, 50);
            this.role_GB.TabIndex = 7;
            this.role_GB.TabStop = false;
            this.role_GB.Text = "Админ";
            // 
            // isAdmin
            // 
            this.isAdmin.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isAdmin.Location = new System.Drawing.Point(29, 17);
            this.isAdmin.Name = "isAdmin";
            this.isAdmin.Size = new System.Drawing.Size(30, 30);
            this.isAdmin.TabIndex = 0;
            this.isAdmin.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(489, 217);
            this.Controls.Add(this.role_GB);
            this.Controls.Add(this.cancel_B);
            this.Controls.Add(this.enterFS_B);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserForm";
            this.Text = "Samantha:Регистрация пользователя";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.role_GB.ResumeLayout(false);
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
        public System.Windows.Forms.CheckBox isAdmin;
        public System.Windows.Forms.GroupBox role_GB;
    }
}