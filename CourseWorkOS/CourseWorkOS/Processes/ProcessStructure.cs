using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Queue<Process> ready_to_execute_processes { get; set; }

        public Queue<Process> ready_to_execute_processes_temp { get; set; }

        public Queue<Process> waiting_processes { get; set; }

        public Queue<Process> svopping_processes { get; set; }

        private char[] temp_states = new char[] { (char)PROCESS_STATES.WAIT, 
                (char)PROCESS_STATES.SVOPPING, (char)PROCESS_STATES.READY_TO_EXECUTE,(char)PROCESS_STATES.RUNNING };

        public ProcessStructure()
        {
            ready_to_execute_processes = new Queue<Process>();

            ready_to_execute_processes_temp = new Queue<Process>();

            waiting_processes = new Queue<Process>();

            svopping_processes = new Queue<Process>();
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
                processes[i] = new Process(getFreePID(), user.ID_owner, user.ID_group, temp_states[rand.Next(0, 3)], 
                    (short)rand.Next(-20, 21),(uint)rand.Next(1, 300), DateTime.Now, process_names[rand.Next(1, 10)]);
            }

            return processes;
        }

        public void sortProcesses(Process[] processes)
        {
            for(int i = 0; i < processes.Length; i++)
            {
                if (processes[i].STAT.Equals(temp_states[2]))
                {
                    ready_to_execute_processes.Enqueue(processes[i]);
                    continue;
                }
                if (processes[i].STAT.Equals(temp_states[1]))
                {
                    svopping_processes.Enqueue(processes[i]);
                    continue;
                }
                if (processes[i].STAT.Equals(temp_states[0]))
                {
                    waiting_processes.Enqueue(processes[i]);
                    continue;
                }
            }
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
    } }

    
