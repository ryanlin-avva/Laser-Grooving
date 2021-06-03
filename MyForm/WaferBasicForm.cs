
using System.Windows.Forms;
using static Velociraptor.SynOperation;

namespace Velociraptor.MyForm
{
    public partial class WaferBasicForm : System.Windows.Forms.Form
    {
        WaferInfo _wafer;
        public WaferBasicForm(WaferInfo wafer)
        {
            InitializeComponent();
            _wafer = wafer;
            tb_waferid.Text = "";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (num_dieX.Value==0 || num_dieY.Value == 0)
            {
                MessageBox.Show("請輸入正確的Die邊長");
                return;
            }
            if (tb_waferid.Text == "")
            {
                MessageBox.Show("請輸入Wafer ID");
                return;
            }
            _wafer.Die_sizeX = (double)num_dieX.Value;
            _wafer.Die_sizeY = (double)num_dieY.Value;
            _wafer.Measure_distance = int.Parse(cb_SelectMeasureDistance.Text);
            _wafer.Scan_type = (cb_selectMeasurePrecision.SelectedIndex == 0)
                                ? eScanType.Scan1Um : eScanType.Scan5Um;
            _wafer.Wafer_type = (cb_wafersize.SelectedIndex == 0) ? 12 : 8;
            _wafer.Wafer_ID = tb_waferid.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void WaferBasicForm_Load(object sender, System.EventArgs e)
        {
            cb_SelectMeasureDistance.SelectedIndex = 0;
            cb_wafersize.SelectedIndex = 0;
            cb_selectMeasurePrecision.SelectedIndex = 0;
        }
    }
    public class WaferInfo
    {
        public double Die_sizeX { get; set; }
        public double Die_sizeY { get; set; }
        public int Measure_distance { get; set; }
        public eScanType Scan_type { get; set; }
        public int Wafer_type { get; set; }
        public string Wafer_ID { get; set; }
    }

}
