namespace Velociraptor.Form
{
    partial class AutoParamsForm
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
            this.label_current_position = new System.Windows.Forms.Label();
            this.cmb_mea_points = new System.Windows.Forms.ComboBox();
            this.lb_row1 = new System.Windows.Forms.Label();
            this.lb_col1 = new System.Windows.Forms.Label();
            this.tb_mea_row1 = new System.Windows.Forms.TextBox();
            this.tb_mea_col1 = new System.Windows.Forms.TextBox();
            this.tb_mea_col2 = new System.Windows.Forms.TextBox();
            this.tb_mea_row2 = new System.Windows.Forms.TextBox();
            this.lb_col2 = new System.Windows.Forms.Label();
            this.lb_row2 = new System.Windows.Forms.Label();
            this.cmb_notch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_col_count = new System.Windows.Forms.TextBox();
            this.tb_row_count = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_wafer_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_current_position
            // 
            this.label_current_position.AutoSize = true;
            this.label_current_position.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_current_position.Location = new System.Drawing.Point(55, 229);
            this.label_current_position.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_current_position.Name = "label_current_position";
            this.label_current_position.Size = new System.Drawing.Size(112, 25);
            this.label_current_position.TabIndex = 104;
            this.label_current_position.Text = "測量點設定";
            // 
            // cmb_mea_points
            // 
            this.cmb_mea_points.FormattingEnabled = true;
            this.cmb_mea_points.Items.AddRange(new object[] {
            "1點",
            "5點",
            "9點"});
            this.cmb_mea_points.Location = new System.Drawing.Point(59, 271);
            this.cmb_mea_points.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_mea_points.Name = "cmb_mea_points";
            this.cmb_mea_points.Size = new System.Drawing.Size(121, 23);
            this.cmb_mea_points.TabIndex = 110;
            this.cmb_mea_points.SelectedIndexChanged += new System.EventHandler(this.cmb_mea_points_SelectedIndexChanged);
            // 
            // lb_row1
            // 
            this.lb_row1.AutoSize = true;
            this.lb_row1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_row1.Location = new System.Drawing.Point(236, 229);
            this.lb_row1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_row1.Name = "lb_row1";
            this.lb_row1.Size = new System.Drawing.Size(66, 25);
            this.lb_row1.TabIndex = 107;
            this.lb_row1.Text = "Row1";
            // 
            // lb_col1
            // 
            this.lb_col1.AutoSize = true;
            this.lb_col1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_col1.Location = new System.Drawing.Point(319, 229);
            this.lb_col1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_col1.Name = "lb_col1";
            this.lb_col1.Size = new System.Drawing.Size(56, 25);
            this.lb_col1.TabIndex = 108;
            this.lb_col1.Text = "Col1";
            // 
            // tb_mea_row1
            // 
            this.tb_mea_row1.Location = new System.Drawing.Point(236, 270);
            this.tb_mea_row1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_mea_row1.Name = "tb_mea_row1";
            this.tb_mea_row1.Size = new System.Drawing.Size(75, 25);
            this.tb_mea_row1.TabIndex = 111;
            // 
            // tb_mea_col1
            // 
            this.tb_mea_col1.Location = new System.Drawing.Point(317, 270);
            this.tb_mea_col1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_mea_col1.Name = "tb_mea_col1";
            this.tb_mea_col1.Size = new System.Drawing.Size(75, 25);
            this.tb_mea_col1.TabIndex = 112;
            // 
            // tb_mea_col2
            // 
            this.tb_mea_col2.Location = new System.Drawing.Point(508, 270);
            this.tb_mea_col2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_mea_col2.Name = "tb_mea_col2";
            this.tb_mea_col2.Size = new System.Drawing.Size(75, 25);
            this.tb_mea_col2.TabIndex = 114;
            this.tb_mea_col2.Visible = false;
            // 
            // tb_mea_row2
            // 
            this.tb_mea_row2.Location = new System.Drawing.Point(427, 270);
            this.tb_mea_row2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_mea_row2.Name = "tb_mea_row2";
            this.tb_mea_row2.Size = new System.Drawing.Size(75, 25);
            this.tb_mea_row2.TabIndex = 113;
            this.tb_mea_row2.Visible = false;
            // 
            // lb_col2
            // 
            this.lb_col2.AutoSize = true;
            this.lb_col2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_col2.Location = new System.Drawing.Point(508, 229);
            this.lb_col2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_col2.Name = "lb_col2";
            this.lb_col2.Size = new System.Drawing.Size(56, 25);
            this.lb_col2.TabIndex = 112;
            this.lb_col2.Text = "Col2";
            this.lb_col2.Visible = false;
            // 
            // lb_row2
            // 
            this.lb_row2.AutoSize = true;
            this.lb_row2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_row2.Location = new System.Drawing.Point(427, 229);
            this.lb_row2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_row2.Name = "lb_row2";
            this.lb_row2.Size = new System.Drawing.Size(66, 25);
            this.lb_row2.TabIndex = 111;
            this.lb_row2.Text = "Row2";
            this.lb_row2.Visible = false;
            // 
            // cmb_notch
            // 
            this.cmb_notch.FormattingEnabled = true;
            this.cmb_notch.Items.AddRange(new object[] {
            "上",
            "下",
            "左",
            "右"});
            this.cmb_notch.Location = new System.Drawing.Point(185, 169);
            this.cmb_notch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_notch.Name = "cmb_notch";
            this.cmb_notch.Size = new System.Drawing.Size(121, 23);
            this.cmb_notch.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(55, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 25);
            this.label5.TabIndex = 115;
            this.label5.Text = "Notch方向";
            // 
            // tb_col_count
            // 
            this.tb_col_count.Location = new System.Drawing.Point(312, 99);
            this.tb_col_count.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_col_count.Name = "tb_col_count";
            this.tb_col_count.Size = new System.Drawing.Size(49, 25);
            this.tb_col_count.TabIndex = 108;
            // 
            // tb_row_count
            // 
            this.tb_row_count.Location = new System.Drawing.Point(185, 99);
            this.tb_row_count.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_row_count.Name = "tb_row_count";
            this.tb_row_count.Size = new System.Drawing.Size(49, 25);
            this.tb_row_count.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(368, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 120;
            this.label6.Text = "Columns";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(241, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 119;
            this.label7.Text = "Rows";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(55, 99);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 25);
            this.label8.TabIndex = 117;
            this.label8.Text = "Die行列數";
            // 
            // tb_wafer_id
            // 
            this.tb_wafer_id.Location = new System.Drawing.Point(185, 36);
            this.tb_wafer_id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_wafer_id.Name = "tb_wafer_id";
            this.tb_wafer_id.Size = new System.Drawing.Size(152, 25);
            this.tb_wafer_id.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(55, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 25);
            this.label9.TabIndex = 123;
            this.label9.Text = "Wafer ID";
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(59, 346);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(119, 51);
            this.btn_ok.TabIndex = 115;
            this.btn_ok.Text = "確定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(219, 346);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(119, 51);
            this.btn_cancel.TabIndex = 160;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // AutoParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 425);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tb_wafer_id);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_col_count);
            this.Controls.Add(this.tb_row_count);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_notch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_mea_col2);
            this.Controls.Add(this.tb_mea_row2);
            this.Controls.Add(this.lb_col2);
            this.Controls.Add(this.lb_row2);
            this.Controls.Add(this.tb_mea_col1);
            this.Controls.Add(this.tb_mea_row1);
            this.Controls.Add(this.lb_col1);
            this.Controls.Add(this.lb_row1);
            this.Controls.Add(this.cmb_mea_points);
            this.Controls.Add(this.label_current_position);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AutoParamsForm";
            this.Text = "自動量測參數設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_current_position;
        public System.Windows.Forms.ComboBox cmb_mea_points;
        private System.Windows.Forms.Label lb_row1;
        private System.Windows.Forms.Label lb_col1;
        public System.Windows.Forms.TextBox tb_mea_row1;
        public System.Windows.Forms.TextBox tb_mea_col1;
        public System.Windows.Forms.TextBox tb_mea_col2;
        public System.Windows.Forms.TextBox tb_mea_row2;
        private System.Windows.Forms.Label lb_col2;
        private System.Windows.Forms.Label lb_row2;
        public System.Windows.Forms.ComboBox cmb_notch;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tb_col_count;
        public System.Windows.Forms.TextBox tb_row_count;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tb_wafer_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}