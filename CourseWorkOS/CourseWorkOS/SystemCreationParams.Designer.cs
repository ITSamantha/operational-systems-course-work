namespace CourseWorkOS
{
    partial class SystemCreationParams
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
            this.enterFS_B = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.value_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FS_size = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cluster_size_CB = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FS_size)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterFS_B
            // 
            this.enterFS_B.BackColor = System.Drawing.Color.Lavender;
            this.enterFS_B.FlatAppearance.BorderSize = 0;
            this.enterFS_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterFS_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterFS_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enterFS_B.Location = new System.Drawing.Point(196, 193);
            this.enterFS_B.Name = "enterFS_B";
            this.enterFS_B.Size = new System.Drawing.Size(268, 45);
            this.enterFS_B.TabIndex = 3;
            this.enterFS_B.Text = "Создать файловую систему";
            this.enterFS_B.UseVisualStyleBackColor = false;
            this.enterFS_B.Click += new System.EventHandler(this.enterFS_B_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.value_label);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FS_size);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размер файловой системы";
            // 
            // value_label
            // 
            this.value_label.AutoSize = true;
            this.value_label.Location = new System.Drawing.Point(550, 75);
            this.value_label.Name = "value_label";
            this.value_label.Size = new System.Drawing.Size(0, 19);
            this.value_label.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Текущее количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "4096 Мб";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "5 Мб";
            // 
            // FS_size
            // 
            this.FS_size.Location = new System.Drawing.Point(49, 25);
            this.FS_size.Maximum = 4095;
            this.FS_size.Minimum = 5;
            this.FS_size.Name = "FS_size";
            this.FS_size.Size = new System.Drawing.Size(517, 45);
            this.FS_size.TabIndex = 0;
            this.FS_size.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FS_size.Value = 4000;
            this.FS_size.ValueChanged += new System.EventHandler(this.FS_size_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cluster_size_CB);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(4, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 66);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Размер кластера файловой системы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "байт";
            // 
            // cluster_size_CB
            // 
            this.cluster_size_CB.BackColor = System.Drawing.Color.Lavender;
            this.cluster_size_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cluster_size_CB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cluster_size_CB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cluster_size_CB.FormattingEnabled = true;
            this.cluster_size_CB.IntegralHeight = false;
            this.cluster_size_CB.ItemHeight = 21;
            this.cluster_size_CB.Items.AddRange(new object[] {
            "512",
            "1024",
            "2048",
            "4096"});
            this.cluster_size_CB.Location = new System.Drawing.Point(49, 25);
            this.cluster_size_CB.Name = "cluster_size_CB";
            this.cluster_size_CB.Size = new System.Drawing.Size(517, 29);
            this.cluster_size_CB.TabIndex = 0;
            // 
            // SystemCreationParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(645, 245);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.enterFS_B);
            this.Name = "SystemCreationParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samantha:Создание файловой системы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FS_size)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enterFS_B;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label value_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TrackBar FS_size;
        public System.Windows.Forms.ComboBox cluster_size_CB;
    }
}