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
    public partial class ProcessForm : Form
    {
        public User user;


        public ProcessForm()
        {
            InitializeComponent();
        }

        public void loadUser(User user)
        {
            this.user = user;
        }

        private void add_processB_Click(object sender, EventArgs e)
        {

        }
    }
}
