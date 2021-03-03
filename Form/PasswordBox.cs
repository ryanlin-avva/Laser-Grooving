using System;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    public partial class PasswordBox : System.Windows.Forms.Form
    {
        public PasswordBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_password.Text == "1234")
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
