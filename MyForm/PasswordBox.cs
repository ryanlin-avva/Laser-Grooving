using System;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    public partial class PasswordBox : System.Windows.Forms.Form
    {
        private string _passwd;
        public PasswordBox(string pass)
        {
            _passwd = pass;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_password.Text == _passwd)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }

    }
}
