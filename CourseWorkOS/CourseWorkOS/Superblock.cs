using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public class Superblock
    {
        public char[] OS_name { get; set; }
        //
        public uint OS_size { get; set; }

        public ushort cluster_size { get; set; }

        public uint amount_of_free_clusters { get; set; }

        public uint amount_of_inodes { get; set; }

        public uint amount_of_free_inodes { get; set; }

        public ushort amount_of_users { get; set; }

        public ushort max_amount_of_users { get; set; } = ushort.MaxValue;//!!!Подумать над алгоритмом

        public ushort amount_of_groups { get; set; }

        public ushort max_amount_of_groups { get; set; } = ushort.MaxValue;//!!!Подумать над алгоритмом

        public uint cluster_bitmap_offset { get; set; }

        public uint inode_bitmap_offset { get; set; }

        public uint ilist_offset { get; set; }

        public uint root_offset { get; set; }

        public uint users_offset { get; set; }

        public uint groups_offset { get; set; }

        public uint data_offset { get; set; }

        //Константы

        public const byte OS_NAME_SIZE = 8;

        public const byte OS_USER_INFO_SIZE = 53;

        public const byte OS_GROUP_INFO_SIZE = 18;

        public const byte OS_SUPERBLOCK_SIZE = 62;

        public const byte OS_INODE_SIZE = 62;

        public const byte OS_ROOT_ROW_SIZE = 29;

        public const double OS_SUM_BITMAP_SIZE = 0.25;

        public const ushort DEFAULT_CLUSTER_SIZE = 512;
        

        public Superblock(uint oS_size, ushort cluster_size)
        {
            OS_name = new char[OS_NAME_SIZE] { 'S', 'a', 'm', 'a', 'n', 't', 'h', 'a' };// Имя файловой системы

            this.cluster_size = cluster_size;//Размер кластера

            this.OS_size = oS_size;//Размер файловой системы

            //max_amount_of_users = 

            //max_amount_of_groups = 

            this.amount_of_groups = this.amount_of_users = 0;

            uint user_size = (uint)max_amount_of_users * OS_USER_INFO_SIZE;//Размер данных под информацию для пользователей

            uint group_size = (uint)max_amount_of_groups * OS_GROUP_INFO_SIZE;//Размер данных под информацию для групп

            oS_size = OS_size - OS_SUPERBLOCK_SIZE - user_size - group_size;//Данные без размера суперблока, информации о пользователях и группах

            double normal_file_size = cluster_size + OS_INODE_SIZE + OS_ROOT_ROW_SIZE + OS_SUM_BITMAP_SIZE;// Размер общей информации о файле

            uint bytes_for_one_file =(uint)Math.Floor(normal_file_size);// Округленный размер информации о файле

            this.amount_of_inodes = (uint)Math.Floor(oS_size/ normal_file_size);//Количество индексных дескрипторов=количество файлов=количество кластеров

            this.amount_of_free_clusters = amount_of_inodes;
            
            this.amount_of_free_inodes = amount_of_inodes;

            uint size_data = amount_of_inodes * cluster_size;//Размер данных под кластера

            uint size_bitmap_cluster = (uint)Math.Ceiling((double)(amount_of_inodes / 8));// Размер данных под одну битовую карту

            uint size_ilist = amount_of_inodes * OS_INODE_SIZE;//Размер данных под массив inode

            uint root_size = amount_of_inodes * OS_ROOT_ROW_SIZE;//Размер данных под корневой каталог
            
            this.cluster_bitmap_offset = OS_SUPERBLOCK_SIZE;//Смещение к битовой карте св/з кластеров

            this.inode_bitmap_offset = cluster_bitmap_offset+ size_bitmap_cluster;//Смещение к битовой карте св/з inode

            this.ilist_offset = inode_bitmap_offset + size_bitmap_cluster;//Смещение к массиву inode

            this.root_offset = ilist_offset+size_ilist;//Смещение к корневому каталогу

            this.users_offset = root_offset+root_size;//Смещение к информации о пользователях

            this.groups_offset = users_offset+user_size;//Смещение к информации о группах

            this.data_offset = groups_offset+group_size;//Смщение к области данных
        }

        public Superblock()
        {
            OS_name = new char[OS_NAME_SIZE] { 'S', 'a', 'm', 'a', 'n', 't', 'h', 'a' };// Имя файловой системы

            this.cluster_size = DEFAULT_CLUSTER_SIZE;//Размер кластера

        }

        //Запись суперблока в бинарный файл
        public bool binaryWritingToFile(BinaryWriter bw)
        {
            try
            {
                bw.Write(this.OS_name);
                bw.Write(this.cluster_size);
                bw.Write(this.OS_size);
                bw.Write(this.amount_of_free_clusters);
                bw.Write(this.amount_of_inodes);
                bw.Write(this.amount_of_free_inodes);
                bw.Write(this.amount_of_users);
                bw.Write(this.max_amount_of_users);
                bw.Write(this.amount_of_groups);
                bw.Write(this.max_amount_of_groups);
                bw.Write(this.cluster_bitmap_offset);
                bw.Write(this.inode_bitmap_offset);
                bw.Write(this.ilist_offset);
                bw.Write(this.root_offset);
                bw.Write(this.users_offset);
                bw.Write(this.groups_offset);
                bw.Write(this.data_offset);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n"+e);
                return false;
            }
        }


        //Загрузка информации о суперблоке из файла
        public static Superblock loadSuperblockFromBinaryFile(BinaryReader reader)
        {
            Superblock sb = new Superblock();
            try
            {
                sb.OS_name = new char[OS_NAME_SIZE];

                for (int i = 0; i < OS_NAME_SIZE; i++)
                {
                    sb.OS_name[i] = reader.ReadChar();
                }
                
                sb.cluster_size = reader.ReadUInt16();
                sb.OS_size = reader.ReadUInt32();
                sb.amount_of_free_clusters = reader.ReadUInt32();
                sb.amount_of_inodes = reader.ReadUInt32();
                sb.amount_of_free_inodes = reader.ReadUInt32();
                sb.amount_of_users = reader.ReadUInt16();
                sb.max_amount_of_users= reader.ReadUInt16();
                sb.amount_of_groups = reader.ReadUInt16();
                sb.max_amount_of_groups= reader.ReadUInt16();
                sb.cluster_bitmap_offset = reader.ReadUInt32();
                sb.inode_bitmap_offset = reader.ReadUInt32();
                sb.ilist_offset = reader.ReadUInt32();
                sb.root_offset = reader.ReadUInt32();
                sb.users_offset = reader.ReadUInt32();
                sb.groups_offset = reader.ReadUInt32();
                sb.data_offset = reader.ReadUInt32();
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
            }
            return sb;
        }
    }
}
