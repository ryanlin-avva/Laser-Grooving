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
            this.label_ipaddress = new System.Windows.Forms.Label();
            this.ntb_led_intensity = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_high_speed = new System.Windows.Forms.ComboBox();
            this.label_hz = new System.Windows.Forms.Label();
            this.cbx_high_speed_mode = new System.Windows.Forms.ComboBox();
            this.ntb_scale = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.label_Scale = new System.Windows.Forms.Label();
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
            this.ctrl_ip_address = new MagicGraphicLibrary.IPAddressControl();
            this.ntb_dnld_number_of_channels = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.ntb_dnld_first_channel = new MagicGraphicLibrary.NumericTextBox(this.components);
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
            this.label_numberofchannels = new System.Windows.Forms.Label();
            this.label_first_channel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
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
            this.btn_trigger = new System.Windows.Forms.Button();
            this.btn_connection_ip = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.btn_dark = new System.Windows.Forms.Button();
            this.tbp_sodx = new System.Windows.Forms.TabPage();
            this.chk_yaxis_auto_scale = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.lbl_number_of_acq_in_sodx_fifo = new System.Windows.Forms.Label();
            this.lbl_number_of_overflow_in_sodx_fifo = new System.Windows.Forms.Label();
            this.ctrl_percentage_use_of_sodx_fifo = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_sodx = new System.Windows.Forms.Button();
            this.lbl_global_signal_health_upp_not_finished_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_health_exposure_lost_count_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_health_upp_lost_count_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_health_ticket_wrong_order_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_health_dsp_load_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_ticket_number_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_number_of_valid_peaks_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_trigger_lost_count_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_real_lightning_time_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_real_exposure_time_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_exposure_flags_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_first_exposure_count_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_start_time_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_stop_position_v_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_stop_position_u_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_stop_position_z_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_stop_position_y_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_stop_position_x_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_start_position_v_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_start_position_u_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_start_position_z_value = new System.Windows.Forms.Label();
            this.lbl_global_signal_start_position_x_value = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.ctrl_counter_gauge = new System.Windows.Forms.ProgressBar();
            this.lbl_global_signal_start_position_y_value = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lbl_global_signal_sample_counter_value = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.num_data_acquisition_number = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.btn_sodx_pause = new System.Windows.Forms.Button();
            this.btn_sodx_execute = new System.Windows.Forms.Button();
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
            this.grp_align_test = new System.Windows.Forms.GroupBox();
            this.btn_find_angle = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.lb_angle = new System.Windows.Forms.Label();
            this.lb_die_side = new System.Windows.Forms.Label();
            this.grp_manual_buttons = new System.Windows.Forms.GroupBox();
            this.btn_align = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_start_mea = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ClearAlarm = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btn_advanced_mode = new System.Windows.Forms.Button();
            this.btn_exposure = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_imageThreshold = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grp_cursor.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tbp_main.SuspendLayout();
            this.tbp_sodx.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tbp_status.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tbp_motion.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grp_align_test.SuspendLayout();
            this.grp_manual_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ipaddress
            // 
            this.label_ipaddress.AutoSize = true;
            this.label_ipaddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ipaddress.Location = new System.Drawing.Point(8, 106);
            this.label_ipaddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ipaddress.Name = "label_ipaddress";
            this.label_ipaddress.Size = new System.Drawing.Size(89, 19);
            this.label_ipaddress.TabIndex = 4;
            this.label_ipaddress.Text = "IP Address";
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
            this.ntb_led_intensity.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ntb_led_intensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_led_intensity.InterceptArrowKeys = true;
            this.ntb_led_intensity.Location = new System.Drawing.Point(29, 137);
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
            this.ntb_led_intensity.Size = new System.Drawing.Size(86, 26);
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
            this.label2.Location = new System.Drawing.Point(117, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(28, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "光源強度";
            // 
            // cbx_high_speed
            // 
            this.cbx_high_speed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_high_speed.FormattingEnabled = true;
            this.cbx_high_speed.Location = new System.Drawing.Point(160, 16);
            this.cbx_high_speed.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_high_speed.Name = "cbx_high_speed";
            this.cbx_high_speed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbx_high_speed.Size = new System.Drawing.Size(89, 24);
            this.cbx_high_speed.TabIndex = 15;
            // 
            // label_hz
            // 
            this.label_hz.AutoSize = true;
            this.label_hz.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hz.Location = new System.Drawing.Point(258, 22);
            this.label_hz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_hz.Name = "label_hz";
            this.label_hz.Size = new System.Drawing.Size(27, 20);
            this.label_hz.TabIndex = 3;
            this.label_hz.Text = "Hz";
            // 
            // cbx_high_speed_mode
            // 
            this.cbx_high_speed_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_high_speed_mode.FormattingEnabled = true;
            this.cbx_high_speed_mode.Location = new System.Drawing.Point(8, 16);
            this.cbx_high_speed_mode.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_high_speed_mode.Name = "cbx_high_speed_mode";
            this.cbx_high_speed_mode.Size = new System.Drawing.Size(142, 24);
            this.cbx_high_speed_mode.TabIndex = 16;
            // 
            // ntb_scale
            // 
            this.ntb_scale.AutoValidate = false;
            this.ntb_scale.AutoValidationTime = 1000;
            this.ntb_scale.BackColor = System.Drawing.Color.White;
            this.ntb_scale.DecimalPlaces = 0;
            this.ntb_scale.EnableErrorValue = false;
            this.ntb_scale.EnableWarningValue = false;
            this.ntb_scale.ErrorColor = System.Drawing.Color.OrangeRed;
            this.ntb_scale.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_scale.HideSelection = false;
            this.ntb_scale.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ntb_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_scale.InterceptArrowKeys = true;
            this.ntb_scale.Location = new System.Drawing.Point(68, 49);
            this.ntb_scale.Margin = new System.Windows.Forms.Padding(4);
            this.ntb_scale.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ntb_scale.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_scale.Name = "ntb_scale";
            this.ntb_scale.Size = new System.Drawing.Size(55, 27);
            this.ntb_scale.TabIndex = 7;
            this.ntb_scale.Text = "230";
            this.ntb_scale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_scale.ThousandsSeparator = false;
            this.ntb_scale.Value = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.ntb_scale.WarningColor = System.Drawing.Color.Gold;
            this.ntb_scale.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_scale.WordWrap = false;
            // 
            // label_Scale
            // 
            this.label_Scale.AutoSize = true;
            this.label_Scale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Scale.Location = new System.Drawing.Point(8, 54);
            this.label_Scale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Scale.Name = "label_Scale";
            this.label_Scale.Size = new System.Drawing.Size(50, 19);
            this.label_Scale.TabIndex = 5;
            this.label_Scale.Text = "Scale";
            // 
            // nud_dynamic
            // 
            this.nud_dynamic.Location = new System.Drawing.Point(20, 314);
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
            this.label_dynamic.Location = new System.Drawing.Point(22, 294);
            this.label_dynamic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dynamic.Name = "label_dynamic";
            this.label_dynamic.Size = new System.Drawing.Size(66, 17);
            this.label_dynamic.TabIndex = 70;
            this.label_dynamic.Text = "Dynamic";
            // 
            // hsb_noise_offset
            // 
            this.hsb_noise_offset.Location = new System.Drawing.Point(18, 248);
            this.hsb_noise_offset.Name = "hsb_noise_offset";
            this.hsb_noise_offset.Size = new System.Drawing.Size(85, 17);
            this.hsb_noise_offset.TabIndex = 69;
            this.hsb_noise_offset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsb_noise_offset_Scroll);
            // 
            // label_noise_offset
            // 
            this.label_noise_offset.AutoSize = true;
            this.label_noise_offset.Location = new System.Drawing.Point(14, 228);
            this.label_noise_offset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_noise_offset.Name = "label_noise_offset";
            this.label_noise_offset.Size = new System.Drawing.Size(88, 17);
            this.label_noise_offset.TabIndex = 68;
            this.label_noise_offset.Text = "Noise Offset";
            // 
            // chk_cursor_v3
            // 
            this.chk_cursor_v3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chk_cursor_v3.Location = new System.Drawing.Point(18, 174);
            this.chk_cursor_v3.Margin = new System.Windows.Forms.Padding(4);
            this.chk_cursor_v3.Name = "chk_cursor_v3";
            this.chk_cursor_v3.Size = new System.Drawing.Size(25, 22);
            this.chk_cursor_v3.TabIndex = 65;
            this.chk_cursor_v3.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // chk_cursor_v2
            // 
            this.chk_cursor_v2.BackColor = System.Drawing.Color.Blue;
            this.chk_cursor_v2.Location = new System.Drawing.Point(18, 104);
            this.chk_cursor_v2.Margin = new System.Windows.Forms.Padding(4);
            this.chk_cursor_v2.Name = "chk_cursor_v2";
            this.chk_cursor_v2.Size = new System.Drawing.Size(25, 22);
            this.chk_cursor_v2.TabIndex = 66;
            this.chk_cursor_v2.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // chk_cursor_v1
            // 
            this.chk_cursor_v1.BackColor = System.Drawing.Color.Red;
            this.chk_cursor_v1.Location = new System.Drawing.Point(18, 40);
            this.chk_cursor_v1.Margin = new System.Windows.Forms.Padding(4);
            this.chk_cursor_v1.Name = "chk_cursor_v1";
            this.chk_cursor_v1.Size = new System.Drawing.Size(25, 22);
            this.chk_cursor_v1.TabIndex = 67;
            this.chk_cursor_v1.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // label_cursor_v3
            // 
            this.label_cursor_v3.AutoSize = true;
            this.label_cursor_v3.Location = new System.Drawing.Point(14, 156);
            this.label_cursor_v3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cursor_v3.Name = "label_cursor_v3";
            this.label_cursor_v3.Size = new System.Drawing.Size(75, 17);
            this.label_cursor_v3.TabIndex = 64;
            this.label_cursor_v3.Text = "Cursor V3";
            // 
            // label_cursor_v2
            // 
            this.label_cursor_v2.AutoSize = true;
            this.label_cursor_v2.Location = new System.Drawing.Point(14, 86);
            this.label_cursor_v2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cursor_v2.Name = "label_cursor_v2";
            this.label_cursor_v2.Size = new System.Drawing.Size(75, 17);
            this.label_cursor_v2.TabIndex = 63;
            this.label_cursor_v2.Text = "Cursor V2";
            // 
            // label_cursor_v1
            // 
            this.label_cursor_v1.AutoSize = true;
            this.label_cursor_v1.Location = new System.Drawing.Point(14, 22);
            this.label_cursor_v1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cursor_v1.Name = "label_cursor_v1";
            this.label_cursor_v1.Size = new System.Drawing.Size(75, 17);
            this.label_cursor_v1.TabIndex = 62;
            this.label_cursor_v1.Text = "Cursor V1";
            // 
            // nud_cursor_v3
            // 
            this.nud_cursor_v3.Location = new System.Drawing.Point(52, 174);
            this.nud_cursor_v3.Margin = new System.Windows.Forms.Padding(4);
            this.nud_cursor_v3.Name = "nud_cursor_v3";
            this.nud_cursor_v3.Size = new System.Drawing.Size(60, 27);
            this.nud_cursor_v3.TabIndex = 59;
            this.nud_cursor_v3.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // nud_cursor_v2
            // 
            this.nud_cursor_v2.Location = new System.Drawing.Point(52, 104);
            this.nud_cursor_v2.Margin = new System.Windows.Forms.Padding(4);
            this.nud_cursor_v2.Name = "nud_cursor_v2";
            this.nud_cursor_v2.Size = new System.Drawing.Size(60, 27);
            this.nud_cursor_v2.TabIndex = 60;
            this.nud_cursor_v2.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // nud_cursor_v1
            // 
            this.nud_cursor_v1.Location = new System.Drawing.Point(52, 40);
            this.nud_cursor_v1.Margin = new System.Windows.Forms.Padding(4);
            this.nud_cursor_v1.Name = "nud_cursor_v1";
            this.nud_cursor_v1.Size = new System.Drawing.Size(60, 27);
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
            this.clsRawImage.Location = new System.Drawing.Point(199, 35);
            this.clsRawImage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
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
            // ctrl_ip_address
            // 
            this.ctrl_ip_address.AllowInternalTab = false;
            this.ctrl_ip_address.AutoHeight = true;
            this.ctrl_ip_address.BackColor = System.Drawing.SystemColors.Window;
            this.ctrl_ip_address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrl_ip_address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ctrl_ip_address.Location = new System.Drawing.Point(8, 129);
            this.ctrl_ip_address.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_ip_address.MinimumSize = new System.Drawing.Size(114, 27);
            this.ctrl_ip_address.Name = "ctrl_ip_address";
            this.ctrl_ip_address.ReadOnly = false;
            this.ctrl_ip_address.Size = new System.Drawing.Size(161, 27);
            this.ctrl_ip_address.TabIndex = 5;
            this.ctrl_ip_address.Text = "0.0.0.0";
            // 
            // ntb_dnld_number_of_channels
            // 
            this.ntb_dnld_number_of_channels.AutoValidate = true;
            this.ntb_dnld_number_of_channels.AutoValidationTime = 5000;
            this.ntb_dnld_number_of_channels.BackColor = System.Drawing.Color.White;
            this.ntb_dnld_number_of_channels.DecimalPlaces = 0;
            this.ntb_dnld_number_of_channels.EnableErrorValue = false;
            this.ntb_dnld_number_of_channels.EnableWarningValue = false;
            this.ntb_dnld_number_of_channels.ErrorColor = System.Drawing.Color.OrangeRed;
            this.ntb_dnld_number_of_channels.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_dnld_number_of_channels.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_dnld_number_of_channels.InterceptArrowKeys = true;
            this.ntb_dnld_number_of_channels.Location = new System.Drawing.Point(338, 90);
            this.ntb_dnld_number_of_channels.Margin = new System.Windows.Forms.Padding(4);
            this.ntb_dnld_number_of_channels.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ntb_dnld_number_of_channels.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_dnld_number_of_channels.Name = "ntb_dnld_number_of_channels";
            this.ntb_dnld_number_of_channels.ReadOnly = true;
            this.ntb_dnld_number_of_channels.Size = new System.Drawing.Size(55, 27);
            this.ntb_dnld_number_of_channels.TabIndex = 81;
            this.ntb_dnld_number_of_channels.Text = "192";
            this.ntb_dnld_number_of_channels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_dnld_number_of_channels.ThousandsSeparator = false;
            this.ntb_dnld_number_of_channels.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            this.ntb_dnld_number_of_channels.WarningColor = System.Drawing.Color.Gold;
            this.ntb_dnld_number_of_channels.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ntb_dnld_first_channel
            // 
            this.ntb_dnld_first_channel.AutoValidate = true;
            this.ntb_dnld_first_channel.AutoValidationTime = 5000;
            this.ntb_dnld_first_channel.BackColor = System.Drawing.Color.White;
            this.ntb_dnld_first_channel.DecimalPlaces = 0;
            this.ntb_dnld_first_channel.EnableErrorValue = false;
            this.ntb_dnld_first_channel.EnableWarningValue = false;
            this.ntb_dnld_first_channel.ErrorColor = System.Drawing.Color.OrangeRed;
            this.ntb_dnld_first_channel.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_dnld_first_channel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_dnld_first_channel.InterceptArrowKeys = true;
            this.ntb_dnld_first_channel.Location = new System.Drawing.Point(338, 55);
            this.ntb_dnld_first_channel.Margin = new System.Windows.Forms.Padding(4);
            this.ntb_dnld_first_channel.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ntb_dnld_first_channel.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_dnld_first_channel.Name = "ntb_dnld_first_channel";
            this.ntb_dnld_first_channel.ReadOnly = true;
            this.ntb_dnld_first_channel.Size = new System.Drawing.Size(55, 27);
            this.ntb_dnld_first_channel.TabIndex = 80;
            this.ntb_dnld_first_channel.Text = "0";
            this.ntb_dnld_first_channel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_dnld_first_channel.ThousandsSeparator = false;
            this.ntb_dnld_first_channel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_dnld_first_channel.WarningColor = System.Drawing.Color.Gold;
            this.ntb_dnld_first_channel.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btn_origin_return
            // 
            this.btn_origin_return.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_origin_return.Location = new System.Drawing.Point(748, 30);
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
            this.groupBox3.Controls.Add(this.ctrl_ip_address);
            this.groupBox3.Controls.Add(this.label_ipaddress);
            this.groupBox3.Controls.Add(this.ntb_dnld_first_channel);
            this.groupBox3.Controls.Add(this.label_numberofchannels);
            this.groupBox3.Controls.Add(this.ntb_dnld_number_of_channels);
            this.groupBox3.Controls.Add(this.label_first_channel);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label_Scale);
            this.groupBox3.Controls.Add(this.cbx_high_speed);
            this.groupBox3.Controls.Add(this.ntb_scale);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbx_high_speed_mode);
            this.groupBox3.Controls.Add(this.label_hz);
            this.groupBox3.Location = new System.Drawing.Point(11, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(630, 180);
            this.groupBox3.TabIndex = 93;
            this.groupBox3.TabStop = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(512, 129);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(98, 17);
            this.label38.TabIndex = 123;
            this.label38.Text = "r軸馬達位置";
            // 
            // ntb_r_cur_motorpos
            // 
            this.ntb_r_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_r_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_r_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_r_cur_motorpos.Location = new System.Drawing.Point(421, 120);
            this.ntb_r_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_r_cur_motorpos.Name = "ntb_r_cur_motorpos";
            this.ntb_r_cur_motorpos.Size = new System.Drawing.Size(86, 25);
            this.ntb_r_cur_motorpos.TabIndex = 122;
            this.ntb_r_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(512, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 121;
            this.label7.Text = "z軸馬達位置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 121;
            this.label6.Text = "y軸馬達位置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 120;
            this.label5.Text = "x軸馬達位置";
            // 
            // ntb_z_cur_motorpos
            // 
            this.ntb_z_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_z_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_z_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_z_cur_motorpos.Location = new System.Drawing.Point(421, 88);
            this.ntb_z_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_z_cur_motorpos.Name = "ntb_z_cur_motorpos";
            this.ntb_z_cur_motorpos.Size = new System.Drawing.Size(86, 25);
            this.ntb_z_cur_motorpos.TabIndex = 118;
            this.ntb_z_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_y_cur_motorpos
            // 
            this.ntb_y_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_y_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_y_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_y_cur_motorpos.Location = new System.Drawing.Point(421, 55);
            this.ntb_y_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_y_cur_motorpos.Name = "ntb_y_cur_motorpos";
            this.ntb_y_cur_motorpos.Size = new System.Drawing.Size(86, 25);
            this.ntb_y_cur_motorpos.TabIndex = 117;
            this.ntb_y_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_x_cur_motorpos
            // 
            this.ntb_x_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_x_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_motorpos.Location = new System.Drawing.Point(421, 24);
            this.ntb_x_cur_motorpos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_x_cur_motorpos.Name = "ntb_x_cur_motorpos";
            this.ntb_x_cur_motorpos.Size = new System.Drawing.Size(86, 25);
            this.ntb_x_cur_motorpos.TabIndex = 116;
            this.ntb_x_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_numberofchannels
            // 
            this.label_numberofchannels.AutoSize = true;
            this.label_numberofchannels.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numberofchannels.Location = new System.Drawing.Point(199, 89);
            this.label_numberofchannels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_numberofchannels.Name = "label_numberofchannels";
            this.label_numberofchannels.Size = new System.Drawing.Size(125, 19);
            this.label_numberofchannels.TabIndex = 96;
            this.label_numberofchannels.Text = "Num / Channels";
            // 
            // label_first_channel
            // 
            this.label_first_channel.AutoSize = true;
            this.label_first_channel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_first_channel.Location = new System.Drawing.Point(208, 59);
            this.label_first_channel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_first_channel.Name = "label_first_channel";
            this.label_first_channel.Size = new System.Drawing.Size(106, 19);
            this.label_first_channel.TabIndex = 95;
            this.label_first_channel.Text = "First Channel";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(160, 16);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(89, 24);
            this.comboBox2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "閥值";
            this.label4.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(258, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hz";
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
            this.ntb_threshold.Location = new System.Drawing.Point(29, 216);
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
            this.ntb_threshold.Size = new System.Drawing.Size(96, 26);
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
            this.label_xaxis.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_xaxis.Location = new System.Drawing.Point(988, 218);
            this.label_xaxis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_xaxis.Name = "label_xaxis";
            this.label_xaxis.Size = new System.Drawing.Size(45, 25);
            this.label_xaxis.TabIndex = 99;
            this.label_xaxis.Text = "X軸";
            // 
            // label_yaxis
            // 
            this.label_yaxis.AutoSize = true;
            this.label_yaxis.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_yaxis.Location = new System.Drawing.Point(1084, 218);
            this.label_yaxis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_yaxis.Name = "label_yaxis";
            this.label_yaxis.Size = new System.Drawing.Size(44, 25);
            this.label_yaxis.TabIndex = 100;
            this.label_yaxis.Text = "Y軸";
            // 
            // label_zaxis
            // 
            this.label_zaxis.AutoSize = true;
            this.label_zaxis.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_zaxis.Location = new System.Drawing.Point(1181, 218);
            this.label_zaxis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_zaxis.Name = "label_zaxis";
            this.label_zaxis.Size = new System.Drawing.Size(45, 25);
            this.label_zaxis.TabIndex = 101;
            this.label_zaxis.Text = "Z軸";
            // 
            // grp_cursor
            // 
            this.grp_cursor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_cursor.Controls.Add(this.nud_dynamic);
            this.grp_cursor.Controls.Add(this.nud_cursor_v1);
            this.grp_cursor.Controls.Add(this.nud_cursor_v2);
            this.grp_cursor.Controls.Add(this.nud_cursor_v3);
            this.grp_cursor.Controls.Add(this.label_cursor_v1);
            this.grp_cursor.Controls.Add(this.label_cursor_v2);
            this.grp_cursor.Controls.Add(this.label_cursor_v3);
            this.grp_cursor.Controls.Add(this.chk_cursor_v1);
            this.grp_cursor.Controls.Add(this.chk_cursor_v2);
            this.grp_cursor.Controls.Add(this.chk_cursor_v3);
            this.grp_cursor.Controls.Add(this.label_noise_offset);
            this.grp_cursor.Controls.Add(this.hsb_noise_offset);
            this.grp_cursor.Controls.Add(this.label_dynamic);
            this.grp_cursor.Location = new System.Drawing.Point(1182, -5);
            this.grp_cursor.Margin = new System.Windows.Forms.Padding(4);
            this.grp_cursor.Name = "grp_cursor";
            this.grp_cursor.Padding = new System.Windows.Forms.Padding(4);
            this.grp_cursor.Size = new System.Drawing.Size(128, 360);
            this.grp_cursor.TabIndex = 110;
            this.grp_cursor.TabStop = false;
            this.grp_cursor.Text = "Cursor";
            this.grp_cursor.Visible = false;
            // 
            // btn_PosingStop
            // 
            this.btn_PosingStop.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_PosingStop.Location = new System.Drawing.Point(748, 91);
            this.btn_PosingStop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PosingStop.Name = "btn_PosingStop";
            this.btn_PosingStop.Size = new System.Drawing.Size(99, 48);
            this.btn_PosingStop.TabIndex = 111;
            this.btn_PosingStop.Text = "停止移動";
            this.btn_PosingStop.Click += new System.EventHandler(this.btn_PosingStop_Click);
            // 
            // ntb_x_cur_pos
            // 
            this.ntb_x_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_x_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_pos.Location = new System.Drawing.Point(984, 250);
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
            this.ntb_y_cur_pos.Location = new System.Drawing.Point(1082, 250);
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
            this.ntb_z_cur_pos.Location = new System.Drawing.Point(1182, 250);
            this.ntb_z_cur_pos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ntb_z_cur_pos.Name = "ntb_z_cur_pos";
            this.ntb_z_cur_pos.Size = new System.Drawing.Size(86, 25);
            this.ntb_z_cur_pos.TabIndex = 115;
            this.ntb_z_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_JOG_Positive_Start
            // 
            this.btn_JOG_Positive_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Positive_Start.Location = new System.Drawing.Point(649, 31);
            this.btn_JOG_Positive_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_JOG_Positive_Start.Name = "btn_JOG_Positive_Start";
            this.btn_JOG_Positive_Start.Size = new System.Drawing.Size(71, 50);
            this.btn_JOG_Positive_Start.TabIndex = 116;
            this.btn_JOG_Positive_Start.Text = "JOG+ Start";
            this.btn_JOG_Positive_Start.Click += new System.EventHandler(this.btn_JOG_Positive_Start_Click);
            // 
            // btn_JOG_Stop
            // 
            this.btn_JOG_Stop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Stop.Location = new System.Drawing.Point(649, 90);
            this.btn_JOG_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_JOG_Stop.Name = "btn_JOG_Stop";
            this.btn_JOG_Stop.Size = new System.Drawing.Size(71, 50);
            this.btn_JOG_Stop.TabIndex = 117;
            this.btn_JOG_Stop.Text = "JOG Stop";
            this.btn_JOG_Stop.Click += new System.EventHandler(this.btn_JOG_Stop_Click);
            // 
            // btn_JOG_Negative_Start
            // 
            this.btn_JOG_Negative_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Negative_Start.Location = new System.Drawing.Point(649, 148);
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
            this.ctrl_zgc_dnld.Location = new System.Drawing.Point(651, 4);
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
            this.ctrl_zgc_dnld.Size = new System.Drawing.Size(529, 445);
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
            this.tabControlMain.Controls.Add(this.tbp_sodx);
            this.tabControlMain.Controls.Add(this.tbp_status);
            this.tabControlMain.Controls.Add(this.tbp_motion);
            this.tabControlMain.Location = new System.Drawing.Point(5, 381);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1320, 490);
            this.tabControlMain.TabIndex = 120;
            // 
            // tbp_main
            // 
            this.tbp_main.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_main.CausesValidation = false;
            this.tbp_main.Controls.Add(this.btn_trigger);
            this.tbp_main.Controls.Add(this.btn_connection_ip);
            this.tbp_main.Controls.Add(this.label37);
            this.tbp_main.Controls.Add(this.clsRawImage);
            this.tbp_main.Controls.Add(this.ntb_threshold);
            this.tbp_main.Controls.Add(this.grp_cursor);
            this.tbp_main.Controls.Add(this.ctrl_zgc_dnld);
            this.tbp_main.Controls.Add(this.btn_dark);
            this.tbp_main.Controls.Add(this.label1);
            this.tbp_main.Controls.Add(this.ntb_led_intensity);
            this.tbp_main.Controls.Add(this.label2);
            this.tbp_main.Location = new System.Drawing.Point(4, 26);
            this.tbp_main.Margin = new System.Windows.Forms.Padding(4);
            this.tbp_main.Name = "tbp_main";
            this.tbp_main.Padding = new System.Windows.Forms.Padding(4);
            this.tbp_main.Size = new System.Drawing.Size(1312, 460);
            this.tbp_main.TabIndex = 6;
            this.tbp_main.Text = "Main";
            // 
            // btn_trigger
            // 
            this.btn_trigger.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.btn_trigger.Location = new System.Drawing.Point(25, 38);
            this.btn_trigger.Margin = new System.Windows.Forms.Padding(2);
            this.btn_trigger.Name = "btn_trigger";
            this.btn_trigger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_trigger.Size = new System.Drawing.Size(112, 48);
            this.btn_trigger.TabIndex = 126;
            this.btn_trigger.Text = "開始取像";
            this.btn_trigger.UseVisualStyleBackColor = true;
            this.btn_trigger.Click += new System.EventHandler(this.btn_trigger_Click);
            // 
            // btn_connection_ip
            // 
            this.btn_connection_ip.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.btn_connection_ip.Location = new System.Drawing.Point(29, 337);
            this.btn_connection_ip.Margin = new System.Windows.Forms.Padding(2);
            this.btn_connection_ip.Name = "btn_connection_ip";
            this.btn_connection_ip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_connection_ip.Size = new System.Drawing.Size(112, 66);
            this.btn_connection_ip.TabIndex = 125;
            this.btn_connection_ip.Text = "變更量測相機IP";
            this.btn_connection_ip.UseVisualStyleBackColor = true;
            this.btn_connection_ip.Click += new System.EventHandler(this.btn_connection_ip_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label37.Location = new System.Drawing.Point(27, 188);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(110, 25);
            this.label37.TabIndex = 124;
            this.label37.Text = "Threshold";
            // 
            // btn_dark
            // 
            this.btn_dark.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_dark.Location = new System.Drawing.Point(29, 271);
            this.btn_dark.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dark.Name = "btn_dark";
            this.btn_dark.Size = new System.Drawing.Size(112, 47);
            this.btn_dark.TabIndex = 98;
            this.btn_dark.Text = "相機去噪";
            this.btn_dark.UseVisualStyleBackColor = true;
            this.btn_dark.Click += new System.EventHandler(this.btn_dark_Click);
            // 
            // tbp_sodx
            // 
            this.tbp_sodx.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_sodx.Controls.Add(this.chk_yaxis_auto_scale);
            this.tbp_sodx.Controls.Add(this.label69);
            this.tbp_sodx.Controls.Add(this.lbl_number_of_acq_in_sodx_fifo);
            this.tbp_sodx.Controls.Add(this.lbl_number_of_overflow_in_sodx_fifo);
            this.tbp_sodx.Controls.Add(this.ctrl_percentage_use_of_sodx_fifo);
            this.tbp_sodx.Controls.Add(this.groupBox4);
            this.tbp_sodx.Controls.Add(this.label61);
            this.tbp_sodx.Controls.Add(this.num_data_acquisition_number);
            this.tbp_sodx.Controls.Add(this.btn_sodx_pause);
            this.tbp_sodx.Controls.Add(this.btn_sodx_execute);
            this.tbp_sodx.Location = new System.Drawing.Point(4, 26);
            this.tbp_sodx.Margin = new System.Windows.Forms.Padding(4);
            this.tbp_sodx.Name = "tbp_sodx";
            this.tbp_sodx.Padding = new System.Windows.Forms.Padding(4);
            this.tbp_sodx.Size = new System.Drawing.Size(1312, 460);
            this.tbp_sodx.TabIndex = 0;
            this.tbp_sodx.Text = "SODX";
            // 
            // chk_yaxis_auto_scale
            // 
            this.chk_yaxis_auto_scale.AutoSize = true;
            this.chk_yaxis_auto_scale.Location = new System.Drawing.Point(116, 98);
            this.chk_yaxis_auto_scale.Margin = new System.Windows.Forms.Padding(4);
            this.chk_yaxis_auto_scale.Name = "chk_yaxis_auto_scale";
            this.chk_yaxis_auto_scale.Size = new System.Drawing.Size(150, 21);
            this.chk_yaxis_auto_scale.TabIndex = 48;
            this.chk_yaxis_auto_scale.Text = "Y Axis Auto Scale";
            this.chk_yaxis_auto_scale.UseVisualStyleBackColor = true;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(112, 66);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(135, 20);
            this.label69.TabIndex = 45;
            this.label69.Text = "Number of Acq.";
            // 
            // lbl_number_of_acq_in_sodx_fifo
            // 
            this.lbl_number_of_acq_in_sodx_fifo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_number_of_acq_in_sodx_fifo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_number_of_acq_in_sodx_fifo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_number_of_acq_in_sodx_fifo.ForeColor = System.Drawing.Color.Black;
            this.lbl_number_of_acq_in_sodx_fifo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_number_of_acq_in_sodx_fifo.Location = new System.Drawing.Point(257, 65);
            this.lbl_number_of_acq_in_sodx_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_acq_in_sodx_fifo.Name = "lbl_number_of_acq_in_sodx_fifo";
            this.lbl_number_of_acq_in_sodx_fifo.Size = new System.Drawing.Size(97, 18);
            this.lbl_number_of_acq_in_sodx_fifo.TabIndex = 44;
            this.lbl_number_of_acq_in_sodx_fifo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_number_of_overflow_in_sodx_fifo
            // 
            this.lbl_number_of_overflow_in_sodx_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_sodx_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_sodx_fifo.Location = new System.Drawing.Point(286, 34);
            this.lbl_number_of_overflow_in_sodx_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_sodx_fifo.Name = "lbl_number_of_overflow_in_sodx_fifo";
            this.lbl_number_of_overflow_in_sodx_fifo.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_sodx_fifo.TabIndex = 40;
            this.lbl_number_of_overflow_in_sodx_fifo.Text = "Overflow";
            // 
            // ctrl_percentage_use_of_sodx_fifo
            // 
            this.ctrl_percentage_use_of_sodx_fifo.Location = new System.Drawing.Point(369, 61);
            this.ctrl_percentage_use_of_sodx_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_sodx_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_sodx_fifo.Name = "ctrl_percentage_use_of_sodx_fifo";
            this.ctrl_percentage_use_of_sodx_fifo.Size = new System.Drawing.Size(96, 26);
            this.ctrl_percentage_use_of_sodx_fifo.Step = 1;
            this.ctrl_percentage_use_of_sodx_fifo.TabIndex = 39;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_sodx);
            this.groupBox4.Controls.Add(this.lbl_global_signal_health_upp_not_finished_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_health_exposure_lost_count_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_health_upp_lost_count_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_health_ticket_wrong_order_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_health_dsp_load_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_ticket_number_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_number_of_valid_peaks_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_trigger_lost_count_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_real_lightning_time_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_real_exposure_time_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_exposure_flags_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_first_exposure_count_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_start_time_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_stop_position_v_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_stop_position_u_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_stop_position_z_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_stop_position_y_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_stop_position_x_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_start_position_v_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_start_position_u_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_start_position_z_value);
            this.groupBox4.Controls.Add(this.lbl_global_signal_start_position_x_value);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.ctrl_counter_gauge);
            this.groupBox4.Controls.Add(this.lbl_global_signal_start_position_y_value);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.lbl_global_signal_sample_counter_value);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Location = new System.Drawing.Point(29, 126);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(540, 320);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Signals";
            // 
            // btn_sodx
            // 
            this.btn_sodx.Location = new System.Drawing.Point(305, 282);
            this.btn_sodx.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sodx.Name = "btn_sodx";
            this.btn_sodx.Size = new System.Drawing.Size(224, 26);
            this.btn_sodx.TabIndex = 1;
            this.btn_sodx.Text = "SODX";
            this.btn_sodx.UseVisualStyleBackColor = true;
            this.btn_sodx.Click += new System.EventHandler(this.btn_sodx_Click);
            // 
            // lbl_global_signal_health_upp_not_finished_value
            // 
            this.lbl_global_signal_health_upp_not_finished_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_health_upp_not_finished_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_health_upp_not_finished_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_health_upp_not_finished_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_health_upp_not_finished_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_health_upp_not_finished_value.Location = new System.Drawing.Point(205, 291);
            this.lbl_global_signal_health_upp_not_finished_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_health_upp_not_finished_value.Name = "lbl_global_signal_health_upp_not_finished_value";
            this.lbl_global_signal_health_upp_not_finished_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_health_upp_not_finished_value.TabIndex = 31;
            this.lbl_global_signal_health_upp_not_finished_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_health_exposure_lost_count_value
            // 
            this.lbl_global_signal_health_exposure_lost_count_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_health_exposure_lost_count_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_health_exposure_lost_count_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_health_exposure_lost_count_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_health_exposure_lost_count_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_health_exposure_lost_count_value.Location = new System.Drawing.Point(205, 270);
            this.lbl_global_signal_health_exposure_lost_count_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_health_exposure_lost_count_value.Name = "lbl_global_signal_health_exposure_lost_count_value";
            this.lbl_global_signal_health_exposure_lost_count_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_health_exposure_lost_count_value.TabIndex = 31;
            this.lbl_global_signal_health_exposure_lost_count_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_health_upp_lost_count_value
            // 
            this.lbl_global_signal_health_upp_lost_count_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_health_upp_lost_count_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_health_upp_lost_count_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_health_upp_lost_count_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_health_upp_lost_count_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_health_upp_lost_count_value.Location = new System.Drawing.Point(205, 249);
            this.lbl_global_signal_health_upp_lost_count_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_health_upp_lost_count_value.Name = "lbl_global_signal_health_upp_lost_count_value";
            this.lbl_global_signal_health_upp_lost_count_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_health_upp_lost_count_value.TabIndex = 31;
            this.lbl_global_signal_health_upp_lost_count_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_health_ticket_wrong_order_value
            // 
            this.lbl_global_signal_health_ticket_wrong_order_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_health_ticket_wrong_order_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_health_ticket_wrong_order_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_health_ticket_wrong_order_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_health_ticket_wrong_order_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_health_ticket_wrong_order_value.Location = new System.Drawing.Point(205, 229);
            this.lbl_global_signal_health_ticket_wrong_order_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_health_ticket_wrong_order_value.Name = "lbl_global_signal_health_ticket_wrong_order_value";
            this.lbl_global_signal_health_ticket_wrong_order_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_health_ticket_wrong_order_value.TabIndex = 31;
            this.lbl_global_signal_health_ticket_wrong_order_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_health_dsp_load_value
            // 
            this.lbl_global_signal_health_dsp_load_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_health_dsp_load_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_health_dsp_load_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_health_dsp_load_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_health_dsp_load_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_health_dsp_load_value.Location = new System.Drawing.Point(205, 188);
            this.lbl_global_signal_health_dsp_load_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_health_dsp_load_value.Name = "lbl_global_signal_health_dsp_load_value";
            this.lbl_global_signal_health_dsp_load_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_health_dsp_load_value.TabIndex = 31;
            this.lbl_global_signal_health_dsp_load_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_ticket_number_value
            // 
            this.lbl_global_signal_ticket_number_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_ticket_number_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_ticket_number_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_ticket_number_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_ticket_number_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_ticket_number_value.Location = new System.Drawing.Point(205, 166);
            this.lbl_global_signal_ticket_number_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_ticket_number_value.Name = "lbl_global_signal_ticket_number_value";
            this.lbl_global_signal_ticket_number_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_ticket_number_value.TabIndex = 31;
            this.lbl_global_signal_ticket_number_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_number_of_valid_peaks_value
            // 
            this.lbl_global_signal_number_of_valid_peaks_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_number_of_valid_peaks_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_number_of_valid_peaks_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_number_of_valid_peaks_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_number_of_valid_peaks_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_number_of_valid_peaks_value.Location = new System.Drawing.Point(205, 145);
            this.lbl_global_signal_number_of_valid_peaks_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_number_of_valid_peaks_value.Name = "lbl_global_signal_number_of_valid_peaks_value";
            this.lbl_global_signal_number_of_valid_peaks_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_number_of_valid_peaks_value.TabIndex = 31;
            this.lbl_global_signal_number_of_valid_peaks_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_trigger_lost_count_value
            // 
            this.lbl_global_signal_trigger_lost_count_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_trigger_lost_count_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_trigger_lost_count_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_trigger_lost_count_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_trigger_lost_count_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_trigger_lost_count_value.Location = new System.Drawing.Point(205, 125);
            this.lbl_global_signal_trigger_lost_count_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_trigger_lost_count_value.Name = "lbl_global_signal_trigger_lost_count_value";
            this.lbl_global_signal_trigger_lost_count_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_trigger_lost_count_value.TabIndex = 31;
            this.lbl_global_signal_trigger_lost_count_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_real_lightning_time_value
            // 
            this.lbl_global_signal_real_lightning_time_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_real_lightning_time_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_real_lightning_time_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_real_lightning_time_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_real_lightning_time_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_real_lightning_time_value.Location = new System.Drawing.Point(205, 104);
            this.lbl_global_signal_real_lightning_time_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_real_lightning_time_value.Name = "lbl_global_signal_real_lightning_time_value";
            this.lbl_global_signal_real_lightning_time_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_real_lightning_time_value.TabIndex = 31;
            this.lbl_global_signal_real_lightning_time_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_real_exposure_time_value
            // 
            this.lbl_global_signal_real_exposure_time_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_real_exposure_time_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_real_exposure_time_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_real_exposure_time_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_real_exposure_time_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_real_exposure_time_value.Location = new System.Drawing.Point(205, 82);
            this.lbl_global_signal_real_exposure_time_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_real_exposure_time_value.Name = "lbl_global_signal_real_exposure_time_value";
            this.lbl_global_signal_real_exposure_time_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_real_exposure_time_value.TabIndex = 31;
            this.lbl_global_signal_real_exposure_time_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_exposure_flags_value
            // 
            this.lbl_global_signal_exposure_flags_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_exposure_flags_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_exposure_flags_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_exposure_flags_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_exposure_flags_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_exposure_flags_value.Location = new System.Drawing.Point(205, 62);
            this.lbl_global_signal_exposure_flags_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_exposure_flags_value.Name = "lbl_global_signal_exposure_flags_value";
            this.lbl_global_signal_exposure_flags_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_exposure_flags_value.TabIndex = 31;
            this.lbl_global_signal_exposure_flags_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_first_exposure_count_value
            // 
            this.lbl_global_signal_first_exposure_count_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_first_exposure_count_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_first_exposure_count_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_first_exposure_count_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_first_exposure_count_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_first_exposure_count_value.Location = new System.Drawing.Point(205, 41);
            this.lbl_global_signal_first_exposure_count_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_first_exposure_count_value.Name = "lbl_global_signal_first_exposure_count_value";
            this.lbl_global_signal_first_exposure_count_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_first_exposure_count_value.TabIndex = 31;
            this.lbl_global_signal_first_exposure_count_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_start_time_value
            // 
            this.lbl_global_signal_start_time_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_start_time_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_start_time_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_start_time_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_start_time_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_start_time_value.Location = new System.Drawing.Point(205, 21);
            this.lbl_global_signal_start_time_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_start_time_value.Name = "lbl_global_signal_start_time_value";
            this.lbl_global_signal_start_time_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_start_time_value.TabIndex = 31;
            this.lbl_global_signal_start_time_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_stop_position_v_value
            // 
            this.lbl_global_signal_stop_position_v_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_stop_position_v_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_stop_position_v_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_stop_position_v_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_stop_position_v_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_stop_position_v_value.Location = new System.Drawing.Point(440, 209);
            this.lbl_global_signal_stop_position_v_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_stop_position_v_value.Name = "lbl_global_signal_stop_position_v_value";
            this.lbl_global_signal_stop_position_v_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_stop_position_v_value.TabIndex = 31;
            this.lbl_global_signal_stop_position_v_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_stop_position_u_value
            // 
            this.lbl_global_signal_stop_position_u_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_stop_position_u_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_stop_position_u_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_stop_position_u_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_stop_position_u_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_stop_position_u_value.Location = new System.Drawing.Point(440, 188);
            this.lbl_global_signal_stop_position_u_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_stop_position_u_value.Name = "lbl_global_signal_stop_position_u_value";
            this.lbl_global_signal_stop_position_u_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_stop_position_u_value.TabIndex = 31;
            this.lbl_global_signal_stop_position_u_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_stop_position_z_value
            // 
            this.lbl_global_signal_stop_position_z_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_stop_position_z_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_stop_position_z_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_stop_position_z_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_stop_position_z_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_stop_position_z_value.Location = new System.Drawing.Point(440, 168);
            this.lbl_global_signal_stop_position_z_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_stop_position_z_value.Name = "lbl_global_signal_stop_position_z_value";
            this.lbl_global_signal_stop_position_z_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_stop_position_z_value.TabIndex = 31;
            this.lbl_global_signal_stop_position_z_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_stop_position_y_value
            // 
            this.lbl_global_signal_stop_position_y_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_stop_position_y_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_stop_position_y_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_stop_position_y_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_stop_position_y_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_stop_position_y_value.Location = new System.Drawing.Point(440, 146);
            this.lbl_global_signal_stop_position_y_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_stop_position_y_value.Name = "lbl_global_signal_stop_position_y_value";
            this.lbl_global_signal_stop_position_y_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_stop_position_y_value.TabIndex = 31;
            this.lbl_global_signal_stop_position_y_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_stop_position_x_value
            // 
            this.lbl_global_signal_stop_position_x_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_stop_position_x_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_stop_position_x_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_stop_position_x_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_stop_position_x_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_stop_position_x_value.Location = new System.Drawing.Point(440, 126);
            this.lbl_global_signal_stop_position_x_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_stop_position_x_value.Name = "lbl_global_signal_stop_position_x_value";
            this.lbl_global_signal_stop_position_x_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_stop_position_x_value.TabIndex = 31;
            this.lbl_global_signal_stop_position_x_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_start_position_v_value
            // 
            this.lbl_global_signal_start_position_v_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_start_position_v_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_start_position_v_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_start_position_v_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_start_position_v_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_start_position_v_value.Location = new System.Drawing.Point(440, 105);
            this.lbl_global_signal_start_position_v_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_start_position_v_value.Name = "lbl_global_signal_start_position_v_value";
            this.lbl_global_signal_start_position_v_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_start_position_v_value.TabIndex = 31;
            this.lbl_global_signal_start_position_v_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_start_position_u_value
            // 
            this.lbl_global_signal_start_position_u_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_start_position_u_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_start_position_u_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_start_position_u_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_start_position_u_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_start_position_u_value.Location = new System.Drawing.Point(440, 84);
            this.lbl_global_signal_start_position_u_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_start_position_u_value.Name = "lbl_global_signal_start_position_u_value";
            this.lbl_global_signal_start_position_u_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_start_position_u_value.TabIndex = 31;
            this.lbl_global_signal_start_position_u_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_start_position_z_value
            // 
            this.lbl_global_signal_start_position_z_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_start_position_z_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_start_position_z_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_start_position_z_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_start_position_z_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_start_position_z_value.Location = new System.Drawing.Point(440, 64);
            this.lbl_global_signal_start_position_z_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_start_position_z_value.Name = "lbl_global_signal_start_position_z_value";
            this.lbl_global_signal_start_position_z_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_start_position_z_value.TabIndex = 31;
            this.lbl_global_signal_start_position_z_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_global_signal_start_position_x_value
            // 
            this.lbl_global_signal_start_position_x_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_start_position_x_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_start_position_x_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_start_position_x_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_start_position_x_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_start_position_x_value.Location = new System.Drawing.Point(440, 22);
            this.lbl_global_signal_start_position_x_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_start_position_x_value.Name = "lbl_global_signal_start_position_x_value";
            this.lbl_global_signal_start_position_x_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_start_position_x_value.TabIndex = 31;
            this.lbl_global_signal_start_position_x_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(14, 292);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(168, 17);
            this.label34.TabIndex = 2;
            this.label34.Text = "Health Upp Not Finished";
            // 
            // ctrl_counter_gauge
            // 
            this.ctrl_counter_gauge.Location = new System.Drawing.Point(305, 241);
            this.ctrl_counter_gauge.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_counter_gauge.MarqueeAnimationSpeed = 0;
            this.ctrl_counter_gauge.Maximum = 65535;
            this.ctrl_counter_gauge.Name = "ctrl_counter_gauge";
            this.ctrl_counter_gauge.Size = new System.Drawing.Size(224, 26);
            this.ctrl_counter_gauge.Step = 1;
            this.ctrl_counter_gauge.TabIndex = 8;
            // 
            // lbl_global_signal_start_position_y_value
            // 
            this.lbl_global_signal_start_position_y_value.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbl_global_signal_start_position_y_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_start_position_y_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_start_position_y_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_start_position_y_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_start_position_y_value.Location = new System.Drawing.Point(440, 42);
            this.lbl_global_signal_start_position_y_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_start_position_y_value.Name = "lbl_global_signal_start_position_y_value";
            this.lbl_global_signal_start_position_y_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_start_position_y_value.TabIndex = 31;
            this.lbl_global_signal_start_position_y_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(14, 272);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(189, 17);
            this.label32.TabIndex = 2;
            this.label32.Text = "Health Exposure Lost Count";
            // 
            // lbl_global_signal_sample_counter_value
            // 
            this.lbl_global_signal_sample_counter_value.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_global_signal_sample_counter_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_global_signal_sample_counter_value.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_global_signal_sample_counter_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_global_signal_sample_counter_value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_global_signal_sample_counter_value.Location = new System.Drawing.Point(205, 208);
            this.lbl_global_signal_sample_counter_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_global_signal_sample_counter_value.Name = "lbl_global_signal_sample_counter_value";
            this.lbl_global_signal_sample_counter_value.Size = new System.Drawing.Size(88, 18);
            this.lbl_global_signal_sample_counter_value.TabIndex = 31;
            this.lbl_global_signal_sample_counter_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 251);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(204, 17);
            this.label28.TabIndex = 2;
            this.label28.Text = "SampleHealth Upp Lost Count";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(301, 210);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(108, 17);
            this.label24.TabIndex = 2;
            this.label24.Text = "Stop Position V";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 231);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Health Ticket Wrong Order";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(301, 189);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 17);
            this.label23.TabIndex = 2;
            this.label23.Text = "Stop Position U";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 189);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Health Dsp Load";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 169);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Stop Position Z";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(14, 169);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 17);
            this.label31.TabIndex = 2;
            this.label31.Text = "Ticket Number";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(301, 148);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 17);
            this.label21.TabIndex = 2;
            this.label21.Text = "Stop Position Y";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(14, 148);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(161, 17);
            this.label29.TabIndex = 2;
            this.label29.Text = "Number Of Valid Peaks";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(301, 128);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 17);
            this.label20.TabIndex = 2;
            this.label20.Text = "Stop Position X";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 128);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(130, 17);
            this.label27.TabIndex = 2;
            this.label27.Text = "Trigger Lost Count";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(301, 106);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 17);
            this.label19.TabIndex = 2;
            this.label19.Text = "Start Position V";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(14, 106);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(140, 17);
            this.label26.TabIndex = 2;
            this.label26.Text = "Real Lightning Time";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(301, 85);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(108, 17);
            this.label18.TabIndex = 2;
            this.label18.Text = "Start Position U";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 85);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(138, 17);
            this.label25.TabIndex = 2;
            this.label25.Text = "Real Exposure Time";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(301, 65);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 17);
            this.label17.TabIndex = 2;
            this.label17.Text = "Start Position Z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "First Flags";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(301, 44);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "Start Position Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 44);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "First Exposure Count";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(301, 22);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 17);
            this.label22.TabIndex = 2;
            this.label22.Text = "Start Position X";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(14, 22);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(74, 17);
            this.label30.TabIndex = 2;
            this.label30.Text = "Start Time";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(14, 210);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(110, 17);
            this.label33.TabIndex = 2;
            this.label33.Text = "Sample Counter";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(112, 34);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(81, 20);
            this.label61.TabIndex = 36;
            this.label61.Text = "Num Acq.";
            // 
            // num_data_acquisition_number
            // 
            this.num_data_acquisition_number.AutoValidate = true;
            this.num_data_acquisition_number.AutoValidationTime = 5000;
            this.num_data_acquisition_number.BackColor = System.Drawing.Color.White;
            this.num_data_acquisition_number.DecimalPlaces = 0;
            this.num_data_acquisition_number.EnableErrorValue = false;
            this.num_data_acquisition_number.EnableWarningValue = false;
            this.num_data_acquisition_number.ErrorColor = System.Drawing.Color.OrangeRed;
            this.num_data_acquisition_number.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num_data_acquisition_number.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_data_acquisition_number.InterceptArrowKeys = true;
            this.num_data_acquisition_number.Location = new System.Drawing.Point(199, 30);
            this.num_data_acquisition_number.Margin = new System.Windows.Forms.Padding(4);
            this.num_data_acquisition_number.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_data_acquisition_number.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.num_data_acquisition_number.Name = "num_data_acquisition_number";
            this.num_data_acquisition_number.Size = new System.Drawing.Size(75, 27);
            this.num_data_acquisition_number.TabIndex = 37;
            this.num_data_acquisition_number.Text = "-1";
            this.num_data_acquisition_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_data_acquisition_number.ThousandsSeparator = false;
            this.num_data_acquisition_number.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.num_data_acquisition_number.WarningColor = System.Drawing.Color.Gold;
            this.num_data_acquisition_number.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btn_sodx_pause
            // 
            this.btn_sodx_pause.Image = ((System.Drawing.Image)(resources.GetObject("btn_sodx_pause.Image")));
            this.btn_sodx_pause.Location = new System.Drawing.Point(481, 28);
            this.btn_sodx_pause.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sodx_pause.Name = "btn_sodx_pause";
            this.btn_sodx_pause.Size = new System.Drawing.Size(76, 65);
            this.btn_sodx_pause.TabIndex = 47;
            this.btn_sodx_pause.UseVisualStyleBackColor = true;
            this.btn_sodx_pause.Click += new System.EventHandler(this.btn_sodx_pause_Click);
            // 
            // btn_sodx_execute
            // 
            this.btn_sodx_execute.Image = ((System.Drawing.Image)(resources.GetObject("btn_sodx_execute.Image")));
            this.btn_sodx_execute.Location = new System.Drawing.Point(29, 28);
            this.btn_sodx_execute.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sodx_execute.Name = "btn_sodx_execute";
            this.btn_sodx_execute.Size = new System.Drawing.Size(76, 65);
            this.btn_sodx_execute.TabIndex = 35;
            this.btn_sodx_execute.UseVisualStyleBackColor = true;
            this.btn_sodx_execute.Click += new System.EventHandler(this.btn_sodx_execute_Click);
            // 
            // tbp_status
            // 
            this.tbp_status.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_status.Controls.Add(this.lst_log);
            this.tbp_status.Controls.Add(this.groupBox5);
            this.tbp_status.Location = new System.Drawing.Point(4, 26);
            this.tbp_status.Margin = new System.Windows.Forms.Padding(4);
            this.tbp_status.Name = "tbp_status";
            this.tbp_status.Size = new System.Drawing.Size(1312, 460);
            this.tbp_status.TabIndex = 5;
            this.tbp_status.Text = "Status";
            // 
            // lst_log
            // 
            this.lst_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_log.FullRowSelect = true;
            this.lst_log.HideSelection = false;
            this.lst_log.Location = new System.Drawing.Point(492, 14);
            this.lst_log.Margin = new System.Windows.Forms.Padding(4);
            this.lst_log.Name = "lst_log";
            this.lst_log.ShowItemToolTips = true;
            this.lst_log.Size = new System.Drawing.Size(804, 442);
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
            this.lbl_number_of_overflow_in_data_format_fifo.Location = new System.Drawing.Point(172, 158);
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
            this.label9.Location = new System.Drawing.Point(15, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Data Format";
            // 
            // ctrl_percentage_use_of_data_format_fifo
            // 
            this.ctrl_percentage_use_of_data_format_fifo.Location = new System.Drawing.Point(382, 152);
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
            this.lbl_number_of_overflow_in_command_data_fifo.Location = new System.Drawing.Point(172, 129);
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
            this.lbl_number_of_overflow_in_data_raw_fifo.Location = new System.Drawing.Point(172, 71);
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
            this.lbl_number_of_overflow_in_data_raw_socket.Location = new System.Drawing.Point(172, 44);
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
            this.lbl_number_of_overflow_in_data_sample_fifo.Location = new System.Drawing.Point(172, 100);
            this.lbl_number_of_overflow_in_data_sample_fifo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_number_of_overflow_in_data_sample_fifo.Name = "lbl_number_of_overflow_in_data_sample_fifo";
            this.lbl_number_of_overflow_in_data_sample_fifo.Size = new System.Drawing.Size(81, 20);
            this.lbl_number_of_overflow_in_data_sample_fifo.TabIndex = 20;
            this.lbl_number_of_overflow_in_data_sample_fifo.Text = "Overflow";
            // 
            // ctrl_percentage_use_of_fifo_data_raw_socket
            // 
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Location = new System.Drawing.Point(382, 39);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Name = "ctrl_percentage_use_of_fifo_data_raw_socket";
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Step = 1;
            this.ctrl_percentage_use_of_fifo_data_raw_socket.TabIndex = 27;
            // 
            // ctrl_percentage_use_of_fifo_data_raw_fifo
            // 
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Location = new System.Drawing.Point(382, 68);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Name = "ctrl_percentage_use_of_fifo_data_raw_fifo";
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Step = 1;
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.TabIndex = 28;
            // 
            // ctrl_percentage_use_of_command_data_fifo
            // 
            this.ctrl_percentage_use_of_command_data_fifo.Location = new System.Drawing.Point(382, 124);
            this.ctrl_percentage_use_of_command_data_fifo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_percentage_use_of_command_data_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_command_data_fifo.Name = "ctrl_percentage_use_of_command_data_fifo";
            this.ctrl_percentage_use_of_command_data_fifo.Size = new System.Drawing.Size(71, 26);
            this.ctrl_percentage_use_of_command_data_fifo.Step = 1;
            this.ctrl_percentage_use_of_command_data_fifo.TabIndex = 29;
            // 
            // ctrl_percentage_use_of_data_sample_fifo
            // 
            this.ctrl_percentage_use_of_data_sample_fifo.Location = new System.Drawing.Point(382, 96);
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
            this.lbl_tx_rate.Location = new System.Drawing.Point(172, 19);
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
            this.lbl_error_no_dataformat.Location = new System.Drawing.Point(11, 308);
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
            this.lbl_resynchronization.Location = new System.Drawing.Point(11, 432);
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
            this.lbl_error_data_header.Location = new System.Drawing.Point(11, 272);
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
            this.lbl_error_data_format_header.Location = new System.Drawing.Point(11, 238);
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
            this.lbl_error_command_header.Location = new System.Drawing.Point(11, 202);
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
            this.tbp_motion.Size = new System.Drawing.Size(1312, 460);
            this.tbp_motion.TabIndex = 7;
            this.tbp_motion.Text = "Motion";
            this.tbp_motion.UseVisualStyleBackColor = true;
            // 
            // cb_SelectMeasureDistance
            // 
            this.cb_SelectMeasureDistance.FormattingEnabled = true;
            this.cb_SelectMeasureDistance.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1",
            "2",
            "5",
            "1",
            "2",
            "5"});
            this.cb_SelectMeasureDistance.Location = new System.Drawing.Point(814, 240);
            this.cb_SelectMeasureDistance.Margin = new System.Windows.Forms.Padding(4);
            this.cb_SelectMeasureDistance.Name = "cb_SelectMeasureDistance";
            this.cb_SelectMeasureDistance.Size = new System.Drawing.Size(83, 24);
            this.cb_SelectMeasureDistance.TabIndex = 121;
            this.cb_SelectMeasureDistance.SelectedIndexChanged += new System.EventHandler(this.cb_SelectMeasureDistance_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label35.Location = new System.Drawing.Point(810, 206);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(92, 25);
            this.label35.TabIndex = 122;
            this.label35.Text = "掃描距離";
            // 
            // btn_moveto_WaferCenter_point
            // 
            this.btn_moveto_WaferCenter_point.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_WaferCenter_point.Location = new System.Drawing.Point(664, 225);
            this.btn_moveto_WaferCenter_point.Margin = new System.Windows.Forms.Padding(4);
            this.btn_moveto_WaferCenter_point.Name = "btn_moveto_WaferCenter_point";
            this.btn_moveto_WaferCenter_point.Size = new System.Drawing.Size(112, 54);
            this.btn_moveto_WaferCenter_point.TabIndex = 124;
            this.btn_moveto_WaferCenter_point.Text = "自動模式";
            this.btn_moveto_WaferCenter_point.UseVisualStyleBackColor = true;
            this.btn_moveto_WaferCenter_point.Click += new System.EventHandler(this.btn_auto_measurement);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_move_distance_z);
            this.groupBox7.Controls.Add(this.btn_move_distance);
            this.groupBox7.Controls.Add(this.btn_movex_negative);
            this.groupBox7.Controls.Add(this.btn_movex_positive);
            this.groupBox7.Controls.Add(this.btn_movey_negative);
            this.groupBox7.Controls.Add(this.btn_movey_positive);
            this.groupBox7.Controls.Add(this.btn_movez_positive);
            this.groupBox7.Controls.Add(this.btn_movez_negative);
            this.groupBox7.Location = new System.Drawing.Point(974, 15);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(315, 198);
            this.groupBox7.TabIndex = 157;
            this.groupBox7.TabStop = false;
            // 
            // btn_move_distance_z
            // 
            this.btn_move_distance_z.BackColor = System.Drawing.Color.White;
            this.btn_move_distance_z.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance_z.Location = new System.Drawing.Point(235, 79);
            this.btn_move_distance_z.Margin = new System.Windows.Forms.Padding(4);
            this.btn_move_distance_z.Name = "btn_move_distance_z";
            this.btn_move_distance_z.Size = new System.Drawing.Size(78, 36);
            this.btn_move_distance_z.TabIndex = 164;
            this.btn_move_distance_z.Text = "0";
            this.btn_move_distance_z.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance_z.UseVisualStyleBackColor = false;
            this.btn_move_distance_z.Click += new System.EventHandler(this.btn_move_distance_z_Click);
            // 
            // btn_move_distance
            // 
            this.btn_move_distance.BackColor = System.Drawing.Color.White;
            this.btn_move_distance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance.Location = new System.Drawing.Point(81, 80);
            this.btn_move_distance.Margin = new System.Windows.Forms.Padding(4);
            this.btn_move_distance.Name = "btn_move_distance";
            this.btn_move_distance.Size = new System.Drawing.Size(78, 36);
            this.btn_move_distance.TabIndex = 162;
            this.btn_move_distance.Text = "0";
            this.btn_move_distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance.UseVisualStyleBackColor = false;
            this.btn_move_distance.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // btn_movex_negative
            // 
            this.btn_movex_negative.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movex_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movex_negative.Image")));
            this.btn_movex_negative.Location = new System.Drawing.Point(6, 64);
            this.btn_movex_negative.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movex_negative.Name = "btn_movex_negative";
            this.btn_movex_negative.Size = new System.Drawing.Size(60, 62);
            this.btn_movex_negative.TabIndex = 123;
            this.btn_movex_negative.Text = "X-";
            this.btn_movex_negative.UseVisualStyleBackColor = true;
            this.btn_movex_negative.Click += new System.EventHandler(this.btn_movex_negative_Click);
            // 
            // btn_movex_positive
            // 
            this.btn_movex_positive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movex_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movex_positive.Image")));
            this.btn_movex_positive.Location = new System.Drawing.Point(166, 61);
            this.btn_movex_positive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movex_positive.Name = "btn_movex_positive";
            this.btn_movex_positive.Size = new System.Drawing.Size(60, 62);
            this.btn_movex_positive.TabIndex = 90;
            this.btn_movex_positive.Text = "X+";
            this.btn_movex_positive.UseVisualStyleBackColor = true;
            this.btn_movex_positive.Click += new System.EventHandler(this.btn_movex_positive_Click);
            // 
            // btn_movey_negative
            // 
            this.btn_movey_negative.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movey_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movey_negative.Image")));
            this.btn_movey_negative.Location = new System.Drawing.Point(86, 121);
            this.btn_movey_negative.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movey_negative.Name = "btn_movey_negative";
            this.btn_movey_negative.Size = new System.Drawing.Size(64, 62);
            this.btn_movey_negative.TabIndex = 126;
            this.btn_movey_negative.Text = "Y-";
            this.btn_movey_negative.UseVisualStyleBackColor = true;
            this.btn_movey_negative.Click += new System.EventHandler(this.btn_movey_negative_Click);
            // 
            // btn_movey_positive
            // 
            this.btn_movey_positive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movey_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movey_positive.Image")));
            this.btn_movey_positive.Location = new System.Drawing.Point(86, 14);
            this.btn_movey_positive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movey_positive.Name = "btn_movey_positive";
            this.btn_movey_positive.Size = new System.Drawing.Size(64, 61);
            this.btn_movey_positive.TabIndex = 125;
            this.btn_movey_positive.Text = "Y+";
            this.btn_movey_positive.UseVisualStyleBackColor = true;
            this.btn_movey_positive.Click += new System.EventHandler(this.btn_movey_positive_Click);
            // 
            // btn_movez_positive
            // 
            this.btn_movez_positive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_movez_positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_movez_positive.Image")));
            this.btn_movez_positive.Location = new System.Drawing.Point(244, 15);
            this.btn_movez_positive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movez_positive.Name = "btn_movez_positive";
            this.btn_movez_positive.Size = new System.Drawing.Size(68, 60);
            this.btn_movez_positive.TabIndex = 128;
            this.btn_movez_positive.Text = "Z+";
            this.btn_movez_positive.UseVisualStyleBackColor = true;
            this.btn_movez_positive.Click += new System.EventHandler(this.btn_movez_positive_Click);
            // 
            // btn_movez_negative
            // 
            this.btn_movez_negative.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movez_negative.Image = ((System.Drawing.Image)(resources.GetObject("btn_movez_negative.Image")));
            this.btn_movez_negative.Location = new System.Drawing.Point(244, 122);
            this.btn_movez_negative.Margin = new System.Windows.Forms.Padding(4);
            this.btn_movez_negative.Name = "btn_movez_negative";
            this.btn_movez_negative.Size = new System.Drawing.Size(68, 64);
            this.btn_movez_negative.TabIndex = 127;
            this.btn_movez_negative.Text = "Z-";
            this.btn_movez_negative.UseVisualStyleBackColor = true;
            this.btn_movez_negative.Click += new System.EventHandler(this.btn_movez_negative_Click);
            // 
            // btn_manual_mode
            // 
            this.btn_manual_mode.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_manual_mode.Location = new System.Drawing.Point(662, 294);
            this.btn_manual_mode.Margin = new System.Windows.Forms.Padding(4);
            this.btn_manual_mode.Name = "btn_manual_mode";
            this.btn_manual_mode.Size = new System.Drawing.Size(112, 51);
            this.btn_manual_mode.TabIndex = 160;
            this.btn_manual_mode.Text = "手動量測";
            this.btn_manual_mode.UseVisualStyleBackColor = true;
            this.btn_manual_mode.Click += new System.EventHandler(this.btn_manual_mode_Click);
            // 
            // btn_unload_wafer
            // 
            this.btn_unload_wafer.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unload_wafer.Location = new System.Drawing.Point(662, 104);
            this.btn_unload_wafer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_unload_wafer.Name = "btn_unload_wafer";
            this.btn_unload_wafer.Size = new System.Drawing.Size(112, 56);
            this.btn_unload_wafer.TabIndex = 159;
            this.btn_unload_wafer.Text = "晶圓退出";
            this.btn_unload_wafer.UseVisualStyleBackColor = true;
            this.btn_unload_wafer.Click += new System.EventHandler(this.btn_unload_wafer_Click);
            // 
            // btn_load_wafer
            // 
            this.btn_load_wafer.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load_wafer.Location = new System.Drawing.Point(662, 30);
            this.btn_load_wafer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_load_wafer.Name = "btn_load_wafer";
            this.btn_load_wafer.Size = new System.Drawing.Size(112, 59);
            this.btn_load_wafer.TabIndex = 158;
            this.btn_load_wafer.Text = "晶圓載入";
            this.btn_load_wafer.UseVisualStyleBackColor = true;
            this.btn_load_wafer.Click += new System.EventHandler(this.btn_load_wafer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp_align_test);
            this.panel1.Controls.Add(this.grp_manual_buttons);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn_ClearAlarm);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.cb_SelectMeasureDistance);
            this.panel1.Controls.Add(this.label44);
            this.panel1.Controls.Add(this.btn_advanced_mode);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.btn_exposure);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btn_imageThreshold);
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
            this.panel1.Size = new System.Drawing.Size(1327, 385);
            this.panel1.TabIndex = 161;
            // 
            // grp_align_test
            // 
            this.grp_align_test.Controls.Add(this.btn_find_angle);
            this.grp_align_test.Controls.Add(this.btn_load);
            this.grp_align_test.Controls.Add(this.lb_angle);
            this.grp_align_test.Controls.Add(this.lb_die_side);
            this.grp_align_test.Location = new System.Drawing.Point(5, 238);
            this.grp_align_test.Margin = new System.Windows.Forms.Padding(4);
            this.grp_align_test.Name = "grp_align_test";
            this.grp_align_test.Padding = new System.Windows.Forms.Padding(4);
            this.grp_align_test.Size = new System.Drawing.Size(134, 136);
            this.grp_align_test.TabIndex = 178;
            this.grp_align_test.TabStop = false;
            // 
            // btn_find_angle
            // 
            this.btn_find_angle.Image = global::Velociraptor.Properties.Resources.dart;
            this.btn_find_angle.Location = new System.Drawing.Point(72, 21);
            this.btn_find_angle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_find_angle.Name = "btn_find_angle";
            this.btn_find_angle.Size = new System.Drawing.Size(50, 50);
            this.btn_find_angle.TabIndex = 3;
            this.btn_find_angle.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Image = global::Velociraptor.Properties.Resources.folder;
            this.btn_load.Location = new System.Drawing.Point(9, 21);
            this.btn_load.Margin = new System.Windows.Forms.Padding(4);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(50, 50);
            this.btn_load.TabIndex = 2;
            this.btn_load.UseVisualStyleBackColor = true;
            // 
            // lb_angle
            // 
            this.lb_angle.AutoSize = true;
            this.lb_angle.Location = new System.Drawing.Point(9, 110);
            this.lb_angle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_angle.Name = "lb_angle";
            this.lb_angle.Size = new System.Drawing.Size(46, 17);
            this.lb_angle.TabIndex = 1;
            this.lb_angle.Text = "角度:";
            // 
            // lb_die_side
            // 
            this.lb_die_side.AutoSize = true;
            this.lb_die_side.Location = new System.Drawing.Point(9, 86);
            this.lb_die_side.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_die_side.Name = "lb_die_side";
            this.lb_die_side.Size = new System.Drawing.Size(46, 17);
            this.lb_die_side.TabIndex = 0;
            this.lb_die_side.Text = "邊長:";
            // 
            // grp_manual_buttons
            // 
            this.grp_manual_buttons.Controls.Add(this.btn_align);
            this.grp_manual_buttons.Controls.Add(this.btn_save);
            this.grp_manual_buttons.Controls.Add(this.btn_start_mea);
            this.grp_manual_buttons.Location = new System.Drawing.Point(806, 285);
            this.grp_manual_buttons.Margin = new System.Windows.Forms.Padding(4);
            this.grp_manual_buttons.Name = "grp_manual_buttons";
            this.grp_manual_buttons.Padding = new System.Windows.Forms.Padding(4);
            this.grp_manual_buttons.Size = new System.Drawing.Size(245, 96);
            this.grp_manual_buttons.TabIndex = 177;
            this.grp_manual_buttons.TabStop = false;
            this.grp_manual_buttons.Visible = false;
            // 
            // btn_align
            // 
            this.btn_align.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_align.Image = global::Velociraptor.Properties.Resources.upward;
            this.btn_align.Location = new System.Drawing.Point(14, 22);
            this.btn_align.Margin = new System.Windows.Forms.Padding(4);
            this.btn_align.Name = "btn_align";
            this.btn_align.Size = new System.Drawing.Size(64, 62);
            this.btn_align.TabIndex = 174;
            this.btn_align.UseVisualStyleBackColor = true;
            this.btn_align.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_save.Image = global::Velociraptor.Properties.Resources.save;
            this.btn_save.Location = new System.Drawing.Point(165, 22);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(64, 62);
            this.btn_save.TabIndex = 176;
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_start_mea
            // 
            this.btn_start_mea.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_start_mea.Image = global::Velociraptor.Properties.Resources.right_arrow;
            this.btn_start_mea.Location = new System.Drawing.Point(90, 22);
            this.btn_start_mea.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start_mea.Name = "btn_start_mea";
            this.btn_start_mea.Size = new System.Drawing.Size(64, 62);
            this.btn_start_mea.TabIndex = 175;
            this.btn_start_mea.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(815, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 36);
            this.button1.TabIndex = 165;
            this.button1.Text = "2000";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label39.Location = new System.Drawing.Point(900, 239);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(44, 25);
            this.label39.TabIndex = 169;
            this.label39.Text = "um";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label42.Location = new System.Drawing.Point(810, 110);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(139, 25);
            this.label42.TabIndex = 164;
            this.label42.Text = "die Y方向寬度";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label41.Location = new System.Drawing.Point(810, 18);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(140, 25);
            this.label41.TabIndex = 163;
            this.label41.Text = "die X方向長度";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(814, 142);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 36);
            this.button2.TabIndex = 166;
            this.button2.Text = "2000";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btn_ClearAlarm
            // 
            this.btn_ClearAlarm.Font = new System.Drawing.Font("DFKai-SB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_ClearAlarm.Image = global::Velociraptor.Properties.Resources.refresh;
            this.btn_ClearAlarm.Location = new System.Drawing.Point(1158, 309);
            this.btn_ClearAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ClearAlarm.Name = "btn_ClearAlarm";
            this.btn_ClearAlarm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_ClearAlarm.Size = new System.Drawing.Size(64, 62);
            this.btn_ClearAlarm.TabIndex = 173;
            this.btn_ClearAlarm.UseVisualStyleBackColor = true;
            this.btn_ClearAlarm.Click += new System.EventHandler(this.btn_ClearAlarm_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label43.Location = new System.Drawing.Point(900, 52);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(44, 25);
            this.label43.TabIndex = 167;
            this.label43.Text = "um";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label44.Location = new System.Drawing.Point(899, 146);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 25);
            this.label44.TabIndex = 168;
            this.label44.Text = "um";
            // 
            // btn_advanced_mode
            // 
            this.btn_advanced_mode.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.btn_advanced_mode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btn_advanced_mode.Image = global::Velociraptor.Properties.Resources.administration;
            this.btn_advanced_mode.Location = new System.Drawing.Point(1230, 309);
            this.btn_advanced_mode.Margin = new System.Windows.Forms.Padding(2);
            this.btn_advanced_mode.Name = "btn_advanced_mode";
            this.btn_advanced_mode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_advanced_mode.Size = new System.Drawing.Size(64, 62);
            this.btn_advanced_mode.TabIndex = 126;
            this.btn_advanced_mode.UseVisualStyleBackColor = true;
            this.btn_advanced_mode.Click += new System.EventHandler(this.btn_advanced_mode_Click);
            // 
            // btn_exposure
            // 
            this.btn_exposure.BackColor = System.Drawing.Color.White;
            this.btn_exposure.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exposure.Location = new System.Drawing.Point(15, 194);
            this.btn_exposure.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exposure.Name = "btn_exposure";
            this.btn_exposure.Size = new System.Drawing.Size(119, 36);
            this.btn_exposure.TabIndex = 172;
            this.btn_exposure.Text = "0";
            this.btn_exposure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_exposure.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(15, 140);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 46);
            this.button5.TabIndex = 171;
            this.button5.Text = "曝光時間";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btn_imageThreshold
            // 
            this.btn_imageThreshold.BackColor = System.Drawing.Color.White;
            this.btn_imageThreshold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imageThreshold.Location = new System.Drawing.Point(15, 86);
            this.btn_imageThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.btn_imageThreshold.Name = "btn_imageThreshold";
            this.btn_imageThreshold.Size = new System.Drawing.Size(119, 36);
            this.btn_imageThreshold.TabIndex = 165;
            this.btn_imageThreshold.Text = "0";
            this.btn_imageThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imageThreshold.UseVisualStyleBackColor = false;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(140, 2);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(2);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(495, 379);
            this.hWindowControl1.TabIndex = 169;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(495, 379);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(15, 9);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 70);
            this.button3.TabIndex = 170;
            this.button3.Text = "切割道\r\n閥值";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // f_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1327, 871);
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
            this.tbp_sodx.ResumeLayout(false);
            this.tbp_sodx.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tbp_status.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tbp_motion.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grp_align_test.ResumeLayout(false);
            this.grp_align_test.PerformLayout();
            this.grp_manual_buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ipaddress;
        private MagicGraphicLibrary.IPAddressControl ctrl_ip_address;
        private System.Windows.Forms.Label label_Scale;
        private MagicGraphicLibrary.NumericTextBox ntb_led_intensity;
        private System.Windows.Forms.Label label_hz;
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
        private System.Windows.Forms.ComboBox cbx_high_speed;
        private System.Windows.Forms.ComboBox cbx_high_speed_mode;
        private MagicGraphicLibrary.NumericTextBox ntb_dnld_number_of_channels;
        private MagicGraphicLibrary.NumericTextBox ntb_dnld_first_channel;
        private System.Windows.Forms.Button btn_origin_return;
        private System.Windows.Forms.Button btn_movex_positive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_numberofchannels;
        private System.Windows.Forms.Label label_first_channel;
        private System.Windows.Forms.SaveFileDialog sfd_upload;
        private System.Windows.Forms.Button btn_dark;
        private System.Windows.Forms.Label label_xaxis;
        private System.Windows.Forms.Label label_yaxis;
        private System.Windows.Forms.Label label_zaxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox grp_cursor;
        private System.Windows.Forms.Button btn_PosingStop;
        internal System.Windows.Forms.Label ntb_x_cur_pos;
        internal System.Windows.Forms.Label ntb_y_cur_pos;
        internal System.Windows.Forms.Label ntb_z_cur_pos;
        private System.Windows.Forms.Button btn_JOG_Positive_Start;
        private System.Windows.Forms.Button btn_JOG_Stop;
        public MagicGraphicLibrary.NumericTextBox ntb_scale;
        internal System.Windows.Forms.Label ntb_z_cur_motorpos;
        internal System.Windows.Forms.Label ntb_y_cur_motorpos;
        internal System.Windows.Forms.Label ntb_x_cur_motorpos;
        private System.Windows.Forms.Button btn_JOG_Negative_Start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MagicGraphicLibrary.cZedGraphic ctrl_zgc_dnld;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tbp_sodx;
        private System.Windows.Forms.CheckBox chk_yaxis_auto_scale;
        private System.Windows.Forms.Button btn_sodx_pause;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label lbl_number_of_acq_in_sodx_fifo;
        private System.Windows.Forms.Label lbl_number_of_overflow_in_sodx_fifo;
        private System.Windows.Forms.ProgressBar ctrl_percentage_use_of_sodx_fifo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_sodx;
        private System.Windows.Forms.Label lbl_global_signal_health_upp_not_finished_value;
        private System.Windows.Forms.Label lbl_global_signal_health_exposure_lost_count_value;
        private System.Windows.Forms.Label lbl_global_signal_health_upp_lost_count_value;
        private System.Windows.Forms.Label lbl_global_signal_health_ticket_wrong_order_value;
        private System.Windows.Forms.Label lbl_global_signal_health_dsp_load_value;
        private System.Windows.Forms.Label lbl_global_signal_ticket_number_value;
        private System.Windows.Forms.Label lbl_global_signal_number_of_valid_peaks_value;
        private System.Windows.Forms.Label lbl_global_signal_trigger_lost_count_value;
        private System.Windows.Forms.Label lbl_global_signal_real_lightning_time_value;
        private System.Windows.Forms.Label lbl_global_signal_real_exposure_time_value;
        private System.Windows.Forms.Label lbl_global_signal_exposure_flags_value;
        private System.Windows.Forms.Label lbl_global_signal_first_exposure_count_value;
        private System.Windows.Forms.Label lbl_global_signal_start_time_value;
        private System.Windows.Forms.Label lbl_global_signal_stop_position_v_value;
        private System.Windows.Forms.Label lbl_global_signal_stop_position_u_value;
        private System.Windows.Forms.Label lbl_global_signal_stop_position_z_value;
        private System.Windows.Forms.Label lbl_global_signal_stop_position_y_value;
        private System.Windows.Forms.Label lbl_global_signal_stop_position_x_value;
        private System.Windows.Forms.Label lbl_global_signal_start_position_v_value;
        private System.Windows.Forms.Label lbl_global_signal_start_position_u_value;
        private System.Windows.Forms.Label lbl_global_signal_start_position_z_value;
        private System.Windows.Forms.Label lbl_global_signal_start_position_x_value;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ProgressBar ctrl_counter_gauge;
        private System.Windows.Forms.Label lbl_global_signal_start_position_y_value;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lbl_global_signal_sample_counter_value;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btn_sodx_execute;
        private System.Windows.Forms.Label label61;
        private MagicGraphicLibrary.NumericTextBox num_data_acquisition_number;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_move_distance_z;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btn_exposure;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_imageThreshold;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_ClearAlarm;
        private System.Windows.Forms.Button btn_advanced_mode;
        private System.Windows.Forms.Label label38;
        internal System.Windows.Forms.Label ntb_r_cur_motorpos;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btn_align;
        private System.Windows.Forms.Button btn_start_mea;
        private System.Windows.Forms.GroupBox grp_manual_buttons;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox grp_align_test;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label lb_angle;
        private System.Windows.Forms.Label lb_die_side;
        private System.Windows.Forms.Button btn_find_angle;
        private System.Windows.Forms.Button btn_trigger;
        private System.Windows.Forms.Button btn_connection_ip;
    }
}

