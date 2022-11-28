using CourseWorkOS.Processes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkOS
{
    public partial class ProcessForm : Form
    {
        public User user;

        public ProcessStructure process_structure;

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

        }

        //Сгенерировать процессы
        private void generateProcess_Click(object sender, EventArgs e)
        {
            process_structure = new ProcessStructure();

            var processes = process_structure.generateProcesses(12, user);

            process_structure.sortProcesses(processes);

            if (process_structure.ready_to_execute_processes.Count != 0)
            {
                foreach (var proc in process_structure.ready_to_execute_processes)
                {
                    readyDG.Rows.Add(new object[] { proc.PID, proc.UID, proc.GUID, proc.STAT, proc.NI, proc.TIME_FOR_EXECUTE, proc.TIME_START, proc.COMMAND });
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
    }
}
