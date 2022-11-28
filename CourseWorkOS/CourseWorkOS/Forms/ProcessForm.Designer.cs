namespace CourseWorkOS
{
    partial class ProcessForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            this.runningDG = new System.Windows.Forms.DataGridView();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_FOR_EXECUTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_START = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.readyDG = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.svoppingDG = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.waitingDG = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.generateProcess = new System.Windows.Forms.Button();
            this.killProcessV = new System.Windows.Forms.Button();
            this.killProcessS = new System.Windows.Forms.Button();
            this.killProcessE = new System.Windows.Forms.Button();
            this.killProcessR = new System.Windows.Forms.Button();
            this.add_processB = new System.Windows.Forms.Button();
            this.changePriV = new System.Windows.Forms.Button();
            this.changePriS = new System.Windows.Forms.Button();
            this.changePriE = new System.Windows.Forms.Button();
            this.changePriR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.runningDG)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readyDG)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svoppingDG)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingDG)).BeginInit();
            this.SuspendLayout();
            // 
            // runningDG
            // 
            this.runningDG.AllowUserToAddRows = false;
            this.runningDG.AllowUserToDeleteRows = false;
            this.runningDG.AllowUserToOrderColumns = true;
            this.runningDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.runningDG.BackgroundColor = System.Drawing.Color.Lavender;
            this.runningDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.runningDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.runningDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PID,
            this.USERID,
            this.GROUPID,
            this.STAT,
            this.NI,
            this.TIME_FOR_EXECUTE,
            this.TIME_START,
            this.COMMAND});
            this.runningDG.Location = new System.Drawing.Point(6, 22);
            this.runningDG.MultiSelect = false;
            this.runningDG.Name = "runningDG";
            this.runningDG.ReadOnly = true;
            this.runningDG.RowHeadersWidth = 10;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runningDG.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.runningDG.RowTemplate.Height = 40;
            this.runningDG.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.runningDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.runningDG.Size = new System.Drawing.Size(814, 92);
            this.runningDG.TabIndex = 4;
            // 
            // PID
            // 
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            this.PID.Width = 65;
            // 
            // USERID
            // 
            this.USERID.HeaderText = "UID";
            this.USERID.Name = "USERID";
            this.USERID.ReadOnly = true;
            this.USERID.Width = 67;
            // 
            // GROUPID
            // 
            this.GROUPID.HeaderText = "GUID";
            this.GROUPID.Name = "GROUPID";
            this.GROUPID.ReadOnly = true;
            this.GROUPID.Width = 81;
            // 
            // STAT
            // 
            this.STAT.HeaderText = "STAT";
            this.STAT.Name = "STAT";
            this.STAT.ReadOnly = true;
            this.STAT.Width = 79;
            // 
            // NI
            // 
            this.NI.HeaderText = "NI";
            this.NI.Name = "NI";
            this.NI.ReadOnly = true;
            this.NI.Width = 54;
            // 
            // TIME_FOR_EXECUTE
            // 
            this.TIME_FOR_EXECUTE.HeaderText = "RUNNING_TIME";
            this.TIME_FOR_EXECUTE.Name = "TIME_FOR_EXECUTE";
            this.TIME_FOR_EXECUTE.ReadOnly = true;
            this.TIME_FOR_EXECUTE.Width = 175;
            // 
            // TIME_START
            // 
            this.TIME_START.HeaderText = "TIME_START";
            this.TIME_START.Name = "TIME_START";
            this.TIME_START.ReadOnly = true;
            this.TIME_START.Width = 148;
            // 
            // COMMAND
            // 
            this.COMMAND.HeaderText = "COMMAND";
            this.COMMAND.Name = "COMMAND";
            this.COMMAND.ReadOnly = true;
            this.COMMAND.Width = 133;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.runningDG);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выполняющийся";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readyDG);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 204);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Готовы к исполнению";
            // 
            // readyDG
            // 
            this.readyDG.AllowUserToAddRows = false;
            this.readyDG.AllowUserToDeleteRows = false;
            this.readyDG.AllowUserToOrderColumns = true;
            this.readyDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.readyDG.BackgroundColor = System.Drawing.Color.Lavender;
            this.readyDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.readyDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.readyDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.readyDG.Location = new System.Drawing.Point(6, 23);
            this.readyDG.MultiSelect = false;
            this.readyDG.Name = "readyDG";
            this.readyDG.ReadOnly = true;
            this.readyDG.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readyDG.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.readyDG.RowTemplate.Height = 40;
            this.readyDG.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.readyDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.readyDG.Size = new System.Drawing.Size(814, 175);
            this.readyDG.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "PID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "UID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 67;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "GUID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 81;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "STAT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 79;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "NI";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 54;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "RUNNING_TIME";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 175;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "TIME_START";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 148;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "COMMAND";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 133;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.svoppingDG);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 527);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(825, 156);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Свопинг";
            // 
            // svoppingDG
            // 
            this.svoppingDG.AllowUserToAddRows = false;
            this.svoppingDG.AllowUserToDeleteRows = false;
            this.svoppingDG.AllowUserToOrderColumns = true;
            this.svoppingDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.svoppingDG.BackgroundColor = System.Drawing.Color.Lavender;
            this.svoppingDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.svoppingDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.svoppingDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.svoppingDG.Location = new System.Drawing.Point(6, 22);
            this.svoppingDG.MultiSelect = false;
            this.svoppingDG.Name = "svoppingDG";
            this.svoppingDG.ReadOnly = true;
            this.svoppingDG.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.svoppingDG.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.svoppingDG.RowTemplate.Height = 40;
            this.svoppingDG.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.svoppingDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.svoppingDG.Size = new System.Drawing.Size(814, 122);
            this.svoppingDG.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "PID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 65;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "UID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 67;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "GUID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 81;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "STAT";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 79;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "NI";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 54;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "RUNNING_TIME";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 175;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "TIME_START";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 148;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "COMMAND";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 133;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.waitingDG);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(12, 361);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(825, 168);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ожидающие";
            // 
            // waitingDG
            // 
            this.waitingDG.AllowUserToAddRows = false;
            this.waitingDG.AllowUserToDeleteRows = false;
            this.waitingDG.AllowUserToOrderColumns = true;
            this.waitingDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.waitingDG.BackgroundColor = System.Drawing.Color.Lavender;
            this.waitingDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.waitingDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waitingDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24});
            this.waitingDG.Location = new System.Drawing.Point(6, 22);
            this.waitingDG.MultiSelect = false;
            this.waitingDG.Name = "waitingDG";
            this.waitingDG.ReadOnly = true;
            this.waitingDG.RowHeadersWidth = 10;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waitingDG.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.waitingDG.RowTemplate.Height = 40;
            this.waitingDG.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.waitingDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.waitingDG.Size = new System.Drawing.Size(814, 138);
            this.waitingDG.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "PID";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 65;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "UID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 67;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "GUID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 81;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "STAT";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 79;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "NI";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 54;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "RUNNING_TIME";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 175;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "TIME_START";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 148;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "COMMAND";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 133;
            // 
            // generateProcess
            // 
            this.generateProcess.BackColor = System.Drawing.Color.Transparent;
            this.generateProcess.FlatAppearance.BorderSize = 0;
            this.generateProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateProcess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateProcess.Image = global::CourseWorkOS.Properties.Resources.process1;
            this.generateProcess.Location = new System.Drawing.Point(46, 3);
            this.generateProcess.Margin = new System.Windows.Forms.Padding(0);
            this.generateProcess.Name = "generateProcess";
            this.generateProcess.Size = new System.Drawing.Size(25, 25);
            this.generateProcess.TabIndex = 23;
            this.toolTip1.SetToolTip(this.generateProcess, "Сгенерировать процессы");
            this.generateProcess.UseVisualStyleBackColor = false;
            this.generateProcess.Click += new System.EventHandler(this.generateProcess_Click);
            // 
            // killProcessV
            // 
            this.killProcessV.BackColor = System.Drawing.Color.Transparent;
            this.killProcessV.FlatAppearance.BorderSize = 0;
            this.killProcessV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.killProcessV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.killProcessV.Image = global::CourseWorkOS.Properties.Resources.kill_process;
            this.killProcessV.Location = new System.Drawing.Point(839, 565);
            this.killProcessV.Margin = new System.Windows.Forms.Padding(0);
            this.killProcessV.Name = "killProcessV";
            this.killProcessV.Size = new System.Drawing.Size(25, 25);
            this.killProcessV.TabIndex = 22;
            this.toolTip1.SetToolTip(this.killProcessV, "Убить процесс");
            this.killProcessV.UseVisualStyleBackColor = false;
            // 
            // killProcessS
            // 
            this.killProcessS.BackColor = System.Drawing.Color.Transparent;
            this.killProcessS.FlatAppearance.BorderSize = 0;
            this.killProcessS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.killProcessS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.killProcessS.Image = global::CourseWorkOS.Properties.Resources.kill_process;
            this.killProcessS.Location = new System.Drawing.Point(840, 397);
            this.killProcessS.Margin = new System.Windows.Forms.Padding(0);
            this.killProcessS.Name = "killProcessS";
            this.killProcessS.Size = new System.Drawing.Size(25, 25);
            this.killProcessS.TabIndex = 21;
            this.toolTip1.SetToolTip(this.killProcessS, "Убить процесс");
            this.killProcessS.UseVisualStyleBackColor = false;
            // 
            // killProcessE
            // 
            this.killProcessE.BackColor = System.Drawing.Color.Transparent;
            this.killProcessE.FlatAppearance.BorderSize = 0;
            this.killProcessE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.killProcessE.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.killProcessE.Image = global::CourseWorkOS.Properties.Resources.kill_process;
            this.killProcessE.Location = new System.Drawing.Point(840, 193);
            this.killProcessE.Margin = new System.Windows.Forms.Padding(0);
            this.killProcessE.Name = "killProcessE";
            this.killProcessE.Size = new System.Drawing.Size(25, 25);
            this.killProcessE.TabIndex = 20;
            this.toolTip1.SetToolTip(this.killProcessE, "Убить процесс");
            this.killProcessE.UseVisualStyleBackColor = false;
            // 
            // killProcessR
            // 
            this.killProcessR.BackColor = System.Drawing.Color.Transparent;
            this.killProcessR.FlatAppearance.BorderSize = 0;
            this.killProcessR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.killProcessR.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.killProcessR.Image = global::CourseWorkOS.Properties.Resources.kill_process;
            this.killProcessR.Location = new System.Drawing.Point(840, 67);
            this.killProcessR.Margin = new System.Windows.Forms.Padding(0);
            this.killProcessR.Name = "killProcessR";
            this.killProcessR.Size = new System.Drawing.Size(25, 25);
            this.killProcessR.TabIndex = 19;
            this.toolTip1.SetToolTip(this.killProcessR, "Убить процесс");
            this.killProcessR.UseVisualStyleBackColor = false;
            // 
            // add_processB
            // 
            this.add_processB.BackColor = System.Drawing.Color.Transparent;
            this.add_processB.FlatAppearance.BorderSize = 0;
            this.add_processB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_processB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_processB.Image = global::CourseWorkOS.Properties.Resources.add_proces;
            this.add_processB.Location = new System.Drawing.Point(12, 3);
            this.add_processB.Margin = new System.Windows.Forms.Padding(0);
            this.add_processB.Name = "add_processB";
            this.add_processB.Size = new System.Drawing.Size(25, 25);
            this.add_processB.TabIndex = 18;
            this.toolTip1.SetToolTip(this.add_processB, "Добавить процесс");
            this.add_processB.UseVisualStyleBackColor = false;
            this.add_processB.Click += new System.EventHandler(this.add_processB_Click);
            // 
            // changePriV
            // 
            this.changePriV.BackColor = System.Drawing.Color.Transparent;
            this.changePriV.FlatAppearance.BorderSize = 0;
            this.changePriV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePriV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePriV.Image = global::CourseWorkOS.Properties.Resources.edit;
            this.changePriV.Location = new System.Drawing.Point(840, 537);
            this.changePriV.Margin = new System.Windows.Forms.Padding(0);
            this.changePriV.Name = "changePriV";
            this.changePriV.Size = new System.Drawing.Size(25, 25);
            this.changePriV.TabIndex = 17;
            this.toolTip1.SetToolTip(this.changePriV, "Изменить приоритет процесса");
            this.changePriV.UseVisualStyleBackColor = false;
            // 
            // changePriS
            // 
            this.changePriS.BackColor = System.Drawing.Color.Transparent;
            this.changePriS.FlatAppearance.BorderSize = 0;
            this.changePriS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePriS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePriS.Image = global::CourseWorkOS.Properties.Resources.edit;
            this.changePriS.Location = new System.Drawing.Point(840, 372);
            this.changePriS.Margin = new System.Windows.Forms.Padding(0);
            this.changePriS.Name = "changePriS";
            this.changePriS.Size = new System.Drawing.Size(25, 25);
            this.changePriS.TabIndex = 16;
            this.toolTip1.SetToolTip(this.changePriS, "Изменить приоритет процесса");
            this.changePriS.UseVisualStyleBackColor = false;
            // 
            // changePriE
            // 
            this.changePriE.BackColor = System.Drawing.Color.Transparent;
            this.changePriE.FlatAppearance.BorderSize = 0;
            this.changePriE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePriE.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePriE.Image = global::CourseWorkOS.Properties.Resources.edit;
            this.changePriE.Location = new System.Drawing.Point(840, 165);
            this.changePriE.Margin = new System.Windows.Forms.Padding(0);
            this.changePriE.Name = "changePriE";
            this.changePriE.Size = new System.Drawing.Size(25, 25);
            this.changePriE.TabIndex = 15;
            this.toolTip1.SetToolTip(this.changePriE, "Изменить приоритет процесса");
            this.changePriE.UseVisualStyleBackColor = false;
            // 
            // changePriR
            // 
            this.changePriR.BackColor = System.Drawing.Color.Transparent;
            this.changePriR.FlatAppearance.BorderSize = 0;
            this.changePriR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePriR.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePriR.Image = global::CourseWorkOS.Properties.Resources.edit;
            this.changePriR.Location = new System.Drawing.Point(840, 42);
            this.changePriR.Margin = new System.Windows.Forms.Padding(0);
            this.changePriR.Name = "changePriR";
            this.changePriR.Size = new System.Drawing.Size(25, 25);
            this.changePriR.TabIndex = 14;
            this.toolTip1.SetToolTip(this.changePriR, "Изменить приоритет процесса");
            this.changePriR.UseVisualStyleBackColor = false;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(909, 690);
            this.Controls.Add(this.generateProcess);
            this.Controls.Add(this.killProcessV);
            this.Controls.Add(this.killProcessS);
            this.Controls.Add(this.killProcessE);
            this.Controls.Add(this.killProcessR);
            this.Controls.Add(this.add_processB);
            this.Controls.Add(this.changePriV);
            this.Controls.Add(this.changePriS);
            this.Controls.Add(this.changePriE);
            this.Controls.Add(this.changePriR);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samantha:Процессы";
            ((System.ComponentModel.ISupportInitialize)(this.runningDG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.readyDG)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.svoppingDG)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waitingDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView runningDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_FOR_EXECUTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_START;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMAND;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView readyDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DataGridView svoppingDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.DataGridView waitingDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        public System.Windows.Forms.Button changePriR;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button changePriE;
        public System.Windows.Forms.Button changePriS;
        public System.Windows.Forms.Button changePriV;
        public System.Windows.Forms.Button add_processB;
        public System.Windows.Forms.Button killProcessR;
        public System.Windows.Forms.Button killProcessE;
        public System.Windows.Forms.Button killProcessS;
        public System.Windows.Forms.Button killProcessV;
        public System.Windows.Forms.Button generateProcess;
    }
}