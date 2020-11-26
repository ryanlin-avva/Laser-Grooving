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
    public partial class KeyBoardForm : Form
    {
        public KeyBoardForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void b0_Click(object sender, EventArgs e)
        {
            if(T.Text == "0") { T.Text = ""; }
            T.Text += ((Button)sender).Text;
        }

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            this.b1.Click += new System.EventHandler(this.b0_Click);
            this.b2.Click += new System.EventHandler(this.b0_Click);
            this.b3.Click += new System.EventHandler(this.b0_Click);
            this.b4.Click += new System.EventHandler(this.b0_Click);
            this.b5.Click += new System.EventHandler(this.b0_Click);
            this.b6.Click += new System.EventHandler(this.b0_Click);
            this.b7.Click += new System.EventHandler(this.b0_Click);
            this.b8.Click += new System.EventHandler(this.b0_Click);
            this.b9.Click += new System.EventHandler(this.b0_Click);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            T.Text = "0";
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            String S = T.Text;
            if(S.Length > 1)
            {
                T.Text = (int.Parse(S.Substring(0, S.Length - 1))).ToString();
            }
            else
            {
                T.Text = "0";
            }
        }

        private void bEnter_Click(object sender, EventArgs e)
        {

        }
    }
}
