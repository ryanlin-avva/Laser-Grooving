using System.Drawing;

namespace Velociraptor.MyForm
{
    public partial class Splash : System.Windows.Forms.Form
    {
        public Splash()
        {
            InitializeComponent();
            pic_avva.Controls.Add(pic_loading);
            pic_loading.BackColor = Color.Transparent;

        }
    }
}
