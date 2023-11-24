using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseWorkOS
{
    public partial class FileInformation : Form
    {
        public FileInformation()
        {
            InitializeComponent();
        }

        private void ok_B_Click(object sender, EventArgs e)
        {
            if (file_name_TB.Text != String.Empty)
            {
                //РЕГУЛЯРНОЕ ВЫРАЖЕНИЕ НА РАСШИРЕНИЕ
                DialogResult = file_name_TB.Text.Contains('.') ? DialogResult.Yes : DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Поле \"Название файла\"не может быть пустым");
            }
        }

        private void cancel_B_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
