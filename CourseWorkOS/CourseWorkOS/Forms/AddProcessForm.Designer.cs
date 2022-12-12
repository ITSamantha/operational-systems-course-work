namespace CourseWorkOS.Forms
{
    partial class AddProcessForm
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
            this.name_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.priority_TB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.time_TB = new System.Windows.Forms.TextBox();
            this.cancel_B = new System.Windows.Forms.Button();
            this.enter_B = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.name_TB);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название/COMMAND";
            // 
            // name_TB
            // 
            this.name_TB.BackColor = System.Drawing.Color.Lavender;
            this.name_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_TB.Location = new System.Drawing.Point(6, 25);
            this.name_TB.MaxLength = 256;
            this.name_TB.Name = "name_TB";
            this.name_TB.Size = new System.Drawing.Size(453, 25);
            this.name_TB.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.priority_TB);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 65);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Приоритет [-20;20]/NI";
            // 
            // priority_TB
            // 
            this.priority_TB.BackColor = System.Drawing.Color.Lavender;
            this.priority_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priority_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priority_TB.Location = new System.Drawing.Point(6, 25);
            this.priority_TB.MaxLength = 3;
            this.priority_TB.Name = "priority_TB";
            this.priority_TB.Size = new System.Drawing.Size(453, 25);
            this.priority_TB.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.time_TB);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 65);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Время работы/TIME_FOR_EXECUTE";
            // 
            // time_TB
            // 
            this.time_TB.BackColor = System.Drawing.Color.Lavender;
            this.time_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_TB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_TB.Location = new System.Drawing.Point(6, 25);
            this.time_TB.MaxLength = 4;
            this.time_TB.Name = "time_TB";
            this.time_TB.Size = new System.Drawing.Size(453, 25);
            this.time_TB.TabIndex = 0;
            // 
            // cancel_B
            // 
            this.cancel_B.BackColor = System.Drawing.Color.Lavender;
            this.cancel_B.FlatAppearance.BorderSize = 0;
            this.cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_B.Location = new System.Drawing.Point(283, 241);
            this.cancel_B.Name = "cancel_B";
            this.cancel_B.Size = new System.Drawing.Size(188, 45);
            this.cancel_B.TabIndex = 12;
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
            this.enter_B.Location = new System.Drawing.Point(29, 241);
            this.enter_B.Name = "enter_B";
            this.enter_B.Size = new System.Drawing.Size(188, 45);
            this.enter_B.TabIndex = 11;
            this.enter_B.Text = "Добавить";
            this.enter_B.UseVisualStyleBackColor = false;
            this.enter_B.Click += new System.EventHandler(this.enter_B_Click);
            // 
            // AddProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(489, 298);
            this.Controls.Add(this.cancel_B);
            this.Controls.Add(this.enter_B);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddProcessForm";
            this.Text = "Samantha:Добавить процесс";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox name_TB;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox priority_TB;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox time_TB;
        private System.Windows.Forms.Button cancel_B;
        private System.Windows.Forms.Button enter_B;
    }
}