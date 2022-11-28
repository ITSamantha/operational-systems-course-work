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
    public partial class GroupWork : Form
    {
        public GroupWork(byte mode)
        {
            InitializeComponent();

            Text = mode == 0 ? "Samantha:Создать группу" : "Samantha:Редактировать группу";

            enter_B.Text = mode == 0 ? "Создать" : "Редактировать";
        }

        private void enter_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancel_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
