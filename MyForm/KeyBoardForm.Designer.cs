namespace Velociraptor.AddOn
{
    partial class KeyBoardForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_01 = new System.Windows.Forms.Button();
            this.btn_10 = new System.Windows.Forms.Button();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.bEnter = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.b0 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.b5 = new System.Windows.Forms.Button();
            this.b6 = new System.Windows.Forms.Button();
            this.b7 = new System.Windows.Forms.Button();
            this.b8 = new System.Windows.Forms.Button();
            this.b9 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_01);
            this.panel1.Controls.Add(this.btn_10);
            this.panel1.Controls.Add(this.tb_result);
            this.panel1.Controls.Add(this.bEnter);
            this.panel1.Controls.Add(this.bClear);
            this.panel1.Controls.Add(this.bBack);
            this.panel1.Controls.Add(this.b0);
            this.panel1.Controls.Add(this.b1);
            this.panel1.Controls.Add(this.b2);
            this.panel1.Controls.Add(this.b3);
            this.panel1.Controls.Add(this.b4);
            this.panel1.Controls.Add(this.b5);
            this.panel1.Controls.Add(this.b6);
            this.panel1.Controls.Add(this.b7);
            this.panel1.Controls.Add(this.b8);
            this.panel1.Controls.Add(this.b9);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 409);
            this.panel1.TabIndex = 0;
            // 
            // btn_01
            // 
            this.btn_01.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_01.Location = new System.Drawing.Point(213, 322);
            this.btn_01.Margin = new System.Windows.Forms.Padding(4);
            this.btn_01.Name = "btn_01";
            this.btn_01.Size = new System.Drawing.Size(80, 65);
            this.btn_01.TabIndex = 16;
            this.btn_01.Text = "*0.1";
            this.btn_01.UseVisualStyleBackColor = true;
            this.btn_01.Click += new System.EventHandler(this.btn_01_Click);
            // 
            // btn_10
            // 
            this.btn_10.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_10.Location = new System.Drawing.Point(125, 322);
            this.btn_10.Margin = new System.Windows.Forms.Padding(4);
            this.btn_10.Name = "btn_10";
            this.btn_10.Size = new System.Drawing.Size(80, 65);
            this.btn_10.TabIndex = 15;
            this.btn_10.Text = "*10";
            this.btn_10.UseVisualStyleBackColor = true;
            this.btn_10.Click += new System.EventHandler(this.btn_10_Click);
            // 
            // tb_result
            // 
            this.tb_result.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_result.Location = new System.Drawing.Point(37, 34);
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(344, 45);
            this.tb_result.TabIndex = 1;
            this.tb_result.Text = "1";
            this.tb_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bEnter
            // 
            this.bEnter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bEnter.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEnter.Location = new System.Drawing.Point(301, 183);
            this.bEnter.Margin = new System.Windows.Forms.Padding(4);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(80, 131);
            this.bEnter.TabIndex = 13;
            this.bEnter.Text = "=";
            this.bEnter.UseVisualStyleBackColor = true;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // bClear
            // 
            this.bClear.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClear.Location = new System.Drawing.Point(301, 322);
            this.bClear.Margin = new System.Windows.Forms.Padding(4);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(80, 65);
            this.bClear.TabIndex = 12;
            this.bClear.Text = "C";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bBack
            // 
            this.bBack.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Image = global::Velociraptor.Properties.Resources.backspace;
            this.bBack.Location = new System.Drawing.Point(301, 110);
            this.bBack.Margin = new System.Windows.Forms.Padding(4);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(80, 65);
            this.bBack.TabIndex = 11;
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // b0
            // 
            this.b0.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b0.Location = new System.Drawing.Point(37, 320);
            this.b0.Margin = new System.Windows.Forms.Padding(4);
            this.b0.Name = "b0";
            this.b0.Size = new System.Drawing.Size(80, 65);
            this.b0.TabIndex = 10;
            this.b0.Text = "0";
            this.b0.UseVisualStyleBackColor = true;
            this.b0.Click += new System.EventHandler(this.Number_Click);
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.Location = new System.Drawing.Point(37, 250);
            this.b1.Margin = new System.Windows.Forms.Padding(4);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(80, 65);
            this.b1.TabIndex = 14;
            this.b1.Text = "1";
            this.b1.UseVisualStyleBackColor = true;
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b2.Location = new System.Drawing.Point(125, 250);
            this.b2.Margin = new System.Windows.Forms.Padding(4);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(80, 65);
            this.b2.TabIndex = 2;
            this.b2.Text = "2";
            this.b2.UseVisualStyleBackColor = true;
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b3.Location = new System.Drawing.Point(213, 250);
            this.b3.Margin = new System.Windows.Forms.Padding(4);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(80, 65);
            this.b3.TabIndex = 7;
            this.b3.Text = "3";
            this.b3.UseVisualStyleBackColor = true;
            // 
            // b4
            // 
            this.b4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b4.Location = new System.Drawing.Point(37, 180);
            this.b4.Margin = new System.Windows.Forms.Padding(4);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(80, 65);
            this.b4.TabIndex = 6;
            this.b4.Text = "4";
            this.b4.UseVisualStyleBackColor = true;
            // 
            // b5
            // 
            this.b5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b5.Location = new System.Drawing.Point(125, 180);
            this.b5.Margin = new System.Windows.Forms.Padding(4);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(80, 65);
            this.b5.TabIndex = 5;
            this.b5.Text = "5";
            this.b5.UseVisualStyleBackColor = true;
            // 
            // b6
            // 
            this.b6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b6.Location = new System.Drawing.Point(213, 180);
            this.b6.Margin = new System.Windows.Forms.Padding(4);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(80, 65);
            this.b6.TabIndex = 4;
            this.b6.Text = "6";
            this.b6.UseVisualStyleBackColor = true;
            // 
            // b7
            // 
            this.b7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b7.Location = new System.Drawing.Point(37, 110);
            this.b7.Margin = new System.Windows.Forms.Padding(4);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(80, 65);
            this.b7.TabIndex = 3;
            this.b7.Text = "7";
            this.b7.UseVisualStyleBackColor = true;
            // 
            // b8
            // 
            this.b8.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b8.Location = new System.Drawing.Point(125, 110);
            this.b8.Margin = new System.Windows.Forms.Padding(4);
            this.b8.Name = "b8";
            this.b8.Size = new System.Drawing.Size(80, 65);
            this.b8.TabIndex = 2;
            this.b8.Text = "8";
            this.b8.UseVisualStyleBackColor = true;
            // 
            // b9
            // 
            this.b9.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b9.Location = new System.Drawing.Point(213, 110);
            this.b9.Margin = new System.Windows.Forms.Padding(4);
            this.b9.Name = "b9";
            this.b9.Size = new System.Drawing.Size(80, 65);
            this.b9.TabIndex = 1;
            this.b9.Text = "9";
            this.b9.UseVisualStyleBackColor = true;
            // 
            // KeyBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 420);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KeyBoardForm";
            this.Text = "KeyBoardForm";
            this.Load += new System.EventHandler(this.KeyBoardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button b0;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button b5;
        private System.Windows.Forms.Button b6;
        private System.Windows.Forms.Button b7;
        private System.Windows.Forms.Button b8;
        private System.Windows.Forms.Button b9;
        private System.Windows.Forms.Button bEnter;
        public System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.Button btn_01;
        private System.Windows.Forms.Button btn_10;
    }
}