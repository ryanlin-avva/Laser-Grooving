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
            this.btn_advanced_mode = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ntb_z_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_y_cur_motorpos = new System.Windows.Forms.Label();
            this.ntb_x_cur_motorpos = new System.Windows.Forms.Label();
            this.ipAddressControl1 = new MagicGraphicLibrary.IPAddressControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label_numberofchannels = new System.Windows.Forms.Label();
            this.label_first_channel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ntb_threshold = new MagicGraphicLibrary.NumericTextBox(this.components);
            this.label_Threshold = new System.Windows.Forms.Label();
            this.btn_general_mode = new System.Windows.Forms.Button();
            this.sfd_upload = new System.Windows.Forms.SaveFileDialog();
            this.label_xaxis = new System.Windows.Forms.Label();
            this.label_yaxis = new System.Windows.Forms.Label();
            this.label_zaxis = new System.Windows.Forms.Label();
            this.label_current_position = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_PosingStop = new System.Windows.Forms.Button();
            this.ntb_x_cur_pos = new System.Windows.Forms.Label();
            this.ntb_y_cur_pos = new System.Windows.Forms.Label();
            this.ntb_z_cur_pos = new System.Windows.Forms.Label();
            this.btn_JOG_Positive_Start = new System.Windows.Forms.Button();
            this.btn_JOG_Stop = new System.Windows.Forms.Button();
            this.btn_ClearAlarm = new System.Windows.Forms.Button();
            this.btn_JOG_Negative_Start = new System.Windows.Forms.Button();
            this.ctrl_zgc_dnld = new MagicGraphicLibrary.cZedGraphic();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tbp_main = new System.Windows.Forms.TabPage();
            this.tbp_sodx = new System.Windows.Forms.TabPage();
            this.chk_yaxis_auto_scale = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.lbl_number_of_acq_in_sodx_fifo = new System.Windows.Forms.Label();
            this.lbl_number_of_overflow_in_sodx_fifo = new System.Windows.Forms.Label();
            this.ctrl_percentage_use_of_sodx_fifo = new System.Windows.Forms.ProgressBar();
            this.ctrl_zgc_sodx = new MagicGraphicLibrary.cZedGraphic();
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
            this.tbp_record = new System.Windows.Forms.TabPage();
            this.btn_moveto_lefttop = new System.Windows.Forms.Button();
            this.btn_moveto_leftbottom = new System.Windows.Forms.Button();
            this.btn_moveto_righttop = new System.Windows.Forms.Button();
            this.btn_moveto_rightbottom = new System.Windows.Forms.Button();
            this.cb_SelectMeasureDistance = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btn_moveto_WaferCenter_point = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_die_count = new System.Windows.Forms.Button();
            this.btn_movedie_rightbottom = new System.Windows.Forms.Button();
            this.btn_movedie_righttop = new System.Windows.Forms.Button();
            this.btn_movedie_leftbottom = new System.Windows.Forms.Button();
            this.btn_movedie_lefttop = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.btn_movedie_xnegative = new System.Windows.Forms.Button();
            this.btn_movedie_ynegative = new System.Windows.Forms.Button();
            this.btn_movedie_xpositive = new System.Windows.Forms.Button();
            this.btn_movedie_ypositive = new System.Windows.Forms.Button();
            this.lb_multi_measure_point = new System.Windows.Forms.ListBox();
            this.btn_add_measure_point = new System.Windows.Forms.Button();
            this.btn_moveto_select_measure_point = new System.Windows.Forms.Button();
            this.btn_clear_measure_point_list = new System.Windows.Forms.Button();
            this.gb_multi_point = new System.Windows.Forms.GroupBox();
            this.btn_remove_measure_point = new System.Windows.Forms.Button();
            this.ck_multi_point_mea = new System.Windows.Forms.CheckBox();
            this.btn_show_data = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_move_distance_z = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.btn_move_distance = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.btn_movex_negative = new System.Windows.Forms.Button();
            this.btn_movex_positive = new System.Windows.Forms.Button();
            this.btn_movey_negative = new System.Windows.Forms.Button();
            this.btn_movey_positive = new System.Windows.Forms.Button();
            this.btn_movez_positive = new System.Windows.Forms.Button();
            this.btn_movez_negative = new System.Windows.Forms.Button();
            this.btn_record_wafer_center_point = new System.Windows.Forms.Button();
            this.btn_unload_wafer = new System.Windows.Forms.Button();
            this.btn_load_wafer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.gb_showdata = new System.Windows.Forms.GroupBox();
            this.rb_showdata_y = new System.Windows.Forms.RadioButton();
            this.rb_showdata_x = new System.Windows.Forms.RadioButton();
            this.btn_connection = new System.Windows.Forms.Button();
            this.btn_dnld_raw_execute = new System.Windows.Forms.Button();
            this.btn_dark = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cursor_v1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tbp_main.SuspendLayout();
            this.tbp_sodx.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tbp_status.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tbp_record.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gb_multi_point.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_showdata.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ipaddress
            // 
            this.label_ipaddress.AutoSize = true;
            this.label_ipaddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ipaddress.Location = new System.Drawing.Point(6, 64);
            this.label_ipaddress.Name = "label_ipaddress";
            this.label_ipaddress.Size = new System.Drawing.Size(71, 16);
            this.label_ipaddress.TabIndex = 4;
            this.label_ipaddress.Text = "IP Address";
            this.label_ipaddress.Visible = false;
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
            this.ntb_led_intensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_led_intensity.InterceptArrowKeys = true;
            this.ntb_led_intensity.Location = new System.Drawing.Point(462, 44);
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
            this.ntb_led_intensity.Size = new System.Drawing.Size(59, 23);
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
            this.label2.Location = new System.Drawing.Point(527, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(458, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "LED光源強度";
            // 
            // cbx_high_speed
            // 
            this.cbx_high_speed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_high_speed.FormattingEnabled = true;
            this.cbx_high_speed.Location = new System.Drawing.Point(128, 13);
            this.cbx_high_speed.Name = "cbx_high_speed";
            this.cbx_high_speed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbx_high_speed.Size = new System.Drawing.Size(72, 21);
            this.cbx_high_speed.TabIndex = 15;
            this.cbx_high_speed.Visible = false;
            // 
            // label_hz
            // 
            this.label_hz.AutoSize = true;
            this.label_hz.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hz.Location = new System.Drawing.Point(206, 18);
            this.label_hz.Name = "label_hz";
            this.label_hz.Size = new System.Drawing.Size(21, 15);
            this.label_hz.TabIndex = 3;
            this.label_hz.Text = "Hz";
            this.label_hz.Visible = false;
            // 
            // cbx_high_speed_mode
            // 
            this.cbx_high_speed_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_high_speed_mode.FormattingEnabled = true;
            this.cbx_high_speed_mode.Location = new System.Drawing.Point(6, 13);
            this.cbx_high_speed_mode.Name = "cbx_high_speed_mode";
            this.cbx_high_speed_mode.Size = new System.Drawing.Size(114, 21);
            this.cbx_high_speed_mode.TabIndex = 16;
            this.cbx_high_speed_mode.Visible = false;
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
            this.ntb_scale.Location = new System.Drawing.Point(54, 39);
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
            this.ntb_scale.Size = new System.Drawing.Size(45, 23);
            this.ntb_scale.TabIndex = 7;
            this.ntb_scale.Text = "230";
            this.ntb_scale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_scale.ThousandsSeparator = false;
            this.ntb_scale.Value = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.ntb_scale.Visible = false;
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
            this.label_Scale.Location = new System.Drawing.Point(6, 43);
            this.label_Scale.Name = "label_Scale";
            this.label_Scale.Size = new System.Drawing.Size(41, 16);
            this.label_Scale.TabIndex = 5;
            this.label_Scale.Text = "Scale";
            this.label_Scale.Visible = false;
            // 
            // nud_dynamic
            // 
            this.nud_dynamic.Location = new System.Drawing.Point(339, 32);
            this.nud_dynamic.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nud_dynamic.Name = "nud_dynamic";
            this.nud_dynamic.Size = new System.Drawing.Size(48, 23);
            this.nud_dynamic.TabIndex = 71;
            this.nud_dynamic.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dynamic.Visible = false;
            this.nud_dynamic.ValueChanged += new System.EventHandler(this.nud_dynamic_ValueChanged);
            // 
            // label_dynamic
            // 
            this.label_dynamic.AutoSize = true;
            this.label_dynamic.Location = new System.Drawing.Point(337, 16);
            this.label_dynamic.Name = "label_dynamic";
            this.label_dynamic.Size = new System.Drawing.Size(51, 13);
            this.label_dynamic.TabIndex = 70;
            this.label_dynamic.Text = "Dynamic";
            this.label_dynamic.Visible = false;
            // 
            // hsb_noise_offset
            // 
            this.hsb_noise_offset.Location = new System.Drawing.Point(265, 32);
            this.hsb_noise_offset.Name = "hsb_noise_offset";
            this.hsb_noise_offset.Size = new System.Drawing.Size(68, 17);
            this.hsb_noise_offset.TabIndex = 69;
            this.hsb_noise_offset.Visible = false;
            this.hsb_noise_offset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsb_noise_offset_Scroll);
            // 
            // label_noise_offset
            // 
            this.label_noise_offset.AutoSize = true;
            this.label_noise_offset.Location = new System.Drawing.Point(262, 16);
            this.label_noise_offset.Name = "label_noise_offset";
            this.label_noise_offset.Size = new System.Drawing.Size(68, 13);
            this.label_noise_offset.TabIndex = 68;
            this.label_noise_offset.Text = "Noise Offset";
            this.label_noise_offset.Visible = false;
            // 
            // chk_cursor_v3
            // 
            this.chk_cursor_v3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chk_cursor_v3.Location = new System.Drawing.Point(183, 32);
            this.chk_cursor_v3.Name = "chk_cursor_v3";
            this.chk_cursor_v3.Size = new System.Drawing.Size(20, 18);
            this.chk_cursor_v3.TabIndex = 65;
            this.chk_cursor_v3.Visible = false;
            this.chk_cursor_v3.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // chk_cursor_v2
            // 
            this.chk_cursor_v2.BackColor = System.Drawing.Color.Blue;
            this.chk_cursor_v2.Location = new System.Drawing.Point(99, 32);
            this.chk_cursor_v2.Name = "chk_cursor_v2";
            this.chk_cursor_v2.Size = new System.Drawing.Size(20, 18);
            this.chk_cursor_v2.TabIndex = 66;
            this.chk_cursor_v2.Visible = false;
            this.chk_cursor_v2.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // chk_cursor_v1
            // 
            this.chk_cursor_v1.BackColor = System.Drawing.Color.Red;
            this.chk_cursor_v1.Location = new System.Drawing.Point(14, 32);
            this.chk_cursor_v1.Name = "chk_cursor_v1";
            this.chk_cursor_v1.Size = new System.Drawing.Size(20, 18);
            this.chk_cursor_v1.TabIndex = 67;
            this.chk_cursor_v1.Visible = false;
            this.chk_cursor_v1.Click += new System.EventHandler(this.chk_cursor_v_Click);
            // 
            // label_cursor_v3
            // 
            this.label_cursor_v3.AutoSize = true;
            this.label_cursor_v3.Location = new System.Drawing.Point(180, 18);
            this.label_cursor_v3.Name = "label_cursor_v3";
            this.label_cursor_v3.Size = new System.Drawing.Size(58, 13);
            this.label_cursor_v3.TabIndex = 64;
            this.label_cursor_v3.Text = "Cursor V3";
            this.label_cursor_v3.Visible = false;
            // 
            // label_cursor_v2
            // 
            this.label_cursor_v2.AutoSize = true;
            this.label_cursor_v2.Location = new System.Drawing.Point(96, 18);
            this.label_cursor_v2.Name = "label_cursor_v2";
            this.label_cursor_v2.Size = new System.Drawing.Size(58, 13);
            this.label_cursor_v2.TabIndex = 63;
            this.label_cursor_v2.Text = "Cursor V2";
            this.label_cursor_v2.Visible = false;
            // 
            // label_cursor_v1
            // 
            this.label_cursor_v1.AutoSize = true;
            this.label_cursor_v1.Location = new System.Drawing.Point(11, 18);
            this.label_cursor_v1.Name = "label_cursor_v1";
            this.label_cursor_v1.Size = new System.Drawing.Size(58, 13);
            this.label_cursor_v1.TabIndex = 62;
            this.label_cursor_v1.Text = "Cursor V1";
            this.label_cursor_v1.Visible = false;
            // 
            // nud_cursor_v3
            // 
            this.nud_cursor_v3.Location = new System.Drawing.Point(211, 32);
            this.nud_cursor_v3.Name = "nud_cursor_v3";
            this.nud_cursor_v3.Size = new System.Drawing.Size(48, 23);
            this.nud_cursor_v3.TabIndex = 59;
            this.nud_cursor_v3.Visible = false;
            this.nud_cursor_v3.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // nud_cursor_v2
            // 
            this.nud_cursor_v2.Location = new System.Drawing.Point(127, 32);
            this.nud_cursor_v2.Name = "nud_cursor_v2";
            this.nud_cursor_v2.Size = new System.Drawing.Size(48, 23);
            this.nud_cursor_v2.TabIndex = 60;
            this.nud_cursor_v2.Visible = false;
            this.nud_cursor_v2.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // nud_cursor_v1
            // 
            this.nud_cursor_v1.Location = new System.Drawing.Point(42, 32);
            this.nud_cursor_v1.Name = "nud_cursor_v1";
            this.nud_cursor_v1.Size = new System.Drawing.Size(48, 23);
            this.nud_cursor_v1.TabIndex = 61;
            this.nud_cursor_v1.Visible = false;
            this.nud_cursor_v1.ValueChanged += new System.EventHandler(this.nud_cursor_vx_ValueChanged);
            // 
            // clsRawImage
            // 
            this.clsRawImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clsRawImage.BackColor = System.Drawing.Color.Black;
            this.clsRawImage.Data = null;
            this.clsRawImage.Dynamic = ((byte)(0));
            this.clsRawImage.ExtendedColor = true;
            this.clsRawImage.FirstDataColumn = 0;
            this.clsRawImage.FirstDataLine = 0;
            this.clsRawImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsRawImage.LabelColor = System.Drawing.Color.Yellow;
            this.clsRawImage.LabelEnabled = true;
            this.clsRawImage.Location = new System.Drawing.Point(10, 11);
            this.clsRawImage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.clsRawImage.Size = new System.Drawing.Size(384, 364);
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
            this.ctrl_ip_address.Location = new System.Drawing.Point(6, 81);
            this.ctrl_ip_address.MinimumSize = new System.Drawing.Size(87, 23);
            this.ctrl_ip_address.Name = "ctrl_ip_address";
            this.ctrl_ip_address.ReadOnly = false;
            this.ctrl_ip_address.Size = new System.Drawing.Size(87, 23);
            this.ctrl_ip_address.TabIndex = 5;
            this.ctrl_ip_address.Text = "0.0.0.0";
            this.ctrl_ip_address.Visible = false;
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
            this.ntb_dnld_number_of_channels.Location = new System.Drawing.Point(270, 72);
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
            this.ntb_dnld_number_of_channels.Size = new System.Drawing.Size(45, 23);
            this.ntb_dnld_number_of_channels.TabIndex = 81;
            this.ntb_dnld_number_of_channels.Text = "192";
            this.ntb_dnld_number_of_channels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_dnld_number_of_channels.ThousandsSeparator = false;
            this.ntb_dnld_number_of_channels.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            this.ntb_dnld_number_of_channels.Visible = false;
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
            this.ntb_dnld_first_channel.Location = new System.Drawing.Point(270, 44);
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
            this.ntb_dnld_first_channel.Size = new System.Drawing.Size(45, 23);
            this.ntb_dnld_first_channel.TabIndex = 80;
            this.ntb_dnld_first_channel.Text = "0";
            this.ntb_dnld_first_channel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntb_dnld_first_channel.ThousandsSeparator = false;
            this.ntb_dnld_first_channel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntb_dnld_first_channel.Visible = false;
            this.ntb_dnld_first_channel.WarningColor = System.Drawing.Color.Gold;
            this.ntb_dnld_first_channel.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btn_origin_return
            // 
            this.btn_origin_return.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_origin_return.Location = new System.Drawing.Point(734, 19);
            this.btn_origin_return.Name = "btn_origin_return";
            this.btn_origin_return.Size = new System.Drawing.Size(52, 57);
            this.btn_origin_return.TabIndex = 84;
            this.btn_origin_return.Text = "原點復歸";
            this.btn_origin_return.UseVisualStyleBackColor = true;
            this.btn_origin_return.Click += new System.EventHandler(this.btn_origin_return_Click);
            // 
            // btn_advanced_mode
            // 
            this.btn_advanced_mode.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_advanced_mode.Location = new System.Drawing.Point(737, 110);
            this.btn_advanced_mode.Name = "btn_advanced_mode";
            this.btn_advanced_mode.Size = new System.Drawing.Size(92, 61);
            this.btn_advanced_mode.TabIndex = 92;
            this.btn_advanced_mode.Text = "維修模式";
            this.btn_advanced_mode.UseVisualStyleBackColor = true;
            this.btn_advanced_mode.Click += new System.EventHandler(this.btn_advanced_mode_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ntb_z_cur_motorpos);
            this.groupBox3.Controls.Add(this.ntb_y_cur_motorpos);
            this.groupBox3.Controls.Add(this.ntb_x_cur_motorpos);
            this.groupBox3.Controls.Add(this.ctrl_ip_address);
            this.groupBox3.Controls.Add(this.label_ipaddress);
            this.groupBox3.Controls.Add(this.ipAddressControl1);
            this.groupBox3.Controls.Add(this.label3);
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
            this.groupBox3.Location = new System.Drawing.Point(9, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 119);
            this.groupBox3.TabIndex = 93;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Record";
            this.groupBox3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 121;
            this.label7.Text = "z軸馬達位置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "y軸馬達位置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 120;
            this.label5.Text = "x軸馬達位置";
            // 
            // ntb_z_cur_motorpos
            // 
            this.ntb_z_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_z_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_z_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_z_cur_motorpos.Location = new System.Drawing.Point(321, 70);
            this.ntb_z_cur_motorpos.Name = "ntb_z_cur_motorpos";
            this.ntb_z_cur_motorpos.Size = new System.Drawing.Size(69, 20);
            this.ntb_z_cur_motorpos.TabIndex = 118;
            this.ntb_z_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_y_cur_motorpos
            // 
            this.ntb_y_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_y_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_y_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_y_cur_motorpos.Location = new System.Drawing.Point(321, 44);
            this.ntb_y_cur_motorpos.Name = "ntb_y_cur_motorpos";
            this.ntb_y_cur_motorpos.Size = new System.Drawing.Size(69, 20);
            this.ntb_y_cur_motorpos.TabIndex = 117;
            this.ntb_y_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_x_cur_motorpos
            // 
            this.ntb_x_cur_motorpos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_motorpos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_x_cur_motorpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_motorpos.Location = new System.Drawing.Point(321, 19);
            this.ntb_x_cur_motorpos.Name = "ntb_x_cur_motorpos";
            this.ntb_x_cur_motorpos.Size = new System.Drawing.Size(69, 20);
            this.ntb_x_cur_motorpos.TabIndex = 116;
            this.ntb_x_cur_motorpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ipAddressControl1
            // 
            this.ipAddressControl1.AllowInternalTab = false;
            this.ipAddressControl1.AutoHeight = true;
            this.ipAddressControl1.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControl1.Location = new System.Drawing.Point(6, 81);
            this.ipAddressControl1.MinimumSize = new System.Drawing.Size(87, 23);
            this.ipAddressControl1.Name = "ipAddressControl1";
            this.ipAddressControl1.ReadOnly = false;
            this.ipAddressControl1.Size = new System.Drawing.Size(87, 23);
            this.ipAddressControl1.TabIndex = 5;
            this.ipAddressControl1.Text = "0.0.0.0";
            this.ipAddressControl1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP Address";
            this.label3.Visible = false;
            // 
            // label_numberofchannels
            // 
            this.label_numberofchannels.AutoSize = true;
            this.label_numberofchannels.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numberofchannels.Location = new System.Drawing.Point(159, 71);
            this.label_numberofchannels.Name = "label_numberofchannels";
            this.label_numberofchannels.Size = new System.Drawing.Size(101, 16);
            this.label_numberofchannels.TabIndex = 96;
            this.label_numberofchannels.Text = "Num / Channels";
            this.label_numberofchannels.Visible = false;
            // 
            // label_first_channel
            // 
            this.label_first_channel.AutoSize = true;
            this.label_first_channel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_first_channel.Location = new System.Drawing.Point(166, 47);
            this.label_first_channel.Name = "label_first_channel";
            this.label_first_channel.Size = new System.Drawing.Size(85, 16);
            this.label_first_channel.TabIndex = 95;
            this.label_first_channel.Text = "First Channel";
            this.label_first_channel.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(128, 13);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(72, 21);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "閥值";
            this.label4.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(206, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hz";
            this.label8.Visible = false;
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
            this.ntb_threshold.HideSelection = false;
            this.ntb_threshold.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ntb_threshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntb_threshold.InterceptArrowKeys = true;
            this.ntb_threshold.Location = new System.Drawing.Point(967, 86);
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
            this.ntb_threshold.Size = new System.Drawing.Size(45, 23);
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
            // label_Threshold
            // 
            this.label_Threshold.AutoSize = true;
            this.label_Threshold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Threshold.Location = new System.Drawing.Point(957, 65);
            this.label_Threshold.Name = "label_Threshold";
            this.label_Threshold.Size = new System.Drawing.Size(64, 16);
            this.label_Threshold.TabIndex = 122;
            this.label_Threshold.Text = "Threshold";
            // 
            // btn_general_mode
            // 
            this.btn_general_mode.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_general_mode.Location = new System.Drawing.Point(813, 26);
            this.btn_general_mode.Name = "btn_general_mode";
            this.btn_general_mode.Size = new System.Drawing.Size(75, 23);
            this.btn_general_mode.TabIndex = 94;
            this.btn_general_mode.Text = "一般模式";
            this.btn_general_mode.UseVisualStyleBackColor = true;
            this.btn_general_mode.Click += new System.EventHandler(this.btn_general_mode_Click);
            // 
            // label_xaxis
            // 
            this.label_xaxis.AutoSize = true;
            this.label_xaxis.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_xaxis.Location = new System.Drawing.Point(226, 48);
            this.label_xaxis.Name = "label_xaxis";
            this.label_xaxis.Size = new System.Drawing.Size(37, 21);
            this.label_xaxis.TabIndex = 99;
            this.label_xaxis.Text = "X軸";
            // 
            // label_yaxis
            // 
            this.label_yaxis.AutoSize = true;
            this.label_yaxis.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_yaxis.Location = new System.Drawing.Point(226, 96);
            this.label_yaxis.Name = "label_yaxis";
            this.label_yaxis.Size = new System.Drawing.Size(36, 21);
            this.label_yaxis.TabIndex = 100;
            this.label_yaxis.Text = "Y軸";
            // 
            // label_zaxis
            // 
            this.label_zaxis.AutoSize = true;
            this.label_zaxis.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_zaxis.Location = new System.Drawing.Point(226, 150);
            this.label_zaxis.Name = "label_zaxis";
            this.label_zaxis.Size = new System.Drawing.Size(36, 21);
            this.label_zaxis.TabIndex = 101;
            this.label_zaxis.Text = "Z軸";
            // 
            // label_current_position
            // 
            this.label_current_position.AutoSize = true;
            this.label_current_position.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_current_position.Location = new System.Drawing.Point(259, 16);
            this.label_current_position.Name = "label_current_position";
            this.label_current_position.Size = new System.Drawing.Size(74, 21);
            this.label_current_position.TabIndex = 103;
            this.label_current_position.Text = "現在位置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_dynamic);
            this.groupBox1.Controls.Add(this.nud_cursor_v1);
            this.groupBox1.Controls.Add(this.nud_cursor_v2);
            this.groupBox1.Controls.Add(this.nud_cursor_v3);
            this.groupBox1.Controls.Add(this.label_cursor_v1);
            this.groupBox1.Controls.Add(this.label_cursor_v2);
            this.groupBox1.Controls.Add(this.label_cursor_v3);
            this.groupBox1.Controls.Add(this.chk_cursor_v1);
            this.groupBox1.Controls.Add(this.chk_cursor_v2);
            this.groupBox1.Controls.Add(this.chk_cursor_v3);
            this.groupBox1.Controls.Add(this.label_noise_offset);
            this.groupBox1.Controls.Add(this.hsb_noise_offset);
            this.groupBox1.Controls.Add(this.label_dynamic);
            this.groupBox1.Location = new System.Drawing.Point(6, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 60);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cursor";
            this.groupBox1.Visible = false;
            // 
            // btn_PosingStop
            // 
            this.btn_PosingStop.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_PosingStop.Location = new System.Drawing.Point(734, 84);
            this.btn_PosingStop.Name = "btn_PosingStop";
            this.btn_PosingStop.Size = new System.Drawing.Size(52, 57);
            this.btn_PosingStop.TabIndex = 111;
            this.btn_PosingStop.Text = "停止移動";
            this.btn_PosingStop.Click += new System.EventHandler(this.btn_PosingStop_Click);
            // 
            // ntb_x_cur_pos
            // 
            this.ntb_x_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_x_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_x_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_x_cur_pos.Location = new System.Drawing.Point(263, 47);
            this.ntb_x_cur_pos.Name = "ntb_x_cur_pos";
            this.ntb_x_cur_pos.Size = new System.Drawing.Size(69, 20);
            this.ntb_x_cur_pos.TabIndex = 113;
            this.ntb_x_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_y_cur_pos
            // 
            this.ntb_y_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_y_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_y_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_y_cur_pos.Location = new System.Drawing.Point(263, 96);
            this.ntb_y_cur_pos.Name = "ntb_y_cur_pos";
            this.ntb_y_cur_pos.Size = new System.Drawing.Size(69, 20);
            this.ntb_y_cur_pos.TabIndex = 114;
            this.ntb_y_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntb_z_cur_pos
            // 
            this.ntb_z_cur_pos.BackColor = System.Drawing.Color.White;
            this.ntb_z_cur_pos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ntb_z_cur_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ntb_z_cur_pos.Location = new System.Drawing.Point(263, 149);
            this.ntb_z_cur_pos.Name = "ntb_z_cur_pos";
            this.ntb_z_cur_pos.Size = new System.Drawing.Size(69, 20);
            this.ntb_z_cur_pos.TabIndex = 115;
            this.ntb_z_cur_pos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_JOG_Positive_Start
            // 
            this.btn_JOG_Positive_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Positive_Start.Location = new System.Drawing.Point(519, 25);
            this.btn_JOG_Positive_Start.Name = "btn_JOG_Positive_Start";
            this.btn_JOG_Positive_Start.Size = new System.Drawing.Size(57, 40);
            this.btn_JOG_Positive_Start.TabIndex = 116;
            this.btn_JOG_Positive_Start.Text = "JOG+ Start";
            this.btn_JOG_Positive_Start.Click += new System.EventHandler(this.btn_JOG_Positive_Start_Click);
            // 
            // btn_JOG_Stop
            // 
            this.btn_JOG_Stop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Stop.Location = new System.Drawing.Point(519, 72);
            this.btn_JOG_Stop.Name = "btn_JOG_Stop";
            this.btn_JOG_Stop.Size = new System.Drawing.Size(57, 40);
            this.btn_JOG_Stop.TabIndex = 117;
            this.btn_JOG_Stop.Text = "JOG Stop";
            this.btn_JOG_Stop.Click += new System.EventHandler(this.btn_JOG_Stop_Click);
            // 
            // btn_ClearAlarm
            // 
            this.btn_ClearAlarm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearAlarm.Location = new System.Drawing.Point(946, 113);
            this.btn_ClearAlarm.Name = "btn_ClearAlarm";
            this.btn_ClearAlarm.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearAlarm.TabIndex = 118;
            this.btn_ClearAlarm.Text = "AlarmClear";
            this.btn_ClearAlarm.UseVisualStyleBackColor = true;
            this.btn_ClearAlarm.Visible = false;
            this.btn_ClearAlarm.Click += new System.EventHandler(this.btn_ClearAlarm_Click);
            // 
            // btn_JOG_Negative_Start
            // 
            this.btn_JOG_Negative_Start.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JOG_Negative_Start.Location = new System.Drawing.Point(519, 118);
            this.btn_JOG_Negative_Start.Name = "btn_JOG_Negative_Start";
            this.btn_JOG_Negative_Start.Size = new System.Drawing.Size(57, 40);
            this.btn_JOG_Negative_Start.TabIndex = 119;
            this.btn_JOG_Negative_Start.Text = "JOG- Start";
            this.btn_JOG_Negative_Start.Click += new System.EventHandler(this.btn_JOG_Negative_Start_Click);
            // 
            // ctrl_zgc_dnld
            // 
            this.ctrl_zgc_dnld.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ctrl_zgc_dnld.ChoiceOfFiberLegend = "";
            this.ctrl_zgc_dnld.EnableChoiceOfFiber = true;
            this.ctrl_zgc_dnld.Location = new System.Drawing.Point(413, 1);
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
            this.ctrl_zgc_dnld.Size = new System.Drawing.Size(592, 439);
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
            this.tabControlMain.Controls.Add(this.tbp_record);
            this.tabControlMain.Location = new System.Drawing.Point(3, 409);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1019, 477);
            this.tabControlMain.TabIndex = 120;
            // 
            // tbp_main
            // 
            this.tbp_main.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_main.CausesValidation = false;
            this.tbp_main.Controls.Add(this.clsRawImage);
            this.tbp_main.Controls.Add(this.groupBox1);
            this.tbp_main.Controls.Add(this.ctrl_zgc_dnld);
            this.tbp_main.Location = new System.Drawing.Point(4, 23);
            this.tbp_main.Name = "tbp_main";
            this.tbp_main.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_main.Size = new System.Drawing.Size(1011, 450);
            this.tbp_main.TabIndex = 6;
            this.tbp_main.Text = "Main";
            // 
            // tbp_sodx
            // 
            this.tbp_sodx.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_sodx.Controls.Add(this.chk_yaxis_auto_scale);
            this.tbp_sodx.Controls.Add(this.label69);
            this.tbp_sodx.Controls.Add(this.lbl_number_of_acq_in_sodx_fifo);
            this.tbp_sodx.Controls.Add(this.lbl_number_of_overflow_in_sodx_fifo);
            this.tbp_sodx.Controls.Add(this.ctrl_percentage_use_of_sodx_fifo);
            this.tbp_sodx.Controls.Add(this.ctrl_zgc_sodx);
            this.tbp_sodx.Controls.Add(this.groupBox4);
            this.tbp_sodx.Controls.Add(this.label61);
            this.tbp_sodx.Controls.Add(this.num_data_acquisition_number);
            this.tbp_sodx.Controls.Add(this.btn_sodx_pause);
            this.tbp_sodx.Controls.Add(this.btn_sodx_execute);
            this.tbp_sodx.Location = new System.Drawing.Point(4, 23);
            this.tbp_sodx.Name = "tbp_sodx";
            this.tbp_sodx.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_sodx.Size = new System.Drawing.Size(1011, 450);
            this.tbp_sodx.TabIndex = 0;
            this.tbp_sodx.Text = "SODX";
            // 
            // chk_yaxis_auto_scale
            // 
            this.chk_yaxis_auto_scale.AutoSize = true;
            this.chk_yaxis_auto_scale.Location = new System.Drawing.Point(444, 6);
            this.chk_yaxis_auto_scale.Name = "chk_yaxis_auto_scale";
            this.chk_yaxis_auto_scale.Size = new System.Drawing.Size(116, 17);
            this.chk_yaxis_auto_scale.TabIndex = 48;
            this.chk_yaxis_auto_scale.Text = "Y Axis Auto Scale";
            this.chk_yaxis_auto_scale.UseVisualStyleBackColor = true;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(73, 38);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(105, 15);
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
            this.lbl_number_of_acq_in_sodx_fifo.Location = new System.Drawing.Point(189, 37);
            this.lbl_number_of_acq_in_sodx_fifo.Name = "lbl_number_of_acq_in_sodx_fifo";
            this.lbl_number_of_acq_in_sodx_fifo.Size = new System.Drawing.Size(78, 15);
            this.lbl_number_of_acq_in_sodx_fifo.TabIndex = 44;
            this.lbl_number_of_acq_in_sodx_fifo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_number_of_overflow_in_sodx_fifo
            // 
            this.lbl_number_of_overflow_in_sodx_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_sodx_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_sodx_fifo.Location = new System.Drawing.Point(212, 12);
            this.lbl_number_of_overflow_in_sodx_fifo.Name = "lbl_number_of_overflow_in_sodx_fifo";
            this.lbl_number_of_overflow_in_sodx_fifo.Size = new System.Drawing.Size(63, 15);
            this.lbl_number_of_overflow_in_sodx_fifo.TabIndex = 40;
            this.lbl_number_of_overflow_in_sodx_fifo.Text = "Overflow";
            // 
            // ctrl_percentage_use_of_sodx_fifo
            // 
            this.ctrl_percentage_use_of_sodx_fifo.Location = new System.Drawing.Point(278, 34);
            this.ctrl_percentage_use_of_sodx_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_sodx_fifo.Name = "ctrl_percentage_use_of_sodx_fifo";
            this.ctrl_percentage_use_of_sodx_fifo.Size = new System.Drawing.Size(77, 21);
            this.ctrl_percentage_use_of_sodx_fifo.Step = 1;
            this.ctrl_percentage_use_of_sodx_fifo.TabIndex = 39;
            // 
            // ctrl_zgc_sodx
            // 
            this.ctrl_zgc_sodx.ChoiceOfFiberLegend = "";
            this.ctrl_zgc_sodx.EnableChoiceOfFiber = false;
            this.ctrl_zgc_sodx.Location = new System.Drawing.Point(444, 34);
            this.ctrl_zgc_sodx.MenuAutoScale = false;
            this.ctrl_zgc_sodx.MenuLoadData = false;
            this.ctrl_zgc_sodx.MenuPrintImage = true;
            this.ctrl_zgc_sodx.MenuSaveData = false;
            this.ctrl_zgc_sodx.MenuSaveImage = true;
            this.ctrl_zgc_sodx.MenuShowValues = true;
            this.ctrl_zgc_sodx.MenuUnZoom = true;
            this.ctrl_zgc_sodx.Name = "ctrl_zgc_sodx";
            this.ctrl_zgc_sodx.PathDataFile = null;
            this.ctrl_zgc_sodx.PathImageFile = null;
            this.ctrl_zgc_sodx.ResourceLanguage = null;
            this.ctrl_zgc_sodx.ScrollGrace = 0D;
            this.ctrl_zgc_sodx.ScrollMaxX = 0D;
            this.ctrl_zgc_sodx.ScrollMaxY = 0D;
            this.ctrl_zgc_sodx.ScrollMaxY2 = 0D;
            this.ctrl_zgc_sodx.ScrollMinX = 0D;
            this.ctrl_zgc_sodx.ScrollMinY = 0D;
            this.ctrl_zgc_sodx.ScrollMinY2 = 0D;
            this.ctrl_zgc_sodx.Size = new System.Drawing.Size(558, 409);
            this.ctrl_zgc_sodx.TabIndex = 34;
            this.ctrl_zgc_sodx.TextMenuAutoScale = "AutoScale";
            this.ctrl_zgc_sodx.TextMenuLoadData = "Load Data";
            this.ctrl_zgc_sodx.TextMenuPrintImage = "Print Image";
            this.ctrl_zgc_sodx.TextMenuSaveData = "Save Data";
            this.ctrl_zgc_sodx.TextMenuSaveImage = "Save Image";
            this.ctrl_zgc_sodx.TextMenuShowValues = "Show Values";
            this.ctrl_zgc_sodx.TextMenuUnZoom = "UnZoom";
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
            this.groupBox4.Location = new System.Drawing.Point(6, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(432, 256);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Signals";
            // 
            // btn_sodx
            // 
            this.btn_sodx.Location = new System.Drawing.Point(244, 226);
            this.btn_sodx.Name = "btn_sodx";
            this.btn_sodx.Size = new System.Drawing.Size(179, 21);
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
            this.lbl_global_signal_health_upp_not_finished_value.Location = new System.Drawing.Point(164, 233);
            this.lbl_global_signal_health_upp_not_finished_value.Name = "lbl_global_signal_health_upp_not_finished_value";
            this.lbl_global_signal_health_upp_not_finished_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_health_exposure_lost_count_value.Location = new System.Drawing.Point(164, 216);
            this.lbl_global_signal_health_exposure_lost_count_value.Name = "lbl_global_signal_health_exposure_lost_count_value";
            this.lbl_global_signal_health_exposure_lost_count_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_health_upp_lost_count_value.Location = new System.Drawing.Point(164, 199);
            this.lbl_global_signal_health_upp_lost_count_value.Name = "lbl_global_signal_health_upp_lost_count_value";
            this.lbl_global_signal_health_upp_lost_count_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_health_ticket_wrong_order_value.Location = new System.Drawing.Point(164, 183);
            this.lbl_global_signal_health_ticket_wrong_order_value.Name = "lbl_global_signal_health_ticket_wrong_order_value";
            this.lbl_global_signal_health_ticket_wrong_order_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_health_dsp_load_value.Location = new System.Drawing.Point(164, 150);
            this.lbl_global_signal_health_dsp_load_value.Name = "lbl_global_signal_health_dsp_load_value";
            this.lbl_global_signal_health_dsp_load_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_ticket_number_value.Location = new System.Drawing.Point(164, 133);
            this.lbl_global_signal_ticket_number_value.Name = "lbl_global_signal_ticket_number_value";
            this.lbl_global_signal_ticket_number_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_number_of_valid_peaks_value.Location = new System.Drawing.Point(164, 116);
            this.lbl_global_signal_number_of_valid_peaks_value.Name = "lbl_global_signal_number_of_valid_peaks_value";
            this.lbl_global_signal_number_of_valid_peaks_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_trigger_lost_count_value.Location = new System.Drawing.Point(164, 100);
            this.lbl_global_signal_trigger_lost_count_value.Name = "lbl_global_signal_trigger_lost_count_value";
            this.lbl_global_signal_trigger_lost_count_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_real_lightning_time_value.Location = new System.Drawing.Point(164, 83);
            this.lbl_global_signal_real_lightning_time_value.Name = "lbl_global_signal_real_lightning_time_value";
            this.lbl_global_signal_real_lightning_time_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_real_exposure_time_value.Location = new System.Drawing.Point(164, 66);
            this.lbl_global_signal_real_exposure_time_value.Name = "lbl_global_signal_real_exposure_time_value";
            this.lbl_global_signal_real_exposure_time_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_exposure_flags_value.Location = new System.Drawing.Point(164, 50);
            this.lbl_global_signal_exposure_flags_value.Name = "lbl_global_signal_exposure_flags_value";
            this.lbl_global_signal_exposure_flags_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_first_exposure_count_value.Location = new System.Drawing.Point(164, 33);
            this.lbl_global_signal_first_exposure_count_value.Name = "lbl_global_signal_first_exposure_count_value";
            this.lbl_global_signal_first_exposure_count_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_start_time_value.Location = new System.Drawing.Point(164, 17);
            this.lbl_global_signal_start_time_value.Name = "lbl_global_signal_start_time_value";
            this.lbl_global_signal_start_time_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_stop_position_v_value.Location = new System.Drawing.Point(352, 167);
            this.lbl_global_signal_stop_position_v_value.Name = "lbl_global_signal_stop_position_v_value";
            this.lbl_global_signal_stop_position_v_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_stop_position_u_value.Location = new System.Drawing.Point(352, 150);
            this.lbl_global_signal_stop_position_u_value.Name = "lbl_global_signal_stop_position_u_value";
            this.lbl_global_signal_stop_position_u_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_stop_position_z_value.Location = new System.Drawing.Point(352, 134);
            this.lbl_global_signal_stop_position_z_value.Name = "lbl_global_signal_stop_position_z_value";
            this.lbl_global_signal_stop_position_z_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_stop_position_y_value.Location = new System.Drawing.Point(352, 117);
            this.lbl_global_signal_stop_position_y_value.Name = "lbl_global_signal_stop_position_y_value";
            this.lbl_global_signal_stop_position_y_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_stop_position_x_value.Location = new System.Drawing.Point(352, 101);
            this.lbl_global_signal_stop_position_x_value.Name = "lbl_global_signal_stop_position_x_value";
            this.lbl_global_signal_stop_position_x_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_start_position_v_value.Location = new System.Drawing.Point(352, 84);
            this.lbl_global_signal_start_position_v_value.Name = "lbl_global_signal_start_position_v_value";
            this.lbl_global_signal_start_position_v_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_start_position_u_value.Location = new System.Drawing.Point(352, 67);
            this.lbl_global_signal_start_position_u_value.Name = "lbl_global_signal_start_position_u_value";
            this.lbl_global_signal_start_position_u_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_start_position_z_value.Location = new System.Drawing.Point(352, 51);
            this.lbl_global_signal_start_position_z_value.Name = "lbl_global_signal_start_position_z_value";
            this.lbl_global_signal_start_position_z_value.Size = new System.Drawing.Size(71, 15);
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
            this.lbl_global_signal_start_position_x_value.Location = new System.Drawing.Point(352, 18);
            this.lbl_global_signal_start_position_x_value.Name = "lbl_global_signal_start_position_x_value";
            this.lbl_global_signal_start_position_x_value.Size = new System.Drawing.Size(71, 15);
            this.lbl_global_signal_start_position_x_value.TabIndex = 31;
            this.lbl_global_signal_start_position_x_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(11, 234);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(127, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Health Upp Not Finished";
            // 
            // ctrl_counter_gauge
            // 
            this.ctrl_counter_gauge.Location = new System.Drawing.Point(244, 193);
            this.ctrl_counter_gauge.MarqueeAnimationSpeed = 0;
            this.ctrl_counter_gauge.Maximum = 65535;
            this.ctrl_counter_gauge.Name = "ctrl_counter_gauge";
            this.ctrl_counter_gauge.Size = new System.Drawing.Size(179, 21);
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
            this.lbl_global_signal_start_position_y_value.Location = new System.Drawing.Point(352, 34);
            this.lbl_global_signal_start_position_y_value.Name = "lbl_global_signal_start_position_y_value";
            this.lbl_global_signal_start_position_y_value.Size = new System.Drawing.Size(71, 15);
            this.lbl_global_signal_start_position_y_value.TabIndex = 31;
            this.lbl_global_signal_start_position_y_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 218);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(142, 13);
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
            this.lbl_global_signal_sample_counter_value.Location = new System.Drawing.Point(164, 166);
            this.lbl_global_signal_sample_counter_value.Name = "lbl_global_signal_sample_counter_value";
            this.lbl_global_signal_sample_counter_value.Size = new System.Drawing.Size(71, 15);
            this.lbl_global_signal_sample_counter_value.TabIndex = 31;
            this.lbl_global_signal_sample_counter_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 201);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(154, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "SampleHealth Upp Lost Count";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(241, 168);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(83, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Stop Position V";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Health Ticket Wrong Order";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(241, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Stop Position U";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Health Dsp Load";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Stop Position Z";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 135);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 13);
            this.label31.TabIndex = 2;
            this.label31.Text = "Ticket Number";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(241, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Stop Position Y";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(11, 118);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(123, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Number Of Valid Peaks";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(241, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Stop Position X";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 102);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(98, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "Trigger Lost Count";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(241, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Start Position V";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 85);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Real Lightning Time";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(241, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Start Position U";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 68);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "Real Exposure Time";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(241, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Start Position Z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "First Flags";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(241, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Start Position Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "First Exposure Count";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(241, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Start Position X";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(57, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "Start Time";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(11, 168);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(84, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Sample Counter";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(73, 12);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(63, 15);
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
            this.num_data_acquisition_number.Location = new System.Drawing.Point(142, 9);
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
            this.num_data_acquisition_number.Size = new System.Drawing.Size(61, 23);
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
            this.btn_sodx_pause.Location = new System.Drawing.Point(368, 7);
            this.btn_sodx_pause.Name = "btn_sodx_pause";
            this.btn_sodx_pause.Size = new System.Drawing.Size(61, 52);
            this.btn_sodx_pause.TabIndex = 47;
            this.btn_sodx_pause.UseVisualStyleBackColor = true;
            this.btn_sodx_pause.Click += new System.EventHandler(this.btn_sodx_pause_Click);
            // 
            // btn_sodx_execute
            // 
            this.btn_sodx_execute.Image = ((System.Drawing.Image)(resources.GetObject("btn_sodx_execute.Image")));
            this.btn_sodx_execute.Location = new System.Drawing.Point(6, 7);
            this.btn_sodx_execute.Name = "btn_sodx_execute";
            this.btn_sodx_execute.Size = new System.Drawing.Size(61, 52);
            this.btn_sodx_execute.TabIndex = 35;
            this.btn_sodx_execute.UseVisualStyleBackColor = true;
            this.btn_sodx_execute.Click += new System.EventHandler(this.btn_sodx_execute_Click);
            // 
            // tbp_status
            // 
            this.tbp_status.BackColor = System.Drawing.SystemColors.Control;
            this.tbp_status.Controls.Add(this.lst_log);
            this.tbp_status.Controls.Add(this.groupBox5);
            this.tbp_status.Location = new System.Drawing.Point(4, 23);
            this.tbp_status.Name = "tbp_status";
            this.tbp_status.Size = new System.Drawing.Size(1011, 450);
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
            this.lst_log.Location = new System.Drawing.Point(382, 6);
            this.lst_log.Name = "lst_log";
            this.lst_log.ShowItemToolTips = true;
            this.lst_log.Size = new System.Drawing.Size(616, 441);
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
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(373, 476);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // lbl_number_of_overflow_in_data_format_fifo
            // 
            this.lbl_number_of_overflow_in_data_format_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_data_format_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_format_fifo.Location = new System.Drawing.Point(135, 193);
            this.lbl_number_of_overflow_in_data_format_fifo.Name = "lbl_number_of_overflow_in_data_format_fifo";
            this.lbl_number_of_overflow_in_data_format_fifo.Size = new System.Drawing.Size(63, 15);
            this.lbl_number_of_overflow_in_data_format_fifo.TabIndex = 35;
            this.lbl_number_of_overflow_in_data_format_fifo.Text = "Overflow";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "Data Format";
            // 
            // ctrl_percentage_use_of_data_format_fifo
            // 
            this.ctrl_percentage_use_of_data_format_fifo.Location = new System.Drawing.Point(303, 189);
            this.ctrl_percentage_use_of_data_format_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_data_format_fifo.Name = "ctrl_percentage_use_of_data_format_fifo";
            this.ctrl_percentage_use_of_data_format_fifo.Size = new System.Drawing.Size(57, 21);
            this.ctrl_percentage_use_of_data_format_fifo.Step = 1;
            this.ctrl_percentage_use_of_data_format_fifo.TabIndex = 34;
            // 
            // lbl_number_of_overflow_in_command_data_fifo
            // 
            this.lbl_number_of_overflow_in_command_data_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_command_data_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_command_data_fifo.Location = new System.Drawing.Point(135, 167);
            this.lbl_number_of_overflow_in_command_data_fifo.Name = "lbl_number_of_overflow_in_command_data_fifo";
            this.lbl_number_of_overflow_in_command_data_fifo.Size = new System.Drawing.Size(63, 15);
            this.lbl_number_of_overflow_in_command_data_fifo.TabIndex = 32;
            this.lbl_number_of_overflow_in_command_data_fifo.Text = "Overflow";
            // 
            // lbl_number_of_overflow_in_data_raw_fifo
            // 
            this.lbl_number_of_overflow_in_data_raw_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_data_raw_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_raw_fifo.Location = new System.Drawing.Point(135, 115);
            this.lbl_number_of_overflow_in_data_raw_fifo.Name = "lbl_number_of_overflow_in_data_raw_fifo";
            this.lbl_number_of_overflow_in_data_raw_fifo.Size = new System.Drawing.Size(63, 15);
            this.lbl_number_of_overflow_in_data_raw_fifo.TabIndex = 31;
            this.lbl_number_of_overflow_in_data_raw_fifo.Text = "Overflow";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Data Socket";
            // 
            // lbl_number_of_overflow_in_data_raw_socket
            // 
            this.lbl_number_of_overflow_in_data_raw_socket.AutoSize = true;
            this.lbl_number_of_overflow_in_data_raw_socket.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_raw_socket.Location = new System.Drawing.Point(135, 90);
            this.lbl_number_of_overflow_in_data_raw_socket.Name = "lbl_number_of_overflow_in_data_raw_socket";
            this.lbl_number_of_overflow_in_data_raw_socket.Size = new System.Drawing.Size(63, 15);
            this.lbl_number_of_overflow_in_data_raw_socket.TabIndex = 24;
            this.lbl_number_of_overflow_in_data_raw_socket.Text = "Overflow";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(9, 167);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(91, 15);
            this.label48.TabIndex = 23;
            this.label48.Text = "Command Data";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(9, 115);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 15);
            this.label36.TabIndex = 25;
            this.label36.Text = "Data Raw";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(9, 141);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(84, 15);
            this.label47.TabIndex = 21;
            this.label47.Text = "Data Sample";
            // 
            // lbl_number_of_overflow_in_data_sample_fifo
            // 
            this.lbl_number_of_overflow_in_data_sample_fifo.AutoSize = true;
            this.lbl_number_of_overflow_in_data_sample_fifo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_number_of_overflow_in_data_sample_fifo.Location = new System.Drawing.Point(135, 141);
            this.lbl_number_of_overflow_in_data_sample_fifo.Name = "lbl_number_of_overflow_in_data_sample_fifo";
            this.lbl_number_of_overflow_in_data_sample_fifo.Size = new System.Drawing.Size(63, 15);
            this.lbl_number_of_overflow_in_data_sample_fifo.TabIndex = 20;
            this.lbl_number_of_overflow_in_data_sample_fifo.Text = "Overflow";
            // 
            // ctrl_percentage_use_of_fifo_data_raw_socket
            // 
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Location = new System.Drawing.Point(303, 86);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Name = "ctrl_percentage_use_of_fifo_data_raw_socket";
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Size = new System.Drawing.Size(57, 21);
            this.ctrl_percentage_use_of_fifo_data_raw_socket.Step = 1;
            this.ctrl_percentage_use_of_fifo_data_raw_socket.TabIndex = 27;
            // 
            // ctrl_percentage_use_of_fifo_data_raw_fifo
            // 
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Location = new System.Drawing.Point(303, 112);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Name = "ctrl_percentage_use_of_fifo_data_raw_fifo";
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Size = new System.Drawing.Size(57, 21);
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.Step = 1;
            this.ctrl_percentage_use_of_fifo_data_raw_fifo.TabIndex = 28;
            // 
            // ctrl_percentage_use_of_command_data_fifo
            // 
            this.ctrl_percentage_use_of_command_data_fifo.Location = new System.Drawing.Point(303, 163);
            this.ctrl_percentage_use_of_command_data_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_command_data_fifo.Name = "ctrl_percentage_use_of_command_data_fifo";
            this.ctrl_percentage_use_of_command_data_fifo.Size = new System.Drawing.Size(57, 21);
            this.ctrl_percentage_use_of_command_data_fifo.Step = 1;
            this.ctrl_percentage_use_of_command_data_fifo.TabIndex = 29;
            // 
            // ctrl_percentage_use_of_data_sample_fifo
            // 
            this.ctrl_percentage_use_of_data_sample_fifo.Location = new System.Drawing.Point(303, 138);
            this.ctrl_percentage_use_of_data_sample_fifo.MarqueeAnimationSpeed = 0;
            this.ctrl_percentage_use_of_data_sample_fifo.Name = "ctrl_percentage_use_of_data_sample_fifo";
            this.ctrl_percentage_use_of_data_sample_fifo.Size = new System.Drawing.Size(57, 21);
            this.ctrl_percentage_use_of_data_sample_fifo.Step = 1;
            this.ctrl_percentage_use_of_data_sample_fifo.TabIndex = 30;
            // 
            // lbl_rx_rate
            // 
            this.lbl_rx_rate.AutoSize = true;
            this.lbl_rx_rate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rx_rate.Location = new System.Drawing.Point(9, 15);
            this.lbl_rx_rate.Name = "lbl_rx_rate";
            this.lbl_rx_rate.Size = new System.Drawing.Size(49, 15);
            this.lbl_rx_rate.TabIndex = 22;
            this.lbl_rx_rate.Text = "rxRate";
            // 
            // lbl_tx_rate
            // 
            this.lbl_tx_rate.AutoSize = true;
            this.lbl_tx_rate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tx_rate.Location = new System.Drawing.Point(9, 41);
            this.lbl_tx_rate.Name = "lbl_tx_rate";
            this.lbl_tx_rate.Size = new System.Drawing.Size(49, 15);
            this.lbl_tx_rate.TabIndex = 19;
            this.lbl_tx_rate.Text = "txRate";
            // 
            // lbl_error_no_dataformat
            // 
            this.lbl_error_no_dataformat.AutoSize = true;
            this.lbl_error_no_dataformat.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_no_dataformat.Location = new System.Drawing.Point(9, 319);
            this.lbl_error_no_dataformat.Name = "lbl_error_no_dataformat";
            this.lbl_error_no_dataformat.Size = new System.Drawing.Size(168, 15);
            this.lbl_error_no_dataformat.TabIndex = 11;
            this.lbl_error_no_dataformat.Text = "lbl_error_no_dataformat";
            // 
            // lbl_unformatted_data
            // 
            this.lbl_unformatted_data.AutoSize = true;
            this.lbl_unformatted_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_unformatted_data.Location = new System.Drawing.Point(9, 415);
            this.lbl_unformatted_data.Name = "lbl_unformatted_data";
            this.lbl_unformatted_data.Size = new System.Drawing.Size(147, 15);
            this.lbl_unformatted_data.TabIndex = 11;
            this.lbl_unformatted_data.Text = "lbl_unformatted_data";
            // 
            // lbl_resynchronization
            // 
            this.lbl_resynchronization.AutoSize = true;
            this.lbl_resynchronization.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_resynchronization.Location = new System.Drawing.Point(9, 402);
            this.lbl_resynchronization.Name = "lbl_resynchronization";
            this.lbl_resynchronization.Size = new System.Drawing.Size(154, 15);
            this.lbl_resynchronization.TabIndex = 11;
            this.lbl_resynchronization.Text = "lbl_resynchronization";
            // 
            // lbl_not_enough_data
            // 
            this.lbl_not_enough_data.AutoSize = true;
            this.lbl_not_enough_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_not_enough_data.Location = new System.Drawing.Point(9, 388);
            this.lbl_not_enough_data.Name = "lbl_not_enough_data";
            this.lbl_not_enough_data.Size = new System.Drawing.Size(140, 15);
            this.lbl_not_enough_data.TabIndex = 10;
            this.lbl_not_enough_data.Text = "lbl_not_enough_data";
            // 
            // lbl_error_data
            // 
            this.lbl_error_data.AutoSize = true;
            this.lbl_error_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data.Location = new System.Drawing.Point(9, 305);
            this.lbl_error_data.Name = "lbl_error_data";
            this.lbl_error_data.Size = new System.Drawing.Size(105, 15);
            this.lbl_error_data.TabIndex = 10;
            this.lbl_error_data.Text = "lbl_error_data";
            // 
            // lbl_error_data_header
            // 
            this.lbl_error_data_header.AutoSize = true;
            this.lbl_error_data_header.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data_header.Location = new System.Drawing.Point(9, 291);
            this.lbl_error_data_header.Name = "lbl_error_data_header";
            this.lbl_error_data_header.Size = new System.Drawing.Size(154, 15);
            this.lbl_error_data_header.TabIndex = 10;
            this.lbl_error_data_header.Text = "lbl_error_data_header";
            // 
            // lbl_error_data_format_entry
            // 
            this.lbl_error_data_format_entry.AutoSize = true;
            this.lbl_error_data_format_entry.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data_format_entry.Location = new System.Drawing.Point(9, 277);
            this.lbl_error_data_format_entry.Name = "lbl_error_data_format_entry";
            this.lbl_error_data_format_entry.Size = new System.Drawing.Size(196, 15);
            this.lbl_error_data_format_entry.TabIndex = 10;
            this.lbl_error_data_format_entry.Text = "lbl_error_data_format_entry";
            // 
            // lbl_error_data_format_header
            // 
            this.lbl_error_data_format_header.AutoSize = true;
            this.lbl_error_data_format_header.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_data_format_header.Location = new System.Drawing.Point(9, 263);
            this.lbl_error_data_format_header.Name = "lbl_error_data_format_header";
            this.lbl_error_data_format_header.Size = new System.Drawing.Size(203, 15);
            this.lbl_error_data_format_header.TabIndex = 10;
            this.lbl_error_data_format_header.Text = "lbl_error_data_format_header";
            // 
            // lbl_error_command_data
            // 
            this.lbl_error_command_data.AutoSize = true;
            this.lbl_error_command_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_command_data.Location = new System.Drawing.Point(9, 249);
            this.lbl_error_command_data.Name = "lbl_error_command_data";
            this.lbl_error_command_data.Size = new System.Drawing.Size(161, 15);
            this.lbl_error_command_data.TabIndex = 10;
            this.lbl_error_command_data.Text = "lbl_error_command_data";
            // 
            // lbl_error_command_header
            // 
            this.lbl_error_command_header.AutoSize = true;
            this.lbl_error_command_header.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_command_header.Location = new System.Drawing.Point(9, 235);
            this.lbl_error_command_header.Name = "lbl_error_command_header";
            this.lbl_error_command_header.Size = new System.Drawing.Size(175, 15);
            this.lbl_error_command_header.TabIndex = 10;
            this.lbl_error_command_header.Text = "lbl_error_command_header";
            // 
            // lbl_number_of_spectra
            // 
            this.lbl_number_of_spectra.AutoSize = true;
            this.lbl_number_of_spectra.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_spectra.Location = new System.Drawing.Point(9, 374);
            this.lbl_number_of_spectra.Name = "lbl_number_of_spectra";
            this.lbl_number_of_spectra.Size = new System.Drawing.Size(154, 15);
            this.lbl_number_of_spectra.TabIndex = 10;
            this.lbl_number_of_spectra.Text = "lbl_number_of_spectra";
            // 
            // lbl_number_of_data
            // 
            this.lbl_number_of_data.AutoSize = true;
            this.lbl_number_of_data.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_data.Location = new System.Drawing.Point(9, 360);
            this.lbl_number_of_data.Name = "lbl_number_of_data";
            this.lbl_number_of_data.Size = new System.Drawing.Size(133, 15);
            this.lbl_number_of_data.TabIndex = 10;
            this.lbl_number_of_data.Text = "lbl_number_of_data";
            // 
            // lbl_number_of_format
            // 
            this.lbl_number_of_format.AutoSize = true;
            this.lbl_number_of_format.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_format.Location = new System.Drawing.Point(9, 346);
            this.lbl_number_of_format.Name = "lbl_number_of_format";
            this.lbl_number_of_format.Size = new System.Drawing.Size(147, 15);
            this.lbl_number_of_format.TabIndex = 10;
            this.lbl_number_of_format.Text = "lbl_number_of_format";
            // 
            // lbl_number_of_command
            // 
            this.lbl_number_of_command.AutoSize = true;
            this.lbl_number_of_command.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_number_of_command.Location = new System.Drawing.Point(9, 332);
            this.lbl_number_of_command.Name = "lbl_number_of_command";
            this.lbl_number_of_command.Size = new System.Drawing.Size(154, 15);
            this.lbl_number_of_command.TabIndex = 10;
            this.lbl_number_of_command.Text = "lbl_number_of_command";
            // 
            // lbl_error_unknow_telegram_type
            // 
            this.lbl_error_unknow_telegram_type.AutoSize = true;
            this.lbl_error_unknow_telegram_type.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbl_error_unknow_telegram_type.Location = new System.Drawing.Point(9, 222);
            this.lbl_error_unknow_telegram_type.Name = "lbl_error_unknow_telegram_type";
            this.lbl_error_unknow_telegram_type.Size = new System.Drawing.Size(217, 15);
            this.lbl_error_unknow_telegram_type.TabIndex = 10;
            this.lbl_error_unknow_telegram_type.Text = "lbl_error_unknow_telegram_type";
            // 
            // tbp_record
            // 
            this.tbp_record.Controls.Add(this.groupBox3);
            this.tbp_record.Controls.Add(this.btn_JOG_Positive_Start);
            this.tbp_record.Controls.Add(this.btn_origin_return);
            this.tbp_record.Controls.Add(this.btn_JOG_Stop);
            this.tbp_record.Controls.Add(this.btn_JOG_Negative_Start);
            this.tbp_record.Controls.Add(this.btn_moveto_lefttop);
            this.tbp_record.Controls.Add(this.btn_PosingStop);
            this.tbp_record.Controls.Add(this.btn_moveto_leftbottom);
            this.tbp_record.Controls.Add(this.btn_moveto_righttop);
            this.tbp_record.Controls.Add(this.btn_moveto_rightbottom);
            this.tbp_record.Controls.Add(this.btn_general_mode);
            this.tbp_record.Location = new System.Drawing.Point(4, 23);
            this.tbp_record.Name = "tbp_record";
            this.tbp_record.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_record.Size = new System.Drawing.Size(1011, 450);
            this.tbp_record.TabIndex = 7;
            this.tbp_record.Text = "Record";
            this.tbp_record.UseVisualStyleBackColor = true;
            // 
            // btn_moveto_lefttop
            // 
            this.btn_moveto_lefttop.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_lefttop.Location = new System.Drawing.Point(607, 25);
            this.btn_moveto_lefttop.Name = "btn_moveto_lefttop";
            this.btn_moveto_lefttop.Size = new System.Drawing.Size(48, 40);
            this.btn_moveto_lefttop.TabIndex = 151;
            this.btn_moveto_lefttop.Text = "移至左上";
            this.btn_moveto_lefttop.UseVisualStyleBackColor = true;
            this.btn_moveto_lefttop.Click += new System.EventHandler(this.btn_moveto_lefttop_Click);
            // 
            // btn_moveto_leftbottom
            // 
            this.btn_moveto_leftbottom.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_leftbottom.Location = new System.Drawing.Point(607, 72);
            this.btn_moveto_leftbottom.Name = "btn_moveto_leftbottom";
            this.btn_moveto_leftbottom.Size = new System.Drawing.Size(48, 40);
            this.btn_moveto_leftbottom.TabIndex = 150;
            this.btn_moveto_leftbottom.Text = "移至左下";
            this.btn_moveto_leftbottom.UseVisualStyleBackColor = true;
            this.btn_moveto_leftbottom.Click += new System.EventHandler(this.btn_moveto_leftbottom_Click);
            // 
            // btn_moveto_righttop
            // 
            this.btn_moveto_righttop.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_righttop.Location = new System.Drawing.Point(666, 26);
            this.btn_moveto_righttop.Name = "btn_moveto_righttop";
            this.btn_moveto_righttop.Size = new System.Drawing.Size(48, 40);
            this.btn_moveto_righttop.TabIndex = 153;
            this.btn_moveto_righttop.Text = "移至右上";
            this.btn_moveto_righttop.UseVisualStyleBackColor = true;
            this.btn_moveto_righttop.Click += new System.EventHandler(this.btn_moveto_righttop_Click);
            // 
            // btn_moveto_rightbottom
            // 
            this.btn_moveto_rightbottom.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_rightbottom.Location = new System.Drawing.Point(666, 71);
            this.btn_moveto_rightbottom.Name = "btn_moveto_rightbottom";
            this.btn_moveto_rightbottom.Size = new System.Drawing.Size(48, 41);
            this.btn_moveto_rightbottom.TabIndex = 152;
            this.btn_moveto_rightbottom.Text = "移至右下";
            this.btn_moveto_rightbottom.UseVisualStyleBackColor = true;
            this.btn_moveto_rightbottom.Click += new System.EventHandler(this.btn_moveto_rightbottom_Click);
            // 
            // cb_SelectMeasureDistance
            // 
            this.cb_SelectMeasureDistance.FormattingEnabled = true;
            this.cb_SelectMeasureDistance.Items.AddRange(new object[] {
            "100um",
            "200um",
            "500um",
            "1mm",
            "2mm",
            "5mm",
            "1cm",
            "2cm",
            "5cm"});
            this.cb_SelectMeasureDistance.Location = new System.Drawing.Point(358, 47);
            this.cb_SelectMeasureDistance.Name = "cb_SelectMeasureDistance";
            this.cb_SelectMeasureDistance.Size = new System.Drawing.Size(79, 21);
            this.cb_SelectMeasureDistance.TabIndex = 121;
            this.cb_SelectMeasureDistance.SelectedIndexChanged += new System.EventHandler(this.cb_SelectMeasureDistance_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label35.Location = new System.Drawing.Point(354, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 21);
            this.label35.TabIndex = 122;
            this.label35.Text = "掃描距離";
            // 
            // btn_moveto_WaferCenter_point
            // 
            this.btn_moveto_WaferCenter_point.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_WaferCenter_point.Location = new System.Drawing.Point(114, 16);
            this.btn_moveto_WaferCenter_point.Name = "btn_moveto_WaferCenter_point";
            this.btn_moveto_WaferCenter_point.Size = new System.Drawing.Size(95, 61);
            this.btn_moveto_WaferCenter_point.TabIndex = 124;
            this.btn_moveto_WaferCenter_point.Text = "移至中心";
            this.btn_moveto_WaferCenter_point.UseVisualStyleBackColor = true;
            this.btn_moveto_WaferCenter_point.Click += new System.EventHandler(this.btn_moveto_WaferCenter_point_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_die_count);
            this.groupBox6.Controls.Add(this.btn_movedie_rightbottom);
            this.groupBox6.Controls.Add(this.btn_movedie_righttop);
            this.groupBox6.Controls.Add(this.btn_movedie_leftbottom);
            this.groupBox6.Controls.Add(this.btn_movedie_lefttop);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.btn_movedie_xnegative);
            this.groupBox6.Controls.Add(this.btn_movedie_ynegative);
            this.groupBox6.Controls.Add(this.btn_movedie_xpositive);
            this.groupBox6.Controls.Add(this.btn_movedie_ypositive);
            this.groupBox6.Location = new System.Drawing.Point(361, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(193, 202);
            this.groupBox6.TabIndex = 143;
            this.groupBox6.TabStop = false;
            // 
            // btn_die_count
            // 
            this.btn_die_count.BackColor = System.Drawing.Color.White;
            this.btn_die_count.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_die_count.Location = new System.Drawing.Point(66, 90);
            this.btn_die_count.Name = "btn_die_count";
            this.btn_die_count.Size = new System.Drawing.Size(64, 29);
            this.btn_die_count.TabIndex = 163;
            this.btn_die_count.Text = "0";
            this.btn_die_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_die_count.UseVisualStyleBackColor = false;
            this.btn_die_count.Click += new System.EventHandler(this.btn_die_count_Click);
            // 
            // btn_movedie_rightbottom
            // 
            this.btn_movedie_rightbottom.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movedie_rightbottom.Image = global::Velociraptor.Properties.Resources.rightdown;
            this.btn_movedie_rightbottom.Location = new System.Drawing.Point(136, 146);
            this.btn_movedie_rightbottom.Name = "btn_movedie_rightbottom";
            this.btn_movedie_rightbottom.Size = new System.Drawing.Size(51, 53);
            this.btn_movedie_rightbottom.TabIndex = 160;
            this.btn_movedie_rightbottom.UseVisualStyleBackColor = true;
            this.btn_movedie_rightbottom.Click += new System.EventHandler(this.btn_movedie_rightbottom_Click);
            // 
            // btn_movedie_righttop
            // 
            this.btn_movedie_righttop.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movedie_righttop.Image = global::Velociraptor.Properties.Resources.rightup;
            this.btn_movedie_righttop.Location = new System.Drawing.Point(136, 11);
            this.btn_movedie_righttop.Name = "btn_movedie_righttop";
            this.btn_movedie_righttop.Size = new System.Drawing.Size(51, 47);
            this.btn_movedie_righttop.TabIndex = 159;
            this.btn_movedie_righttop.UseVisualStyleBackColor = true;
            this.btn_movedie_righttop.Click += new System.EventHandler(this.btn_movedie_righttop_Click);
            // 
            // btn_movedie_leftbottom
            // 
            this.btn_movedie_leftbottom.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movedie_leftbottom.Image = global::Velociraptor.Properties.Resources.leftdown;
            this.btn_movedie_leftbottom.Location = new System.Drawing.Point(6, 147);
            this.btn_movedie_leftbottom.Name = "btn_movedie_leftbottom";
            this.btn_movedie_leftbottom.Size = new System.Drawing.Size(53, 52);
            this.btn_movedie_leftbottom.TabIndex = 158;
            this.btn_movedie_leftbottom.UseVisualStyleBackColor = true;
            this.btn_movedie_leftbottom.Click += new System.EventHandler(this.btn_movedie_leftbottom_Click);
            // 
            // btn_movedie_lefttop
            // 
            this.btn_movedie_lefttop.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_movedie_lefttop.Image = global::Velociraptor.Properties.Resources.leftup;
            this.btn_movedie_lefttop.Location = new System.Drawing.Point(6, 11);
            this.btn_movedie_lefttop.Name = "btn_movedie_lefttop";
            this.btn_movedie_lefttop.Size = new System.Drawing.Size(50, 47);
            this.btn_movedie_lefttop.TabIndex = 157;
            this.btn_movedie_lefttop.UseVisualStyleBackColor = true;
            this.btn_movedie_lefttop.Click += new System.EventHandler(this.btn_movedie_lefttop_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label37.Location = new System.Drawing.Point(58, 122);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(81, 21);
            this.label37.TabIndex = 156;
            this.label37.Text = "die間移動";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label39.Location = new System.Drawing.Point(64, 63);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 19);
            this.label39.TabIndex = 155;
            this.label39.Text = "移動個數";
            // 
            // btn_movedie_xnegative
            // 
            this.btn_movedie_xnegative.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movedie_xnegative.Image = global::Velociraptor.Properties.Resources.left;
            this.btn_movedie_xnegative.Location = new System.Drawing.Point(6, 79);
            this.btn_movedie_xnegative.Name = "btn_movedie_xnegative";
            this.btn_movedie_xnegative.Size = new System.Drawing.Size(52, 50);
            this.btn_movedie_xnegative.TabIndex = 132;
            this.btn_movedie_xnegative.UseVisualStyleBackColor = true;
            this.btn_movedie_xnegative.Click += new System.EventHandler(this.btn_movedie_xnegative_Click);
            // 
            // btn_movedie_ynegative
            // 
            this.btn_movedie_ynegative.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_movedie_ynegative.Image = global::Velociraptor.Properties.Resources.down;
            this.btn_movedie_ynegative.Location = new System.Drawing.Point(69, 147);
            this.btn_movedie_ynegative.Name = "btn_movedie_ynegative";
            this.btn_movedie_ynegative.Size = new System.Drawing.Size(55, 52);
            this.btn_movedie_ynegative.TabIndex = 134;
            this.btn_movedie_ynegative.UseVisualStyleBackColor = true;
            this.btn_movedie_ynegative.Click += new System.EventHandler(this.btn_movedie_ynegative_Click);
            // 
            // btn_movedie_xpositive
            // 
            this.btn_movedie_xpositive.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movedie_xpositive.Image = global::Velociraptor.Properties.Resources.right;
            this.btn_movedie_xpositive.Location = new System.Drawing.Point(132, 79);
            this.btn_movedie_xpositive.Name = "btn_movedie_xpositive";
            this.btn_movedie_xpositive.Size = new System.Drawing.Size(55, 50);
            this.btn_movedie_xpositive.TabIndex = 131;
            this.btn_movedie_xpositive.UseVisualStyleBackColor = true;
            this.btn_movedie_xpositive.Click += new System.EventHandler(this.btn_movedie_xpositive_Click);
            // 
            // btn_movedie_ypositive
            // 
            this.btn_movedie_ypositive.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movedie_ypositive.Image = global::Velociraptor.Properties.Resources.up;
            this.btn_movedie_ypositive.Location = new System.Drawing.Point(69, 11);
            this.btn_movedie_ypositive.Name = "btn_movedie_ypositive";
            this.btn_movedie_ypositive.Size = new System.Drawing.Size(55, 49);
            this.btn_movedie_ypositive.TabIndex = 133;
            this.btn_movedie_ypositive.UseVisualStyleBackColor = true;
            this.btn_movedie_ypositive.Click += new System.EventHandler(this.btn_movedie_ypositive_Click);
            // 
            // lb_multi_measure_point
            // 
            this.lb_multi_measure_point.FormattingEnabled = true;
            this.lb_multi_measure_point.Location = new System.Drawing.Point(134, 17);
            this.lb_multi_measure_point.Name = "lb_multi_measure_point";
            this.lb_multi_measure_point.Size = new System.Drawing.Size(211, 147);
            this.lb_multi_measure_point.TabIndex = 144;
            // 
            // btn_add_measure_point
            // 
            this.btn_add_measure_point.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_add_measure_point.Location = new System.Drawing.Point(6, 16);
            this.btn_add_measure_point.Name = "btn_add_measure_point";
            this.btn_add_measure_point.Size = new System.Drawing.Size(122, 38);
            this.btn_add_measure_point.TabIndex = 145;
            this.btn_add_measure_point.Text = "加入測量點";
            this.btn_add_measure_point.UseVisualStyleBackColor = true;
            this.btn_add_measure_point.Click += new System.EventHandler(this.btn_add_measure_point_Click);
            // 
            // btn_moveto_select_measure_point
            // 
            this.btn_moveto_select_measure_point.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_moveto_select_measure_point.Location = new System.Drawing.Point(6, 93);
            this.btn_moveto_select_measure_point.Name = "btn_moveto_select_measure_point";
            this.btn_moveto_select_measure_point.Size = new System.Drawing.Size(122, 38);
            this.btn_moveto_select_measure_point.TabIndex = 148;
            this.btn_moveto_select_measure_point.Text = "移動至所選測量點";
            this.btn_moveto_select_measure_point.UseVisualStyleBackColor = true;
            this.btn_moveto_select_measure_point.Click += new System.EventHandler(this.btn_moveto_select_measure_point_Click);
            // 
            // btn_clear_measure_point_list
            // 
            this.btn_clear_measure_point_list.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_clear_measure_point_list.Location = new System.Drawing.Point(6, 131);
            this.btn_clear_measure_point_list.Name = "btn_clear_measure_point_list";
            this.btn_clear_measure_point_list.Size = new System.Drawing.Size(122, 38);
            this.btn_clear_measure_point_list.TabIndex = 149;
            this.btn_clear_measure_point_list.Text = "重新測量";
            this.btn_clear_measure_point_list.UseVisualStyleBackColor = true;
            this.btn_clear_measure_point_list.Click += new System.EventHandler(this.btn_clear_measure_point_list_Click);
            // 
            // gb_multi_point
            // 
            this.gb_multi_point.Controls.Add(this.btn_remove_measure_point);
            this.gb_multi_point.Controls.Add(this.lb_multi_measure_point);
            this.gb_multi_point.Controls.Add(this.btn_add_measure_point);
            this.gb_multi_point.Controls.Add(this.btn_moveto_select_measure_point);
            this.gb_multi_point.Controls.Add(this.btn_clear_measure_point_list);
            this.gb_multi_point.Location = new System.Drawing.Point(588, 37);
            this.gb_multi_point.Name = "gb_multi_point";
            this.gb_multi_point.Size = new System.Drawing.Size(352, 174);
            this.gb_multi_point.TabIndex = 154;
            this.gb_multi_point.TabStop = false;
            // 
            // btn_remove_measure_point
            // 
            this.btn_remove_measure_point.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_remove_measure_point.Location = new System.Drawing.Point(6, 55);
            this.btn_remove_measure_point.Name = "btn_remove_measure_point";
            this.btn_remove_measure_point.Size = new System.Drawing.Size(122, 38);
            this.btn_remove_measure_point.TabIndex = 156;
            this.btn_remove_measure_point.Text = "移除測量點";
            this.btn_remove_measure_point.UseVisualStyleBackColor = true;
            this.btn_remove_measure_point.Click += new System.EventHandler(this.btn_remove_measure_point_Click);
            // 
            // ck_multi_point_mea
            // 
            this.ck_multi_point_mea.AutoSize = true;
            this.ck_multi_point_mea.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ck_multi_point_mea.Location = new System.Drawing.Point(594, 14);
            this.ck_multi_point_mea.Name = "ck_multi_point_mea";
            this.ck_multi_point_mea.Size = new System.Drawing.Size(93, 25);
            this.ck_multi_point_mea.TabIndex = 155;
            this.ck_multi_point_mea.Text = "多點測量";
            this.ck_multi_point_mea.UseVisualStyleBackColor = true;
            this.ck_multi_point_mea.CheckedChanged += new System.EventHandler(this.ck_multi_point_mea_CheckedChanged);
            // 
            // btn_show_data
            // 
            this.btn_show_data.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_show_data.Location = new System.Drawing.Point(737, 16);
            this.btn_show_data.Name = "btn_show_data";
            this.btn_show_data.Size = new System.Drawing.Size(93, 61);
            this.btn_show_data.TabIndex = 156;
            this.btn_show_data.Text = "數據顯示";
            this.btn_show_data.UseVisualStyleBackColor = true;
            this.btn_show_data.Click += new System.EventHandler(this.btn_show_data_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_move_distance_z);
            this.groupBox7.Controls.Add(this.label40);
            this.groupBox7.Controls.Add(this.btn_move_distance);
            this.groupBox7.Controls.Add(this.label38);
            this.groupBox7.Controls.Add(this.btn_movex_negative);
            this.groupBox7.Controls.Add(this.btn_movex_positive);
            this.groupBox7.Controls.Add(this.btn_movey_negative);
            this.groupBox7.Controls.Add(this.btn_movey_positive);
            this.groupBox7.Controls.Add(this.btn_movez_positive);
            this.groupBox7.Controls.Add(this.btn_movez_negative);
            this.groupBox7.Location = new System.Drawing.Point(83, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(252, 202);
            this.groupBox7.TabIndex = 157;
            this.groupBox7.TabStop = false;
            // 
            // btn_move_distance_z
            // 
            this.btn_move_distance_z.BackColor = System.Drawing.Color.White;
            this.btn_move_distance_z.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance_z.Location = new System.Drawing.Point(187, 93);
            this.btn_move_distance_z.Name = "btn_move_distance_z";
            this.btn_move_distance_z.Size = new System.Drawing.Size(62, 29);
            this.btn_move_distance_z.TabIndex = 164;
            this.btn_move_distance_z.Text = "0";
            this.btn_move_distance_z.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance_z.UseVisualStyleBackColor = false;
            this.btn_move_distance_z.Click += new System.EventHandler(this.btn_move_distance_z_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label40.Location = new System.Drawing.Point(60, 67);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(69, 19);
            this.label40.TabIndex = 163;
            this.label40.Text = "移動距離";
            // 
            // btn_move_distance
            // 
            this.btn_move_distance.BackColor = System.Drawing.Color.White;
            this.btn_move_distance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move_distance.Location = new System.Drawing.Point(64, 94);
            this.btn_move_distance.Name = "btn_move_distance";
            this.btn_move_distance.Size = new System.Drawing.Size(62, 29);
            this.btn_move_distance.TabIndex = 162;
            this.btn_move_distance.Text = "0";
            this.btn_move_distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_move_distance.UseVisualStyleBackColor = false;
            this.btn_move_distance.Click += new System.EventHandler(this.btn_move_distance_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label38.Location = new System.Drawing.Point(197, 62);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 21);
            this.label38.TabIndex = 161;
            this.label38.Text = "Z方向";
            // 
            // btn_movex_negative
            // 
            this.btn_movex_negative.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movex_negative.Image = global::Velociraptor.Properties.Resources.left3;
            this.btn_movex_negative.Location = new System.Drawing.Point(4, 81);
            this.btn_movex_negative.Name = "btn_movex_negative";
            this.btn_movex_negative.Size = new System.Drawing.Size(48, 50);
            this.btn_movex_negative.TabIndex = 123;
            this.btn_movex_negative.UseVisualStyleBackColor = true;
            this.btn_movex_negative.Click += new System.EventHandler(this.btn_movex_negative_Click);
            // 
            // btn_movex_positive
            // 
            this.btn_movex_positive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movex_positive.Image = global::Velociraptor.Properties.Resources.right3;
            this.btn_movex_positive.Location = new System.Drawing.Point(132, 79);
            this.btn_movex_positive.Name = "btn_movex_positive";
            this.btn_movex_positive.Size = new System.Drawing.Size(48, 50);
            this.btn_movex_positive.TabIndex = 90;
            this.btn_movex_positive.UseVisualStyleBackColor = true;
            this.btn_movex_positive.Click += new System.EventHandler(this.btn_movex_positive_Click);
            // 
            // btn_movey_negative
            // 
            this.btn_movey_negative.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movey_negative.Image = global::Velociraptor.Properties.Resources.down3;
            this.btn_movey_negative.Location = new System.Drawing.Point(69, 149);
            this.btn_movey_negative.Name = "btn_movey_negative";
            this.btn_movey_negative.Size = new System.Drawing.Size(51, 50);
            this.btn_movey_negative.TabIndex = 126;
            this.btn_movey_negative.UseVisualStyleBackColor = true;
            this.btn_movey_negative.Click += new System.EventHandler(this.btn_movey_negative_Click);
            // 
            // btn_movey_positive
            // 
            this.btn_movey_positive.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movey_positive.Image = global::Velociraptor.Properties.Resources.up3;
            this.btn_movey_positive.Location = new System.Drawing.Point(69, 11);
            this.btn_movey_positive.Name = "btn_movey_positive";
            this.btn_movey_positive.Size = new System.Drawing.Size(51, 49);
            this.btn_movey_positive.TabIndex = 125;
            this.btn_movey_positive.UseVisualStyleBackColor = true;
            this.btn_movey_positive.Click += new System.EventHandler(this.btn_movey_positive_Click);
            // 
            // btn_movez_positive
            // 
            this.btn_movez_positive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_movez_positive.Image = global::Velociraptor.Properties.Resources.up3;
            this.btn_movez_positive.Location = new System.Drawing.Point(195, 12);
            this.btn_movez_positive.Name = "btn_movez_positive";
            this.btn_movez_positive.Size = new System.Drawing.Size(54, 48);
            this.btn_movez_positive.TabIndex = 128;
            this.btn_movez_positive.UseVisualStyleBackColor = true;
            this.btn_movez_positive.Click += new System.EventHandler(this.btn_movez_positive_Click);
            // 
            // btn_movez_negative
            // 
            this.btn_movez_negative.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movez_negative.Image = global::Velociraptor.Properties.Resources.down3;
            this.btn_movez_negative.Location = new System.Drawing.Point(195, 150);
            this.btn_movez_negative.Name = "btn_movez_negative";
            this.btn_movez_negative.Size = new System.Drawing.Size(54, 51);
            this.btn_movez_negative.TabIndex = 127;
            this.btn_movez_negative.UseVisualStyleBackColor = true;
            this.btn_movez_negative.Click += new System.EventHandler(this.btn_movez_negative_Click);
            // 
            // btn_record_wafer_center_point
            // 
            this.btn_record_wafer_center_point.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_record_wafer_center_point.Location = new System.Drawing.Point(114, 116);
            this.btn_record_wafer_center_point.Name = "btn_record_wafer_center_point";
            this.btn_record_wafer_center_point.Size = new System.Drawing.Size(98, 61);
            this.btn_record_wafer_center_point.TabIndex = 160;
            this.btn_record_wafer_center_point.Text = "中心點設定";
            this.btn_record_wafer_center_point.UseVisualStyleBackColor = true;
            this.btn_record_wafer_center_point.Click += new System.EventHandler(this.btn_record_wafer_center_point_Click);
            // 
            // btn_unload_wafer
            // 
            this.btn_unload_wafer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unload_wafer.Location = new System.Drawing.Point(5, 116);
            this.btn_unload_wafer.Name = "btn_unload_wafer";
            this.btn_unload_wafer.Size = new System.Drawing.Size(95, 61);
            this.btn_unload_wafer.TabIndex = 159;
            this.btn_unload_wafer.Text = "晶圓退出";
            this.btn_unload_wafer.UseVisualStyleBackColor = true;
            this.btn_unload_wafer.Click += new System.EventHandler(this.btn_unload_wafer_Click);
            // 
            // btn_load_wafer
            // 
            this.btn_load_wafer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load_wafer.Location = new System.Drawing.Point(6, 16);
            this.btn_load_wafer.Name = "btn_load_wafer";
            this.btn_load_wafer.Size = new System.Drawing.Size(95, 61);
            this.btn_load_wafer.TabIndex = 158;
            this.btn_load_wafer.Text = "晶圓載入";
            this.btn_load_wafer.UseVisualStyleBackColor = true;
            this.btn_load_wafer.Click += new System.EventHandler(this.btn_load_wafer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.ntb_threshold);
            this.panel1.Controls.Add(this.gb_multi_point);
            this.panel1.Controls.Add(this.label_Threshold);
            this.panel1.Controls.Add(this.btn_connection);
            this.panel1.Controls.Add(this.btn_dnld_raw_execute);
            this.panel1.Controls.Add(this.ck_multi_point_mea);
            this.panel1.Controls.Add(this.btn_dark);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.btn_ClearAlarm);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 398);
            this.panel1.TabIndex = 161;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.ntb_x_cur_pos);
            this.groupBox2.Controls.Add(this.gb_showdata);
            this.groupBox2.Controls.Add(this.btn_moveto_WaferCenter_point);
            this.groupBox2.Controls.Add(this.ntb_y_cur_pos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ntb_z_cur_pos);
            this.groupBox2.Controls.Add(this.btn_record_wafer_center_point);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label_zaxis);
            this.groupBox2.Controls.Add(this.ntb_led_intensity);
            this.groupBox2.Controls.Add(this.btn_unload_wafer);
            this.groupBox2.Controls.Add(this.btn_load_wafer);
            this.groupBox2.Controls.Add(this.label_yaxis);
            this.groupBox2.Controls.Add(this.cb_SelectMeasureDistance);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label_xaxis);
            this.groupBox2.Controls.Add(this.label_current_position);
            this.groupBox2.Controls.Add(this.btn_advanced_mode);
            this.groupBox2.Controls.Add(this.btn_show_data);
            this.groupBox2.Location = new System.Drawing.Point(3, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1019, 184);
            this.groupBox2.TabIndex = 163;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(584, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 29);
            this.button2.TabIndex = 166;
            this.button2.Text = "2000";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(585, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 29);
            this.button1.TabIndex = 165;
            this.button1.Text = "2000";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label42.Location = new System.Drawing.Point(581, 96);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(111, 21);
            this.label42.TabIndex = 164;
            this.label42.Text = "die Y方向寬度";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label41.Location = new System.Drawing.Point(580, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(112, 21);
            this.label41.TabIndex = 163;
            this.label41.Text = "die X方向長度";
            // 
            // gb_showdata
            // 
            this.gb_showdata.Controls.Add(this.rb_showdata_y);
            this.gb_showdata.Controls.Add(this.rb_showdata_x);
            this.gb_showdata.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_showdata.Location = new System.Drawing.Point(358, 94);
            this.gb_showdata.Name = "gb_showdata";
            this.gb_showdata.Size = new System.Drawing.Size(113, 77);
            this.gb_showdata.TabIndex = 162;
            this.gb_showdata.TabStop = false;
            this.gb_showdata.Text = "切割道方向";
            // 
            // rb_showdata_y
            // 
            this.rb_showdata_y.AutoSize = true;
            this.rb_showdata_y.Location = new System.Drawing.Point(12, 45);
            this.rb_showdata_y.Name = "rb_showdata_y";
            this.rb_showdata_y.Size = new System.Drawing.Size(86, 25);
            this.rb_showdata_y.TabIndex = 1;
            this.rb_showdata_y.TabStop = true;
            this.rb_showdata_y.Text = "Y軸方向";
            this.rb_showdata_y.UseVisualStyleBackColor = true;
            // 
            // rb_showdata_x
            // 
            this.rb_showdata_x.AutoSize = true;
            this.rb_showdata_x.Location = new System.Drawing.Point(12, 23);
            this.rb_showdata_x.Name = "rb_showdata_x";
            this.rb_showdata_x.Size = new System.Drawing.Size(87, 25);
            this.rb_showdata_x.TabIndex = 0;
            this.rb_showdata_x.TabStop = true;
            this.rb_showdata_x.Text = "X軸方向";
            this.rb_showdata_x.UseVisualStyleBackColor = true;
            // 
            // btn_connection
            // 
            this.btn_connection.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_connection.Image = global::Velociraptor.Properties.Resources.FUNC_DISCONNECT;
            this.btn_connection.Location = new System.Drawing.Point(1, 14);
            this.btn_connection.Name = "btn_connection";
            this.btn_connection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_connection.Size = new System.Drawing.Size(80, 79);
            this.btn_connection.TabIndex = 3;
            this.btn_connection.Text = "相機連接";
            this.btn_connection.UseVisualStyleBackColor = true;
            this.btn_connection.Click += new System.EventHandler(this.btn_connection_Click);
            // 
            // btn_dnld_raw_execute
            // 
            this.btn_dnld_raw_execute.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_dnld_raw_execute.ForeColor = System.Drawing.Color.White;
            this.btn_dnld_raw_execute.Image = global::Velociraptor.Properties.Resources.FUNC_STOP;
            this.btn_dnld_raw_execute.Location = new System.Drawing.Point(3, 124);
            this.btn_dnld_raw_execute.Name = "btn_dnld_raw_execute";
            this.btn_dnld_raw_execute.Size = new System.Drawing.Size(80, 84);
            this.btn_dnld_raw_execute.TabIndex = 52;
            this.btn_dnld_raw_execute.Text = "開始測量";
            this.btn_dnld_raw_execute.UseVisualStyleBackColor = true;
            this.btn_dnld_raw_execute.Click += new System.EventHandler(this.btn_dnld_raw_execute_Click);
            // 
            // btn_dark
            // 
            this.btn_dark.Image = global::Velociraptor.Properties.Resources.FUNC_DARK;
            this.btn_dark.Location = new System.Drawing.Point(957, 3);
            this.btn_dark.Name = "btn_dark";
            this.btn_dark.Size = new System.Drawing.Size(61, 52);
            this.btn_dark.TabIndex = 98;
            this.btn_dark.UseVisualStyleBackColor = true;
            this.btn_dark.Click += new System.EventHandler(this.btn_dark_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label43.Location = new System.Drawing.Point(655, 55);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(35, 21);
            this.label43.TabIndex = 167;
            this.label43.Text = "um";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label44.Location = new System.Drawing.Point(655, 136);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(35, 21);
            this.label44.TabIndex = 168;
            this.label44.Text = "um";
            // 
            // f_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1024, 898);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tbp_main.ResumeLayout(false);
            this.tbp_sodx.ResumeLayout(false);
            this.tbp_sodx.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tbp_status.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tbp_record.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gb_multi_point.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_showdata.ResumeLayout(false);
            this.gb_showdata.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ipaddress;
        private MagicGraphicLibrary.IPAddressControl ctrl_ip_address;
        private System.Windows.Forms.Button btn_connection;
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
        private System.Windows.Forms.Button btn_dnld_raw_execute;
        private MagicGraphicLibrary.RawImage clsRawImage;
        private System.Windows.Forms.ComboBox cbx_high_speed;
        private System.Windows.Forms.ComboBox cbx_high_speed_mode;
        private MagicGraphicLibrary.NumericTextBox ntb_dnld_number_of_channels;
        private MagicGraphicLibrary.NumericTextBox ntb_dnld_first_channel;
        private System.Windows.Forms.Button btn_origin_return;
        private System.Windows.Forms.Button btn_movex_positive;
        private System.Windows.Forms.Button btn_advanced_mode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_general_mode;
        private System.Windows.Forms.Label label_numberofchannels;
        private System.Windows.Forms.Label label_first_channel;
        private System.Windows.Forms.SaveFileDialog sfd_upload;
        private System.Windows.Forms.Button btn_dark;
        private System.Windows.Forms.Label label_xaxis;
        private System.Windows.Forms.Label label_yaxis;
        private System.Windows.Forms.Label label_zaxis;
        private System.Windows.Forms.Label label_current_position;
        private MagicGraphicLibrary.IPAddressControl ipAddressControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_PosingStop;
        internal System.Windows.Forms.Label ntb_x_cur_pos;
        internal System.Windows.Forms.Label ntb_y_cur_pos;
        internal System.Windows.Forms.Label ntb_z_cur_pos;
        private System.Windows.Forms.Button btn_JOG_Positive_Start;
        private System.Windows.Forms.Button btn_JOG_Stop;
        public MagicGraphicLibrary.NumericTextBox ntb_scale;
        private System.Windows.Forms.Button btn_ClearAlarm;
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
        private MagicGraphicLibrary.cZedGraphic ctrl_zgc_sodx;
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
        private System.Windows.Forms.Label label_Threshold;
        private System.Windows.Forms.ComboBox cb_SelectMeasureDistance;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btn_movex_negative;
        private System.Windows.Forms.Button btn_moveto_WaferCenter_point;
        private System.Windows.Forms.Button btn_movey_positive;
        private System.Windows.Forms.Button btn_movey_negative;
        private System.Windows.Forms.Button btn_movez_negative;
        private System.Windows.Forms.Button btn_movez_positive;
        private System.Windows.Forms.Button btn_movedie_ynegative;
        private System.Windows.Forms.Button btn_movedie_ypositive;
        private System.Windows.Forms.Button btn_movedie_xnegative;
        private System.Windows.Forms.Button btn_movedie_xpositive;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lb_multi_measure_point;
        private System.Windows.Forms.Button btn_add_measure_point;
        private System.Windows.Forms.Button btn_moveto_select_measure_point;
        private System.Windows.Forms.Button btn_clear_measure_point_list;
        private System.Windows.Forms.Button btn_moveto_leftbottom;
        private System.Windows.Forms.Button btn_moveto_lefttop;
        private System.Windows.Forms.Button btn_moveto_rightbottom;
        private System.Windows.Forms.Button btn_moveto_righttop;
        private System.Windows.Forms.GroupBox gb_multi_point;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.CheckBox ck_multi_point_mea;
        private System.Windows.Forms.Button btn_remove_measure_point;
        private System.Windows.Forms.Button btn_show_data;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_load_wafer;
        private System.Windows.Forms.Button btn_unload_wafer;
        private System.Windows.Forms.Button btn_record_wafer_center_point;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btn_movedie_rightbottom;
        private System.Windows.Forms.Button btn_movedie_righttop;
        private System.Windows.Forms.Button btn_movedie_leftbottom;
        private System.Windows.Forms.Button btn_movedie_lefttop;
        private System.Windows.Forms.TabPage tbp_record;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btn_die_count;
        private System.Windows.Forms.Button btn_move_distance;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox gb_showdata;
        private System.Windows.Forms.RadioButton rb_showdata_y;
        private System.Windows.Forms.RadioButton rb_showdata_x;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_move_distance_z;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
    }
}

