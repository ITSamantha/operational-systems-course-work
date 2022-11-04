using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public class FileSystem//
    {
        public const string SYSTEM_FILE_NAME = "data.bin";

        public Superblock superblock;

        public User user = new User();

        public void createFileSystem(ushort cluster_size= 512 ,uint fs_size= 4294967295)
        {
            using (var fs1 = new FileStream(FileSystem.SYSTEM_FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs1.SetLength(fs_size);
            }

            superblock = new Superblock(fs_size, cluster_size);

            uint bit_size = (uint)Math.Ceiling((double)superblock.amount_of_inodes / 8);

            byte[] cluster_bitmap = new byte[bit_size];

            byte[] inode_bitmap = new byte[bit_size];

            //!!!!Тут регистрация пользователя

            using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.OpenOrCreate)))
            {
                superblock.binaryWritingToFile(writer);
                writer.Write(cluster_bitmap);
                writer.Write(inode_bitmap);
            }
        }

        public bool loadFileSystemFromFile()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    superblock = Superblock.loadSuperblockFromBinaryFile(reader);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception happened: " + e);
                return false;
            }
        }


        //ЧТО ЗАПИСАТЬ В BYTE, ЕСЛИ ФАЙЛ ПУСТ?
        //Создание файла
        public bool createFile(char[] file_name, char[] extention, byte[] bytes)
        {
            try
            {
                if (superblock.amount_of_free_clusters == 0)
                {
                    Console.Write("Все кластеры заняты.");
                    return false;
                }
                if (superblock.amount_of_free_inodes == 0)
                {
                    Console.Write("Все индексные дескрипторы заняты.");
                    return false;
                }
                //КОГДА БОЛЬШЕ 10 КЛАСТЕРОВ ТОЖЕ ОБРАБОТАТЬ!
                int[] ID_clusters;

                byte[] new_files_bytes;

                int cluster_number = (int)Math.Ceiling(((double)bytes.Length / (double)superblock.cluster_size));

                getFreeClustersAddressesAndBytes(cluster_number,out ID_clusters,out new_files_bytes);
                
                setStateOfClustersInBitmap(ID_clusters,  true, new_files_bytes);

                superblock.amount_of_free_clusters-=(uint)ID_clusters.Length;

                int ID_inode;

                byte inode_byte;
                

                //ЗАПИСЬ В КОРНЕВОМ КАТАЛОГЕ

                //ЗАПИСЬ ACCESS_RULES

                getFreeInodeId(out ID_inode,out inode_byte);

                setStateOfInodeInBitmap(ID_inode, true, inode_byte);

                superblock.amount_of_free_inodes--;

                Inode inode = new Inode(user.ID_owner, user.ID_group, (ushort)248/*!!!!*/, (uint)bytes.Length, (uint)cluster_number,
                    (uint)DateTime.Now.Second, (uint)DateTime.Now.Second, ID_clusters);//ДОДЕЛАТЬ СЕКУНДЫ
                
                Cluster[] clusters = getClusterArrFromBytesArr(bytes, (ushort)cluster_number);

                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    superblock.binaryWritingToFile(writer);

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.ilist_offset + ID_inode*Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                    inode.binaryWritingToFile(writer);
                    
                    for(int i = 0; i < ID_clusters.Length; i++)
                    {
                        writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.data_offset + ID_clusters[i] * 512), SeekOrigin.Current);

                        clusters[i].binaryWritingToFile(writer);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception:" + e);
                return false;
            }
        }


        //Изменение файла, зная номер айнода
        public void editFileWithInode(uint inode_number,byte[] new_bytes)
        {
            if (isInodeBusy(inode_number, true))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.ilist_offset + Superblock.OS_INODE_SIZE * inode_number), SeekOrigin.Current);

                    Inode inode = Inode.loadInodeFromBinaryFile(reader);

                    //setStateOfClustersInBitmap()

                    //createFile()
                }
            }
            else
            {
                Console.WriteLine("Такого файла не существует.");
                return;
            }
        }


        //Получить список всех пользователей
        public User[] getUsersArray()
        {
            if (superblock.amount_of_users != 0)
            {
                User[] users = new User[superblock.amount_of_users];
                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.users_offset), SeekOrigin.Current);

                    for (int i = 0; i < superblock.amount_of_users; i++)
                    {
                        users[i] = User.loadUserFromBinaryFile(reader);
                    }
                }
                return users;
            }
            return null;
            
        }

        //Получить список всех пользователей
        public Group[] getGroupsArray()
        {
            if (superblock.amount_of_groups != 0)
            {
                Group[] groups = new Group[superblock.amount_of_groups];
                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.groups_offset), SeekOrigin.Current);

                    for (int i = 0; i < superblock.amount_of_groups; i++)
                    {
                        groups[i] =Group.loadGroupFromBinaryFile(reader);
                    }
                }
                return groups;
            }
            return null;

        }



        //Считка файла, зная номер айнода
        public byte[] readFileWithInode(uint inode_number)
        {
            byte[] bytes;

            if(isInodeBusy(inode_number, true))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, 
                        superblock.ilist_offset + Superblock.OS_INODE_SIZE*inode_number), SeekOrigin.Current);

                    Inode inode = Inode.loadInodeFromBinaryFile(reader);

                    bytes = new byte[inode.size_in_bytes];

                    //ПРОВЕРКА НА ПУСТОТУ/НЕПУСТОТУ КЛАСТЕРОВ!!
                    int offset = 0;

                    for (int i = 0; i < inode.addr.Length;i++)
                    {
                        if (inode.addr[i] == -1) { break; }
                        else
                        {
                            reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, 
                                superblock.data_offset + superblock.cluster_size * inode.addr[i]), SeekOrigin.Current);

                            Cluster cluster = Cluster.loadClusterFromBinaryFile(reader,superblock.cluster_size);

                            for(int j = 0; j < cluster.bytes.Length; j++)
                            {
                                if (offset >= bytes.Length)
                                {
                                    break;
                                }
                                else
                                {
                                    bytes[offset] = cluster.bytes[j];
                                    offset++;
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Такого файла не существует.");
                return null;
            }
            return bytes;
        }

        
        //Получить массив кластеров из массива байтов
        public Cluster[] getClusterArrFromBytesArr(byte[] bytes,ushort cluster_number)
        {
            Cluster[] clusters = new Cluster[cluster_number];

            for(int i = 0; i < cluster_number; i++)
            {
                clusters[i] = new Cluster(superblock.cluster_size);
            }

            int offset = 0;
            
            for (int i = 0; i < cluster_number; i++)
            {
                clusters[i].bytes = new byte[superblock.cluster_size];

                for(int j = 0; j <superblock.cluster_size;j++)
                {
                    if (offset >= bytes.Length)
                    {
                        break;
                    }

                    clusters[i].bytes[j] = bytes[offset];
                    offset ++;
                }
               
            }
            return clusters;
        }
        
        //Получение адресов и байтов кластеров для файла
        public void getFreeClustersAddressesAndBytes(int number, out int[] clusters,out byte[] bytes)
        {
            clusters = new int[number];

            bytes = new byte[number];

            int index = 0;

            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, superblock.cluster_bitmap_offset), SeekOrigin.Current);

                for(int i = 0; i < superblock.amount_of_inodes; i++)
                {
                    byte b = reader.ReadByte();

                    BitArray bits = new BitArray((new byte[] { b }));

                    for(int j = 0; j < bits.Length; j++)
                    {
                        if (index != number)
                        {
                            if (!bits[7-j])
                            {
                                clusters[index] = i*8+j;
                                bytes[index] = b;
                                index++;
                            }
                        }
                        else { return; }
                    }

                }
            }
        }
        
        //Установка значений битов в битовой карте кластеров
        public bool setStateOfClustersInBitmap(int[] clusters,bool isBusy,byte[] bytes)
        {
            try
            {
                for (int i = 0; i < clusters.Length;)
                {
                    int temp_j = 0;

                    int cluster_number = 0;

                    BitArray bits = new BitArray((new byte[] { bytes[i] }));

                    cluster_number = clusters[i]/8;

                    for (int j = i; j < clusters.Length; j++)
                    {
                        if (clusters[j] / 8 == clusters[i] / 8)
                        {
                            bits[7 - clusters[j] % 8] = isBusy;
                            temp_j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                    {
                        writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.cluster_bitmap_offset + cluster_number), SeekOrigin.Current);

                        byte[] new_byte = new byte[1];

                        bits.CopyTo(new_byte, 0);

                        writer.Write(new_byte);

                        i += temp_j;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:" + e);
                return false;
            }
        }

        //Поиск свободного inode
        public void getFreeInodeId(out int ID_inode, out byte inode_byte)
        {
            ID_inode = inode_byte = 0;

            ////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {
                reader.BaseStream.Seek(calculateWhereToCome( reader.BaseStream.Position, superblock.inode_bitmap_offset), SeekOrigin.Current);

                for (int i = 0; i < superblock.amount_of_inodes; i++)
                {
                    byte b = reader.ReadByte();

                    BitArray bits = new BitArray((new byte[] { b }));

                    for (int j = 0; j < bits.Length; j++)
                    {
                        if (!bits[7-j])
                        {
                            ID_inode = i * 8 + j;
                            inode_byte = b;
                            return;
                        }
                    }
                }
            }
        }


        //Функция проверки занят/свободен inode
        public bool isInodeBusy(uint inode_number, bool isBusy)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, superblock.inode_bitmap_offset+inode_number/8), SeekOrigin.Current);
                    
                     byte b = reader.ReadByte();
                            
                     BitArray bits = new BitArray((new byte[] { b }));

                     for (int j = 0; j < bits.Length; j++)
                     {
                          if (j == (7-inode_number % 8))
                          {
                            return bits[j] == isBusy;
                          }
                     }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.Write("Exception happened:" + e);
                return false;
            }
        }

        //Установка значений битов в битовой карте inode
        public bool setStateOfInodeInBitmap(int inode_id, bool isBusy, byte inode_byte)
        {
            try
            {
                BitArray bits = new BitArray((new byte[] { inode_byte }));

                int byte_number = inode_id / 8;

                int position = inode_id % 8;

                bits[7 - position] = isBusy;

                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.inode_bitmap_offset + byte_number), SeekOrigin.Current);

                    byte[] new_byte = new byte[1];

                    bits.CopyTo(new_byte, 0);

                    writer.Write(new_byte);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:" + e);
                return false;
            }
        }

        public long calculateWhereToCome(long current_position, long next_position) => next_position - current_position;


        //Создание пользователя системы
        public void createUserFS(string user_login, string password, bool role = false)
        {
            try
            {
                int owner_id = -1;

                if (superblock.amount_of_users != 0)
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                    {
                        reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, 
                            superblock.users_offset+(superblock.amount_of_users-1)*Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                        User last_user = User.loadUserFromBinaryFile(reader);

                        owner_id = last_user.ID_owner;
                    }
                }
                else { role = true; }//Первый пользователь автоматически становится администратором
                
                ushort group_id = createGroupFS(user_login,true);

                User user = new User((ushort)(owner_id+1), group_id, user_login.ToCharArray(), password, role);

                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    superblock.amount_of_users++;

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 
                        superblock.users_offset + (superblock.amount_of_users - 1) * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                    user.binaryWritingToFile(writer);
                    
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                    superblock.binaryWritingToFile(writer);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception happened: "+e);
            }
        }



        //Удаление пользователя системы
        public void deleteUserFS(ushort owner_id, ushort group_id, string user_login, string password, bool role = false)
        {
            
        }


        //Создание группы пользователей
        public ushort createGroupFS(string group_name,bool isForCreatingUser)
        {
            try
            {
                int group_id = -1;

                if (superblock.amount_of_groups != 0)
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                    {
                        reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.groups_offset+ (superblock.amount_of_groups-1) * Superblock.OS_GROUP_INFO_SIZE), SeekOrigin.Current);

                        Group last_group = Group.loadGroupFromBinaryFile(reader);

                        group_id = last_group.ID_group;
                    }
                }

                Group group = new Group((ushort)(group_id+1), group_name.ToCharArray());

                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {

                    superblock.amount_of_groups++;

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                        superblock.groups_offset + (superblock.amount_of_groups-1) * Superblock.OS_GROUP_INFO_SIZE), SeekOrigin.Current);

                    group.binaryWritingToFile(writer);
                    

                    if (!isForCreatingUser)
                    {
                        writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                        superblock.binaryWritingToFile(writer);
                    }
                }
                return (ushort)(group_id+1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception happened: " + e);
                return 0;
            }
        }


    }
}
