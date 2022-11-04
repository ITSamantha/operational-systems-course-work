using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    static class Converter
    {
        //!
        public static char[] convertFromBytesIntoChar(byte[] str)
        {
            Encoding encoding = Encoding.Default;
            return encoding.GetChars(str);
        }

        public static byte[] convertFromCharIntoBytes(char[] str)
        {
            Encoding encoding = Encoding.Default;
            return encoding.GetBytes(str);
        }

    }
}
