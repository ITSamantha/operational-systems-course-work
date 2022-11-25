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
    public class FileSystem
    {
        public const string SYSTEM_FILE_NAME = "data.bin";

        public const byte MAX_CLUSTER_AMOUNT = 10;

        public Superblock superblock;

        public User user = new User();

        public FileStream file_stream;

        //Константы

        public const byte WRITE_END_FILE = 0;

        public const byte DELETE_FILE = 0;

        public const byte CHANGE_ACCESS = 1;

        public const byte RENAME_FILE = 2;

        public const byte COPY_FILE = 3;

        //Создать ФС
        public void createFileSystem(ushort cluster_size = 512, uint fs_size = 4294967295)
        {
            try { File.Delete(SYSTEM_FILE_NAME); }
            catch (Exception e) { }
            if (file_stream == null)
            {
                this.file_stream = new FileStream(SYSTEM_FILE_NAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);

                file_stream.SetLength(fs_size);
            }
            
            superblock = new Superblock(fs_size, cluster_size);

            uint bit_size = (uint)Math.Ceiling((double)superblock.amount_of_inodes / 8);

            byte[] cluster_bitmap = new byte[bit_size];

            byte[] inode_bitmap = new byte[bit_size];

            BinaryWriter writer = new BinaryWriter(file_stream);

            writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                0), SeekOrigin.Current);

            superblock.binaryWritingToFile(writer);

            writer.Write(cluster_bitmap);

            writer.Write(inode_bitmap);

            this.file_stream.Close();

            this.file_stream = new FileStream(SYSTEM_FILE_NAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }

        //Загрузить ФС из файла
        public bool loadFileSystemFromFile()
        {
            if (file_stream == null)
            {
                this.file_stream = new FileStream(SYSTEM_FILE_NAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }

            try
            {
                BinaryReader reader = new BinaryReader(file_stream);
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                   0), SeekOrigin.Current);
                superblock = Superblock.loadSuperblockFromBinaryFile(reader);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception happened: " + e);
                return false;
            }
        }

        //Создание файла
        public bool createFile(char[] file_name, char[] extention, byte[] bytes, AccessRules rules)
        {
            try
            {
                if (checkIfTheSameFileNames(RootCatalogRow.createFileName(new RootCatalogRow(file_name, extention, 0))))
                {
                    MessageBox.Show("Файл с таким именем существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (superblock.amount_of_free_clusters == 0)
                {
                    Console.Write("Все кластера заняты.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (superblock.amount_of_free_inodes == 0)
                {
                    Console.Write("Все индексные дескрипторы заняты.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int[] ID_clusters;

                byte[] new_files_bytes;

                int cluster_number = bytes.Length == 0 ? 1 : (int)Math.Ceiling(((double)bytes.Length / (double)superblock.cluster_size));

                if (cluster_number > MAX_CLUSTER_AMOUNT)
                {
                    MessageBox.Show("Размер файла слишком большой. Невозможно записать.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                getFreeClustersAddressesAndBytes(cluster_number, out ID_clusters, out new_files_bytes);

                setStateOfClustersInBitmap(ID_clusters, true, new_files_bytes);

                uint ID_inode;

                byte inode_byte;

                getFreeInodeId(out ID_inode, out inode_byte);

                setStateOfInodeInBitmap(ID_inode, true, inode_byte);

                Inode inode = new Inode(user.ID_owner, user.ID_group, rules.getAccessRulesForFile(), (uint)bytes.Length, (uint)cluster_number,
                    Converter.getSeconds(DateTime.Now), Converter.getSeconds(DateTime.Now), ID_clusters);

                Cluster[] clusters = getClusterArrFromBytesArr(bytes, (ushort)cluster_number);

                RootCatalogRow root = new RootCatalogRow(file_name, extention, ID_inode);

                BinaryWriter writer = new BinaryWriter(file_stream);

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.ilist_offset + ID_inode * Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                inode.binaryWritingToFile(writer);

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                        superblock.root_offset + (superblock.amount_of_inodes - superblock.amount_of_free_inodes) * Superblock.OS_ROOT_ROW_SIZE), SeekOrigin.Current);

                root.binaryWritingToFile(writer);

                superblock.amount_of_free_inodes--;

                superblock.amount_of_free_clusters -= (uint)ID_clusters.Length;

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                for (int i = 0; i < ID_clusters.Length; i++)
                {
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                            superblock.data_offset + ID_clusters[i] * superblock.cluster_size), SeekOrigin.Current);

                    clusters[i].binaryWritingToFile(writer);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception:" + e);
                return false;
            }
        }

        //Отобразить файл ДОДЕЛАТЬ ПРАВА
        public byte[] readFile(string file_name)
        {
            var roots = getAllRootCatalogRows();

            int inode_num = -1;

            byte[] bytes = new byte[0];

            for (int i = 0; i < roots.Length; i++)
            {
                if (RootCatalogRow.createFileName(roots[i]).SequenceEqual(file_name))
                {
                    inode_num = (int)roots[i].inode_number;
                }
            }

            if (inode_num != -1)
            {
                var inode = getInodeByNumber((uint)inode_num);

                Cluster[] clusters = new Cluster[inode.size_in_clusters];

                BinaryReader reader = new BinaryReader(file_stream);
                for (int i = 0; i < clusters.Length; i++)
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                    superblock.data_offset + superblock.cluster_size * inode.addr[i]), SeekOrigin.Current);

                    clusters[i] = Cluster.loadClusterFromBinaryFile(reader, superblock.cluster_size);
                }
                int position = 0;

                bytes = new byte[inode.size_in_bytes];

                for (int i = 0; i < clusters.Length; i++)
                {
                    for (int j = 0; j < superblock.cluster_size; j++)
                    {
                        if (position >= inode.size_in_bytes)
                        {
                            break;
                        }
                        bytes[position] = clusters[i].bytes[j];
                        position++;
                    }

                }
            }
            return bytes;
        }

        //Изменение файла, зная номер айнода ДОДЕЛАТЬ
        public void editFileWithInode(uint inode_number, byte[] new_bytes)
        {
            if (isInodeBusy(inode_number, true))
            {
                BinaryReader reader = new BinaryReader(file_stream);
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.ilist_offset + Superblock.OS_INODE_SIZE * inode_number), SeekOrigin.Current);

                Inode inode = Inode.loadInodeFromBinaryFile(reader);

                //setStateOfClustersInBitmap()

                //createFile()
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
                BinaryReader reader = new BinaryReader(file_stream);
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.users_offset), SeekOrigin.Current);

                for (int i = 0; i < superblock.amount_of_users; i++)
                {
                    users[i] = User.loadUserFromBinaryFile(reader);
                }

                return users;
            }
            return null;

        }

        //Получить список всех групп
        public Group[] getGroupsArray()
        {
            if (superblock.amount_of_groups != 0)
            {
                Group[] groups = new Group[superblock.amount_of_groups];
                BinaryReader reader = new BinaryReader(file_stream);
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.groups_offset), SeekOrigin.Current);

                for (int i = 0; i < superblock.amount_of_groups; i++)
                {
                    groups[i] = Group.loadGroupFromBinaryFile(reader);
                }
                return groups;
            }
            return null;

        }

        //Получить массив кластеров из массива байтов
        public Cluster[] getClusterArrFromBytesArr(byte[] bytes, ushort cluster_number)
        {
            Cluster[] clusters = new Cluster[cluster_number];

            for (int i = 0; i < cluster_number; i++)
            {
                clusters[i] = new Cluster(superblock.cluster_size);
            }

            if (bytes.Length == 0)
            {
                return clusters;
            }

            int offset = 0;

            for (int i = 0; i < cluster_number; i++)
            {
                clusters[i].bytes = new byte[superblock.cluster_size];

                for (int j = 0; j < superblock.cluster_size; j++)
                {
                    if (offset >= bytes.Length)
                    {
                        break;
                    }

                    clusters[i].bytes[j] = bytes[offset];
                    offset++;
                }

            }
            return clusters;
        }

        //Получение адресов и байтов кластеров для файла
        public void getFreeClustersAddressesAndBytes(int number, out int[] clusters, out byte[] bytes)
        {
            clusters = new int[number];

            bytes = new byte[number];

            int index = 0;

            BinaryReader reader = new BinaryReader(file_stream);
            reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, superblock.cluster_bitmap_offset), SeekOrigin.Current);

            for (int i = 0; i < superblock.amount_of_inodes; i++)
            {
                byte b = reader.ReadByte();

                BitArray bits = new BitArray((new byte[] { b }));

                for (int j = 0; j < bits.Length; j++)
                {
                    if (index != number)
                    {
                        if (!bits[7 - j])
                        {
                            clusters[index] = i * 8 + j;
                            bytes[index] = b;
                            index++;
                        }
                    }
                    else { return; }
                }

            }
        }

        //Установка значений битов в битовой карте кластеров
        public bool setStateOfClustersInBitmap(int[] clusters, bool isBusy, byte[] bytes)
        {
            try
            {
                for (int i = 0; i < clusters.Length;)
                {
                    int temp_j = 0;

                    int cluster_number = 0;

                    BitArray bits = new BitArray((new byte[] { bytes[i] }));

                    cluster_number = clusters[i] / 8;

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
                    BinaryWriter writer = new BinaryWriter(file_stream);
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                            superblock.cluster_bitmap_offset + cluster_number), SeekOrigin.Current);

                    byte[] new_byte = new byte[1];

                    bits.CopyTo(new_byte, 0);

                    writer.Write(new_byte);

                    i += temp_j;
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
            BinaryReader reader = new BinaryReader(file_stream);
            reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position, superblock.inode_bitmap_offset), SeekOrigin.Current);

            for (int i = 0; i < superblock.amount_of_inodes; i++)
            {
                byte b = reader.ReadByte();

                BitArray bits = new BitArray((new byte[] { b }));

                for (int j = 0; j < bits.Length; j++)
                {
                    if (!bits[7 - j])
                    {
                        ID_inode = (uint)(i * 8 + j);
                        inode_byte = b;
                        return;
                    }
                }
            }
        }

        //Функция проверки занят/свободен inode
        public bool isInodeBusy(uint inode_number, bool isBusy)
        {
            try
            {
                BinaryReader reader = new BinaryReader(file_stream);
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.inode_bitmap_offset + inode_number / 8), SeekOrigin.Current);

                byte b = reader.ReadByte();

                BitArray bits = new BitArray((new byte[] { b }));

                for (int j = 0; j < bits.Length; j++)
                {
                    if (j == (7 - inode_number % 8))
                    {
                        return bits[j] == isBusy;
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

        //Установка значений битов в битовой карте inode
        public bool setStateOfInodeInBitmap(uint inode_id, bool isBusy, byte inode_byte)
        {
            try
            {
                BitArray bits = new BitArray((new byte[] { inode_byte }));

                uint byte_number = inode_id / 8;

                uint position = inode_id % 8;

                bits[(int)(7 - position)] = isBusy;

                BinaryWriter writer = new BinaryWriter(file_stream);

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.inode_bitmap_offset + byte_number), SeekOrigin.Current);

                byte[] new_byte = new byte[1];

                bits.CopyTo(new_byte, 0);

                writer.Write(new_byte);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:" + e);
                return false;
            }
        }

        //Получение всех файлов системы
        public RootCatalogRow[] getAllRootCatalogRows()
        {
            var amount_of_files = superblock.amount_of_inodes - superblock.amount_of_free_inodes;

            var root_catalog_rows = new RootCatalogRow[amount_of_files];

            BinaryReader reader = new BinaryReader(file_stream);
            reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.root_offset), SeekOrigin.Current);

            for (int i = 0; i < amount_of_files; i++)
            {
                root_catalog_rows[i] = RootCatalogRow.loadRootRowFromBinaryFile(reader);
            }

            return root_catalog_rows;
        }

        public long calculateWhereToCome(long current_position, long next_position) => next_position - current_position;
        
        //Проверка, есть ли файл с таким именем
        public bool checkIfTheSameFileNames(string new_file_name)
        {
            BinaryReader reader = new BinaryReader(file_stream);
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
            return false;
        }

        //Смена прав доступа
        public bool changeAccessRules(uint inode_number, Inode inode)
        {
            //Менять права доступа могут только администратор и владелец
            if (!checkRules(CHANGE_ACCESS, null, inode))
            {
                MessageBox.Show("Для смены прав доступа файла Вам необходимо быть администратором или владельцем файла.", "Error");
                return false;
            }

            try
            {
                BinaryWriter writer = new BinaryWriter(file_stream);
                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                         superblock.ilist_offset + inode_number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);
                inode.binaryWritingToFile(writer);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Что-то пошло не так при записи новых прав доступа.");
                return false;
            }
        }

        //Переименование файла. Переименование файла осуществляется при наличии прав x
        public int renameFile(int position, RootCatalogRow root_row, Inode inode, string _base, string _ext)
        {
            AccessRules access = new AccessRules(inode.access_rules);

            if (checkRules(RENAME_FILE, access, inode))
            {

                if (checkIfTheSameFileNames($"{_base}{_ext}"))
                {
                    MessageBox.Show($"Файл с именем {_base}{_ext} уже существует или было введено идентичное имя файла.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return -1;
                }

                root_row = new RootCatalogRow(_base.ToCharArray(), _ext.ToCharArray(), root_row.inode_number);

                if (position != -1)
                {
                    BinaryWriter writer = new BinaryWriter(file_stream);
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                             superblock.root_offset + position * Superblock.OS_ROOT_ROW_SIZE), SeekOrigin.Current);

                    root_row.binaryWritingToFile(writer);
                }
                else
                {
                    MessageBox.Show("Данный файл не найден.");
                }
            }
            else
            {
                MessageBox.Show("Права доступа на файл не позволяют выполнить данные действия. " +
                    "Для переименования у Вас должны быть права на x. Возможно, файл имеет атрибут \"Только чтение\"", "Error");
                position = -1;
            }
            return position;
        }

        //Получить inode по номеру
        public Inode getInodeByNumber(uint number)
        {
            Inode inode;
            try
            {
                BinaryReader reader = new BinaryReader(file_stream);
                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.ilist_offset + number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);
                inode = Inode.loadInodeFromBinaryFile(reader);
                return inode;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Копирование файла. Для копирования необходимы права на чтение
        public void copyFile(string _ext, string _base, string old_name)
        {
            if (checkIfTheSameFileNames($"{_base}{_ext}"))
            {
                MessageBox.Show("Такой файл уже существует!");
                return;
            }

            RootCatalogRow root = findRootRowByName(old_name);

            byte[] bytes;

            var inode = getInodeByNumber(root.inode_number);

            if (inode == null)
            {
                MessageBox.Show("Что-то пошло не так при получении дескриптора");
                return;
            }

            AccessRules access = new AccessRules(inode.access_rules);

            if (checkRules(COPY_FILE, access, inode))
            {

                var position = 0;

                BinaryReader reader = new BinaryReader(file_stream);

                bytes = new byte[inode.size_in_bytes];

                for (int i = 0; i < inode.addr.Length; i++)
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

                createFile(_base.ToCharArray(), _ext.ToCharArray(), bytes, new AccessRules(inode.access_rules));
            }
            else
            {
                MessageBox.Show("У Вас нет прав для выполнения данной операции");
            }
        }

        //Удаление файла
        public bool deleteFile(string file_name)
        {
            var roots = getAllRootCatalogRows();

            Inode inode = null;

            int inode_id = -1;

            for (int i = 0; i < roots.Length; i++)
            {
                if (RootCatalogRow.createFileName(roots[i]).SequenceEqual(file_name))
                {
                    inode = getInodeByNumber(roots[i].inode_number);
                    inode_id = (int)roots[i].inode_number;
                    break;
                }
            }

            if (inode == null)
            {
                MessageBox.Show("Такой индексный дескриптор не существует.");
                return false;
            }

            AccessRules access = new AccessRules(inode.access_rules);

            if (checkRules(DELETE_FILE, access, inode))
            {
                BinaryWriter writer = new BinaryWriter(file_stream);

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                            superblock.root_offset), SeekOrigin.Current);

                for (int i = 0; i < roots.Length; i++)
                {
                    if (RootCatalogRow.createFileName(roots[i]) == file_name)
                    {
                        continue;
                    }
                    roots[i].binaryWritingToFile(writer);
                }

                BinaryReader reader = new BinaryReader(file_stream);

                reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.inode_bitmap_offset + inode_id / 8), SeekOrigin.Current);

                setStateOfInodeInBitmap((uint)inode_id, false, reader.ReadByte());

                int[] clusters = new int[inode.size_in_clusters];

                byte[] bytes = new byte[inode.size_in_clusters];

                for (int i = 0; i < inode.size_in_clusters; i++)
                {
                    clusters[i] = inode.addr[i];

                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.cluster_bitmap_offset + clusters[i] / 8), SeekOrigin.Current);

                    bytes[i] = reader.ReadByte();
                }

                setStateOfClustersInBitmap(clusters, false, bytes);

                superblock.amount_of_free_inodes++;

                superblock.amount_of_free_clusters += (uint)clusters.Length;

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                            0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                return true;

            }
            else
            {
                MessageBox.Show("Ваши правв доступа не позволяют это сделать. Для удаления файла необходимы права на запись w.");
            }

            return false;
        }

        //Дописать в конец файла РАЗБЕРИСЬ
        public bool writeEndFile(string file_name, byte[] new_bytes)
        {
            var root = findRootRowByName(file_name);

            var inode = getInodeByNumber(root.inode_number);

            AccessRules access = new AccessRules(inode.access_rules);

            if (checkRules(WRITE_END_FILE, access, inode))
            {
                long bytes_in_last_cluster = superblock.cluster_size * inode.size_in_clusters - inode.size_in_bytes;//Свободные байты в последнем кластере

                int cluster_number = bytes_in_last_cluster < new_bytes.Length ? 
                    (int)Math.Ceiling(((double)new_bytes.Length / (double)superblock.cluster_size)) : (int)Math.Floor(((double)new_bytes.Length / (double)superblock.cluster_size));

                if (inode.size_in_clusters + cluster_number > MAX_CLUSTER_AMOUNT)
                {
                    MessageBox.Show("Размер данных слишком большой. Невозможно записать.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (superblock.amount_of_free_clusters < cluster_number)
                {
                    Console.Write("Кластеров для записи такого количества информации не хватит.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var position = 0;

                BinaryReader reader = new BinaryReader(file_stream);
                BinaryWriter writer = new BinaryWriter(file_stream);

                if (bytes_in_last_cluster != 0)
                {
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                        superblock.data_offset + superblock.cluster_size * inode.addr[inode.size_in_clusters - 1]), SeekOrigin.Current);

                    var cluster = Cluster.loadClusterFromBinaryFile(reader, superblock.cluster_size);

                    for (int i = 0; i < bytes_in_last_cluster; i++)
                    {
                        if (i >= new_bytes.Length) { break; }
                        cluster.bytes[superblock.cluster_size - bytes_in_last_cluster + i] = new_bytes[i];
                        position++;
                    }

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                        superblock.data_offset + superblock.cluster_size * inode.addr[inode.size_in_clusters - 1]), SeekOrigin.Current);

                    cluster.binaryWritingToFile(writer);
                }

                int[] ID_clusters = null;

                byte[] new_files_bytes;

                if (cluster_number != 0)
                {
                    getFreeClustersAddressesAndBytes(cluster_number, out ID_clusters, out new_files_bytes);

                    setStateOfClustersInBitmap(ID_clusters, true, new_files_bytes);
                }
                else
                {
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.ilist_offset + root.inode_number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                    inode = formChangesInode(inode, (uint)cluster_number, (uint)new_bytes.Length, ID_clusters);

                    inode.binaryWritingToFile(writer);

                    return true;
                }

                //ТУТ ЧТО-ТО НЕ ТАК
                long new_size = bytes_in_last_cluster >= new_bytes.Length ? bytes_in_last_cluster - new_bytes.Length : new_bytes.Length - bytes_in_last_cluster;
                byte[] bytes2 = new byte[new_size];
                Array.Copy(new_bytes, bytes_in_last_cluster, bytes2, 0, new_size);

                Cluster[] clusters = getClusterArrFromBytesArr(bytes2, (ushort)cluster_number);

                superblock.amount_of_free_clusters -= (uint)cluster_number;

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                for (int i = 0; i < ID_clusters.Length; i++)
                {
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                                 superblock.data_offset + ID_clusters[i] * superblock.cluster_size), SeekOrigin.Current);

                    clusters[i].binaryWritingToFile(writer);
                }

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.ilist_offset + root.inode_number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                inode = formChangesInode(inode, (uint)cluster_number, (uint)new_bytes.Length, ID_clusters);

                inode.binaryWritingToFile(writer);

                return true;
            }
            else
            {
                MessageBox.Show("Ваши права не позволяют провести операцию. Для дозаписи необходимо иметь права на w. Возможно файл имеет атрибут read_only", "Error");
                return false;
            }
        }

        public Inode formChangesInode(Inode inode, uint cluster_number, uint new_bytes_length, int[] ID_clusters)
        {
            if (ID_clusters != null)
            {
                for (int i = 0; i < cluster_number; i++)
                {
                    inode.addr[inode.size_in_clusters + i] = ID_clusters[i];
                }
            }
            inode.size_in_clusters += (uint)cluster_number;

            inode.size_in_bytes += new_bytes_length;

            inode.datetime_of_last_modification = Converter.getSeconds(DateTime.Now);

            return inode;
        }

        public bool checkRules(byte operation, AccessRules access, Inode inode)
        {
            bool isRules = true;

            switch (operation)
            {
                case WRITE_END_FILE:
                    {
                        if (!user.user_role)
                        {
                            if (!access.read_only_file)
                            {
                                if (user.ID_owner == inode.ID_owner)
                                {
                                    isRules = access.w_u ? true : false;
                                }
                                else
                                {
                                    if (user.ID_group == inode.ID_group)
                                    {
                                        isRules = access.w_g ? true : false;
                                    }
                                    else
                                    {
                                        isRules = access.w_o ? true : false;
                                    }
                                }
                            }
                            else
                            {
                                isRules = false;
                            }
                        }

                        break;
                    }

                case CHANGE_ACCESS:
                    {
                        if (user.ID_owner != inode.ID_owner && !user.user_role)
                        {
                            isRules = false;
                        }
                        break;
                    }
                case RENAME_FILE:
                    {
                        if (!user.user_role)//Если не администратор
                        {
                            if (access.read_only_file)//Если только для чтения
                            {
                                isRules = false;
                            }
                            else
                            {
                                //Если x == true, тогда можно
                                if (inode.ID_owner == user.ID_owner)//Если текущий user - владелец файла
                                {
                                    isRules = !access.x_u ? false : true;
                                }
                                else
                                {
                                    if (inode.ID_group == user.ID_group)//Если user в группе владельца
                                    {
                                        isRules = !access.x_g ? false : true;
                                    }
                                    else//Иначе остальные
                                    {
                                        isRules = !access.x_o ? false : true;
                                    }
                                }

                            }
                        }
                        break;
                    }
                case COPY_FILE:
                    {
                        if (!user.user_role)//Если read_only, то можно
                        {
                            if (user.ID_owner == inode.ID_owner)
                            {
                                isRules = access.r_u ? true : false;
                            }
                            else
                            {
                                if (user.ID_group == inode.ID_group)
                                {
                                    isRules = access.r_g ? true : false;
                                }
                                else
                                {
                                    isRules = access.r_o ? true : false;
                                }
                            }

                        }
                        break;
                    }
            }
            return isRules;
        }

        public RootCatalogRow findRootRowByName(string file_name)
        {
            var roots = getAllRootCatalogRows();

            for (int i = 0; i < roots.Length; i++)
            {
                if (RootCatalogRow.createFileName(roots[i]).SequenceEqual(file_name))
                {
                    return roots[i];
                }
            }
            return null;
        }

        public int findRootPosition(string file_name)
        {
            var roots = getAllRootCatalogRows();

            for (int i = 0; i < roots.Length; i++)
            {
                if (RootCatalogRow.createFileName(roots[i]).SequenceEqual(file_name))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool editFile(string file_name, byte[] new_bytes)
        {
            var root = findRootRowByName(file_name);

            var inode = getInodeByNumber(root.inode_number);

            AccessRules access = new AccessRules(inode.access_rules);

            if (checkRules(WRITE_END_FILE, access, inode))
            {
                int cluster_number = new_bytes.Length == 0 ? 1 : (int)Math.Ceiling(((double)new_bytes.Length / (double)superblock.cluster_size));

                if (cluster_number > MAX_CLUSTER_AMOUNT)
                {
                    MessageBox.Show("Размер данных слишком большой. Невозможно записать.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (superblock.amount_of_free_clusters < cluster_number)
                {
                    Console.Write("Кластеров для записи такого количества информации не хватит.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var position = 0;

                BinaryReader reader = new BinaryReader(file_stream);
                BinaryWriter writer = new BinaryWriter(file_stream);


                int[] ID_clusters = null;

                byte[] new_files_bytes;

                getFreeClustersAddressesAndBytes(cluster_number, out ID_clusters, out new_files_bytes);

                setStateOfClustersInBitmap(ID_clusters, true, new_files_bytes);



                Cluster[] clusters = getClusterArrFromBytesArr(new_bytes, (ushort)cluster_number);

                superblock.amount_of_free_clusters -= (uint)cluster_number;

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                for (int i = 0; i < ID_clusters.Length; i++)
                {
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                                 superblock.data_offset + ID_clusters[i] * superblock.cluster_size), SeekOrigin.Current);

                    clusters[i].binaryWritingToFile(writer);
                }

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.ilist_offset + root.inode_number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);

                inode = formChangesInode(inode, (uint)cluster_number, (uint)new_bytes.Length, ID_clusters);

                inode.binaryWritingToFile(writer);

                return true;
            }
            else
            {
                MessageBox.Show("Ваши права не позволяют провести операцию. Для дозаписи необходимо иметь права на w. Возможно файл имеет атрибут read_only", "Error");
                return false;
            }
        }

        //При передаче прав или удалении пользователя, файлы переходят к админу
        public void giveAllFilesToAdmin(ushort old_user_id)
        {
            var roots = getAllRootCatalogRows();

            var admin = getAdmin();

            BinaryWriter writer = new BinaryWriter(file_stream);

            if (roots != null)
            {
                for (int i = 0; i < roots.Length; i++)
                {
                    var inode = getInodeByNumber(roots[i].inode_number);

                    if (inode.ID_owner == old_user_id)
                    {
                        inode.ID_owner = admin.ID_owner;
                        inode.ID_group = admin.ID_group;

                        writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                            superblock.ilist_offset + roots[i].inode_number * Superblock.OS_INODE_SIZE), SeekOrigin.Current);
                        inode.binaryWritingToFile(writer);
                    }
                }
            }
        }



        /*Работа с пользователями*/
        
        //Забрать или дать права администратора
        public void setAdmin(string user_login,bool isAdmin)
        {
            BinaryWriter writer = new BinaryWriter(file_stream);

            var users = getUsersArray();

            var temp_user = new User(user_login.ToCharArray());

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].user_login.SequenceEqual(temp_user.user_login))
                {
                    users[i].user_role = isAdmin;

                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                        superblock.users_offset + i * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                    users[i].binaryWritingToFile(writer);

                    break;
                }
            }
        }

        //Создание пользователя системы
        public User createUserFS(string user_login, string password,ushort group_id, bool role = false)
        {
            try
            {
                int owner_id = -1;

                if (superblock.amount_of_users != 0)
                {
                    BinaryReader reader = new BinaryReader(file_stream);
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.users_offset + (superblock.amount_of_users - 1) * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                    User last_user = User.loadUserFromBinaryFile(reader);

                    owner_id = last_user.ID_owner;
                }
                
                User user = new User((ushort)(owner_id + 1), group_id, user_login.ToCharArray(), password, role);

                BinaryWriter writer = new BinaryWriter(file_stream);
                superblock.amount_of_users++;

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                    superblock.users_offset + (superblock.amount_of_users - 1) * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                user.binaryWritingToFile(writer);

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception happened: " + e);
                return null;
            }
        }

        //Удаление пользователя системы
        public void deleteUserFS(ushort UID)
        {
            var users = getUsersArray();

            int position = 0;

            BinaryWriter writer = new BinaryWriter(file_stream);
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
            writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);
            superblock.binaryWritingToFile(writer);
        }

        //Смена пользователя
        public void changeUser(User user)
        {
            this.user = user;
        }

        //Возвращает объект User с заданным именем
        public User getUserByName(string user_name)
        {
            var temp_user = new User(user_name.ToCharArray());

            foreach(var user in getUsersArray())
            {
                if (user.user_login.SequenceEqual(temp_user.user_login))
                {
                    return user;
                }
            }
            return null;
        }

        //Проверяет всех пользователей на наличие такого логина
        public bool checkIfTheSameLogin(string login)
        {
            User temp_user = new User(login.ToCharArray());

            var users = getUsersArray();

            if (users != null)
            {
                foreach (var user in users)
                {
                    if (user.user_login.SequenceEqual(temp_user.user_login))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Найти позицию пользователя в таблице пользователей
        public int getUserPosition(string user_name)
        {
            var temp_user = new User(user_name.ToCharArray());

            var users = getUsersArray();

            if (users != null)
            {
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i].user_login.SequenceEqual(temp_user.user_login))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public User getAdmin()
        {
            var users =getUsersArray();
            
            if (users != null)
            {
                foreach(var user in users)
                {
                    if (user.user_role)
                    {
                        return user;
                    }
                }
            }
            return null;
        }



        /*Работа с группами*/

        //Получить ID по названию
        public int getGUID(string group_name)
        {
            var temp_group = new Group(0, group_name.ToCharArray());

            foreach(var group in getGroupsArray())
            {
                if (group.group_name.SequenceEqual(temp_group.group_name))
                {
                    return group.ID_group;
                }
            }
            return -1;
        }

        //Существует ли такая группа
        public bool checkIfTheSameGroupNames(string group_name)
        {
            Group temp_group = new Group(0, group_name.ToCharArray());
            var groups = getGroupsArray();
            if(groups!= null)
            {
                foreach (var group in groups)
                {
                    if (group.group_name.SequenceEqual(temp_group.group_name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Создание группы пользователей
        public int createGroupFS(string group_name)
        {
            if (superblock.amount_of_groups == superblock.max_amount_of_groups)
            {
                MessageBox.Show("Максимальное количество групп достигнуто.");

                return -1;
            }

            try
            {
                int group_id = -1;

                if (superblock.amount_of_groups != 0)
                {
                    BinaryReader reader = new BinaryReader(file_stream);
                    reader.BaseStream.Seek(calculateWhereToCome(reader.BaseStream.Position,
                            superblock.groups_offset + (superblock.amount_of_groups - 1) * Superblock.OS_GROUP_INFO_SIZE), SeekOrigin.Current);

                    Group last_group = Group.loadGroupFromBinaryFile(reader);

                    group_id = last_group.ID_group;
                }

                Group group = new Group((ushort)(group_id + 1), group_name.ToCharArray());

                BinaryWriter writer = new BinaryWriter(file_stream);
                superblock.amount_of_groups++;

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                    superblock.groups_offset + (superblock.amount_of_groups - 1) * Superblock.OS_GROUP_INFO_SIZE), SeekOrigin.Current);

                group.binaryWritingToFile(writer);

                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, 0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                return (ushort)(group_id + 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception happened: " + e);
                return 0;
            }
        }

        //Изменение названия группы
        public bool changeGroup(string old_group_name,string new_group_name)
        {
            var GUID = getGUID(old_group_name);

            Group group = new Group((ushort)GUID, new_group_name.ToCharArray());

            int position = getGroupPosition(old_group_name);

            if(position == -1)
            {
                return false;
            }

            BinaryWriter writer = new BinaryWriter(file_stream);

            writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
               superblock.groups_offset+position*Superblock.OS_GROUP_INFO_SIZE), SeekOrigin.Current);

            group.binaryWritingToFile(writer);
            return true;
        }

        //Получить позицию группы в списке групп
        public int getGroupPosition(string group_name)
        {
            var groups = getGroupsArray();

            if (groups != null)
            {
                for (int i = 0; i < groups.Length; i++)
                {
                    if(groups[i].group_name.SequenceEqual(new Group(0, group_name.ToArray()).group_name))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        //Удаление группы
        public bool deleteGroup(ushort GUID)
        {
            var groups = getGroupsArray();

            if (groups != null)
            {
                BinaryWriter writer = new BinaryWriter(file_stream);

                int position = 0;

                for (int i = 0; i < groups.Length; i++)
                {
                    if (groups[i].ID_group == GUID)
                    {
                        superblock.amount_of_groups--;
                        continue;
                    }
                    writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position, superblock.groups_offset+position*Superblock.OS_GROUP_INFO_SIZE), SeekOrigin.Current);
                    groups[i].binaryWritingToFile(writer);
                    position++;
                }
                    
                writer.BaseStream.Seek(calculateWhereToCome(writer.BaseStream.Position,
                   0), SeekOrigin.Current);

                superblock.binaryWritingToFile(writer);

                return true;
            }
            else
            {
                return false;
            }

        }

        //Получить пользователей группы
        public User[] getUsersInGroup(ushort GUID)
        {
            var all_users = getUsersArray();

            List<User> users = new List<User>();
            
            if (all_users != null)
            {
                for(int i = 0; i < all_users.Length; i++)
                {
                    if (all_users[i].ID_group == GUID)
                    {
                        users.Add(all_users[i]);
                    }
                }
            }
            return users.ToArray();
        }
    }
}
