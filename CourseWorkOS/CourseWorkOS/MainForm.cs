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

namespace CourseWorkOS
{
    public partial class MainForm : Form
    {
        public short work_mode { get; set; }

        public FileSystem FileSystem { get; set; } = new FileSystem();

        public const string GROUP_AMOUNT = "Количество групп: ";

        public const string USER_AMOUNT = "Количество пользователей: ";

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
            
            free_L.Text = $"Данные:{(uint)(FileSystem.superblock.amount_of_free_clusters*Superblock.DEFAULT_CLUSTER_SIZE) / MB_SIZE} Мб свободно из {free_place} Мб";
        }

        private void work_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 0;
        }//!


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

                formRegistarionOrAutorizationUser(0,true);

                using (BinaryReader reader = new BinaryReader(File.Open(SYSTEM_FILE_NAME, FileMode.Open)))
                {
                    reader.BaseStream.Seek(FileSystem.calculateWhereToCome(reader.BaseStream.Position,
                        FileSystem.superblock.users_offset), SeekOrigin.Current);

                    FileSystem.user = User.loadUserFromBinaryFile(reader);
                }
            }
            else { return; }
        }


        public bool formRegistarionOrAutorizationUser(byte mode,bool isAdmin=false)
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
                        FileSystem.createUserFS(form.login_TB.Text, form.password_TB.Text,isAdmin);
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
        }

        private void users_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 2;

            user_DG.Rows.Clear();

            var users = FileSystem.getUsersArray();

            for (int i = 0; i < users.Length; i++)
            {
                user_DG.Rows.Add(new object[] {users[i].ID_owner, users[i].ID_group, new string(users[i].user_login),users[i].user_role });
            }

            user_amount_L.Text = USER_AMOUNT + users.Length.ToString();
        }

        private void groups_B_Click(object sender, EventArgs e)
        {
            main_control.SelectedIndex = 3;

            group_DG.Rows.Clear();

            var groups = FileSystem.getGroupsArray();

            for (int i = 0; i < groups.Length; i++)
            {
                group_DG.Rows.Add(new object[] { groups[i].ID_group, new string(groups[i].group_name) });
            }

            group_amount_L.Text = GROUP_AMOUNT + groups.Length.ToString();
        }
        
    }
}
