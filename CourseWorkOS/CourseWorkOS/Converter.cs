using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    static class Converter
    {
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

        public static uint getSeconds(DateTime dt)
        {
            TimeSpan span = dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            return (uint)span.TotalSeconds;
        }

        public static DateTime GetDateTime(uint seconds)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt.AddSeconds(seconds);
            return dt;
        }

    }
}
