using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using MagicServerLibrary;
using MagicGraphicLibrary;
using MagicCommonLibrary;
using MagicAddOn;
using AddOn;
using Velociraptor.AddOn;
using Velociraptor.Form;
using HalconDotNet;
using Velociraptor.MyForm;

namespace Velociraptor
{
    //-------------------------------------------------------------------------------------------
    public partial class f_main : System.Windows.Forms.Form
    {
        #region eThreadAction
        public enum eThreadAction
        {
            /// <summary>nothing to do</summary>
            None,
            /// <summary>client connect</summary>
            eClientConnect,
            /// <summary>client disconnect</summary>
            eClientDisconnect,
            /// <summary>client settings</summary>
            eClientSettings,
            /// <summary>Start Record Data Samples.</summary>
            StartRecordDataSample,
            /// <summary>Start Record Data Samples.</summary>
            StartRecordDataSample_0,
            /// <summary>Stop Record Data Samples.</summary>
            StopRecordDataSample,
            /// <summary>Stop Record Data Samples.</summary>
            StopRecordDataSample_0,
            /// <summary>Start Move Samples Pitch 5um.</summary>
            StartMoveSamplePitch5um,
            /// <summary>Start Move Samples Pitch 1um.</summary>
            StartMoveSamplePitch1um,
            /// <summary>FifoDataSample.</summary>
            DoMultiPointSample,
            /// <summary>close application</summary>
            eCloseApplication,
        }
        #endregion
        #region enEventThreadGui
        /// <summary>List of event for thread Gui.</summary>
        public enum enEventThreadGui
        {
            /// <summary>Init Display.</summary>
            InitDisplay,
            /// <summary>Init Download Display.</summary>
            InitDownloadDisplay,
            /// <summary>Display Statistics.</summary>
            DisplayStatistics,
            /// <summary>Display Connection State.</summary>
            DisplayConnectionState,
            /// <summary>Display Command</summary>
            DisplayCommandData,
            /// <summary>Display Download Raw Spectra</summary>
            DisplayDownloadRawSpectra,
            /// <summary>Prepare High Speed.</summary>
            PrepareHighSpeed,
            /// <summary>Update High Speed.</summary>
            UpdateHighSpeed,
            /// <summary>Update High Speed Mode.</summary>
            UpdateHighSpeedMode,
            /// <summary>Display Record Panel</summary>
            DisplayRecordPanel,
            /// <summary>Update Button</summary>
            eUpdateButton,
            /// <summary>DisplayDataSample</summary>
            DisplayDataSample,

            /// <summary>Display Data Format.</summary>
            DisplayDataFormat,
            /// <summary>Display Sample Rate</summary>
            DisplaySampleRate,
            /// <summary>Display Peak Detection Filter</summary>
            DisplayPeakDetectionFilterplay,
            /// <summary>Display Error</summary>
            DisplayError,
        }
        #endregion
        #region eThreadDataSample
        /// <summary>List of event for thread Gui.</summary>
        public enum eThreadDataSample
        {
            /// <summary>Receive Data Samples Cls 0.</summary>
            DataSample,
        }
        #endregion
        #region eThreadAcquisition
        enum eThreadAcquisition
        {
            /// <summary>run acquisition</summary>
            eRun,
            /// <summary>stop acquisition</summary>
            eStop,
        }
        #endregion
        #region eThreadDisplayAcquisition
        enum eThreadDisplayAcquisition
        {
            /// <summary>run display acquisition</summary>
            eRun,
            /// <summary>pause display acquisition</summary>
            ePause,
        }
        #endregion

        #region ImageProcessing
        private HalconProc hp = new HalconProc();
        private HObject cur_img;
        private string ImageFullPath;
        #endregion

        System.Timers.Timer timer;
        double xpos = -0.1;
        double ypos = -0.1;
        int counter = 0;
        int counter_end = 0;
        double dataIntensityAverage = 0;

        #region Threads and events
        /// <summary>thread action process</summary>
        public cThreadProcess _threadActionProcess = null;
        /// <summary>thread to the display refresh</summary>
        cThreadProcess _threadGui = null;
        /// <summary>thread to the display refresh</summary>
        cThreadProcess _threadDataSample = null;
        cThreadProcess _threadAcquisitionProcess = null;
        /// <summary>_lock thread action process</summary>
        object _lockActionProcess = new object();
        /// <summary>the current thread action</summary>
        eThreadAction _threadAction = eThreadAction.None;
        List<sEventActionProcessControl> _eventActionProcessControlList = new List<sEventActionProcessControl>();
        List<cErrorEventArgs> _errorList = null;
        cClientSocket.OnClientConnectEventHandler _eventOnClientConnect = null;
        cClientSocket.OnClientDisconnectEventHandler _eventOnClientDisconnect = null;
        cClientCommunication.OnReceiveCommandDataEventHandler _eventOnUpdateCommandData = null;
        cClientCommunication.OnReceiveDataFormatEventHandler _eventOnUpdateDataFormat = null;
        cClientCommunication.OnUpdateIhmEventHandler _eventOnUpdateIhm = null;
        cClientCommunication.OnReceiveDataSampleEventHandler _eventOnUpdateDataSample = null;
        cClientCommunication.OnReceiveDataFormatEventHandler _eventOnUpdateDataFormatEntry = null;
        cErrorEventArgs.OnErrorEventHandler _eventOnError = null;
        cSelectingFilters.OnFiltersRemoveEventHandler _eventOnFiltersRemove = null;
        cSelectingFilters.OnFiltersAddEventHandler _eventOnFiltersAdd = null;
        #endregion
        #region acquisition thread
        int _dataAcquisitionNumber = 0;
        int _dataAcquisitionCounter = 0;
        eThreadAcquisition _threadAcquisition = eThreadAcquisition.eStop;
        eThreadDisplayAcquisition _threadDisplayAcquisition = eThreadDisplayAcquisition.eRun;
        #endregion
        #region cls_components
        cClientCommunication _client = null;
        /// <summary>size of rx/tx ethernet buffer</summary>
        const int _rxBufferSizeOfClientSocket = 1024 * 1024 * 32;
        const int _txBufferSizeOfClientSocket = 1024 * 1024 * 32;
        sCCDRange _ccd_range = null;
        cGeneralSettings _generalSettings = null;
        cCsvWriteFiles _ccsvWriteFiles = new cCsvWriteFiles();
        cProjectSettings _cprojectSettings = new cProjectSettings();
        sProjectSettings _sprojectSettings = new sProjectSettings();
        sAcquisition _acquisitionTab = new sAcquisition();
        cSelectingFilters _selectingFilters = null;
        cSaveFilteredData _saveFilteredData = null;
        cDisplayDataSodx _displayDataSodx = null;
        #region cursor and curve
        cCurve _curve_v1 = null;
        cCurve _curve_v2 = null;
        cCurve _curve_v3 = null;
        cRawImageCursor _cursor_raw_v1 = null;
        cRawImageCursor _cursor_raw_v2 = null;
        cRawImageCursor _cursor_raw_v3 = null;
        bool _isCursorV1IndexChange = false;
        bool _isCursorV2IndexChange = false;
        bool _isCursorH1IndexChange = false;
        #endregion
        #region Fifo
        //Command Data Fifo
        const int _maxNumberOfBufferInFifoCommandData = 64;
        cQueueExt _fifoCommandData = null;
        //Data Sample Fifo
        private const int _maxNumberOfBufferInFifoDataSample = 1024 * 16;
        private cQueueExt _fifoDataSample = null;
        object _lockFifoDataSample = new object();
        //Data Sodx Fifo
        private const int _maxNumberOfBufferInFifoDataSodx = 1024 * 8;
        private cQueueExt _fifoDataSodx = null;
        //Data Format Fifo
        private const int _maxNumberOfBufferInFifoDataFormat = 64;
        private cQueueExt _fifoDataFormat = null;
        #endregion
        #region Control Update
        cControlUpdateEx _controlUpdate = null;
        sControlUpdateEx _clu_led_intensity = null;
        sControlUpdateEx _clu_number_of_peak = null;
        sControlUpdateEx _clu_scale = null;
        sControlUpdateEx _clu_threshold = null;
        sControlUpdateEx _clu_cbx_high_speed_mode = null;
        sControlUpdateEx _clu_cbx_high_speed = null;
        cControlUpdateEx.OnEventHandler _eventControlUpdateValueToText = null;
        cControlUpdateEx.OnEventHandler _eventcontrolUpdateTextToValue = null;
        #endregion
        #region delegate function for precitec
        delegate void InitDisplayDelegateHandler(System.Windows.Forms.Form form);
        InitDisplayDelegateHandler InitDisplayDelegate;

        delegate void InitDownloadDisplayDelegateHandler(System.Windows.Forms.Form form);
        InitDownloadDisplayDelegateHandler InitDownloadDisplayDelegate;

        delegate void DisplayConnectionStateDelegateHandler(cClientCommunication client);
        DisplayConnectionStateDelegateHandler DisplayConnectionStateDelegate;

        delegate void DisplayCommandDataDelegateHandler(cClsCommandData clsCommand);
        DisplayCommandDataDelegateHandler DisplayCommandDataDelegate;

        delegate void DisplaySpectraDelegateHandler(cDnldCommand dnldCommand);
        DisplaySpectraDelegateHandler DisplayRawSpectraDelegate;

        delegate void DisplayDataSampleDelegateHandler(cDataSample dataSample);
        DisplayDataSampleDelegateHandler DisplayDataSampleDelegate;

        delegate void DisplayDataFormatDelegateHandler(cClientCommunication client);
        DisplayDataFormatDelegateHandler DisplayDataFormatDelegate;

        delegate void DisplayStatisticsDelegateHandler(List<cClientStatistics> clientStatisticsList);
        DisplayStatisticsDelegateHandler DisplayStatisticsDelegate;

        delegate void DisplaySodxAcquisitionDelegateHandler(System.Windows.Forms.Form form);
        DisplaySodxAcquisitionDelegateHandler DisplaySodxAcquisitionDelegate;

        delegate void CloseFormDelegate(object sender, EventArgs e);
        CloseFormDelegate _eventCloseForm;
        #endregion
        #endregion

        PasswordEngineer psengineerForm = new PasswordEngineer();
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件

        private int _measure_distance;
        private int _start_measure_pos;
        private bool is_advanced_mode = false;
        private Motions _motion = new Motions();
        private MeasureParamReader measureParamReader;
        private SynOperation _syn_op;

