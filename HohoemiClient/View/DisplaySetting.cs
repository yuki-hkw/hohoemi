using System;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class DisplaySetting : Form
    {
        public Screen SelectedScreen { set; get; }

        public DisplaySetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
