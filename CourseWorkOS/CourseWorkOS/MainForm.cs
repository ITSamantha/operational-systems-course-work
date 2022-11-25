using CourseWorkOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CourseWorkOS
{
    public partial class MainForm : Form
    {
        public short work_mode { get; set; }

        public FileSystem FileSystem { get; set; } = new FileSystem();

        public const string GROUP_AMOUNT = "Количество групп: ";

        public const string USER_AMOUNT = "Количество пользователей: ";

        public const string BYTE = " байт";

        public const string FS_FILE = "Samantha:Файл";

        //Константы

        public const string SYSTEM_FILE_NAME = "data.bin";

        public const uint MB_SIZE = 1048576;

        public uint free_place;



        /*Инициализация формы*/

        //Конструктор
        public MainForm()
        {

            firstWorkWithSystem();

            InitializeComponent();

            changeUser();

            free_place = (uint)(FileSystem.superblock.OS_size - FileSystem.superblock.amount_of_groups * Superblock.OS_GROUP_INFO_SIZE
                - FileSystem.superblock.amount_of_users * Superblock.OS_USER_INFO_SIZE - FileSystem.superblock.amount_of_inodes * Superblock.OS_INODE_SIZE +
                FileSystem.superblock.amount_of_inodes / 4 - Superblock.OS_SUPERBLOCK_SIZE - FileSystem.superblock.amount_of_inodes * Superblock.OS_ROOT_ROW_SIZE) / MB_SIZE;

            free_L.Text = $"Данные:{(uint)(FileSystem.superblock.amount_of_free_clusters * FileSystem.superblock.cluster_size) / MB_SIZE} Мб свободно из {free_place} Мб";

        }

        //Событие закрытия формы
        private void MainForm_Closed(object sender, EventArgs e)
        {
            FileSystem.file_stream.Close();
        }



        /*Обработка событий кнопок*/

        //Работа с файловой системой
        private void work_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 0;

            showFiles();
        }

        //Дописать в конец файла
        private void writeEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file_name = (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text;

            OpenFile op = new OpenFile();

            op.file_name.Text = file_name;

            var result = op.ShowDialog();

            if (op.DialogResult != DialogResult.Cancel)
            {
                if (op.text_TB.Text != String.Empty)
                {
                    if (FileSystem.writeEndFile(file_name, Converter.convertFromCharIntoBytes(op.text_TB.Text.ToCharArray())))
                    {
                        MessageBox.Show("Информация успешно дописана в конец файла.");
                    }
                }
                else
                {
                    MessageBox.Show("Данные не были введены.");
                    return;
                }
            }
        }
        
        //Открыть или изменить файл
        private void openItem_Click(object sender, EventArgs e)
        {
            var file_name = (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text;

            OpenFile op = new OpenFile();

            op.file_name.Text = file_name;

            op.text_TB.Text = new string(Converter.convertFromBytesIntoChar(FileSystem.readFile(file_name)));

            var result = op.ShowDialog();

            if (result != DialogResult.Cancel)
            {

            }

        }
        
        //Копировать файл
        private void copyItem_Click(object sender, EventArgs e)
        {
            var text = (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text;

            Name_File nf = new Name_File();

            var result = nf.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            string _ext, _base;

            Converter.getBaseAndExtention(nf.file_name_TB.Text, out _ext, out _base);

            if (!isExtNormal(_ext))
            {
                MessageBox.Show("Расширение должно содержать не более 5 символов (включая точку).");
                return;
            }

            if (!isBaseNormal(_base))
            {
                MessageBox.Show("Имя файла должно содержать не более 20 символов.");
                return;
            }

            FileSystem.copyFile(_ext, _base, text);

            showFiles();
        }

        //Создание файла
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fl = createPropertyFileForm(0, DateTime.Now, DateTime.Now, FileSystem.user.ID_owner, FileSystem.user.ID_group);

            var result = fl.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                var access = formAccess(fl.r_u.Checked, fl.w_u.Checked, fl.x_u.Checked, fl.r_g.Checked, fl.w_g.Checked,
                    fl.x_g.Checked, fl.r_o.Checked, fl.w_o.Checked, fl.x_o.Checked, fl.onlyReadCB.Checked, fl.hidenCB.Checked, fl.systemCB.Checked);

                string _ext;

                string _base;

                Converter.getBaseAndExtention(fl.file_name_TB.Text, out _ext, out _base);

                if (!isExtNormal(_ext))
                {
                    MessageBox.Show("Расширение должно содержать не более 5 символов (включая точку).");
                    return;
                }

                if (!isBaseNormal(_base))
                {
                    MessageBox.Show("Имя файла должно содержать не более 20 символов.");
                    return;
                }

                FileSystem.createFile(_base.ToCharArray(), _ext.ToCharArray(), new byte[0], access);

                showFiles();
            }
        }
        
        //Просмотр свойств
        private void propertiesItem_Click(object sender, EventArgs e)
        {
            workWithProperties((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text);
        }

        //Смена прав доступа
        private void workWithRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workWithProperties((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text);
        }

        //Обработка события нажатия на кнопку "Перименовать файл"
        private void renameItem_Click(object sender, EventArgs e)
        {
            workWithProperties((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text);
        }
        
        //Смена пользователя
        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRegistarionOrAutorizationUser(1);

            changeUser();
        }

        //Выход из системы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            firstWorkWithSystem();

            changeUser();

            Show();
        }

        //Удаление файла
        private void deleteItem_Click(object sender, EventArgs e)
        {
            if (FileSystem.deleteFile((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text))
            {
                showFiles();
            }
        }

        

        /*Вспомогательные функции*/

        //Задание параметров создаваемой системы
        public void formCreatingParamsForSystem()
        {
            SystemCreationParams scr = new SystemCreationParams();

            scr.ShowDialog();

            if (scr.DialogResult == DialogResult.OK)
            {
                FileSystem.createFileSystem(ushort.Parse(scr.cluster_size_CB.Text), (uint)scr.FS_size.Value * MB_SIZE);

                formRegistarionOrAutorizationUser(0);

            }
            else { return; }
        }

        //Смена текущего пользователя
        public void changeUser()
        {
            user_change_B.Text = new string(FileSystem.user.user_login);
        }

        //Работа со свойствами (изменение прав доступа, переименование, показ)
        public void workWithProperties(string file_name)
        {
            int position = FileSystem.findRootPosition(file_name);

            RootCatalogRow root = FileSystem.findRootRowByName(file_name);

            if (position == -1)
            {
                MessageBox.Show("Данный файл не существует.");
                return;
            }

            var inode = FileSystem.getInodeByNumber(root.inode_number);

            var fl = createPropertyFileForm(inode.size_in_bytes, Converter.GetDateTime(inode.datetime_of_creation),
                Converter.GetDateTime(inode.datetime_of_last_modification), inode.ID_owner, inode.ID_group, RootCatalogRow.createFileName(root), new AccessRules(inode.access_rules));

            var access1 = formAccess(fl.r_u.Checked, fl.w_u.Checked, fl.x_u.Checked, fl.r_g.Checked, fl.w_g.Checked,
                    fl.x_g.Checked, fl.r_o.Checked, fl.w_o.Checked, fl.x_o.Checked, fl.onlyReadCB.Checked,
                    fl.hidenCB.Checked, fl.systemCB.Checked).getAccessRulesForFile();

            var result = fl.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                if (file_name != fl.file_name_TB.Text)
                {
                    string _ext;

                    string _base;

                    Converter.getBaseAndExtention(fl.file_name_TB.Text, out _ext, out _base);

                    if (!isExtNormal(_ext))
                    {
                        MessageBox.Show("Расширение должно содержать не более 5 символов (включая точку).");
                        return;
                    }

                    if (!isBaseNormal(_base))
                    {
                        MessageBox.Show("Имя файла должно содержать не более 20 символов.");
                        return;
                    }

                    position = FileSystem.renameFile(position, root, inode, _base, _ext);

                    if (position != -1)
                    {
                        file_panel.Controls[position].Text = fl.file_name_TB.Text;
                    }
                }

                var access2 = formAccess(fl.r_u.Checked, fl.w_u.Checked, fl.x_u.Checked, fl.r_g.Checked, fl.w_g.Checked,
                    fl.x_g.Checked, fl.r_o.Checked, fl.w_o.Checked, fl.x_o.Checked, fl.onlyReadCB.Checked, fl.hidenCB.Checked,
                    fl.systemCB.Checked).getAccessRulesForFile();

                if (access1 != access2)
                {
                    inode.access_rules = access2;

                    FileSystem.changeAccessRules(root.inode_number, inode);
                }
            }
        }

        //Сформировать права доступа
        private AccessRules formAccess(bool r_u, bool w_u, bool x_u, bool r_g, bool w_g, bool x_g,
            bool r_o, bool w_o, bool x_o, bool read_only, bool hidden, bool sys)
        {
            AccessRules access = new AccessRules();
            access.r_u = r_u;
            access.r_g = r_g;
            access.r_o = r_o;
            access.w_u = w_u;
            access.w_g = w_g;
            access.w_o = w_o;
            access.x_u = x_u;
            access.x_g = x_g;
            access.x_o = x_o;
            access.read_only_file = read_only;
            access.hidden_file = hidden;
            access.system_file = sys;
            return access;
        }
        
        //Создание формы "Свойства файла"
        private FileInformation createPropertyFileForm(uint size, DateTime creation, DateTime change,
            ushort user_id, ushort group_id, string file_name = "", AccessRules access = null)
        {
            FileInformation fl = new FileInformation();

            fl.file_name_TB.Text = file_name;

            fl.ownerUID_TB.Text = user_id.ToString();

            var users = FileSystem.getUsersArray();

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].ID_owner == user_id)
                {
                    fl.owner_TB.Text = new string(users[i].user_login);
                    break;
                }
            }

            fl.ownerGUID_TB.Text = group_id.ToString();

            var groups = FileSystem.getGroupsArray();

            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i].ID_group == group_id)
                {
                    fl.group_TB.Text = new string(groups[i].group_name);
                    break;
                }
            }

            fl.size_TB.Text = $"{size} байт";

            fl.createTB.Text = creation.ToString();

            fl.changeTB.Text = change.ToString();

            if (access != null)
            {
                fl.onlyReadCB.Checked = access.read_only_file;
                fl.hidenCB.Checked = access.hidden_file;
                fl.systemCB.Checked = access.system_file;
                fl.r_u.Checked = access.r_u;
                fl.w_u.Checked = access.w_u;
                fl.x_u.Checked = access.x_u;
                fl.r_g.Checked = access.r_g;
                fl.w_g.Checked = access.w_g;
                fl.x_g.Checked = access.x_g;
                fl.r_o.Checked = access.r_o;
                fl.w_o.Checked = access.w_o;
                fl.x_o.Checked = access.x_o;
            }

            return fl;

        }
        
        //Корректно ли расширение файла
        public bool isExtNormal(string _ext)
        {
            if (_ext.Length > RootCatalogRow.EXTENTION_SIZE)
            {
                return false;
            }
            return true;
        }

        //Корректно ли название файла
        public bool isBaseNormal(string _base)
        {
            if (_base.Length > RootCatalogRow.NAME_SIZE)
            {
                return false;
            }
            return true;
        }

        //Создание или загрузка файловой системы
        public void firstWorkWithSystem()
        {
            bool isNew = true;

            while (isNew)
            {
                entryForm entry = new entryForm();

                entry.ShowDialog();

                work_mode = entry.work_mode;

                switch (work_mode)
                {
                    //Продолжить работу с существующей ФС
                    case 1:
                        {
                            FileSystem.loadFileSystemFromFile();

                            if (formRegistarionOrAutorizationUser(1))
                            {
                                isNew = false;
                            }

                            break;
                        }

                    //Создать новую ФС
                    case 2:
                        {
                            var result = MessageBox.Show("Вы уверены? Все данные предыдущей ФС будут удалены.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                formCreatingParamsForSystem();

                                isNew = false;
                            }
                            break;
                        }

                    //Выход
                    case 0:
                        {
                            return;
                        }


                }
            }
        }

        //Создание объекта файла
        private Button createFileObj(string text = "default")
        {
            var file_obj = new Button();

            file_obj.Image = Resources.file;

            file_obj.ImageAlign = ContentAlignment.TopCenter;

            file_obj.TextAlign = ContentAlignment.BottomCenter;

            file_obj.Size = new Size(145, 100);

            file_obj.FlatStyle = FlatStyle.Flat;

            file_obj.FlatAppearance.BorderSize = 0;

            file_obj.Font = new Font("Times New Roman", 10);

            file_obj.Text = $"{text}";

            return file_obj;
        }

        //Показать файлы
        private void showFiles()
        {

            var files = FileSystem.getAllRootCatalogRows();

            file_panel.Controls.Clear();

            file_panel.RowCount = (int)Math.Ceiling((double)files.Length / 5.0);

            file_panel.RowStyles.Clear();

            Button[] buttons = new Button[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                Button file_obj = createFileObj();

                file_obj.ContextMenuStrip = contextMenuForFile;

                file_obj.Text = RootCatalogRow.createFileName(files[i]);

                buttons[i] = file_obj;
            }

            Action action = () => {
                file_panel.Controls.AddRange(buttons);
            };
            Invoke(action);

            free_L.Text = $"Данные:{(uint)(FileSystem.superblock.amount_of_free_clusters * FileSystem.superblock.cluster_size) / MB_SIZE} Мб свободно из {free_place} Мб";

        }

        //Загрузить группы в таблицу
        private void loadGroupsToTable()
        {
            group_DG.Rows.Clear();

            var groups = FileSystem.getGroupsArray();

            for (int i = 0; i < groups.Length; i++)
            {
                group_DG.Rows.Add(new object[] { groups[i].ID_group, new string(groups[i].group_name) });
            }

            group_amount_L.Text = GROUP_AMOUNT + groups.Length.ToString();
        }

        //Загрузить пользователей в таблицу
        private void loadUsersToTable()
        {
            user_DG.Rows.Clear();

            var users = FileSystem.getUsersArray();

            for (int i = 0; i < users.Length; i++)
            {
                user_DG.Rows.Add(new object[] { users[i].ID_owner, users[i].ID_group, new string(users[i].user_login), users[i].user_role });
            }

            user_amount_L.Text = USER_AMOUNT + users.Length.ToString();
        }

        //Форма регистрации и авторизации
        public bool formRegistarionOrAutorizationUser(byte mode)
        {
            UserForm form = new UserForm(mode);//0 - регистрация, 1 - авторизация

            if (mode == 0)
            {
                var groups = FileSystem.getGroupsArray();

                if (groups != null)
                {
                    foreach (var group in groups)
                    {
                        form.comboBox1.Items.Add(new string(group.group_name));
                    }
                }
            }

            while (true)
            {
                form.ShowDialog();

                if (form.DialogResult != DialogResult.OK) { return false; }

                if (form.login_TB.Text == String.Empty || form.password_TB.Text == String.Empty)
                {
                    MessageBox.Show("Поле \"Логин\" и поле \"Пароль\" не могут быть пустымы.");
                }
                else { break; }
            }

            switch (mode)
            {
                case 0:
                    {
                        if (FileSystem.checkIfTheSameLogin(form.login_TB.Text))
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return false;
                        }

                        var group_id = FileSystem.checkIfTheSameGroupNames(form.comboBox1.Text) ?
                            FileSystem.getGUID(form.comboBox1.Text) : FileSystem.createGroupFS(form.comboBox1.Text);

                        if (group_id == -1)
                        {
                            MessageBox.Show("Не удалось найти или создать группу.");
                            return false;
                        }

                        var temp_user = FileSystem.createUserFS(form.login_TB.Text, form.password_TB.Text, (ushort)group_id, FileSystem.superblock.amount_of_users == 0 ? true : false);

                        MessageBox.Show($"Пользователь {form.login_TB.Text} успешно зарегистрирован:)",
                            "Регистрация пройдена успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (FileSystem.superblock.amount_of_users == 1)
                        {
                            FileSystem.user = temp_user;
                        }
                        return true;
                    }
                case 1:
                    {
                        try
                        {
                            User new_user = new User(0, 0, form.login_TB.Text.ToCharArray(), form.password_TB.Text, false);

                            User[] users = FileSystem.getUsersArray();

                            for (int i = 0; i < FileSystem.superblock.amount_of_users; i++)
                            {
                                if (new_user.user_login.SequenceEqual(users[i].user_login) &&
                                         users[i].hash_password.SequenceEqual(new_user.hash_password))
                                {
                                    MessageBox.Show($"Добро пожаловать,{form.login_TB.Text} :)", "Авторизация пройдена успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    FileSystem.user = users[i];
                                    return true;
                                }
                            }
                            MessageBox.Show("Упс!Такой пользователь не найден!Возможно, Вы неверно ввели пароль.");
                            return false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Exception happened {e}");
                            return false;
                        }
                    }
            }
            return false;
        }

        //Информация о системе
        private void info_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 1;

            nameOS_TB.Text = new string(FileSystem.superblock.OS_name);

            custer_size_TB.Text = FileSystem.superblock.cluster_size.ToString() + BYTE;

            sizeOS_TB.Text = FileSystem.superblock.OS_size.ToString() + BYTE;

            freeclusters_TB.Text = FileSystem.superblock.amount_of_free_clusters.ToString();

            inode_TB.Text = FileSystem.superblock.amount_of_inodes.ToString();

            freeinode_TB.Text = FileSystem.superblock.amount_of_free_inodes.ToString();

            registr_user_TB.Text = FileSystem.superblock.amount_of_users.ToString();

            registr_group_TB.Text = FileSystem.superblock.amount_of_groups.ToString();

            max_user_TB.Text = FileSystem.superblock.max_amount_of_users.ToString();

            max_group_TB.Text = FileSystem.superblock.max_amount_of_groups.ToString();

            cluster_bitmap_TB.Text = FileSystem.superblock.cluster_bitmap_offset.ToString() + BYTE;

            inode_bitmap_TB.Text = FileSystem.superblock.inode_bitmap_offset.ToString() + BYTE;

            ilist_TB.Text = FileSystem.superblock.ilist_offset.ToString() + BYTE;

            root_TB.Text = FileSystem.superblock.root_offset.ToString() + BYTE;

            info_user_TB.Text = FileSystem.superblock.users_offset.ToString() + BYTE;

            info_group_TB.Text = FileSystem.superblock.groups_offset.ToString() + BYTE;

            data_TB.Text = FileSystem.superblock.data_offset.ToString() + BYTE;

        }

        //Загрузить пользователей в таблицу
        private void users_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 2;

            loadUsersToTable();

        }

        //Загрузить группы в таблицу
        private void groups_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 3;

            loadGroupsToTable();
        }



        /*Работа с пользователями*/

        //Добавление пользователя
        private void add_user_B_Click(object sender, EventArgs e)
        {
            if (FileSystem.superblock.amount_of_users == FileSystem.superblock.max_amount_of_users)
            {
                MessageBox.Show("Максимальное количество пользователей существует в системе. Невозможно добавить.");
                return;
            }
            if (FileSystem.user.user_role)
            {
                formRegistarionOrAutorizationUser(0);

                loadUsersToTable();
            }
            else
            {
                MessageBox.Show("Только администратор может добавлять пользователей", "Error");
            }
        }

        //Удаление пользователя
        private void delete_user_B_Click(object sender, EventArgs e)
        {
            if (FileSystem.superblock.amount_of_users == 1)
            {
                MessageBox.Show("Невозможно удалить. В системе должен быть хотя бы один пользователь.");
                return;
            }
            if (user_DG.SelectedRows[0].Cells[3].Value.ToString().Equals("True"))
            {
                MessageBox.Show("Невозможно удалить администратора.Передайте права администратора какому-либо пользователю, а затем удалите пользователя.");
                return;
            }
            if (FileSystem.user.user_role)
            {
                var result = MessageBox.Show("Вы уверены? Данный пользователь будет безвозвратно удален.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    FileSystem.deleteUserFS((ushort)user_DG.SelectedRows[0].Cells[0].Value);

                    FileSystem.giveAllFilesToAdmin((ushort)user_DG.SelectedRows[0].Cells[0].Value);

                    MessageBox.Show("Пользователь успешно удален.");

                    loadUsersToTable();
                }
            }
            else
            {
                MessageBox.Show("Необходимо быть администратором, чтобы удалять пользователей.");
            }
        }

        //Передача прав администратора
        private void setAdmin_B_Click(object sender, EventArgs e)
        {
            if (FileSystem.superblock.amount_of_users < 2)
            {
                MessageBox.Show("Данное действие недоступно. Количество пользователей должно быть не менее 2.");
                return;
            }

            if (new string(FileSystem.user.user_login).SequenceEqual(user_DG.SelectedRows[0].Cells[2].Value.ToString()))
            {
                MessageBox.Show("Данное действие недоступно.Нельяз передать права самому себе.");
                return;
            }

            if (FileSystem.user.user_role)
            {
                if (MessageBox.Show("Вы точно хотите передать права администратора другому пользователю?", "Предупреждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Name_File n = new Name_File();
                    n.Text = "Введите пароль";
                    n.groupBox1.Text = "Введите пароль администратора";

                    if (n.ShowDialog() == DialogResult.OK)
                    {
                        if (User.transformPasswordIntoHash(n.file_name_TB.Text).SequenceEqual(FileSystem.user.hash_password))
                        {
                            FileSystem.user.user_role = false;
                            FileSystem.setAdmin(new string(FileSystem.user.user_login), false);
                            FileSystem.setAdmin(user_DG.SelectedRows[0].Cells[2].Value.ToString(), true);
                            loadUsersToTable();
                        }
                        else
                        {
                            MessageBox.Show("Вы неправильно ввели пароль.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Данное действие доступно только администратору.");
            }
        }

        //Изменение параметров пользователя
        private void changeUserB_Click(object sender, EventArgs e)
        {
            bool isChanged = false;
            
            //|| user_DG.SelectedRows[0].Cells[2].Value.ToString().SequenceEqual(new string(FileSystem.user.user_login)
            if (FileSystem.user.user_role)
            {
                UserForm form = new UserForm(3);

                var groups = FileSystem.getGroupsArray();

                if (groups != null)
                {
                    foreach (var group in groups)
                    {
                        form.comboBox1.Items.Add(new string(group.group_name));
                    }
                }
                User temp_user = FileSystem.getUserByName(user_DG.SelectedRows[0].Cells[2].Value.ToString());

                var prev_name = temp_user.user_login;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.login_TB.Text != String.Empty)
                    {
                        if (FileSystem.checkIfTheSameLogin(form.login_TB.Text))
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return;
                        }
                        temp_user.formUserLogin(form.login_TB.Text.ToCharArray());
                        isChanged = true;
                    }
                    if (form.password_TB.Text != String.Empty)
                    {
                        temp_user.hash_password = User.transformPasswordIntoHash(form.password_TB.Text);
                        isChanged = true;
                    }
                    if (form.comboBox1.Text != String.Empty)
                    {
                        var group_id = FileSystem.checkIfTheSameGroupNames(form.comboBox1.Text) ?
                            FileSystem.getGUID(form.comboBox1.Text) : FileSystem.createGroupFS(form.comboBox1.Text);

                        if (group_id == -1)
                        {
                            MessageBox.Show("Не удалось найти или создать группу.");
                            return;
                        }
                        temp_user.ID_group = (ushort)group_id;
                        isChanged = true;
                    }

                    if (isChanged)
                    {
                        BinaryWriter writer = new BinaryWriter(FileSystem.file_stream);

                        var position = (ushort)FileSystem.getUserPosition(user_DG.SelectedRows[0].Cells[2].Value.ToString());

                        writer.BaseStream.Seek(FileSystem.calculateWhereToCome(writer.BaseStream.Position,
                            FileSystem.superblock.users_offset + position * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                        temp_user.binaryWritingToFile(writer);

                        if (prev_name.SequenceEqual(FileSystem.user.user_login))
                        {
                            FileSystem.user = FileSystem.getUserByName(new string(temp_user.user_login));
                        }
                        changeUser();
                        
                        loadUsersToTable();
                    }
                }
            }
            else
            {
                MessageBox.Show("Для изменения профиля пользователя неоьходимо либо быть влдельцем аккаунта, либо администратором.");
            }
        }
        


        /*Работа с группами*/

        //Создание группы
        private void add_group_B_Click(object sender, EventArgs e)
        {
            if (!FileSystem.user.user_role)
            {
                MessageBox.Show("Данное действие доступно только администратору.");
                return;
            }

            GroupWork gw = new GroupWork(0);

            if (gw.ShowDialog() == DialogResult.OK)
            {
                if (gw.group_TB.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Вы не ввели название.");
                    return;
                }

                if (FileSystem.checkIfTheSameGroupNames(gw.group_TB.Text))
                {
                    MessageBox.Show("Невозможно создать. Группа с таким названием уже существует.");
                    return;
                }

                FileSystem.createGroupFS(gw.group_TB.Text);
                loadGroupsToTable();
            }
        }

        //Изменение группы
        private void changeGroupB_Click(object sender, EventArgs e)
        {
            if (!FileSystem.user.user_role)
            {
                MessageBox.Show("Данное действие доступно только администратору.");
                return;
            }

            GroupWork gw = new GroupWork(1);

            if (gw.ShowDialog() == DialogResult.OK)
            {
                if (gw.group_TB.Text.Trim() != String.Empty)
                {
                    if (FileSystem.checkIfTheSameGroupNames(gw.group_TB.Text))
                    {
                        MessageBox.Show("Невозможно изменить. Группа с таким названием уже существует.");
                        return;
                    }
                    FileSystem.changeGroup(group_DG.SelectedRows[0].Cells[1].Value.ToString(), gw.group_TB.Text);
                    loadGroupsToTable();
                }
                else
                {
                    MessageBox.Show("Вы не ввели новое название.");
                }
            }
        }

        //Удаление группы
        private void delete_group_B_Click(object sender, EventArgs e)
        {
            if (FileSystem.superblock.amount_of_groups == 1)
            {
                MessageBox.Show("Данное действие недоступно. В системе должна быть хотя бы одна группа");
                return;
            }

            if (!FileSystem.user.user_role)
            {
                MessageBox.Show("Данное действие доступно только администратору.");
                return;
            }

            if (MessageBox.Show("Вы уверены?Это действие нельзя будет отменить.", "Предупреждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var users = FileSystem.getUsersInGroup((ushort)group_DG.SelectedRows[0].Cells[0].Value);

                if (users != null&&users.Length!=0)
                {
                    StringBuilder sb = new StringBuilder($"При удалении без группы останется {users.Length} пользователей: ");
                    foreach (var us in users)
                    {
                        sb.Append($"\n{new string(us.user_login).Replace('\0',' ').Trim()}");
                    }
                    sb.Append("\nВ следующем диалоговом окне Вам необходимо выбрать группу для этих пользователей.");

                    MessageBox.Show(sb.ToString());

                    GroupChoose form = new GroupChoose();

                    var groups = FileSystem.getGroupsArray();

                    if (groups != null)
                    {
                        foreach (var group in groups)
                        {
                            if(group.ID_group!= (ushort)group_DG.SelectedRows[0].Cells[0].Value)
                            {
                                form.comboBox1.Items.Add(new string(group.group_name));
                            }
                        }
                    }

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var group_id = FileSystem.checkIfTheSameGroupNames(form.comboBox1.Text) ?
                           FileSystem.getGUID(form.comboBox1.Text) : FileSystem.createGroupFS(form.comboBox1.Text);

                        if (group_id == -1)
                        {
                            MessageBox.Show("Не удалось найти или создать группу.");
                            return;
                        }

                        BinaryWriter writer = new BinaryWriter(FileSystem.file_stream);

                        for (int i = 0; i < users.Length; i++)
                        {
                            users[i].ID_group = (ushort)group_id;

                            var position = (ushort)FileSystem.getUserPosition(new string(users[i].user_login));

                            writer.BaseStream.Seek(FileSystem.calculateWhereToCome(writer.BaseStream.Position,
                                FileSystem.superblock.users_offset + position * Superblock.OS_USER_INFO_SIZE), SeekOrigin.Current);

                            users[i].binaryWritingToFile(writer);

                        }
                        FileSystem.user = FileSystem.getUserByName(new string(FileSystem.user.user_login));
                        
                    }
                    else
                    {
                        return;
                    }
                }
                if (FileSystem.deleteGroup((ushort)group_DG.SelectedRows[0].Cells[0].Value))
                {
                    MessageBox.Show("Группа успешно удалена.");
                    loadGroupsToTable();
                }
            }
        }

        private void показатьСкрытыеФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
