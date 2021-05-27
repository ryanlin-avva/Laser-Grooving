
namespace Velociraptor.MyForm
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.pic_avva = new System.Windows.Forms.PictureBox();
            this.pic_loading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_avva
            // 
            this.pic_avva.Image = ((System.Drawing.Image)(resources.GetObject("pic_avva.Image")));
            this.pic_avva.Location = new System.Drawing.Point(0, 2);
            this.pic_avva.Name = "pic_avva";
            this.pic_avva.Size = new System.Drawing.Size(2004, 708);
            this.pic_avva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_avva.TabIndex = 0;
            this.pic_avva.TabStop = false;
            // 
            // pic_loading
            // 
            this.pic_loading.BackColor = System.Drawing.Color.Transparent;
            this.pic_loading.Image = ((System.Drawing.Image)(resources.GetObject("pic_loading.Image")));
            this.pic_loading.Location = new System.Drawing.Point(1672, 594);
            this.pic_loading.Name = "pic_loading";
            this.pic_loading.Size = new System.Drawing.Size(332, 116);
            this.pic_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_loading.TabIndex = 1;
            this.pic_loading.TabStop = false;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2007, 710);
            this.Controls.Add(this.pic_loading);
            this.Controls.Add(this.pic_avva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.Text = "AVVA";
            ((System.ComponentModel.ISupportInitialize)(this.pic_avva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_avva;
        private System.Windows.Forms.PictureBox pic_loading;
    }
}