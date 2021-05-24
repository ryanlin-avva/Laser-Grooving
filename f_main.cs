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
        #region eThreadAction
        public enum eThreadAction
        {
            /// <summary>nothing to do</summary>
            None,
            /// <summary>client connect</summary>
            eClientConnect,
            /// <summary>client disconnect</summary>
            eClientDisconnect,
            /// <summary>do alignment</summary>
            eAlignment,
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
        sSpectrumRaw spectrumRaw = new sSpectrumRaw();
        #endregion
        #region measure settings
        private int _measure_distance;
        private bool is_advanced_mode = false;
        private SynOperation _syn_op;
        private DBKeeper _db;
        private string _measure_filename;
        private bool _in_trigger = false;
        private int _trigger_end = 0;
        private bool _cancelFormClosing = true;
        private bool startmeasure = false;
        private FindScribe fs = new FindScribe();
        #endregion
        #region autofocus
        long minAFFuncMs;
        long maxAFFuncMs;
        int zImgCount;
        int zPosition;
        readonly AutoResetEvent imageCloneDone;
        bool imageClone;
        Object focusImage;
        delegate double AutoFocusFunc(Object image);
        AutoFocusFunc runAFFunc;
        #endregion
        #region Move, Alignment, Scan
        readonly EventHandler autoFocusRun; 
        delegate bool AlignmentFunc(Object offset);
        AlignmentFunc alignmentFunc;
        bool isAligning = false;
        readonly AutoResetEvent alignDone;
        bool alignmentSucceed = true;

        ScanMoveDelegate scanMove1umFunc;
        ScanMoveDelegate scanMove5umFunc;
        MoveDelegate syncMoveFunc;
        MeasureDelegate measureFunc;
        eScanType _scan_type;
        #endregion
        #region wafer info
        WaferChuck chuck = new WaferChuck();
        private string _wafer_id;
        private int _notch_idx;
        private int _die_row_count = 0;
        private int _die_col_count = 0;
        //die_side (um) 0:x邊長, 1:y邊長, 2:切割道寬度
        private double[] die_size = new double[3];
        private double[] EstimatedDieSide = new double[2];
        private double[] _pos_keep = new double[3];
        #endregion
        #region Misc
        System.Timers.Timer timer;
        System.Timers.Timer timer1;
        System.Timers.Timer timer_measure;
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
        log4net.ILog _log;
        #endregion
        #region 主程式開關
        #region Constructor
        public f_main()
        {
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
                InitDownloadDisplayDelegate = new InitDownloadDisplayDelegateHandler(_OnUpdateInitDownloadDisplay);
                DisplayConnectionStateDelegate = new DisplayConnectionStateDelegateHandler(DisplayClientConnectionState);
                DisplayCommandDataDelegate = new DisplayCommandDataDelegateHandler(DisplayCommandData);
                DisplayRawSpectraDelegate = new DisplaySpectraDelegateHandler(UpdateDisplayRawSpectraDelegate);
                DisplayStatisticsDelegate = new DisplayStatisticsDelegateHandler(DisplayStatistics);
                DisplayDataFormatDelegate = new DisplayDataFormatDelegateHandler(DisplayDataFormat);
                _eventOnClientConnect = new cClientSocket.OnClientConnectEventHandler(OnClientConnect);
                _eventOnClientDisconnect = new cClientSocket.OnClientDisconnectEventHandler(OnClientDisconnect);
                _eventOnUpdateCommandData = new cClientCommunication.OnReceiveCommandDataEventHandler(OnUpdateCommandData);
                _eventOnUpdateDataFormat = new cClientCommunication.OnReceiveDataFormatEventHandler(OnUpdateDataFormat);
                _eventOnUpdateIhm = new cClientCommunication.OnUpdateIhmEventHandler(OnUpdateIhm);
                _eventOnUpdateDataSample = new cClientCommunication.OnReceiveDataSampleEventHandler(_OnUpdateDataSample);
                _eventOnUpdateDataFormatEntry = new cClientCommunication.OnReceiveDataFormatEventHandler(_OnUpdateDataFormatEntry);
                _eventOnError = new cErrorEventArgs.OnErrorEventHandler(_OnError);
                _eventCloseForm = new CloseFormDelegate(_OnCloseOnStart);
                _ccd_range = new sCCDRange(0, 0);
                runAFFunc = new AutoFocusFunc(Cv2LaplacianVariance);
                autoFocusRun = new EventHandler(AutoFocusRun);
                alignmentFunc = new AlignmentFunc(Alignment);
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
                scanMove5umFunc = new ScanMoveDelegate(_syn_op.AsyncMove5um);
                scanMove1umFunc = new ScanMoveDelegate(_syn_op.AsyncMove1um);
                syncMoveFunc = new MoveDelegate(_syn_op.SyncMoveTo);
                measureFunc = new MeasureDelegate(_syn_op.MeasureScan);

                camera.ImageFileDirPath = _syn_op.SavingPath;
                camera.Open(_syn_op.IsSimulate);
                camera.IntstSet(0, tr_light.Value);
                camera.MaxMagSet();
                camera.ImageGrabbed += OnImageGrabbed;
                #endregion
                imageCloneDone = new AutoResetEvent(false);
                alignDone = new AutoResetEvent(false);
                _db = new DBKeeper();
                _log.Info("Form construction finished");
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

            spectrumRaw.FirstChannel = Constants.PREC_FirstChannel;
            spectrumRaw.NumberOfChannels = Constants.PREC_NumberOfChannels;
            spectrumRaw.SpectraId = (uint)eSpectraId.SpectraIdRawSpectrum;
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
            grp_manual_buttons.Visible = false;
            #endregion

            try
            {
                ConnectMeasure();

                Control.CheckForIllegalCrossThreadCalls = false;
                timer = new System.Timers.Timer(100);//定時週期0.1秒
                timer.Elapsed += UpdateUIControls;//定時時間到的時候的回撥函式
                timer.AutoReset = true; //是否不斷重複定時器操作
                timer.Enabled = true;
                timer1 = new System.Timers.Timer(300000);//定時週期300秒
                timer1.Elapsed += GeneralMode;
                timer1.AutoReset = false; //是否不斷重複定時器操作
                timer_measure = new System.Timers.Timer(300000);
                timer_measure.Elapsed += MeasureTimeout;
                timer_measure.AutoReset = false;

                GrabOn();
                _log.Debug("Camera Start Grabbing");
                btn_grab.Image = Properties.Resources.green;

                cb_SelectMeasureDistance.SelectedIndex = 0;
                cb_wafersize.SelectedIndex = 0;
                cb_selectMeasurePrecision.SelectedIndex = 0;
                tbLight.Text = tr_light.Value.ToString();
                tbThreshold1.Text = tr_threshold.Value.ToString();
                GeneralMode(null, null);
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
                                if (spectra.Data != null)
                                    this.Invoke(this.DisplayRawSpectraDelegate, new object[] { _client.DnldCommand });
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
                    if (isAligning && alignDone.WaitOne(0))
                    {
                        isAligning = false;
                    }
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
                                        //_generalSettings.General.Sensor.NumberOfFibers = _client.FibersParameters.NumberOfFibersUsed;
                                        //_generalSettings.General.SodxCommand.Signal.AltitudePeak1 = true;
                                        //_generalSettings.General.SodxCommand.Signal.IntensityLevelPeak1 = true;
                                        //_generalSettings.General.SodxCommand.Signal.IntensityRawPeak1 = true;
                                        //_generalSettings.General.SodxCommand.GlobalSignal.SampleCounter = true;
                                        //_generalSettings.General.SodxCommand.GlobalSignal.StartPositionX = true;
                                        //_generalSettings.General.SodxCommand.GlobalSignal.StartPositionY = true;
                                        //_generalSettings.General.SodxCommand.GlobalSignal.StartPositionZ = true;
                                        //_client.SelectOutputFormat = _generalSettings.General.SodxCommand;
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
                            if (_threadGui != null)
                            {
                                if (is_advanced_mode)
                                {
                                    _threadGui.EventUserList[(int)enEventThreadGui.DisplayStatistics].Set();
                                }
                            }
                        }
                    }
                    #endregion  
                }
                _threadActionProcess.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, string.Format("Error : {0}.{1}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name));
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
                                    profiler.StartInfo.FileName = "SInspector.exe";
                                    profiler.StartInfo.Arguments = Path.Combine(_syn_op.SavingPath, _measure_filename + ".data"); // if you need some
                                    profiler.Start();
                                }
                            }
                        }
                    } 
                    else if (_syn_op.IsSimulate)
                    {
                        _ccsvWriteFiles.Save(_syn_op.DataDirection, (int)_syn_op.GetPos('Z'));
                        _ccsvWriteFiles.Close();
                        _client.TriggerStop();
                        _in_trigger = false;
                        startmeasure = false;
                    }
                }
                if ((_client != null||_syn_op.IsSimulate) && (_threadMeasure.EventUserList[(int)eThreadMeasure.eRun].WaitOne(0)))
                {
                    int scan_mode = cb_selectMeasurePrecision.SelectedIndex == 0 ? 1 : 5;
                    _ccsvWriteFiles.Open(Path.Combine(_syn_op.SavingPath, _measure_filename+".data"), scan_mode);
                    _in_trigger = true;
                }
            }
            _threadMeasure.EventExitProcessThreadDo.Set();
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
            //PasswordBox psForm = new PasswordBox();

            //if (psForm.ShowDialog() == DialogResult.OK)
            //{
            _log.Debug("AdvancedMode");
            is_advanced_mode = true;
            //timer.Enabled = false;
            timer1.Enabled = true; //定時器啟動

            tabControlMain.TabPages.Add(tbp_motion); //Add a tab page
            grp_cursor.Visible = true;
            grp_align_test.Visible = true;
            btn_connection_ip.Visible = true;
            grp_mea_para.Visible = true;
            grp_test.Visible = true;
            //}
            //else
            //{
            //    MessageBox.Show("密碼錯誤!!");
            //}
        }
        #region general mode
        public void GeneralMode(object sender, EventArgs e)
        {
            _log.Debug("GeneralMode");
            is_advanced_mode = false;
            timer1.Enabled = false;

            tabControlMain.TabPages.Remove(tbp_motion); //Remove a tab page
            grp_cursor.Visible = false;
            grp_align_test.Visible = false;
            btn_connection_ip.Visible = false;
            grp_mea_para.Visible = false;
            grp_test.Visible = false;
        }
        #endregion
        private void FreezeControls()
        {
            grp_move.Enabled = false;
            grp_op.Enabled = false;
            cb_SelectMeasureDistance.Enabled = false;
            cb_selectMeasurePrecision.Enabled = false;
            cb_wafersize.Enabled = false;
        }
        private void DefreezeControls()
        {
            grp_move.Enabled = true;
            grp_op.Enabled = true;
            cb_SelectMeasureDistance.Enabled = true;
            cb_selectMeasurePrecision.Enabled = true;
            cb_wafersize.Enabled = true;
        }
        #endregion
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

        #endregion
        #region 顯示或輸入或改變事件
        #region ntb_cur_pos
        public void UpdateUIControls(object sender, EventArgs e)
        {
            ntb_x_cur_pos.Text = _syn_op.GetPos('X').ToString();
            ntb_y_cur_pos.Text = _syn_op.GetPos('Y').ToString();
            ntb_z_cur_pos.Text = _syn_op.GetPos('Z').ToString();
            ntb_x_cur_motorpos.Text = _syn_op.GetPos('X').ToString();
            ntb_y_cur_motorpos.Text = _syn_op.GetPos('Y').ToString();
            ntb_z_cur_motorpos.Text = _syn_op.GetPos('Z').ToString();
            ntb_r_cur_motorpos.Text = _syn_op.GetPos('R').ToString();
            if (isGarpping) btn_grab.Image = Properties.Resources.green;
            else btn_grab.Image = Properties.Resources.red; ;
            if (_client.ClientIsConnected)
                btn_connect.Image = Properties.Resources.green;
            else
                btn_connect.Image = Properties.Resources.red;
            if (_client.DnldCommand.IsBusyDownloadRaw)
                btn_download.Image = Properties.Resources._0_7;
            else
                btn_download.Image = Properties.Resources._0_6;
        }
        #endregion
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
        #region cb_SelectMeasureDistance_SelectedIndexChanged
        private void cb_SelectMeasureDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            _measure_distance = int.Parse(cb_SelectMeasureDistance.Text);
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
            if (client != null)
            {
                if (client.ClientIsConnected)
                {
                    btn_connect.Image = Properties.Resources.green;
                }
                else
                {
                    btn_connect.Image = Properties.Resources.red;
                }
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
            try
            {
                _syn_op.GoHome();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex,"Main");
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
        #region btn_auto_measurement
        private void btn_auto_measurement(object sender, EventArgs e)
        {
            if (tb_dieX.Text == "" || tb_dieY.Text == "")
            {
                MessageBox.Show("請先輸入die的邊長");
                return;
            }
            if (tbThreshold1.Text == "")
            {
                MessageBox.Show("請先輸入影像分割閥值");
                return;
            }
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
                DoAlignment();
                AutoParamsForm form = new AutoParamsForm();
                if (form.ShowDialog() != DialogResult.OK) return;

                RawDownloadStop();

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
                data.scan_type = cb_selectMeasurePrecision.SelectedIndex == 0 ? 1 : 5;
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
                _mea_pos = _syn_op.TransformDiePos(_die_row_count, _die_col_count, EstimatedDieSide, _mea_pts);
                _measure_distance = Constants.AutoMeasureDistance;
                RawDownloadStop();
                List<string> f_list = new List<string>();
                //full pathname = data directory/wafer_id_datetime/DataSet_n.data
                for (int i = 0; i < _mea_pos.Count; i++)
                    f_list.Add(Path.Combine(path, "DataSet_" + i.ToString()));
                FreezeControls();
                DoMeasure(f_list, _mea_pos);

                _db.Insert(data);

                _log.Debug("Auto Measurement Grab on");
                GrabOn();
                RawDownloadStart();
                btn_grab.Enabled = true;
            }
            catch(Exception ex)
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
                int move_distance = (axis=='Z')
                    ? int.Parse(btn_move_distance_z.Text)
                    : int.Parse(btn_move_distance.Text);
                if (name[1] == '-') move_distance = -move_distance;
                DoSyncMove(axis, move_distance);
                _log.Debug("btn_move_Click finished:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Move"+name);
            }
        }
        private void btn_moveR_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.Text;
            try
            {
                int move_distance = int.Parse(btn_move_distance_r.Text);
                if (name=="CCW") move_distance = -move_distance;
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
            cb_wafersize.Enabled = false;
            try
            {
                _syn_op.MoveToCenter();
                GrabOff();
                camera.ImageGrabbed -= OnImageGrabbed;
                camera.ImageGrabbed += OnAutoFocusImageGrabbed;
                GrabOn();
                autoFocusRun.BeginInvoke(sender, e, new AsyncCallback(AutoFocusRun_Callback), null);
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
                cb_wafersize.Enabled = true;
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Unload Wafer");
            }
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
            _clu_threshold = new sControlUpdateEx(ntb_threshold);
            _controlUpdate.ControlUpdateList.Add(_clu_threshold);
            _clu_frequency = new sControlUpdateEx(ntb_frequency);
            _controlUpdate.ControlUpdateList.Add(_clu_frequency);
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
                        if (numericTextBox == ntb_led_intensity)//Led Intensity
                        {
                            _client.LedIntensity = (float)ntb_led_intensity.Value;
                        }
                        else if (numericTextBox == ntb_threshold)//Threshold
                        {
                            _client.Threshold = (float)ntb_threshold.Value;
                        }
                        else if (numericTextBox == ntb_frequency)
                        {
                            _generalSettings.General.HighSpeed = new sHighSpeed(_generalSettings.HighSpeedBase, (uint)ntb_frequency.Value, _client.SensorFrequencyMax);
                        }
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
        }
        #endregion
        #region _OnError
        private void _OnError(object sender, cErrorEventArgs e)
        {
            try
            {
                if (e.Message.MessageType == eMessageType.Error)
                {
                    lock (_errorList)
                    {
                        _errorList.Add(e);
                    }
                    if (_threadGui == null)
                    {
                        _log.Debug(String.Format("->> {0} : Error {1}"
                            , sender.GetType().FullName.ToString(), e.Message.Text));
                    }
                    else
                    {
                        _threadGui.EventUserList[(int)enEventThreadGui.DisplayError].Set();
                        _log.Debug(String.Format("->> {0} : Error {1}", sender.GetType().FullName.ToString(), e.Message.Text));
                    }
                }
            }
            catch (Exception)
            {
                return;
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
        #region btn_ClearAlarm_Click
        private void btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                _syn_op.ClearAlarm();
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Clear Alarm");
            }
        }
        #endregion

        private void btn_manual_mode_Click(object sender, EventArgs e)
        {
            grp_manual_buttons.Visible = !grp_manual_buttons.Visible;
        }

        private void btn_align_Click(object sender, EventArgs e)
        {
            GrabOff();
            DoAlignment();
            GrabOn();
            btn_grab.Enabled = true;
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if ((_client != null) && (_client.DnldCommand != null))
            {
                if (_client.DnldCommand.IsBusyDownloadRaw)
                {
                    _client.DnldCommand.StopDownloadRaw();
                    btn_download.Image = Properties.Resources._0_6;
                }
                else
                {
                    sSpectrumRaw spectrumRaw = new sSpectrumRaw();
                    spectrumRaw.FirstChannel = Constants.PREC_FirstChannel;
                    spectrumRaw.NumberOfChannels = Constants.PREC_NumberOfChannels;
                    spectrumRaw.SpectraId = (uint)eSpectraId.SpectraIdRawSpectrum;
                    _client.DnldCommand.StartDownloadRaw(spectrumRaw, -1);
                    btn_download.Image = Properties.Resources._0_7;
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
                tb_dieX.Text = param.Width.ToString();
                tb_dieY.Text = param.Height.ToString();
                ImageFullPath = param.ImageFilePath;
                _cur_bitmap = new Bitmap(ImageFullPath);
                pic_camera.Image = _cur_bitmap;
            }
        }
        private void btn_find_angle_Click(object sender, EventArgs e)
        {
            VisionCalibrator vc = new VisionCalibrator();
            int threshold1;
            if (!int.TryParse(tbThreshold1.Text, out threshold1)) threshold1 = 6;
            _cur_bitmap.Save("test.bmp", ImageFormat.Bmp);
            try
            {             
                fs.find_angle(_cur_bitmap, threshold1, die_size);
                EstimatedDieSide[Constants.WAY_HORIZONTAL] = vc.Pixel2Um_X(fs.WidthAverage);
                EstimatedDieSide[Constants.WAY_VERTICAL] = vc.Pixel2Um_X(fs.HeightAverage);
                lb_die_side1.Text = "邊長: " + EstimatedDieSide[0].ToString("0.#")
                    + " X " + EstimatedDieSide[1].ToString("0.#");
                lb_angle1.Text = "角度: " + fs.AngleAverage.ToString("0.####");
                //Bitmap bmp = new Bitmap(_cur_bitmap.Width, _cur_bitmap.Height);
                Bitmap bmp = _cur_bitmap.Clone(
                                new Rectangle(0, 0, _cur_bitmap.Width, _cur_bitmap.Height)
                                , PixelFormat.Format24bppRgb);
                fs.Draw(ref bmp);
                pic_camera.Image = bmp;
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "Pic Find Angle:");
            }
        }
        private void btn_start_mea_Click(object sender, EventArgs e)
        {
            try
            {
                if (_client.ClientIsConnected)
                {
                    SaveFileDialog sfd_upload = new SaveFileDialog();
                    sfd_upload.Filter = "DATA file|*.data";
                    sfd_upload.Title = "Save a File";
                    sfd_upload.InitialDirectory = _syn_op.SavingPath;
                    sfd_upload.RestoreDirectory = true;
                    DateTime dt = DateTime.Now;
                    string dateTimeFileName = string.Format("_{0:yy_MM_dd_HH_mm_ss}", dt);
                    sfd_upload.FileName = dateTimeFileName;
                    sfd_upload.DefaultExt = "data";
                    if ((_client != null) && (_client.DnldCommand != null))
                    {
                        if (sfd_upload.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            _measure_filename = sfd_upload.FileName;
                            PointF pos = new PointF((float)_syn_op.GetPos('X')
                                                       , (float)_syn_op.GetPos('Y'));
                            List<string> f_list = new List<string> { Path.GetDirectoryName(_measure_filename) };
                            List<PointF> p_list = new List<PointF> { pos };
                            FreezeControls();
                            DoMeasure(f_list, p_list);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, string.Format("Error : {0}.{1}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name));
            }
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            ConnectMeasure();
        }

        #region Set_EncoderParameter
        private bool Set_EncoderParameter(int StartPos, float TrigInterval, int TrigNum)
        {
            #region set triggerParameter
            _client.TriggerStop();
            int StopPos = (int)(StartPos + TrigInterval * (TrigNum - 1));
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
        #region Image Grabbing
        private void OnImageGrabbed(Object sender, EventArgs e)
        {
            AvvaCamera camera = sender as AvvaCamera;

            if (InvokeRequired)
            {
                //_log.Debug("In OnImageGrabbed BeginInvoke:"+Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(OnImageGrabbed), sender, e);
                return;
            }

            if (camera.CameraState==AvvaCamera.EAvvaCameraState.Closed) return;

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

                _cur_bitmap = bitmap;
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
        private void GrabOn()
        {
            try
            {
                _log.Debug("In GrabOn: "+Thread.CurrentThread.ManagedThreadId.ToString());

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
        #endregion
        #region AutoFocus
        private void OnAutoFocusImageGrabbed(Object sender, EventArgs e)
        {
            AvvaCamera camera = sender as AvvaCamera;

            if (InvokeRequired)
            {
                _log.Debug("In OnAutoFocusImageGrabbed BeginInvoke:" + Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(OnAutoFocusImageGrabbed), sender, e);

                return;
            }
            _log.Debug("In OnAutoFocusImageGrabbed:" + Thread.CurrentThread.ManagedThreadId.ToString());

            if (camera.ImageData != null)
            {
                //_log.Debug("In OnAutoFocusImageGrabbed ImageData !=null:" + Thread.CurrentThread.ManagedThreadId.ToString());
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

                if (badImageData == true)
                {
                    bitmap.Dispose();
                    return;
                }
                
                Bitmap bitmapOld = pic_camera.Image as Bitmap;
                pic_camera.Image = bitmap;

                bitmapOld?.Dispose();

                if ((imageClone == true &&
                    camera.UserData != null &&
                    zPosition == (int)camera.UserData &&
                    ++zImgCount > 1) || _syn_op.IsSimulate)
                {
                    focusImage = BitmapConverter.ToMat(bitmap);
                    imageClone = false;
                    camera.SetUserData(null);
                    zImgCount = 0;
                    imageCloneDone.Set();
                } 
                camera.ImageData = null;
            }
        }
        private void AutoFocusRun(Object sender, EventArgs e)
        {
            int beginPosition, endPosition, positionNo, positionId;
            int[] runPosition;
            IAsyncResult[] result;
            double[] variance;
            double maxVariance;
            Object[] runImage;
            MoveEventArgs moveEventArgs;

            GrabOn();
            Console.WriteLine("Auto Focusing Fisrt Run:");
            //Max Mag
            beginPosition = _syn_op.MaxMagAutoFocusBegin;
            endPosition = _syn_op.MaxMagAutoFocusEnd;

            positionNo = (Math.Abs(endPosition - beginPosition)) / 1000 + 1;

            minAFFuncMs = Int32.MaxValue;
            maxAFFuncMs = 0;

            runPosition = new int[positionNo];
            result = new IAsyncResult[positionNo];
            variance = new double[positionNo];
            runImage = new Object[positionNo];

            for (int position = beginPosition, i = 0; position <= endPosition; position += 1000, i++)
            {
                runPosition[i] = position;
                moveEventArgs = new MoveEventArgs('Z', position, false);
                OnAsyncMove(sender, moveEventArgs);
                AsyncMoveWait('Z', position);
                //_syn_op.MoveTo('Z', position, false);
                zPosition = position;
                camera.SetUserData((object)position);
                zImgCount = 0;

                imageCloneDone.Reset();
                imageClone = true;
                imageCloneDone.WaitOne();

                runImage[i] = focusImage;

                result[i] = runAFFunc.BeginInvoke(runImage[i], null, null);
            }

            for (int i = 0; i < positionNo; i++)
            {
                result[i].AsyncWaitHandle.WaitOne();
                variance[i] = runAFFunc.EndInvoke(result[i]);
                result[i].AsyncWaitHandle.Close();
            }

            maxVariance = variance[0];
            positionId = 0;
            for (int i = 0; i < positionNo; i++)
            {
                Console.WriteLine("variance[" + i + "]= " + variance[i]);
                if (variance[i] > maxVariance)
                {
                    maxVariance = variance[i];
                    positionId = i;
                }
            }

            Console.WriteLine("position id: " + positionId + ", position: " + runPosition[positionId] + ", variance: " + variance[positionId]);

            Console.WriteLine("Auto Focusing Second Run:");

            if (positionId == 0)
                beginPosition = runPosition[0];
            else
                beginPosition = runPosition[positionId - 1];

            if (positionId == positionNo - 1)
                endPosition = runPosition[positionNo - 1];
            else
                endPosition = runPosition[positionId + 1];

            positionNo = (Math.Abs(endPosition - beginPosition)) / 100 + 1;

            runPosition = new int[positionNo];
            result = new IAsyncResult[positionNo];
            variance = new double[positionNo];
            runImage = new Object[positionNo];

            for (int position = beginPosition, i = 0; position <= endPosition; position += 100, i++)
            {
                runPosition[i] = position;
                moveEventArgs = new MoveEventArgs('Z', position, false);
                OnAsyncMove(sender, moveEventArgs);
                AsyncMoveWait('Z', position);
                //_syn_op.MoveTo('Z', position, false);
                zPosition = position;
                camera.SetUserData((object)position);
                zImgCount = 0;

                imageCloneDone.Reset();
                imageClone = true;
                imageCloneDone.WaitOne();

                runImage[i] = focusImage;
                result[i] = runAFFunc.BeginInvoke(runImage[i], null, null);
            }

            for (int i = 0; i < positionNo; i++)
            {
                result[i].AsyncWaitHandle.WaitOne();
                variance[i] = runAFFunc.EndInvoke(result[i]);
                result[i].AsyncWaitHandle.Close();
            }

            maxVariance = variance[0];
            positionId = 0;
            for (int i = 0; i < positionNo; i++)
            {
                Console.WriteLine("variance[" + i + "]: " + variance[i]);
                if (variance[i] > maxVariance)
                {
                    maxVariance = variance[i];
                    positionId = i;
                }
            }
            moveEventArgs = new MoveEventArgs('Z', runPosition[positionId], false);
            OnAsyncMove(sender, moveEventArgs);
            AsyncMoveWait('Z', runPosition[positionId]);

            Console.WriteLine("position id: " + positionId + ", position: " + runPosition[positionId] + ", variance: " + variance[positionId]);
            Console.WriteLine("Max AF func elapsed ms: " + maxAFFuncMs + ", Min AF func elapsed ms: " + minAFFuncMs);
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
        private void AsyncMoveWait(char[]axis, double[] position)
        {
            for (int i=0; i<axis.Length; i++)
            {
                while (_syn_op.GetPos(axis[i]) != position[i])
                {
                    Thread.Sleep(50);
                }
            }
        }
        private void AsyncMoveWait(char axis, double position)
        {
            while (_syn_op.GetPos(axis) != position)
            {
                Thread.Sleep(50);
            }
        }
        private void AutoFocusRun_Callback(IAsyncResult result)
        {
            AutoFocusRun_Done(this, EventArgs.Empty);
        }
        private void AutoFocusRun_Done(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                _log.Debug("In AutoFocusRun_Done BeginInvoke:" + Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(AutoFocusRun_Done), sender, e);

                return;
            }
            _log.Debug("In AutoFocusRun_Done:" + Thread.CurrentThread.ManagedThreadId.ToString());
            GrabOff();
            camera.ImageGrabbed -= OnAutoFocusImageGrabbed;
            camera.ImageGrabbed += OnImageGrabbed;
            GrabOn();
        }
        private double Cv2LaplacianVariance(Object image)
        {
            Console.WriteLine("Cv2LaplacianVariance");
            Mat mat = (Mat)image;
            double variance;
            var watch = System.Diagnostics.Stopwatch.StartNew();

#if false
            using (var laplacian = new Mat())
            {
                int kernel_size = 3;
                int scale = 1;
                int delta = 0;
                int ddepth = image.Type().Depth;
                Cv2.Laplacian(image, laplacian, ddepth, kernel_size, scale, delta);
                Cv2.MeanStdDev(laplacian, out var mean, out var stddev);
                variance = stddev.Val0 * stddev.Val0;
            }
#else
            using (var gray = new Mat())
            using (var laplacian = new Mat())
            {
                Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
                Cv2.Laplacian(gray, laplacian, MatType.CV_64F);
                Cv2.MeanStdDev(laplacian, out var mean, out var stddev);
                variance = stddev.Val0 * stddev.Val0;
            }
#endif

            mat.Dispose();

            watch.Stop();

            if (watch.ElapsedMilliseconds < minAFFuncMs)
                minAFFuncMs = watch.ElapsedMilliseconds;
            else if (watch.ElapsedMilliseconds > maxAFFuncMs)
                maxAFFuncMs = watch.ElapsedMilliseconds;

            return variance;
        }

        #endregion
        #region Alignment
        private bool Alignment(Object o)
        {
            try
            {
                int offset = (int)o;
                camera.MinMagSet();
                char[] axis = { 'X', 'Y' };
                double[] center = _syn_op.GetCenter();
                MoveEventArgs moveEventArgs = new MoveEventArgs(axis, center, false);
                OnAsyncMove(this, moveEventArgs);
                AsyncMoveWait(axis, center);
                fs.find_angle(_cur_bitmap, offset, die_size);
                moveEventArgs = new MoveEventArgs('R', fs.AngleAverage * 1000, true);
                OnAsyncMove(this, moveEventArgs);
                AsyncMoveWait(axis, center);
                VisionCalibrator vc = new VisionCalibrator();
                EstimatedDieSide[Constants.WAY_HORIZONTAL] = vc.Pixel2Um_X(fs.WidthAverage);
                EstimatedDieSide[Constants.WAY_VERTICAL] = vc.Pixel2Um_X(fs.HeightAverage);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionDialog(ex, "DoAlignment()");
                return false;
            }
        }
        private void DoAlignment()
        {
            if (tb_dieX.Text == "" || tb_dieY.Text == "")
            {
                MessageBox.Show("請先輸入die的邊長");
                return;
            }
            if (tbThreshold1.Text == "")
            {
                MessageBox.Show("請先輸入影像分割閥值");
                return;
            }
            VisionCalibrator vc = new VisionCalibrator();
            die_size[Constants.WAY_HORIZONTAL] = (int)vc.Um2Pixel_X(Int32.Parse(tb_dieX.Text));
            die_size[Constants.WAY_VERTICAL] = (int)vc.Um2Pixel_Y(Int32.Parse(tb_dieY.Text));
            die_size[2] = Constants.SCRIBE_LINE_WIDTH;
            int offset = Int32.Parse(tbThreshold1.Text);
            alignDone.Reset();
            isAligning = true;
            alignmentFunc.BeginInvoke(offset, new AsyncCallback(Alignment_Callback), alignmentFunc);
        }
        private void Alignment_Callback(IAsyncResult result)
        {
            AlignmentFunc func = (AlignmentFunc)result.AsyncState;
            alignmentSucceed = func.EndInvoke(result);
            alignDone.Set();
        }
        private void Alignment_Done(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                _log.Debug("In Alignment_Done BeginInvoke:" + Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(Alignment_Done), sender, e);

                return;
            }
            _log.Debug("轉正完成");
        }
        #endregion
        #region Sync Move emulating function
        private void DoSyncMove(char[] axis_char, double[] distance, bool isRelative = true)
        {
            _log.Debug("DoSyncMove:" + Thread.CurrentThread.ManagedThreadId.ToString());
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis_char, distance, isRelative);
            syncMoveFunc.BeginInvoke(moveEventArgs
                , new AsyncCallback(SyncMove_Callback), syncMoveFunc);
            grp_move.Enabled = false;
        }
        private void DoSyncMove(char axis_char, double distance, bool isRelative = true)
        {
            _log.Debug("DoSyncMove:" + Thread.CurrentThread.ManagedThreadId.ToString());
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis_char, distance, isRelative);
            syncMoveFunc.BeginInvoke(moveEventArgs
                , new AsyncCallback(SyncMove_Callback), syncMoveFunc);
            grp_move.Enabled = false;
        }
        #endregion
        #region scan
        private void DoMeasure(List<string> f_list, List<PointF> pos)
        {
            _log.Debug("DoMeasure:" + Thread.CurrentThread.ManagedThreadId.ToString());
            _in_trigger = true;
            measureFunc.BeginInvoke(f_list, pos
                , _scan_type
                , _measure_distance
                , new AsyncCallback(Measure_Callback), measureFunc);
        }

        private void OnSynOpError(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                _log.Debug("OnSynOpError BeginInvoke:" + Thread.CurrentThread.ManagedThreadId.ToString());
                BeginInvoke(new EventHandler(OnSynOpError), sender, e);

                return;
            }
            SynOpErrorArgs error = (SynOpErrorArgs)e;
            ExceptionDialog(error.Ex, error.Message);
        }
        #endregion
        private void RawDownloadStart()
        {
            if ((_client != null) && (_client.DnldCommand != null))
            {
                if (!_client.DnldCommand.IsBusyDownloadRaw)
                    _client.DnldCommand.StartDownloadRaw(spectrumRaw, -1);
            }
        }

        private void RawDownloadStop()
        {
            if (_syn_op.IsSimulate) return;
            if ((_client != null) && (_client.DnldCommand != null))
            {
                if (_client.DnldCommand.IsBusyDownloadRaw)
                    _client.DnldCommand.StopDownloadRaw();
            }
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
            pic_camera.Image = fs.DoThreshold(_cur_bitmap, int.Parse(tbThreshold1.Text));
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
        private void btn_autofocus_Click_1(object sender, EventArgs e)
        {
            camera.ImageGrabbed -= OnImageGrabbed;
            camera.ImageGrabbed += OnAutoFocusImageGrabbed;
            autoFocusRun.BeginInvoke(sender, e, new AsyncCallback(AutoFocusRun_Callback), null);
        }
        private void cb_wafersize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_wafersize.SelectedIndex == 0) chuck.Set_12inchWafer();
            else chuck.Set_8inchWafer();
        }
        private void SyncMove_Callback(IAsyncResult result)
        {
            MoveDelegate func = (MoveDelegate)result.AsyncState;
            func.EndInvoke(result);
            _log.Debug("SyncMove_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            grp_move.Enabled = true;
        }
        private void Measure_Callback(IAsyncResult result)
        {
            MeasureDelegate func = (MeasureDelegate)result.AsyncState;
            func.EndInvoke(result);
            timer_measure.Enabled = true;
            _log.Debug("Measure_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
            DefreezeControls();
        }
        public void MeasureTimeout(object sender, EventArgs e)
        {
            if (startmeasure||_in_trigger) SaveMeasureData();
        }       
        private void SaveMeasureData()
        {
            if (_syn_op.IsSimulate)
            {
                _log.Debug("SaveMeasureData" + Thread.CurrentThread.ManagedThreadId.ToString());
                return;
            }
            _ccsvWriteFiles.Save(_syn_op.DataDirection, (int)_syn_op.GetPos('Z'));
            _ccsvWriteFiles.Close();
            _client.TriggerStop();
            _in_trigger = false;
            startmeasure = false;
        }
        private void ScanMove_Callback(IAsyncResult result)
        {
            ScanMoveDelegate func = (ScanMoveDelegate)result.AsyncState;
            func.EndInvoke(result);
            _log.Debug("ScanMove_Callback:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void btn_test_Click(object sender, EventArgs e)
        {
            _log.Debug("btn_test_Click:" + Thread.CurrentThread.ManagedThreadId.ToString());

            DefreezeControls();

            //_syn_op.AsyncMove5um(1000);
        }

        private void cb_selectMeasurePrecision_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scan_type = (cb_selectMeasurePrecision.SelectedIndex == 0) 
                         ? eScanType.Scan1Um : eScanType.Scan5Um;
        }

        private void tbThreshold1_TextChanged(object sender, EventArgs e)
        {
            tr_threshold.Value = int.Parse(tbThreshold1.Text);
        }

        private void tbLight_TextChanged(object sender, EventArgs e)
        {
            tr_light.Value = int.Parse(tbLight.Text);
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
