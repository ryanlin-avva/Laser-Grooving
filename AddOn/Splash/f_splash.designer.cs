#if (_CLS)
namespace MagicAddOn
#elif (_MPS)
namespace MpsAddOn
#else
namespace AddOn
#endif
{
    partial class f_splash
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
            this.lbl_action = new System.Windows.Forms.Label();
            this.pgb_load = new System.Windows.Forms.ProgressBar();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.lbl_starting = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_action
            // 
            this.lbl_action.Location = new System.Drawing.Point(11, 157);
            this.lbl_action.Name = "lbl_action";
            this.lbl_action.Size = new System.Drawing.Size(314, 13);
            this.lbl_action.TabIndex = 0;
            // 
            // pgb_load
            // 
            this.pgb_load.Location = new System.Drawing.Point(11, 173);
            this.pgb_load.Name = "pgb_load";
            this.pgb_load.Size = new System.Drawing.Size(315, 23);
            this.pgb_load.TabIndex = 1;
            // 
            // pic_logo
            // 
            this.pic_logo.Location = new System.Drawing.Point(112, 12);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(141, 108);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_logo.TabIndex = 2;
            this.pic_logo.TabStop = false;
            // 
            // lbl_starting
            // 
            this.lbl_starting.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_starting.Location = new System.Drawing.Point(11, 49);
            this.lbl_starting.Name = "lbl_starting";
            this.lbl_starting.Size = new System.Drawing.Size(315, 33);
            this.lbl_starting.TabIndex = 3;
            this.lbl_starting.Text = "Application is starting...";
            this.lbl_starting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_version
            // 
            this.lbl_version.Location = new System.Drawing.Point(11, 135);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(314, 13);
            this.lbl_version.TabIndex = 0;
            // 
            // f_splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 210);
            this.Controls.Add(this.lbl_starting);
            this.Controls.Add(this.pic_logo);
            this.Controls.Add(this.pgb_load);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.lbl_action);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_splash";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f_splash_FormClosed);
            this.Load += new System.EventHandler(this.f_splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_action;
        private System.Windows.Forms.ProgressBar pgb_load;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Label lbl_starting;
        private System.Windows.Forms.Label lbl_version;
    }
}