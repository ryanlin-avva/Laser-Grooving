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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_main));
            this.ntb_led_intensity = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_dynamic = new System.Windows.Forms.NumericUpDown();
            this.label_dynamic = new System.Windows.Forms.Label();
            this.hsb_noise_offset = new System.Windows.Forms.HScrollBar();
            this.label_noise_offset = new System.Windows.Forms.Label();
            this.chk_cursor_v3 = new System.Windows.Forms.Panel();
            this.chk_cursor_v2 = new System.Windows.Forms.Panel();
            this.chk_cursor_v1 = new System.Windows.Forms.Panel();
            this.label_cursor_v3 = new System.Windows.Forms.Label();
            this.label_cursor_v2 = new System.Windows.Forms.Label();
            this.label_cursor_v1 = new System.Windows.Forms.Label();
            this.nud_cursor_v3 = new System.Windows.Forms.NumericUpDown();
            this.nud_cursor_v2 = new System.Windows.Forms.NumericUpDown();
            this.nud_cursor_v1 = new System.Windows.Forms.NumericUpDown();
            this.clsRawImage = new MagicGraphicLibrary.RawImage();
            this.btn_origin_return = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ntb_r_cur_motorpos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ntb_z_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_y_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_x_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_threshold = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.sfd_upload = new System.Windows.Forms.SaveFileDialog();
            this.label_xaxis = new System.Windows.Forms.Label();
            this.label_yaxis = new System.Windows.Forms.Label();
            this.label_zaxis = new System.Windows.Forms.Label();
            this.grp_cursor = new System.Windows.Forms.GroupBox();
            this.btn_PosingStop = new System.Windows.Forms.Button();
            this.ntb_x_cur_pos = new System.Windows.Forms.Label();
            this.ntb_y_cur_pos = new System.Windows.Forms.Label();
            this.ntb_z_cur_pos = new System.Windows.Forms.Label();
            this.btn_JOG_Positive_Start = new System.Windows.Forms.Button();
            this.btn_JOG_Stop = new System.Windows.Forms.Button();
            this.btn_JOG_Negative_Start = new System.Windows.Forms.Button();
            this.ctrl_zgc_dnld = new MagicGraphicLibrary.cZedGraphic();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tbp_main = new System.Windows.Forms.TabPage();
            this.pic_switch = new System.Windows.Forms.PictureBox();
            this.grp_mea_para = new System.Windows.Forms.GroupBox();
            this.ntb_frequency = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btn_connection_ip = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.btn_dark = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.tbp_status = new System.Windows.Forms.TabPage();
            this.lst_log = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbl_number_of_overflow_in_data_format_fifo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrl_percentage_use_of_data_format_fifo = new System.Windows.Forms.ProgressBar();
            this.lbl_number_of_overflow_in_command_data_fifo = new System.Windows.Forms.Label();
            this.lbl_number_of_overflow_in_data_raw_fifo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_number_of_overflow_in_data_raw_socket = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lbl_number_of_overflow_in_data_sample_fifo = new System.Windows.Forms.Label();
            this.ctrl_percentage_use_of_fifo_data_raw_socket = new System.Windows.Forms.ProgressBar();
            this.ctrl_percentage_use_of_fifo_data_raw_fifo = new System.Windows.Forms.ProgressBar();
            this.ctrl_percentage_use_of_command_data_fifo = new System.Windows.Forms.ProgressBar();
            this.ctrl_percentage_use_of_data_sample_fifo = new System.Windows.Forms.ProgressBar();
            this.lbl_rx_rate = new System.Windows.Forms.Label();
            this.lbl_tx_rate = new System.Windows.Forms.Label();
            this.lbl_error_no_dataformat = new System.Windows.Forms.Label();
            this.lbl_unformatted_data = new System.Windows.Forms.Label();
            this.lbl_resynchronization = new System.Windows.Forms.Label();
            this.lbl_not_enough_data = new System.Windows.Forms.Label();
            this.lbl_error_data = new System.Windows.Forms.Label();
            this.lbl_error_data_header = new System.Windows.Forms.Label();
            this.lbl_error_data_format_entry = new System.Windows.Forms.Label();
            this.lbl_error_data_format_header = new System.Windows.Forms.Label();
            this.lbl_error_command_data = new System.Windows.Forms.Label();
            this.lbl_error_command_header = new System.Windows.Forms.Label();
            this.lbl_number_of_spectra = new System.Windows.Forms.Label();
            this.lbl_number_of_data = new System.Windows.Forms.Label();
            this.lbl_number_of_format = new System.Windows.Forms.Label();
            this.lbl_number_of_command = new System.Windows.Forms.Label();
            this.lbl_error_unknow_telegram_type = new System.Windows.Forms.Label();
            this.tbp_motion = new System.Windows.Forms.TabPage();
            this.cb_SelectMeasureDistance = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btn_moveto_WaferCenter_point = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_move_distance_r = new System.Windows.Forms.Button();
            this.btn_moveR_cw = new System.Windows.Forms.Button();
            this.btn_moveR_ccw = new System.Windows.Forms.Button();
            this.btn_move_distance_z = new System.Windows.Forms.Button();
            this.btn_move_distance = new System.Windows.Forms.Button();
            this.btn_movex_negative = new System.Windows.Forms.Button();
            this.btn_movex_positive = new System.Windows.Forms.Button();
            this.btn_movey_negative = new System.Windows.Forms.Button();
            this.btn_movey_positive = new System.Windows.Forms.Button();
            this.btn_movez_positive = new System.Windows.Forms.Button();
            this.btn_movez_negative = new System.Windows.Forms.Button();
            this.btn_manual_mode = new System.Windows.Forms.Button();
            this.btn_unload_wafer = new System.Windows.Forms.Button();
            this.btn_load_wafer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_grab = new System.Windows.Forms.Button();
            this.grp_pic_test = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbThreshold1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lb_die_side1 = new System.Windows.Forms.Label();
            this.lb_angle1 = new System.Windows.Forms.Label();
            this.pic_camera = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_wafersize = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tb_dieY = new System.Windows.Forms.TextBox();
            this.tb_dieX = new System.Windows.Forms.TextBox();
            this.tbExposure = new System.Windows.Forms.TextBox();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.grp_align_test = new System.Windows.Forms.GroupBox();
            this.btn_find_angle = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.lb_angle = new System.Windows.Forms.Label();
            this.lb_die_side = new System.Windows.Forms.Label();
            this.grp_manual_buttons = new System.Windows.Forms.GroupBox();
            this.btn_align = new System.Windows.Forms.Button();
            this.btn_start_mea = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.btn_ClearAlarm = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btn_advanced_mode = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grp_cursor.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tbp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_switch)).BeginInit();
            this.grp_mea_para.SuspendLayout();
            this.tbp_status.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tbp_motion.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grp_pic_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_camera)).BeginInit();
            this.grp_align_test.SuspendLayout();
            this.grp_manual_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntb_led_intensity
            // 
            this.ntb_led_intensity.AutoValidate = false;
            this.ntb_led_intensity.AutoValidationTime = 1000;
            this.ntb_led_intensity.BackColor = System.Drawing.Color.White;
            this.ntb_led_intensity.DecimalPlaces = 0;
            this.ntb_led_intensity.EnableErrorValue = false;
            this.ntb_led_intensity.EnableWarningValue = false;
            this.ntb_led_intensity.ErrorColor = System.Drawing.Color.OrangeRed;
            this.ntb_led_intensity.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_led_intensity.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_led_intensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_led_intensity.InterceptArrowKeys = true;
            this.ntb_led_intensity.Location = new System.Drawing.Point(13, 121);
            this.ntb_led_intensity.Margin = new System.Windows.Forms.Padding(4);
            this.ntb_led_intensity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ntb_led_intensity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_led_intensity.Name = "ntb_led_intensity";
            this.ntb_led_intensity.Size = new System.Drawing.Size(85, 29);
            this.ntb_led_intensity.TabIndex = 2;
            this.ntb_led_intensity.Text = "0";
            this.ntb_led_intensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_led_intensity.ThousandsSeparator = false;
            this.ntb_led_intensity.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_led_intensity.WarningColor = System.Drawing.Color.Gold;
            this.ntb_led_intensity.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "光源強度";
            // 
            // nud_dynamic
            // 
            this.nud_dynamic.Location = new System.Drawing.Point(14, 251);
            this.nud_dynamic.Margin = new System.Windows.Forms.Padding(4);
            this.nud_dynamic.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nud_dynamic.Name = "nud_dynamic";
            this.nud_dynamic.Size = new System.Drawing.Size(60, 27);
            this.nud_dynamic.TabIndex = 71;
            this.nud_dynamic.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dynamic.ValueChanged += new System.EventHandler(this.nud_dynamic_ValueChanged);
            // 
            // label_dynamic
            // 
            this.label_dynamic.AutoSize = true;
            this.label_dynamic.Location = new System.Drawing.Point(15, 231);
            this.label_dynamic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dynamic.Name = "label_dynamic";
            this.label_dynamic.Size = new System.Drawing.Size(66, 17);
            this.label_dynamic.TabIndex = 70;
            this.label_dynamic.Text = "Dynamic";
            // 
            // hsb_noise_offset
            // 
            this.hsb_noise_offset.Location = new System.Drawing.Point(12, 186);
            this.hsb_noise_offset.Name = "hsb_noise_offset";
            this.hsb_noise_offset.Size = new System.Drawing.Size(85, 17);
            this.hsb_noise_offset.TabIndex = 69;
            this.hsb_noise_offset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsb_noise_offset_Scroll);
            // 
            // label_noise_offset
            // 
            this.label_noise_offset.AutoSize = true;
            this.label_noise_offset.Location = new System.Drawing.Point(8, 166);
            this.label_noise_offset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_noise_offset.Name = "label_noise_offset";
            this.label_noise_offset.Size = new System.Drawing.Size(88, 17);
            this.label_noise_offset.TabIndex = 68;
            this.label_noise_offset.Text = "Noise Offset";
            // 
            // chk_cursor_v3
            // 
            this.chk_cursor_v3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chk_cursor_v3.Location = new System.Drawing.Point(12, 111);
            this.chk_cursor_v3.Margin = new System.Windows.Forms.Padding(4);
            this.chk_cursor_v3.Name = "chk_cursor_v3";
            this.chk_cursor_v3.Size = new System.Drawing.Size(25, 21);
            this.chk_cursor_v3.TabIndex = 65;
            this.chk_cursor_v3.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // chk_cursor_v2
            // 
            this.chk_cursor_v2.BackColor = System.Drawing.Color.Blue;
            this.chk_cursor_v2.Location = new System.Drawing.Point(12, 41);
            this.chk_cursor_v2.Margin = new System.Windows.Forms.Padding(4);
            this.chk_cursor_v2.Name = "chk_cursor_v2";
            this.chk_cursor_v2.Size = new System.Drawing.Size(25, 21);
            this.chk_cursor_v2.TabIndex = 66;
            this.chk_cursor_v2.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // chk_cursor_v1
            // 
            this.chk_cursor_v1.BackColor = System.Drawing.Color.Red;
            this.chk_cursor_v1.Location = new System.Drawing.Point(649, 45);
            this.chk_cursor_v1.Margin = new System.Windows.Forms.Padding(4);
            this.chk_cursor_v1.Name = "chk_cursor_v1";
            this.chk_cursor_v1.Size = new System.Drawing.Size(25, 21);
            this.chk_cursor_v1.TabIndex = 67;
            this.chk_cursor_v1.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // label_cursor_v3
            // 
            this.label_cursor_v3.AutoSize = true;
            this.label_cursor_v3.Location = new System.Drawing.Point(8, 94);
            this.label_cursor_v3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cursor_v3.Name = "label_cursor_v3";
            this.label_cursor_v3.Size = new System.Drawing.Size(75, 17);
            this.label_cursor_v3.TabIndex = 64;
            this.label_cursor_v3.Text = "Cursor V3";
            // 
            // label_cursor_v2
            // 
            this.label_cursor_v2.AutoSize = true;
            this.label_cursor_v2.Location = new System.Drawing.Point(8, 24);
            this.label_cursor_v2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cursor_v2.Name = "label_cursor_v2";
            this.label_cursor_v2.Size = new System.Drawing.Size(75, 17);
            this.label_cursor_v2.TabIndex = 63;
            this.label_cursor_v2.Text = "Cursor V2";
            // 
            // label_cursor_v1
            // 
            this.label_cursor_v1.AutoSize = true;
            this.label_cursor_v1.Location = new System.Drawing.Point(645, 25);
            this.label_cursor_v1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cursor_v1.Name = "label_cursor_v1";
            this.label_cursor_v1.Size = new System.Drawing.Size(75, 17);
            this.label_cursor_v1.TabIndex = 62;
            this.label_cursor_v1.Text = "Cursor V1";
            // 
            // nud_cursor_v3
            // 
            this.nud_cursor_v3.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nud_cursor_v3.Location = new System.Drawing.Point(45, 111);
            this.nud_cursor_v3.Margin = new System.Windows.Forms.Padding(4);
            this.nud_cursor_v3.Name = "nud_cursor_v3";
            this.nud_cursor_v3.Size = new System.Drawing.Size(60, 28);
            this.nud_cursor_v3.TabIndex = 59;
            this.nud_cursor_v3.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // nud_cursor_v2
            // 
            this.nud_cursor_v2.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nud_cursor_v2.Location = new System.Drawing.Point(45, 41);
            this.nud_cursor_v2.Margin = new System.Windows.Forms.Padding(4);
            this.nud_cursor_v2.Name = "nud_cursor_v2";
            this.nud_cursor_v2.Size = new System.Drawing.Size(60, 28);
            this.nud_cursor_v2.TabIndex = 60;
            this.nud_cursor_v2.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // nud_cursor_v1
            // 
            this.nud_cursor_v1.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nud_cursor_v1.Location = new System.Drawing.Point(681, 45);
            this.nud_cursor_v1.Margin = new System.Windows.Forms.Padding(4);
            this.nud_cursor_v1.Name = "nud_cursor_v1";
            this.nud_cursor_v1.Size = new System.Drawing.Size(60, 28);
            this.nud_cursor_v1.TabIndex = 61;
            this.nud_cursor_v1.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // clsRawImage
            // 
            this.clsRawImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clsRawImage.BackColor = System.Drawing.Color.Black;
            this.clsRawImage.Data = null;
            this.clsRawImage.Dynamic = ((byte)(0));
            this.clsRawImage.ExtendedColor = true;
            this.clsRawImage.FirstDataColumn = 0;
            this.clsRawImage.FirstDataLine = 0;
            this.clsRawImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsRawImage.LabelColor = System.Drawing.Color.Yellow;
            this.clsRawImage.LabelEnabled = true;
            this.clsRawImage.Location = new System.Drawing.Point(145, -2);
            this.clsRawImage.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.clsRawImage.MenuLoadData = true;
            this.clsRawImage.MenuPauseData = true;
            this.clsRawImage.MenuPrintImage = true;
            this.clsRawImage.MenuSaveData = true;
            this.clsRawImage.MenuSaveImage = true;
            this.clsRawImage.Name = "clsRawImage";
            this.clsRawImage.NoiseOffset = 1;
            this.clsRawImage.PathDataFile = null;
            this.clsRawImage.PathImageFile = null;
            this.clsRawImage.Paused = false;
            this.clsRawImage.RefreshDisplay = 40;
            this.clsRawImage.Size = new System.Drawing.Size(384, 367);
            this.clsRawImage.SizeOfDataColumn = 192;
            this.clsRawImage.SizeOfDataLine = 174;
            this.clsRawImage.TabIndex = 76;
            this.clsRawImage.TextMenuLoadData = "Load Data";
            this.clsRawImage.TextMenuPause = "Pause";
            this.clsRawImage.TextMenuPlay = "Run";
            this.clsRawImage.TextMenuPrintImage = "Print Image";
            this.clsRawImage.TextMenuSaveData = "Save Data";
            this.clsRawImage.TextMenuSaveImage = "Save Image";
            this.clsRawImage.TextPositionFiber = "Fiber";
            this.clsRawImage.TextPositionPixel = "Pixel";
            this.clsRawImage.TextValuePixel = "Value";
            this.clsRawImage.ZoomX = 2F;
            this.clsRawImage.ZoomXEnabled = true;
            this.clsRawImage.ZoomXIn = 2F;
            this.clsRawImage.ZoomY = 2F;
            this.clsRawImage.ZoomYEnabled = true;
            this.clsRawImage.ZoomYIn = 2F;
            // 
            // btn_origin_return
            // 
            this.btn_origin_return.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_origin_return.Location = new System.Drawing.Point(342, 134);
            this.btn_origin_return.Margin = new System.Windows.Forms.Padding(4);
            this.btn_origin_return.Name = "btn_origin_return";
            this.btn_origin_return.Size = new System.Drawing.Size(99, 51);
            this.btn_origin_return.TabIndex = 84;
            this.btn_origin_return.Text = "原點復歸";
            this.btn_origin_return.UseVisualStyleBackColor = true;
            this.btn_origin_return.Click += new System.EventHandler(this.btn_origin_return_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.ntb_r_cur_motorpos);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ntb_z_cur_motorpos);
            this.groupBox3.Controls.Add(this.ntb_y_cur_motorpos);
            this.groupBox3.Controls.Add(this.ntb_x_cur_motorpos);
            this.groupBox3.Location = new System.Drawing.Point(11, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(304, 180);
            this.groupBox3.TabIndex = 93;
            this.groupBox3.TabStop = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label38.Location = new System.Drawing.Point(145, 131);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(113, 24);
            this.label38.TabIndex = 123;
            this.label38.Text = "r軸馬達位置";
            // 
            // ntb_r_cur_motorpos
            // 
            this.ntb_r_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_r_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_r_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_r_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_r_cur_motorpos.Location = new System.Drawing.Point(25, 130);
            this.ntb_r_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_r_cur_motorpos.Name = "ntb_r_cur_motorpos";
            this.ntb_r_cur_motorpos.Size = new System.Drawing.Size(112, 24);
            this.ntb_r_cur_motorpos.TabIndex = 122;
            this.ntb_r_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(145, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 24);
            this.label7.TabIndex = 121;
            this.label7.Text = "z軸馬達位置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(145, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 24);
            this.label6.TabIndex = 121;
            this.label6.Text = "y軸馬達位置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(145, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 24);
            this.label5.TabIndex = 120;
            this.label5.Text = "x軸馬達位置";
            // 
            // ntb_z_cur_motorpos
            // 
            this.ntb_z_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_z_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_z_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_z_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_z_cur_motorpos.Location = new System.Drawing.Point(25, 99);
            this.ntb_z_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_z_cur_motorpos.Name = "ntb_z_cur_motorpos";
            this.ntb_z_cur_motorpos.Size = new System.Drawing.Size(112, 24);
            this.ntb_z_cur_motorpos.TabIndex = 118;
            this.ntb_z_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_y_cur_motorpos
            // 
            this.ntb_y_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_y_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_y_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_y_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_y_cur_motorpos.Location = new System.Drawing.Point(25, 66);
            this.ntb_y_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_y_cur_motorpos.Name = "ntb_y_cur_motorpos";
            this.ntb_y_cur_motorpos.Size = new System.Drawing.Size(112, 24);
            this.ntb_y_cur_motorpos.TabIndex = 117;
            this.ntb_y_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_x_cur_motorpos
            // 
            this.ntb_x_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntb_x_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_motorpos.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.ntb_x_cur_motorpos.Location = new System.Drawing.Point(25, 34);
            this.ntb_x_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_x_cur_motorpos.Name = "ntb_x_cur_motorpos";
            this.ntb_x_cur_motorpos.Size = new System.Drawing.Size(112, 24);
            this.ntb_x_cur_motorpos.TabIndex = 116;
            this.ntb_x_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_threshold
            // 
            this.ntb_threshold.AutoValidate = false;
            this.ntb_threshold.AutoValidationTime = 1000;
            this.ntb_threshold.BackColor = System.Drawing.Color.White;
            this.ntb_threshold.DecimalPlaces = 0;
            this.ntb_threshold.EnableErrorValue = false;
            this.ntb_threshold.EnableWarningValue = false;
            this.ntb_threshold.ErrorColor = System.Drawing.Color.OrangeRed;
            this.ntb_threshold.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_threshold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_threshold.HideSelection = false;
            this.ntb_threshold.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ntb_threshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_threshold.InterceptArrowKeys = true;
            this.ntb_threshold.Location = new System.Drawing.Point(8, 132);
            this.ntb_threshold.Margin = new System.Windows.Forms.Padding(4);
            this.ntb_threshold.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.ntb_threshold.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_threshold.Name = "ntb_threshold";
            this.ntb_threshold.Size = new System.Drawing.Size(102, 26);
            this.ntb_threshold.TabIndex = 123;
            this.ntb_threshold.Text = "400";
            this.ntb_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_threshold.ThousandsSeparator = false;
            this.ntb_threshold.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.ntb_threshold.WarningColor = System.Drawing.Color.Gold;
            this.ntb_threshold.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_threshold.WordWrap = false;
            // 
            // label_xaxis
            // 
            this.label_xaxis.AutoSize = true;
            this.label_xaxis.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_xaxis.Location = new System.Drawing.Point(982, 305);
            this.label_xaxis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_xaxis.Name = "label_xaxis";
            this.label_xaxis.Size = new System.Drawing.Size(38, 22);
            this.label_xaxis.TabIndex = 99;
            this.label_xaxis.Text = "X軸";
            // 
            // label_yaxis
            // 
            this.label_yaxis.AutoSize = true;
            this.label_yaxis.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_yaxis.Location = new System.Drawing.Point(1078, 305);
            this.label_yaxis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_yaxis.Name = "label_yaxis";
            this.label_yaxis.Size = new System.Drawing.Size(38, 22);
            this.label_yaxis.TabIndex = 100;
            this.label_yaxis.Text = "Y軸";
            // 
            // label_zaxis
            // 
            this.label_zaxis.AutoSize = true;
            this.label_zaxis.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_zaxis.Location = new System.Drawing.Point(1175, 305);
            this.label_zaxis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_zaxis.Name = "label_zaxis";
            this.label_zaxis.Size = new System.Drawing.Size(38, 22);
            this.label_zaxis.TabIndex = 101;
            this.label_zaxis.Text = "Z軸";
            // 
            // grp_cursor
            // 
            this.grp_cursor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_cursor.Controls.Add(this.nud_dynamic);
            this.grp_cursor.Controls.Add(this.nud_cursor_v2);
            this.grp_cursor.Controls.Add(this.nud_cursor_v3);
            this.grp_cursor.Controls.Add(this.label_cursor_v2);
            this.grp_cursor.Controls.Add(this.label_cursor_v3);
            this.grp_cursor.Controls.Add(this.chk_cursor_v2);
            this.grp_cursor.Controls.Add(this.chk_cursor_v3);
            this.grp_cursor.Controls.Add(this.label_noise_offset);
            this.grp_cursor.Controls.Add(this.hsb_noise_offset);
            this.grp_cursor.Controls.Add(this.label_dynamic);
            this.grp_cursor.Location = new System.Drawing.Point(636, 80);
            this.grp_cursor.Margin = new System.Windows.Forms.Padding(4);
            this.grp_cursor.Name = "grp_cursor";
            this.grp_cursor.Padding = new System.Windows.Forms.Padding(4);
            this.grp_cursor.Size = new System.Drawing.Size(108, 292);
            this.grp_cursor.TabIndex = 110;
            this.grp_cursor.TabStop = false;
            this.grp_cursor.Visible = false;
            // 
            // btn_PosingStop
            // 
            this.btn_PosingStop.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_PosingStop.Location = new System.Drawing.Point(479, 136);
            this.btn_PosingStop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PosingStop.Name = "btn_PosingStop";
            this.btn_PosingStop.Size = new System.Drawing.Size(99, 49);
            this.btn_PosingStop.TabIndex = 111;
            this.btn_PosingStop.Text = "停止移動";
            this.btn_PosingStop.Click += new System.EventHandler(this.btn_PosingStop_Click);
            // 
            // ntb_x_cur_pos
            // 
            this.ntb_x_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_x_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_pos.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_x_cur_pos.Location = new System.Drawing.Point(978, 336);
            this.ntb_x_cur_pos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_x_cur_pos.Name = "ntb_x_cur_pos";
            this.ntb_x_cur_pos.Size = new System.Drawing.Size(86, 25);
            this.ntb_x_cur_pos.TabIndex = 113;
            this.ntb_x_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_y_cur_pos
            // 
            this.ntb_y_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_y_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_y_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_y_cur_pos.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_y_cur_pos.Location = new System.Drawing.Point(1075, 336);
            this.ntb_y_cur_pos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_y_cur_pos.Name = "ntb_y_cur_pos";
            this.ntb_y_cur_pos.Size = new System.Drawing.Size(86, 25);
            this.ntb_y_cur_pos.TabIndex = 114;
            this.ntb_y_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_z_cur_pos
            // 
            this.ntb_z_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_z_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_z_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_z_cur_pos.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_z_cur_pos.Location = new System.Drawing.Point(1175, 336);
            this.ntb_z_cur_pos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_z_cur_pos.Name = "ntb_z_cur_pos";
            this.ntb_z_cur_pos.Size = new System.Drawing.Size(86, 25);
            this.ntb_z_cur_pos.TabIndex = 115;
            this.ntb_z_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_JOG_Positive_Start
            // 
            this.btn_JOG_Positive_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Positive_Start.Location = new System.Drawing.Point(342, 59);
            this.btn_JOG_Positive_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_JOG_Positive_Start.Name = "btn_JOG_Positive_Start";
            this.btn_JOG_Positive_Start.Size = new System.Drawing.Size(71, 50);
            this.btn_JOG_Positive_Start.TabIndex = 116;
            this.btn_JOG_Positive_Start.Text = "JOG+ Start";
            this.btn_JOG_Positive_Start.Click += new System.EventHandler(this.btn_JOG_Positive_Start_Click);
            // 
            // btn_JOG_Stop
            // 
            this.btn_JOG_Stop.BackColor = System.Drawing.Color.DarkRed;
            this.btn_JOG_Stop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Stop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_JOG_Stop.Location = new System.Drawing.Point(506, 59);
            this.btn_JOG_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_JOG_Stop.Name = "btn_JOG_Stop";
            this.btn_JOG_Stop.Size = new System.Drawing.Size(71, 50);
            this.btn_JOG_Stop.TabIndex = 117;
            this.btn_JOG_Stop.Text = "JOG Stop";
            this.btn_JOG_Stop.UseVisualStyleBackColor = false;
            this.btn_JOG_Stop.Click += new System.EventHandler(this.btn_JOG_Stop_Click);
            // 
            // btn_JOG_Negative_Start
            // 
            this.btn_JOG_Negative_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Negative_Start.Location = new System.Drawing.Point(421, 59);
            this.btn_JOG_Negative_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_JOG_Negative_Start.Name = "btn_JOG_Negative_Start";
            this.btn_JOG_Negative_Start.Size = new System.Drawing.Size(71, 50);
            this.btn_JOG_Negative_Start.TabIndex = 119;
            this.btn_JOG_Negative_Start.Text = "JOG- Start";
            this.btn_JOG_Negative_Start.Click += new System.EventHandler(this.btn_JOG_Negative_Start_Click);
            // 
            // ctrl_zgc_dnld
            // 
            this.ctrl_zgc_dnld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrl_zgc_dnld.ChoiceOfFiberLegend = "";
            this.ctrl_zgc_dnld.EnableChoiceOfFiber = true;
            this.ctrl_zgc_dnld.Location = new System.Drawing.Point(832, 0);
            this.ctrl_zgc_dnld.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.ctrl_zgc_dnld.MenuAutoScale = true;
            this.ctrl_zgc_dnld.MenuLoadData = false;
            this.ctrl_zgc_dnld.MenuPrintImage = true;
            this.ctrl_zgc_dnld.MenuSaveData = false;
            this.ctrl_zgc_dnld.MenuSaveImage = true;
            this.ctrl_zgc_dnld.MenuShowValues = false;
            this.ctrl_zgc_dnld.MenuUnZoom = true;
            this.ctrl_zgc_dnld.Name = "ctrl_zgc_dnld";
            this.ctrl_zgc_dnld.PathDataFile = null;
            this.ctrl_zgc_dnld.PathImageFile = null;
            this.ctrl_zgc_dnld.ResourceLanguage = null;
            this.ctrl_zgc_dnld.ScrollGrace = 0D;
            this.ctrl_zgc_dnld.ScrollMaxX = 0D;
            this.ctrl_zgc_dnld.ScrollMaxY = 0D;
            this.ctrl_zgc_dnld.ScrollMaxY2 = 0D;
            this.ctrl_zgc_dnld.ScrollMinX = 0D;
            this.ctrl_zgc_dnld.ScrollMinY = 0D;
            this.ctrl_zgc_dnld.ScrollMinY2 = 0D;
            this.ctrl_zgc_dnld.Size = new System.Drawing.Size(560, 452);
            this.ctrl_zgc_dnld.TabIndex = 58;
            this.ctrl_zgc_dnld.TextMenuAutoScale = "AutoScale";
            this.ctrl_zgc_dnld.TextMenuLoadData = "Load Data";
            this.ctrl_zgc_dnld.TextMenuPrintImage = "Print Image";
            this.ctrl_zgc_dnld.TextMenuSaveData = "Save Data";
            this.ctrl_zgc_dnld.TextMenuSaveImage = "Save Image";
            this.ctrl_zgc_dnld.TextMenuShowValues = "Show Values";
            this.ctrl_zgc_dnld.TextMenuUnZoom = "UnZoom";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tbp_main);
            this.tabControlMain.Controls.Add(this.tbp_status);
            this.tabControlMain.Controls.Add(this.tbp_motion);
            this.tabControlMain.Location = new System.Drawing.Point(5, 381);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1432, 490);
            this.tabControlMain.TabIndex = 120;
            // 
            // tbp_main
            // 
            this.tbp_main.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_main.CausesValidation = false;
            this.tbp_main.Controls.Add(this.pic_switch);
            this.tbp_main.Controls.Add(this.grp_mea_para);
            this.tbp_main.Controls.Add(this.nud_cursor_v1);
            this.tbp_main.Controls.Add(this.btn_download);
            this.tbp_main.Controls.Add(this.clsRawImage);
            this.tbp_main.Controls.Add(this.grp_cursor);
            this.tbp_main.Controls.Add(this.chk_cursor_v1);
            this.tbp_main.Controls.Add(this.label_cursor_v1);
            this.tbp_main.Controls.Add(this.ctrl_zgc_dnld);
            this.tbp_main.Controls.Add(this.label1);
            this.tbp_main.Controls.Add(this.ntb_led_intensity);
            this.tbp_main.Controls.Add(this.label2);
            this.tbp_main.Location = new System.Drawing.Point(4, 26);
            this.tbp_main.Margin = new System.Windows.Forms.Padding(4);
            this.tbp_main.Name = "tbp_main";
            this.tbp_main.Padding = new System.Windows.Forms.Padding(4);
            this.tbp_main.Size = new System.Drawing.Size(1424, 460);
            this.tbp_main.TabIndex = 6;
            this.tbp_main.Text = "一般";
            // 
            // pic_switch
            // 
            this.pic_switch.Image = global::Velociraptor.Properties.Resources.green;
            this.pic_switch.Location = new System.Drawing.Point(655, 386);
            this.pic_switch.Margin = new System.Windows.Forms.Padding(4);
            this.pic_switch.Name = "pic_switch";
            this.pic_switch.Size = new System.Drawing.Size(66, 64);
            this.pic_switch.TabIndex = 128;
            this.pic_switch.TabStop = false;
            this.pic_switch.Click += new System.EventHandler(this.pic_switch_Click);
            // 
            // grp_mea_para
            // 
            this.grp_mea_para.Controls.Add(this.ntb_frequency);
            this.grp_mea_para.Controls.Add(this.label4);
            this.grp_mea_para.Controls.Add(this.btn_connection_ip);
            this.grp_mea_para.Controls.Add(this.ntb_threshold);
            this.grp_mea_para.Controls.Add(this.label37);
            this.grp_mea_para.Controls.Add(this.btn_dark);
            this.grp_mea_para.Location = new System.Drawing.Point(5, 155);
            this.grp_mea_para.Margin = new System.Windows.Forms.Padding(2);
            this.grp_mea_para.Name = "grp_mea_para";
            this.grp_mea_para.Padding = new System.Windows.Forms.Padding(2);
            this.grp_mea_para.Size = new System.Drawing.Size(128, 295);
            this.grp_mea_para.TabIndex = 127;
            this.grp_mea_para.TabStop = false;
            this.grp_mea_para.Visible = false;
            // 
            // ntb_frequency
            // 
            this.ntb_frequency.AutoValidate = false;
            this.ntb_frequency.AutoValidationTime = 1000;
            this.ntb_frequency.BackColor = System.Drawing.Color.White;
            this.ntb_frequency.DecimalPlaces = 0;
            this.ntb_frequency.EnableErrorValue = false;
            this.ntb_frequency.EnableWarningValue = false;
            this.ntb_frequency.ErrorColor = System.Drawing.Color.OrangeRed;
            this.ntb_frequency.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_frequency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_frequency.HideSelection = false;
            this.ntb_frequency.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ntb_frequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_frequency.InterceptArrowKeys = true;
            this.ntb_frequency.Location = new System.Drawing.Point(8, 198);
            this.ntb_frequency.Margin = new System.Windows.Forms.Padding(4);
            this.ntb_frequency.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.ntb_frequency.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_frequency.Name = "ntb_frequency";
            this.ntb_frequency.Size = new System.Drawing.Size(102, 26);
            this.ntb_frequency.TabIndex = 126;
            this.ntb_frequency.Text = "2000";
            this.ntb_frequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_frequency.ThousandsSeparator = false;
            this.ntb_frequency.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.ntb_frequency.WarningColor = System.Drawing.Color.Gold;
            this.ntb_frequency.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_frequency.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(11, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 22);
            this.label4.TabIndex = 127;
            this.label4.Text = "取樣頻率";
            // 
            // btn_connection_ip
            // 
            this.btn_connection_ip.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_connection_ip.Location = new System.Drawing.Point(8, 36);
            this.btn_connection_ip.Margin = new System.Windows.Forms.Padding(1);
            this.btn_connection_ip.Name = "btn_connection_ip";
            this.btn_connection_ip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_connection_ip.Size = new System.Drawing.Size(102, 46);
            this.btn_connection_ip.TabIndex = 125;
            this.btn_connection_ip.Text = "變更相機IP";
            this.btn_connection_ip.UseVisualStyleBackColor = true;
            this.btn_connection_ip.Click += new System.EventHandler(this.btn_connection_ip_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label37.Location = new System.Drawing.Point(11, 105);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(78, 22);
            this.label37.TabIndex = 124;
            this.label37.Text = "強度閥值";
            // 
            // btn_dark
            // 
            this.btn_dark.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_dark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_dark.Location = new System.Drawing.Point(6, 240);
            this.btn_dark.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dark.Name = "btn_dark";
            this.btn_dark.Size = new System.Drawing.Size(102, 46);
            this.btn_dark.TabIndex = 98;
            this.btn_dark.Text = "相機去噪";
            this.btn_dark.UseVisualStyleBackColor = true;
            this.btn_dark.Click += new System.EventHandler(this.btn_dark_Click);
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_download.Location = new System.Drawing.Point(12, 29);
            this.btn_download.Margin = new System.Windows.Forms.Padding(1);
            this.btn_download.Name = "btn_download";
            this.btn_download.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_download.Size = new System.Drawing.Size(102, 46);
            this.btn_download.TabIndex = 126;
            this.btn_download.Text = "開始取像";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // tbp_status
            // 
            this.tbp_status.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_status.Controls.Add(this.lst_log);
            this.tbp_status.Controls.Add(this.groupBox5);
            this.tbp_status.Location = new System.Drawing.Point(4, 26);
            this.tbp_status.Margin = new System.Windows.Forms.Padding(4);
            this.tbp_status.Name = "tbp_status";
            this.tbp_status.Size = new System.Drawing.Size(1424, 460);
            this.tbp_status.TabIndex = 5;
            this.tbp_status.Text = "狀態";
            // 
            // lst_log
            // 
            this.lst_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_log.FullRowSelect = true;
            this.lst_log.HideSelection = false;
            this.lst_log.Location = new System.Drawing.Point(491, 14);
            this.lst_log.Margin = new System.Windows.Forms.Padding(4);
            this.lst_log.Name = "lst_log";
            this.lst_log.ShowItemToolTips = true;
            this.lst_log.Size = new System.Drawing.Size(916, 443);
            this.lst_log.TabIndex = 36;
            this.lst_log.UseCompatibleStateImageBehavior = false;
            this.lst_log.View = System.Windows.Forms.View.Details;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_number_of_overflow_in_data_format_fifo);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.ctrl_percentage_use_of_data_format_fifo);
            this.groupBox5.Controls.Add(this.lbl_number_of_overflow_in_command_data_fifo);
            this.groupBox5.Controls.Add(this.lbl_number_of_overflow_in_data_raw_fifo);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.lbl_number_of_overflow_in_data_raw_socket);
            this.groupBox5.Controls.Add(this.label48);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label47);
            this.groupBox5.Controls.Add(this.lbl_number_of_overflow_in_data_sample_fifo);
            this.groupBox5.Controls.Add(this.ctrl_percentage_use_of_fifo_data_raw_socket);
            this.groupBox5.Controls.Add(this.ctrl_percentage_use_of_fifo_data_raw_fifo);
            this.groupBox5.Controls.Add(this.ctrl_percentage_use_of_command_data_fifo);
            this.groupBox5.Controls.Add(this.ctrl_percentage_use_of_data_sample_fifo);
            this.groupBox5.Controls.Add(this.lbl_rx_rate);
            this.groupBox5.Controls.Add(this.lbl_tx_rate);
            this.groupBox5.Controls.Add(this.lbl_error_no_dataformat);
            this.groupBox5.Controls.Add(this.lbl_unformatted_data);
            this.groupBox5.Controls.Add(this.lbl_resynchronization);
            this.groupBox5.Controls.Add(this.lbl_not_enough_data);
            this.groupBox5.Controls.Add(this.lbl_error_data);
            this.groupBox5.Controls.Add(this.lbl_error_data_header);
            this.groupBox5.Controls.Add(this.lbl_error_data_format_entry);
            this.groupBox5.Controls.Add(this.lbl_error_data_format_header);
            this.groupBox5.Controls.Add(this.lbl_error_command_data);
            this.groupBox5.Controls.Add(this.lbl_error_command_header);
            this.groupBox5.Controls.Add(this.lbl_number_of_spectra);
            this.groupBox5.Controls.Add(this.lbl_number_of_data);
            this.groupBox5.Controls.Add(this.lbl_number_of_format);
            this.groupBox5.Controls.Add(this.lbl_number_of_command);
            this.groupBox5.Controls.Add(this.lbl_error_unknow_telegram_type);
            this.groupBox5.Location = new System.Drawing.Point(4, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(466, 459);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // lbl_number_of_overflow_in_data_format_fifo
            // 
            this.lbl_number_of_overflow_in_data_format_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_data_format_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_format_fifo.Location = new System.Drawing.Point(171, 159);
            this.lbl_number_of_overflow_in_data_format_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_data_format_fifo.Name = "lbl_number_of_overflow_in_data_format_fifo";
            this.lbl_number_of_overflow_in_data_format_fifo.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_data_format_fifo.TabIndex = 35;
            this.lbl_number_of_overflow_in_data_format_fifo.Text = "Overflow";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 159);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Data Format";
            // 
            // ctrl_percentage_use_of_data_format_fifo
            // 
            this.ctrl_percentage_use_of_data_format_fifo.Location = new System.Drawing.Point(381, 151);
            this.ctrl_percentage_use_of_data_format_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_data_format_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_data_format_fifo.Name = "ctrl_percentage_use_of_data_format_fifo";
            this.ctrl_percentage_use_of_data_format_fifo.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_data_format_fifo.Step = 1;
            this.ctrl_percentage_use_of_data_format_fifo.TabIndex = 34;
            // 
            // lbl_number_of_overflow_in_command_data_fifo
            // 
            this.lbl_number_of_overflow_in_command_data_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_command_data_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_command_data_fifo.Location = new System.Drawing.Point(171, 129);
            this.lbl_number_of_overflow_in_command_data_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_command_data_fifo.Name = "lbl_number_of_overflow_in_command_data_fifo";
            this.lbl_number_of_overflow_in_command_data_fifo.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_command_data_fifo.TabIndex = 32;
            this.lbl_number_of_overflow_in_command_data_fifo.Text = "Overflow";
            // 
            // lbl_number_of_overflow_in_data_raw_fifo
            // 
            this.lbl_number_of_overflow_in_data_raw_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_data_raw_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_raw_fifo.Location = new System.Drawing.Point(171, 71);
            this.lbl_number_of_overflow_in_data_raw_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_data_raw_fifo.Name = "lbl_number_of_overflow_in_data_raw_fifo";
            this.lbl_number_of_overflow_in_data_raw_fifo.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_data_raw_fifo.TabIndex = 31;
            this.lbl_number_of_overflow_in_data_raw_fifo.Text = "Overflow";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 44);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Data Socket";
            // 
            // lbl_number_of_overflow_in_data_raw_socket
            // 
            this.lbl_number_of_overflow_in_data_raw_socket.AutoSize = true;
            this.lbl_number_of_overflow_in_data_raw_socket.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_raw_socket.Location = new System.Drawing.Point(171, 44);
            this.lbl_number_of_overflow_in_data_raw_socket.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_data_raw_socket.Name = "lbl_number_of_overflow_in_data_raw_socket";
            this.lbl_number_of_overflow_in_data_raw_socket.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_data_raw_socket.TabIndex = 24;
            this.lbl_number_of_overflow_in_data_raw_socket.Text = "Overflow";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(15, 129);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(117, 20);
            this.label48.TabIndex = 23;
            this.label48.Text = "Command Data";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(15, 71);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(81, 20);
            this.label36.TabIndex = 25;
            this.label36.Text = "Data Raw";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(15, 100);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(108, 20);
            this.label47.TabIndex = 21;
            this.label47.Text = "Data Sample";
            // 
            // lbl_number_of_overflow_in_data_sample_fifo
            // 
            this.lbl_number_of_overflow_in_data_sample_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_data_sample_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_sample_fifo.Location = new System.Drawing.Point(171, 100);
            this.lbl_number_of_overflow_in_data_sample_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_data_sample_fifo.Name = "lbl_number_of_overflow_in_data_sample_fifo";
            this.lbl_number_of_overflow_in_data_sample_fifo.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_data_sample_fifo.TabIndex = 20;
            this.lbl_number_of_overflow_in_data_sample_fifo.Text = "Overflow";
            // 
            // ctrl_percentage_use_of_fifo_data_raw_socket
            // 
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Location = new System.Drawing.Point(381, 39);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Name = "ctrl_percentage_use_of_fifo_data_raw_socket";
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Step = 1;
            this.ctrl_percentage_use_of_fifo_data_raw_socket.TabIndex = 27;
            // 
            // ctrl_percentage_use_of_fifo_data_raw_fifo
            // 
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Location = new System.Drawing.Point(381, 69);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Name = "ctrl_percentage_use_of_fifo_data_raw_fifo";
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Step = 1;
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.TabIndex = 28;
            // 
            // ctrl_percentage_use_of_command_data_fifo
            // 
            this.ctrl_percentage_use_of_command_data_fifo.Location = new System.Drawing.Point(381, 124);
            this.ctrl_percentage_use_of_command_data_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_command_data_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_command_data_fifo.Name = "ctrl_percentage_use_of_command_data_fifo";
            this.ctrl_percentage_use_of_command_data_fifo.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_command_data_fifo.Step = 1;
            this.ctrl_percentage_use_of_command_data_fifo.TabIndex = 29;
            // 
            // ctrl_percentage_use_of_data_sample_fifo
            // 
            this.ctrl_percentage_use_of_data_sample_fifo.Location = new System.Drawing.Point(381, 96);
            this.ctrl_percentage_use_of_data_sample_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_data_sample_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_data_sample_fifo.Name = "ctrl_percentage_use_of_data_sample_fifo";
            this.ctrl_percentage_use_of_data_sample_fifo.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_data_sample_fifo.Step = 1;
            this.ctrl_percentage_use_of_data_sample_fifo.TabIndex = 30;
            // 
            // lbl_rx_rate
            // 
            this.lbl_rx_rate.AutoSize = true;
            this.lbl_rx_rate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rx_rate.Location = new System.Drawing.Point(15, 19);
            this.lbl_rx_rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_rx_rate.Name = "lbl_rx_rate";
            this.lbl_rx_rate.Size = new System.Drawing.Size(63, 20);
            this.lbl_rx_rate.TabIndex = 22;
            this.lbl_rx_rate.Text = "rxRate";
            // 
            // lbl_tx_rate
            // 
            this.lbl_tx_rate.AutoSize = true;
            this.lbl_tx_rate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tx_rate.Location = new System.Drawing.Point(171, 19);
            this.lbl_tx_rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tx_rate.Name = "lbl_tx_rate";
            this.lbl_tx_rate.Size = new System.Drawing.Size(63, 20);
            this.lbl_tx_rate.TabIndex = 19;
            this.lbl_tx_rate.Text = "txRate";
            // 
            // lbl_error_no_dataformat
            // 
            this.lbl_error_no_dataformat.AutoSize = true;
            this.lbl_error_no_dataformat.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_no_dataformat.Location = new System.Drawing.Point(11, 309);
            this.lbl_error_no_dataformat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_no_dataformat.Name = "lbl_error_no_dataformat";
            this.lbl_error_no_dataformat.Size = new System.Drawing.Size(216, 20);
            this.lbl_error_no_dataformat.TabIndex = 11;
            this.lbl_error_no_dataformat.Text = "lbl_error_no_dataformat";
            // 
            // lbl_unformatted_data
            // 
            this.lbl_unformatted_data.AutoSize = true;
            this.lbl_unformatted_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_unformatted_data.Location = new System.Drawing.Point(11, 415);
            this.lbl_unformatted_data.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_unformatted_data.Name = "lbl_unformatted_data";
            this.lbl_unformatted_data.Size = new System.Drawing.Size(189, 20);
            this.lbl_unformatted_data.TabIndex = 11;
            this.lbl_unformatted_data.Text = "lbl_unformatted_data";
            // 
            // lbl_resynchronization
            // 
            this.lbl_resynchronization.AutoSize = true;
            this.lbl_resynchronization.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_resynchronization.Location = new System.Drawing.Point(11, 431);
            this.lbl_resynchronization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resynchronization.Name = "lbl_resynchronization";
            this.lbl_resynchronization.Size = new System.Drawing.Size(198, 20);
            this.lbl_resynchronization.TabIndex = 11;
            this.lbl_resynchronization.Text = "lbl_resynchronization";
            // 
            // lbl_not_enough_data
            // 
            this.lbl_not_enough_data.AutoSize = true;
            this.lbl_not_enough_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_not_enough_data.Location = new System.Drawing.Point(11, 395);
            this.lbl_not_enough_data.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_not_enough_data.Name = "lbl_not_enough_data";
            this.lbl_not_enough_data.Size = new System.Drawing.Size(180, 20);
            this.lbl_not_enough_data.TabIndex = 10;
            this.lbl_not_enough_data.Text = "lbl_not_enough_data";
            // 
            // lbl_error_data
            // 
            this.lbl_error_data.AutoSize = true;
            this.lbl_error_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data.Location = new System.Drawing.Point(11, 290);
            this.lbl_error_data.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_data.Name = "lbl_error_data";
            this.lbl_error_data.Size = new System.Drawing.Size(135, 20);
            this.lbl_error_data.TabIndex = 10;
            this.lbl_error_data.Text = "lbl_error_data";
            // 
            // lbl_error_data_header
            // 
            this.lbl_error_data_header.AutoSize = true;
            this.lbl_error_data_header.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data_header.Location = new System.Drawing.Point(11, 271);
            this.lbl_error_data_header.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_data_header.Name = "lbl_error_data_header";
            this.lbl_error_data_header.Size = new System.Drawing.Size(198, 20);
            this.lbl_error_data_header.TabIndex = 10;
            this.lbl_error_data_header.Text = "lbl_error_data_header";
            // 
            // lbl_error_data_format_entry
            // 
            this.lbl_error_data_format_entry.AutoSize = true;
            this.lbl_error_data_format_entry.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data_format_entry.Location = new System.Drawing.Point(11, 255);
            this.lbl_error_data_format_entry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_data_format_entry.Name = "lbl_error_data_format_entry";
            this.lbl_error_data_format_entry.Size = new System.Drawing.Size(252, 20);
            this.lbl_error_data_format_entry.TabIndex = 10;
            this.lbl_error_data_format_entry.Text = "lbl_error_data_format_entry";
            // 
            // lbl_error_data_format_header
            // 
            this.lbl_error_data_format_header.AutoSize = true;
            this.lbl_error_data_format_header.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data_format_header.Location = new System.Drawing.Point(11, 239);
            this.lbl_error_data_format_header.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_data_format_header.Name = "lbl_error_data_format_header";
            this.lbl_error_data_format_header.Size = new System.Drawing.Size(261, 20);
            this.lbl_error_data_format_header.TabIndex = 10;
            this.lbl_error_data_format_header.Text = "lbl_error_data_format_header";
            // 
            // lbl_error_command_data
            // 
            this.lbl_error_command_data.AutoSize = true;
            this.lbl_error_command_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_command_data.Location = new System.Drawing.Point(11, 220);
            this.lbl_error_command_data.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_command_data.Name = "lbl_error_command_data";
            this.lbl_error_command_data.Size = new System.Drawing.Size(207, 20);
            this.lbl_error_command_data.TabIndex = 10;
            this.lbl_error_command_data.Text = "lbl_error_command_data";
            // 
            // lbl_error_command_header
            // 
            this.lbl_error_command_header.AutoSize = true;
            this.lbl_error_command_header.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_command_header.Location = new System.Drawing.Point(11, 201);
            this.lbl_error_command_header.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_command_header.Name = "lbl_error_command_header";
            this.lbl_error_command_header.Size = new System.Drawing.Size(225, 20);
            this.lbl_error_command_header.TabIndex = 10;
            this.lbl_error_command_header.Text = "lbl_error_command_header";
            // 
            // lbl_number_of_spectra
            // 
            this.lbl_number_of_spectra.AutoSize = true;
            this.lbl_number_of_spectra.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_spectra.Location = new System.Drawing.Point(11, 376);
            this.lbl_number_of_spectra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_spectra.Name = "lbl_number_of_spectra";
            this.lbl_number_of_spectra.Size = new System.Drawing.Size(198, 20);
            this.lbl_number_of_spectra.TabIndex = 10;
            this.lbl_number_of_spectra.Text = "lbl_number_of_spectra";
            // 
            // lbl_number_of_data
            // 
            this.lbl_number_of_data.AutoSize = true;
            this.lbl_number_of_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_data.Location = new System.Drawing.Point(11, 359);
            this.lbl_number_of_data.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_data.Name = "lbl_number_of_data";
            this.lbl_number_of_data.Size = new System.Drawing.Size(171, 20);
            this.lbl_number_of_data.TabIndex = 10;
            this.lbl_number_of_data.Text = "lbl_number_of_data";
            // 
            // lbl_number_of_format
            // 
            this.lbl_number_of_format.AutoSize = true;
            this.lbl_number_of_format.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_format.Location = new System.Drawing.Point(11, 341);
            this.lbl_number_of_format.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_format.Name = "lbl_number_of_format";
            this.lbl_number_of_format.Size = new System.Drawing.Size(189, 20);
            this.lbl_number_of_format.TabIndex = 10;
            this.lbl_number_of_format.Text = "lbl_number_of_format";
            // 
            // lbl_number_of_command
            // 
            this.lbl_number_of_command.AutoSize = true;
            this.lbl_number_of_command.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_command.Location = new System.Drawing.Point(11, 324);
            this.lbl_number_of_command.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_command.Name = "lbl_number_of_command";
            this.lbl_number_of_command.Size = new System.Drawing.Size(198, 20);
            this.lbl_number_of_command.TabIndex = 10;
            this.lbl_number_of_command.Text = "lbl_number_of_command";
            // 
            // lbl_error_unknow_telegram_type
            // 
            this.lbl_error_unknow_telegram_type.AutoSize = true;
            this.lbl_error_unknow_telegram_type.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_unknow_telegram_type.Location = new System.Drawing.Point(11, 186);
            this.lbl_error_unknow_telegram_type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_error_unknow_telegram_type.Name = "lbl_error_unknow_telegram_type";
            this.lbl_error_unknow_telegram_type.Size = new System.Drawing.Size(279, 20);
            this.lbl_error_unknow_telegram_type.TabIndex = 10;
            this.lbl_error_unknow_telegram_type.Text = "lbl_error_unknow_telegram_type";
            // 
            // tbp_motion
            // 
            this.tbp_motion.Controls.Add(this.groupBox3);
            this.tbp_motion.Controls.Add(this.btn_JOG_Positive_Start);
            this.tbp_motion.Controls.Add(this.btn_origin_return);
            this.tbp_motion.Controls.Add(this.btn_JOG_Stop);
            this.tbp_motion.Controls.Add(this.btn_JOG_Negative_Start);
            this.tbp_motion.Controls.Add(this.btn_PosingStop);
            this.tbp_motion.Location = new System.Drawing.Point(4, 26);
            this.tbp_motion.Margin = new System.Windows.Forms.Padding(4);
            this.tbp_motion.Name = "tbp_motion";
            this.tbp_motion.Padding = new System.Windows.Forms.Padding(4);
            this.tbp_motion.Size = new System.Drawing.Size(1424, 460);
            this.tbp_motion.TabIndex = 7;
            this.tbp_motion.Text = "運動";
            this.tbp_motion.UseVisualStyleBackColor = true;
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
            this.cb_SelectMeasureDistance.Location = new System.Drawing.Point(814, 240);
            this.cb_SelectMeasureDistance.Margin = new System.Windows.Forms.Padding(4);
            this.cb_SelectMeasureDistance.Name = "cb_SelectMeasureDistance";
            this.cb_SelectMeasureDistance.Size = new System.Drawing.Size(83, 29);
            this.cb_SelectMeasureDistance.TabIndex = 121;
            this.cb_SelectMeasureDistance.SelectedIndexChanged += new System.EventHandler(this.cb_SelectMeasureDistance_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label35.Location = new System.Drawing.Point(810, 206);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(78, 22);
            this.label35.TabIndex = 122;
            this.label35.Text = "掃描距離";
            // 
            // btn_moveto_WaferCenter_point
            // 
            this.btn_moveto_WaferCenter_point.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_moveto_WaferCenter_point.Location = new System.Drawing.Point(660, 162);
            this.btn_moveto_WaferCenter_point.Margin = new System.Windows.Forms.Padding(4);
            this.btn_moveto_WaferCenter_point.Name = "btn_moveto_WaferCenter_point";
            this.btn_moveto_WaferCenter_point.Size = new System.Drawing.Size(111, 54);
            this.btn_moveto_WaferCenter_point.TabIndex = 124;
            this.btn_moveto_WaferCenter_point.Text = "自動模式";
            this.btn_moveto_WaferCenter_point.UseVisualStyleBackColor = true;
            this.btn_moveto_WaferCenter_point.Click += new System.EventHandler(this.btn_auto_measurement);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.btn_move_distance_r);
            this.groupBox7.Controls.Add(this.btn_moveR_cw);
            this.groupBox7.Controls.Add(this.btn_moveR_ccw);
            this.groupBox7.Controls.Add(this.btn_move_distance_z);
            this.groupBox7.Controls.Add(this.btn_move_distance);
            this.groupBox7.Controls.Add(this.btn_movex_negative);
            this.groupBox7.Controls.Add(this.btn_movex_positive);
            this.groupBox7.Controls.Add(this.btn_movey_negative);
            this.groupBox7.Controls.Add(this.btn_movey_positive);
            this.groupBox7.Controls.Add(this.btn_movez_positive);
            this.groupBox7.Controls.Add(this.btn_movez_negative);
            this.groupBox7.Location = new System.Drawing.Point(972, 27);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(431, 234);
            this.groupBox7.TabIndex = 157;
            this.groupBox7.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(271, 204);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 22);
            this.label12.TabIndex = 188;
            this.label12.Text = "um";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(342, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 22);
            this.label11.TabIndex = 187;
            this.label11.Text = "0.001度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(113, 204);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 22);
            this.label8.TabIndex = 186;
            this.label8.Text = "um";
            // 
            // btn_move_distance_r
            // 
            this.btn_move_distance_r.BackColor = System.Drawing.Color.White;
            this.btn_move_distance_r.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance_r.Location = new System.Drawing.Point(342, 92);
            this.btn_move_distance_r.Margin = new System.Windows.Forms.Padding(4);
            this.btn_move_distance_r.Name = "btn_move_distance_r";
            this.btn_move_distance_r.Size = new System.Drawing.Size(69, 36);
            this.btn_move_distance_r.TabIndex = 167;
            this.btn_move_distance_r.Text = "1";
            this.btn_move_distance_r.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance_r.UseVisualStyleBackColor = false;
            this.btn_move_distance_r.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // btn_moveR_cw
            // 
            this.btn_moveR_cw.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveR_cw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_moveR_cw.Image = ((System.Drawing.Image)(resources.GetObject("btn_moveR_cw.Image")));
            this.btn_moveR_cw.Location = new System.Drawing.Point(342, 30);
            this.btn_moveR_cw.Margin = new System.Windows.Forms.Padding(4);
            this.btn_moveR_cw.Name = "btn_moveR_cw";
            this.btn_moveR_cw.Size = new System.Drawing.Size(69, 60);
            this.btn_moveR_cw.TabIndex = 166;
            this.btn_moveR_cw.Text = "CW";
            this.btn_moveR_cw.UseVisualStyleBackColor = true;
            this.btn_moveR_cw.Click += new System.EventHandler(this.btn_moveR_Click);
            // 
            // btn_moveR_ccw
            // 
            this.btn_moveR_ccw.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveR_ccw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_moveR_ccw.Image = ((System.Drawing.Image)(resources.GetObject("btn_moveR_ccw.Image")));
            this.btn_moveR_ccw.Location = new System.Drawing.Point(342, 136);
            this.btn_moveR_ccw.Margin = new System.Windows.Forms.Padding(4);
            this.btn_moveR_ccw.Name = "btn_moveR_ccw";
            this.btn_moveR_ccw.Size = new System.Drawing.Size(69, 64);
            this.btn_moveR_ccw.TabIndex = 165;
            this.btn_moveR_ccw.Text = "CCW";
            this.btn_moveR_ccw.UseVisualStyleBackColor = true;
            this.btn_moveR_ccw.Click += new System.EventHandler(this.btn_moveR_Click);
            // 
            // btn_move_distance_z
            // 
            this.btn_move_distance_z.BackColor = System.Drawing.Color.White;
            this.btn_move_distance_z.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance_z.Location = new System.Drawing.Point(255, 94);
            this.btn_move_distance_z.Margin = new System.Windows.Forms.Padding(4);
            this.btn_move_distance_z.Name = "btn_move_distance_z";
            this.btn_move_distance_z.Size = new System.Drawing.Size(70, 36);
            this.btn_move_distance_z.TabIndex = 164;
            this.btn_move_distance_z.Text = "1000";
            this.btn_move_distance_z.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance_z.UseVisualStyleBackColor = false;
            this.btn_move_distance_z.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // btn_move_distance
            // 
            this.btn_move_distance.BackColor = System.Drawing.Color.White;
            this.btn_move_distance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance.Location = new System.Drawing.Point(92, 95);
            this.btn_move_distance.Margin = new System.Windows.Forms.Padding(4);
            this.btn_move_distance.Name = "btn_move_distance";
            this.btn_move_distance.Size = new System.Drawing.Size(79, 36);
            this.btn_move_distance.TabIndex = 162;
            this.btn_move_distance.Text = "10000";
            this.btn_move_distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance.UseVisualStyleBackColor = false;
            this.btn_move_distance.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // btn_movex_negative
            // 
            this.btn_movex_negative.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movex_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movex_negative.Image")));
            this.btn_movex_negative.Location = new System.Drawing.Point(18, 79);
            this.btn_movex_negative.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movex_negative.Name = "btn_movex_negative";
            this.btn_movex_negative.Size = new System.Drawing.Size(60, 61);
            this.btn_movex_negative.TabIndex = 123;
            this.btn_movex_negative.Text = "X-";
            this.btn_movex_negative.UseVisualStyleBackColor = true;
            this.btn_movex_negative.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movex_positive
            // 
            this.btn_movex_positive.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movex_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movex_positive.Image")));
            this.btn_movex_positive.Location = new System.Drawing.Point(178, 76);
            this.btn_movex_positive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movex_positive.Name = "btn_movex_positive";
            this.btn_movex_positive.Size = new System.Drawing.Size(60, 61);
            this.btn_movex_positive.TabIndex = 90;
            this.btn_movex_positive.Text = "X+";
            this.btn_movex_positive.UseVisualStyleBackColor = true;
            this.btn_movex_positive.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movey_negative
            // 
            this.btn_movey_negative.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movey_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movey_negative.Image")));
            this.btn_movey_negative.Location = new System.Drawing.Point(98, 136);
            this.btn_movey_negative.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movey_negative.Name = "btn_movey_negative";
            this.btn_movey_negative.Size = new System.Drawing.Size(64, 61);
            this.btn_movey_negative.TabIndex = 126;
            this.btn_movey_negative.Text = "Y-";
            this.btn_movey_negative.UseVisualStyleBackColor = true;
            this.btn_movey_negative.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movey_positive
            // 
            this.btn_movey_positive.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movey_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movey_positive.Image")));
            this.btn_movey_positive.Location = new System.Drawing.Point(98, 29);
            this.btn_movey_positive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movey_positive.Name = "btn_movey_positive";
            this.btn_movey_positive.Size = new System.Drawing.Size(64, 61);
            this.btn_movey_positive.TabIndex = 125;
            this.btn_movey_positive.Text = "Y+";
            this.btn_movey_positive.UseVisualStyleBackColor = true;
            this.btn_movey_positive.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movez_positive
            // 
            this.btn_movez_positive.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movez_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movez_positive.Image")));
            this.btn_movez_positive.Location = new System.Drawing.Point(255, 30);
            this.btn_movez_positive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movez_positive.Name = "btn_movez_positive";
            this.btn_movez_positive.Size = new System.Drawing.Size(69, 60);
            this.btn_movez_positive.TabIndex = 128;
            this.btn_movez_positive.Text = "Z+";
            this.btn_movez_positive.UseVisualStyleBackColor = true;
            this.btn_movez_positive.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_movez_negative
            // 
            this.btn_movez_negative.Font = new System.Drawing.Font("PMingLiU", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movez_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movez_negative.Image")));
            this.btn_movez_negative.Location = new System.Drawing.Point(255, 136);
            this.btn_movez_negative.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movez_negative.Name = "btn_movez_negative";
            this.btn_movez_negative.Size = new System.Drawing.Size(69, 64);
            this.btn_movez_negative.TabIndex = 127;
            this.btn_movez_negative.Text = "Z-";
            this.btn_movez_negative.UseVisualStyleBackColor = true;
            this.btn_movez_negative.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_manual_mode
            // 
            this.btn_manual_mode.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_manual_mode.Location = new System.Drawing.Point(659, 234);
            this.btn_manual_mode.Margin = new System.Windows.Forms.Padding(4);
            this.btn_manual_mode.Name = "btn_manual_mode";
            this.btn_manual_mode.Size = new System.Drawing.Size(111, 51);
            this.btn_manual_mode.TabIndex = 160;
            this.btn_manual_mode.Text = "手動量測";
            this.btn_manual_mode.UseVisualStyleBackColor = true;
            this.btn_manual_mode.Click += new System.EventHandler(this.btn_manual_mode_Click);
            // 
            // btn_unload_wafer
            // 
            this.btn_unload_wafer.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_unload_wafer.Location = new System.Drawing.Point(660, 89);
            this.btn_unload_wafer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_unload_wafer.Name = "btn_unload_wafer";
            this.btn_unload_wafer.Size = new System.Drawing.Size(111, 56);
            this.btn_unload_wafer.TabIndex = 159;
            this.btn_unload_wafer.Text = "晶圓退出";
            this.btn_unload_wafer.UseVisualStyleBackColor = true;
            this.btn_unload_wafer.Click += new System.EventHandler(this.btn_unload_wafer_Click);
            // 
            // btn_load_wafer
            // 
            this.btn_load_wafer.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_load_wafer.Location = new System.Drawing.Point(660, 15);
            this.btn_load_wafer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_load_wafer.Name = "btn_load_wafer";
            this.btn_load_wafer.Size = new System.Drawing.Size(111, 59);
            this.btn_load_wafer.TabIndex = 158;
            this.btn_load_wafer.Text = "晶圓載入";
            this.btn_load_wafer.UseVisualStyleBackColor = true;
            this.btn_load_wafer.Click += new System.EventHandler(this.btn_load_wafer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_grab);
            this.panel1.Controls.Add(this.grp_pic_test);
            this.panel1.Controls.Add(this.pic_camera);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_wafersize);
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.tb_dieY);
            this.panel1.Controls.Add(this.tb_dieX);
            this.panel1.Controls.Add(this.tbExposure);
            this.panel1.Controls.Add(this.tbThreshold);
            this.panel1.Controls.Add(this.grp_align_test);
            this.panel1.Controls.Add(this.grp_manual_buttons);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.btn_ClearAlarm);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.cb_SelectMeasureDistance);
            this.panel1.Controls.Add(this.label44);
            this.panel1.Controls.Add(this.btn_advanced_mode);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label_zaxis);
            this.panel1.Controls.Add(this.ntb_z_cur_pos);
            this.panel1.Controls.Add(this.label_yaxis);
            this.panel1.Controls.Add(this.label_xaxis);
            this.panel1.Controls.Add(this.ntb_y_cur_pos);
            this.panel1.Controls.Add(this.hWindowControl1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btn_moveto_WaferCenter_point);
            this.panel1.Controls.Add(this.ntb_x_cur_pos);
            this.panel1.Controls.Add(this.btn_manual_mode);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.btn_unload_wafer);
            this.panel1.Controls.Add(this.btn_load_wafer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1438, 385);
            this.panel1.TabIndex = 161;
            // 
            // btn_grab
            // 
            this.btn_grab.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_grab.Location = new System.Drawing.Point(15, 201);
            this.btn_grab.Margin = new System.Windows.Forms.Padding(4);
            this.btn_grab.Name = "btn_grab";
            this.btn_grab.Size = new System.Drawing.Size(102, 46);
            this.btn_grab.TabIndex = 189;
            this.btn_grab.Text = "連續取像";
            this.btn_grab.UseVisualStyleBackColor = true;
            this.btn_grab.Click += new System.EventHandler(this.btn_grab_Click);
            // 
            // grp_pic_test
            // 
            this.grp_pic_test.Controls.Add(this.label13);
            this.grp_pic_test.Controls.Add(this.tbThreshold1);
            this.grp_pic_test.Controls.Add(this.button1);
            this.grp_pic_test.Controls.Add(this.button2);
            this.grp_pic_test.Controls.Add(this.lb_die_side1);
            this.grp_pic_test.Controls.Add(this.lb_angle1);
            this.grp_pic_test.Location = new System.Drawing.Point(419, 3);
            this.grp_pic_test.Name = "grp_pic_test";
            this.grp_pic_test.Size = new System.Drawing.Size(197, 169);
            this.grp_pic_test.TabIndex = 187;
            this.grp_pic_test.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(11, 84);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 18);
            this.label13.TabIndex = 191;
            this.label13.Text = "閥值";
            // 
            // tbThreshold1
            // 
            this.tbThreshold1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbThreshold1.Location = new System.Drawing.Point(59, 81);
            this.tbThreshold1.Margin = new System.Windows.Forms.Padding(2);
            this.tbThreshold1.Name = "tbThreshold1";
            this.tbThreshold1.Size = new System.Drawing.Size(63, 29);
            this.tbThreshold1.TabIndex = 190;
            // 
            // button1
            // 
            this.button1.Image = global::Velociraptor.Properties.Resources.dart;
            this.button1.Location = new System.Drawing.Point(72, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_find_angle_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Velociraptor.Properties.Resources.folder;
            this.button2.Location = new System.Drawing.Point(10, 16);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lb_die_side1
            // 
            this.lb_die_side1.AutoSize = true;
            this.lb_die_side1.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_die_side1.Location = new System.Drawing.Point(10, 115);
            this.lb_die_side1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_die_side1.Name = "lb_die_side1";
            this.lb_die_side1.Size = new System.Drawing.Size(40, 18);
            this.lb_die_side1.TabIndex = 4;
            this.lb_die_side1.Text = "邊長:";
            // 
            // lb_angle1
            // 
            this.lb_angle1.AutoSize = true;
            this.lb_angle1.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_angle1.Location = new System.Drawing.Point(10, 139);
            this.lb_angle1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_angle1.Name = "lb_angle1";
            this.lb_angle1.Size = new System.Drawing.Size(40, 18);
            this.lb_angle1.TabIndex = 5;
            this.lb_angle1.Text = "角度:";
            // 
            // pic_camera
            // 
            this.pic_camera.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pic_camera.Location = new System.Drawing.Point(339, 177);
            this.pic_camera.Name = "pic_camera";
            this.pic_camera.Size = new System.Drawing.Size(277, 205);
            this.pic_camera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_camera.TabIndex = 186;
            this.pic_camera.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(901, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 22);
            this.label3.TabIndex = 185;
            this.label3.Text = "吋";
            // 
            // cb_wafersize
            // 
            this.cb_wafersize.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.cb_wafersize.FormattingEnabled = true;
            this.cb_wafersize.Items.AddRange(new object[] {
            "12",
            "8"});
            this.cb_wafersize.Location = new System.Drawing.Point(815, 330);
            this.cb_wafersize.Margin = new System.Windows.Forms.Padding(4);
            this.cb_wafersize.Name = "cb_wafersize";
            this.cb_wafersize.Size = new System.Drawing.Size(83, 29);
            this.cb_wafersize.TabIndex = 183;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label40.Location = new System.Drawing.Point(811, 296);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(78, 22);
            this.label40.TabIndex = 184;
            this.label40.Text = "晶圓尺寸";
            // 
            // tb_dieY
            // 
            this.tb_dieY.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb_dieY.Location = new System.Drawing.Point(815, 146);
            this.tb_dieY.Margin = new System.Windows.Forms.Padding(2);
            this.tb_dieY.Name = "tb_dieY";
            this.tb_dieY.Size = new System.Drawing.Size(88, 29);
            this.tb_dieY.TabIndex = 182;
            // 
            // tb_dieX
            // 
            this.tb_dieX.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb_dieX.Location = new System.Drawing.Point(815, 54);
            this.tb_dieX.Margin = new System.Windows.Forms.Padding(2);
            this.tb_dieX.Name = "tb_dieX";
            this.tb_dieX.Size = new System.Drawing.Size(88, 29);
            this.tb_dieX.TabIndex = 181;
            // 
            // tbExposure
            // 
            this.tbExposure.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbExposure.Location = new System.Drawing.Point(15, 157);
            this.tbExposure.Margin = new System.Windows.Forms.Padding(2);
            this.tbExposure.Name = "tbExposure";
            this.tbExposure.Size = new System.Drawing.Size(105, 29);
            this.tbExposure.TabIndex = 180;
            // 
            // tbThreshold
            // 
            this.tbThreshold.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbThreshold.Location = new System.Drawing.Point(15, 61);
            this.tbThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(105, 29);
            this.tbThreshold.TabIndex = 179;
            // 
            // grp_align_test
            // 
            this.grp_align_test.Controls.Add(this.btn_find_angle);
            this.grp_align_test.Controls.Add(this.btn_load);
            this.grp_align_test.Controls.Add(this.lb_angle);
            this.grp_align_test.Controls.Add(this.lb_die_side);
            this.grp_align_test.Location = new System.Drawing.Point(5, 239);
            this.grp_align_test.Margin = new System.Windows.Forms.Padding(4);
            this.grp_align_test.Name = "grp_align_test";
            this.grp_align_test.Padding = new System.Windows.Forms.Padding(4);
            this.grp_align_test.Size = new System.Drawing.Size(134, 135);
            this.grp_align_test.TabIndex = 178;
            this.grp_align_test.TabStop = false;
            // 
            // btn_find_angle
            // 
            this.btn_find_angle.Image = global::Velociraptor.Properties.Resources.dart;
            this.btn_find_angle.Location = new System.Drawing.Point(71, 18);
            this.btn_find_angle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_find_angle.Name = "btn_find_angle";
            this.btn_find_angle.Size = new System.Drawing.Size(50, 50);
            this.btn_find_angle.TabIndex = 3;
            this.btn_find_angle.UseVisualStyleBackColor = true;
            this.btn_find_angle.Click += new System.EventHandler(this.btn_find_angle_Click);
            // 
            // btn_load
            // 
            this.btn_load.Image = global::Velociraptor.Properties.Resources.folder;
            this.btn_load.Location = new System.Drawing.Point(9, 18);
            this.btn_load.Margin = new System.Windows.Forms.Padding(4);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(50, 50);
            this.btn_load.TabIndex = 2;
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lb_angle
            // 
            this.lb_angle.AutoSize = true;
            this.lb_angle.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_angle.Location = new System.Drawing.Point(11, 109);
            this.lb_angle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_angle.Name = "lb_angle";
            this.lb_angle.Size = new System.Drawing.Size(40, 18);
            this.lb_angle.TabIndex = 1;
            this.lb_angle.Text = "角度:";
            // 
            // lb_die_side
            // 
            this.lb_die_side.AutoSize = true;
            this.lb_die_side.Font = new System.Drawing.Font("Microsoft JhengHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_die_side.Location = new System.Drawing.Point(11, 85);
            this.lb_die_side.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_die_side.Name = "lb_die_side";
            this.lb_die_side.Size = new System.Drawing.Size(40, 18);
            this.lb_die_side.TabIndex = 0;
            this.lb_die_side.Text = "邊長:";
            // 
            // grp_manual_buttons
            // 
            this.grp_manual_buttons.Controls.Add(this.btn_align);
            this.grp_manual_buttons.Controls.Add(this.btn_start_mea);
            this.grp_manual_buttons.Location = new System.Drawing.Point(640, 285);
            this.grp_manual_buttons.Margin = new System.Windows.Forms.Padding(4);
            this.grp_manual_buttons.Name = "grp_manual_buttons";
            this.grp_manual_buttons.Padding = new System.Windows.Forms.Padding(4);
            this.grp_manual_buttons.Size = new System.Drawing.Size(150, 90);
            this.grp_manual_buttons.TabIndex = 177;
            this.grp_manual_buttons.TabStop = false;
            this.grp_manual_buttons.Visible = false;
            // 
            // btn_align
            // 
            this.btn_align.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_align.Image = global::Velociraptor.Properties.Resources.upward;
            this.btn_align.Location = new System.Drawing.Point(5, 20);
            this.btn_align.Margin = new System.Windows.Forms.Padding(4);
            this.btn_align.Name = "btn_align";
            this.btn_align.Size = new System.Drawing.Size(64, 61);
            this.btn_align.TabIndex = 174;
            this.btn_align.UseVisualStyleBackColor = true;
            this.btn_align.Click += new System.EventHandler(this.btn_align_Click);
            // 
            // btn_start_mea
            // 
            this.btn_start_mea.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_start_mea.Image = global::Velociraptor.Properties.Resources.right_arrow;
            this.btn_start_mea.Location = new System.Drawing.Point(78, 20);
            this.btn_start_mea.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start_mea.Name = "btn_start_mea";
            this.btn_start_mea.Size = new System.Drawing.Size(64, 61);
            this.btn_start_mea.TabIndex = 175;
            this.btn_start_mea.UseVisualStyleBackColor = true;
            this.btn_start_mea.Click += new System.EventHandler(this.btn_start_mea_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label39.Location = new System.Drawing.Point(900, 239);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(37, 22);
            this.label39.TabIndex = 169;
            this.label39.Text = "um";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label42.Location = new System.Drawing.Point(810, 110);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(119, 22);
            this.label42.TabIndex = 164;
            this.label42.Text = "die Y方向寬度";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label41.Location = new System.Drawing.Point(810, 19);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(119, 22);
            this.label41.TabIndex = 163;
            this.label41.Text = "die X方向長度";
            // 
            // btn_ClearAlarm
            // 
            this.btn_ClearAlarm.Font = new System.Drawing.Font("DFKai-SB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_ClearAlarm.Image = global::Velociraptor.Properties.Resources.refresh;
            this.btn_ClearAlarm.Location = new System.Drawing.Point(1269, 305);
            this.btn_ClearAlarm.Margin = new System.Windows.Forms.Padding(1);
            this.btn_ClearAlarm.Name = "btn_ClearAlarm";
            this.btn_ClearAlarm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_ClearAlarm.Size = new System.Drawing.Size(64, 61);
            this.btn_ClearAlarm.TabIndex = 173;
            this.btn_ClearAlarm.UseVisualStyleBackColor = true;
            this.btn_ClearAlarm.Click += new System.EventHandler(this.btn_ClearAlarm_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label43.Location = new System.Drawing.Point(900, 51);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(37, 22);
            this.label43.TabIndex = 167;
            this.label43.Text = "um";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.label44.Location = new System.Drawing.Point(899, 146);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(37, 22);
            this.label44.TabIndex = 168;
            this.label44.Text = "um";
            // 
            // btn_advanced_mode
            // 
            this.btn_advanced_mode.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.btn_advanced_mode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btn_advanced_mode.Image = global::Velociraptor.Properties.Resources.administration;
            this.btn_advanced_mode.Location = new System.Drawing.Point(1340, 305);
            this.btn_advanced_mode.Margin = new System.Windows.Forms.Padding(1);
            this.btn_advanced_mode.Name = "btn_advanced_mode";
            this.btn_advanced_mode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_advanced_mode.Size = new System.Drawing.Size(64, 61);
            this.btn_advanced_mode.TabIndex = 126;
            this.btn_advanced_mode.UseVisualStyleBackColor = true;
            this.btn_advanced_mode.Click += new System.EventHandler(this.btn_advanced_mode_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(15, 104);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 46);
            this.button5.TabIndex = 171;
            this.button5.Text = "曝光時間";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(140, 2);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(1);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(253, 214);
            this.hWindowControl1.TabIndex = 169;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(253, 214);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(15, 9);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 46);
            this.button3.TabIndex = 170;
            this.button3.Text = "切割道閥值";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // f_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1438, 876);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "f_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_main_FormClosing);
            this.Load += new System.EventHandler(this.f_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_dynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grp_cursor.ResumeLayout(false);
            this.grp_cursor.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tbp_main.ResumeLayout(false);
            this.tbp_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_switch)).EndInit();
            this.grp_mea_para.ResumeLayout(false);
            this.grp_mea_para.PerformLayout();
            this.tbp_status.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tbp_motion.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grp_pic_test.ResumeLayout(false);
            this.grp_pic_test.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_camera)).EndInit();
            this.grp_align_test.ResumeLayout(false);
            this.grp_align_test.PerformLayout();
            this.grp_manual_buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MagicGraphicLibrary.NumericTextBox ntb_led_intensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_dynamic;
        private System.Windows.Forms.Label label_dynamic;
        private System.Windows.Forms.HScrollBar hsb_noise_offset;
        private System.Windows.Forms.Label label_noise_offset;
        private System.Windows.Forms.Panel chk_cursor_v3;
        private System.Windows.Forms.Panel chk_cursor_v2;
        private System.Windows.Forms.Panel chk_cursor_v1;
        private System.Windows.Forms.Label label_cursor_v3;
        private System.Windows.Forms.Label label_cursor_v2;
        private System.Windows.Forms.Label label_cursor_v1;
        private System.Windows.Forms.NumericUpDown nud_cursor_v3;
        private System.Windows.Forms.NumericUpDown nud_cursor_v2;
        private System.Windows.Forms.NumericUpDown nud_cursor_v1;
        private MagicGraphicLibrary.RawImage clsRawImage;
        private System.Windows.Forms.Button btn_origin_return;
        private System.Windows.Forms.Button btn_movex_positive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SaveFileDialog sfd_upload;
        private System.Windows.Forms.Button btn_dark;
        private System.Windows.Forms.Label label_xaxis;
        private System.Windows.Forms.Label label_yaxis;
        private System.Windows.Forms.Label label_zaxis;
        private System.Windows.Forms.GroupBox grp_cursor;
        private System.Windows.Forms.Button btn_PosingStop;
        internal System.Windows.Forms.Label ntb_x_cur_pos;
        internal System.Windows.Forms.Label ntb_y_cur_pos;
        internal System.Windows.Forms.Label ntb_z_cur_pos;
        private System.Windows.Forms.Button btn_JOG_Positive_Start;
        private System.Windows.Forms.Button btn_JOG_Stop;
        internal System.Windows.Forms.Label ntb_z_cur_motorpos;
        internal System.Windows.Forms.Label ntb_y_cur_motorpos;
        internal System.Windows.Forms.Label ntb_x_cur_motorpos;
        private System.Windows.Forms.Button btn_JOG_Negative_Start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MagicGraphicLibrary.cZedGraphic ctrl_zgc_dnld;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tbp_status;
        private System.Windows.Forms.ListView lst_log;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_number_of_overflow_in_data_format_fifo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar ctrl_percentage_use_of_data_format_fifo;
        private System.Windows.Forms.Label lbl_number_of_overflow_in_command_data_fifo;
        private System.Windows.Forms.Label lbl_number_of_overflow_in_data_raw_fifo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_number_of_overflow_in_data_raw_socket;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lbl_number_of_overflow_in_data_sample_fifo;
        private System.Windows.Forms.ProgressBar ctrl_percentage_use_of_fifo_data_raw_socket;
        private System.Windows.Forms.ProgressBar ctrl_percentage_use_of_fifo_data_raw_fifo;
        private System.Windows.Forms.ProgressBar ctrl_percentage_use_of_command_data_fifo;
        private System.Windows.Forms.ProgressBar ctrl_percentage_use_of_data_sample_fifo;
        private System.Windows.Forms.Label lbl_rx_rate;
        private System.Windows.Forms.Label lbl_tx_rate;
        private System.Windows.Forms.Label lbl_error_no_dataformat;
        private System.Windows.Forms.Label lbl_unformatted_data;
        private System.Windows.Forms.Label lbl_resynchronization;
        private System.Windows.Forms.Label lbl_not_enough_data;
        private System.Windows.Forms.Label lbl_error_data;
        private System.Windows.Forms.Label lbl_error_data_header;
        private System.Windows.Forms.Label lbl_error_data_format_entry;
        private System.Windows.Forms.Label lbl_error_data_format_header;
        private System.Windows.Forms.Label lbl_error_command_data;
        private System.Windows.Forms.Label lbl_error_command_header;
        private System.Windows.Forms.Label lbl_number_of_spectra;
        private System.Windows.Forms.Label lbl_number_of_data;
        private System.Windows.Forms.Label lbl_number_of_format;
        private System.Windows.Forms.Label lbl_number_of_command;
        private System.Windows.Forms.Label lbl_error_unknow_telegram_type;
        private System.Windows.Forms.TabPage tbp_main;
        public MagicGraphicLibrary.NumericTextBox ntb_threshold;
        private System.Windows.Forms.ComboBox cb_SelectMeasureDistance;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btn_movex_negative;
        private System.Windows.Forms.Button btn_moveto_WaferCenter_point;
        private System.Windows.Forms.Button btn_movey_positive;
        private System.Windows.Forms.Button btn_movey_negative;
        private System.Windows.Forms.Button btn_movez_negative;
        private System.Windows.Forms.Button btn_movez_positive;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_load_wafer;
        private System.Windows.Forms.Button btn_unload_wafer;
        private System.Windows.Forms.Button btn_manual_mode;
        private System.Windows.Forms.TabPage tbp_motion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_move_distance;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btn_move_distance_z;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_ClearAlarm;
        private System.Windows.Forms.Button btn_advanced_mode;
        private System.Windows.Forms.Label label38;
        internal System.Windows.Forms.Label ntb_r_cur_motorpos;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btn_align;
        private System.Windows.Forms.Button btn_start_mea;
        private System.Windows.Forms.GroupBox grp_manual_buttons;
        private System.Windows.Forms.GroupBox grp_align_test;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label lb_angle;
        private System.Windows.Forms.Label lb_die_side;
        private System.Windows.Forms.Button btn_find_angle;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_connection_ip;
        private System.Windows.Forms.TextBox tbThreshold;
        private System.Windows.Forms.TextBox tbExposure;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tb_dieX;
        private System.Windows.Forms.TextBox tb_dieY;
        private System.Windows.Forms.Button btn_move_distance_r;
        private System.Windows.Forms.Button btn_moveR_cw;
        private System.Windows.Forms.Button btn_moveR_ccw;
        private System.Windows.Forms.GroupBox grp_mea_para;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_wafersize;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.PictureBox pic_switch;
        public MagicGraphicLibrary.NumericTextBox ntb_frequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pic_camera;
        private System.Windows.Forms.GroupBox grp_pic_test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lb_die_side1;
        private System.Windows.Forms.Label lb_angle1;
        private System.Windows.Forms.Button btn_grab;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbThreshold1;
    }
}

