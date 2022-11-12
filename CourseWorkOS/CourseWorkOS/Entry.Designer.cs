namespace CourseWorkOS
{
    partial class entryForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createFS_B = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.enterFS_B = new System.Windows.Forms.Button();
            this.work_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CourseWorkOS.Properties.Resources.auto_logo;
            this.pictureBox1.Location = new System.Drawing.Point(1, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.createFS_B);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.enterFS_B);
            this.panel1.Controls.Add(this.work_B);
            this.panel1.Location = new System.Drawing.Point(1, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 146);
            this.panel1.TabIndex = 1;
            // 
            // createFS_B
            // 
            this.createFS_B.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.createFS_B.FlatAppearance.BorderSize = 0;
            this.createFS_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createFS_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createFS_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createFS_B.Location = new System.Drawing.Point(80, 86);
            this.createFS_B.Name = "createFS_B";
            this.createFS_B.Size = new System.Drawing.Size(268, 45);
            this.createFS_B.TabIndex = 4;
            this.createFS_B.Text = "Создание системы";
            this.createFS_B.UseVisualStyleBackColor = false;
            this.createFS_B.Click += new System.EventHandler(this.createFS_B_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(80, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(268, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Работа с файловой системой";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // enterFS_B
            // 
            this.enterFS_B.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.enterFS_B.FlatAppearance.BorderSize = 0;
            this.enterFS_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterFS_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterFS_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enterFS_B.Location = new System.Drawing.Point(80, 26);
            this.enterFS_B.Name = "enterFS_B";
            this.enterFS_B.Size = new System.Drawing.Size(268, 45);
            this.enterFS_B.TabIndex = 2;
            this.enterFS_B.Text = "Вход в систему";
            this.enterFS_B.UseVisualStyleBackColor = false;
            this.enterFS_B.Click += new System.EventHandler(this.enterFS_B_Click);
            // 
            // work_B
            // 
            this.work_B.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.work_B.FlatAppearance.BorderSize = 0;
            this.work_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.work_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.work_B.Location = new System.Drawing.Point(80, 26);
            this.work_B.Name = "work_B";
            this.work_B.Size = new System.Drawing.Size(268, 45);
            this.work_B.TabIndex = 1;
            this.work_B.Text = "Работа с файловой системой";
            this.work_B.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "SamanthaOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // entryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "entryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samantha:Система";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.entryForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button enterFS_B;
        private System.Windows.Forms.Button work_B;
        private System.Windows.Forms.Button createFS_B;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}

