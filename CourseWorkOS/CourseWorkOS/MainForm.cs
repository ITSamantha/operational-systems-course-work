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

        public const uint MB_SIZE =1048576;

        public uint free_place;

        public MainForm()
        {
            
            firstWorkWithSystem();
            
            InitializeComponent();

            user_change_B.Text = new string(FileSystem.user.user_login);

            free_place = (uint)(FileSystem.superblock.OS_size - FileSystem.superblock.amount_of_groups * Superblock.OS_GROUP_INFO_SIZE
                - FileSystem.superblock.amount_of_users * Superblock.OS_USER_INFO_SIZE - FileSystem.superblock.amount_of_inodes * Superblock.OS_INODE_SIZE+
                FileSystem.superblock.amount_of_inodes/4-Superblock.OS_SUPERBLOCK_SIZE - FileSystem.superblock.amount_of_inodes*Superblock.OS_ROOT_ROW_SIZE) / MB_SIZE;
            
            free_L.Text = $"Данные:{(uint)(FileSystem.superblock.amount_of_free_clusters*FileSystem.superblock.cluster_size) / MB_SIZE} Мб свободно из {free_place} Мб";

            //FileSystem.createFile(new char[] { 'f', 'i', 'l', 'e' }, new char[] { 't', 'x', 't' }, new byte[1024]);
            /*
                       for (int i = 0; i < 50; i++)
                        {
                            FileSystem.createFile(new char[] { 'f','i','l','e'}, new char[] { 't','x','t' }, new byte[512]);
                        }
                        MessageBox.Show("yes");*/



        }

        private void work_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 0;
            
            showFiles();
        }


        //Создание или вход в файловую систему
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

        public void formCreatingParamsForSystem()
        {
            SystemCreationParams scr = new SystemCreationParams();

            scr.ShowDialog();

            if (scr.DialogResult == DialogResult.OK)
            {
                FileSystem.createFileSystem(ushort.Parse(scr.cluster_size_CB.Text),(uint)scr.FS_size.Value*MB_SIZE);

                formRegistarionOrAutorizationUser(0);

                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(FileSystem.calculateWhereToCome(reader.BaseStream.Position,
                        FileSystem.superblock.users_offset), SeekOrigin.Current);

                    FileSystem.user = User.loadUserFromBinaryFile(reader);
                }
            }
            else { return; }
        }


        public bool formRegistarionOrAutorizationUser(byte mode)
        {
            UserForm form = new UserForm(mode);//0 - регистрация, 1 - авторизация

            while (true)
            {
                form.ShowDialog();

                if (form.DialogResult != DialogResult.OK) { return false; }

                if (form.login_TB.Text == String.Empty || form.password_TB.Text == String.Empty)//ПОЛЬЗОВАТЕЛЬ НА РУССКОМ?
                {
                    MessageBox.Show("Поле \"Логин\" и поле \"Пароль\" не могут быть пустымы.");
                }
                else { break; }
            }

            switch (mode)
            {
                case 0:
                    {
                        var form_user = new User(form.login_TB.Text.ToCharArray());

                        var users = FileSystem.getUsersArray();

                        if (users!=null)
                        {
                            foreach (var user in users)
                            {
                                if (user.user_login.SequenceEqual(form_user.user_login))
                                {
                                    MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                        FileSystem.createUserFS(form.login_TB.Text, form.password_TB.Text,form.isAdmin.Checked);
                        MessageBox.Show($"Пользователь {form.login_TB.Text} успешно зарегистрирован:)",
                            "Регистрация пройдена успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    MessageBox.Show($"Добро пожаловать,{form.login_TB.Text} :)", "Авторизация пройдена успешно",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    FileSystem.user = users[i];
                                    return true;
                                }
                            }
                            MessageBox.Show("Упс!Такой пользователь не найден!");
                            return false;
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine($"Exception happened {e}");
                            return false;
                        }
                    }
            }
            return false;
        }

        private void info_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 1;
            
            nameOS_TB.Text = new string(FileSystem.superblock.OS_name);

            custer_size_TB.Text = FileSystem.superblock.cluster_size.ToString()+BYTE;

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

        private void users_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 2;

            loadUsersToTable();
            
        }

        private void groups_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 3;

            loadGroupsToTable();
        }

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

        private void add_user_B_Click(object sender, EventArgs e)
        {
            formRegistarionOrAutorizationUser(0);

            loadUsersToTable();
        }

        private void delete_user_B_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены? Данный пользователь будет безвозвратно удален.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //УДАЛЕНИЕ ОДНОИМЕННОЙ ГРУППЫ?
                FileSystem.deleteUserFS((ushort)user_DG.SelectedRows[0].Cells[0].Value);

                MessageBox.Show("Пользователь успешно удален.");

                loadUsersToTable();
            }
        }
        
        private void showFiles()
        {

            var files = FileSystem.getAllRootCatalogRows();

            file_panel.Controls.Clear();
            
            file_panel.RowStyles.Clear();

            file_panel.RowCount = (int)Math.Ceiling((double)(files.Length / 5))+1;

            Button[] buttons = new Button[files.Length];
            
            for (int i = 0; i < files.Length; i++)
            {
                if (i <file_panel.RowCount)
                {
                    file_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 90));
                }
                
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

        


        private Button createFileObj(string text="default")
        {
            var file_obj = new Button();

            file_obj.Image = Resources.file;

            file_obj.ImageAlign = ContentAlignment.TopCenter;

            file_obj.TextAlign = ContentAlignment.BottomCenter;

            file_obj.Size = new Size(150, 150);

            file_obj.FlatStyle = FlatStyle.Flat;

            file_obj.FlatAppearance.BorderSize = 0;

            file_obj.Font = new Font("Times New Roman", 10);

            file_obj.Text = $"{text}";

            return file_obj;
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"open {(((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text}");
        }

        private void changeItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"change {(((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text}");
        }

        //Обработка события нажатия на кнопку "Перименовать файл"
        //ПЕРЕДЕЛАТЬ ФУНКЦИЮ
        private void renameItem_Click(object sender, EventArgs e)
        {
            //НЕ ЗАБУДЬ В NAME_FILE ДОДЕЛАТЬ ПРОВЕРКУ ДЛИНЫ НАЗВАНИЯ И РАСШИРЕНИЯ
            Name_File name = new Name_File();

            var result = name.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                var position = FileSystem.renameFile((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text, 
                    name.file_name_TB.Text,result==DialogResult.Yes);

                if (position != -1)
                {
                    file_panel.Controls[position].Text = name.file_name_TB.Text;
                }
            }
        }

        private void copyItem_Click(object sender, EventArgs e)
        {
            FileSystem.copyFile((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text, true);//НЕ ЗАБУДЬ ДОДЕЛАТЬ ПРОВЕРКУ НА РАСШИЕРНИЕ
            showFiles();
           
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)//Также продумать access!!!
        {
            var fl = createPropertyFileForm(0,DateTime.Now, DateTime.Now);

            var result = fl.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                var access = formAccess(fl.r_u.Checked, fl.w_u.Checked, fl.x_u.Checked, fl.r_g.Checked, fl.w_g.Checked,
                    fl.x_g.Checked, fl.r_o.Checked, fl.w_o.Checked, fl.x_o.Checked, fl.onlyReadCB.Checked, fl.hidenCB.Checked, fl.systemCB.Checked);

                FileSystem.createFile(result == DialogResult.Yes ? fl.file_name_TB.Text.Split('.')[0].ToCharArray() : fl.file_name_TB.Text.ToCharArray(),
                result == DialogResult.Yes ? fl.file_name_TB.Text.Split('.')[1].ToCharArray() : new char[0], new byte[0], access);

                showFiles();
            }
        }

        private FileInformation createPropertyFileForm(uint size,DateTime creation,DateTime change,string file_name="",AccessRules access = null)
        {
            FileInformation fl = new FileInformation();

            fl.file_name_TB.Text = file_name;

            fl.ownerUID_TB.Text = FileSystem.user.ID_owner.ToString();

            var users = FileSystem.getUsersArray();

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].ID_owner == FileSystem.user.ID_owner)
                {
                    fl.owner_TB.Text = new string(users[i].user_login);
                    break;
                }
            }

            fl.ownerGUID_TB.Text = FileSystem.user.ID_group.ToString();

            var groups = FileSystem.getGroupsArray();

            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i].ID_group == FileSystem.user.ID_group)
                {
                    fl.group_TB.Text = new string(groups[i].group_name);
                    break;
                }
            }

            fl.size_TB.Text = $"{size} байт";

            fl.createTB.Text = creation.ToString();

            fl.changeTB.Text = change.ToString();

            if(access!= null)
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

        private AccessRules formAccess(bool r_u, bool w_u, bool x_u, bool r_g, bool w_g, bool x_g,
            bool r_o,bool w_o,bool x_o, bool read_only,bool hidden,bool sys)
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

        private void propertiesItem_Click(object sender, EventArgs e)
        {
            int position;

            RootCatalogRow root;

            FileSystem.findExactFile((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Button).Text,out position,out root);

            var inode = FileSystem.getInodeByNumber(root.inode_number);

            var fl = createPropertyFileForm(inode.size_in_bytes, Converter.GetDateTime(inode.datetime_of_creation), 
                Converter.GetDateTime(inode.datetime_of_last_modification), RootCatalogRow.createFileName(root),new AccessRules(inode.access_rules));

            fl.ShowDialog();
        }
    }
}
