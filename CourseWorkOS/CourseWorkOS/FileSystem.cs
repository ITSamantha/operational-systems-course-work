using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public bool createFile(char[] file_name, char[] extention, byte[] bytes,AccessRules rules)//ПРОДУМАТЬ ИЗМЕНЕНИЕ ФАЙЛА
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

                int[] ID_clusters;

                byte[] new_files_bytes;

                int cluster_number = (int)Math.Ceiling(((double)bytes.Length / (double)superblock.cluster_size));

                if (cluster_number > 10)
                {
                    //MessageBox.Show("Размер файла слишком большой. Невозможно записать.");
                    return false;
                }

                getFreeClustersAddressesAndBytes(cluster_number,out ID_clusters,out new_files_bytes);
                
                setStateOfClustersInBitmap(ID_clusters,  true, new_files_bytes);
                
                uint ID_inode;

                byte inode_byte;
                
                getFreeInodeId(out ID_inode,out inode_byte);

                setStateOfInodeInBitmap(ID_inode, true, inode_byte);
                
                Inode inode = new Inode(user.ID_owner, user.ID_group, rules.getAccessRulesForFile(), (uint)bytes.Length, (uint)cluster_number,
                    Converter.getSeconds(DateTime.Now), Converter.getSeconds(DateTime.Now), ID_clusters);//Обрати внимание на даты!!!
                
                Cluster[] clusters = getClusterArrFromBytesArr(bytes, (ushort)cluster_number);

                RootCatalogRow root = new RootCatalogRow(file_name, extention, ID_inode);
                
                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    superblock.binaryWritingToFile(writer);

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.ilist_offset + ID_inode*Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                    inode.binaryWritingToFile(writer);

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.root_offset + (superblock.amount_of_inodes-superblock.amount_of_free_inodes)* Superblock.OS_ROOT_ROW_SIZE), SeekOrigin.Current);

                    root.binaryWritingToFile(writer);

                    superblock.amount_of_free_inodes--;

                    superblock.amount_of_free_clusters -= (uint)ID_clusters.Length;

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                    superblock.binaryWritingToFile(writer);
                    
                    for (int i = 0; i < ID_clusters.Length; i++)
                    {
                        writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.data_offset + ID_clusters[i] * superblock.cluster_size), SeekOrigin.Current);

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
                MessageBox.Show("Такого файла не существует.");
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
        public void getFreeInodeId(out uint ID_inode, out byte inode_byte)
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
                            ID_inode = (uint)(i * 8 + j);
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
        public bool setStateOfInodeInBitmap(uint inode_id, bool isBusy, byte inode_byte)
        {
            try
            {
                BitArray bits = new BitArray((new byte[] { inode_byte }));

                uint byte_number = inode_id / 8;

                uint position = inode_id % 8;

                bits[(int)(7 - position)] = isBusy;

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
        public void deleteUserFS(ushort UID)
        {
            var users = getUsersArray();

            int position = 0;

            if(users!= null)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i].ID_owner == UID)
                        {
                            superblock.amount_of_users--;
                        }
                        else
                        {
                            writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                            superblock.users_offset + position * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);
                            users[i].binaryWritingToFile(writer);
                            position++;
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Список пользователей пуст.");
            }
        }

        public RootCatalogRow[] getAllRootCatalogRows()
        {
            var amount_of_files = superblock.amount_of_inodes - superblock.amount_of_free_inodes;

            var root_catalog_rows = new RootCatalogRow[amount_of_files];

            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.root_offset), SeekOrigin.Current);

                for (int i = 0; i < amount_of_files; i++)
                {
                    root_catalog_rows[i] = RootCatalogRow.loadRootRowFromBinaryFile(reader);
                }
            }
            
            return root_catalog_rows;
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

        /*public RootCatalogRow isBusyName(string old_file, string old_extention, string new_file, string new_extention)
        {

        }*/

        //Проверка, есть ли файл с таким именем
        public bool checkIfTheSameFileNames(string new_file_name)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {

                var amount_of_files = superblock.amount_of_inodes - superblock.amount_of_free_inodes;

                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                    superblock.root_offset), SeekOrigin.Current);

                for (short i = 0; i < amount_of_files; i++)
                {
                    var root_row = RootCatalogRow.loadRootRowFromBinaryFile(reader);

                    if (new_file_name == RootCatalogRow.createFileName(root_row))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        //Переименование файла
        public int renameFile(string old_name,string new_name,bool isWithExtention)
        {
            int position = -1;

            //!!!!!Проверка прав доступа
            
            if (checkIfTheSameFileNames(new_name)||old_name == new_name)
            {
                MessageBox.Show($"Файл с именем {new_name} уже существует или было введено идентичное имя файла.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return position;
            }

            RootCatalogRow root_row;

            findExactFile(old_name,out position,out root_row);
            
            root_row = new RootCatalogRow(isWithExtention ? new_name.Split('.')[0].ToCharArray() : new_name.ToCharArray(),
                isWithExtention ? new_name.Split('.')[1].ToCharArray() : new char[0], root_row.inode_number);

            if (position != -1)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                         superblock.root_offset + position * Superblock.OS_ROOT_ROW_SIZE), SeekOrigin.Current);

                    root_row.binaryWritingToFile(writer);
                }
            }
            else
            {
                MessageBox.Show("Данный файл не найден.");
            }
            return position;
        }

        //Найти файл в корневом каталоге
        public void findExactFile(string file,out int position, out RootCatalogRow root)
        {
            root = new RootCatalogRow();

            position = -1;

            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {

                var amount_of_files = superblock.amount_of_inodes - superblock.amount_of_free_inodes;

                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                    superblock.root_offset), SeekOrigin.Current);

                for (short i = 0; i < amount_of_files; i++)
                {
                    root= RootCatalogRow.loadRootRowFromBinaryFile(reader);

                    if (file == RootCatalogRow.createFileName(root))
                    {
                        position = i;

                        break;
                    }
                }
            }
        }
        
        public Inode getInodeByNumber(uint number)
        {
            Inode inode;
            //Проверка на пустоту!!!
            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                    superblock.ilist_offset + number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                inode = Inode.loadInodeFromBinaryFile(reader);
            }
                return inode;
        }

        public void copyFile(string file_name ,bool isWithExtention)
        {
            Inode inode;

            RootCatalogRow root;

            int position;

            byte[] bytes;

            findExactFile(file_name, out position, out root);

            //Проверка ,занят ли айнод?

            //Проверка на существование такого же файла с тем же названием!
            position = 0;

            using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
            {
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                    superblock.ilist_offset + root.inode_number*Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                inode = Inode.loadInodeFromBinaryFile(reader);

                bytes = new byte[inode.size_in_bytes];

                for(int i = 0; i < inode.addr.Length; i++)
                {
                    if (inode.addr[i] != -1)
                    {
                        reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                    superblock.data_offset + inode.addr[i] * superblock.cluster_size), SeekOrigin.Current);

                        Cluster cluster = Cluster.loadClusterFromBinaryFile(reader, superblock.cluster_size);

                        for (int j = 0; j < superblock.cluster_size; j++)
                        {
                            if (position >= inode.size_in_bytes)
                            {
                                break;
                            }
                            bytes[position] = cluster.bytes[j];
                            position++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            //ПРОВЕРКА НА ВМЕСТИМОСТЬ ИМЕНИ ПРИ ДОБАВЛЕНИИ COPY
            createFile(isWithExtention ? $"{file_name.Split('.')[0]}_copy".ToCharArray() : $"{file_name}_copy".ToCharArray(),
                isWithExtention ? file_name.Split('.')[1].ToCharArray() : new char[0], bytes,new AccessRules(inode.access_rules));
        }

        public void deleteFile(string file_name)
        {

        }
    }
}
