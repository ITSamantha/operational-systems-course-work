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
    public partial class GroupChoose : Form
    {
        public GroupChoose()
        {
            InitializeComponent();
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
