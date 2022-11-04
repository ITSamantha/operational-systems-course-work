using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkOS
{
    public partial class UserForm : Form
    {
        public UserForm(byte mode)
        {
            InitializeComponent();

            this.Text = mode == 0 ? "Samantha: Регистрация пользователя" : "Samantha: Авторизация пользователя";
         
            this.enterFS_B.Text = mode == 0 ? "Регистрация" : "Авторизация пользователя";
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancel_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;//
        }
    }
}
