using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public class User
    {
        //ЛОГИН И ПАРОЛЬ МОЖНО ПОМЕНЯТЬ!
        public ushort ID_owner { get; set; }

        public ushort ID_group { get; set; }

        public char[] user_login { get; set; }

        public char[] hash_password { get; set; }

        public bool user_role { get; set; }

        //Константы 

        public const ushort LOGIN_SIZE = 16;

        public const ushort PASSWORD_SIZE = 32;
        
        public User(ushort iD_owner, ushort iD_group, char[] user_login,string password, bool user_role)
        {
            this.ID_owner = iD_owner;

            this.ID_group = iD_group;

            this.user_login = new char[LOGIN_SIZE];

            for(int i = 0; i < user_login.Length; i++)
            {
                this.user_login[i] =  user_login[i];
            }
            
            this.hash_password = transformPasswordIntoHash(password);

            this.user_role = user_role;
        }

        public User() { }
        
        //ДОБАВИТЬ ПРОВЕКУ НА ПУСТОТУ
        public static char[] transformPasswordIntoHash(string pass)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(pass);

                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                char[] new_pass = new char[32];

                for (byte i = 0; i < 32; i++)
                {
                    new_pass[i] = sb[i];
                }

                return new_pass;
            }
        }
        

        //Запись пользователя в бинарный файл
        public bool binaryWritingToFile(BinaryWriter bw)
        {
            try
            {
                bw.Write(this.ID_owner);
                bw.Write(this.ID_group);
                bw.Write(Converter.convertFromCharIntoBytes(this.user_login));//Кодировка русских символов
                bw.Write(Converter.convertFromCharIntoBytes(this.hash_password));
                bw.Write(this.user_role);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
                return false;
            }
        }

        //Загрузка информации о пользователе из файла
        public static User loadUserFromBinaryFile(BinaryReader reader)
        {
            User user = new User();

            try
            {
                user.ID_owner = reader.ReadUInt16();

                user.ID_group = reader.ReadUInt16();

                byte[] login = reader.ReadBytes(LOGIN_SIZE);

                user.user_login = Converter.convertFromBytesIntoChar(login);

                byte[] hash = reader.ReadBytes(PASSWORD_SIZE);

                user.hash_password = Converter.convertFromBytesIntoChar(hash);

                user.user_role = reader.ReadBoolean();
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
            }
            return user;
        }

    }
}