        #region wafer info
        private string _wafer_id;
        private int _notch_idx;
        private int _die_row_count = 0;
        private int _die_col_count = 0;
        private int[] _mea_pts_rows;
        private int[] _mea_pts_cols;
        private int[] _mea_pos_x;
        private int[] _mea_pos_y;
        //die_side (um) 0:x邊長, 1:y邊長, 2:切割道寬度
        private double[] die_side = new double[3];
        int[] _center_pos = new int[3];
        #endregion
        #region 主程式開關
        #region Constructor
        public f_main()
        {
            InitializeComponent();

            f_splash splash = new f_splash();
            splash.ShowDialog();
            splash.Dispose();
            splash = null;
            _generalSettings = new cGeneralSettings(null, null);
            _generalSettings.Load();

            #region Settings
            _cprojectSettings.FileNameSettings = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ProjectSettings");
            _cprojectSettings.Load();
            #endregion

            measureParamReader = new MeasureParamReader(Constants.paraFilename);
            if (!Directory.Exists(measureParamReader.SavingPath))
                Directory.CreateDirectory(measureParamReader.SavingPath);

            #region Fifo
            //Fifo Data Format
            _fifoCommandData = new cQueueExt(_maxNumberOfBufferInFifoCommandData);
            _fifoCommandData.IdName = "Sample Command";
            _fifoCommandData.OnError += _eventOnError;
            //Fifo Data Sample
            _fifoDataSample = new cQueueExt(_maxNumberOfBufferInFifoDataSample);
            _fifoDataSample.IdName = "Fifo Data Sample";
            _fifoDataSample.OnError += _eventOnError;
            //Fifo Data Format
            _fifoDataFormat = new cQueueExt(_maxNumberOfBufferInFifoDataFormat);
            _fifoDataFormat.IdName = "Sample Data Format";
            _fifoDataFormat.OnError += _eventOnError;
            //Fifo Data Sodx       
            _fifoDataSodx = new cQueueExt(_maxNumberOfBufferInFifoDataSodx);
            _fifoDataSodx.IdName = "Sample Data Sodx";
            _fifoDataSodx.OnError += _eventOnError;
            #endregion

            _errorList = new List<cErrorEventArgs>();
            _selectingFilters = new cSelectingFilters();
            _selectingFilters.OnFiltersAdd += _eventOnFiltersAdd;
            _selectingFilters.OnFiltersRemove += _eventOnFiltersRemove;
            _saveFilteredData = new cSaveFilteredData(_selectingFilters);


            InitDisplayDelegate = new InitDisplayDelegateHandler(OnInitDisplay);
            InitDownloadDisplayDelegate = new InitDownloadDisplayDelegateHandler(_OnUpdateInitDownloadDisplay);

            DisplayConnectionStateDelegate = new DisplayConnectionStateDelegateHandler(DisplayClientConnectionState);
            DisplayCommandDataDelegate = new DisplayCommandDataDelegateHandler(DisplayCommandData);
            DisplayRawSpectraDelegate = new DisplaySpectraDelegateHandler(UpdateDisplayRawSpectraDelegate);
            DisplayDataSampleDelegate = new DisplayDataSampleDelegateHandler(DisplayDataSample);
            DisplayStatisticsDelegate = new DisplayStatisticsDelegateHandler(DisplayStatistics);
            DisplayDataFormatDelegate = new DisplayDataFormatDelegateHandler(DisplayDataFormat);
            DisplaySodxAcquisitionDelegate = new DisplaySodxAcquisitionDelegateHandler(DisplaySodxAcquisition);
            _eventOnClientConnect = new cClientSocket.OnClientConnectEventHandler(OnClientConnect);
            _eventOnClientDisconnect = new cClientSocket.OnClientDisconnectEventHandler(OnClientDisconnect);
            _eventOnUpdateCommandData = new cClientCommunication.OnReceiveCommandDataEventHandler(OnUpdateCommandData);
            _eventOnUpdateDataFormat = new cClientCommunication.OnReceiveDataFormatEventHandler(OnUpdateDataFormat);
            _eventOnUpdateIhm = new cClientCommunication.OnUpdateIhmEventHandler(OnUpdateIhm);
            _eventOnUpdateDataSample = new cClientCommunication.OnReceiveDataSampleEventHandler(OnUpdateDataSample);
            _eventOnUpdateDataFormatEntry = new cClientCommunication.OnReceiveDataFormatEventHandler(_OnUpdateDataFormatEntry);
            _eventOnError = new cErrorEventArgs.OnErrorEventHandler(_OnError);
            _eventOnFiltersRemove = new cSelectingFilters.OnFiltersRemoveEventHandler(_OnFiltersRemove);
            _eventOnFiltersAdd = new cSelectingFilters.OnFiltersAddEventHandler(_OnFiltersAdd);
            _eventCloseForm = new CloseFormDelegate(_OnCloseOnStart);
            //CCD Range
            _ccd_range = new sCCDRange(0, 0);

            cb_SelectMeasureDistance.SelectedIndex = 3;

            _syn_op = new SynOperation(_motion, hp);
        }
        #endregion
        #region CloseOnStart
        private void _OnCloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Load
        private void f_main_Load(object sender, EventArgs e)
        {
            Text = string.Format("Velociraptor Version : {0}", Assembly.GetExecutingAssembly().GetName().Version);
            clsRawImage.OnValueCursorChange += new RawImage.OnValueCursorChangeEventHandler(ctrl_display_OnValueCursorChange);

            #region sets the client parameter
            _client = new cClientCommunication(_rxBufferSizeOfClientSocket, _txBufferSizeOfClientSocket);
            _client.Initialize(null, null);
            _client.HighSpeedBase = _generalSettings.HighSpeedBase;
            _client.SensorsBase = _generalSettings.SensorsBase;
            _client.OpticalProbesBase = _generalSettings.OpticalProbesBase;
            _client.OnClientConnect += _eventOnClientConnect;
            _client.OnClientDisconnect += _eventOnClientDisconnect;
            _client.OnReceiveCommandData += _eventOnUpdateCommandData;
            _client.OnReceiveDataFormat += _eventOnUpdateDataFormat;
            _client.OnReceiveDataSample += _eventOnUpdateDataSample;
            _client.OnUpdateIhm += _eventOnUpdateIhm;
            _client.PortNumber = 7891;
            _client.TimeoutConnection = 500;
            _client.IP = IPAddress.Parse(_generalSettings.General.IpAddress);

            _client.OnError += _eventOnError;
            _client.Dark();

            ctrl_ip_address.Text = _generalSettings.General.IpAddress;
            #endregion

            #region start thread
            //start process thread 
            _threadActionProcess = new cThreadProcess(Enum.GetValues(typeof(eThreadAction)).Length);
            _threadActionProcess.StartThread(new ThreadStart(ThreadLoop));
            //start display thread 
            _threadGui = new cThreadProcess(Enum.GetValues(typeof(enEventThreadGui)).Length);
            _threadGui.StartThread(new ThreadStart(ThreadGuiLoop));
            //start display thread 
            _threadDataSample = new cThreadProcess(Enum.GetValues(typeof(eThreadDataSample)).Length);
            _threadDataSample.StartThread(new ThreadStart(ThreadDataSample_0));
            //start acquisition thread            
            _threadAcquisitionProcess = new cThreadProcess(Enum.GetValues(typeof(eThreadAcquisition)).Length);
            _threadAcquisitionProcess.StartThread(new ThreadStart(ThreadAcquisitionLoop));
            _threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eStop].Set();

            _threadGui.EventUserList[(int)enEventThreadGui.InitDisplay].Set();
            _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();
            _threadGui.EventUserList[(int)enEventThreadGui.PrepareHighSpeed].Set();

            #endregion
            Text = string.Format("Sample 2 Version : {0}", Assembly.GetExecutingAssembly().GetName().Version);

            #region Tool Tips
            ToolTip tips = new ToolTip();

            // Set up the delays for the ToolTip.
            tips.AutoPopDelay = 5000;
            tips.InitialDelay = 1000;
            tips.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tips.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            tips.SetToolTip(this.btn_advanced_mode, "工程模式切換");
            tips.SetToolTip(this.btn_ClearAlarm, "運動報警重置");
            tips.SetToolTip(this.btn_align, "晶圓轉正");
            tips.SetToolTip(this.btn_start_mea, "開始測量");
            tips.SetToolTip(this.btn_save, "儲存");
            tips.SetToolTip(this.btn_load, "開啟影像");
            tips.SetToolTip(this.btn_find_angle, "找角度");
            grp_manual_buttons.Visible = false;
            #endregion

            ConnectMeasure();
            GeneralMode(null, null);
            Control.CheckForIllegalCrossThreadCalls = false;
            if (!_motion.Init(Constants.paraFilename))
            {
                MessageBox.Show(_motion.GetErrorMsg());
                _threadActionProcess.EventUserList[(int)eThreadAction.eCloseApplication].Set();
                this.Close();
                //Application.Exit();
                return;
            }

            #region halcon window control init
            hp.SetHWindow(hWindowControl1);
            hp.WinSize = hWindowControl1.Size;
            string backgroud = "../../Images/background.jpg";
            if (File.Exists(backgroud))
                cur_img = hp.LoadImage(backgroud);
            #endregion

