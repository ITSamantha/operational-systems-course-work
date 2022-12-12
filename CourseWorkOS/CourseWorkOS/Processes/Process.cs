using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    
    public class Process:IComparable<Process>
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

        public int CompareTo(Process next)
        {
            if (next.NI.Equals(this.NI)) { return 0; }

            if (next.NI > this.NI)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }


        //ПОДУМАТЬ
        //Квант - 3000 мс
        public bool processContext()
        {
            Thread.Sleep(1000);
            TIME_FOR_EXECUTE--;

            if (TIME_FOR_EXECUTE == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
