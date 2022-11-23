using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    static class Converter
    {
        //Конвертация из байтов в символы
        public static char[] convertFromBytesIntoChar(byte[] str)
        {
            Encoding encoding = Encoding.Default;
            return encoding.GetChars(str);
        }

        //Конвертация из символов в байты
        public static byte[] convertFromCharIntoBytes(char[] str)
        {
            Encoding encoding = Encoding.Default;
            return encoding.GetBytes(str);
        }

        //Получение секунд из даты от 01.01.1970
        public static uint getSeconds(DateTime dt)
        {
            TimeSpan span = dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            return (uint)span.TotalSeconds;
        }

        //Получение даты по секундам от 01.01.1970
        public static DateTime GetDateTime(uint seconds)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(seconds);
            return dt;
        }

        public static void getBaseAndExtention(string name, out string _ext,out string _base)
        {
            _ext = Path.GetExtension(name);
            
            _base = Path.GetFileNameWithoutExtension(name);
            
        }
        
    }
}
