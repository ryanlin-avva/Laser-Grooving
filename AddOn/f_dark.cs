using System;
using System.Windows.Forms;

//#if (_CLS_CALIBRATION_BENCH)
//namespace ClsCalibrationBench.Ihm
//#elif (_MPS_CALIBRATION_BENCH)
//namespace MpsCalibrationBench.Ihm
//#elif (_CLS) && (!_CLS_CALIBRATION_BENCH)
//namespace MagicAddOn
//#elif (_MPS) && (!_MPS_CALIBRATION_BENCH)
//namespace MpsAddOn
//#else
namespace AddOn
//#endif
{
    public partial class f_dark : Form
    {
        #region Constructor
        public f_dark()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void f_dark_Load(object sender, EventArgs e)
        {
            string str = "";
            str += "Dark reference will take place immedialtely after clicking 'Take Reference' button.";
            str += "Before this operation, please make sure that the measuring unit has reached its operating temperature (after switched on takes about 10 minutes).";
            str += "Also please observe that there is NO target object within the measuring range of the optical probe. And the optical probe must not be directed straight towards a light source.";
            txt_info.Text = str;
            this.Text = "Dark Informations";
        }
        #endregion
    }
}
