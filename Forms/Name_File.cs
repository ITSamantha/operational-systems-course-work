﻿using System;
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
    public partial class Name_File : Form
    {
        public Name_File()
        {
            InitializeComponent();
        }
        
        private void ok_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
        }

        private void cancel_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
