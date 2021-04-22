
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
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrl_ip_address
            // 
            this.ctrl_ip_address.AllowInternalTab = false;
            this.ctrl_ip_address.AutoHeight = true;
            this.ctrl_ip_address.BackColor = System.Drawing.SystemColors.Window;
            this.ctrl_ip_address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrl_ip_address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ctrl_ip_address.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ctrl_ip_address.Location = new System.Drawing.Point(175, 37);
            this.ctrl_ip_address.Margin = new System.Windows.Forms.Padding(2);
            this.ctrl_ip_address.MinimumSize = new System.Drawing.Size(87, 22);
            this.ctrl_ip_address.Name = "ctrl_ip_address";
            this.ctrl_ip_address.ReadOnly = false;
            this.ctrl_ip_address.Size = new System.Drawing.Size(138, 22);
            this.ctrl_ip_address.TabIndex = 0;
            this.ctrl_ip_address.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(43, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "量測相機IP位址";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(62, 164);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(190, 164);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(43, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "設定完成後，需重新啟動APP才能生效";
            // 
            // ConnectionIpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 228);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrl_ip_address);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label label2;
    }
}