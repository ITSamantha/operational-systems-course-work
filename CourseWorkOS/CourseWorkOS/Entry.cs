using System;
using System.Windows.Forms;

namespace CourseWorkOS
{
    public partial class entryForm : Form
    {

        public entryForm()
        {
            InitializeComponent();
        }

        private void createFS_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        
    }
}
