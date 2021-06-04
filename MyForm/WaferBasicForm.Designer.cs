
namespace Velociraptor.MyForm
{
    partial class WaferBasicForm
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
            this.label41 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cb_selectMeasurePrecision = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_SelectMeasureDistance = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.cb_wafersize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.num_dieX = new System.Windows.Forms.NumericUpDown();
            this.num_dieY = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_waferid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_dieX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_dieY)).BeginInit();
            this.SuspendLayout();
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label41.Location = new System.Drawing.Point(308, 50);
            this.label41.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(137, 33);
            this.label41.TabIndex = 163;
            this.label41.Text = "die X 邊長";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(654, 154);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 33);
            this.label15.TabIndex = 197;
            this.label15.Text = "um";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label35.Location = new System.Drawing.Point(542, 50);
            this.label35.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(119, 33);
            this.label35.TabIndex = 122;
            this.label35.Text = "掃描距離";
            // 
            // cb_selectMeasurePrecision
            // 
            this.cb_selectMeasurePrecision.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.cb_selectMeasurePrecision.FormattingEnabled = true;
            this.cb_selectMeasurePrecision.Items.AddRange(new object[] {
            "1",
            "5"});
            this.cb_selectMeasurePrecision.Location = new System.Drawing.Point(550, 154);
            this.cb_selectMeasurePrecision.Margin = new System.Windows.Forms.Padding(7);
            this.cb_selectMeasurePrecision.Name = "cb_selectMeasurePrecision";
            this.cb_selectMeasurePrecision.Size = new System.Drawing.Size(100, 41);
            this.cb_selectMeasurePrecision.TabIndex = 195;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label44.Location = new System.Drawing.Point(448, 154);
            this.label44.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 33);
            this.label44.TabIndex = 168;
            this.label44.Text = "um";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(540, 132);
            this.label17.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 33);
            this.label17.TabIndex = 196;
            this.label17.Text = "掃描精度";
            // 
            // cb_SelectMeasureDistance
            // 
            this.cb_SelectMeasureDistance.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.cb_SelectMeasureDistance.FormattingEnabled = true;
            this.cb_SelectMeasureDistance.Items.AddRange(new object[] {
            "1000",
            "2000",
            "100",
            "200",
            "500"});
            this.cb_SelectMeasureDistance.Location = new System.Drawing.Point(548, 76);
            this.cb_SelectMeasureDistance.Margin = new System.Windows.Forms.Padding(7);
            this.cb_SelectMeasureDistance.Name = "cb_SelectMeasureDistance";
            this.cb_SelectMeasureDistance.Size = new System.Drawing.Size(102, 41);
            this.cb_SelectMeasureDistance.TabIndex = 121;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label43.Location = new System.Drawing.Point(450, 76);
            this.label43.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 33);
            this.label43.TabIndex = 167;
            this.label43.Text = "um";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label42.Location = new System.Drawing.Point(306, 132);
            this.label42.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(136, 33);
            this.label42.TabIndex = 164;
            this.label42.Text = "die Y 邊長";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label39.Location = new System.Drawing.Point(654, 76);
            this.label39.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 33);
            this.label39.TabIndex = 169;
            this.label39.Text = "um";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label40.Location = new System.Drawing.Point(52, 132);
            this.label40.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(119, 33);
            this.label40.TabIndex = 184;
            this.label40.Text = "晶圓尺寸";
            // 
            // cb_wafersize
            // 
            this.cb_wafersize.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.cb_wafersize.FormattingEnabled = true;
            this.cb_wafersize.Items.AddRange(new object[] {
            "12",
            "8"});
            this.cb_wafersize.Location = new System.Drawing.Point(55, 154);
            this.cb_wafersize.Margin = new System.Windows.Forms.Padding(7);
            this.cb_wafersize.Name = "cb_wafersize";
            this.cb_wafersize.Size = new System.Drawing.Size(159, 41);
            this.cb_wafersize.TabIndex = 183;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(218, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 33);
            this.label3.TabIndex = 185;
            this.label3.Text = "吋";
            // 
            // num_dieX
            // 
            this.num_dieX.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.num_dieX.Location = new System.Drawing.Point(312, 76);
            this.num_dieX.Margin = new System.Windows.Forms.Padding(4);
            this.num_dieX.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.num_dieX.Name = "num_dieX";
            this.num_dieX.Size = new System.Drawing.Size(133, 42);
            this.num_dieX.TabIndex = 198;
            // 
            // num_dieY
            // 
            this.num_dieY.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.num_dieY.Location = new System.Drawing.Point(312, 154);
            this.num_dieY.Margin = new System.Windows.Forms.Padding(4);
            this.num_dieY.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.num_dieY.Name = "num_dieY";
            this.num_dieY.Size = new System.Drawing.Size(133, 42);
            this.num_dieY.TabIndex = 199;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(209, 231);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 54);
            this.button1.TabIndex = 200;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(381, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 54);
            this.button2.TabIndex = 201;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(54, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 33);
            this.label2.TabIndex = 203;
            this.label2.Text = "晶圓ID";
            // 
            // tb_waferid
            // 
            this.tb_waferid.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb_waferid.Location = new System.Drawing.Point(55, 76);
            this.tb_waferid.Name = "tb_waferid";
            this.tb_waferid.Size = new System.Drawing.Size(159, 42);
            this.tb_waferid.TabIndex = 204;
            // 
            // WaferBasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 320);
            this.Controls.Add(this.tb_waferid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.num_dieY);
            this.Controls.Add(this.num_dieX);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_selectMeasurePrecision);
            this.Controls.Add(this.cb_wafersize);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cb_SelectMeasureDistance);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label42);
            this.Font = new System.Drawing.Font("PMingLiU", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WaferBasicForm";
            this.Text = "WaferBasicForm";
            this.Load += new System.EventHandler(this.WaferBasicForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_dieX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_dieY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cb_selectMeasurePrecision;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cb_SelectMeasureDistance;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cb_wafersize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_dieX;
        private System.Windows.Forms.NumericUpDown num_dieY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_waferid;
    }
}