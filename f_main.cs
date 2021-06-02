using System;
using Velociraptor.AddOn;
using Velociraptor.MyForm;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Net;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using MagicServerLibrary;
using MagicGraphicLibrary;
using MagicCommonLibrary;
using MagicAddOn;
using AddOn;
using System.Windows.Forms;
using Velociraptor.Form;
using System.Drawing.Imaging;
using Velociraptor.ImageProc;
using Avva.CameraFramework;
using log4net;
using log4net.Repository;
using OpenCvSharp.Extensions;
using OpenCvSharp;
using Point = System.Drawing.Point;
using static Velociraptor.SynOperation;

namespace Velociraptor
{
    //-------------------------------------------------------------------------------------------
    public partial class f_main : System.Windows.Forms.Form
    {
        #region Variable Declaration
        #region eThreadAction
        public enum eThreadAction
        {
            /// <summary>nothing to do</summary>
            None,
            /// <summary>client connect</summary>
            eClientConnect,
            /// <summary>client disconnect</summary>
            eClientDisconnect,
            /// <summary>find angle</summary>
            eFindAngle,
            /// <summary>do alignment</summary>
            eAlignment,
            /// <summary>do measure</summary>
            eManualMeasure,
            eAutoMeasure,
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
        #region eThreadMeasure
        enum eThreadMeasure
        {
            /// <summary>run acquisition</summary>
            eRun,
            /// <summary>in acquisition</summary>
            eData,
        }
        #endregion
        #region ImageProcessing
        private string ImageFullPath;
        bool isGarpping=false;
        Bitmap _cur_bitmap = null;
        IAvvaCamera basler = new BaslerCamera();
        AvvaCamera camera;
        #endregion
        #region Threads and events
        /// <summary>the current thread action</summary>
        eThreadAction _threadAction = eThreadAction.None;
        cClientCommunication _client = null;
        /// <summary>size of rx/tx ethernet buffer</summary>
        const int _rxBufferSizeOfClientSocket = 1024 * 1024 * 32;
        const int _txBufferSizeOfClientSocket = 1024 * 1024 * 32;
        /// <summary>_lock thread action process</summary>
        object _lockActionProcess = new object();
        /// <summary>thread action process</summary>
        public cThreadProcess _threadActionProcess = null;
        cThreadProcess _threadGui = null;
        cThreadProcess _threadMeasure = null;
        //public MyThread _threadActionProcess = null;
        //MyThread _threadGui = null;
        //MyThread _threadMeasure = null;
        //CCD Range
        sCCDRange _ccd_range = null;
        cGeneralSettings _generalSettings = null;
        // acquisition thread
        int _dataAcquisitionNumber = 0;
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
        private cQueueExt _fifoDataMeasure = null;
        //Data Format Fifo
        private const int _maxNumberOfBufferInFifoDataFormat = 64;
        private cQueueExt _fifoDataFormat = null;
        #endregion
        #region Control Update
        cControlUpdateEx _controlUpdate = null;
        sControlUpdateEx _clu_led_intensity = null;
        sControlUpdateEx _clu_number_of_peak = null;
        sControlUpdateEx _clu_frequency = null;
        sControlUpdateEx _clu_threshold = null;
        cControlUpdateEx.OnEventHandler _eventControlUpdateValueToText = null;
        cControlUpdateEx.OnEventHandler _eventcontrolUpdateTextToValue = null;
        #endregion
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
        #region delegate function for precitec
        delegate void InitDisplayDelegateHandler(System.Windows.Forms.Form form);
        InitDisplayDelegateHandler InitDisplayDelegate;

        delegate void InitDownloadDisplayDelegateHandler(System.Windows.Forms.Form form);
        InitDownloadDisplayDelegateHandler InitDownloadDisplayDelegate;

        delegate void DisplayStatisticsDelegateHandler(List<cClientStatistics> clientStatisticsList);
        DisplayStatisticsDelegateHandler DisplayStatisticsDelegate;

        delegate void DisplayConnectionStateDelegateHandler(cClientCommunication client);
        DisplayConnectionStateDelegateHandler DisplayConnectionStateDelegate;

        delegate void DisplayCommandDataDelegateHandler(cClsCommandData clsCommand);
        DisplayCommandDataDelegateHandler DisplayCommandDataDelegate;

        delegate void DisplaySpectraDelegateHandler(cDnldCommand dnldCommand);
        DisplaySpectraDelegateHandler DisplayRawSpectraDelegate;

        delegate void DisplayDataFormatDelegateHandler(cClientCommunication client);
        DisplayDataFormatDelegateHandler DisplayDataFormatDelegate;

        cClientSocket.OnClientConnectEventHandler _eventOnClientConnect = null;
        cClientSocket.OnClientDisconnectEventHandler _eventOnClientDisconnect = null;
        cClientCommunication.OnReceiveCommandDataEventHandler _eventOnUpdateCommandData = null;
        cClientCommunication.OnReceiveDataFormatEventHandler _eventOnUpdateDataFormat = null;
        cClientCommunication.OnUpdateIhmEventHandler _eventOnUpdateIhm = null;
        cClientCommunication.OnReceiveDataSampleEventHandler _eventOnUpdateDataSample = null;
        cClientCommunication.OnReceiveDataFormatEventHandler _eventOnUpdateDataFormatEntry = null;

        delegate void CloseFormDelegate(object sender, EventArgs e);
        CloseFormDelegate _eventCloseForm;
        List<cErrorEventArgs> _errorList = null;
        cErrorEventArgs.OnErrorEventHandler _eventOnError = null;
        #endregion
        #region cls_components

        CsvWriteFile _ccsvWriteFiles = new CsvWriteFile();
        #endregion
        #region measure settings
        private int _measure_distance;
        private bool is_advanced_mode = false;
        private SynOperation _syn_op;
        private DBKeeper _db;
        private string _measure_filename;
        public bool _in_trigger = false;
        private int _trigger_end = 0;
        private bool _cancelFormClosing = true;
        public bool startmeasure = false;
        public bool measureFinish = true;

        #endregion
        #region autofocus
        WaferLoadDelegate waferLoadDelegate;
        WaferLoadDelegate waferUnloadDelegate;
        SetMagDelegate toMagePosDelegate;
        #endregion
        #region Move, Alignment, Scan
        FindAngleDelegate findAngleDelegate;
        FindAngleDelegate alignmentFunc;
        object _image_lock = new object();

        ScanMoveDelegate scanMove1umFunc;
        ScanMoveDelegate scanMove5umFunc;
        MoveDelegate syncMoveFunc;
        MeasureDelegate measureFunc;
        eScanType _scan_type;

