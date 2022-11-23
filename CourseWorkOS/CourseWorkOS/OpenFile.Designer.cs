namespace CourseWorkOS
{
    partial class OpenFile
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
            this.text_TB = new System.Windows.Forms.TextBox();
            this.file_name = new System.Windows.Forms.Label();
            this.cancel_B = new System.Windows.Forms.Button();
            this.ok_B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_TB
            // 
            this.text_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_TB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_TB.Location = new System.Drawing.Point(12, 38);
            this.text_TB.MaxLength = 40960;
            this.text_TB.Multiline = true;
            this.text_TB.Name = "text_TB";
            this.text_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_TB.Size = new System.Drawing.Size(776, 405);
            this.text_TB.TabIndex = 0;
            // 
            // file_name
            // 
            this.file_name.BackColor = System.Drawing.Color.Lavender;
            this.file_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.file_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_name.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.file_name.Location = new System.Drawing.Point(0, 0);
            this.file_name.Margin = new System.Windows.Forms.Padding(0);
            this.file_name.Name = "file_name";
            this.file_name.Size = new System.Drawing.Size(800, 33);
            this.file_name.TabIndex = 1;
            this.file_name.Text = "label1";
            this.file_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancel_B
            // 
            this.cancel_B.BackColor = System.Drawing.Color.Lavender;
            this.cancel_B.FlatAppearance.BorderSize = 0;
            this.cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_B.Location = new System.Drawing.Point(419, 449);
            this.cancel_B.Name = "cancel_B";
            this.cancel_B.Size = new System.Drawing.Size(188, 40);
            this.cancel_B.TabIndex = 21;
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
            this.ok_B.Location = new System.Drawing.Point(201, 449);
            this.ok_B.Name = "ok_B";
            this.ok_B.Size = new System.Drawing.Size(188, 40);
            this.ok_B.TabIndex = 20;
            this.ok_B.Text = "Применить";
            this.ok_B.UseVisualStyleBackColor = false;
            this.ok_B.Click += new System.EventHandler(this.ok_B_Click);
            // 
            // OpenFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.cancel_B);
            this.Controls.Add(this.ok_B);
            this.Controls.Add(this.file_name);
            this.Controls.Add(this.text_TB);
            this.Name = "OpenFile";
            this.Text = "Samantha:Файл";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancel_B;
        private System.Windows.Forms.Button ok_B;
        public System.Windows.Forms.Label file_name;
        public System.Windows.Forms.TextBox text_TB;
    }
}