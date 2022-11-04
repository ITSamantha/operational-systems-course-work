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
    public partial class entryForm : Form
    {

        public short work_mode { get; set; }

        public entryForm()
        {
            work_mode = -1;

            InitializeComponent();
        }

        private void createFS_B_Click(object sender, EventArgs e)
        {
            setMode(2);
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            setMode(1);//!
        }

        private void entryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (work_mode == -1)
            {
                setMode(0);
            }
        }

        private void setMode(short mode)
        {
            this.work_mode = mode;
            Close();
        }
    
    }
}
