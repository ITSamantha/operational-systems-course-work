namespace CourseWorkOS
{
    partial class GroupWork
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
            this.group_TB = new System.Windows.Forms.TextBox();
            this.cancel_B = new System.Windows.Forms.Button();
            this.enter_B = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.group_TB);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название группы";
            // 
            // group_TB
            // 
            this.group_TB.BackColor = System.Drawing.Color.Lavender;
            this.group_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_TB.Location = new System.Drawing.Point(6, 24);
            this.group_TB.MaxLength = 16;
            this.group_TB.Name = "group_TB";
            this.group_TB.Size = new System.Drawing.Size(435, 32);
            this.group_TB.TabIndex = 0;
            // 
            // cancel_B
            // 
            this.cancel_B.BackColor = System.Drawing.Color.Lavender;
            this.cancel_B.FlatAppearance.BorderSize = 0;
            this.cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_B.Location = new System.Drawing.Point(268, 106);
            this.cancel_B.Name = "cancel_B";
            this.cancel_B.Size = new System.Drawing.Size(188, 45);
            this.cancel_B.TabIndex = 10;
            this.cancel_B.Text = "Отмена";
            this.cancel_B.UseVisualStyleBackColor = false;
            this.cancel_B.Click += new System.EventHandler(this.cancel_B_Click);
            // 
            // enter_B
            // 
            this.enter_B.BackColor = System.Drawing.Color.Lavender;
            this.enter_B.FlatAppearance.BorderSize = 0;
            this.enter_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enter_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enter_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enter_B.Location = new System.Drawing.Point(14, 106);
            this.enter_B.Name = "enter_B";
            this.enter_B.Size = new System.Drawing.Size(188, 45);
            this.enter_B.TabIndex = 9;
            this.enter_B.Text = "Изменить";
            this.enter_B.UseVisualStyleBackColor = false;
            this.enter_B.Click += new System.EventHandler(this.enter_B_Click);
            // 
            // GroupWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(471, 179);
            this.Controls.Add(this.cancel_B);
            this.Controls.Add(this.enter_B);
            this.Controls.Add(this.groupBox1);
            this.Name = "GroupWork";
            this.Text = "GroupWork";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox group_TB;
        private System.Windows.Forms.Button cancel_B;
        private System.Windows.Forms.Button enter_B;
    }
}