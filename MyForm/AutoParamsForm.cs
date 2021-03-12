using System;
using System.Windows.Forms;

namespace Velociraptor.Form
{
    public partial class AutoParamsForm : System.Windows.Forms.Form
    {
        public AutoParamsForm()
        {
            InitializeComponent();
            cmb_mea_points.SelectedIndex = 1; //5 points measurement
            cmb_notch.SelectedIndex = 1; //DOWN
        }

        private void cmb_mea_points_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_mea_points.SelectedIndex)
            {
                case 0:
                    lb_col1.Visible = false;
                    lb_row1.Visible = false;
                    tb_mea_row1.Visible = false;
                    tb_mea_col1.Visible = false;

                    lb_col2.Visible = false;
                    lb_row2.Visible = false;
                    tb_mea_row2.Visible = false;
                    tb_mea_col2.Visible = false;
                    break;
                case 1:
                    lb_col1.Visible = true;
                    lb_row1.Visible = true;
                    tb_mea_row1.Visible = true;
                    tb_mea_col1.Visible = true;

                    lb_col2.Visible = false;
                    lb_row2.Visible = false;
                    tb_mea_row2.Visible = false;
                    tb_mea_col2.Visible = false;
                    break;
                case 2:
                    lb_col1.Visible = true;
                    lb_row1.Visible = true;
                    tb_mea_row1.Visible = true;
                    tb_mea_col1.Visible = true;

                    lb_col2.Visible = true;
                    lb_row2.Visible = true;
                    tb_mea_row2.Visible = true;
                    tb_mea_col2.Visible = true;
                    break;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
