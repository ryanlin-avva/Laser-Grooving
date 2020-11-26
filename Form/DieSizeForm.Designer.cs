namespace Velociraptor
{
    partial class DieSizeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.die_x_length = new System.Windows.Forms.TextBox();
            this.die_y_length = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "請輸入Die尺寸";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(67, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "x軸橫向長度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(67, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "y軸縱向長度";
            // 
            // die_x_length
            // 
            this.die_x_length.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.die_x_length.Location = new System.Drawing.Point(88, 97);
            this.die_x_length.Name = "die_x_length";
            this.die_x_length.Size = new System.Drawing.Size(189, 52);
            this.die_x_length.TabIndex = 3;
            this.die_x_length.Text = "0";
            this.die_x_length.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // die_y_length
            // 
            this.die_y_length.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.die_y_length.Location = new System.Drawing.Point(88, 192);
            this.die_y_length.Name = "die_y_length";
            this.die_y_length.Size = new System.Drawing.Size(189, 52);
            this.die_y_length.TabIndex = 4;
            this.die_y_length.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(283, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "um";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(283, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 37);
            this.label5.TabIndex = 6;
            this.label5.Text = "um";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(100, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 49);
            this.button1.TabIndex = 7;
            this.button1.Text = "下一步";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DieSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 335);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.die_y_length);
            this.Controls.Add(this.die_x_length);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DieSizeForm";
            this.Text = "DieSizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox die_x_length;
        public System.Windows.Forms.TextBox die_y_length;
    }
}