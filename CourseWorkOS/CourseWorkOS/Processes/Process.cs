using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public enum PROCESS_STATES
    {
        WAIT = 'S',
        RUNNING = 'R',
        SVOPPING ='V',
        READY_TO_EXECUTE='E'
    }

    public class Process
    {
        public ulong PID { get; private set; }

        public uint UID { get; private set; }

        public uint GUID { get; private set; }

        public char STAT { get; set; }

        public short NI { get; set; }

        public uint TIME_FOR_EXECUTE { get; set; }

        public DateTime TIME_START { get; set; }

        public string COMMAND { get; set; }

        public Process(ulong pID, uint uID, uint gUID, char sTAT, short nI, uint tIME_FOR_EXECUTE, DateTime tIME_START, string cOMMAND)
        {
            PID = pID;
            UID = uID;
            GUID = gUID;
            STAT = sTAT;
            NI = nI;
            TIME_FOR_EXECUTE = tIME_FOR_EXECUTE;
            TIME_START = tIME_START;
            COMMAND = cOMMAND;
        }

        public static Process[] generateProcesses(int count)
        {

        }

    }
}
