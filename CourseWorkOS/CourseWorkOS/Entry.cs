using System;
using System.Windows.Forms;

namespace CourseWorkOS
{
    public partial class entryForm : Form
    {

        public short work_mode { get; set; } = NO_FS_MODE;

        public const byte CREATE_FS_MODE = 2;

        public const byte ENTER_FS_MODE = 1;

        public const short NO_FS_MODE = -1;

        public const byte EXIT_FS_MODE = 0;

        public entryForm()
        {
            InitializeComponent();
        }

        private void createFS_B_Click(object sender, EventArgs e)
        {
            setMode(CREATE_FS_MODE);
        }

        private void enterFS_B_Click(object sender, EventArgs e)
        {
            setMode(ENTER_FS_MODE);
        }

        private void entryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (work_mode == NO_FS_MODE)
            {
                setMode(EXIT_FS_MODE);
            }
        }

        private void setMode(short mode)
        {
            this.work_mode = mode;

            Close();
        }
    
    }
}
