using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public class RootCatalogRow
    {
        public char[] file_name { get; set; }

        public char[] file_extention { get; set; }

        public uint inode_number { get; set; }

        //Константы

        public const ushort NAME_SIZE = 20;

        public const ushort EXTENTION_SIZE = 5;
        
        public RootCatalogRow(char[] row_name, char[] row_extention, uint inode_number)
        {
            file_name = new char[20];

            for(int i = 0; i < row_name.Length; i++)
            {
                this.file_name[i] = row_name[i];
            }

            file_extention = new char[5];

            for (int i = 0; i < row_extention.Length; i++)
            {
                this.file_extention[i] = row_extention[i];
            }

            this.inode_number = inode_number;
        }

        public RootCatalogRow(){}

        //Запись строки корневого каталога в бинарный файл
        public bool binaryWritingToFile(BinaryWriter bw)
        {
            try
            {
                bw.Write(Converter.convertFromCharIntoBytes(this.file_name));//Кодировка русских символов
                bw.Write(Converter.convertFromCharIntoBytes(this.file_extention));//Кодировка русских символов
                bw.Write(this.inode_number);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
                return false;
            }
        }
        
        //Загрузка информации о записи корневого каталога из файла
        public static RootCatalogRow loadRootRowFromBinaryFile(BinaryReader reader)
        {
            RootCatalogRow root = new RootCatalogRow();

            try
            {
                root.file_name = new char[NAME_SIZE];

                byte[] name = reader.ReadBytes(NAME_SIZE);
                
                root.file_name = Converter.convertFromBytesIntoChar(name);

                root.file_extention = new char[EXTENTION_SIZE];

                byte[] extention = reader.ReadBytes(EXTENTION_SIZE);

                root.file_extention = Converter.convertFromBytesIntoChar(extention);
                
                root.inode_number = reader.ReadUInt32();
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
            }
            return root;
        }

        public static string createFileName(RootCatalogRow file)
        {
            StringBuilder s = new StringBuilder();

            for (int j = 0; j < file.file_name.Length; j++)
            {
                if (file.file_name[j] != '\0')
                {
                    s.Append(file.file_name[j]);
                }
            }

            for (int j = 0; j < file.file_extention.Length; j++)
            {
                if (file.file_extention[j] != '\0')
                {
                    s.Append(file.file_extention[j]);
                }
            }
            return $"{s.ToString()}";
        }
    }
}
