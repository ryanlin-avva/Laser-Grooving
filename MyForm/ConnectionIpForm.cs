namespace Velociraptor.MyForm
{
    using System.Windows.Forms;

    public partial class ConnectionIpForm : System.Windows.Forms.Form
    {
        public ConnectionIpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
