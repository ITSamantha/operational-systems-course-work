namespace CourseWorkOS
{
    partial class Name_File
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
            this.cancel_B = new System.Windows.Forms.Button();
            this.ok_B = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.file_name_TB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel_B
            // 
            this.cancel_B.BackColor = System.Drawing.Color.Lavender;
            this.cancel_B.FlatAppearance.BorderSize = 0;
            this.cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_B.Location = new System.Drawing.Point(230, 96);
            this.cancel_B.Name = "cancel_B";
            this.cancel_B.Size = new System.Drawing.Size(188, 45);
            this.cancel_B.TabIndex = 11;
            this.cancel_B.Text = "Отмена";
            this.cancel_B.UseVisualStyleBackColor = false;
            this.cancel_B.Click += new System.EventHandler(this.cancel_B_Click);
            // 
            // ok_B
            // 
            this.ok_B.BackColor = System.Drawing.Color.Lavender;
            this.ok_B.FlatAppearance.BorderSize = 0;
            this.ok_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ok_B.Location = new System.Drawing.Point(12, 96);
            this.ok_B.Name = "ok_B";
            this.ok_B.Size = new System.Drawing.Size(188, 45);
            this.ok_B.TabIndex = 10;
            this.ok_B.Text = "Применить";
            this.ok_B.UseVisualStyleBackColor = false;
            this.ok_B.Click += new System.EventHandler(this.ok_B_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.file_name_TB);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 65);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название файла (с расширением или без)";
            // 
            // file_name_TB
            // 
            this.file_name_TB.BackColor = System.Drawing.Color.Lavender;
            this.file_name_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.file_name_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.file_name_TB.Location = new System.Drawing.Point(6, 25);
            this.file_name_TB.MaxLength = 25;
            this.file_name_TB.Name = "file_name_TB";
            this.file_name_TB.Size = new System.Drawing.Size(383, 25);
            this.file_name_TB.TabIndex = 0;
            // 
            // Name_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 157);
            this.Controls.Add(this.cancel_B);
            this.Controls.Add(this.ok_B);
            this.Controls.Add(this.groupBox1);
            this.Name = "Name_File";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samantha: Название файла";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel_B;
        private System.Windows.Forms.Button ok_B;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox file_name_TB;
    }
}