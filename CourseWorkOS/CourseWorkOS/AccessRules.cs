using System;
using System.Collections;

namespace CourseWorkOS
{
    
    public class AccessRules
    {
        public bool r_u { get; set; }//Чтение для владельца!
        public bool w_u { get; set; }//Запись для владельца
        public bool x_u { get; set; }//Исполнение для владельца


        public bool r_g { get; set; }//Чтение для группы
        public bool w_g { get; set; }//Запись для группы
        public bool x_g { get; set; }//Исполнение для группы


        public bool r_o { get; set; }//Чтение для остальных
        public bool w_o { get; set; }//Запись для остальных
        public bool x_o { get; set; }//Исполнение для остальных

        public bool read_only_file { get; set; }//Только для чтения
        public bool hidden_file { get; set; }//Скрытый
        public bool system_file { get; set; }//Системный
        
        public AccessRules(ushort access)
        {
            BitArray access_bits = new BitArray((new int[] { access }));
            
            //Для владельца
            r_u = access_bits[11];
            w_u = access_bits[10];
            x_u = access_bits[9];

            //Для группы
            r_g = access_bits[8];
            w_g = access_bits[7];
            x_g = access_bits[6];

            //Для остальных
            r_o = access_bits[5];
            w_o = access_bits[4];
            x_o = access_bits[3];

            //Атрибуты
            read_only_file = access_bits[2];
            hidden_file  = access_bits[1];
            system_file = access_bits[0];
        }

        public AccessRules() { }

        //Получить десятичное представление прав доступа
        public ushort getAccessRulesForFile()
        {
            //Права доступа для владельца
            ushort u_access = (ushort)(Convert.ToDouble(this.r_u) * Math.Pow(2.0, 11) + Convert.ToDouble(this.w_u) * Math.Pow(2.0, 10) +
                Convert.ToDouble(this.x_u) * Math.Pow(2.0, 9));

            //Права доступа для группы
            ushort g_access = (ushort)(Convert.ToDouble(this.r_g) * Math.Pow(2.0, 8) + Convert.ToDouble(this.w_g) * Math.Pow(2.0, 7) +
                Convert.ToDouble(this.x_g) * Math.Pow(2.0, 6));

            //Права доступа для остальных
            ushort o_access = (ushort)(Convert.ToDouble(this.r_o) * Math.Pow(2.0, 5) + Convert.ToDouble(this.w_o) * Math.Pow(2.0, 4) +
                Convert.ToDouble(this.x_o) * Math.Pow(2.0, 3));

            //Права доступа для атрибутов
            ushort attributes = (ushort)(Convert.ToDouble(this.read_only_file) * Math.Pow(2.0, 2) + Convert.ToDouble(this.hidden_file) * Math.Pow(2.0, 1) +
                Convert.ToDouble(this.system_file) * Math.Pow(2.0, 0));

            return (ushort)(u_access + g_access + o_access + attributes);
        }
    }
}
