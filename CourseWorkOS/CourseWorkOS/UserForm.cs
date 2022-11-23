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

            if (mode != 3)
            {
                this.Text = mode == 0 ? "Samantha: Регистрация пользователя" : "Samantha: Авторизация пользователя";
                this.enterFS_B.Text = mode == 0 ? "Регистрация" : "Авторизация пользователя";
                this.groupBox3.Visible = mode == 0  ? true : false;
            }
           
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancel_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
        
        private void login_TB_Leave(object sender, EventArgs e)
        {
            comboBox1.Text = login_TB.Text;
        }
    }
}