        #endregion
        #region wafer info
        WaferChuck chuck = new WaferChuck();
        private string _wafer_id;
        private int _wafer_type; //12 or 8
        private int _notch_idx;
        private int _die_row_count = 0;
        private int _die_col_count = 0;
        //die_side (um) 0:x邊長, 1:y邊長, 2:切割道寬度
        private double[] die_size = new double[3];
        private double[] _pos_keep = new double[3];
        #endregion
        #region Misc
        System.Timers.Timer timer;
        System.Timers.Timer timer1;
        System.Timers.Timer timer_measure;
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
        log4net.ILog _log;
        Thread splashThread;
        #endregion
        #endregion
        #region 主程式開關
        #region Constructor
        public f_main()
        {
            splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();

            InitializeComponent();
            try
            {
                _generalSettings = new cGeneralSettings(null, null);
                _generalSettings.Load();
                _errorList = new List<cErrorEventArgs>();
                #region Fifo Allocation
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
                _fifoDataMeasure = new cQueueExt(_maxNumberOfBufferInFifoDataSodx);
                _fifoDataMeasure.IdName = "Measurement Data";
                _fifoDataMeasure.OnError += _eventOnError;
                #endregion
                #region Delegate function assignment
                InitDisplayDelegate = new InitDisplayDelegateHandler(OnInitDisplay);
                DisplayCommandDataDelegate = new DisplayCommandDataDelegateHandler(DisplayCommandData);
                DisplayDataFormatDelegate = new DisplayDataFormatDelegateHandler(DisplayDataFormat);
                _eventOnClientConnect = new cClientSocket.OnClientConnectEventHandler(OnClientConnect);
                _eventOnClientDisconnect = new cClientSocket.OnClientDisconnectEventHandler(OnClientDisconnect);
                _eventOnUpdateCommandData = new cClientCommunication.OnReceiveCommandDataEventHandler(OnUpdateCommandData);
                _eventOnUpdateDataFormat = new cClientCommunication.OnReceiveDataFormatEventHandler(OnUpdateDataFormat);
                _eventOnUpdateDataSample = new cClientCommunication.OnReceiveDataSampleEventHandler(_OnUpdateDataSample);
                _eventOnUpdateDataFormatEntry = new cClientCommunication.OnReceiveDataFormatEventHandler(_OnUpdateDataFormatEntry);
                _eventOnError = new cErrorEventArgs.OnErrorEventHandler(_OnError);
                _eventCloseForm = new CloseFormDelegate(_OnCloseOnStart);
                _ccd_range = new sCCDRange(0, 0);
                #endregion
                #region Motion, Camera, Log Initialization
                ILoggerRepository repository = log4net.LogManager.CreateRepository("AvvaLaserGrooving");
                log4net.Config.XmlConfigurator.ConfigureAndWatch(repository
                    , new FileInfo(Path.Combine(Constants.appConfigFolder, "AvvaLaserGrooving.log4net.xml")));
                _log = log4net.LogManager.GetLogger("AvvaLaserGrooving", "AvvaMain");

                ILoggerRepository repository1 = log4net.LogManager.CreateRepository("AvvaCamera1");
                log4net.Config.XmlConfigurator.ConfigureAndWatch(repository1
                    , new FileInfo(Path.Combine(Constants.appConfigFolder, "AvvaCamera.log4net.xml")));
                log4net.ILog log_cam = log4net.LogManager.GetLogger("AvvaCamera1", "AvvaCamera");
                camera = new AvvaCamera(basler, new Mvotem0745("COM7"), new ILPSC("COM6"), log_cam);

                ILoggerRepository repository2 = log4net.LogManager.CreateRepository("AvvaMotion1");
                log4net.Config.XmlConfigurator.ConfigureAndWatch(repository2
                    , new FileInfo(Path.Combine(Constants.appConfigFolder, "AvvaMotion.log4net.xml")));
                log4net.ILog log_motion = log4net.LogManager.GetLogger("AvvaMotion1", "AvvaMotion");
                _syn_op = new SynOperation(Constants.appConfigFolder, camera, _log, log_motion);
                _syn_op.MotorOn();
                _syn_op.GoHome();                
                _syn_op.AsyncMove += OnAsyncMove;
                _syn_op.ScanParamSet += OnScanParamSet;
                _syn_op.OnError += OnSynOpError;
                #endregion
                #region synthesis operations initializations
                waferLoadDelegate = new WaferLoadDelegate(_syn_op.WaferLoad);
                waferUnloadDelegate = new WaferLoadDelegate(_syn_op.WaferUnload);
                toMagePosDelegate = new SetMagDelegate(_syn_op.ToMagPos);
                scanMove5umFunc = new ScanMoveDelegate(_syn_op.AsyncMove5um);
                scanMove1umFunc = new ScanMoveDelegate(_syn_op.AsyncMove1um);
                syncMoveFunc = new MoveDelegate(_syn_op.SyncMoveTo);
                measureFunc = new MeasureDelegate(_syn_op.MeasureScan);
                findAngleDelegate = new FindAngleDelegate(_syn_op.FindAngle);
                alignmentFunc = new FindAngleDelegate(_syn_op.Alignment);

                camera.ImageFileDirPath = _syn_op.SavingPath;
                camera.Open(_syn_op.IsSimulate);
                camera.IntstSet(0, tr_light.Value);
                camera.MaxMagSet();
                camera.ImageGrabbed += OnImageGrabbed;
                camera.ImageFiltered += OnImageFiltered;
                #endregion
                _db = new DBKeeper();
                _log.Info("Form construction finished");
                splashThread.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ExceptionDialog(ex,"應用初始化失敗");
                this.Close();
                Environment.Exit(0);
            }
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
            if (_client.DnldCommand.IsBusyDownloadRaw)
                _client.DnldCommand.StopDownloadRaw();
            #endregion
            #region start thread
            //start process thread 
            _threadActionProcess = new cThreadProcess("_threadActionProcess", Enum.GetValues(typeof(eThreadAction)).Length);
            _threadActionProcess.StartThread(new ThreadStart(ThreadLoop));
            //start display thread 
            _threadGui = new cThreadProcess("_threadGui", Enum.GetValues(typeof(enEventThreadGui)).Length);
            _threadGui.StartThread(new ThreadStart(ThreadGuiLoop));
            //start measurement triggered thread            
            _threadMeasure = new cThreadProcess("_threadMeasure", Enum.GetValues(typeof(eThreadMeasure)).Length);
            _threadMeasure.StartThread(new ThreadStart(ThreadMeasureLoop));

            _threadGui.EventUserList[(int)enEventThreadGui.InitDisplay].Set();
            _threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].Set();

            #endregion
            this.Size = new System.Drawing.Size(765, 745);
            panel2.Visible = false;
            CenterToScreen();
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
            tips.SetToolTip(this.btn_load, "開啟影像");
            tips.SetToolTip(this.btn_find_angle, "找角度");
            #endregion

