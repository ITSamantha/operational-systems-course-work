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
    public partial class SystemCreationParams : Form
    {
        public SystemCreationParams()
        {
            InitializeComponent();

            value_label.Text = "5 Мб";

            FS_size.Value = FS_size.Minimum;

            cluster_size_CB.SelectedIndex = 0;
        }

        private void FS_size_ValueChanged(object sender, EventArgs e)
        {
            value_label.Text = FS_size.Value.ToString()+" Мб";
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;//
        }
    }
}
