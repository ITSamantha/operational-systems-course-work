using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public class Group//
    {
        public ushort ID_group { get; set; }

        public char[] group_name { get; set; }

        //Константы

        public const ushort GROUP_SIZE = 16;

        //СМЕНА НАЗВАНИЯ ГРУППЫ
        public Group(ushort iD_group, char[] group_name)
        {
            this.ID_group = iD_group;

            this.group_name = new char[GROUP_SIZE];

            for (int i = 0; i < group_name.Length; i++)
            {
                this.group_name[i] = group_name[i];
            }
        }

        public Group() { }

        //Запись группы в бинарный файл
        public bool binaryWritingToFile(BinaryWriter bw)
        {
            try
            {
                bw.Write(this.ID_group);
                bw.Write(Converter.convertFromCharIntoBytes(this.group_name));//Кодировка русских символов
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
                return false;
            }
        }

        //Загрузка информации о группе из файла
        public static Group loadGroupFromBinaryFile(BinaryReader reader)
        {
            Group group = new Group();

            try
            {
                group.ID_group = reader.ReadUInt16();

                byte[] name = reader.ReadBytes(GROUP_SIZE);

                group.group_name = Converter.convertFromBytesIntoChar(name);
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
            }
            return group;
        }
        
    }
}
