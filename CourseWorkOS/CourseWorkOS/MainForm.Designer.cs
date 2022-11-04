namespace CourseWorkOS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.direction_TB = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.user_change_B = new System.Windows.Forms.Button();
            this.groups_B = new System.Windows.Forms.Button();
            this.users_B = new System.Windows.Forms.Button();
            this.info_B = new System.Windows.Forms.Button();
            this.work_B = new System.Windows.Forms.Button();
            this.free_L = new System.Windows.Forms.Label();
            this.main_control = new System.Windows.Forms.TabControl();
            this.work_with_FS_TP = new System.Windows.Forms.TabPage();
            this.info_about_FS = new System.Windows.Forms.TabPage();
            this.work_with_users_TP = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.user_DG = new System.Windows.Forms.DataGridView();
            this.user_amount_L = new System.Windows.Forms.Label();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_amount_L = new System.Windows.Forms.Label();
            this.group_DG = new System.Windows.Forms.DataGridView();
            this.GID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUP_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.main_control.SuspendLayout();
            this.work_with_users_TP.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_DG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_DG)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.groups_B);
            this.panel1.Controls.Add(this.users_B);
            this.panel1.Controls.Add(this.info_B);
            this.panel1.Controls.Add(this.work_B);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 579);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.user_change_B);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.direction_TB);
            this.panel2.Location = new System.Drawing.Point(155, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 36);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Путь:";
            // 
            // direction_TB
            // 
            this.direction_TB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.direction_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.direction_TB.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.direction_TB.Location = new System.Drawing.Point(53, 6);
            this.direction_TB.MinimumSize = new System.Drawing.Size(0, 30);
            this.direction_TB.Name = "direction_TB";
            this.direction_TB.ReadOnly = true;
            this.direction_TB.Size = new System.Drawing.Size(388, 23);
            this.direction_TB.TabIndex = 0;
            this.direction_TB.Text = "/";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Controls.Add(this.free_L);
            this.panel3.Location = new System.Drawing.Point(615, 543);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 36);
            this.panel3.TabIndex = 9;
            // 
            // user_change_B
            // 
            this.user_change_B.BackColor = System.Drawing.Color.Lavender;
            this.user_change_B.FlatAppearance.BorderSize = 0;
            this.user_change_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_change_B.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_change_B.Image = global::CourseWorkOS.Properties.Resources.login;
            this.user_change_B.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.user_change_B.Location = new System.Drawing.Point(574, 0);
            this.user_change_B.Name = "user_change_B";
            this.user_change_B.Size = new System.Drawing.Size(199, 36);
            this.user_change_B.TabIndex = 8;
            this.user_change_B.UseVisualStyleBackColor = false;
            // 
            // groups_B
            // 
            this.groups_B.Dock = System.Windows.Forms.DockStyle.Top;
            this.groups_B.FlatAppearance.BorderSize = 0;
            this.groups_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groups_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groups_B.Image = global::CourseWorkOS.Properties.Resources.groups;
            this.groups_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.groups_B.Location = new System.Drawing.Point(0, 225);
            this.groups_B.Name = "groups_B";
            this.groups_B.Size = new System.Drawing.Size(146, 75);
            this.groups_B.TabIndex = 3;
            this.groups_B.Text = "Работа с группами";
            this.groups_B.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.groups_B.UseVisualStyleBackColor = true;
            this.groups_B.Click += new System.EventHandler(this.groups_B_Click);
            // 
            // users_B
            // 
            this.users_B.Dock = System.Windows.Forms.DockStyle.Top;
            this.users_B.FlatAppearance.BorderSize = 0;
            this.users_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.users_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users_B.Image = ((System.Drawing.Image)(resources.GetObject("users_B.Image")));
            this.users_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.users_B.Location = new System.Drawing.Point(0, 150);
            this.users_B.Name = "users_B";
            this.users_B.Size = new System.Drawing.Size(146, 75);
            this.users_B.TabIndex = 2;
            this.users_B.Text = "Работа с пользователями";
            this.users_B.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.users_B.UseVisualStyleBackColor = true;
            this.users_B.Click += new System.EventHandler(this.users_B_Click);
            // 
            // info_B
            // 
            this.info_B.Dock = System.Windows.Forms.DockStyle.Top;
            this.info_B.FlatAppearance.BorderSize = 0;
            this.info_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_B.Image = global::CourseWorkOS.Properties.Resources.info;
            this.info_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.info_B.Location = new System.Drawing.Point(0, 75);
            this.info_B.Name = "info_B";
            this.info_B.Size = new System.Drawing.Size(146, 75);
            this.info_B.TabIndex = 1;
            this.info_B.Text = "Сведения о файловой системе";
            this.info_B.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.info_B.UseVisualStyleBackColor = true;
            this.info_B.Click += new System.EventHandler(this.info_B_Click);
            // 
            // work_B
            // 
            this.work_B.Dock = System.Windows.Forms.DockStyle.Top;
            this.work_B.FlatAppearance.BorderSize = 0;
            this.work_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.work_B.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.work_B.Image = global::CourseWorkOS.Properties.Resources.work;
            this.work_B.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.work_B.Location = new System.Drawing.Point(0, 0);
            this.work_B.Name = "work_B";
            this.work_B.Size = new System.Drawing.Size(146, 75);
            this.work_B.TabIndex = 0;
            this.work_B.Text = "Работа с файловой системой";
            this.work_B.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.work_B.UseVisualStyleBackColor = true;
            this.work_B.Click += new System.EventHandler(this.work_B_Click);
            // 
            // free_L
            // 
            this.free_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.free_L.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.free_L.Location = new System.Drawing.Point(0, 0);
            this.free_L.Margin = new System.Windows.Forms.Padding(0);
            this.free_L.Name = "free_L";
            this.free_L.Size = new System.Drawing.Size(313, 36);
            this.free_L.TabIndex = 0;
            this.free_L.Text = "label2";
            // 
            // main_control
            // 
            this.main_control.Controls.Add(this.work_with_FS_TP);
            this.main_control.Controls.Add(this.info_about_FS);
            this.main_control.Controls.Add(this.work_with_users_TP);
            this.main_control.Controls.Add(this.tabPage1);
            this.main_control.Location = new System.Drawing.Point(155, 35);
            this.main_control.Name = "main_control";
            this.main_control.SelectedIndex = 0;
            this.main_control.Size = new System.Drawing.Size(770, 505);
            this.main_control.TabIndex = 10;
            // 
            // work_with_FS_TP
            // 
            this.work_with_FS_TP.Location = new System.Drawing.Point(4, 22);
            this.work_with_FS_TP.Name = "work_with_FS_TP";
            this.work_with_FS_TP.Padding = new System.Windows.Forms.Padding(3);
            this.work_with_FS_TP.Size = new System.Drawing.Size(762, 479);
            this.work_with_FS_TP.TabIndex = 0;
            this.work_with_FS_TP.Text = "tabPage1";
            this.work_with_FS_TP.UseVisualStyleBackColor = true;
            // 
            // info_about_FS
            // 
            this.info_about_FS.Location = new System.Drawing.Point(4, 22);
            this.info_about_FS.Name = "info_about_FS";
            this.info_about_FS.Padding = new System.Windows.Forms.Padding(3);
            this.info_about_FS.Size = new System.Drawing.Size(762, 479);
            this.info_about_FS.TabIndex = 1;
            this.info_about_FS.Text = "info_about_FS";
            this.info_about_FS.UseVisualStyleBackColor = true;
            // 
            // work_with_users_TP
            // 
            this.work_with_users_TP.Controls.Add(this.user_amount_L);
            this.work_with_users_TP.Controls.Add(this.user_DG);
            this.work_with_users_TP.Location = new System.Drawing.Point(4, 22);
            this.work_with_users_TP.Name = "work_with_users_TP";
            this.work_with_users_TP.Padding = new System.Windows.Forms.Padding(3);
            this.work_with_users_TP.Size = new System.Drawing.Size(762, 479);
            this.work_with_users_TP.TabIndex = 2;
            this.work_with_users_TP.Text = "tabPage1";
            this.work_with_users_TP.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.group_amount_L);
            this.tabPage1.Controls.Add(this.group_DG);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(762, 479);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // user_DG
            // 
            this.user_DG.AllowUserToAddRows = false;
            this.user_DG.AllowUserToDeleteRows = false;
            this.user_DG.AllowUserToOrderColumns = true;
            this.user_DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.user_DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.user_DG.BackgroundColor = System.Drawing.Color.Lavender;
            this.user_DG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.user_DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.user_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.user_DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UID,
            this.GUID,
            this.LOGIN,
            this.ROLE});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.user_DG.DefaultCellStyle = dataGridViewCellStyle2;
            this.user_DG.Location = new System.Drawing.Point(25, 29);
            this.user_DG.Name = "user_DG";
            this.user_DG.RowHeadersWidth = 75;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_DG.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.user_DG.Size = new System.Drawing.Size(714, 424);
            this.user_DG.TabIndex = 0;
            // 
            // user_amount_L
            // 
            this.user_amount_L.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_amount_L.Location = new System.Drawing.Point(456, 456);
            this.user_amount_L.Margin = new System.Windows.Forms.Padding(0);
            this.user_amount_L.Name = "user_amount_L";
            this.user_amount_L.Size = new System.Drawing.Size(306, 23);
            this.user_amount_L.TabIndex = 1;
            this.user_amount_L.Text = "Количество пользователей:";
            // 
            // UID
            // 
            this.UID.HeaderText = "UID";
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            // 
            // GUID
            // 
            this.GUID.HeaderText = "GUID";
            this.GUID.Name = "GUID";
            this.GUID.ReadOnly = true;
            // 
            // LOGIN
            // 
            this.LOGIN.HeaderText = "LOGIN";
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.ReadOnly = true;
            // 
            // ROLE
            // 
            this.ROLE.HeaderText = "ROLE";
            this.ROLE.Name = "ROLE";
            this.ROLE.ReadOnly = true;
            // 
            // group_amount_L
            // 
            this.group_amount_L.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_amount_L.Location = new System.Drawing.Point(455, 456);
            this.group_amount_L.Margin = new System.Windows.Forms.Padding(0);
            this.group_amount_L.Name = "group_amount_L";
            this.group_amount_L.Size = new System.Drawing.Size(306, 23);
            this.group_amount_L.TabIndex = 3;
            this.group_amount_L.Text = "Количество групп:";
            // 
            // group_DG
            // 
            this.group_DG.AllowUserToAddRows = false;
            this.group_DG.AllowUserToDeleteRows = false;
            this.group_DG.AllowUserToOrderColumns = true;
            this.group_DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.group_DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.group_DG.BackgroundColor = System.Drawing.Color.Lavender;
            this.group_DG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.group_DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.group_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.group_DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GID,
            this.GROUP_NAME});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.group_DG.DefaultCellStyle = dataGridViewCellStyle5;
            this.group_DG.Location = new System.Drawing.Point(24, 29);
            this.group_DG.Name = "group_DG";
            this.group_DG.RowHeadersWidth = 75;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_DG.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.group_DG.Size = new System.Drawing.Size(714, 424);
            this.group_DG.TabIndex = 2;
            // 
            // GID
            // 
            this.GID.HeaderText = "GID";
            this.GID.Name = "GID";
            this.GID.ReadOnly = true;
            // 
            // GROUP_NAME
            // 
            this.GROUP_NAME.HeaderText = "GROUP_NAME";
            this.GROUP_NAME.Name = "GROUP_NAME";
            this.GROUP_NAME.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(926, 579);
            this.Controls.Add(this.main_control);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SamanthaOS";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.main_control.ResumeLayout(false);
            this.work_with_users_TP.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.user_DG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button work_B;
        private System.Windows.Forms.Button info_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox direction_TB;
        private System.Windows.Forms.Button user_change_B;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button users_B;
        private System.Windows.Forms.Button groups_B;
        private System.Windows.Forms.Label free_L;
        private System.Windows.Forms.TabControl main_control;
        private System.Windows.Forms.TabPage work_with_FS_TP;
        private System.Windows.Forms.TabPage info_about_FS;
        private System.Windows.Forms.TabPage work_with_users_TP;
        private System.Windows.Forms.Label user_amount_L;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView user_DG;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLE;
        private System.Windows.Forms.Label group_amount_L;
        public System.Windows.Forms.DataGridView group_DG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUP_NAME;
    }
}