            _motion.GetCenterPos(ref _center_pos);
        }
        #endregion
        #region Form Closing
        private void f_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Settings
            _cprojectSettings.Save();
            _cprojectSettings.Project.Dispose();
            if (_client!=null)
                _generalSettings.General.SodxCommand = _client.SelectOutputFormat;
            _generalSettings.SaveSettings();
            #endregion
            #region _client
            if (_client != null)
            {
                _client.OnReceiveCommandData -= _eventOnUpdateCommandData;
                _client.OnReceiveDataFormat -= _eventOnUpdateDataFormat;
                _client.OnReceiveDataSample -= _eventOnUpdateDataSample;
                _client.OnError -= _eventOnError;
                _client.OnUpdateIhm -= _eventOnUpdateIhm;
                _client.OnClientConnect -= _eventOnClientConnect;
                _client.OnClientDisconnect -= _eventOnClientDisconnect;
                _client.Dispose();
                _client = null;
            }
            #endregion
            #region _threadDataSample
            if (_threadDataSample != null)
            {
                if (_threadDataSample != null)
                {
                    _threadDataSample.StopThread(50);
                    _threadDataSample.Dispose();
                    _threadDataSample = null;
                }
                _threadDataSample = null;
            }
            #endregion
            _motion.MotorOff();
            if (_displayDataSodx != null)
                _displayDataSodx.Dispose();
            #region _fifoCommandData
            if (_fifoCommandData != null)
            {
                _fifoCommandData.OnError -= _eventOnError;
                _fifoCommandData.Dispose();
                _fifoCommandData = null;
            }
            #endregion
            #region _fifoDataFormat
            if (_fifoDataFormat != null)
            {
                _fifoDataFormat.OnError -= _eventOnError;
                _fifoDataFormat.Dispose();
                _fifoDataFormat = null;
            }
            #endregion
            #region _fifoDataSample
            if (_fifoDataSample != null)
            {
                _fifoDataSample.OnError -= _eventOnError;
                _fifoDataSample.Dispose();
                _fifoDataSample = null;
            }
            #endregion
            _threadActionProcess.EventUserList[(int)eThreadAction.eCloseApplication].Set();
            if (_controlUpdate != null) _controlUpdate.Dispose();
        }
        #endregion
        #endregion

        #region 主thread
        #region ThreadGuiLoop
        /// <summary>This method is called when starting the thread.</summary> 
        public void ThreadGuiLoop()
        {
            cClsCommandData clsCommandData = null;
            cTimeMeasurement _tm = new cTimeMeasurement(cTimeMeasurement.enTimeStepType.MILLISECOND, false);
            cDataFormat dataFormat = null;
            cDataSample dataSample = null;
            double dTimeout = _tm.FlashTiming;
            short[,] sBuffer = null;
            int _timoutStatistics = 250, _timoutStatisticsValue = 0; //Display Statistics step 250 mms
            int _timoutDataSample = 1, _timoutDataSampleValue = 0;

            while (!_threadGui.EventExitProcessThread.WaitOne(10))
            {
                //Debug.WriteLine("ThreadGuiLoop");
                dTimeout = _tm.FlashTiming;
                _timoutStatisticsValue += (int)dTimeout;
                _timoutDataSampleValue += (int)dTimeout;

                #region DisplayRecordPanel
                if (_threadGui.EventUserList[(int)enEventThreadGui.DisplayRecordPanel].WaitOne(0))
                {
                    Invoke((Action)(() =>
                    {
                        bool enabled = ((_cprojectSettings != null) && (_cprojectSettings.Project != null) && (_cprojectSettings.Project.Recording == false));

                    }));
                }
                #endregion
                #region InitDisplay
                if (_threadGui.EventUserList[(int)enEventThreadGui.InitDisplay].WaitOne(0))
                {
                    this.Invoke(this.InitDisplayDelegate, new object[] { this });
                    _threadGui.EventUserList[(int)enEventThreadGui.PrepareHighSpeed].Set();
                }
                #endregion
                #region PrepareHighSpeed
                if (_threadGui.EventUserList[(int)enEventThreadGui.PrepareHighSpeed].WaitOne(0))
                {
                    this.Invoke(new cIhmHighSpeed.PrepareHighSpeedDelegateHandler(cIhmHighSpeed.PrepareHighSpeed), _client, _generalSettings, _clu_cbx_high_speed_mode, _clu_cbx_high_speed);
                }
                #endregion
                #region UpdateHighSpeed
                if (_threadGui.EventUserList[(int)enEventThreadGui.UpdateHighSpeed].WaitOne(0))
                {
                    this.Invoke(new cIhmHighSpeed.UpdateHighSpeedDelegateHandler(cIhmHighSpeed.UpdateHighSpeed), _client, _generalSettings, _clu_cbx_high_speed_mode, _clu_cbx_high_speed);
                }
                #endregion
                #region UpdateHighSpeedMode
                if (_threadGui.EventUserList[(int)enEventThreadGui.UpdateHighSpeedMode].WaitOne(0))
                {
                    this.Invoke(new cIhmHighSpeed.UpdateHighSpeedModeDelegateHandler(cIhmHighSpeed.UpdateHighSpeedMode), _client, _generalSettings, _clu_cbx_high_speed_mode, _clu_cbx_high_speed);
                }
                #endregion
                #region Display Download Display
                if (_threadGui.EventUserList[(int)enEventThreadGui.InitDownloadDisplay].WaitOne(0))
                {
                    this.Invoke(this.InitDownloadDisplayDelegate, new object[] { this });
                    _curve_v2.IsVisible = _cursor_raw_v2.Visible = false;
                    _curve_v3.IsVisible = _cursor_raw_v3.Visible = false;

                }
                #endregion
                #region Display Client Connection
                if (_threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].WaitOne(0))
                {
                    this.Invoke(this.DisplayConnectionStateDelegate, new object[] { _client });
                }
                #endregion
                #region Dislpay Statistics
                if (_threadGui.EventUserList[(int)enEventThreadGui.DisplayStatistics].WaitOne(0))
                {
                    this.Invoke(this.DisplayStatisticsDelegate, new object[] { _client.ClientStatisticsList });
                }
                #endregion
                #region Dislpay Command Data
                if ((_timoutStatisticsValue > _timoutStatistics) && (_client != null) && (_client.ClientIsConnected) && (_threadGui.EventUserList[(int)enEventThreadGui.DisplayCommandData].WaitOne(0)))
                {
                    _timoutStatisticsValue = 0;
                    if (_fifoCommandData != null)
                    {
                        lock (_fifoCommandData)
                        {
                            while (_fifoCommandData.Count > 0)
                            {
                                clsCommandData = (cClsCommandData)_fifoCommandData.Dequeue();
                                this.Invoke(this.DisplayCommandDataDelegate, new object[] { clsCommandData });
                            }
                        }
                    }
                }
                #endregion
                #region Display Download Raw Spectra
                if (_threadGui.EventUserList[(int)enEventThreadGui.DisplayDownloadRawSpectra].WaitOne(0))
                {
                    if ((_client != null) && (_client.DnldCommand != null))
                    {
                        sDnldCommandState dnldCommandState = _client.DnldCommand.StateDownloadRaw;
                        sBuffer = _client.DnldCommand.DataRawSpectra;

                        if (sBuffer != null)
                        {
                            sSpectraRaw spectra = new sSpectraRaw(_client.DnldCommand.SpectrumRaw, sBuffer, _client.FibersParameters);
                            clsRawImage.Data = spectra.Data;
                            this.Invoke(this.DisplayRawSpectraDelegate, new object[] { _client.DnldCommand });
                        }
                    }
                }
                #endregion
                #region Display Data Sample
                //Display Data Sample
                if ((_timoutDataSampleValue > _timoutDataSample) && (_client != null) && (_client.ClientIsConnected) && (_threadGui.EventUserList[(int)enEventThreadGui.DisplayDataSample].WaitOne(0)))
                {
                    _timoutDataSampleValue = 0;
                    if (_fifoDataSample != null)
                    {
                        lock (_fifoDataSample)
                        {
                            while (_fifoDataSample.Count > 0)
                            {
                                dataSample = (cDataSample)_fifoDataSample.Dequeue();    //Display Data Sample
                                if (dataSample != null)
                                {
                                    if ((_threadAcquisition == eThreadAcquisition.eRun) && ((_dataAcquisitionNumber == -1) || (_dataAcquisitionNumber > 0)))
                                    {
                                        _dataAcquisitionCounter += 1;
                                        foreach (sSignalData signalData in dataSample.SignalDataList)
                                        {
                                            if ((_selectingFilters != null) && (_selectingFilters.IsSelected(signalData) != null))
                                            {
                                                lock (_fifoDataSodx)
                                                {
                                                    _fifoDataSodx.Enqueue(signalData);
                                                }
                                            }
                                        }
                                        if (_dataAcquisitionNumber > 0)
                                        {
                                            _dataAcquisitionNumber -= 1;
                                            if (_dataAcquisitionNumber == 0)
                                            {
                                                _threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eStop].Set();
                                            }
                                        }
                                    }
                                }
                                if (_fifoDataSample.IsEmpty)
                                {
                                    this.Invoke(this.DisplayDataSampleDelegate, new object[] { dataSample });
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Display Data Format
                if ((_client != null) && (_client.ClientIsConnected) && (_threadGui.EventUserList[(int)enEventThreadGui.DisplayDataFormat].WaitOne(0)))
                {
                    if (_fifoDataFormat != null)
                    {
                        lock (_fifoDataFormat)
                        {
                            while (_fifoDataFormat.Count > 0)
                            {
                                dataFormat = (cDataFormat)_fifoDataFormat.Dequeue();
                                this.Invoke(this.DisplayDataFormatDelegate, new object[] { _client });
                            }
                        }
                    }
                }
                #endregion
                #region Display Error
                if (_threadGui.EventUserList[(int)enEventThreadGui.DisplayError].WaitOne(0))
                {
                    this.Invoke(new cClientIhm.UpdateDisplayErrorDelegateHandler(cClientIhm.FuncUpdateDisplayErrorDelegateHandler), lst_log, _errorList);
                }
                #endregion
            }
            _threadGui.EventExitProcessThreadDo.Set();
        }
        #endregion     
        #region ThreadLoop
        /// <summary>This method is called when starting the thread.</summary>
        private void ThreadLoop()
        {
            cTimeout timeout = new cTimeout(true, cTimeMeasurement.enTimeStepType.MILLISECOND);
            int timeoutValue = 10;
            timeout.TimeoutValue = 200; //200ms.
            try
            {
                while (_threadActionProcess.EventExitProcessThread.WaitOne(timeoutValue) == false)
                {
                    //Debug.WriteLine("ThreadLoop");

                    #region Close App; Stop threads
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.eCloseApplication].WaitOne(0))
                    {
                        if (_threadDataSample != null)
                        {
                            _threadActionProcess.StopThread(50);
                            _threadActionProcess.Dispose();
                            _threadActionProcess = null;
                        }
                        if (_threadGui != null)
                        {
                            _threadGui.StopThread(50);
                            _threadGui.Dispose();
                            _threadGui = null;
                        }
                        if (_threadAcquisitionProcess != null)
                        {
                            _threadAcquisitionProcess.StopThread(50);
                            _threadAcquisitionProcess.Dispose();
                            _threadAcquisitionProcess = null;
                        }
                        _threadActionProcess.EventExitProcessThread.Set();
                        continue;
                    }
                    #endregion
                    #region Connect/Disconnect
                    if (_client != null)
                    {
                        //calculate statistics Timeout                    
                        if (timeout.IsTimeout() 
                            && ((_threadActionProcess.EventUserList[(int)eThreadAction.eClientConnect].WaitOne(0)) 
                                || (_threadActionProcess.EventUserList[(int)eThreadAction.eClientDisconnect].WaitOne(0))))
                        {
                            //GC.Collect();
                            switch (_threadAction)
                            {
                                //client connect
                                case eThreadAction.eClientConnect:
                                    if (_client.Open())
                                    {
                                        _threadAction = eThreadAction.None;
                                        sVersion version = _client.Version;
                                        _saveFilteredData.SaturationLevelIntensity = _client.SaturationLevelIntensity;
                                        _generalSettings.General.Sensor.NumberOfFibers = _client.FibersParameters.NumberOfFibersUsed;
                                        _generalSettings.General.SodxCommand.Signal.AltitudePeak1 = true;
                                        _generalSettings.General.SodxCommand.Signal.IntensityLevelPeak1 = true;
                                        _generalSettings.General.SodxCommand.Signal.IntensityRawPeak1 = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.SampleCounter = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.StartPositionX = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.StartPositionY = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.StartPositionZ = true;
                                        _client.SelectOutputFormat = _generalSettings.General.SodxCommand;
                                        _client.TriggerStop();
                                        _threadGui.EventUserList[(int)enEventThreadGui.PrepareHighSpeed].Set();
                                    }
                                    else
                                    {
                                        _threadAction = eThreadAction.eClientDisconnect;
                                        _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();
                                    }
                                    if ((_client != null) && (_client.DnldCommand != null))
                                    {
                                        if (_client.DnldCommand.IsBusyDownloadRaw)
                                        {
                                            _client.DnldCommand.StopDownloadRaw();
                                        }
                                        else
                                        {
                                            UInt32 ivalue = 0;
                                            sSpectrumRaw spectrumRaw = new sSpectrumRaw();
                                            if (UInt32.TryParse(ntb_dnld_first_channel.Text, out ivalue))
                                            {
                                                spectrumRaw.FirstChannel = ivalue;
                                                if (UInt32.TryParse(ntb_dnld_number_of_channels.Text, out ivalue))
                                                {
                                                    spectrumRaw.NumberOfChannels = ivalue;
                                                    spectrumRaw.SpectraId = (uint)eSpectraId.SpectraIdRawSpectrum;
                                                    _client.DnldCommand.StartDownloadRaw(spectrumRaw, -1);
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case eThreadAction.eClientDisconnect:
                                    _client.Close();
                                    _threadAction = eThreadAction.None;
                                    MessageBox.Show("量測用相機連線失敗");
                                    break;
                            }
                            if (_threadGui != null)
                            {
                                if (is_advanced_mode)
                                {
                                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayStatistics].Set();
                                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayDataSample].Set();
                                }
                            }
                        }
                    }
                    #endregion
                    #region StartRecordDataSample
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StartRecordDataSample].WaitOne(0))
                    {
                        if ((_cprojectSettings != null) && (_cprojectSettings.Project != null))
                        {
                            #region Recording = true
                            _cprojectSettings.Project.Recording = true;
                            #endregion
                            _threadActionProcess.EventUserList[(int)eThreadAction.StartRecordDataSample_0].Set();
                        }
                    }
                    #endregion
                    #region StartRecordDataSample_0
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StartRecordDataSample_0].WaitOne(0))
                    {
                        _client.TriggerStop();
                        if ((_cprojectSettings != null) && (_cprojectSettings.Project != null))
                        {

                            _cprojectSettings.Project.NumberOfSamples = -1;
                            _start_measure_pos = int.Parse(ntb_x_cur_pos.Text);
                            _acquisitionTab.StartMeasureXPos = int.Parse(ntb_x_cur_pos.Text);
                            _acquisitionTab.StartMeasureYPos = int.Parse(ntb_y_cur_pos.Text);
                            _acquisitionTab.StartMeasureZPos = int.Parse(ntb_z_cur_pos.Text);
                            #region set triggerParameter
                            UInt32[] Re_LongData = new UInt32[3];   // L size register data storage variable
                            _client.SetEncoderCounters(eEncoderId.Encoder_X, eEncoderFunc.SetPositionImmediately, Re_LongData[0]);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EnableTriggerDuringReturnMovement, measureParamReader.EnableTriggerDuringReturnMovement);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.ChooseAxis, measureParamReader.ChooseAxis);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EndlessRountripTrigger, measureParamReader.EndlessRountripTrigger);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStopPosition, _start_measure_pos + _measure_distance);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetTriggerInterval, measureParamReader.SetTriggerInterval);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStartPosition, _start_measure_pos);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SelectEncoderTriggerSource, measureParamReader.SelectEncoderTriggerSource);
                            #endregion

                            #region Clear Fifo
                            if (_fifoDataSample != null)
                            {
                                lock (_fifoDataSample)
                                {
                                    _fifoDataSample.Clear();         //開始測量前清空
                                }
                            }
                            #endregion
                            if (_motion.ScanMode() == 0)
                            {                               
                                _threadActionProcess.EventUserList[(int)eThreadAction.StartMoveSamplePitch5um].Set();
                                
                            }
                            else
                            {                              
                                _threadActionProcess.EventUserList[(int)eThreadAction.StartMoveSamplePitch1um].Set();
                                
                            }
                            _acquisitionTab.Recording = true;
                            
                        }
                    }
                    #endregion
                    #region StopRecordDataSample
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StopRecordDataSample].WaitOne(0))
                    {
                        if ((_cprojectSettings != null) && (_cprojectSettings.Project != null) /*&& (_cprojectSettings.Project.Recording == false)*/)
                        {
                            
                            _threadActionProcess.EventUserList[(int)eThreadAction.StopRecordDataSample_0].Set();

                        }
                    }
                    #endregion
                    #region StopRecordDataSample_0
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StopRecordDataSample_0].WaitOne(0))
                    {
                        if ((_cprojectSettings != null) && (_cprojectSettings.Project != null))
                        {
                            #region Stop Trigger
                            if ((_client.ClientIsConnected) && (_client.ClientIsConfigured))
                            {
                                _client.TriggerStop();
                            }
                            #endregion
                            #region Close Files
                            if (_ccsvWriteFiles != null)
                            {
                                _ccsvWriteFiles.Close();
                                _ccsvWriteFiles.Dispose();
                                _ccsvWriteFiles = null;
                            }
                            #endregion
                        }
                    }
                    #endregion
                    #region StartMoveSamplePitch5um
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StartMoveSamplePitch5um].WaitOne(0))
                    {
                        if (!_motion.Move5um(_measure_distance))
                        {
                            MessageBox.Show(_motion.GetErrorMsg());
                            return;
                        }
                    }
                    #endregion
                    #region StartMoveSamplePitch1um
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StartMoveSamplePitch1um].WaitOne(0))
                    {
                        if (!_motion.Move1um(Constants.AutoMeasureDistance))
                        {
                            MessageBox.Show(_motion.GetErrorMsg());
                            return;
                        }
                    }
                    #endregion
                }
                _threadActionProcess.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this._eventCloseForm?.Invoke(null, null);
            }
        }
        #endregion
        #region ThreadDataSample_0
        /// <summary>This method is called when starting the thread.</summary> 
        public void ThreadDataSample_0()
        {
            while (!_threadDataSample.EventExitProcessThread.WaitOne(0))
            {
                //Debug.WriteLine("ThreadDataSample_0");

                #region DataSample_0
                if (_threadDataSample.EventUserList[(int)eThreadDataSample.DataSample].WaitOne(0))  
                {              
                    if (_fifoDataSample != null)
                    {
                        lock (_fifoDataSample)
                        {
                            while (_fifoDataSample.Count > 0)
                            {                            
                                cDataSample clsDataSample = (cDataSample)_fifoDataSample.Dequeue();     //把_fifoDataSample中的資料取出來到clsDataSample
                                clsDataSample.SignalDataList[0].DataType = eDataType.LongInt;
                                clsDataSample.SignalDataList[1].DataType = eDataType.LongInt;
                                clsDataSample.SignalDataList[2].DataType = eDataType.LongInt;
                                if ((clsDataSample != null) && (_acquisitionTab != null)  && ((_acquisitionTab.NumberOfSamples == -1) || (_acquisitionTab.NumberOfSamples > _acquisitionTab.NumberOfAcquisition)))
                                {
                                    #region Record                                 
                                    if (clsDataSample.SignalDataList[4].PointCount == 192)
                                        //if (IsInteger((clsDataSample.SignalDataList[0].DataToDouble - measureParamReader.SetStartPosition) / measureParamReader.SetTriggerInterval) && clsDataSample.SignalDataList[4].PointCount == 192)
                                    {
                                        if (xpos != clsDataSample.SignalDataList[0].DataToDouble )
                                        {

                                            if (counter == 0)
                                            {
                                                ypos = _acquisitionTab.StartMeasureYPos;
                                            }
                                            if (_ccsvWriteFiles != null)
                                                {
                                                    lock (_ccsvWriteFiles)
                                                    {
                                                        if (counter < _acquisitionTab.NumberOfSamples + 1)
                                                        {                                                         
                                                            if (_ccsvWriteFiles.Add(clsDataSample))
                                                            {
                                                                counter = counter + 1;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble;
                                                                ypos = clsDataSample.SignalDataList[1].DataToDouble;
                                                            }                
                                                        }                                                     
                                                        if (counter == _acquisitionTab.NumberOfSamples+1 )
                                                        {
                                                            if (_ccsvWriteFiles.WriteList(_cprojectSettings, _measure_distance, _motion.ScanMode()))
                                                            {
                                                                counter = 0;
                                                                counter_end = 0;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble - 1;
                                                            }
                                                            else
                                                            {
                                                                counter = 0;
                                                                counter_end = 0;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble - 1;
                                                            }
                                                        }
                                                    }                                                 
                                                }
                                                else
                                                {
                                                    //_ccsvWriteFiles = new cCsvWriteFiles();
                                                }
                                            //}
                                        }
                                        else
                                        {
                                            ypos = clsDataSample.SignalDataList[1].DataToDouble;
                                            if ((int)xpos == (_acquisitionTab.StartMeasureXPos + _measure_distance) && (int)ypos == (_acquisitionTab.StartMeasureYPos + 1)&& counter_end == 0)
                                            {
                                                if ((_ccsvWriteFiles != null))
                                                {
                                                    lock (_ccsvWriteFiles)
                                                    {
                                                        if (counter < _acquisitionTab.NumberOfSamples + 1)
                                                        {
                                                            if(_ccsvWriteFiles.Add(clsDataSample))
                                                            {
                                                                counter = counter + 1;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble;
                                                                ypos = clsDataSample.SignalDataList[1].DataToDouble;
                                                                counter_end = 1;
                                                            }
                                                            
                                                        }
                                                    }
                                                }
                                            }
                                            if ((int)xpos == (_acquisitionTab.StartMeasureXPos + 1) && (int)ypos == (_acquisitionTab.StartMeasureYPos + 2)&& counter_end == 1)
                                            {
                                                if ((_ccsvWriteFiles != null))
                                                {
                                                    lock (_ccsvWriteFiles)
                                                    {
                                                        if (counter < _acquisitionTab.NumberOfSamples + 1)
                                                        {
                                                            if (_ccsvWriteFiles.Add(clsDataSample))
                                                            {
                                                                counter = counter + 1;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble;
                                                                ypos = clsDataSample.SignalDataList[1].DataToDouble;
                                                                counter_end = 2;
                                                            }                                                           
                                                        }
                                                    }
                                                }
                                            }
                                            if ((int)xpos == (_acquisitionTab.StartMeasureXPos + _measure_distance) && (int)ypos == (_acquisitionTab.StartMeasureYPos + 3) && counter_end == 2)
                                            {
                                                if ((_ccsvWriteFiles != null))
                                                {
                                                    lock (_ccsvWriteFiles)
                                                    {
                                                        if (counter < _acquisitionTab.NumberOfSamples + 1)
                                                        {
                                                            if(_ccsvWriteFiles.Add(clsDataSample))
                                                            {
                                                                counter = counter + 1;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble;
                                                                ypos = clsDataSample.SignalDataList[1].DataToDouble;
                                                                counter_end = 3;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if ((int)xpos == (_acquisitionTab.StartMeasureXPos + 1) && (int)ypos == (_acquisitionTab.StartMeasureYPos + 4) && counter_end == 3)
                                            {
                                                if ((_ccsvWriteFiles != null))
                                                {
                                                    lock (_ccsvWriteFiles)
                                                    {
                                                        if (counter < _acquisitionTab.NumberOfSamples + 1)
                                                        {
                                                            if(_ccsvWriteFiles.Add(clsDataSample))
                                                            {
                                                                counter = counter + 1;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble;
                                                                ypos = clsDataSample.SignalDataList[1].DataToDouble;
                                                                counter_end = 0;
                                                            }                                                           
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    #endregion                                
                                    
                                }
                                dataIntensityAverage = clsDataSample.SignalDataList[6].Average(0, true);                              
                            }
                        }
                    }
                }
                #endregion
            }
            _threadDataSample.EventExitProcessThreadDo.Set();
        }
        #endregion
        #endregion

        #region 按鈕Click事件
        #region btn_dark_Click
        private void btn_dark_Click(object sender, EventArgs e)
        {
            if ((_client != null) && (_client.ClientIsConnected))
            {
                f_dark form = new f_dark();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _client.Dark();
                }
            }
        }
        #endregion
        #region btn mode switch
        private void btn_advanced_mode_Click(object sender, EventArgs e)
        {
            if (is_advanced_mode) GeneralMode(sender, e);
            else AdvancedMode();
        }
        private void AdvancedMode()
        {
            PasswordBox psForm = new PasswordBox();

            if (psForm.ShowDialog() == DialogResult.OK)
            {
                is_advanced_mode = true;
                timer = new System.Timers.Timer(300000);//定時週期300秒
                timer.Elapsed += GeneralMode;//定時時間到的時候的回撥函式
                timer.AutoReset = false; //是否不斷重複定時器操作
                timer.Enabled = true; //定時器啟動

                tabControlMain.TabPages.Add(tbp_sodx); //Add a tab page
                tabControlMain.TabPages.Add(tbp_status); //Add a tab page
                tabControlMain.TabPages.Add(tbp_motion); //Add a tab page
                grp_cursor.Visible = true;
                grp_align_test.Visible = true;
                btn_connection_ip.Visible = true;
            }
            else
            {
                MessageBox.Show("密碼錯誤!!");
            }
        }
        #region general mode
        public void GeneralMode(object sender, EventArgs e)
        {
            is_advanced_mode = false;

            tabControlMain.TabPages.Remove(tbp_sodx); //Remove a tab page
            tabControlMain.TabPages.Remove(tbp_status); //Remove a tab page
            tabControlMain.TabPages.Remove(tbp_motion); //Remove a tab page
            grp_cursor.Visible = false;
            grp_align_test.Visible = false;
            btn_connection_ip.Visible = false;

            timer = new System.Timers.Timer(1);//定時週期0.001秒
            timer.Elapsed += ntb_cur_pos;//定時時間到的時候的回撥函式
            timer.AutoReset = true; //是否不斷重複定時器操作
            timer.Enabled = true; //定時器啟動
        }
        #endregion
        #endregion
        #region btn_sodx_Click 
        private void btn_sodx_Click(object sender, EventArgs e)
        {
            f_selected_sodx selected_sodx = new f_selected_sodx();
            cSodxCommand sodxCommand = new cSodxCommand();
            sodxCommand = _client.SelectOutputFormat;
            selected_sodx.SodxCommand = sodxCommand;
            if (selected_sodx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _client.SelectOutputFormat = selected_sodx.BackupSodxCommand.Copy();
            }
        }
        #endregion
        #region btn_sodx_execute_Click
        private void btn_sodx_execute_Click(object sender, EventArgs e)
        {
            _threadAcquisition = (_threadAcquisition == eThreadAcquisition.eRun) ? eThreadAcquisition.eStop : eThreadAcquisition.eRun;
            if ((_threadAcquisition == eThreadAcquisition.eRun) && (_client != null))
            {
                _dataAcquisitionCounter = 0;
                _fifoDataSodx.CalculationOfFifo.Reset();
                _client.ClearDataSampleFifo();
                _threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eRun].Set();
                _dataAcquisitionNumber = (int)num_data_acquisition_number.Value;
            }
            else
            {
                _threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eStop].Set();
            }
        }
        #endregion
        #region btn_sodx_pause_Click
        private void btn_sodx_pause_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                _threadDisplayAcquisition = (_threadDisplayAcquisition == eThreadDisplayAcquisition.ePause) ? eThreadDisplayAcquisition.eRun : eThreadDisplayAcquisition.ePause;
            }
        }
        #endregion
        #region btn_move_distance_Click
        private void btn_move_distance_Click(object sender, EventArgs e)
        {
            KeyBoardForm _keyboardForm = new KeyBoardForm();//例項化一個Form2視窗
            _keyboardForm.StartPosition = FormStartPosition.CenterScreen;
            if (_keyboardForm.ShowDialog() == DialogResult.OK)
            {
                btn_move_distance.Text = _keyboardForm.T.Text;
            }
        }
        #endregion
        #region btn_move_distance_z_Click
        private void btn_move_distance_z_Click(object sender, EventArgs e)
        {
            KeyBoardForm _keyboardForm = new KeyBoardForm();//例項化一個Form2視窗
            _keyboardForm.StartPosition = FormStartPosition.CenterScreen;
            if (_keyboardForm.ShowDialog() == DialogResult.OK)
            {
                btn_move_distance_z.Text = _keyboardForm.T.Text;
            }
        }
        #endregion
        #region btn_AutoFocus_Click
        private void btn_AutoFocus_Click(object sender, EventArgs e)
        {
            FocusClimbing();
        }
        #endregion

        #endregion

        #region 顯示或輸入或改變事件
        #region ntb_cur_pos
        public void ntb_cur_pos(object sender, EventArgs e)
        {
            ntb_x_cur_motorpos.Text = _motion.GetPos('X').ToString();
            ntb_y_cur_motorpos.Text = _motion.GetPos('Y').ToString();
            ntb_z_cur_motorpos.Text = _motion.GetPos('Z').ToString();
            ntb_r_cur_motorpos.Text = _motion.GetPos('R').ToString();
        }      
        #endregion
        #region cb_SelectMeasureDistance_SelectedIndexChanged
        private void cb_SelectMeasureDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            _measure_distance = int.Parse(cb_SelectMeasureDistance.Text);
            if (_motion.ScanMode() == 1) _measure_distance *= 5;
        }
        #endregion
        #region tabControlMain_Selecting
        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControlMain.SelectedTab == tbp_sodx
                || tabControlMain.SelectedTab == tbp_status
                || tabControlMain.SelectedTab == tbp_motion)
            {
                if (psengineerForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("密碼錯誤!!");
                    e.Cancel = true;
                }
            }
        }
        #endregion
        #endregion

        #region 連接相機 事件
        #region OnClientConnect
        private void OnClientConnect(object sender, EventArgs e)
        {
            if (_threadGui != null)
            {
                _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();
            }
        }
        #endregion
        #region OnClientDisconnect
        private void OnClientDisconnect(object sender, EventArgs e)
        {
            if (_threadGui != null)
            {
                _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();
            }
        }
        #endregion
        #region DisplayClientConnectionState
        private void DisplayClientConnectionState(cClientCommunication client)
        {
            /*
            if (client != null)
            {
                btn_connection.Image = (client.ClientIsConnected) ? Properties.Resources.FUNC_CONNECT : Properties.Resources.FUNC_DISCONNECT;
            }
            */
        }
        #endregion
        #region _OnClientConnect
        private void _OnClientConnect(object sender, EventArgs e)
        {
            if (_threadGui != null)
            {
                _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();
            }
        }
        #endregion
        #region _OnClientDisconnect
        private void _OnClientDisconnect(object sender, EventArgs e)
        {
            if (_threadGui != null)
            {
                _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();
            }
        }
        #endregion

        #endregion

        #region 即時顯示圖事件
        #region _OnUpdateInitDownloadDisplay
        private void _OnUpdateInitDownloadDisplay(System.Windows.Forms.Form form)
        {
            double Zoom = 2;

            clsRawImage.FirstDataLine = 0;
            if (_ccd_range != null)
            {
                clsRawImage.SizeOfDataLine = _ccd_range.PixelRange;
            }
            clsRawImage.FirstDataColumn = 0;
            clsRawImage.SizeOfDataColumn = _generalSettings.General.Sensor.NumberOfFibers; ;
            clsRawImage.ZoomX = (float)Zoom;
            clsRawImage.ZoomY = (float)Zoom;
            clsRawImage.ClearCursorList();
            _cursor_raw_v1 = new cRawImageCursor(cRawImageCursor.eTypeOfCursor.Vertical);
            _cursor_raw_v1.CursorColor = Color.Red;
            _cursor_raw_v1.Name = "_cursor_v1";
            clsRawImage.AddCursorList(_cursor_raw_v1);
            _cursor_raw_v2 = new cRawImageCursor(cRawImageCursor.eTypeOfCursor.Vertical);
            _cursor_raw_v2.CursorColor = Color.Blue;
            _cursor_raw_v2.Name = "_cursor_v2";
            clsRawImage.AddCursorList(_cursor_raw_v2);
            _cursor_raw_v3 = new cRawImageCursor(cRawImageCursor.eTypeOfCursor.Vertical);
            _cursor_raw_v3.CursorColor = Color.Green;
            _cursor_raw_v3.Name = "_cursor_v3";
            clsRawImage.AddCursorList(_cursor_raw_v3);
            #region NumericUpDown
            chk_cursor_v1.Tag = _cursor_raw_v1;
            nud_cursor_v1.Tag = _cursor_raw_v1;
            nud_cursor_v1.Minimum = clsRawImage.FirstDataColumn;
            nud_cursor_v1.Maximum = clsRawImage.FirstDataColumn + clsRawImage.SizeOfDataColumn;
            chk_cursor_v2.Tag = _cursor_raw_v2;
            nud_cursor_v2.Tag = _cursor_raw_v2;
            nud_cursor_v2.Minimum = clsRawImage.FirstDataColumn;
            nud_cursor_v2.Maximum = clsRawImage.FirstDataColumn + clsRawImage.SizeOfDataColumn;
            chk_cursor_v3.Tag = _cursor_raw_v3;
            nud_cursor_v3.Tag = _cursor_raw_v3;
            nud_cursor_v3.Minimum = clsRawImage.FirstDataColumn;
            nud_cursor_v3.Maximum = clsRawImage.FirstDataColumn + clsRawImage.SizeOfDataColumn;
            #endregion
            #region zegraph
            if (_curve_v1 != null)
            {
                _curve_v1.Dispose();
                _curve_v1 = null;
            }
            if (_curve_v2 != null)
            {
                _curve_v2.Dispose();
                _curve_v2 = null;
            }
            if (_curve_v3 != null)
            {
                _curve_v3.Dispose();
                _curve_v3 = null;
            }
            _curve_v1 = cMagicGraphCurve.PrepareCurve(_cursor_raw_v1.DataPoint, null, _cursor_raw_v1.CursorColor, -1, -1, _cursor_raw_v1.Name);
            _curve_v2 = cMagicGraphCurve.PrepareCurve(_cursor_raw_v2.DataPoint, null, _cursor_raw_v2.CursorColor, -1, -1, _cursor_raw_v2.Name);
            _curve_v3 = cMagicGraphCurve.PrepareCurve(_cursor_raw_v3.DataPoint, null, _cursor_raw_v3.CursorColor, -1, -1, _cursor_raw_v3.Name);
            ctrl_zgc_dnld.DisplayInit();
            ctrl_zgc_dnld.SetXAxisTitle("Pixels", Color.Black, Color.SkyBlue, 10);
            ctrl_zgc_dnld.SetYAxisTitle("Intensity", Color.Black, Color.SkyBlue, 10);
            ctrl_zgc_dnld.GraphPane.XAxis.Scale.Format = "#";
            ctrl_zgc_dnld.GraphPane.YAxis.Scale.Format = "#";
            ctrl_zgc_dnld.GraphPane.YAxis.Title.FontSpec.Angle = 180;
            ctrl_zgc_dnld.GraphPane.XAxis.Scale.Min = clsRawImage.FirstDataColumn;
            ctrl_zgc_dnld.GraphPane.XAxis.Scale.Max = clsRawImage.FirstDataColumn + clsRawImage.SizeOfDataLine;
            ctrl_zgc_dnld.GraphPane.YAxis.Scale.Min = -50;
            ctrl_zgc_dnld.GraphPane.YAxis.Scale.Max = 0x7FFF;
            ctrl_zgc_dnld.ClearCurves();
            ctrl_zgc_dnld.AddCurve(_curve_v1);
            ctrl_zgc_dnld.AddCurve(_curve_v2);
            ctrl_zgc_dnld.AddCurve(_curve_v3);
            ctrl_zgc_dnld.AxisChange();
            ctrl_zgc_dnld.Refresh();
            #endregion
        }
        #endregion

        #region UpdateDisplayRawSpectraDelegate
        private void UpdateDisplayRawSpectraDelegate(cDnldCommand dnldCommand)
        {
            if (clsRawImage.Data != null)
            {
                if ((_isCursorV1IndexChange) || (_isCursorV2IndexChange) || (_isCursorH1IndexChange))
                {
                    #region cursor V1
                    if (_isCursorV1IndexChange)
                    {
                        _curve_v1.IsVisible = _cursor_raw_v1.Visible;
                        _curve_v1.DataOne = _cursor_raw_v1.DataPoint;
                        _isCursorV1IndexChange = false;
                    }
                    #endregion
                    #region cursor V2
                    if (_isCursorV2IndexChange)
                    {
                        _curve_v2.IsVisible = _cursor_raw_v2.Visible;
                        _curve_v2.DataOne = _cursor_raw_v2.DataPoint;
                        _isCursorV2IndexChange = false;
                    }
                    #endregion
                    #region cursor H1
                    if (_isCursorH1IndexChange)
                    {
                        _curve_v3.IsVisible = _cursor_raw_v3.Visible;
                        _curve_v3.DataOne = _cursor_raw_v3.DataPoint;
                        _isCursorH1IndexChange = false;
                    }
                    #endregion
                    ctrl_zgc_dnld.AxisChange();
                    ctrl_zgc_dnld.DisplayClear();
                    ctrl_zgc_dnld.DisplayCurves();
                    ctrl_zgc_dnld.Refresh();
                }
            }
        }
        #endregion
        #region Noise Offset
        private void hsb_noise_offset_Scroll(object sender, ScrollEventArgs e)
        {
            clsRawImage.NoiseOffset = e.NewValue;
        }
        #endregion
        #region Dynamic
        private void nud_dynamic_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown nud_cursor = (NumericUpDown)sender;
                clsRawImage.Dynamic = (byte)nud_cursor.Value;
            }
        }
        #endregion
        #region ctrl_display_OnValueCursorChange
        //-------------------------------------------------------------------------------------------
        private void ctrl_display_OnValueCursorChange(object sender, int value)
        {
            if (sender is cRawImageCursor)
            {
                cRawImageCursor cursor = (cRawImageCursor)sender;
                if (cursor.Name == "_cursor_v1")
                {
                    this.Invoke((MethodInvoker)delegate { nud_cursor_v1.Value = Math.Min(Math.Max(nud_cursor_v1.Minimum, cursor.Index), nud_cursor_v1.Maximum - 1); });
                    _isCursorV1IndexChange = true;
                }
                if (cursor.Name == "_cursor_v2")
                {
                    this.Invoke((MethodInvoker)delegate { nud_cursor_v2.Value = Math.Min(Math.Max(nud_cursor_v2.Minimum, cursor.Index), nud_cursor_v2.Maximum - 1); });
                    _isCursorV2IndexChange = true;
                }
                if (cursor.Name == "_cursor_v3")
                {
                    this.Invoke((MethodInvoker)delegate { nud_cursor_v3.Value = Math.Min(Math.Max(nud_cursor_v3.Minimum, cursor.Index), nud_cursor_v3.Maximum - 1); });
                    _isCursorH1IndexChange = true;
                }
            }
        }
        #endregion
        #region nud_cursor_vx_ValueChanged
        private void nud_cursor_vx_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown nud_cursor = (NumericUpDown)sender;
                cRawImageCursor cursor = (cRawImageCursor)nud_cursor.Tag;
                if (cursor != null)
                {
                    cursor.Index = (int)nud_cursor.Value;
                    if (_client.DnldCommand.IsBusyDownloadRaw == false)
                    {
                        this.Invoke(this.DisplayRawSpectraDelegate, new object[] { _client.DnldCommand });
                        clsRawImage.Invalidate();
                    }
                }
            }
        }
        #endregion
        #region chk_cursor_v_Click
        private void chk_cursor_v_Click(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                Panel panel = (Panel)sender;
                cRawImageCursor cursor = (cRawImageCursor)panel.Tag;
                if (cursor != null)
                {
                    if (cursor.Name == "_cursor_v1")
                    {
                        _isCursorV1IndexChange = true;
                    }
                    if (cursor.Name == "_cursor_v2")
                    {
                        _isCursorV2IndexChange = true;
                    }
                    if (cursor.Name == "_cursor_v3")
                    {
                        _isCursorH1IndexChange = true;
                    }
                    cursor.Visible = (cursor.Visible) ? false : true;
                    if (_client.DnldCommand.IsBusyDownloadRaw == false)
                    {
                        this.Invoke(this.DisplayRawSpectraDelegate, new object[] { _client.DnldCommand });
                        clsRawImage.Invalidate();
                    }
                }
            }
        }
        #endregion

        #region OnUpdateIhm
        private void OnUpdateIhm(object sender)
        {
            if ((sender != null) && (sender is sDnldCommandState))
            {
                switch ((eSpectraId)((sDnldCommandState)sender).SpectraId)
                {
                    case eSpectraId.SpectraIdRawSpectrum:
                        if (_threadGui != null)
                        {
                            _threadGui.EventUserList[(int)enEventThreadGui.DisplayDownloadRawSpectra].Set();
                        }
                        break;
                }
            }
        }
        #endregion

        #endregion

        #region 運動控制
        #region btn_origin_return_Click
        private void btn_origin_return_Click(object sender, EventArgs e)
        {
            if (!_motion.GoHome()) 
                MessageBox.Show(_motion.GetErrorMsg());
        }
        #endregion
        #region btn_PosingStop_Click
        private void btn_PosingStop_Click(object sender, EventArgs e)
        {
            if (!_motion.StopMove())
                MessageBox.Show(_motion.GetErrorMsg());
        }
        #endregion
        #region btn_auto_measurement
        private void btn_auto_measurement(object sender, EventArgs e)
        {
            if (tb_dieX.Text == "" || tb_dieY.Text == "")
            {
                MessageBox.Show("請先輸入die的邊長");
                return;
            }
            if (tbThreshold.Text == "")
            {
                MessageBox.Show("請先輸入影像分割閥值");
                return;
            }
            //轉正
            VisionCalibrator vc = new VisionCalibrator();
            die_side[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(Int32.Parse(tb_dieX.Text));
            die_side[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(Int32.Parse(tb_dieY.Text));
            die_side[2] = Constants.SCRIBE_LINE_WIDTH;
            int threshold = Int32.Parse(tbThreshold.Text);
            if (!_syn_op.DoAlignment(cur_img, threshold, ref die_side))
            {
                MessageBox.Show(_syn_op.Err_msg);
                return;
            }
            die_side[Constants.WAY_HORIZONTAL] = vc.Pixel2Um_X(die_side[Constants.WAY_HORIZONTAL]);
            die_side[Constants.WAY_VERTICAL] = vc.Pixel2Um_Y(die_side[Constants.WAY_VERTICAL]);

            AutoParamsForm form = new AutoParamsForm();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            _wafer_id = form.tb_wafer_id.Text;
            _notch_idx = form.cmb_notch.SelectedIndex;
            _die_row_count = int.Parse(form.tb_row_count.Text);
            _die_col_count = int.Parse(form.tb_col_count.Text);
            int pts_cnt = form.cmb_mea_points.SelectedIndex * 4 + 1;
            _mea_pts_rows = new int[pts_cnt];
            _mea_pts_cols = new int[pts_cnt];
            _mea_pos_y = new int[pts_cnt];
            _mea_pos_x = new int[pts_cnt];
            //pts[0]==>central die
            _mea_pts_rows[0] = (_die_row_count % 2 == 0) ? 1 : 0;
            _mea_pts_cols[0] = (_die_col_count % 2 == 0) ? 1 : 0;
            _mea_pos_y[0] = TransformDiePos(_mea_pts_rows[0], true);
            _mea_pos_x[0] = TransformDiePos(_mea_pts_cols[0], false);
            if (pts_cnt > 0) //more than 1 points
            {
                int r = int.Parse(form.tb_mea_row1.Text);
                int c = int.Parse(form.tb_mea_col1.Text);
                if (r > _die_row_count/2 || c > _die_col_count / 2)
                {
                    MessageBox.Show("指定量測的die位置，超出晶圓範圍");
                    return;
                }
                int pos_x = TransformDiePos(c, false);
                int pos_y = TransformDiePos(r, true);

                _mea_pts_rows[1] = r; _mea_pts_cols[1] = -c; //left-top
                _mea_pts_rows[2] = r; _mea_pts_cols[2] = c; //right-top
                _mea_pts_rows[3] = -r; _mea_pts_cols[3] = c; //right-bottom
                _mea_pts_rows[4] = -r; _mea_pts_cols[4] = -c; //left-bottom
                _mea_pos_y[1] = pos_y; _mea_pos_x[1] = -pos_x; //left-top
                _mea_pos_y[2] = pos_y; _mea_pos_x[2] = pos_x; //right-top
                _mea_pos_y[3] = -pos_y; _mea_pos_x[3] = pos_x; //right-bottom
                _mea_pos_y[4] = -pos_y; _mea_pos_x[4] = -pos_x; //left-bottom
                if (pts_cnt > 5) //9 points
                {
                    r = int.Parse(form.tb_mea_row2.Text);
                    c = int.Parse(form.tb_mea_col2.Text);
                    if (r > _die_row_count / 2 || c > _die_col_count / 2)
                    {
                        MessageBox.Show("指定量測的die位置，超出晶圓範圍");
                        return;
                    }
                    pos_x = TransformDiePos(c, false);
                    pos_y = TransformDiePos(r, true);
                    _mea_pts_rows[5] = -r; _mea_pts_cols[5] = -c; //left-bottom
                    _mea_pts_rows[6] = r; _mea_pts_cols[6] = -c; //left-top
                    _mea_pts_rows[7] = r; _mea_pts_cols[7] = c; //right-top
                    _mea_pts_rows[8] = -r; _mea_pts_cols[8] = c; //right-bottom
                    _mea_pos_y[5] = -pos_y; _mea_pos_x[5] = -pos_x; //left-top
                    _mea_pos_y[6] = pos_y; _mea_pos_x[6] = -pos_x; //right-top
                    _mea_pos_y[7] = pos_y; _mea_pos_x[7] = pos_x; //right-bottom
                    _mea_pos_y[8] = -pos_y; _mea_pos_x[8] = pos_x; //left-bottom
                }
            }
            _syn_op.DoAutoScan(_wafer_id, _mea_pos_x, _mea_pos_y);
        }
        private int TransformDiePos(int die_idx, bool is_row)
        {
            int idx = (is_row) ? 1 : 0;
            int base_coor = _center_pos[idx];
            if (_die_col_count % 2 == 1) //odd number
            {
                base_coor = _center_pos[idx] - (int)(die_side[idx] / 2);
                return (int)(base_coor + die_idx * die_side[idx]);
            }
            else //even number
            {
                if (die_idx >= 0)
                    return (int)(base_coor + (die_idx - 1) * die_side[idx]);
                else
                    return (int)(base_coor + die_idx * die_side[idx]);
            }
        }
        #endregion
        #region btn_move_Click
        private void btn_movex_positive_Click(object sender, EventArgs e)
        {
            int move_distance = int.Parse(btn_move_distance.Text);
            if (!_motion.MoveTo('X', move_distance))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_movex_negative_Click(object sender, EventArgs e)
        {
            int move_distance = int.Parse(btn_move_distance.Text);
            if (!_motion.MoveTo('X', -move_distance))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_movey_positive_Click(object sender, EventArgs e)
        {
            int move_distance = int.Parse(btn_move_distance.Text);
            if (!_motion.MoveTo('Y', move_distance))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_movey_negative_Click(object sender, EventArgs e)
        {
            int move_distance = int.Parse(btn_move_distance.Text);
            if (!_motion.MoveTo('Y', -move_distance))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_movez_positive_Click(object sender, EventArgs e)
        {
            int move_distance = int.Parse(btn_move_distance_z.Text);
            if (!_motion.MoveTo('Z', move_distance))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_movez_negative_Click(object sender, EventArgs e)
        {
            int move_distance = int.Parse(btn_move_distance_z.Text);
            if (!_motion.MoveTo('Z', -move_distance))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        #endregion
        #region btn_JOG__Click 
        private void btn_JOG_Positive_Start_Click(object sender, EventArgs e)
        {
            if (!_motion.JogY(true))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_JOG_Negative_Start_Click(object sender, EventArgs e)
        {
            if (!_motion.JogY(true, false))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_JOG_Stop_Click(object sender, EventArgs e)
        {
            if (!_motion.JogY(false))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        #endregion
        #region btn_load/unload_wafer_Click
        private void btn_load_wafer_Click(object sender, EventArgs e)
        {
            char[] axis = { 'X', 'Y', 'Z' };
            if (!_motion.MoveTo(axis, _center_pos, false))
                MessageBox.Show(_motion.GetErrorMsg());
        }
        private void btn_unload_wafer_Click(object sender, EventArgs e)
        {
            int[] distance = new int[3];
            _motion.GetLoadPos(ref distance);
            char[] axis = { 'X', 'Y', 'Z' };
            _motion.MoveTo(axis, distance, false);
        }
        #endregion
        #endregion

        #region 計算函數
        #region IsInteger
        public bool IsInteger(double d)
        {
            return (d == (int)d);
        }
        #endregion
        #endregion



        #region OnInitDisplay
        private void OnInitDisplay(System.Windows.Forms.Form form)
        {
            _eventControlUpdateValueToText = new cControlUpdateEx.OnEventHandler(OnControlUpdateValueToText);
            _eventcontrolUpdateTextToValue = new cControlUpdateEx.OnEventHandler(OnControlUpdateTextToValue);
            _controlUpdate = new cControlUpdateEx(_eventcontrolUpdateTextToValue, _eventControlUpdateValueToText, Color.LemonChiffon);
            _controlUpdate.ControlUpdateList.Clear();
            _clu_led_intensity = new sControlUpdateEx(ntb_led_intensity);
            _controlUpdate.ControlUpdateList.Add(_clu_led_intensity);
            _clu_scale = new sControlUpdateEx(ntb_scale);
            _controlUpdate.ControlUpdateList.Add(_clu_scale);
            _clu_threshold = new sControlUpdateEx(ntb_threshold);
            _controlUpdate.ControlUpdateList.Add(_clu_threshold);
            _clu_cbx_high_speed_mode = new sControlUpdateEx(cbx_high_speed_mode);
            _controlUpdate.ControlUpdateList.Add(_clu_cbx_high_speed_mode);
            _clu_cbx_high_speed = new sControlUpdateEx(cbx_high_speed);
            _controlUpdate.ControlUpdateList.Add(_clu_cbx_high_speed);
            _threadGui.EventUserList[(int)enEventThreadGui.DisplayDataSample].Set();
            _threadGui.EventUserList[(int)enEventThreadGui.DisplaySampleRate].Set();
            Invalidate();
        }
        #endregion     
        #region OnUpdateDataSample
        /// <summary>Event receive new data sample</summary>
        /// <param name="clsCommand"> The <see cref="cDataSample"/> instance containing the data sample.</param>
        private void OnUpdateDataSample(cDataSample dataSample)
        {
            if ((_fifoDataSample != null) && (dataSample != null))
            {
                lock (_fifoDataSample)
                {
                    _fifoDataSample.Enqueue(dataSample);    //定期收集資料 用event的方式執行
                    if (_threadDataSample != null)
                    {
                        _threadDataSample.EventUserList[(int)eThreadDataSample.DataSample].Set();
                    }
                }
            }
        }
        #endregion
        #region _OnUpdateDataSample
        private void _OnUpdateDataSample(cDataSample dataSample)
        {
            if ((_fifoDataSample != null) && (dataSample != null))
            {
                lock (_fifoDataSample)
                {
                    _fifoDataSample.Enqueue(dataSample);
                    if (_displayDataSodx != null)
                    {
                        _displayDataSodx.DataSample = dataSample;
                    }
                }
                if (_threadGui != null)
                {
                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayDataSample].Set();
                }
            }
        }
        #endregion
        #region OnUpdateCommandData
        private void OnUpdateCommandData(cClsCommandData clsCommand)
        {
            if (_fifoCommandData != null)
            {
                lock (_fifoCommandData)
                {
                    _fifoCommandData.Enqueue(clsCommand);
                }
                if (_threadGui != null)
                {
                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayCommandData].Set();
                }
            }
        }
        #endregion
        #region _OnUpdateCommandData
        private void _OnUpdateCommandData(cClsCommandData clsCommand)
        {
            if (_fifoCommandData != null)
            {
                lock (_fifoCommandData)
                {
                    _fifoCommandData.Enqueue(clsCommand);
                }
                if (_threadGui != null)
                {
                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayCommandData].Set();
                }
            }
        }
        #endregion
        #region OnUpdateDataFormat
        /// <summary>Event receive new data format</summary>
        /// <param name="clsCommand"> The <see cref="cDataFormat"/> instance containing the data format.</param>
        private void OnUpdateDataFormat(cDataFormat dataFormat)
        {
        }
        #endregion
        #region _OnUpdateDataFormatEntry
        private void _OnUpdateDataFormatEntry(cDataFormat dataFormat)
        {
            if (_fifoDataFormat != null)
            {
                lock (_fifoDataFormat)
                {
                    _fifoDataFormat.Enqueue(dataFormat);
                }
                if (_threadGui != null)
                {
                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayDataFormat].Set();
                }
            }
        }
        #endregion
        #region OnControlUpdateValueToText
        private void OnControlUpdateValueToText(object sender)
        {
            if (sender is sControlUpdateEx)
            {
                sControlUpdateEx controlUpdate = (sControlUpdateEx)sender;
                if (controlUpdate.Object is NumericTextBox)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ((NumericTextBox)controlUpdate.Object).Text = controlUpdate.Text;
                    });
                }
                else if (controlUpdate.Object is TextBox)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ((TextBox)controlUpdate.Object).Text = controlUpdate.Text;
                    });
                }
                else if (controlUpdate.Object is ComboBox)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ((ComboBox)controlUpdate.Object).Text = controlUpdate.Text;
                    });
                }
            }
        }
        #endregion
        #region OnControlUpdateTextToValue
        private void OnControlUpdateTextToValue(object sender)
        {
            try
            {
                if ((_client != null) && (_client.ClientIsConnected) && (sender is sControlUpdateEx))
                {
                    sControlUpdateEx controlUpdate = (sControlUpdateEx)sender;
                    if (controlUpdate.Object is NumericTextBox)
                    {
                        NumericTextBox numericTextBox = (NumericTextBox)controlUpdate.Object;
                        if (numericTextBox == ntb_led_intensity)//Led Intensity
                        {
                            _client.LedIntensity = (float)ntb_led_intensity.Value;
                        }

                        else if (numericTextBox == ntb_threshold)//Threshold
                        {
                        _client.Threshold = (float)ntb_threshold.Value;
                        }
                        Invoke((Action)(() => { numericTextBox.SelectAll(); }));
                    }
                    else if (controlUpdate.Object is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)controlUpdate.Object;
                        if ((comboBox == cbx_high_speed) && (_client != null))
                        {
                            _threadGui.EventUserList[(int)enEventThreadGui.UpdateHighSpeed].Set();
                        }
                        else if ((comboBox == cbx_high_speed_mode) && (_client != null))
                        {
                            _threadGui.EventUserList[(int)enEventThreadGui.UpdateHighSpeedMode].Set();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region DisplayCommandData
        private void DisplayCommandData(cClsCommandData clsCommand)
        {
            if ((clsCommand != null) && (clsCommand.ErrorEventArgs == null))
            {
                switch (clsCommand.CommandList)
                {
                    //Led Intensity
                    case eCommandList.LAI:
                        if (_clu_led_intensity != null)
                        {
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_led_intensity, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        }
                        break;
                    //Free Sample Rate
                    case eCommandList.SHZ:
                        if (_clu_cbx_high_speed != null)
                        {
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_cbx_high_speed, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        }
                        break;
                    //Number Of Peaks
                    case eCommandList.NOP:
                        if (_clu_number_of_peak != null)
                        {
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_number_of_peak, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        }
                        break;
                    //Scale
                    case eCommandList.SCA:
                        if (_clu_scale != null)
                        {
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_scale, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), true, true, true);
                            if (_displayDataSodx != null)
                            {
                                _displayDataSodx.Scale = Convert.ToInt32(clsCommand.Value);
                                _displayDataSodx.SaturationLevelIntensity = _client.SaturationLevelIntensity;
                            }
                            if (_saveFilteredData != null)
                            {
                                _saveFilteredData.Scale = Convert.ToInt32(clsCommand.Value);
                                _saveFilteredData.SaturationLevelIntensity = _client.SaturationLevelIntensity;
                            }
                        }
                        break;
                    //Threshold
                    case eCommandList.THR:
                        if (_clu_threshold != null)
                        {
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_threshold, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        }
                        break;
                    //CCD Range
                    case eCommandList.CRA:
                        if (clsCommand.Value is sCCDRange)
                        {
                            _ccd_range = (sCCDRange)clsCommand.Value;
                            _threadGui.EventUserList[(int)enEventThreadGui.InitDownloadDisplay].Set();
                        }
                        break;

                }
            }

        }
        #endregion
        #region DisplayDataSample
        private void DisplayDataSample(cDataSample dataSample)
        {
            if ((dataSample != null) && (_displayDataSodx != null))
            {

                lbl_global_signal_start_time_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_sample_counter_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_start_position_y_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_start_position_x_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_start_position_z_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_start_position_u_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_start_position_v_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_stop_position_x_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_stop_position_y_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_stop_position_z_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_stop_position_u_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_stop_position_v_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_first_exposure_count_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_exposure_flags_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_real_exposure_time_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_real_lightning_time_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_trigger_lost_count_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_number_of_valid_peaks_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_ticket_number_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_health_dsp_load_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_health_ticket_wrong_order_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_health_upp_lost_count_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_health_exposure_lost_count_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_health_upp_not_finished_value.BackColor = Color.PaleTurquoise;
                lbl_global_signal_start_time_value.Text = "";
                lbl_global_signal_sample_counter_value.Text = "";
                lbl_global_signal_start_position_y_value.Text = "";
                lbl_global_signal_start_position_x_value.Text = "";
                lbl_global_signal_start_position_z_value.Text = "";
                lbl_global_signal_start_position_u_value.Text = "";
                lbl_global_signal_start_position_v_value.Text = "";
                lbl_global_signal_stop_position_x_value.Text = "";
                lbl_global_signal_stop_position_y_value.Text = "";
                lbl_global_signal_stop_position_z_value.Text = "";
                lbl_global_signal_stop_position_u_value.Text = "";
                lbl_global_signal_stop_position_v_value.Text = "";
                lbl_global_signal_first_exposure_count_value.Text = "";
                lbl_global_signal_exposure_flags_value.Text = "";
                lbl_global_signal_real_exposure_time_value.Text = "";
                lbl_global_signal_real_lightning_time_value.Text = "";
                lbl_global_signal_trigger_lost_count_value.Text = "";
                lbl_global_signal_number_of_valid_peaks_value.Text = "";
                lbl_global_signal_ticket_number_value.Text = "";
                lbl_global_signal_health_dsp_load_value.Text = "";
                lbl_global_signal_health_ticket_wrong_order_value.Text = "";
                lbl_global_signal_health_upp_lost_count_value.Text = "";
                lbl_global_signal_health_exposure_lost_count_value.Text = "";
                lbl_global_signal_health_upp_not_finished_value.Text = "";

                foreach (sSignalData data in dataSample.SignalDataList)
                {
                    data.DataType = eDataType.LongInt;
                    if (data.SignalType == eSodxSignalType.Global_Signals)
                    {
                        //Global_Signal_Sample_Counter
                        if (data.Signal == eSodxSignal.Global_Signal_Sample_Counter)
                        {
                            lbl_global_signal_sample_counter_value.Text = data.DataToString;
                            lbl_global_signal_sample_counter_value.BackColor = Color.PaleGreen;
                            //ctrl_counter_gauge.Value = Convert.ToInt32(data.DataToDouble);
                        }
                        //Global_Signal_Start_Time
                        else if (data.Signal == eSodxSignal.Global_Signal_Start_Time)
                        {
                            lbl_global_signal_start_time_value.Text = data.DataToString;
                            lbl_global_signal_start_time_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Start_Position_X
                        if (data.Signal == eSodxSignal.Global_Signal_Start_Position_X)
                        {
                            ntb_x_cur_pos.Text = data.DataToString;
                            //ntb_x_cur_pos.BackColor = Color.PaleGreen;
                            lbl_global_signal_start_position_x_value.Text = data.DataToString;
                            lbl_global_signal_start_position_x_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Start_Position_Y
                        else if (data.Signal == eSodxSignal.Global_Signal_Start_Position_Y)
                        {
                            ntb_y_cur_pos.Text = data.DataToString;
                            //ntb_y_cur_pos.BackColor = Color.PaleGreen;
                            lbl_global_signal_start_position_y_value.Text = data.DataToString;
                            lbl_global_signal_start_position_y_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Start_Position_Z
                        else if (data.Signal == eSodxSignal.Global_Signal_Start_Position_Z)
                        {
                            ntb_z_cur_pos.Text = data.DataToString;
                            //ntb_z_cur_pos.BackColor = Color.PaleGreen;
                            lbl_global_signal_start_position_z_value.Text = data.DataToString;
                            lbl_global_signal_start_position_z_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Start_Position_U
                        else if (data.Signal == eSodxSignal.Global_Signal_Start_Position_U)
                        {
                            lbl_global_signal_start_position_u_value.Text = data.DataToString;
                            lbl_global_signal_start_position_u_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Start_Position_V
                        else if (data.Signal == eSodxSignal.Global_Signal_Start_Position_V)
                        {
                            lbl_global_signal_start_position_v_value.Text = data.DataToString;
                            lbl_global_signal_start_position_v_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Stop_Position_X
                        else if (data.Signal == eSodxSignal.Global_Signal_Stop_Position_X)
                        {
                            lbl_global_signal_stop_position_x_value.Text = data.DataToString;
                            lbl_global_signal_stop_position_x_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Stop_Position_Y
                        else if (data.Signal == eSodxSignal.Global_Signal_Stop_Position_Y)
                        {
                            lbl_global_signal_stop_position_y_value.Text = data.DataToString;
                            lbl_global_signal_stop_position_y_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Stop_Position_Z
                        else if (data.Signal == eSodxSignal.Global_Signal_Stop_Position_Z)
                        {
                            lbl_global_signal_stop_position_z_value.Text = data.DataToString;
                            lbl_global_signal_stop_position_z_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Stop_Position_U
                        else if (data.Signal == eSodxSignal.Global_Signal_Stop_Position_U)
                        {
                            lbl_global_signal_stop_position_u_value.Text = data.DataToString;
                            lbl_global_signal_stop_position_u_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Stop_Position_V
                        else if (data.Signal == eSodxSignal.Global_Signal_Stop_Position_V)
                        {
                            lbl_global_signal_stop_position_v_value.Text = data.DataToString;
                            lbl_global_signal_stop_position_v_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_First_Exposure_Count
                        else if (data.Signal == eSodxSignal.Global_Signal_First_Exposure_Count)
                        {
                            lbl_global_signal_first_exposure_count_value.Text = data.DataToString;
                            lbl_global_signal_first_exposure_count_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Exposure_Flags
                        else if (data.Signal == eSodxSignal.Global_Signal_Exposure_Flags)
                        {
                            lbl_global_signal_exposure_flags_value.Text = data.DataToString;
                            lbl_global_signal_exposure_flags_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Real_Exposure_Time
                        else if (data.Signal == eSodxSignal.Global_Signal_Real_Exposure_Time)
                        {
                            lbl_global_signal_real_exposure_time_value.Text = data.DataToString;
                            lbl_global_signal_real_exposure_time_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Real_Lightning_Time
                        else if (data.Signal == eSodxSignal.Global_Signal_Real_Lightning_Time)
                        {
                            lbl_global_signal_real_lightning_time_value.Text = data.DataToString;
                            lbl_global_signal_real_lightning_time_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Trigger_Lost_Count
                        else if (data.Signal == eSodxSignal.Global_Signal_Trigger_Lost_Count)
                        {
                            lbl_global_signal_trigger_lost_count_value.Text = data.DataToString;
                            lbl_global_signal_trigger_lost_count_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Number_Of_Valid_Peaks
                        else if (data.Signal == eSodxSignal.Global_Signal_Number_Of_Valid_Peaks)
                        {
                            lbl_global_signal_number_of_valid_peaks_value.Text = data.DataToString;
                            lbl_global_signal_number_of_valid_peaks_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Ticket_Number
                        else if (data.Signal == eSodxSignal.Global_Signal_Ticket_Number)
                        {
                            lbl_global_signal_ticket_number_value.Text = data.DataToString;
                            lbl_global_signal_ticket_number_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Ticket_NuGlobal_Signal_Health_Dsp_Loadmber
                        else if (data.Signal == eSodxSignal.Global_Signal_Health_Dsp_Load)
                        {
                            lbl_global_signal_health_dsp_load_value.Text = data.DataToString;
                            lbl_global_signal_health_dsp_load_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Health_Ticket_Wrong_Order
                        else if (data.Signal == eSodxSignal.Global_Signal_Health_Ticket_Wrong_Order)
                        {
                            lbl_global_signal_health_ticket_wrong_order_value.Text = data.DataToString;
                            lbl_global_signal_health_ticket_wrong_order_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Health_Upp_Lost_Count
                        else if (data.Signal == eSodxSignal.Global_Signal_Health_Upp_Lost_Count)
                        {
                            lbl_global_signal_health_upp_lost_count_value.Text = data.DataToString;
                            lbl_global_signal_health_upp_lost_count_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Health_Exposure_Lost_Count
                        else if (data.Signal == eSodxSignal.Global_Signal_Health_Exposure_Lost_Count)
                        {
                            lbl_global_signal_health_exposure_lost_count_value.Text = data.DataToString;
                            lbl_global_signal_health_exposure_lost_count_value.BackColor = Color.PaleGreen;
                        }
                        //Global_Signal_Health_Upp_Not_Finished
                        else if (data.Signal == eSodxSignal.Global_Signal_Health_Upp_Not_Finished)
                        {
                            lbl_global_signal_health_upp_not_finished_value.Text = data.DataToString;
                            lbl_global_signal_health_upp_not_finished_value.BackColor = Color.PaleGreen;
                        }



                    }
                }
            }
        }
        #endregion
        #region DisplayDataFormat
        private void DisplayDataFormat(cClientCommunication client)
        {
            if ((_selectingFilters != null) && (_displayDataSodx != null))
            {
                //lbl_sample_rate.Text = string.Format("Sample Rate : {0}Hz", client.DataFormatSampleRate);
                //lbl_sample_rate.ForeColor = Color.Green;
                _threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eStop].Set();
                //remove previous checkbox if exist and create new checkbox
                _selectingFilters.SetSodxCommandList(client.SodxCommandList);
                _displayDataSodx.SetSodxCommandList(client.SodxCommandList);
            }
        }
        #endregion      
        #region DisplaySodxAcquisition
        private void DisplaySodxAcquisition(System.Windows.Forms.Form form)
        {
            btn_sodx_execute.Image = (_threadAcquisition == eThreadAcquisition.eRun) ? cResources.GetImageRunOn : cResources.GetImageRunOff;
            btn_sodx.Enabled = (_threadAcquisition == eThreadAcquisition.eRun) ? false : true;
            for (int idx = 0; idx < _selectingFilters.List.Count; idx++)
            {
                _selectingFilters.List[idx].CheckBox.Enabled = (_threadAcquisition != eThreadAcquisition.eRun);
            }
        }
        #endregion
        #region DisplayStatistics
        private void DisplayStatistics(List<cClientStatistics> clientStatisticsList)
        {
            if (clientStatisticsList != null)
            {
                for (int idx = 0; idx < clientStatisticsList.Count; idx++)
                {
                    cClientStatistics clientStatistics = clientStatisticsList[idx];
                    if (clientStatistics.IdName == "Client Socket Rx Data")
                    {
                        lbl_rx_rate.Text = string.Format("Rx : {0,12}", cCalculationsOnTheRate.BytesToString(clientStatistics.Rate.Value));
                        lbl_rx_rate.ForeColor = Color.Blue;
                        lbl_number_of_overflow_in_data_raw_socket.Text = string.Format("{0}, Max Used : {1:P0}", clientStatistics.DataFifo.Overflow, clientStatistics.DataFifo.MaxPercent);
                        lbl_number_of_overflow_in_data_raw_socket.ForeColor = (clientStatistics.DataFifo.Overflow > 0) ? Color.Red : Color.Blue;
                        ctrl_percentage_use_of_fifo_data_raw_socket.Value = (int)(clientStatistics.DataFifo.Percent * 100);
                    }
                    else if (clientStatistics.IdName == "Client Socket Tx Data")
                    {
                        lbl_tx_rate.Text = string.Format("Tx : {0,12}", cCalculationsOnTheRate.BytesToString(clientStatistics.Rate.Value));
                        lbl_tx_rate.ForeColor = Color.Blue;
                    }
                    else if ((clientStatistics.IdName == "Client Binary Data Rx Raw") && (clientStatistics.DataFifo != null))
                    {
                        lbl_number_of_overflow_in_data_raw_fifo.Text = string.Format("{0}, Max Used : {1:P0}", clientStatistics.DataFifo.Overflow, clientStatistics.DataFifo.MaxPercent);
                        lbl_number_of_overflow_in_data_raw_fifo.ForeColor = (clientStatistics.DataFifo.Overflow > 0) ? Color.Red : Color.Blue;
                        ctrl_percentage_use_of_fifo_data_raw_fifo.Value = (int)(clientStatistics.DataFifo.Percent * 100);
                        lbl_error_unknow_telegram_type.Text = string.Format("Error unknow telegram type : {0,10}", clientStatistics.ErrorUnknowTelegramType);
                        lbl_error_unknow_telegram_type.ForeColor = (clientStatistics.ErrorUnknowTelegramType == 0) ? Color.Black : Color.Red;
                        lbl_error_command_header.Text = string.Format("Error command header       : {0,10}", clientStatistics.ErrorCommandHeader);
                        lbl_error_command_header.ForeColor = (clientStatistics.ErrorCommandHeader == 0) ? Color.Black : Color.Red;
                        lbl_error_command_data.Text = string.Format("Error command data         : {0,10}", clientStatistics.ErrorCommandData);
                        lbl_error_command_data.ForeColor = (clientStatistics.ErrorCommandData == 0) ? Color.Black : Color.Red;
                        lbl_error_data_format_header.Text = string.Format("Error data format header   : {0,10}", clientStatistics.ErrorDataFormatHeader);
                        lbl_error_data_format_header.ForeColor = (clientStatistics.ErrorDataFormatHeader == 0) ? Color.Black : Color.Red;
                        lbl_error_data_format_entry.Text = string.Format("Error data format entry    : {0,10}", clientStatistics.ErrorDataFormatEntry);
                        lbl_error_data_format_entry.ForeColor = (clientStatistics.ErrorDataFormatEntry == 0) ? Color.Black : Color.Red;
                        lbl_error_data_header.Text = string.Format("Error data header          : {0,10}", clientStatistics.ErrorDataHeader);
                        lbl_error_data_header.ForeColor = (clientStatistics.ErrorDataHeader == 0) ? Color.Black : Color.Red;
                        lbl_error_data.Text = string.Format("Error data                 : {0,10}", clientStatistics.ErrorData);
                        lbl_error_data.ForeColor = (clientStatistics.ErrorData == 0) ? Color.Black : Color.Red;
                        lbl_error_no_dataformat.ForeColor = (clientStatistics.ErrorNoDataFormat == 0) ? Color.Black : Color.Red;
                        lbl_error_no_dataformat.Text = string.Format("Error no DataFormat        : {0,10}", clientStatistics.ErrorNoDataFormat);
                        lbl_resynchronization.Text = string.Format("Error de synchronization   : {0,10}", clientStatistics.Resynchronization);
                        lbl_resynchronization.ForeColor = (clientStatistics.Resynchronization == 0) ? Color.Black : Color.Red;
                        lbl_not_enough_data.Text = string.Format("Not enough data            : {0,10}", clientStatistics.NotEnoughData);
                        lbl_number_of_command.Text = string.Format("Number of command          : {0,10}", clientStatistics.NumberOfCommandMessage);
                        lbl_number_of_command.ForeColor = (clientStatistics.NumberOfCommandMessage == 0) ? Color.Black : Color.Green;
                        lbl_number_of_format.Text = string.Format("Number of format data      : {0,10}", clientStatistics.NumberOfFormatMessage);
                        lbl_number_of_format.ForeColor = (clientStatistics.NumberOfCommandMessage == 0) ? Color.Black : Color.Green;
                        lbl_number_of_data.Text = string.Format("Number of data             : {0,10}", clientStatistics.NumberOfDataMessage);
                        lbl_number_of_data.ForeColor = (clientStatistics.NumberOfCommandMessage == 0) ? Color.Black : Color.Green;
                        lbl_number_of_spectra.Text = string.Format("Number of spectra          : {0,10}", clientStatistics.NumberOfSpectraMessage);
                        lbl_unformatted_data.Text = string.Format("Unformatted data           : {0,10}", clientStatistics.UnformattedData);
                        lbl_unformatted_data.ForeColor = (clientStatistics.UnformattedData == 0) ? Color.Black : Color.Orange;
                    }
                    else if ((clientStatistics.IdName == "Client Data Sample") && (clientStatistics.DataFifo != null))
                    {
                        lbl_number_of_overflow_in_data_sample_fifo.Text = string.Format("{0}, Max Used : {1:P0}", clientStatistics.DataFifo.Overflow, clientStatistics.DataFifo.MaxPercent);
                        lbl_number_of_overflow_in_data_sample_fifo.ForeColor = (clientStatistics.DataFifo.Overflow > 0) ? Color.Red : Color.Blue;
                        ctrl_percentage_use_of_data_sample_fifo.Value = (int)(clientStatistics.DataFifo.Percent * 100);
                    }
                    else if ((clientStatistics.IdName != "Client Command Data") && (clientStatistics.DataFifo != null))
                    {
                        lbl_number_of_overflow_in_command_data_fifo.Text = string.Format("{0}, Max Used : {1:P0}", clientStatistics.DataFifo.Overflow, clientStatistics.DataFifo.MaxPercent);
                        lbl_number_of_overflow_in_command_data_fifo.ForeColor = (clientStatistics.DataFifo.Overflow > 0) ? Color.Red : Color.Blue;
                        ctrl_percentage_use_of_command_data_fifo.Value = (int)(clientStatistics.DataFifo.Percent * 100);
                    }
                }
            }
            if (_fifoDataSodx != null)
            {
                lbl_number_of_overflow_in_sodx_fifo.Text = string.Format("{0}, Max Used : {1:P0}", _fifoDataSodx.CalculationOfFifo.OverFlow, _fifoDataSodx.CalculationOfFifo.MaxPercent);
                lbl_number_of_overflow_in_sodx_fifo.ForeColor = (_fifoDataSodx.CalculationOfFifo.OverFlow > 0) ? Color.Red : Color.Blue;
                ctrl_percentage_use_of_sodx_fifo.Value = (int)(_fifoDataSodx.CalculationOfFifo.Percent * 100);
                lbl_number_of_acq_in_sodx_fifo.Text = _dataAcquisitionCounter.ToString();
            }
        }
        #endregion


        #region ThreadAcquisitionLoop
        public void ThreadAcquisitionLoop()
        {
            sSignalData signalData = null;
            int timeout = 20, currentTimeout = 20;

            while (!_threadAcquisitionProcess.EventExitProcessThread.WaitOne(timeout))
            {
                //Debug.WriteLine("ThreadAquisitionLoop");
                lock (_fifoDataSodx)
                {
                    do
                    {
                        signalData = (sSignalData)_fifoDataSodx.Dequeue();
                        if ((_client != null) && (signalData != null) && (_saveFilteredData != null))
                        {
                            _saveFilteredData.WriteFile(signalData, _generalSettings.General.SeparatorCharacter);
                        }
                    } while (signalData != null);
                }
                if (_threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eStop].WaitOne(0))
                {
                    if (_saveFilteredData != null)
                    {
                        _saveFilteredData.CloseFiles();
                    }
                    _threadAcquisition = eThreadAcquisition.eStop;
                    this.Invoke(this.DisplaySodxAcquisitionDelegate, new object[] { this });
                }
                if ((_client != null) && (_threadAcquisitionProcess.EventUserList[(int)eThreadAcquisition.eRun].WaitOne(0)))
                {
                    if (_saveFilteredData != null)
                    {
                        _saveFilteredData.CloseFiles();
                    }
                    _saveFilteredData.OpenFiles(_generalSettings.General.DataDirectory);
                    _threadAcquisition = eThreadAcquisition.eRun;
                    this.Invoke(this.DisplaySodxAcquisitionDelegate, new object[] { this });
                }
                currentTimeout = (_fifoDataSodx.Count > 0) ? timeout : 0;
            }
            _threadAcquisitionProcess.EventExitProcessThreadDo.Set();
        }
        #endregion
        #region _OnFiltersRemove
        private void _OnFiltersRemove(object sender)
        {
            this.Invoke(new cIhmSelectingFilters.RemoveSelectingFiltersControlsHandler(cIhmSelectingFilters.RemoveSelectingFiltersControls), tbp_sodx.Controls, _selectingFilters);
        }
        #endregion
        #region _OnFiltersAdd
        private void _OnFiltersAdd(object sender)
        {
            Point newLocation = new Point(btn_sodx_execute.Location.X, btn_sodx_execute.Location.Y + btn_sodx_execute.Height);
            this.Invoke(new cIhmSelectingFilters.AddSelectingFiltersControlsHandler(cIhmSelectingFilters.AddSelectingFiltersControls), tbp_sodx.Controls, newLocation, _selectingFilters);
        }



        #endregion
        #region _OnError
        private void _OnError(object sender, cErrorEventArgs e)
        {
            if (e.Message.MessageType == eMessageType.Error)
            {
                lock (_errorList)
                {
                    _errorList.Add(e);
                }
                _threadGui.EventUserList[(int)enEventThreadGui.DisplayError].Set();
                Debug.WriteLine("->> {0} : Erreur {1}", sender.GetType().FullName.ToString(), e.Message.Text);
            }
        }
        #endregion
        #region Record Panel
        #region sEventActionProcessControl
        class sEventActionProcessControl
        {
            public eThreadAction Event = eThreadAction.None;
            public object Tag = null;
            public object TagExt = null;

            public sEventActionProcessControl(eThreadAction eventFifoGui)
            {
                Event = eventFifoGui;
                Tag = null;
            }
            public sEventActionProcessControl(eThreadAction eventFifoGui, object tag)
            {
                Event = eventFifoGui;
                Tag = tag;
            }
            public sEventActionProcessControl(eThreadAction eventFifoGui, object tag, object tagExt)
            {
                Event = eventFifoGui;
                Tag = tag;
                TagExt = tagExt;
            }
        }




        #endregion

        #region chk_enabled_trigger_CheckedChanged
        #endregion

        #region chk_auto_rearm_CheckedChanged
        #endregion

        #endregion

        #region  FocusClimbing
        private void FocusClimbing()
        {
            int zpos = _motion.GetPos('Z');       
            List<int> zpos_List = new List<int>();
            _motion.MoveTo('Z', -48000, false); 
            for (int i = 0; i < 1500; i++)
            {
                _motion.MoveTo('Z', -1);
                if (dataIntensityAverage != 0 )
                {
                    zpos = _motion.GetPos('Z');
                    zpos_List.Add(zpos);                       
                } 
            }
            _motion.MoveTo('Z', zpos_List[zpos_List.Count/2], false);  
        }
        #endregion
        #region btn_ClearAlarm_Click
        private void btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            if (!_motion.ClearAlarm())
                MessageBox.Show(_motion.GetErrorMsg());
        }
        #endregion

        private void btn_manual_mode_Click(object sender, EventArgs e)
        {
            grp_manual_buttons.Visible = !grp_manual_buttons.Visible;
        }

        private void btn_align_Click(object sender, EventArgs e)
        {
            if (tb_dieX.Text == "" || tb_dieY.Text == "")
            {
                MessageBox.Show("請先輸入die的邊長");
                return;
            }

            //轉正
            VisionCalibrator vc = new VisionCalibrator();
            die_side[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(Int32.Parse(tb_dieX.Text));
            die_side[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(Int32.Parse(tb_dieY.Text));
            die_side[2] = Constants.SCRIBE_LINE_WIDTH;
            int threshold = Int32.Parse(tbThreshold.Text);
            if (!_syn_op.DoAlignment(cur_img, threshold, ref die_side))
            {
                MessageBox.Show(_syn_op.Err_msg);
                return;
            }
            die_side[Constants.WAY_HORIZONTAL] = vc.Pixel2Um_X(die_side[Constants.WAY_HORIZONTAL]);
            die_side[Constants.WAY_VERTICAL] = vc.Pixel2Um_Y(die_side[Constants.WAY_VERTICAL]);
        }

        private void btn_trigger_Click(object sender, EventArgs e)
        {
            if ((_client != null) && (_client.DnldCommand != null))
            {
                if (_client.DnldCommand.IsBusyDownloadRaw)
                {
                    _client.DnldCommand.StopDownloadRaw();
                }
                else
                {
                    UInt32 ivalue = 0;
                    sSpectrumRaw spectrumRaw = new sSpectrumRaw();
                    if (UInt32.TryParse(ntb_dnld_first_channel.Text, out ivalue))
                    {
                        spectrumRaw.FirstChannel = ivalue;
                        if (UInt32.TryParse(ntb_dnld_number_of_channels.Text, out ivalue))
                        {
                            spectrumRaw.NumberOfChannels = ivalue;
                            spectrumRaw.SpectraId = (uint)eSpectraId.SpectraIdRawSpectrum;
                            _client.DnldCommand.StartDownloadRaw(spectrumRaw, -1);
                        }
                    }
                }
            }
        }
        private void ConnectMeasure()
        { 
            if (_client != null)
            {
                if (_generalSettings.General.IpAddress == "")
                {
                    btn_connection_ip_Click(null, null);
                }
                lock (_lockActionProcess)
                {
                    _threadAction = (_client.ClientIsConnected) ? eThreadAction.eClientDisconnect : eThreadAction.eClientConnect;
                    switch (_threadAction)
                    {
                        case eThreadAction.eClientConnect:
                            _threadActionProcess.EventUserList[(int)eThreadAction.eClientConnect].Set();
                            break;
                        case eThreadAction.eClientDisconnect:
                            _threadActionProcess.EventUserList[(int)eThreadAction.eClientDisconnect].Set();
                            break;
                    }
                }
            }
        }

        private void btn_connection_ip_Click(object sender, EventArgs e)
        {
            ConnectionIpForm frm = new ConnectionIpForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _client.IP = IPAddress.Parse(frm.ctrl_ip_address.Text);
                _generalSettings.General.IpAddress = frm.ctrl_ip_address.Text;
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.case)|*.case|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ParamMgr param = new ParamMgr();
                param.Read(openFileDialog1.FileName);
                tbThreshold.Text = param.ThresholdStr;
                die_side[0] = param.Width;
                die_side[1] = param.Height;
                die_side[2] = Constants.SCRIBE_LINE_WIDTH;
                tbThreshold.Text = param.Threshold.ToString();
                tb_dieX.Text = param.Width.ToString();
                tb_dieY.Text = param.Height.ToString();
                ImageFullPath = param.ImageFilePath;
                cur_img = hp.LoadImage(ImageFullPath);
            }
        }


        private void btn_find_angle_Click(object sender, EventArgs e)
        {
            double w=0, h=0, angle=0;
            int threshold = Int32.Parse(tbThreshold.Text);
            if (_syn_op.find_angle(cur_img, threshold, ref die_side, ref angle))
            {
                lb_die_side.Text = "邊長: " + w.ToString("0.###")
                    + " X " + h.ToString("0.###");
                lb_angle.Text = "角度: " + angle.ToString("0.####");

            }
            else
            {
                MessageBox.Show(_syn_op.Err_msg);
            }
        }

        private void btn_start_mea_Click(object sender, EventArgs e)
        {
            try
            {
                if (_client.ClientIsConnected)
                {

                    SaveFileDialog sfd_upload = new SaveFileDialog();
                    sfd_upload.Filter = "DATA file|*.data|TXT file|*.txt|所有檔案|*.*";
                    sfd_upload.Title = "Save a File";
                    sfd_upload.InitialDirectory = Application.StartupPath;
                    sfd_upload.RestoreDirectory = true;
                    DateTime dt = DateTime.Now;
                    string dateTimeFileName = string.Format("_{0:yy_MM_dd_HH_mm_ss}", dt);
                    sfd_upload.FileName = String.Format("{0}", dateTimeFileName);
                    sfd_upload.DefaultExt = "data";
                    if ((_client != null) && (_client.DnldCommand != null))
                    {
                        if ((_cprojectSettings != null) && (_cprojectSettings.Project != null))
                        {
                            if (sfd_upload.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                string strFilePath = sfd_upload.FileName.ToString();
                                _cprojectSettings.Project.DataDirectoryFilename = strFilePath;
                                _cprojectSettings.Project.DataDirectory = strFilePath.Substring(0, strFilePath.LastIndexOf("\\"));
                                _cprojectSettings.Project.Filename = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1);

                                _threadActionProcess.EventUserList[(int)eThreadAction.StartRecordDataSample].Set();

                                sw.Reset();//碼表歸零
                                sw.Start();//碼表開始計時
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //NOT USE YET
        }
    }
}

