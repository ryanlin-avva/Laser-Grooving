namespace Velociraptor
{
    partial class f_main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_main));
            this.sfd_upload = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp_jog = new System.Windows.Forms.GroupBox();
            this.btn_JOG_Stop = new System.Windows.Forms.Button();
            this.btn_JOG_Negative_Start = new System.Windows.Forms.Button();
            this.btn_origin_return = new System.Windows.Forms.Button();
            this.btn_PosingStop = new System.Windows.Forms.Button();
            this.btn_JOG_Positive_Start = new System.Windows.Forms.Button();
            this.grp_align_test = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.lb_die_side1 = new System.Windows.Forms.Label();
            this.lb_angle1 = new System.Windows.Forms.Label();
            this.btn_find_angle = new System.Windows.Forms.Button();
            this.btn_align = new System.Windows.Forms.Button();
            this.btn_start_mea = new System.Windows.Forms.Button();
            this.grp_test = new System.Windows.Forms.GroupBox();
            this.btn_autofocus = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ntb_x_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_y_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_z_cur_motorpos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ntb_r_cur_motorpos = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_move = new System.Windows.Forms.GroupBox();
            this.btn_movez_negative = new System.Windows.Forms.Button();
            this.btn_movez_positive = new System.Windows.Forms.Button();
            this.btn_movey_positive = new System.Windows.Forms.Button();
            this.btn_movey_negative = new System.Windows.Forms.Button();
            this.btn_movex_positive = new System.Windows.Forms.Button();
            this.btn_movex_negative = new System.Windows.Forms.Button();
            this.btn_move_distance = new System.Windows.Forms.Button();
            this.btn_move_distance_z = new System.Windows.Forms.Button();
            this.btn_moveR_ccw = new System.Windows.Forms.Button();
            this.btn_moveR_cw = new System.Windows.Forms.Button();
            this.btn_move_distance_r = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_threshold = new System.Windows.Forms.Button();
            this.btn_light = new System.Windows.Forms.Button();
            this.btn_advanced_mode = new System.Windows.Forms.Button();
            this.btn_ClearAlarm = new System.Windows.Forms.Button();
            this.tbLight = new System.Windows.Forms.TextBox();
            this.pic_camera = new System.Windows.Forms.PictureBox();
            this.btn_grab = new System.Windows.Forms.Button();
            this.tr_threshold = new System.Windows.Forms.TrackBar();
            this.tr_light = new System.Windows.Forms.TrackBar();
            this.tbThreshold1 = new System.Windows.Forms.TextBox();
            this.grp_op = new System.Windows.Forms.GroupBox();
            this.btn_moveto_WaferCenter_point = new System.Windows.Forms.Button();
            this.btn_unload_wafer = new System.Windows.Forms.Button();
            this.btn_load_wafer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.grp_jog.SuspendLayout();
            this.grp_align_test.SuspendLayout();
            this.grp_test.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grp_move.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_camera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_light)).BeginInit();
            this.grp_op.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp_move);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.grp_test);
            this.panel2.Controls.Add(this.grp_align_test);
            this.panel2.Controls.Add(this.grp_jog);
            this.panel2.Location = new System.Drawing.Point(765, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 646);
            this.panel2.TabIndex = 200;
            // 
            // grp_jog
            // 
            this.grp_jog.Controls.Add(this.btn_JOG_Positive_Start);
            this.grp_jog.Controls.Add(this.btn_PosingStop);
            this.grp_jog.Controls.Add(this.btn_origin_return);
            this.grp_jog.Controls.Add(this.btn_JOG_Negative_Start);
            this.grp_jog.Controls.Add(this.btn_JOG_Stop);
            this.grp_jog.Location = new System.Drawing.Point(18, 310);
            this.grp_jog.Margin = new System.Windows.Forms.Padding(2);
            this.grp_jog.Name = "grp_jog";
            this.grp_jog.Padding = new System.Windows.Forms.Padding(2);
            this.grp_jog.Size = new System.Drawing.Size(345, 82);
            this.grp_jog.TabIndex = 120;
            this.grp_jog.TabStop = false;
            // 
            // btn_JOG_Stop
            // 
            this.btn_JOG_Stop.BackColor = System.Drawing.Color.DarkRed;
            this.btn_JOG_Stop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Stop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_JOG_Stop.Location = new System.Drawing.Point(139, 20);
            this.btn_JOG_Stop.Name = "btn_JOG_Stop";
            this.btn_JOG_Stop.Size = new System.Drawing.Size(57, 40);
            this.btn_JOG_Stop.TabIndex = 117;
            this.btn_JOG_Stop.Text = "JOG Stop";
            this.btn_JOG_Stop.UseVisualStyleBackColor = false;
            this.btn_JOG_Stop.Click += new System.EventHandler(this.btn_JOG_Stop_Click);
            // 
            // btn_JOG_Negative_Start
            // 
            this.btn_JOG_Negative_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Negative_Start.Location = new System.Drawing.Point(71, 20);
            this.btn_JOG_Negative_Start.Name = "btn_JOG_Negative_Start";
            this.btn_JOG_Negative_Start.Size = new System.Drawing.Size(57, 40);
            this.btn_JOG_Negative_Start.TabIndex = 119;
            this.btn_JOG_Negative_Start.Text = "JOG- Start";
            this.btn_JOG_Negative_Start.Click += new System.EventHandler(this.btn_JOG_Negative_Start_Click);
            // 
            // btn_origin_return
            // 
            this.btn_origin_return.Font = new System.Drawing.Font("Microsoft JhengHei", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_origin_return.Location = new System.Drawing.Point(214, 20);
            this.btn_origin_return.Name = "btn_origin_return";
            this.btn_origin_return.Size = new System.Drawing.Size(57, 40);
            this.btn_origin_return.TabIndex = 84;
            this.btn_origin_return.Text = "原點\r\n復歸";
            this.btn_origin_return.UseVisualStyleBackColor = true;
            this.btn_origin_return.Click += new System.EventHandler(this.btn_origin_return_Click);
            // 
            // btn_PosingStop
            // 
            this.btn_PosingStop.Font = new System.Drawing.Font("Microsoft JhengHei", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_PosingStop.Location = new System.Drawing.Point(277, 20);
            this.btn_PosingStop.Name = "btn_PosingStop";
            this.btn_PosingStop.Size = new System.Drawing.Size(57, 40);
            this.btn_PosingStop.TabIndex = 111;
            this.btn_PosingStop.Text = "停止\r\n移動";
            this.btn_PosingStop.Click += new System.EventHandler(this.btn_PosingStop_Click);
            // 
            // btn_JOG_Positive_Start
            // 
            this.btn_JOG_Positive_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Positive_Start.Location = new System.Drawing.Point(8, 20);
            this.btn_JOG_Positive_Start.Name = "btn_JOG_Positive_Start";
            this.btn_JOG_Positive_Start.Size = new System.Drawing.Size(57, 40);
            this.btn_JOG_Positive_Start.TabIndex = 116;
            this.btn_JOG_Positive_Start.Text = "JOG+ Start";
            this.btn_JOG_Positive_Start.Click += new System.EventHandler(this.btn_JOG_Positive_Start_Click);
            // 
            // grp_align_test
            // 
            this.grp_align_test.Controls.Add(this.btn_start_mea);
            this.grp_align_test.Controls.Add(this.btn_align);
            this.grp_align_test.Controls.Add(this.btn_find_angle);
            this.grp_align_test.Controls.Add(this.lb_angle1);
            this.grp_align_test.Controls.Add(this.lb_die_side1);
            this.grp_align_test.Controls.Add(this.btn_load);
            this.grp_align_test.Location = new System.Drawing.Point(18, 223);
            this.grp_align_test.Name = "grp_align_test";
            this.grp_align_test.Size = new System.Drawing.Size(345, 65);
            this.grp_align_test.TabIndex = 178;
            this.grp_align_test.TabStop = false;
            // 
            // btn_load
            // 
            this.btn_load.Image = global::Velociraptor.Properties.Resources.folder;
            this.btn_load.Location = new System.Drawing.Point(7, 14);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(40, 40);
            this.btn_load.TabIndex = 2;
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lb_die_side1
            // 
            this.lb_die_side1.AutoSize = true;
            this.lb_die_side1.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_die_side1.Location = new System.Drawing.Point(116, 16);
            this.lb_die_side1.Name = "lb_die_side1";
            this.lb_die_side1.Size = new System.Drawing.Size(32, 15);
            this.lb_die_side1.TabIndex = 4;
            this.lb_die_side1.Text = "邊長:";
            // 
            // lb_angle1
            // 
            this.lb_angle1.AutoSize = true;
            this.lb_angle1.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_angle1.Location = new System.Drawing.Point(116, 41);
            this.lb_angle1.Name = "lb_angle1";
            this.lb_angle1.Size = new System.Drawing.Size(32, 15);
            this.lb_angle1.TabIndex = 5;
            this.lb_angle1.Text = "角度:";
            // 
            // btn_find_angle
            // 
            this.btn_find_angle.Image = global::Velociraptor.Properties.Resources.dart;
            this.btn_find_angle.Location = new System.Drawing.Point(57, 14);
            this.btn_find_angle.Name = "btn_find_angle";
            this.btn_find_angle.Size = new System.Drawing.Size(40, 40);
            this.btn_find_angle.TabIndex = 3;
            this.btn_find_angle.UseVisualStyleBackColor = true;
            this.btn_find_angle.Click += new System.EventHandler(this.btn_find_angle_Click);
            // 
            // btn_align
            // 
            this.btn_align.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_align.Image = global::Velociraptor.Properties.Resources.upward;
            this.btn_align.Location = new System.Drawing.Point(222, 14);
            this.btn_align.Name = "btn_align";
            this.btn_align.Size = new System.Drawing.Size(40, 40);
            this.btn_align.TabIndex = 174;
            this.btn_align.UseVisualStyleBackColor = true;
            this.btn_align.Click += new System.EventHandler(this.btn_align_Click);
            // 
            // btn_start_mea
            // 
            this.btn_start_mea.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_start_mea.Image = global::Velociraptor.Properties.Resources.right_arrow;
            this.btn_start_mea.Location = new System.Drawing.Point(288, 14);
            this.btn_start_mea.Name = "btn_start_mea";
            this.btn_start_mea.Size = new System.Drawing.Size(40, 40);
            this.btn_start_mea.TabIndex = 175;
            this.btn_start_mea.UseVisualStyleBackColor = true;
            this.btn_start_mea.Click += new System.EventHandler(this.btn_manual_mea_Click);
            // 
            // grp_test
            // 
            this.grp_test.Controls.Add(this.btn_test);
            this.grp_test.Controls.Add(this.btn_autofocus);
            this.grp_test.Location = new System.Drawing.Point(18, 542);
            this.grp_test.Margin = new System.Windows.Forms.Padding(2);
            this.grp_test.Name = "grp_test";
            this.grp_test.Padding = new System.Windows.Forms.Padding(2);
            this.grp_test.Size = new System.Drawing.Size(109, 60);
            this.grp_test.TabIndex = 194;
            this.grp_test.TabStop = false;
            this.grp_test.Visible = false;
            // 
            // btn_autofocus
            // 
            this.btn_autofocus.Image = global::Velociraptor.Properties.Resources.focus_icon;
            this.btn_autofocus.Location = new System.Drawing.Point(10, 15);
            this.btn_autofocus.Margin = new System.Windows.Forms.Padding(2);
            this.btn_autofocus.Name = "btn_autofocus";
            this.btn_autofocus.Size = new System.Drawing.Size(40, 40);
            this.btn_autofocus.TabIndex = 0;
            this.btn_autofocus.UseVisualStyleBackColor = true;
            this.btn_autofocus.Click += new System.EventHandler(this.btn_autofocus_Click_1);
            // 
            // btn_test
            // 
            this.btn_test.Image = global::Velociraptor.Properties.Resources.test;
            this.btn_test.Location = new System.Drawing.Point(57, 15);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(40, 40);
            this.btn_test.TabIndex = 192;
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.ntb_r_cur_motorpos);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ntb_z_cur_motorpos);
            this.groupBox3.Controls.Add(this.ntb_y_cur_motorpos);
            this.groupBox3.Controls.Add(this.ntb_x_cur_motorpos);
            this.groupBox3.Location = new System.Drawing.Point(18, 422);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 96);
            this.groupBox3.TabIndex = 93;
            this.groupBox3.TabStop = false;
            // 
            // ntb_x_cur_motorpos
            // 
            this.ntb_x_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_x_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_x_cur_motorpos.Location = new System.Drawing.Point(110, 19);
            this.ntb_x_cur_motorpos.Name = "ntb_x_cur_motorpos";
            this.ntb_x_cur_motorpos.Size = new System.Drawing.Size(90, 20);
            this.ntb_x_cur_motorpos.TabIndex = 116;
            this.ntb_x_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_y_cur_motorpos
            // 
            this.ntb_y_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_y_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_y_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_y_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_y_cur_motorpos.Location = new System.Drawing.Point(236, 19);
            this.ntb_y_cur_motorpos.Name = "ntb_y_cur_motorpos";
            this.ntb_y_cur_motorpos.Size = new System.Drawing.Size(90, 20);
            this.ntb_y_cur_motorpos.TabIndex = 117;
            this.ntb_y_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_z_cur_motorpos
            // 
            this.ntb_z_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_z_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_z_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_z_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_z_cur_motorpos.Location = new System.Drawing.Point(110, 51);
            this.ntb_z_cur_motorpos.Name = "ntb_z_cur_motorpos";
            this.ntb_z_cur_motorpos.Size = new System.Drawing.Size(90, 20);
            this.ntb_z_cur_motorpos.TabIndex = 118;
            this.ntb_z_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(92, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 19);
            this.label5.TabIndex = 120;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(218, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 19);
            this.label6.TabIndex = 121;
            this.label6.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(92, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 19);
            this.label7.TabIndex = 121;
            this.label7.Text = "z";
            // 
            // ntb_r_cur_motorpos
            // 
            this.ntb_r_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_r_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_r_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_r_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_r_cur_motorpos.Location = new System.Drawing.Point(235, 51);
            this.ntb_r_cur_motorpos.Name = "ntb_r_cur_motorpos";
            this.ntb_r_cur_motorpos.Size = new System.Drawing.Size(90, 20);
            this.ntb_r_cur_motorpos.TabIndex = 122;
            this.ntb_r_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label38.Location = new System.Drawing.Point(220, 51);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(15, 19);
            this.label38.TabIndex = 123;
            this.label38.Text = "r";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 124;
            this.label1.Text = "目前位置";
            // 
            // grp_move
            // 
            this.grp_move.Controls.Add(this.label12);
            this.grp_move.Controls.Add(this.label11);
            this.grp_move.Controls.Add(this.label8);
            this.grp_move.Controls.Add(this.btn_move_distance_r);
            this.grp_move.Controls.Add(this.btn_moveR_cw);
            this.grp_move.Controls.Add(this.btn_moveR_ccw);
            this.grp_move.Controls.Add(this.btn_move_distance_z);
            this.grp_move.Controls.Add(this.btn_move_distance);
            this.grp_move.Controls.Add(this.btn_movex_negative);
            this.grp_move.Controls.Add(this.btn_movex_positive);
            this.grp_move.Controls.Add(this.btn_movey_negative);
            this.grp_move.Controls.Add(this.btn_movey_positive);
            this.grp_move.Controls.Add(this.btn_movez_positive);
            this.grp_move.Controls.Add(this.btn_movez_negative);
            this.grp_move.Location = new System.Drawing.Point(18, 22);
            this.grp_move.Name = "grp_move";
            this.grp_move.Size = new System.Drawing.Size(345, 187);
            this.grp_move.TabIndex = 157;
            this.grp_move.TabStop = false;
            // 
            // btn_movez_negative
            // 
            this.btn_movez_negative.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movez_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movez_negative.Image")));
            this.btn_movez_negative.Location = new System.Drawing.Point(204, 109);
            this.btn_movez_negative.Name = "btn_movez_negative";
            this.btn_movez_negative.Size = new System.Drawing.Size(55, 51);
            this.btn_movez_negative.TabIndex = 127;
            this.btn_movez_negative.Text = "Z-";
            this.btn_movez_negative.UseVisualStyleBackColor = true;
            this.btn_movez_negative.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movez_positive
            // 
            this.btn_movez_positive.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movez_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movez_positive.Image")));
            this.btn_movez_positive.Location = new System.Drawing.Point(204, 24);
            this.btn_movez_positive.Name = "btn_movez_positive";
            this.btn_movez_positive.Size = new System.Drawing.Size(55, 48);
            this.btn_movez_positive.TabIndex = 128;
            this.btn_movez_positive.Text = "Z+";
            this.btn_movez_positive.UseVisualStyleBackColor = true;
            this.btn_movez_positive.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movey_positive
            // 
            this.btn_movey_positive.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movey_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movey_positive.Image")));
            this.btn_movey_positive.Location = new System.Drawing.Point(78, 23);
            this.btn_movey_positive.Name = "btn_movey_positive";
            this.btn_movey_positive.Size = new System.Drawing.Size(51, 49);
            this.btn_movey_positive.TabIndex = 125;
            this.btn_movey_positive.Text = "Y+";
            this.btn_movey_positive.UseVisualStyleBackColor = true;
            this.btn_movey_positive.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movey_negative
            // 
            this.btn_movey_negative.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movey_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movey_negative.Image")));
            this.btn_movey_negative.Location = new System.Drawing.Point(78, 109);
            this.btn_movey_negative.Name = "btn_movey_negative";
            this.btn_movey_negative.Size = new System.Drawing.Size(51, 49);
            this.btn_movey_negative.TabIndex = 126;
            this.btn_movey_negative.Text = "Y-";
            this.btn_movey_negative.UseVisualStyleBackColor = true;
            this.btn_movey_negative.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movex_positive
            // 
            this.btn_movex_positive.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movex_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movex_positive.Image")));
            this.btn_movex_positive.Location = new System.Drawing.Point(142, 61);
            this.btn_movex_positive.Name = "btn_movex_positive";
            this.btn_movex_positive.Size = new System.Drawing.Size(48, 49);
            this.btn_movex_positive.TabIndex = 90;
            this.btn_movex_positive.Text = "X+";
            this.btn_movex_positive.UseVisualStyleBackColor = true;
            this.btn_movex_positive.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movex_negative
            // 
            this.btn_movex_negative.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movex_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movex_negative.Image")));
            this.btn_movex_negative.Location = new System.Drawing.Point(14, 63);
            this.btn_movex_negative.Name = "btn_movex_negative";
            this.btn_movex_negative.Size = new System.Drawing.Size(48, 49);
            this.btn_movex_negative.TabIndex = 123;
            this.btn_movex_negative.Text = "X-";
            this.btn_movex_negative.UseVisualStyleBackColor = true;
            this.btn_movex_negative.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_move_distance
            // 
            this.btn_move_distance.BackColor = System.Drawing.Color.White;
            this.btn_move_distance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance.Location = new System.Drawing.Point(74, 76);
            this.btn_move_distance.Name = "btn_move_distance";
            this.btn_move_distance.Size = new System.Drawing.Size(63, 29);
            this.btn_move_distance.TabIndex = 162;
            this.btn_move_distance.Text = "10000";
            this.btn_move_distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance.UseVisualStyleBackColor = false;
            this.btn_move_distance.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // btn_move_distance_z
            // 
            this.btn_move_distance_z.BackColor = System.Drawing.Color.White;
            this.btn_move_distance_z.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance_z.Location = new System.Drawing.Point(204, 75);
            this.btn_move_distance_z.Name = "btn_move_distance_z";
            this.btn_move_distance_z.Size = new System.Drawing.Size(56, 29);
            this.btn_move_distance_z.TabIndex = 164;
            this.btn_move_distance_z.Text = "1000";
            this.btn_move_distance_z.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance_z.UseVisualStyleBackColor = false;
            this.btn_move_distance_z.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // btn_moveR_ccw
            // 
            this.btn_moveR_ccw.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveR_ccw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_moveR_ccw.Image = global::Velociraptor.Properties.Resources.ccw_new;
            this.btn_moveR_ccw.Location = new System.Drawing.Point(274, 109);
            this.btn_moveR_ccw.Name = "btn_moveR_ccw";
            this.btn_moveR_ccw.Size = new System.Drawing.Size(55, 51);
            this.btn_moveR_ccw.TabIndex = 165;
            this.btn_moveR_ccw.Text = "CCW";
            this.btn_moveR_ccw.UseVisualStyleBackColor = true;
            this.btn_moveR_ccw.Click += new System.EventHandler(this.btn_moveR_Click);
            // 
            // btn_moveR_cw
            // 
            this.btn_moveR_cw.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveR_cw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_moveR_cw.Image = ((System.Drawing.Image)(resources.GetObject("btn_moveR_cw.Image")));
            this.btn_moveR_cw.Location = new System.Drawing.Point(274, 24);
            this.btn_moveR_cw.Name = "btn_moveR_cw";
            this.btn_moveR_cw.Size = new System.Drawing.Size(55, 48);
            this.btn_moveR_cw.TabIndex = 166;
            this.btn_moveR_cw.Text = "CW";
            this.btn_moveR_cw.UseVisualStyleBackColor = true;
            this.btn_moveR_cw.Click += new System.EventHandler(this.btn_moveR_Click);
            // 
            // btn_move_distance_r
            // 
            this.btn_move_distance_r.BackColor = System.Drawing.Color.White;
            this.btn_move_distance_r.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance_r.Location = new System.Drawing.Point(274, 74);
            this.btn_move_distance_r.Name = "btn_move_distance_r";
            this.btn_move_distance_r.Size = new System.Drawing.Size(55, 29);
            this.btn_move_distance_r.TabIndex = 167;
            this.btn_move_distance_r.Text = "1";
            this.btn_move_distance_r.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance_r.UseVisualStyleBackColor = false;
            this.btn_move_distance_r.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(90, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 18);
            this.label8.TabIndex = 186;
            this.label8.Text = "um";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(274, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 18);
            this.label11.TabIndex = 187;
            this.label11.Text = "0.001度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(217, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 18);
            this.label12.TabIndex = 188;
            this.label12.Text = "um";
            // 
            // btn_threshold
            // 
            this.btn_threshold.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_threshold.Image = global::Velociraptor.Properties.Resources.fence;
            this.btn_threshold.Location = new System.Drawing.Point(528, 635);
            this.btn_threshold.Name = "btn_threshold";
            this.btn_threshold.Size = new System.Drawing.Size(34, 38);
            this.btn_threshold.TabIndex = 170;
            this.btn_threshold.UseVisualStyleBackColor = true;
            this.btn_threshold.Click += new System.EventHandler(this.btn_threshold_Click);
            // 
            // btn_light
            // 
            this.btn_light.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_light.Image = global::Velociraptor.Properties.Resources.light_bulb4;
            this.btn_light.Location = new System.Drawing.Point(528, 586);
            this.btn_light.Name = "btn_light";
            this.btn_light.Size = new System.Drawing.Size(34, 38);
            this.btn_light.TabIndex = 171;
            this.btn_light.UseVisualStyleBackColor = true;
            this.btn_light.Click += new System.EventHandler(this.btn_light_Click);
            // 
            // btn_advanced_mode
            // 
            this.btn_advanced_mode.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.btn_advanced_mode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btn_advanced_mode.Image = global::Velociraptor.Properties.Resources.administration;
            this.btn_advanced_mode.Location = new System.Drawing.Point(579, 12);
            this.btn_advanced_mode.Margin = new System.Windows.Forms.Padding(1);
            this.btn_advanced_mode.Name = "btn_advanced_mode";
            this.btn_advanced_mode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_advanced_mode.Size = new System.Drawing.Size(51, 49);
            this.btn_advanced_mode.TabIndex = 126;
            this.btn_advanced_mode.UseVisualStyleBackColor = true;
            this.btn_advanced_mode.Click += new System.EventHandler(this.btn_advanced_mode_Click);
            // 
            // btn_ClearAlarm
            // 
            this.btn_ClearAlarm.Font = new System.Drawing.Font("DFKai-SB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_ClearAlarm.Image = global::Velociraptor.Properties.Resources.refresh;
            this.btn_ClearAlarm.Location = new System.Drawing.Point(510, 12);
            this.btn_ClearAlarm.Margin = new System.Windows.Forms.Padding(1);
            this.btn_ClearAlarm.Name = "btn_ClearAlarm";
            this.btn_ClearAlarm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_ClearAlarm.Size = new System.Drawing.Size(51, 49);
            this.btn_ClearAlarm.TabIndex = 173;
            this.btn_ClearAlarm.UseVisualStyleBackColor = true;
            this.btn_ClearAlarm.Click += new System.EventHandler(this.btn_ClearAlarm_Click);
            // 
            // tbLight
            // 
            this.tbLight.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbLight.Location = new System.Drawing.Point(584, 596);
            this.tbLight.Margin = new System.Windows.Forms.Padding(2);
            this.tbLight.Name = "tbLight";
            this.tbLight.Size = new System.Drawing.Size(52, 25);
            this.tbLight.TabIndex = 180;
            this.tbLight.Text = "100";
            this.tbLight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLight.TextChanged += new System.EventHandler(this.tbLight_TextChanged);
            // 
            // pic_camera
            // 
            this.pic_camera.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pic_camera.Location = new System.Drawing.Point(6, 72);
            this.pic_camera.Margin = new System.Windows.Forms.Padding(2);
            this.pic_camera.Name = "pic_camera";
            this.pic_camera.Size = new System.Drawing.Size(628, 503);
            this.pic_camera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_camera.TabIndex = 186;
            this.pic_camera.TabStop = false;
            // 
            // btn_grab
            // 
            this.btn_grab.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_grab.Image = global::Velociraptor.Properties.Resources.red;
            this.btn_grab.Location = new System.Drawing.Point(167, 8);
            this.btn_grab.Name = "btn_grab";
            this.btn_grab.Size = new System.Drawing.Size(64, 56);
            this.btn_grab.TabIndex = 189;
            this.btn_grab.UseVisualStyleBackColor = true;
            this.btn_grab.Click += new System.EventHandler(this.btn_grab_Click);
            // 
            // tr_threshold
            // 
            this.tr_threshold.BackColor = System.Drawing.SystemColors.Control;
            this.tr_threshold.LargeChange = 1;
            this.tr_threshold.Location = new System.Drawing.Point(16, 634);
            this.tr_threshold.Margin = new System.Windows.Forms.Padding(2);
            this.tr_threshold.Maximum = 32;
            this.tr_threshold.Minimum = 1;
            this.tr_threshold.Name = "tr_threshold";
            this.tr_threshold.Size = new System.Drawing.Size(490, 45);
            this.tr_threshold.TabIndex = 190;
            this.tr_threshold.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tr_threshold.Value = 4;
            this.tr_threshold.Scroll += new System.EventHandler(this.tr_threshold_Scroll);
            // 
            // tr_light
            // 
            this.tr_light.BackColor = System.Drawing.SystemColors.Control;
            this.tr_light.Location = new System.Drawing.Point(16, 584);
            this.tr_light.Margin = new System.Windows.Forms.Padding(2);
            this.tr_light.Maximum = 255;
            this.tr_light.Name = "tr_light";
            this.tr_light.Size = new System.Drawing.Size(490, 45);
            this.tr_light.TabIndex = 191;
            this.tr_light.TickFrequency = 10;
            this.tr_light.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tr_light.Value = 100;
            this.tr_light.Scroll += new System.EventHandler(this.tr_light_Scroll);
            // 
            // tbThreshold1
            // 
            this.tbThreshold1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbThreshold1.Location = new System.Drawing.Point(584, 644);
            this.tbThreshold1.Margin = new System.Windows.Forms.Padding(2);
            this.tbThreshold1.Name = "tbThreshold1";
            this.tbThreshold1.Size = new System.Drawing.Size(55, 25);
            this.tbThreshold1.TabIndex = 190;
            this.tbThreshold1.Text = "4";
            this.tbThreshold1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbThreshold1.TextChanged += new System.EventHandler(this.tbThreshold1_TextChanged);
            // 
            // grp_op
            // 
            this.grp_op.Controls.Add(this.btn_load_wafer);
            this.grp_op.Controls.Add(this.btn_unload_wafer);
            this.grp_op.Controls.Add(this.btn_moveto_WaferCenter_point);
            this.grp_op.Location = new System.Drawing.Point(644, 72);
            this.grp_op.Margin = new System.Windows.Forms.Padding(2);
            this.grp_op.Name = "grp_op";
            this.grp_op.Padding = new System.Windows.Forms.Padding(2);
            this.grp_op.Size = new System.Drawing.Size(101, 174);
            this.grp_op.TabIndex = 198;
            this.grp_op.TabStop = false;
            // 
            // btn_moveto_WaferCenter_point
            // 
            this.btn_moveto_WaferCenter_point.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_moveto_WaferCenter_point.Location = new System.Drawing.Point(5, 120);
            this.btn_moveto_WaferCenter_point.Name = "btn_moveto_WaferCenter_point";
            this.btn_moveto_WaferCenter_point.Size = new System.Drawing.Size(89, 43);
            this.btn_moveto_WaferCenter_point.TabIndex = 124;
            this.btn_moveto_WaferCenter_point.Text = "進行量測";
            this.btn_moveto_WaferCenter_point.UseVisualStyleBackColor = true;
            this.btn_moveto_WaferCenter_point.Click += new System.EventHandler(this.btn_auto_measurement);
            // 
            // btn_unload_wafer
            // 
            this.btn_unload_wafer.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_unload_wafer.Location = new System.Drawing.Point(5, 67);
            this.btn_unload_wafer.Name = "btn_unload_wafer";
            this.btn_unload_wafer.Size = new System.Drawing.Size(89, 45);
            this.btn_unload_wafer.TabIndex = 159;
            this.btn_unload_wafer.Text = "晶圓退出";
            this.btn_unload_wafer.UseVisualStyleBackColor = true;
            this.btn_unload_wafer.Click += new System.EventHandler(this.btn_unload_wafer_Click);
            // 
            // btn_load_wafer
            // 
            this.btn_load_wafer.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_load_wafer.Location = new System.Drawing.Point(5, 14);
            this.btn_load_wafer.Name = "btn_load_wafer";
            this.btn_load_wafer.Size = new System.Drawing.Size(89, 47);
            this.btn_load_wafer.TabIndex = 158;
            this.btn_load_wafer.Text = "晶圓載入";
            this.btn_load_wafer.UseVisualStyleBackColor = true;
            this.btn_load_wafer.Click += new System.EventHandler(this.btn_load_wafer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Velociraptor.Properties.Resources.AVVA_R_D_Corp;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 199;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.grp_op);
            this.panel1.Controls.Add(this.tbThreshold1);
            this.panel1.Controls.Add(this.tr_light);
            this.panel1.Controls.Add(this.tr_threshold);
            this.panel1.Controls.Add(this.btn_grab);
            this.panel1.Controls.Add(this.pic_camera);
            this.panel1.Controls.Add(this.tbLight);
            this.panel1.Controls.Add(this.btn_ClearAlarm);
            this.panel1.Controls.Add(this.btn_advanced_mode);
            this.panel1.Controls.Add(this.btn_light);
            this.panel1.Controls.Add(this.btn_threshold);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 702);
            this.panel1.TabIndex = 161;
            // 
            // f_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1157, 706);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaserGrooving V2.001";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_main_FormClosing);
            this.Load += new System.EventHandler(this.f_main_Load);
            this.panel2.ResumeLayout(false);
            this.grp_jog.ResumeLayout(false);
            this.grp_align_test.ResumeLayout(false);
            this.grp_align_test.PerformLayout();
            this.grp_test.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grp_move.ResumeLayout(false);
            this.grp_move.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_camera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_light)).EndInit();
            this.grp_op.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog sfd_upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grp_move;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_move_distance_r;
        private System.Windows.Forms.Button btn_moveR_cw;
        private System.Windows.Forms.Button btn_moveR_ccw;
        private System.Windows.Forms.Button btn_move_distance_z;
        private System.Windows.Forms.Button btn_move_distance;
        private System.Windows.Forms.Button btn_movex_negative;
        private System.Windows.Forms.Button btn_movex_positive;
        private System.Windows.Forms.Button btn_movey_negative;
        private System.Windows.Forms.Button btn_movey_positive;
        private System.Windows.Forms.Button btn_movez_positive;
        private System.Windows.Forms.Button btn_movez_negative;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label38;
        internal System.Windows.Forms.Label ntb_r_cur_motorpos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label ntb_z_cur_motorpos;
        internal System.Windows.Forms.Label ntb_y_cur_motorpos;
        internal System.Windows.Forms.Label ntb_x_cur_motorpos;
        private System.Windows.Forms.GroupBox grp_test;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_autofocus;
        private System.Windows.Forms.GroupBox grp_align_test;
        private System.Windows.Forms.Button btn_start_mea;
        private System.Windows.Forms.Button btn_align;
        private System.Windows.Forms.Button btn_find_angle;
        private System.Windows.Forms.Label lb_angle1;
        private System.Windows.Forms.Label lb_die_side1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.GroupBox grp_jog;
        private System.Windows.Forms.Button btn_JOG_Positive_Start;
        private System.Windows.Forms.Button btn_PosingStop;
        private System.Windows.Forms.Button btn_origin_return;
        private System.Windows.Forms.Button btn_JOG_Negative_Start;
        private System.Windows.Forms.Button btn_JOG_Stop;
        private System.Windows.Forms.Button btn_threshold;
        private System.Windows.Forms.Button btn_light;
        private System.Windows.Forms.Button btn_advanced_mode;
        private System.Windows.Forms.Button btn_ClearAlarm;
        private System.Windows.Forms.TextBox tbLight;
        private System.Windows.Forms.PictureBox pic_camera;
        private System.Windows.Forms.Button btn_grab;
        private System.Windows.Forms.TrackBar tr_threshold;
        private System.Windows.Forms.TrackBar tr_light;
        private System.Windows.Forms.TextBox tbThreshold1;
        private System.Windows.Forms.GroupBox grp_op;
        private System.Windows.Forms.Button btn_load_wafer;
        private System.Windows.Forms.Button btn_unload_wafer;
        private System.Windows.Forms.Button btn_moveto_WaferCenter_point;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

