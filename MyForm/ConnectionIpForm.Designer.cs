
namespace Velociraptor.MyForm
{
    partial class ConnectionIpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrl_ip_address = new MagicGraphicLibrary.IPAddressControl();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrl_ip_address
            // 
            this.ctrl_ip_address.AllowInternalTab = false;
            this.ctrl_ip_address.AutoHeight = true;
            this.ctrl_ip_address.BackColor = System.Drawing.SystemColors.Window;
            this.ctrl_ip_address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrl_ip_address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ctrl_ip_address.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.ctrl_ip_address.Location = new System.Drawing.Point(233, 46);
            this.ctrl_ip_address.MinimumSize = new System.Drawing.Size(165, 34);
            this.ctrl_ip_address.Name = "ctrl_ip_address";
            this.ctrl_ip_address.ReadOnly = false;
            this.ctrl_ip_address.Size = new System.Drawing.Size(165, 34);
            this.ctrl_ip_address.TabIndex = 0;
            this.ctrl_ip_address.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(57, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "量測相機IP位址";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(81, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(252, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConnectionIpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 285);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrl_ip_address);
            this.Name = "ConnectionIpForm";
            this.Text = "ConnectionParam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MagicGraphicLibrary.IPAddressControl ctrl_ip_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}