using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkOS.Processes
{
    
    public enum PROCESS_STATES
    {
        WAIT = 'S',
        RUNNING = 'R',
        SVOPPING = 'V',
        READY_TO_EXECUTE = 'E'
    }

    public class ProcessStructure
    {
        private string[] process_names =  new string[10]{ "justprocess", "rythmbox","vk", "os", "Samantha:files", "Samantha:create_system",
            "Samantha:Create user","Samantha:delete file","Samantha:create group","Samantha:load" };
        
        public Process running_process { get; set; }

        public List<Process> ready_to_execute_processes { get; set; }

        public List<Process> ready_to_execute_processes_temp { get; set; }

        public List<Process> waiting_processes { get; set; }

        public List<Process> svopping_processes { get; set; }

        public bool isRunning = false;

        public char[] temp_states = new char[] { (char)PROCESS_STATES.WAIT, 
                (char)PROCESS_STATES.SVOPPING, (char)PROCESS_STATES.READY_TO_EXECUTE,(char)PROCESS_STATES.RUNNING };

        public ProcessStructure()
        {
            ready_to_execute_processes = new List<Process>();

            ready_to_execute_processes_temp = new List<Process>();

            waiting_processes = new List<Process>();

            svopping_processes = new List<Process>();
        }

        private void clearQueues()
        {
            ready_to_execute_processes.Clear();

            ready_to_execute_processes_temp.Clear();

            waiting_processes.Clear();

            svopping_processes.Clear();

            running_process = null;
        }

        
        public Process[] generateProcesses(int number, User user)
        {
            var processes = new Process[number];

            var rand = new Random();
            
            for(int i = 0; i < number; i++)
            {
                processes[i] = new Process((ulong)(i+1), user.ID_owner, user.ID_group, temp_states[rand.Next(0, 3)], 
                    (short)rand.Next(-20, 21),(uint)rand.Next(1, 30), DateTime.Now, process_names[rand.Next(1, 10)]);
            }
            //ПОДУМАТЬ НАД СВОПИНГОМ

            return processes;
        }

        public void sortProcesses(Process[] processes)
        {
            for(int i = 0; i < processes.Length; i++)
            {
                if (processes[i].STAT.Equals(temp_states[2]))
                {
                    ready_to_execute_processes.Add(processes[i]);
                    continue;
                }
                if (processes[i].STAT.Equals(temp_states[1]))
                {
                    svopping_processes.Add(processes[i]);
                    continue;
                }
                if (processes[i].STAT.Equals(temp_states[0]))
                {
                    waiting_processes.Add(processes[i]);
                    continue;
                }
            }
            ready_to_execute_processes.Sort();
            svopping_processes.Sort();
            waiting_processes.Sort();
        }

        
        public ulong getFreePID()
        {
            ulong PID = 0;

            if (ready_to_execute_processes.Count != 0)
            {
                foreach(var proc in ready_to_execute_processes)
                {
                    if (proc.PID > PID)
                    {
                        PID = proc.PID;
                    }
                }
            }
            if (ready_to_execute_processes_temp.Count != 0)
            {
                foreach (var proc in ready_to_execute_processes_temp)
                {
                    if (proc.PID > PID)
                    {
                        PID = proc.PID;
                    }
                }
            }
            if (waiting_processes.Count != 0)
            {
                foreach (var proc in ready_to_execute_processes)
                {
                    if (proc.PID > PID)
                    {
                        PID = proc.PID;
                    }
                }
            }
            if (svopping_processes.Count != 0)
            {
                foreach (var proc in ready_to_execute_processes)
                {
                    if (proc.PID > PID)
                    {
                        PID = proc.PID;
                    }
                }
            }
            return (PID+1);
        }

        public void processAlgorythm()
        {
            Random rand = new Random();
            while (true)
            {
                if (ready_to_execute_processes.Count != 0&& !isRunning)
                {
                    running_process = ready_to_execute_processes[0];
                    running_process.STAT = temp_states[3];
                    ready_to_execute_processes.RemoveAt(0);
                    isRunning = true;
                    if (running_process.processContext())
                    {
                        if (rand.Next(-1, 5) >= 0)
                        {
                            running_process.STAT = temp_states[2];
                            ready_to_execute_processes_temp.Add(running_process);
                        }
                        else
                        {
                            running_process.STAT = temp_states[0];
                            waiting_processes.Add(running_process);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Процесс завершен.");
                    }
                }
                else
                {
                    foreach(var proc in ready_to_execute_processes_temp)
                    {
                        ready_to_execute_processes.Add(proc);
                    }
                    ready_to_execute_processes_temp.Clear();
                    running_process = null;
                    if (rand.Next(0, 2) == 1)
                    {
                        if (svopping_processes.Count != 0)
                        {
                            var temp = svopping_processes[0];
                            temp.STAT = temp_states[2];
                            ready_to_execute_processes.Add(temp);
                            svopping_processes.RemoveAt(0);
                        }
                    }
                    if (rand.Next(0, 2) == 1)
                    {
                        if (waiting_processes.Count != 0)
                        {
                            var temp = waiting_processes[0];
                            temp.STAT = temp_states[2];
                            ready_to_execute_processes.Add(temp);
                            waiting_processes.RemoveAt(0);
                        }
                    }
                    ready_to_execute_processes.Sort();
                }
            }
        }
        
    } }

    