            try
            {
                ConnectMeasure();

                Control.CheckForIllegalCrossThreadCalls = false;
                timer = new System.Timers.Timer(Constants.INTL_gui_update);//定時週期0.1秒
                timer.Elapsed += UpdateUIControls;//定時時間到的時候的回撥函式
                timer.AutoReset = true; //是否不斷重複定時器操作
                timer.Enabled = true;
                timer_measure = new System.Timers.Timer(Constants.INTL_DataSaveDelay);
                timer_measure.Elapsed += MeasureTimeout;
                timer_measure.AutoReset = false;

                GrabOn();
                _log.Debug("Camera Start Grabbing");
                btn_grab.Image = Properties.Resources.green;

                tbLight.Text = tr_light.Value.ToString();
                tbThreshold1.Text = tr_threshold.Value.ToString();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Form Load");
                this.Close();
            }
        }
        #endregion
        #region Form Closing
        private void f_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancelFormClosing)
            {
                _log.Debug("_cancelFormClosing with e.cancel=true");
                timer.Enabled = false;
                timer.Dispose();
                GrabOff();
                camera.Close();
                if ((_client != null) && (_client.ClientIsConnected))
                {
                    _client.TriggerStop();
                    _client.Close();
                }
                _cancelFormClosing = false;
                _threadActionProcess.EventUserList[(int)eThreadAction.eCloseApplication].Set();
                e.Cancel = true;
                return;
            }

