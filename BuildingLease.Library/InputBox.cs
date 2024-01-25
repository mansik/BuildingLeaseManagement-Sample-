using System;
using System.Windows.Forms;

namespace BuildingLease.Library
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            AppConfig.DbPassword = passwordTextBox.Text.Trim();
        }
    }
}
