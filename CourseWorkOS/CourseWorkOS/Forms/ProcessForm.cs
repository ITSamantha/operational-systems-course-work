﻿using CourseWorkOS.Forms;
using CourseWorkOS.Processes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkOS
{
    public partial class ProcessForm : Form
    {
        public User user;

        public ProcessStructure process_structure;

        Thread process_algo;

        Thread form_change;

        public ProcessForm()
        {
            InitializeComponent();
        }

        public void loadUser(User user)
        {
            this.user = user;
        }

        private void add_processB_Click(object sender, EventArgs e)
        {
            AddProcessForm form = new AddProcessForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.name_TB.Text==String.Empty|| form.time_TB.Text == String.Empty|| form.priority_TB.Text == String.Empty)
                {
                    MessageBox.Show("Поля не могут быть пустыми.");
                    return;
                }
                if (int.Parse(form.time_TB.Text) <= 0)
                {
                    MessageBox.Show("Время должно превышать 0 секунд.");
                    return;
                }
            }
        }

        //Сгенерировать процессы
        private void generateProcess_Click(object sender, EventArgs e)
        {
            process_structure = new ProcessStructure();

            var processes = process_structure.generateProcesses(15, user);

            process_structure.sortProcesses(processes);

            showProcesses();
        }

        public void showProcesses()
        {
            if (process_structure.ready_to_execute_processes.Count != 0)
            {
                foreach (var proc in process_structure.ready_to_execute_processes)
                {
                    readyDG.Rows.Add(new object[] { proc.PID, proc.UID, proc.GUID, proc.STAT, proc.NI, proc.TIME_FOR_EXECUTE, proc.TIME_START, proc.COMMAND });
                }
                if (process_structure.ready_to_execute_processes_temp.Count != 0)
                {
                    foreach (var proc in process_structure.ready_to_execute_processes_temp)
                    {
                        readyDG.Rows.Add(new object[] { proc.PID, proc.UID, proc.GUID, proc.STAT, proc.NI, proc.TIME_FOR_EXECUTE, proc.TIME_START, proc.COMMAND });
                    }
                }
            }


            if (process_structure.running_process != null)
            {
                runningDG.Rows.Add(new object[] { process_structure.running_process.PID, process_structure.running_process.UID,
                    process_structure.running_process.GUID, process_structure.running_process.STAT, process_structure.running_process.NI,
                    process_structure.running_process.TIME_FOR_EXECUTE, process_structure.running_process.TIME_START,
                    process_structure.running_process.COMMAND });
            }

            if (process_structure.svopping_processes.Count != 0)
            {
                foreach (var proc in process_structure.svopping_processes)
                {
                    svoppingDG.Rows.Add(new object[] { proc.PID, proc.UID, proc.GUID, proc.STAT, proc.NI, proc.TIME_FOR_EXECUTE, proc.TIME_START, proc.COMMAND });
                }
            }

            if (process_structure.waiting_processes.Count != 0)
            {
                foreach (var proc in process_structure.waiting_processes)
                {
                    waitingDG.Rows.Add(new object[] { proc.PID, proc.UID, proc.GUID, proc.STAT, proc.NI, proc.TIME_FOR_EXECUTE, proc.TIME_START, proc.COMMAND });
                }
            }
        }

        public void clearTables()
        {
            waitingDG.Rows.Clear();
            svoppingDG.Rows.Clear();
            runningDG.Rows.Clear();
            readyDG.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process_algo = new Thread(process_structure.processAlgorythm);

            process_algo.Start();

            form_change = new Thread(processOn);

            form_change.Start();
        }

        public void processOn()
        {
            while (true)
            {
                if (process_structure.isRunning)
                {
                    Action action = () => {
                        clearTables();
                        showProcesses();
                    };
                    Invoke(action);
                    process_structure.isRunning = false;
                }
                if (process_structure.running_process == null)
                {
                    Action action = () => {
                        runningDG.Rows.Clear();
                    };
                    Invoke(action);
                }
            }
        }

        private void ProcessForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                process_algo.Abort();
                form_change.Abort();
            }
            catch(Exception)
            {

            }
        }
    }
}