            _log.Debug("f_main_FormClosing");
            #region _client
            if (_client != null)
            {
                _client.OnReceiveCommandData -= _eventOnUpdateCommandData;
                _client.OnReceiveDataFormat -= _eventOnUpdateDataFormatEntry;
                _client.OnReceiveDataSample -= _eventOnUpdateDataSample;
                _client.OnError -= _eventOnError;
                _client.OnUpdateIhm -= _eventOnUpdateIhm;
                _client.OnClientConnect -= _eventOnClientConnect;
                _client.OnClientDisconnect -= _eventOnClientDisconnect;
                _generalSettings.General.SodxCommand = _client.SelectOutputFormat;
                _generalSettings.Save();
                _client.Dispose();
                _client = null;
            }
            #endregion
            _syn_op.MotorOff();
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
            if (_controlUpdate != null) _controlUpdate.Dispose();
            #region _threadProcess
            if (_threadActionProcess != null)
            {
                _threadActionProcess.StopThread(500);
                _threadActionProcess.Dispose();
                _threadActionProcess = null;
            }
            #endregion
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
            double dTimeout = _tm.FlashTiming;
            short[,] sBuffer = null;
            int _timoutStatistics = 250, _timoutStatisticsValue = 0; //Display Statistics step 250 mms
            int _timoutDataSampleValue = 0;
            try
            {
                while (!_threadGui.EventExitProcessThread.WaitOne(20))
                {
                    //Debug.WriteLine("ThreadGuiLoop");
                    dTimeout = _tm.FlashTiming;
                    _timoutStatisticsValue += (int)dTimeout;
                    _timoutDataSampleValue += (int)dTimeout;

                    #region InitDisplay
                    if (_threadGui.EventUserList[(int)enEventThreadGui.InitDisplay].WaitOne(0))
                    {
                        this.Invoke(this.InitDisplayDelegate, new object[] { this });
                    }
                    #endregion
                    #region Display Download Display
                    if (_threadGui.EventUserList[(int)enEventThreadGui.InitDownloadDisplay].WaitOne(0))
                    {
                        this.Invoke(this.InitDownloadDisplayDelegate, new object[] { this });
                        //_curve_v2.IsVisible = _cursor_raw_v2.Visible = false;
                        //_curve_v3.IsVisible = _cursor_raw_v3.Visible = false;
                    }
                    #endregion
                    #region Display Client Connection
                    if (_threadGui.EventUserList[(int)enEventThreadGui.DisplayConnectionState].WaitOne(0))
                    {
                        this.Invoke(this.DisplayConnectionStateDelegate, new object[] { _client });
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
                }
                _threadGui.EventExitProcessThreadDo.Set();
            }
            catch (Exception)
            {
                if (_threadGui != null) _threadGui.EventExitProcessThreadDo.Set();
            }
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
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.eCloseApplication].WaitOne(0))
                    {
                        _log.Debug("_threadActionProcess EventExitProcessThread");
                        if (_threadMeasure != null)
                        {
                            _threadMeasure.StopThread(500);
                            _threadMeasure.Dispose();
                            _threadMeasure = null;
                        }
                        if (_threadGui != null)
                        {
                            _threadGui.StopThread(500);
                            _threadGui.Dispose();
                            _threadGui = null;
                        }
                        _threadActionProcess.EventExitProcessThread.Set();
                        continue;
                    }
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
                                        _generalSettings.General.Sensor.NumberOfFibers = _client.FibersParameters.NumberOfFibersUsed;
                                        _generalSettings.General.SodxCommand.Signal.AltitudePeak1 = true;//這邊需要收的資料須打開才能收的到
                                        _generalSettings.General.SodxCommand.Signal.IntensityLevelPeak1 = true;
                                        _generalSettings.General.SodxCommand.Signal.IntensityRawPeak1 = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.SampleCounter = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.StartPositionX = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.StartPositionY = true;
                                        _generalSettings.General.SodxCommand.GlobalSignal.StartPositionZ = true;//這邊需要收的資料須打開才能收的到
                                        _client.SelectOutputFormat = _generalSettings.General.SodxCommand;
                                        _client.TriggerStop();
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
                                            sSpectrumRaw spectrumRaw = new sSpectrumRaw();
                                            spectrumRaw.FirstChannel = Constants.PREC_FirstChannel;
                                            spectrumRaw.NumberOfChannels = Constants.PREC_NumberOfChannels;
                                            spectrumRaw.SpectraId = (uint)eSpectraId.SpectraIdRawSpectrum;
                                            _client.DnldCommand.StartDownloadRaw(spectrumRaw, -1);
                                        }
                                    }
                                    break;
                                case eThreadAction.eClientDisconnect:
                                    _client.Close();
                                    _threadAction = eThreadAction.None;
                                    break;
                            }
                        }
                    }
                    #endregion  
                }
                _threadActionProcess.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, string.Format("Error : {0}.{1}(2)"
                              , this.GetType().FullName.ToString()
                              , System.Reflection.MethodInfo.GetCurrentMethod().Name
                              , Thread.CurrentThread.ManagedThreadId));
            }
            finally
            {
                this._eventCloseForm?.Invoke(null, null);
            }
        }
        #endregion
        #region ThreadMeasureLoop
        public void ThreadMeasureLoop()
        {
            int timeout = 20;
            _ccsvWriteFiles = new CsvWriteFile();
            while (!_threadMeasure.EventExitProcessThread.WaitOne(timeout))
            {
                //Debug.WriteLine("ThreadMeasureLoop");              
                if (_threadMeasure.EventUserList[(int)eThreadMeasure.eData].WaitOne(0))
                {
                    if (_fifoDataSample != null)
                    {
                        lock (_fifoDataSample)
                        {
                            while (_fifoDataSample.Count > 0)
                            {
                                cDataSample dataSample = (cDataSample)_fifoDataSample.Dequeue();    //Display Data Sample
                                if (dataSample.FirstDataAfterTriggerStart) startmeasure = true;
                                if (_ccsvWriteFiles != null && startmeasure == true)
                                {
                                    if (_scan_type==eScanType.Scan1Um)
                                    {
                                        int line_no = 4 - (_dataAcquisitionNumber-1) / _measure_distance;
                                        _ccsvWriteFiles.Add(dataSample.SignalDataList, line_no);
                                    }
                                    else
                                    {
                                        _ccsvWriteFiles.Add(dataSample.SignalDataList, 0);
                                    }
                                    _dataAcquisitionNumber--;
                                }                             
                                if ((_dataAcquisitionNumber <= 0 || _syn_op.IsSimulate) 
                                    && startmeasure == true)
                                {
                                    SaveMeasureData();                                    
                                    Process profiler = new Process();
                                    profiler.StartInfo.FileName = "ThickInspector.exe";
                                    if (_threadAction==eThreadAction.eAutoMeasure)
                                        profiler.StartInfo.Arguments = Path.GetDirectoryName( _measure_filename); 
                                    else
                                        profiler.StartInfo.Arguments = _measure_filename;
                                    profiler.Start();
                                }
                            }
                        }
                    } 
                    else if (_syn_op.IsSimulate)
                    {
                        SaveMeasureData();
                    }
                }
                if ((_client != null||_syn_op.IsSimulate) && (_threadMeasure.EventUserList[(int)eThreadMeasure.eRun].WaitOne(0)))
                {
                    _ccsvWriteFiles.Open(Path.Combine(_syn_op.SavingPath, _measure_filename+".data"), _scan_type);
                    timer_measure.Enabled = true;
                    _in_trigger = true;
                }
            }
            _threadMeasure.EventExitProcessThreadDo.Set();
        }
        #endregion
        #endregion
        #region CLS event
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
        #region OnInitDisplay
        private void OnInitDisplay(System.Windows.Forms.Form form)
        {
            _eventControlUpdateValueToText = new cControlUpdateEx.OnEventHandler(OnControlUpdateValueToText);
            _eventcontrolUpdateTextToValue = new cControlUpdateEx.OnEventHandler(OnControlUpdateTextToValue);
            _controlUpdate = new cControlUpdateEx(_eventcontrolUpdateTextToValue, _eventControlUpdateValueToText, Color.LemonChiffon);
            _controlUpdate.ControlUpdateList.Clear();
            _threadGui.EventUserList[(int)enEventThreadGui.DisplaySampleRate].Set();
            Invalidate();
        }
        #endregion
        #region -OnUpdateDataSample
        /// <summary>Event receive new data sample</summary>
        /// <param name="clsCommand"> The <see cref="cDataSample"/> instance containing the data sample.</param>
        private void _OnUpdateDataSample(cDataSample dataSample)
        {
            if (_in_trigger && (_fifoDataSample != null) && (dataSample != null))
            {
                lock (_fifoDataSample)
                {
                    _fifoDataSample.Enqueue(dataSample);
                }
                _threadMeasure.EventUserList[(int)eThreadMeasure.eData].Set();
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
                        Invoke((Action)(() => { numericTextBox.SelectAll(); }));
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, string.Format("Error : {0}.{1}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name));
            }
        }
        #endregion
        #region DisplayCommandData
        private void DisplayCommandData(cClsCommandData clsCommand)
        {
            _log.Debug("DisplayCommandData");

            if ((clsCommand != null) && (clsCommand.ErrorEventArgs == null))
            {
                switch (clsCommand.CommandList)
                {
                    //Led Intensity
                    case eCommandList.LAI:
                        if (_clu_led_intensity != null)
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_led_intensity, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        break;
                    //Free Sample Rate
                    case eCommandList.SHZ:
                        if (_clu_frequency != null)
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_frequency, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        break;
                    //Number Of Peaks
                    case eCommandList.NOP:
                        if (_clu_number_of_peak != null)
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_number_of_peak, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
                        break;
                    //Threshold
                    case eCommandList.THR:
                        if (_clu_threshold != null)
                            this.Invoke(new cIhmUpdateControl.UpdateTextHandler(cIhmUpdateControl.UpdateText), _clu_threshold, string.Format("{0}", Convert.ToInt32(clsCommand.Value)), false, true, true);
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
        #region DisplayDataFormat
        private void DisplayDataFormat(cClientCommunication client)
        {
            _log.Debug("DisplayDataFormat");
        }
        #endregion 
        private void _OnError(object sender, cErrorEventArgs e)
        {
            try
            {
                if (e.Message.MessageType == eMessageType.Error)
                {
                    _log.Debug(String.Format("->> {0} : Error {1}"
                            , sender.GetType().FullName.ToString(), e.Message.Text));
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion
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
        #region Set_EncoderParameter
        private bool Set_EncoderParameter(int StartPos, float TrigInterval, int TrigNum)
        {
            #region set triggerParameter
            _client.TriggerStop();
            int StopPos = (int)(StartPos + TrigInterval * (TrigNum - 1));//TrigNum代表一行的點個數
            bool SelectEncoderTriggerSource = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SelectEncoderTriggerSource, 1);
            bool EnableTriggerDuringReturnMovement = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EnableTriggerDuringReturnMovement, 1);
            bool ChooseAxis = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.ChooseAxis, 0);
            bool EndlessRountripTrigger = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EndlessRountripTrigger, 0);
            bool SetStartPosition = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStartPosition, StartPos);
            bool SetStopPosition = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStopPosition, StopPos);
            bool SetTriggerInterval = _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetTriggerInterval, (float)TrigInterval);          
            if (!(_client.ClientIsConnected && EnableTriggerDuringReturnMovement && ChooseAxis
                && EndlessRountripTrigger && SetStopPosition && SetTriggerInterval && SetStartPosition
                && SelectEncoderTriggerSource)) return false;
            _trigger_end = StopPos;
            _client.TriggerEach();
            return true;
            #endregion
        }
        #endregion
        #region AutoFocus
        private void DoWaferLoad()
        {
            OpButtonFreeze();
            waferLoadDelegate.BeginInvoke(new AsyncCallback(WaferLoad_Callback)
                                        , waferLoadDelegate);
            _log.Debug("DoAutoFocus:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void DoWaferUnload()
        {
            OpButtonFreeze();
            waferUnloadDelegate.BeginInvoke(new AsyncCallback(WaferLoad_Callback)
                                        , waferLoadDelegate);
            _log.Debug("DoAutoFocus:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void DoSetMag(eMagType mag_type)
        {
            OpButtonFreeze();
            toMagePosDelegate.BeginInvoke(mag_type
                 , new AsyncCallback(SetMag_Callback)
                 , toMagePosDelegate);
            _log.Debug("DoAutoFocus:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        #endregion
        #region FindAngle, Alignment, Measure
        private void DoFindAngle()
        {
            btn_find_angle.Enabled = false;

            VisionCalibrator vc = new VisionCalibrator();
            die_size[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(die_size[Constants.WAY_HORIZONTAL]);
            die_size[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(die_size[Constants.WAY_VERTICAL]);
            die_size[2] = Constants.SCRIBE_LINE_WIDTH;
            Bitmap map;
            lock (_image_lock)
            {
                map = new Bitmap(_cur_bitmap);
            }
            findAngleDelegate.BeginInvoke(map, die_size
                             , int.Parse(tbThreshold1.Text)
                             , new AsyncCallback(FindAngle_Callback), findAngleDelegate);
            _log.Debug("DoFindAngle:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void DoAlignment()
        {
            GrabOn();
            DoSetMag(eMagType.MinMag);
            OpButtonFreeze();

            VisionCalibrator vc = new VisionCalibrator();
            die_size[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(die_size[Constants.WAY_HORIZONTAL]);
            die_size[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(die_size[Constants.WAY_VERTICAL]);
            die_size[2] = Constants.SCRIBE_LINE_WIDTH;

            Bitmap map;
            lock (_image_lock)
            {
                map = new Bitmap(_cur_bitmap);
            }
            alignmentFunc.BeginInvoke(map, die_size
                             , int.Parse(tbThreshold1.Text), new AsyncCallback(Alignment_Callback), alignmentFunc);
            _log.Debug("DoAlignment:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void DoMeasure(List<string> f_list, List<PointF> p_list)
        {
            GrabOn();
            OpButtonFreeze();
            Bitmap map;
            lock (_image_lock)
            {
                map = new Bitmap(_cur_bitmap);
            }
            measureFunc.BeginInvoke(f_list, p_list, _scan_type, _measure_distance
                                  , map, die_size, int.Parse(tbThreshold1.Text)
                                  , new AsyncCallback(Measure_Callback), measureFunc);
        }
        private void OpButtonFreeze()
        {
            grp_op.Enabled = false;
            grp_move.Enabled = false;
        }
        #endregion
        #region callback
        private void OnSynOpError(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                if ((startmeasure || _in_trigger)&& _ccsvWriteFiles.IsOpen)
                {
                    _ccsvWriteFiles.Close();
                }
                _log.Debug("OnSynOpError BeginInvoke:" + Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(OnSynOpError), sender, e);

                return;
            }
            SynOpErrorArgs error = (SynOpErrorArgs)e;
            ExceptionDialog(error.Ex, error.Message);
        }
        private void OnAsyncMove(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                _log.Debug("OnAsyncMove InvokeRequired: " + Thread.CurrentThread.ManagedThreadId);
                Invoke(new EventHandler(OnAsyncMove), sender, e);
                _log.Debug("OnAsyncMove InvokeRequired Finished: " + Thread.CurrentThread.ManagedThreadId);
                return;
            }

            _log.Debug("OnAsyncMove: " + Thread.CurrentThread.ManagedThreadId);
            MoveEventArgs moveEventArgs;
            moveEventArgs = (MoveEventArgs)e;
            _syn_op.AsyncMoveTo(moveEventArgs.Axis, moveEventArgs.Position, moveEventArgs.Relative);
        }
        private void OnImageGrabbed(Object sender, EventArgs e)
        {
            AvvaCamera camera = sender as AvvaCamera;

            if (InvokeRequired)
            {
                //_log.Debug("In OnImageGrabbed BeginInvoke:"+Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(OnImageGrabbed), sender, e);
                return;
            }

            if (camera.CameraState == AvvaCamera.EAvvaCameraState.Closed) return;

            //_log.Debug("In OnImageGrabbed:" + Thread.CurrentThread.ManagedThreadId.ToString());
            if (camera.ImageData != null)
            {
                if (!isGarpping) return;
                //Picture Box==
                bool badImageData = false;

                Bitmap bitmap = new Bitmap(camera.ImageWidth, camera.ImageHeight, PixelFormat.Format32bppRgb);
                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite, bitmap.PixelFormat);
                IntPtr intPtr = bmpData.Scan0;

                try
                {
                    camera.ConvertImage(bmpData.Stride, intPtr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    badImageData = true;
                }

                bitmap.UnlockBits(bmpData);

                if (badImageData == true) return;

                Bitmap bitmapOld = pic_camera.Image as Bitmap;

                lock (_image_lock)
                {
                    _cur_bitmap = bitmap;
                }
                pic_camera.Image = bitmap;
                //if (is_advanced_mode)
                //{
                //    using (Graphics g = Graphics.FromImage(pic_camera.Image))
                //    {
                //        Pen pen = new Pen(Color.SkyBlue, 4);

                //        g.DrawLine(pen, 0, camera.ImageHeight / 2 - 1, camera.ImageWidth, camera.ImageHeight / 2 - 1);
                //        g.DrawLine(pen, camera.ImageWidth / 2 - 1, 0, camera.ImageWidth / 2 - 1, camera.ImageHeight);

                //        g.DrawEllipse(pen, camera.ImageWidth / 2 - 16 - 1, camera.ImageHeight / 2 - 16 - 1, 32, 32);
                //    }
                //}

                bitmapOld?.Dispose();

                if (isGarpping == true)
                    camera.ImageData = null;
            }
        }
        private void OnImageFiltered(Object sender, EventArgs e)
        {
            AvvaCamera camera = sender as AvvaCamera;

            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler(OnImageFiltered), sender, e);

                return;
            }

            if (camera.ImageData != null)
            {
                Mat mat = new OpenCvSharp.Mat(camera.ImageHeight, camera.ImageWidth, MatType.CV_8UC4);

                try
                {
                    camera.ConvertImage((int)mat.Step(), mat.DataStart);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    mat.Dispose();
                    return;
                }

                _syn_op.ImgMat = mat;

                //if (isAutoLighting == true)
                //{
                //    ColorHistShow((Mat)image);
                //}

                _syn_op.imageFilterDone.Set();
            }
        }
        private void OnScanParamSet(Object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                _log.Debug("OnScanParamSet InvokeRequired: " + Thread.CurrentThread.ManagedThreadId);
                Invoke(new EventHandler(OnScanParamSet), sender, e);

                return;
            }
            _log.Debug("OnScanParamSet: " + Thread.CurrentThread.ManagedThreadId);

            MoveEventArgs m_arg = (MoveEventArgs)e;
            _client.SetEncoderCounters(eEncoderId.Encoder_X, eEncoderFunc.SetPositionImmediately, _syn_op.GetPos('X'));
            _client.SetEncoderCounters(eEncoderId.Encoder_Y, eEncoderFunc.SetPositionImmediately, _syn_op.GetPos('Y'));
            _client.SetEncoderCounters(eEncoderId.Encoder_Z, eEncoderFunc.SetPositionImmediately, _syn_op.GetPos('Z'));
            _dataAcquisitionNumber = _measure_distance / _syn_op.TriggerInterval;
            if (_scan_type == eScanType.Scan1Um)
                _dataAcquisitionNumber *= 5;
            _fifoDataSample.CalculationOfFifo.Reset();
            _client.ClearDataSampleFifo();

            _syn_op.EncoderParamSetOk = Set_EncoderParameter((int)m_arg.Position[0], 1, _dataAcquisitionNumber);
            _measure_filename = _syn_op.ScanFileName;
            if (_syn_op.EncoderParamSetOk || _syn_op.IsSimulate)
                _threadMeasure.EventUserList[(int)eThreadMeasure.eRun].Set();
            else
                ExceptionDialog("設定量測trigger失敗");
            _syn_op.EncoderSet.Set();
        }
        private void SyncMove_Callback(IAsyncResult result)
        {
            MoveDelegate func = (MoveDelegate)result.AsyncState;
            func.EndInvoke(result);
            _log.Debug("SyncMove_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            GroupMoveEnable(true);
        }
        private void WaferLoad_Callback(IAsyncResult result)
        {
            try
            {
                WaferLoadDelegate func = (WaferLoadDelegate)result.AsyncState;
                func.EndInvoke(result);
                _log.Debug("WaferLoad_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "WaferLoad_Callback");
            }
            OpFreeze_Done(this, EventArgs.Empty);
        }
        private void SetMag_Callback(IAsyncResult result)
        {
            try
            {
                SetMagDelegate func = (SetMagDelegate)result.AsyncState;
                func.EndInvoke(result);
                _log.Debug("MagSet_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "MagSet_Callback");
            }
            OpFreeze_Done(this, EventArgs.Empty);
        }
        private void FindAngle_Callback(IAsyncResult result)
        {
            _threadAction = eThreadAction.None;
            try
            {
                FindAngleDelegate func = (FindAngleDelegate)result.AsyncState;
                func.EndInvoke(result);
                FindAngle_Done(this, EventArgs.Empty);
                _log.Debug("FindAngle_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "FindAngle_Callback");
            }
            Invoke((MethodInvoker)delegate { btn_find_angle.Enabled = true; });
        }
        private void FindAngle_Done(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                _log.Debug("In FindAngle_Done BeginInvoke:" + Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(FindAngle_Done), sender, e);
                return;
            }

            lb_die_side1.Text = "邊長: " + _syn_op.EstimatedDieSide[0].ToString("0.#")
                + " X " + _syn_op.EstimatedDieSide[1].ToString("0.#");
            lb_angle1.Text = "角度: " + _syn_op.AngleAverage.ToString("0.####");
            _log.Debug("ScanMove_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            Bitmap bmp;
            lock (_image_lock)
            {
                bmp = _cur_bitmap.Clone(
                            new Rectangle(0, 0, _cur_bitmap.Width, _cur_bitmap.Height)
                            , PixelFormat.Format24bppRgb);
            }
            _syn_op.Draw(ref bmp);
            pic_camera.Image = bmp;
        }
        private void OpFreeze_Done(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OpFreeze_Done), sender, e);
                _log.Debug("OpFreeze_Done InvokeRequired:" + Thread.CurrentThread.ManagedThreadId);
                return;
            }
            _log.Debug("OpFreeze_Done:" + Thread.CurrentThread.ManagedThreadId);
            grp_op.Enabled = true;
            grp_move.Enabled = true;
        }
        private void Alignment_Callback(IAsyncResult result)
        {
            _threadAction = eThreadAction.None;
            try
            {
                FindAngleDelegate func = (FindAngleDelegate)result.AsyncState;
                func.EndInvoke(result);
                DoSetMag(eMagType.MaxMag);
                _log.Debug("Alignment_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Alignment_Callback");
            }
            OpFreeze_Done(this, EventArgs.Empty);
        }
        private void Measure_Callback(IAsyncResult result)
        {
            try
            {
                MeasureDelegate func = (MeasureDelegate)result.AsyncState;
                func.EndInvoke(result);
                _log.Debug("Measure_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Measure_Callback");
            }
            OpFreeze_Done(this, EventArgs.Empty);
        }
        private void MeasureTimeout(object sender, EventArgs e)
        {
            if (startmeasure||_in_trigger) SaveMeasureData();
        }       
        private void SaveMeasureData()
        {
            timer_measure.Enabled = false;
            _in_trigger = false;
            startmeasure = false;
            if (_syn_op.IsSimulate)
            {
                _log.Debug("SaveMeasureData:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            else
            {
                _ccsvWriteFiles.Save(_syn_op.DataDirection, (int)_syn_op.GetPos('Z'));
                _client.TriggerStop();
            }
            _ccsvWriteFiles.Close();
            _syn_op.DataSaved.Set();

            Process profiler = new Process();
            profiler.StartInfo.FileName = "ThickInspector.exe";
            if (_threadAction == eThreadAction.eAutoMeasure)
                profiler.StartInfo.Arguments = Path.GetDirectoryName(_measure_filename);
            else
                profiler.StartInfo.Arguments = _measure_filename;
            profiler.Start();
        }
        private void ScanMove_Callback(IAsyncResult result)
        {
            ScanMoveDelegate func = (ScanMoveDelegate)result.AsyncState;
            func.EndInvoke(result);
            _log.Debug("ScanMove_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void UpdateUIControls(object sender, EventArgs e)
        {
            ntb_x_cur_motorpos.Text = _syn_op.GetPos('X').ToString();
            ntb_y_cur_motorpos.Text = _syn_op.GetPos('Y').ToString();
            ntb_z_cur_motorpos.Text = _syn_op.GetPos('Z').ToString();
            ntb_r_cur_motorpos.Text = _syn_op.GetPos('R').ToString();
            if (isGarpping) btn_grab.Image = Properties.Resources.green;
            else btn_grab.Image = Properties.Resources.red; ;
        }
        private void GroupMoveEnable(bool toEnabled)
        {
            Invoke((MethodInvoker)delegate
            {
                grp_move.Enabled = toEnabled;
            });
        }
        #endregion
        #region Sync Move emulating function
        private void DoSyncMove(char[] axis_char, double[] distance, bool isRelative = true)
        {
            _log.Debug("DoSyncMove:" + Thread.CurrentThread.ManagedThreadId.ToString());
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis_char, distance, isRelative);
            syncMoveFunc.BeginInvoke(moveEventArgs
                , new AsyncCallback(SyncMove_Callback), syncMoveFunc);
            GroupMoveEnable(false);
        }
        private void DoSyncMove(char axis_char, double distance, bool isRelative = true)
        {
            _log.Debug("DoSyncMove:" + Thread.CurrentThread.ManagedThreadId.ToString());
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis_char, distance, isRelative);
            syncMoveFunc.BeginInvoke(moveEventArgs
                , new AsyncCallback(SyncMove_Callback), syncMoveFunc);
            GroupMoveEnable(false);
        }
        #endregion
        #region btn_Click_event
        #region 運動控制
        #region btn_origin_return_Click
        private void btn_origin_return_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.GoHome();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Main");
            }
        }
        #endregion
        #region btn_PosingStop_Click
        private void btn_PosingStop_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.StopMove();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Main");
            }
        }
        #endregion
        #region btn measurement related
        private void btn_find_angle_Click(object sender, EventArgs e)
        {
            _threadAction = eThreadAction.eFindAngle;
            DoFindAngle();
        }
        private void btn_align_Click(object sender, EventArgs e)
        {
            _threadAction = eThreadAction.eAlignment;
            DoAlignment();
        }
        private void btn_manual_mea_Click(object sender, EventArgs e)
        {
            if (!_syn_op.IsSimulate)
            {
                if (!_client.ClientIsConnected)
                {
                    MessageBox.Show("量測相機未連線，請先連結相機");
                    return;
                }
                if ((_client == null) && (_client.DnldCommand == null))
                {
                    MessageBox.Show("量測相機初始化失敗，請重新啟動系統");
                    return;
                }
            }
            SaveFileDialog sfd_upload = new SaveFileDialog();
            sfd_upload.Filter = "DATA file|*.data";
            sfd_upload.Title = "Save a File";
            sfd_upload.InitialDirectory = _syn_op.SavingPath;
            sfd_upload.RestoreDirectory = true;
            DateTime dt = DateTime.Now;
            string dateTimeFileName = string.Format("_{0:yy_MM_dd_HH_mm_ss}", dt);
            sfd_upload.FileName = dateTimeFileName;
            sfd_upload.DefaultExt = "data";
            if (sfd_upload.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            _measure_filename = sfd_upload.FileName;

            grp_op.Enabled = false;
            grp_move.Enabled = false;

            VisionCalibrator vc = new VisionCalibrator();
            die_size[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(die_size[Constants.WAY_HORIZONTAL]);
            die_size[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(die_size[Constants.WAY_VERTICAL]);
            die_size[2] = Constants.SCRIBE_LINE_WIDTH;

            PointF pos = new PointF((float)_syn_op.GetPos('X')
                                  , (float)_syn_op.GetPos('Y'));
            List<string> f_list = new List<string> { _measure_filename };
            List<PointF> p_list = new List<PointF> { pos };
            _log.Debug("DoMeasure:" + Thread.CurrentThread.ManagedThreadId.ToString());
            _in_trigger = true;
            _threadAction = eThreadAction.eManualMeasure;
            DoMeasure(f_list, p_list);
        }
        private void btn_auto_measurement(object sender, EventArgs e)
        {
            if (!_syn_op.IsSimulate)
            {
                if (!_client.ClientIsConnected)
                {
                    MessageBox.Show("量測相機未連線，請先連結相機");
                    return;
                }
                if ((_client == null) && (_client.DnldCommand == null))
                {
                    MessageBox.Show("量測相機初始化失敗，請重新啟動系統");
                    return;
                }
            }
            try
            {
                VisionCalibrator vc = new VisionCalibrator();
                die_size[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(die_size[Constants.WAY_HORIZONTAL]);
                die_size[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(die_size[Constants.WAY_VERTICAL]);
                die_size[2] = Constants.SCRIBE_LINE_WIDTH;

                _threadAction = eThreadAction.eAutoMeasure;
                _threadActionProcess.EventUserList[(int)eThreadAction.eFindAngle].Set();
                AutoParamsForm form = new AutoParamsForm();
                if (form.ShowDialog() != DialogResult.OK) return;

                grp_op.Enabled = false;
                grp_move.Enabled = false;

                _wafer_id = form.tb_wafer_id.Text;
                _notch_idx = form.cmb_notch.SelectedIndex;
                _die_row_count = int.Parse(form.tb_row_count.Text);
                _die_col_count = int.Parse(form.tb_col_count.Text);
                int pts_cnt = form.cmb_mea_points.SelectedIndex;

                DateTime dt = DateTime.Now;
                string dt_str = string.Format("_{0:yy_MM_dd_HH_mm}", dt);
                _wafer_id += dt_str;
                string path = Path.Combine(_syn_op.SavingPath, _wafer_id);
                Directory.CreateDirectory(path);

                DBKeeper.SCAN_DATA data = new DBKeeper.SCAN_DATA();
                data.wafer_id = _wafer_id;
                data.points_cnt = pts_cnt * 4 + 1;
                data.scan_type = _scan_type == eScanType.Scan1Um ? 1 : 5;
                data.notch_way = form.cmb_notch.SelectedIndex;
                data.scan_ok = 0;
                List<Point> _mea_pts = new List<Point>();
                List<PointF> _mea_pos;

                int r = (_die_row_count % 2 == 0) ? 1 : 0;
                int c = (_die_col_count % 2 == 0) ? 1 : 0;
                _mea_pts.Add(new Point(c, r));
                if (pts_cnt > 0)
                {
                    r = int.Parse(form.tb_mea_row1.Text);
                    c = int.Parse(form.tb_mea_col1.Text);
                    if (r > _die_row_count / 2 || c > _die_col_count / 2)
                    {
                        MessageBox.Show("指定量測的die位置，超出晶圓範圍");
                        return;
                    }
                    data.row1 = r;
                    data.col1 = c;
                    _mea_pts.Add(new Point(c, r));
                    _mea_pts.Add(new Point(-c, r));
                    _mea_pts.Add(new Point(-c, -r));
                    _mea_pts.Add(new Point(c, -r));
                    if (pts_cnt > 1)
                    {
                        r = int.Parse(form.tb_mea_row2.Text);
                        c = int.Parse(form.tb_mea_col2.Text);
                        if (r > _die_row_count / 2 || c > _die_col_count / 2)
                        {
                            MessageBox.Show("指定量測的die位置，超出晶圓範圍");
                            return;
                        }
                        data.row2 = r;
                        data.col2 = c;
                        _mea_pts.Add(new Point(c, -r));
                        _mea_pts.Add(new Point(c, r));
                        _mea_pts.Add(new Point(-c, r));
                        _mea_pts.Add(new Point(-c, -r));
                    }
                }
                _mea_pos = _syn_op.TransformDiePos(_die_row_count, _die_col_count, _mea_pts);
                _measure_distance = Constants.AutoMeasureDistance;
                List<string> f_list = new List<string>();
                //full pathname = data directory/wafer_id_datetime/DataSet_n.data
                for (int i = 0; i < _mea_pos.Count; i++)
                    f_list.Add(Path.Combine(path, "DataSet_" + i.ToString()));
                DoMeasure(f_list, _mea_pos);
                _db.Insert(data);
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Auto Measurement");
            }
        }
        #endregion
        #region btn_move_Click
        private void btn_move_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.Text;
            char axis = Char.ToUpper(name[0]);
            try
            {
                int move_distance = (axis == 'Z')
                    ? int.Parse(btn_move_distance_z.Text)
                    : int.Parse(btn_move_distance.Text);
                if (name[1] == '-') move_distance = -move_distance;
                DoSyncMove(axis, move_distance);
                _log.Debug("btn_move_Click finished:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Move" + name);
            }
        }
        private void btn_moveR_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.Text;
            try
            {
                int move_distance = int.Parse(btn_move_distance_r.Text);
                if (name == "CCW") move_distance = -move_distance;
                DoSyncMove('R', move_distance);
                _log.Debug("btn_move_Click finished:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Move" + name);
            }
        }
        #endregion
        #region btn_JOG__Click 
        private void btn_JOG_Positive_Start_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.JogY(true);
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "JOG+");
            }
        }
        private void btn_JOG_Negative_Start_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.JogY(true, false);
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "JOG-");
            }
        }
        private void btn_JOG_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.JogY(false);
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "JOG Stop");
            }
        }
        #endregion
        #region btn_load/unload_wafer_Click
        private void btn_load_wafer_Click(object sender, EventArgs e)
        {
            WaferInfo wafer = new WaferInfo();
            WaferBasicForm w_form = new WaferBasicForm(wafer);
            if (w_form.DialogResult != DialogResult.OK) return;

            die_size[0] = wafer.Die_sizeX;
            die_size[1] = wafer.Die_sizeY;
            _measure_distance = wafer.Measure_distance;
            _scan_type = wafer.Scan_type;
            _wafer_type = wafer.Wafer_type;
            try
            {
                if (_wafer_type == 12) chuck.Set_12inchWafer();
                else chuck.Set_8inchWafer();
                MessageBox.Show("即將開始載入wafer，請確認wafer已經放好");
                chuck.PressWafer();
                DoWaferLoad();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Load Wafer");
            }
        }
        private void btn_unload_wafer_Click(object sender, EventArgs e)
        {
            try
            {
                DoWaferUnload();
                chuck.ReleaseWafer();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Unload Wafer");
            }
        }
        #endregion
        #endregion
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
        private void btn_advanced_mode_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
            if (panel2.Visible)
                this.Size = new System.Drawing.Size(1173, 745);
            else
                this.Size = new System.Drawing.Size(765, 745);
            CenterToScreen();
        }

        #region btn_move_distance
        private void btn_move_distance_Click(object sender, EventArgs e)
        {
            KeyBoardForm _keyboardForm = new KeyBoardForm();//例項化一個Form2視窗
            Button btn_distance = (Button)sender;
            _keyboardForm.StartPosition = FormStartPosition.CenterScreen;
            _keyboardForm.tb_result.Text = btn_distance.Text;
            _keyboardForm.tb_result.SelectionStart = 0;
            _keyboardForm.tb_result.SelectionLength = btn_distance.Text.Length;

            if (_keyboardForm.ShowDialog() == DialogResult.OK)
            {
                btn_distance.Text = _keyboardForm.tb_result.Text;
            }
        }
        #endregion
        #region Miscellaneous
        private void btn_grab_Click(object sender, EventArgs e)
        {
            if (isGarpping)
            {
                GrabOff();
                btn_grab.Image = Properties.Resources.red;
            }
            else
            {
                GrabOn();
                btn_grab.Image = Properties.Resources.green;
            }
        }
        private void btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.ClearAlarm();
                GroupMoveEnable(true);
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Clear Alarm");
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
            frm.ctrl_ip_address.Text = _generalSettings.General.IpAddress;
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
                GrabOff();
                ParamMgr param = new ParamMgr();
                param.Read(openFileDialog1.FileName);
                die_size[0] = param.Width;
                die_size[1] = param.Height;
                die_size[2] = Constants.SCRIBE_LINE_WIDTH;
                tbThreshold1.Text = param.Threshold.ToString();
                ImageFullPath = param.ImageFilePath;
                _cur_bitmap = new Bitmap(ImageFullPath);
                pic_camera.Image = _cur_bitmap;
            }
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            ConnectMeasure();
        }
        private void tr_threshold_Scroll(object sender, EventArgs e)
        {
            tbThreshold1.Text = tr_threshold.Value.ToString();
        }

        private void tr_light_Scroll(object sender, EventArgs e)
        {
            tbLight.Text = tr_light.Value.ToString();
        }

        private void btn_light_Click(object sender, EventArgs e)
        {
            camera.IntstSet(0, int.Parse(tbLight.Text));
        }

        private void btn_threshold_Click(object sender, EventArgs e)
        {
            GrabOff();
            Bitmap map;
            lock (_image_lock)
            {
                map = _cur_bitmap.Clone() as Bitmap;
            }
            map.Save("c:/avva/test/map.bmp");
            pic_camera.Image = _syn_op.Threshold(map, int.Parse(tbThreshold1.Text));
            pic_camera.Image.Save("c:/avva/test/threshold.bmp");

        }
        private void btn_test_Click(object sender, EventArgs e)
        {
            _log.Debug("btn_test_Click:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void tbThreshold1_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(tbThreshold1.Text, out value))
                tr_threshold.Value = value;
            else
            {
                MessageBox.Show("Only number allowed");
                tbThreshold1.Text = "1";
            }
        }

        private void tbLight_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(tbLight.Text, out value))
                tr_light.Value = value;
            else
            {
                MessageBox.Show("Only number allowed");
                tbLight.Text = "0";
            }
        }
        private void btn_autofocus_Click_1(object sender, EventArgs e)
        {
            DoWaferLoad();
        }
        private void GrabOn()
        {
            try
            {
                _log.Debug("In GrabOn: " + Thread.CurrentThread.ManagedThreadId.ToString());

                if (isGarpping) return;
                _log.Debug("Begin GrabStart:" + Thread.CurrentThread.ManagedThreadId.ToString());
                camera.GrabStart();
                isGarpping = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ExceptionDialog(ex, "Camera.GrabStart() failed!");
            }
        }
        private void GrabOff()
        {
            try
            {
                _log.Debug("In GrabOff" + Thread.CurrentThread.ManagedThreadId.ToString());
                if (isGarpping)
                {
                    _log.Debug("Begin GrabStop" + Thread.CurrentThread.ManagedThreadId.ToString());
                    camera.GrabStop();
                    isGarpping = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Camera.GrabStop() failed!");
            }
        }
        private void ExceptionDialog(Exception e, string message)
        {
            string dialog_message;

            dialog_message = "Main_Form: " + message + Environment.NewLine + e.Message;
            if (e.InnerException != null)
            {
                dialog_message += Environment.NewLine + e.InnerException?.Message;
            }
            _log.Warn(dialog_message);
            MessageBox.Show(dialog_message);
        }
        private void ExceptionDialog(string message)
        {
            _log.Warn(message);
            MessageBox.Show(message);
        }
        #endregion
        #endregion

        public void StartSplash()
        {
            Application.Run(new Splash());
        }

    }
    [Serializable]
    class AvvaException : Exception
    {
        public AvvaException(string description)
            : base(description)
        {
            if (description == null) throw new ArgumentNullException("description");
        }

        public AvvaException(string description, Exception inner)
            : base(description, inner)
        {
            if (description == null) throw new ArgumentNullException("description");
            if (inner == null) throw new ArgumentNullException("inner");
        }
    }
    public class AlignEventArgs : EventArgs
    {
        public int Offset { get; set; }
    }
    public class SynOpErrorArgs : EventArgs
    {
        public string Message { get; set; }
        public Exception Ex { get; set; }
    }
}
