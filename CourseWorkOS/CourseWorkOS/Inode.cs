using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    class Inode
    {//ФУНКЦИЯ ВРЕМЕНИ ДОПИСАТЬ1
        public ushort ID_owner { get; set; }

        public ushort ID_group { get; set; }

        public ushort access_rules { get; set; }

        public uint size_in_bytes { get; set; }

        public uint size_in_clusters { get; set; }

        public uint datetime_of_creation { get; set; }

        public uint datetime_of_last_modification { get; set; }

        public int[] addr { get; set; }

        //Константы

        public const byte ADDR_LENGTH= 10;

        public const short FREE_CLUSTER = -1;//Указывает, что адрес пуст, кластер не выделен

        public Inode(ushort iD_owner, ushort iD_group,ushort access_rules, uint size_in_bytes, uint size_in_clusters,
            uint datetime_of_last_modification, uint datetime_of_creation, int[] addr)
        {
            this.ID_owner = iD_owner;

            this.ID_group = iD_group;

            this.access_rules = access_rules;

            this.size_in_bytes = size_in_bytes;

            this.size_in_clusters = size_in_clusters;
            
            this.datetime_of_last_modification = datetime_of_last_modification;

            this.datetime_of_creation = datetime_of_creation;

            this.addr = new int[ADDR_LENGTH];

            for(int i = 0; i < ADDR_LENGTH; i++)
            {
                this.addr[i] = i >= addr.Length ? -1 : addr[i];
            }
        }

        public Inode()
        {
            this.addr = new int[10];

            for (int i = 0; i < ADDR_LENGTH; i++)
            {
                this.addr[i] = -1;
            }
        }

        //Запись inode в файл
        public bool binaryWritingToFile(BinaryWriter bw)
        {
            try
            {
                bw.Write(this.ID_owner);
                bw.Write(this.ID_group);
                bw.Write(this.access_rules);
                bw.Write(this.size_in_bytes);
                bw.Write(this.size_in_clusters);
                bw.Write(this.datetime_of_last_modification);
                bw.Write(this.datetime_of_creation);
                for (int i = 0; i < ADDR_LENGTH; i++)
                {
                    bw.Write(this.addr[i]);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
                return false;
            }
        }

        //Загрузка inode из файла
        public static Inode loadInodeFromBinaryFile(BinaryReader reader)
        {
            Inode inode = new Inode();
            try
            {
                inode.ID_owner = reader.ReadUInt16();
                inode.ID_group = reader.ReadUInt16();
                inode.access_rules = reader.ReadUInt16();
                inode.size_in_bytes = reader.ReadUInt32();
                inode.size_in_clusters = reader.ReadUInt32();
                inode.datetime_of_last_modification = reader.ReadUInt32();
                inode.datetime_of_creation = reader.ReadUInt32();
                for(int i = 0; i < ADDR_LENGTH; i++)
                {
                    inode.addr[i] = reader.ReadInt32();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
            }
            return inode;
        }
    }
    
}

