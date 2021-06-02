using System;
using System.Windows.Forms;
using static Velociraptor.SynOperation;

namespace Velociraptor.Form
{
    public partial class AutoParamsForm : System.Windows.Forms.Form
    {
        #region notch direction
        public enum eNotchWay
        {
            UP
            , DOWN
            , LEFT
            , RIGHT
        }
        #endregion
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
            if (tb_wafer_id.Text == "")
            {
                MessageBox.Show("wafer id沒有設定");
                return;
            }
            if (tb_row_count.Text == "" || tb_col_count.Text == "")
            {
                MessageBox.Show("die的行/列數沒有設定");
                return;
            }
            if ((tb_mea_row1.Visible && tb_mea_row1.Text=="")
                || (tb_mea_row1.Visible && tb_mea_row1.Text == "")
                || (tb_mea_col1.Visible && tb_mea_col1.Text == "")
                || (tb_mea_row2.Visible && tb_mea_row2.Text == "")
                || (tb_mea_col2.Visible && tb_mea_col2.Text == ""))
            {
                MessageBox.Show("量測位置沒有設定");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
