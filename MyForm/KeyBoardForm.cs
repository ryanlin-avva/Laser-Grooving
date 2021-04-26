using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Velociraptor.AddOn
{
    public partial class KeyBoardForm : System.Windows.Forms.Form
    {
        public KeyBoardForm()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, EventArgs e)
        {
            if(tb_result.Text == "0") { tb_result.Text = ""; }
            tb_result.Text += ((Button)sender).Text;
        }

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            this.b1.Click += new System.EventHandler(this.Number_Click);
            this.b2.Click += new System.EventHandler(this.Number_Click);
            this.b3.Click += new System.EventHandler(this.Number_Click);
            this.b4.Click += new System.EventHandler(this.Number_Click);
            this.b5.Click += new System.EventHandler(this.Number_Click);
            this.b6.Click += new System.EventHandler(this.Number_Click);
            this.b7.Click += new System.EventHandler(this.Number_Click);
            this.b8.Click += new System.EventHandler(this.Number_Click);
            this.b9.Click += new System.EventHandler(this.Number_Click);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tb_result.Text = "0";
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            int s = int.Parse(tb_result.Text) / 10;
            tb_result.Text = s.ToString();
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            int s = int.Parse(tb_result.Text) * 10;
            tb_result.Text = s.ToString();
        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            int s = int.Parse(tb_result.Text) / 10;
            tb_result.Text = s.ToString();
        }
    }
}
