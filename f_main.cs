using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using MagicServerLibrary;
using MagicGraphicLibrary;
using MagicCommonLibrary;
using MagicAddOn;
using AddOn;
using Velociraptor.AddOn;
using MotionAPI;
using CHRDLLDemoNS;






namespace Velociraptor
{
    //-------------------------------------------------------------------------------------------
    public partial class f_main : Form
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

        /// <summary>the current thread action</summary>
        eThreadAction _threadAction = eThreadAction.None;
        cClientCommunication _client = null;
        /// <summary>size of rx/tx ethernet buffer</summary>
        const int _rxBufferSizeOfClientSocket = 1024 * 1024 * 32;
        const int _txBufferSizeOfClientSocket = 1024 * 1024 * 32;
        /// <summary>_lock thread action process</summary>
        object _lockActionProcess = new object();
        System.Timers.Timer timer;
        double xpos = -0.1;
        double ypos = -0.1;
        int move_distance = 0;
        int die_count = 0;
        int counter = 0;
        int counter_end = 0;
        double dataIntensityAverage = 0;
        #region Threads
        /// <summary>thread action process</summary>
        public cThreadProcess _threadActionProcess = null;
        /// <summary>thread to the display refresh</summary>
        cThreadProcess _threadGui = null;
        /// <summary>thread to the display refresh</summary>
        cThreadProcess _threadDataSample = null;

        cThreadProcess _threadAcquisitionProcess = null;
        #endregion
        #region acquisition thread
        //int _dataAcquisitionNumber = 0;
        //int _dataAcquisitionCounter = 0;
        //eThreadAcquisition _threadAcquisition = eThreadAcquisition.eStop;

        #endregion
        //CCD Range
        sCCDRange _ccd_range = null;
        cGeneralSettings _generalSettings = null;

        //cThreadProcess _threadAcquisitionProcess = null;

        //bool _isStopPushButton = false;
        //cDataSample _dataSampleGui = null;
        cCsvWriteFiles _ccsvWriteFiles = new cCsvWriteFiles();
        //cSelectingFilters _selectingFilters = null;
        //cSaveFilteredData _saveFilteredData = null;
        cProjectSettings _cprojectSettings = new cProjectSettings();
        sProjectSettings _sprojectSettings = new sProjectSettings();
        sAcquisition _acquisitionTab = new sAcquisition();
        PasswordEngineer psengineerForm = new PasswordEngineer();
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件

        //acquisition thread
        int _dataAcquisitionNumber = 0;
        int _dataAcquisitionCounter = 0;
        eThreadAcquisition _threadAcquisition = eThreadAcquisition.eStop;
        eThreadDisplayAcquisition _threadDisplayAcquisition = eThreadDisplayAcquisition.eRun;



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
        List<string[]> MultiPointList = new List<string[]>();
        List<sEventActionProcessControl> _eventActionProcessControlList = new List<sEventActionProcessControl>();
        List<cErrorEventArgs> _errorList = null;
        cSelectingFilters _selectingFilters = null;
        cSaveFilteredData _saveFilteredData = null;
        cDisplayDataSodx _displayDataSodx = null;
        //control update
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
        #region YASKAWA servor parameter control
        UInt32 g_hController = 0;				 // Controller handle				
        UInt32 g_hDevice;  // Device handle




        CMotionAPI.MOTION_DATA[] MotionDataForMove = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA structure宣告3個含有1個陣列元素的陣列
        CMotionAPI.POSITION_DATA[] PosForMove = new CMotionAPI.POSITION_DATA[3];    // POSITION_DATA structure
        CMotionAPI.MOTION_DATA[] MotionDataForMea = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA structure宣告3個含有1個陣列元素的陣列
        CMotionAPI.POSITION_DATA[] PosForMea = new CMotionAPI.POSITION_DATA[3];    // POSITION_DATA structure
        CMotionAPI.POSITION_DATA[] PosForMeaMoveDownY = new CMotionAPI.POSITION_DATA[3];    // POSITION_DATA structure
        CMotionAPI.POSITION_DATA[] PosForMeaMoveForwardX = new CMotionAPI.POSITION_DATA[3];    // POSITION_DATA structure
        CMotionAPI.POSITION_DATA[] PosForMeaMoveBackX = new CMotionAPI.POSITION_DATA[3];    // POSITION_DATA structure
        UInt16[] HomeMethod = new UInt16[3];                                 // Zero point return method
        UInt16[] Direction = new UInt16[3];                                  // Moving direction
        UInt16[] WaitForCompletion = new UInt16[3];                          // Completion attribute storage variable
        UInt32 rc;                                                           // Motion API return value

        CMotionAPI.COM_DEVICE ComDevice;              // The ymcOpenController setting structure
        String AxisName;               // Axis name
        UInt32[] hAxis = new UInt32[3];  // Axis handle
        //UInt32[] hAxis = new UInt32[1];
        Int16 i;                      // Index of number of axes
        //
        UInt32 RegisterDataNumber;             // Number of read-in registers
        UInt32 ReadDataNumber = 00000000;                 // Number of obtained registers
        UInt16[] Reg_ShortData = new UInt16[3];  // W or B size register data storage variable
        public Int32[] Reg_LongDataX = new Int32[1];   // L size register data storage variable
        public Int32[] Reg_LongDataY = new Int32[1];   // L size register data storage variable
        public Int32[] Reg_LongDataZ = new Int32[1];   // L size register data storage variable
        UInt32[] Re_LongData = new UInt32[3];   // L size register data storage variable

        // Definition of motion API variables
        UInt32 hRegister_OLx = 0x00000000;                   // Register data handle for OL register
        UInt32 hRegister_OLy = 0x00000000;                   // Register data handle for OL register
        UInt32 hRegister_OLz = 0x00000000;                   // Register data handle for OL register


        String cRegisterName_OLx = "IL8010";               // OL register name storage variable
        String cRegisterName_OLy = "IL8090";               // OL register name storage variable
        String cRegisterName_OLz = "IL8110";               // OL register name storage variable

        public List<int> xposList = new List<int>();
        public List<int> yposList = new List<int>();
        #endregion
        cCurve _curve_v1 = null;
        cCurve _curve_v2 = null;
        cCurve _curve_v3 = null;
        cRawImageCursor _cursor_raw_v1 = null;
        cRawImageCursor _cursor_raw_v2 = null;
        cRawImageCursor _cursor_raw_v3 = null;
        bool _isCursorV1IndexChange = false;
        bool _isCursorV2IndexChange = false;
        bool _isCursorH1IndexChange = false;


        AVVAParameter ReadParameter = new AVVAParameter("C:/Users/User/Desktop/Velociraptor/AVVAParameter.ini");


        delegate void InitDisplayDelegateHandler(Form form);
        InitDisplayDelegateHandler InitDisplayDelegate;

        delegate void UpdateInitDisplayDelegateHandler(Form form);
        UpdateInitDisplayDelegateHandler UpdateInitDisplayDelegate;

        delegate void InitDownloadDisplayDelegateHandler(Form form);
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

        delegate void DisplaySodxAcquisitionDelegateHandler(Form form);
        DisplaySodxAcquisitionDelegateHandler DisplaySodxAcquisitionDelegate;

        delegate void CloseFormDelegate(object sender, EventArgs e);
        CloseFormDelegate CloseForm;


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
            _client = new cClientCommunication(_rxBufferSizeOfClientSocket, _txBufferSizeOfClientSocket);
            #endregion

            _client.Initialize(null, null);
            _client.HighSpeedBase = _generalSettings.HighSpeedBase;
            _client.SensorsBase = _generalSettings.SensorsBase;
            _client.OpticalProbesBase = _generalSettings.OpticalProbesBase;
            _errorList = new List<cErrorEventArgs>();
            _selectingFilters = new cSelectingFilters();
            _selectingFilters.OnFiltersAdd += _eventOnFiltersAdd;
            _selectingFilters.OnFiltersRemove += _eventOnFiltersRemove;
            _saveFilteredData = new cSaveFilteredData(_selectingFilters);
            _displayDataSodx = new cDisplayDataSodx(_generalSettings, ctrl_zgc_sodx, btn_sodx_pause, chk_yaxis_auto_scale);


            InitDisplayDelegate = new InitDisplayDelegateHandler(OnInitDisplay);
            InitDownloadDisplayDelegate = new InitDownloadDisplayDelegateHandler(_OnUpdateInitDownloadDisplay);



            DisplayConnectionStateDelegate = new DisplayConnectionStateDelegateHandler(DisplayClientConnectionState);
            DisplayCommandDataDelegate = new DisplayCommandDataDelegateHandler(DisplayCommandData);
            DisplayRawSpectraDelegate = new DisplaySpectraDelegateHandler(UpdateDisplayRawSpectraDelegate);
            DisplayDataSampleDelegate = new DisplayDataSampleDelegateHandler(DisplayDataSample);
            DisplayStatisticsDelegate = new DisplayStatisticsDelegateHandler(DisplayStatistics);
            DisplayDataFormatDelegate = new DisplayDataFormatDelegateHandler(DisplayDataFormat);
            DisplaySodxAcquisitionDelegate = new DisplaySodxAcquisitionDelegateHandler(DisplaySodxAcquisition);
            UpdateInitDisplayDelegate = new UpdateInitDisplayDelegateHandler(_OnUpdateInitDisplay);
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
            CloseForm = new CloseFormDelegate(CloseOnStart);
            //CCD Range
            _ccd_range = new sCCDRange(0, 0);


        }
        #endregion
        #region CloseOnStart
        private void CloseOnStart(object sender, EventArgs e)
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
            #region Sets the ymcOpenController parameters                             
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCIe_MODE;
            ComDevice.PortNumber = 1;
            ComDevice.CpuNumber = 1;    //cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber = 0;
            ComDevice.IPAddress = "";    //ctrl_ip_address.Text
            ComDevice.Timeout = 10000;
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


            gb_multi_point.Enabled = false;
            #region YASKAWA servor setting
            #region ymcOpenController
            //在執行任何其他API之前，必須執行此API
            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #region Sets the motion API timeout                               
            // Sets the motion API timeout.			
            rc = CMotionAPI.ymcSetAPITimeoutValue(50000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #region Deletes the axis handle that is held by the Machine Controller   
            // Deletes the axis handle that is held by the Machine Controller.
            rc = CMotionAPI.ymcClearAllAxes();
            //rc = CMotionAPI.ymcClearAxis(hAxis[0]);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #region Creates the axis handle      
            for (i = 0; i < 3; i++)
            {
                AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareAxis \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                    return;
                }
            }
            #endregion
            #region Gets the device handle
            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #region Executes servo ON
            //打開由設備手柄指定軸的伺服
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #endregion
            timer = new System.Timers.Timer(1);//定時週期0.001秒
            timer.Elapsed += ntb_cur_pos;//定時時間到的時候的回撥函式
            timer.AutoReset = true; //是否不斷重複定時器操作
            timer.Enabled = true; //定時器啟動
            Control.CheckForIllegalCrossThreadCalls = false;
            tabControlMain.TabPages.Remove(tbp_sodx); //Remove a tab page
            tabControlMain.TabPages.Remove(tbp_status); //Remove a tab page
            tabControlMain.TabPages.Remove(tbp_record); //Remove a tab page

            //#region 跳出初始視窗執行初始化
           
            //HomePosition(ReadParameter.OriginReturnVelocity, ReadParameter.OriginReturnApproachVelocity, ReadParameter.OriginReturnCreepVelocity, 0);
            //#region darkform
            //    f_dark darkform = new f_dark();
            //    darkform.StartPosition = FormStartPosition.CenterScreen;
            //    if (darkform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        _client.Dark();
            //        #region diesizeform
            //        DieSizeForm diesizeform = new DieSizeForm();
            //        diesizeform.StartPosition = FormStartPosition.CenterScreen;

            //        if (diesizeform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            _acquisitionTab.DieWidth = Int32.Parse(diesizeform.die_x_length.Text);
            //            _acquisitionTab.DieHeight = Int32.Parse(diesizeform.die_y_length.Text);
            //            #region WaferCenterPointform
            //            WaferCenterPointForm wafercenterpointform = new WaferCenterPointForm();
            //            wafercenterpointform.StartPosition = FormStartPosition.CenterScreen;
            //            if (wafercenterpointform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //            {
            //                movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance, ReadParameter.moveToWaferCenterPointYDistance, ReadParameter.moveToWaferCenterPointZDistance);
            //            }
            //            else
            //            {
            //                MessageBox.Show("請移至中心對焦!!");
            //                System.Environment.Exit(0);
            //            }
            //            #endregion
            //        }
            //        else
            //        {
            //            MessageBox.Show("請輸入die尺寸!!");
            //            System.Environment.Exit(0);
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        MessageBox.Show("請執行噪聲去除!!");
            //        System.Environment.Exit(0);
            //    }
            //#endregion

           
            //#endregion


            ctrl_zgc_sodx.ResourceLanguage = _generalSettings.General.ResourceLanguage;
            Text = string.Format("Sample 2 Version : {0}", Assembly.GetExecutingAssembly().GetName().Version);

        }
        #endregion
        #region Form Closing
        private void f_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region _fifoCommandData
            if (_fifoCommandData != null)
            {
                _fifoCommandData.Dispose();
                _fifoCommandData = null;
            }
            #endregion
            #region _controlUpdate
            if (_controlUpdate != null)
            {
                _controlUpdate.Dispose();
                _controlUpdate = null;
            }
            #endregion
            #region FifoDataSample
            if (_fifoDataSample != null)
            {
                lock (_fifoDataSample)
                {

                    if (_fifoDataSample != null)
                    {
                        _fifoDataSample.Dispose();
                        _fifoDataSample = null;
                    }
                    _fifoDataSample = null;
                }
            }
            #endregion

            UInt32 rc;    // Motion API return value


            #region Executes servo OFF.
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #region Deletes the device handle created in this thread. 
            rc = CMotionAPI.ymcClearDevice(g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion
            #region Close the Controller.
            rc = CMotionAPI.ymcCloseController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            #endregion

            #region Settings
            _cprojectSettings.Save();
            _cprojectSettings.Project.Dispose();
            #endregion
            #region clsRawImage
            if (clsRawImage != null)
            {
                clsRawImage.RefreshDisplay = 0;
            }
            #endregion
            #region _threadDataSample
            if (_threadDataSample != null)
            {
                if (_threadDataSample != null)
                {
                    _threadDataSample.StopThread(500);
                    _threadDataSample.Dispose();
                    _threadDataSample = null;
                }
                _threadDataSample = null;
            }
            #endregion
            #region _threadActionProcess
            if (_threadActionProcess != null)
            {
                _threadActionProcess.StopThread(500);
                _threadActionProcess.Dispose();
                _threadActionProcess = null;
            }
            #endregion
            #region _threadGui
            if (_threadGui != null)
            {
                _threadGui.StopThread(500);
                _threadGui.Dispose();
                _threadGui = null;
            }
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
                _generalSettings.General.SodxCommand = _client.SelectOutputFormat;
                _generalSettings.SaveSettings();
                _client.Dispose();
                _client = null;
            }
            #endregion
            #region _displayDataSodx
            if (_displayDataSodx != null)
            {
                _displayDataSodx.Dispose();
                _displayDataSodx = null;
            }
            #endregion
            if (_threadAcquisitionProcess != null)
            {
                _threadAcquisitionProcess.StopThread(500);
                _threadAcquisitionProcess.Dispose();
                _threadAcquisitionProcess = null;
            }


            // Ends the motion API.
            //Application.Exit();



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
            #region _fifoDataSodx
            if (_fifoDataSodx != null)
            {
                _fifoDataSodx.OnError -= _eventOnError;
                _fifoDataSodx.Dispose();
                _fifoDataSodx = null;
            }
            #endregion
            #region _controlUpdate
            if (_controlUpdate != null)
            {
                _controlUpdate.Dispose();
                _controlUpdate = null;
            }
            #endregion
            #region _saveFilteredData
            if (_saveFilteredData != null)
            {
                _saveFilteredData.Dispose();
                _saveFilteredData = null;
            }
            #endregion
            #region _selectingFilters
            if (_selectingFilters != null)
            {
                _selectingFilters.OnFiltersAdd -= _eventOnFiltersAdd;
                _selectingFilters.OnFiltersRemove -= _eventOnFiltersRemove;
                _selectingFilters.Dispose();
                _selectingFilters = null;
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
            cDataSample dataSample = null;
            double dTimeout = _tm.FlashTiming;
            short[,] sBuffer = null;
            int _timoutStatistics = 250, _timoutStatisticsValue = 0; //Display Statistics step 250 mms
            int _timoutDataSample = 1, _timoutDataSampleValue = 0;

            while (!_threadGui.EventExitProcessThread.WaitOne(10))
            {
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
                    this.Invoke(this.UpdateInitDisplayDelegate, new object[] { this });
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
                #region UpdateButton
                if (_threadGui.EventUserList[(int)enEventThreadGui.eUpdateButton].WaitOne(0))
                {
                    Invoke((Action)(() =>
                    {
                        btn_connection.Enabled = (_client != null) && (_client.ClientIsConnected == false);
                    }));
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

                    #region Connect/Disconnect
                    if (_client != null)
                    {
                        //calculate statistics Timeout                    
                        if (timeout.IsTimeout())
                        {
                            GC.Collect();
                            switch (_threadAction)
                            {
                                //client connect
                                case eThreadAction.eClientConnect:
                                    _threadAction = (_client.Open()) ? eThreadAction.None : eThreadAction.eClientDisconnect;
                                    if (_threadAction == eThreadAction.None)
                                    {
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
                                //client disconnect
                                case eThreadAction.eClientDisconnect:
                                    _client.Close();
                                    _threadAction = eThreadAction.None;
                                    break;
                            }
                            if (_threadGui != null)
                            {
                                _threadGui.EventUserList[(int)enEventThreadGui.DisplayStatistics].Set();
                                _threadGui.EventUserList[(int)enEventThreadGui.DisplayDataSample].Set();
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
                            ReadParameter.SetStartPosition = int.Parse(ntb_x_cur_pos.Text);
                            _acquisitionTab.StartMeasureXPos = int.Parse(ntb_x_cur_pos.Text);
                            _acquisitionTab.StartMeasureYPos = int.Parse(ntb_y_cur_pos.Text);
                            _acquisitionTab.StartMeasureZPos = int.Parse(ntb_z_cur_pos.Text);
                            #region set triggerParameter
                            _client.SetEncoderCounters(eEncoderId.Encoder_X, eEncoderFunc.SetPositionImmediately, Re_LongData[0]);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EnableTriggerDuringReturnMovement, ReadParameter.EnableTriggerDuringReturnMovement);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.ChooseAxis, ReadParameter.ChooseAxis);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.EndlessRountripTrigger, ReadParameter.EndlessRountripTrigger);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStopPosition, ReadParameter.SetStartPosition + ReadParameter.MeasureDistance);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetTriggerInterval, ReadParameter.SetTriggerInterval);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SetStartPosition, ReadParameter.SetStartPosition);
                            _client.SetEncoderTriggerControl(eEncoderTriggerControlFunc.SelectEncoderTriggerSource, ReadParameter.SelectEncoderTriggerSource);
                            #endregion


                            //_client.TriggerEach();


                            #region Cls_0 
                            _ccsvWriteFiles = new cCsvWriteFiles();
                            if ((_client.ClientIsConnected) && (_client.ClientIsConfigured))
                            {
                                if(rb_showdata_x.Checked)
                                {
                                    _ccsvWriteFiles.Open(_cprojectSettings, _cprojectSettings.Project.DataDirectory, _cprojectSettings.Project.Filename, ReadParameter.MeasureDistance, ReadParameter.ScanningMode,0, _acquisitionTab.StartMeasureZPos);
                                }
                                if(rb_showdata_y.Checked)
                                {
                                    _ccsvWriteFiles.Open(_cprojectSettings, _cprojectSettings.Project.DataDirectory, _cprojectSettings.Project.Filename, ReadParameter.MeasureDistance, ReadParameter.ScanningMode,1, _acquisitionTab.StartMeasureZPos);
                                }

                            }
                            else
                            {
                                _acquisitionTab = null;
                            }
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
                            if (_threadDataSample != null)
                            {
                                _threadDataSample.EventUserList[(int)eThreadDataSample.DataSample].Set();
                            }
                            if (ReadParameter.ScanningMode == 0)
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
                            /*
                            #region Acquisition Tab
                            if (_acquisitionTab != null)
                            {
                                lock (_acquisitionTab)
                                {
                                    _acquisitionTab.Recording = false;
                                        _acquisitionTab = null;
                                        if (_threadActionProcess != null)
                                        {
                                            _threadActionProcess.EventUserList[(int)eThreadAction.StopRecordDataSample].Set();
                                        }
                                    
                                }
                            }
                            #endregion*/
                            #region Stop Trigger
                            if ((_client.ClientIsConnected) && (_client.ClientIsConfigured))
                            {
                                _client.TriggerStop();
                            }
                            #endregion
                            //Thread.Sleep(5000);
                            #region Close Files
                            if (_ccsvWriteFiles != null)
                            {
                                _ccsvWriteFiles.Close();
                                _ccsvWriteFiles.Dispose();
                                _ccsvWriteFiles = null;
                            }
                            #endregion
                            #region show data
                            if (rb_showdata_x.Checked)
                            {
                                ProcessStartInfo Info2 = new ProcessStartInfo();

                                Info2.FileName = "ThickInspector.exe";//執行的檔案名稱

                                Info2.WorkingDirectory = @"C:\Users\USER\Desktop\Velociraptor\Bin\Debug";//檔案所在的目錄

                                Info2.Arguments = string.Format(@"{0} 1 0", _cprojectSettings.Project.DataDirectoryFilename);

                                Process.Start(Info2);

                                if (ck_multi_point_mea.Checked)
                                {
                                    CheckDoNextPosMeasure _checkdonextposmeasure = new CheckDoNextPosMeasure();
                                    _checkdonextposmeasure.StartPosition = FormStartPosition.Manual;
                                    if (_checkdonextposmeasure.ShowDialog() == DialogResult.OK)
                                    {
                                        _acquisitionTab.DoNextMeasure = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("結束多點測量!!");
                                        _acquisitionTab.DoNextMeasure = true;
                                        _acquisitionTab.Recording = false;
                                    }
                                }
                                else
                                {

                                }
                                sw.Stop();//碼錶停止

                                //印出所花費的總豪秒數

                                string result1 = sw.Elapsed.TotalMilliseconds.ToString();
                            }
                            if (rb_showdata_y.Checked)
                            {
                                ProcessStartInfo Info2 = new ProcessStartInfo();

                                Info2.FileName = "ThickInspector.exe";//執行的檔案名稱

                                Info2.WorkingDirectory = @"C:\Users\USER\Desktop\Velociraptor\Bin\Debug";//檔案所在的目錄

                                Info2.Arguments = string.Format(@"{0} 1 1", _cprojectSettings.Project.DataDirectoryFilename);

                                Process.Start(Info2);

                                if (ck_multi_point_mea.Checked)
                                {
                                    CheckDoNextPosMeasure _checkdonextposmeasure = new CheckDoNextPosMeasure();
                                    _checkdonextposmeasure.StartPosition = FormStartPosition.Manual;
                                    if (_checkdonextposmeasure.ShowDialog() == DialogResult.OK)
                                    {
                                        _acquisitionTab.DoNextMeasure = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("結束多點測量!!");
                                        _acquisitionTab.DoNextMeasure = true;
                                        _acquisitionTab.Recording = false;
                                    }
                                }
                                else
                                {

                                }
                            }
                            #endregion

                        }
                    }
                    #endregion
                    #region StartMoveSamplePitch5um
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StartMoveSamplePitch5um].WaitOne(0))
                    {
                        #region sets the positioning parameter
                        // Sets the positioning parameter.
                        Int32[] VelDataForMea = new Int32[3];                     // Speed storage variable (for 3 axes)
                        Int32[] PosDataForMea = new Int32[3];                     // Target position storage variable (for 3 axes)
                        Int32[] AccDataForMea = new Int32[3];                     // Acceleration storage variable (for 3 axes)
                        Int32[] DecDataForMea = new Int32[3];                     // Deceleration storage variable (for 3 axes)
                        i = 0;
                        VelDataForMea[i] = ReadParameter.measAxis0VelData;
                        AccDataForMea[i] = ReadParameter.measAxis0AccData;
                        DecDataForMea[i] = ReadParameter.measAxis0DecData;
                        PosDataForMea[i] = (int)ReadParameter.MeasureDistance;
                        i = 1;
                        VelDataForMea[i] = ReadParameter.measAxis1VelData;
                        AccDataForMea[i] = ReadParameter.measAxis1AccData;
                        DecDataForMea[i] = ReadParameter.measAxis1DecData;
                        PosDataForMea[i] = ReadParameter.measAxis1PosData;
                        i = 2;
                        VelDataForMea[i] = ReadParameter.measAxis2VelData;
                        AccDataForMea[i] = ReadParameter.measAxis2AccData;
                        DecDataForMea[i] = ReadParameter.measAxis2DecData;
                        #endregion
                        #region sets the motiondata position waitforcompletion
                        // Loops as many times as the number of the connected axes in the window and sets as many parameters as the number of axes.
                        // Performs positioning (ymcMoveDriverPositioning) after setting the data.
                        // Motion data setting 
                        Int16[] Direction = new Int16[3];                   // JOG direction specified (for 3 axes)
                        UInt16[] Timeout = new UInt16[3];                    // Timeout time (for 3 axes)
                        for (i = 0; i < 3; i++)
                        {
                            // Motion data setting
                            MotionDataForMea[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                            MotionDataForMea[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
                            MotionDataForMea[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                            MotionDataForMea[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                            MotionDataForMea[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;
                            MotionDataForMea[i].DataType = 0;
                            //MotionData[i].MaxVelocity    = 10000; 
                            MotionDataForMea[i].Acceleration = AccDataForMea[i];
                            MotionDataForMea[i].Deceleration = DecDataForMea[i];
                            MotionDataForMea[i].FilterTime = 10;
                            MotionDataForMea[i].Velocity = VelDataForMea[i];
                            /* Not Use MotionData[i].ApproachVelocity = NULL; */
                            /* Not Use MotionData[i].CreepVelocity    = NULL; */

                            // Position data setting
                            PosForMea[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                            PosForMea[i].PositionData = PosDataForMea[i];
                            // By setting the completion attribute to "COMMAND_STARTED (starting the command)," 
                            // the control returns to the application immediately after positioning command execution.
                            WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
                            Direction[i] = (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
                            Timeout[i] = 0;
                        }

                        #endregion
                        rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMea, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        } 
                    }
                    #endregion
                    #region StartMoveSamplePitch1um
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.StartMoveSamplePitch1um].WaitOne(0))
                    {
                        #region sets the positioning parameter
                        // Sets the positioning parameter.
                        Int32[] VelDataForMea = new Int32[3];                     // Speed storage variable (for 3 axes)
                        Int32[] PosDataForMea = new Int32[3];                     // Target position storage variable (for 3 axes)
                        Int32[] PosDataForMeaMoveDownY = new Int32[3];                     // Target position storage variable (for 3 axes)
                        Int32[] PosDataForMeaMoveForwardX = new Int32[3];
                        Int32[] PosDataForMeaMoveBackX = new Int32[3];                     // Target position storage variable (for 3 axes)
                        Int32[] AccDataForMea = new Int32[3];                     // Acceleration storage variable (for 3 axes)
                        Int32[] DecDataForMea = new Int32[3];                     // Deceleration storage variable (for 3 axes)
                        i = 0;
                        VelDataForMea[i] = ReadParameter.measAxis0VelData;
                        AccDataForMea[i] = ReadParameter.measAxis0AccData;
                        DecDataForMea[i] = ReadParameter.measAxis0DecData;
                        PosDataForMea[i] = (int)ReadParameter.MeasureDistance;
                        PosDataForMeaMoveForwardX[i] = (int)ReadParameter.MeasureDistance-1;
                        PosDataForMeaMoveDownY[i] = 0;
                        PosDataForMeaMoveBackX[i] = -(int)ReadParameter.MeasureDistance+1;
                        i = 1;
                        VelDataForMea[i] = ReadParameter.measAxis1VelData;
                        AccDataForMea[i] = ReadParameter.measAxis1AccData;
                        DecDataForMea[i] = ReadParameter.measAxis1DecData;
                        PosDataForMea[i] = ReadParameter.measAxis1PosData;
                        PosDataForMeaMoveForwardX[i] = 0;
                        PosDataForMeaMoveDownY[i] = 1;
                        PosDataForMeaMoveBackX[i] = ReadParameter.measAxis1PosData;
                        i = 2;
                        VelDataForMea[i] = ReadParameter.measAxis2VelData;
                        AccDataForMea[i] = ReadParameter.measAxis2AccData;
                        DecDataForMea[i] = ReadParameter.measAxis2DecData;
                        PosDataForMeaMoveForwardX[i] = 0;
                        PosDataForMeaMoveDownY[i] = ReadParameter.measAxis2PosData;
                        PosDataForMeaMoveBackX[i] = ReadParameter.measAxis2PosData;


                        #endregion
                        #region sets the motiondata position waitforcompletion
                        // Loops as many times as the number of the connected axes in the window and sets as many parameters as the number of axes.
                        // Performs positioning (ymcMoveDriverPositioning) after setting the data.
                        // Motion data setting 
                        Int16[] Direction = new Int16[3];                   // JOG direction specified (for 3 axes)
                        UInt16[] Timeout = new UInt16[3];                    // Timeout time (for 3 axes)
                        for (i = 0; i < 3; i++)
                        {
                            // Motion data setting
                            MotionDataForMea[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                            MotionDataForMea[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
                            MotionDataForMea[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                            MotionDataForMea[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_UNIT_PAR;
                            MotionDataForMea[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;
                            MotionDataForMea[i].DataType = 0;
                            MotionDataForMea[i].MaxVelocity    = 2000; 
                            MotionDataForMea[i].Acceleration = AccDataForMea[i];
                            MotionDataForMea[i].Deceleration = DecDataForMea[i];
                            MotionDataForMea[i].FilterTime = 10;
                            MotionDataForMea[i].Velocity = VelDataForMea[i];
                            /* Not Use MotionData[i].ApproachVelocity = NULL; */
                            /* Not Use MotionData[i].CreepVelocity    = NULL; */

                            // Position data setting
                            PosForMea[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                            PosForMea[i].PositionData = PosDataForMea[i];
                            PosForMeaMoveDownY[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                            PosForMeaMoveDownY[i].PositionData = PosDataForMeaMoveDownY[i];
                            PosForMeaMoveForwardX[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                            PosForMeaMoveForwardX[i].PositionData = PosDataForMeaMoveForwardX[i];
                            PosForMeaMoveBackX[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                            PosForMeaMoveBackX[i].PositionData = PosDataForMeaMoveBackX[i];
                            // By setting the completion attribute to "COMMAND_STARTED (starting the command)," 
                            // the control returns to the application immediately after positioning command execution.
                            WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.LATCH_COMPLETED;
                            Direction[i] = (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
                            Timeout[i] = 0;
                        }

                        #endregion
                        rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        Thread.Sleep(80);
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMea, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                       
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        Thread.Sleep(80);
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveBackX, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        Thread.Sleep(80);
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveForwardX, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        Thread.Sleep(80);
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveBackX, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }
                        Thread.Sleep(80);
                        rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveForwardX, 0, "Start", WaitForCompletion, 0);
                        if (rc != CMotionAPI.MP_SUCCESS)
                        {
                            MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                            return;
                        }                       
                    }
                    #endregion
                    #region FifoDataSample
                    if (_threadActionProcess.EventUserList[(int)eThreadAction.DoMultiPointSample].WaitOne(0))
                    {


                    }
                    #endregion
                }
                _threadActionProcess.EventExitProcessThreadDo.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error : {0}.{1} : {2}", this.GetType().FullName.ToString(), System.Reflection.MethodInfo.GetCurrentMethod().Name, ex.Message), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally
            //{
            //this.Invoke(this.CloseForm, null, null);
            //}
        }
        #endregion
        #region ThreadDataSample_0
        /// <summary>This method is called when starting the thread.</summary> 
        public void ThreadDataSample_0()
        {
            while (!_threadDataSample.EventExitProcessThread.WaitOne(0))
            {
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
                                    if (IsInteger((clsDataSample.SignalDataList[0].DataToDouble - ReadParameter.SetStartPosition) / ReadParameter.SetTriggerInterval) && clsDataSample.SignalDataList[4].PointCount == 192 )
                                    {
                                        if (xpos != clsDataSample.SignalDataList[0].DataToDouble )
                                        {

                                            if (counter == 0)
                                            {
                                                ypos = _acquisitionTab.StartMeasureYPos;
                                            }
                                            //if (ypos == clsDataSample.SignalDataList[1].DataToDouble)
                                            //{
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
                                                        if (counter == _acquisitionTab.NumberOfSamples )
                                                        {
                                                            if (_ccsvWriteFiles.WriteList(_cprojectSettings, ReadParameter.MeasureDistance, ReadParameter.ScanningMode))
                                                            {
                                                                _threadActionProcess.EventUserList[(int)eThreadAction.StopRecordDataSample].Set();
                                                                btn_dnld_raw_execute.Image = Properties.Resources.FUNC_STOP;
                                                                counter = 0;
                                                                counter_end = 0;
                                                                xpos = clsDataSample.SignalDataList[0].DataToDouble - 1;
                                                            }
                                                            else
                                                            {
                                                                _threadActionProcess.EventUserList[(int)eThreadAction.StopRecordDataSample].Set();
                                                                btn_dnld_raw_execute.Image = Properties.Resources.FUNC_STOP;
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
                                            if ((int)xpos == (_acquisitionTab.StartMeasureXPos + ReadParameter.MeasureDistance) && (int)ypos == (_acquisitionTab.StartMeasureYPos + 1)&& counter_end == 0)
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
                                            if ((int)xpos == (_acquisitionTab.StartMeasureXPos + ReadParameter.MeasureDistance) && (int)ypos == (_acquisitionTab.StartMeasureYPos + 3) && counter_end == 2)
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
        #region Connection Click
        private void btn_connection_Click(object sender, EventArgs e)
        {

            if (_client != null)
            {
                _client.IP = IPAddress.Parse(ctrl_ip_address.Text);
                _generalSettings.General.IpAddress = ctrl_ip_address.Text;
                lock (_lockActionProcess)
                {
                    _threadAction = (_client.ClientIsConnected) ? eThreadAction.eClientDisconnect : eThreadAction.eClientConnect;
                    if (_client.ClientIsConnected)
                    {
                        _eventActionProcessControlList.Add(new sEventActionProcessControl(eThreadAction.eClientDisconnect, _generalSettings));
                    }
                    else
                    {
                        _eventActionProcessControlList.Add(new sEventActionProcessControl(eThreadAction.eClientConnect, _generalSettings));
                    }
                }
            }


        }
        #endregion
        #region Raw Execute Click
        private void btn_dnld_raw_execute_Click(object sender, EventArgs e)
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
                                btn_dnld_raw_execute.Image = Properties.Resources.FUNC_RUN;

                                string strFilePath = sfd_upload.FileName.ToString();
                                _cprojectSettings.Project.DataDirectoryFilename = strFilePath;
                                _cprojectSettings.Project.DataDirectory = strFilePath.Substring(0, strFilePath.LastIndexOf("\\"));
                                _cprojectSettings.Project.Filename = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1);

                                if (ck_multi_point_mea.Checked)
                                {
                                    _acquisitionTab.DoNextMeasure = true;
                                    for (int i = 0; i < lb_multi_measure_point.Items.Count; i++)
                                    {
                                        
                                        
                                        if (_acquisitionTab.DoNextMeasure)
                                        {
                                            movePositionAbsolute(Int32.Parse(MultiPointList[i][0]), Int32.Parse(MultiPointList[i][1]), Int32.Parse(MultiPointList[i][2]));
                                            _acquisitionTab.DoNextMeasure = false;
                                            Thread.Sleep(3000);
                                            if (Int32.Parse(ntb_x_cur_motorpos.Text) == Int32.Parse(MultiPointList[i][0]) &&
                                                Int32.Parse(ntb_y_cur_motorpos.Text) == Int32.Parse(MultiPointList[i][1]) &&
                                                Int32.Parse(ntb_z_cur_motorpos.Text) == Int32.Parse(MultiPointList[i][2]))
                                            {
                                                _cprojectSettings.Project.Filename = string.Format("{0}__{1}", i + 1, strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1));
                                                _cprojectSettings.Project.DataDirectoryFilename = string.Format("{0}\\{1}", _cprojectSettings.Project.DataDirectory, _cprojectSettings.Project.Filename);
                                                _threadActionProcess.EventUserList[(int)eThreadAction.StartRecordDataSample].Set();
                                                
                                                
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                        while (!_acquisitionTab.DoNextMeasure)
                                        {
                                            
                                        }
                                        if (!_acquisitionTab.Recording)
                                        {
                                            return;
                                        }
                                    }

                                }
                                else
                                {
                                    _threadActionProcess.EventUserList[(int)eThreadAction.StartRecordDataSample].Set();

                                    sw.Reset();//碼表歸零
                                    sw.Start();//碼表開始計時
                                }

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
        #endregion
        #region btn_engineer_Click
        /*
        private void btn_engineer_Click(object sender, EventArgs e)
        {
            
            
            //f_engineer_settings form = new f_engineer_settings();
            PasswordBox psForm = new PasswordBox();
            //form.EngineerSettings = _generalSettings.General;
            if (psForm.ShowDialog() == DialogResult.OK)
            {
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                f_engineer_settings form = new f_engineer_settings();
                form.ShowDialog(this);
                //_generalSettings.General = form.EngineerSettings;
                //_generalSettings.Save();
                    
                //}
            }
            else
            {
                MessageBox.Show("密碼錯誤!!");
                //e.Cancel = true;
            }
        }*/
        #endregion
        #region btn_show_data_Click
        private void btn_show_data_Click(object sender, EventArgs e)
        {

            if (rb_showdata_x.Checked)
            {
                ProcessStartInfo Info2 = new ProcessStartInfo();

                Info2.FileName = "ThickInspector.exe";//執行的檔案名稱

                Info2.WorkingDirectory = @"C:\Users\USER\Desktop\Velociraptor\Bin\Debug";//檔案所在的目錄

                Info2.Arguments = string.Format(@"{0} 1 0", _cprojectSettings.Project.DataDirectoryFilename);

                Process.Start(Info2);
            }
            else if (rb_showdata_y.Checked)
            {
                ProcessStartInfo Info2 = new ProcessStartInfo();

                Info2.FileName = "ThickInspector.exe";//執行的檔案名稱

                Info2.WorkingDirectory = @"C:\Users\USER\Desktop\Velociraptor\Bin\Debug";//檔案所在的目錄

                Info2.Arguments = string.Format(@"{0} 1 1", _cprojectSettings.Project.DataDirectoryFilename);

                Process.Start(Info2);
            }
            else
            {
                MessageBox.Show("請選擇切割道方向!!");
            }

        }
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
        #region btn_general_mode_Click
        private void btn_general_mode_Click(object sender, EventArgs e)
        {
            tabControlMain.TabPages.Remove(tbp_sodx); //Remove a tab page
            tabControlMain.TabPages.Remove(tbp_status); //Remove a tab page
            tabControlMain.TabPages.Remove(tbp_record); //Remove a tab page
            _curve_v2.IsVisible = _cursor_raw_v2.Visible = false;
            _curve_v3.IsVisible = _cursor_raw_v3.Visible = false;
            label_cursor_v1.Visible = false;
            chk_cursor_v1.Visible = false;
            nud_cursor_v1.Visible = false;
            label_cursor_v2.Visible = false;
            chk_cursor_v2.Visible = false;
            nud_cursor_v2.Visible = false;
            label_cursor_v3.Visible = false;
            chk_cursor_v3.Visible = false;
            nud_cursor_v3.Visible = false;
            label_noise_offset.Visible = false;
            hsb_noise_offset.Visible = false;
            label_dynamic.Visible = false;
            nud_dynamic.Visible = false;
            cbx_high_speed_mode.Visible = false;
            cbx_high_speed.Visible = false;
            label_hz.Visible = false;
            label_Scale.Visible = false;
            ntb_scale.Visible = false;
            label_ipaddress.Visible = false;
            ctrl_ip_address.Visible = false;
            label_first_channel.Visible = false;
            label_numberofchannels.Visible = false;
            ntb_dnld_first_channel.Visible = false;
            ntb_dnld_number_of_channels.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            btn_dark.Visible = false;
            btn_ClearAlarm.Visible = false;
        }
        #endregion
        #region btn_advanced_mode_Click
        private void btn_advanced_mode_Click(object sender, EventArgs e)
        {
            PasswordBox psForm = new PasswordBox();

            if (psForm.ShowDialog() == DialogResult.OK)
            {
                timer = new System.Timers.Timer(300000);//定時週期300秒
                timer.Elapsed += btn_general_mode_Click;//定時時間到的時候的回撥函式
                timer.AutoReset = false; //是否不斷重複定時器操作
                timer.Enabled = true; //定時器啟動
                Control.CheckForIllegalCrossThreadCalls = false;

                
                tabControlMain.TabPages.Add(tbp_sodx); //Add a tab page
                tabControlMain.TabPages.Add(tbp_status); //Add a tab page
                tabControlMain.TabPages.Add(tbp_record); //Add a tab page

                label_cursor_v1.Visible = true;
                chk_cursor_v1.Visible = true;
                nud_cursor_v1.Visible = true;
                label_cursor_v2.Visible = true;
                chk_cursor_v2.Visible = true;
                nud_cursor_v2.Visible = true;
                label_cursor_v3.Visible = true;
                chk_cursor_v3.Visible = true;
                nud_cursor_v3.Visible = true;
                label_noise_offset.Visible = true;
                hsb_noise_offset.Visible = true;
                label_dynamic.Visible = true;
                nud_dynamic.Visible = true;

                cbx_high_speed_mode.Visible = true;
                cbx_high_speed.Visible = true;
                label_hz.Visible = true;
                label_Scale.Visible = true;
                ntb_scale.Visible = true;
                label_ipaddress.Visible = true;
                ctrl_ip_address.Visible = true;
                label_first_channel.Visible = true;
                label_numberofchannels.Visible = true;
                ntb_dnld_first_channel.Visible = true;
                ntb_dnld_number_of_channels.Visible = true;
                groupBox1.Visible = true;
                groupBox3.Visible = true;
                btn_dark.Visible = true;
                btn_ClearAlarm.Visible = true;
            }
            else
            {
                MessageBox.Show("密碼錯誤!!");
            }
        }
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
        #region btn_settings_Click 
        /*
        private void btn_settings_Click(object sender, EventArgs e)
        {
            f_settings form = new f_settings();
            form.Settings = _generalSettings.General;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _generalSettings.General = form.Settings;
                _generalSettings.Save();
            }
        }*/
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
        #region btn_ClearAlarm_Click
        private void btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            UInt32 rc;

            //============================================================================ To Contents of Processing
            // Clears all the Machine Controller alarms. 
            //============================================================================
            rc = CMotionAPI.ymcClearAlarm(0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearAlarm \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }

        #endregion
        #region btn_record_wafer_center_point_Click
        private void btn_record_wafer_center_point_Click(object sender, EventArgs e)
        {
            ReadParameter.moveToWaferCenterPointXDistance = Int32.Parse(ntb_x_cur_motorpos.Text);
            ReadParameter.moveToWaferCenterPointYDistance = Int32.Parse(ntb_y_cur_motorpos.Text);
            ReadParameter.moveToWaferCenterPointZDistance = Int32.Parse(ntb_z_cur_motorpos.Text);
        }
        #endregion
        #region btn_move_distance_Click
        private void btn_move_distance_Click(object sender, EventArgs e)
        {
            KeyBoardForm _keyboardForm = new KeyBoardForm();//例項化一個Form2視窗
            _keyboardForm.StartPosition = FormStartPosition.CenterScreen;
            if (_keyboardForm.ShowDialog() == DialogResult.OK)
            {
                move_distance = int.Parse(_keyboardForm.T.Text);
                btn_move_distance.Text = _keyboardForm.T.Text;
            }
            else
            {
                MessageBox.Show("請輸入移動距離!!");
                
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
                move_distance = int.Parse(_keyboardForm.T.Text);
                btn_move_distance.Text = _keyboardForm.T.Text;
            }
            else
            {
                MessageBox.Show("請輸入移動距離!!");

            }
        }
        #endregion
        #region btn_die_count_Click
        private void btn_die_count_Click(object sender, EventArgs e)
        {
            KeyBoardForm _keyboardForm = new KeyBoardForm();//例項化一個Form2視窗
            _keyboardForm.StartPosition = FormStartPosition.CenterScreen;
            if (_keyboardForm.ShowDialog() == DialogResult.OK)
            {
                move_distance = int.Parse(_keyboardForm.T.Text);
                btn_die_count.Text = _keyboardForm.T.Text;
            }
            else
            {
                MessageBox.Show("請輸入要移動之die個數!!");
                
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
            ntb_x_cur_motorpos.Text = Get_X_MotorPos().ToString();
            ntb_y_cur_motorpos.Text = Get_Y_MotorPos().ToString();
            ntb_z_cur_motorpos.Text = Get_Z_MotorPos().ToString();
            
        }      
        #endregion
        #region cb_SelectMeasureDistance_SelectedIndexChanged
        private void cb_SelectMeasureDistance_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb_SelectMeasureDistance.SelectedIndex == 0)
            {
                ReadParameter.MeasureDistance = 100;
                if(ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 100;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 500;
                }
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 1)
            {
                ReadParameter.MeasureDistance = 200;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 200;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 1000;
                }        
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 2)
            {
                ReadParameter.MeasureDistance = 500;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 500;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 2500;
                }            
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 3)
            {
                ReadParameter.MeasureDistance = 1000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 1000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 5000;
                }
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 4)
            {
                ReadParameter.MeasureDistance = 2000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 2000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 10000;
                }
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 5)
            {
                ReadParameter.MeasureDistance = 5000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 5000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 25000;
                }
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 6)
            {
                //ReadParameter.measAxis0VelData = 340;
                ReadParameter.MeasureDistance = 10000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 10000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 50000;
                }
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 7)
            {
                //ReadParameter.measAxis0VelData = 200;
                ReadParameter.MeasureDistance = 20000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 20000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 100000;
                }
            }
            else if (cb_SelectMeasureDistance.SelectedIndex == 8)
            {
                //ReadParameter.measAxis0VelData = 199;
                ReadParameter.MeasureDistance = 50000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 50000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 250000;
                }
            }
            else
            {
                ReadParameter.MeasureDistance = 1000;
                if (ReadParameter.ScanningMode == 0)
                {
                    _acquisitionTab.NumberOfSamples = 1000;
                }
                else
                {
                    _acquisitionTab.NumberOfSamples = 5000;
                }
            }
        }
        #endregion
        #region ck_multi_point_mea_CheckedChanged
        private void ck_multi_point_mea_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_multi_point_mea.Checked)
            {
                gb_multi_point.Enabled = true;
            }
            else
            {
                gb_multi_point.Enabled = false;
            }
        }
        #endregion
        #region tabControlMain_Selecting
        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (tabControlMain.SelectedTab == tbp_sodx)
            {
                if (psengineerForm.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    MessageBox.Show("密碼錯誤!!");
                    e.Cancel = true;
                }
            }
            if (tabControlMain.SelectedTab == tbp_status)
            {
                if (psengineerForm.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    MessageBox.Show("密碼錯誤!!");
                    e.Cancel = true;
                }
            }
            if (tabControlMain.SelectedTab == tbp_record)
            {
                if (psengineerForm.ShowDialog() == DialogResult.OK)
                {

                }
                else
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
            if (client != null)
            {
                btn_connection.Image = (client.ClientIsConnected) ? Properties.Resources.FUNC_CONNECT : Properties.Resources.FUNC_DISCONNECT;
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
        private void _OnUpdateInitDownloadDisplay(Form form)
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

        #region 多點測量
        #region btn_add_measure_point_Click
        private void btn_add_measure_point_Click(object sender, EventArgs e)
        {
            MultiPointList.Add(new string[] { ntb_x_cur_motorpos.Text, ntb_y_cur_motorpos.Text, ntb_z_cur_motorpos.Text });
            lb_multi_measure_point.Items.Add(String.Format("{0},{1},{2}", ntb_x_cur_pos.Text, ntb_y_cur_pos.Text, ntb_z_cur_pos.Text));

        }
        #endregion

        #region  btn_remove_measure_point_Click
        private void btn_remove_measure_point_Click(object sender, EventArgs e)
        {
            MultiPointList.RemoveAt(lb_multi_measure_point.SelectedIndex);
            while (lb_multi_measure_point.SelectedItem != null)
            {
                lb_multi_measure_point.Items.Remove(lb_multi_measure_point.SelectedItem);
            }
        }
        #endregion

        #region btn_moveto_select_measure_point_Click
        private void btn_moveto_select_measure_point_Click(object sender, EventArgs e)
        {
            if (lb_multi_measure_point.SelectedItem != null)
            {
                movePositionAbsolute(Int32.Parse(MultiPointList[lb_multi_measure_point.SelectedIndex][0]), Int32.Parse(MultiPointList[lb_multi_measure_point.SelectedIndex][1]), Int32.Parse(MultiPointList[lb_multi_measure_point.SelectedIndex][2]));
            }
        }
        #endregion

        #region btn_clear_measure_point_list_Click
        private void btn_clear_measure_point_list_Click(object sender, EventArgs e)
        {
            MultiPointList.Clear();
            lb_multi_measure_point.Items.Clear();
        }
        #endregion

        #endregion

        #region 運動控制
        #region HomePosition
        private void HomePosition(Int32 arg_Velocity, Int32 arg_Approach, Int32 arg_Creep, Int32 arg_Position)
        {
            #region Performs zero point return.
            for (i = 0; i < 3; i++)
            {
                // Motion data setting at INPUT & phase C pulse method
                MotionDataForMove[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                /* Not Use MotionData[0].MoveType         = NULL; */
                MotionDataForMove[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;    // Speed [reference unit/s]
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;        // Time constant specified [ms]
                                                                                               /* Not Use MotionData[0].FilterType       = NULL; */
                MotionDataForMove[i].DataType = 0;                 // All parameters directly specified
                                                                   /* MotionData[0].MaxVelocity              = NULL; */
                MotionDataForMove[i].Acceleration = 100;               // Acceleration time constant [ms] 
                MotionDataForMove[i].Deceleration = 100;               // Deceleration time constant [ms]
                                                                       /* Not Use MotionData[0].FilterTime       = NULL; */
                MotionDataForMove[i].Velocity = arg_Velocity;      // Speed [reference unit/s]
                MotionDataForMove[i].ApproachVelocity = arg_Approach;      // Approach speed [reference unit/s]
                MotionDataForMove[i].CreepVelocity = arg_Creep;         // Creep speed [reference unit/s]

                PosForMove[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                PosForMove[i].PositionData = arg_Position;
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;
            }
            #endregion
            HomeMethod[0] = (UInt16)CMotionAPI.ApiDefs.HMETHOD_POT_ONLY;     // Zero point return method
            HomeMethod[1] = (UInt16)CMotionAPI.ApiDefs.HMETHOD_POT_ONLY;     // Zero point return method
            HomeMethod[2] = (UInt16)CMotionAPI.ApiDefs.HMETHOD_POT_ONLY;     // Zero point return method
            Direction[0] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;       // Moving direction
            Direction[1] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;       // Moving direction
            Direction[2] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;       // Moving direction
            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            rc = CMotionAPI.ymcMoveHomePosition(g_hDevice, MotionDataForMove, PosForMove, HomeMethod, Direction, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveHomePositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }
        #endregion
        #region btn_origin_return_Click
        private void btn_origin_return_Click(object sender, EventArgs e)
        {
            HomePosition(ReadParameter.OriginReturnVelocity, ReadParameter.OriginReturnApproachVelocity, ReadParameter.OriginReturnCreepVelocity, 0);
        }
        #endregion
        #region movePositionRelative
        private void movePositionRelative(int i, int sign, int distance)
        {
            #region sets the positioning parameter
            // Sets the positioning parameter.
            Int32[] VelDataForMove = new Int32[3];                     // Speed storage variable (for 3 axes)
            Int32[] PosDataForMove = new Int32[3];                     // Target position storage variable (for 3 axes)
            Int32[] AccDataForMove = new Int32[3];                     // Acceleration storage variable (for 3 axes)
            Int32[] DecDataForMove = new Int32[3];                     // Deceleration storage variable (for 3 axes)
            if (i == 0)
            {
                VelDataForMove[i] = ReadParameter.moveAxis0VelData;
                AccDataForMove[i] = ReadParameter.moveAxis0AccData;
                DecDataForMove[i] = ReadParameter.moveAxis0DecData;
                PosDataForMove[i] = sign * distance;
            }
            else if (i == 1)
            {
                VelDataForMove[i] = ReadParameter.moveAxis1VelData;
                AccDataForMove[i] = ReadParameter.moveAxis1AccData;
                DecDataForMove[i] = ReadParameter.moveAxis1DecData;
                PosDataForMove[i] = sign * distance;
            }
            else if (i == 2)
            {
                VelDataForMove[i] = ReadParameter.moveAxis2VelData;
                AccDataForMove[i] = ReadParameter.moveAxis2AccData;
                DecDataForMove[i] = ReadParameter.moveAxis2DecData;
                PosDataForMove[i] = sign * distance;
            }
            #endregion
            #region sets the motiondata position waitforcompletion
            // Loops as many times as the number of the connected axes in the window and sets as many parameters as the number of axes.
            // Performs positioning (ymcMoveDriverPositioning) after setting the data.
            // Motion data setting
            for (i = 0; i < 3; i++)
            {
                // Motion data setting
                MotionDataForMove[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
                MotionDataForMove[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                MotionDataForMove[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;
                MotionDataForMove[i].DataType = 0;
                MotionDataForMove[i].MaxVelocity    = 5000; 
                MotionDataForMove[i].Acceleration = AccDataForMove[i];
                MotionDataForMove[i].Deceleration = DecDataForMove[i];
                MotionDataForMove[i].FilterTime = 10;
                MotionDataForMove[i].Velocity = VelDataForMove[i];
                /* Not Use MotionData[i].ApproachVelocity = NULL; */
                /* Not Use MotionData[i].CreepVelocity    = NULL; */

                // Position data setting
                PosForMove[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                PosForMove[i].PositionData = PosDataForMove[i];

                // By setting the completion attribute to "COMMAND_STARTED (starting the command)," 
                // the control returns to the application immediately after positioning command execution.
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;
            }
            #endregion

            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMove, PosForMove, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }
        #endregion
        #region movePositionAbsolute
        private void movePositionAbsolute(int xpos, int ypos, int zpos)
        {
            #region sets the positioning parameter
            // Sets the positioning parameter.
            Int32[] VelDataForMove = new Int32[3];                     // Speed storage variable (for 3 axes)
            Int32[] PosDataForMove = new Int32[3];                     // Target position storage variable (for 3 axes)
            Int32[] AccDataForMove = new Int32[3];                     // Acceleration storage variable (for 3 axes)
            Int32[] DecDataForMove = new Int32[3];                     // Deceleration storage variable (for 3 axes)
            i = 0;
            VelDataForMove[i] = ReadParameter.moveAxis0VelData;
            AccDataForMove[i] = ReadParameter.moveAxis0AccData;
            DecDataForMove[i] = ReadParameter.moveAxis0DecData;
            PosDataForMove[i] = xpos;
            i = 1;
            VelDataForMove[i] = ReadParameter.moveAxis1VelData;
            AccDataForMove[i] = ReadParameter.moveAxis1AccData;
            DecDataForMove[i] = ReadParameter.moveAxis1DecData;
            PosDataForMove[i] = ypos;
            i = 2;
            VelDataForMove[i] = ReadParameter.moveAxis2VelData;
            AccDataForMove[i] = ReadParameter.moveAxis2AccData;
            DecDataForMove[i] = ReadParameter.moveAxis2DecData;
            PosDataForMove[i] = zpos;

            #endregion
            #region sets the motiondata position waitforcompletion
            // Loops as many times as the number of the connected axes in the window and sets as many parameters as the number of axes.
            // Performs positioning (ymcMoveDriverPositioning) after setting the data.
            // Motion data setting
            for (i = 0; i < 3; i++)
            {
                // Motion data setting
                MotionDataForMove[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
                MotionDataForMove[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                MotionDataForMove[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;
                MotionDataForMove[i].DataType = 0;
                MotionDataForMove[i].MaxVelocity    = 5000; 
                MotionDataForMove[i].Acceleration = AccDataForMove[i];
                MotionDataForMove[i].Deceleration = DecDataForMove[i];
                MotionDataForMove[i].FilterTime = 10;
                MotionDataForMove[i].Velocity = VelDataForMove[i];
                /* Not Use MotionData[i].ApproachVelocity = NULL; */
                /* Not Use MotionData[i].CreepVelocity    = NULL; */

                // Position data setting
                PosForMove[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                PosForMove[i].PositionData = PosDataForMove[i];

                // By setting the completion attribute to "COMMAND_STARTED (starting the command)," 
                // the control returns to the application immediately after positioning command execution.
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;
            }
            #endregion

            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMove, PosForMove, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }
        #endregion
        #region btn_PosingStop_Click
        private void btn_PosingStop_Click(object sender, EventArgs e)
        {
            #region set servor parameter
            Int32[] DecDataForMove = new Int32[3];                     // Deceleration storage variable (for 3 axes)
            i = 0;
            DecDataForMove[i] = ReadParameter.moveAxis0DecData;
            i = 1;
            DecDataForMove[i] = ReadParameter.moveAxis1DecData;
            i = 2;
            DecDataForMove[i] = ReadParameter.moveAxis2DecData;
            #endregion
            //============================================================================ To Contents of Processing
            // Loops as many times as the number of the connected axes in the window and sets as many parameters as the number of axes.
            // Executes the axis stop  (ymcStopMotion) after setting the data.
            //============================================================================
            for (i = 0; i < 3; i++)
            {
                /* Not Use MotionData[i].CoordinateSystem    = NULL; */
                /* Not Use MotionData[i].MoveType            = NULL; */
                /* Not Use MotionData[i].VelocityType        = NULL; */
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;    // Time constant specified [ms]
                /* Not Use MotionData[i].FilterType          = NULL; */
                MotionDataForMove[i].DataType = 0;             // All parameters directly specified
                /* Not Use MotionData[i].MaxVelocity         = NULL; */
                /* Not Use MotionData[i].Acceleration        = NULL; */
                MotionDataForMove[i].Deceleration = DecDataForMove[i];    // Deceleration time constant [ms]
                                                                          /* Not Use MotionData[i].FilterTime          = NULL; */
                                                                          /* Not Use MotionData[i].Velocity            = NULL; */
                                                                          /* Not Use MotionData[i].ApproachVelocity    = NULL; */
                                                                          /* Not Use MotionData[i].CreepVelocity       = NULL; */

                // By setting the completion attribute to "POSITIONING_COMPLETED,"
                // the control does not return to the application until completion of axis stop.
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }

            rc = CMotionAPI.ymcStopMotion(g_hDevice, MotionDataForMove, "Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

        }
        #endregion
        #region btn_moveto_WaferCenter_point_Click
        private void btn_moveto_WaferCenter_point_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance, ReadParameter.moveToWaferCenterPointYDistance, ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movex_positive_Click
        private void btn_movex_positive_Click(object sender, EventArgs e)
        {
            movePositionRelative(0, 1, move_distance);
        }
        #endregion
        #region btn_movex_negative_Click
        private void btn_movex_negative_Click(object sender, EventArgs e)
        {
            movePositionRelative(0, -1, move_distance);
        }
        #endregion
        #region btn_movey_positive_Click
        private void btn_movey_positive_Click(object sender, EventArgs e)
        {
            movePositionRelative(1, 1, move_distance);
        }
        #endregion
        #region btn_movey_negative_Click
        private void btn_movey_negative_Click(object sender, EventArgs e)
        {
            movePositionRelative(1, -1, move_distance);
        }
        #endregion
        #region btn_movez_positive_Click
        private void btn_movez_positive_Click(object sender, EventArgs e)
        {
            movePositionRelative(2, 1, move_distance);
        }
        #endregion
        #region btn_movez_negative_Click
        private void btn_movez_negative_Click(object sender, EventArgs e)
        {
            movePositionRelative(2, -1, move_distance);
        }
        #endregion
        #region btn_JOG_Positive_Start_Click 
        private void btn_JOG_Positive_Start_Click(object sender, EventArgs e)
        {
            #region set servor parameter
            UInt16[] Timeout = new UInt16[3];                    // Timeout time (for 3 axes)
            Int16[] Direction = new Int16[3];                   // JOG direction specified (for 3 axes)
            Int32[] VelData = new Int32[3];                     // Speed storage variable (for 3 axes)
            Int32[] AccData = new Int32[3];                     // Acceleration storage variable (for 3 axes)
            Int32[] DecData = new Int32[3];                     // Deceleration storage variable (for 3 axes)
            i = 0;
            VelData[i] = ReadParameter.moveJOGAxis0VelData;
            AccData[i] = ReadParameter.moveAxis0AccData;
            DecData[i] = ReadParameter.moveAxis0DecData;
            i = 1;
            VelData[i] = ReadParameter.moveJOGAxis1VelData;
            AccData[i] = ReadParameter.moveAxis1AccData;
            DecData[i] = ReadParameter.moveAxis1DecData;
            i = 2;
            VelData[i] = ReadParameter.moveJOGAxis2VelData;
            AccData[i] = ReadParameter.moveAxis2AccData;
            DecData[i] = ReadParameter.moveAxis2DecData;
            #endregion
            for (i = 0; i < 3; i++)
            {
                // Motion data setting
                MotionDataForMove[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;	// Work coordinate system
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;	// Incremental value specified
                MotionDataForMove[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;	// Speed [reference unit/s]
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;		// Time constant specified [ms]
                MotionDataForMove[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;	// Moving average filter (simplified S-curve)
                MotionDataForMove[i].DataType = 0;										// All parameters directly specified
                /* Not Use MotionData[i].MaxVelocity      = NULL; */
                MotionDataForMove[i].Acceleration = AccData[i];								// Acceleration time constant [ms] 
                MotionDataForMove[i].Deceleration = DecData[i];								// Deceleration time constant [ms]
                MotionDataForMove[i].FilterTime = 10;                                       // Filter time [0.1 ms]
                MotionDataForMove[i].Velocity = VelData[i];                                // Speed [reference unit/s]					
                                                                                           /* Not Use MotionData[i].ApproachVelocity = NULL; */
                                                                                           /* Not Use MotionData[i].CreepVelocity    = NULL; */
                Direction[i] = (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
                Timeout[i] = 1;
            }
            rc = CMotionAPI.ymcMoveJOG(g_hDevice, MotionDataForMove, Direction, Timeout, 0, "Start", 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveJOG Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }
        #endregion
        #region btn_JOG_Negative_Start_Click
        private void btn_JOG_Negative_Start_Click(object sender, EventArgs e)
        {
            #region set servor parameter
            UInt16[] Timeout = new UInt16[3];                    // Timeout time (for 3 axes)
            Int16[] Direction = new Int16[3];                   // JOG direction specified (for 3 axes)
            Int32[] VelData = new Int32[3];                     // Speed storage variable (for 3 axes)
            Int32[] AccData = new Int32[3];                     // Acceleration storage variable (for 3 axes)
            Int32[] DecData = new Int32[3];                     // Deceleration storage variable (for 3 axes)
            i = 0;
            VelData[i] = ReadParameter.moveJOGAxis0VelData;
            AccData[i] = ReadParameter.moveAxis0AccData;
            DecData[i] = ReadParameter.moveAxis0DecData;
            i = 1;
            VelData[i] = ReadParameter.moveJOGAxis1VelData;
            AccData[i] = ReadParameter.moveAxis1AccData;
            DecData[i] = ReadParameter.moveAxis1DecData;
            i = 2;
            VelData[i] = ReadParameter.moveJOGAxis2VelData;
            AccData[i] = ReadParameter.moveAxis2AccData;
            DecData[i] = ReadParameter.moveAxis2DecData;
            #endregion
            for (i = 0; i < 3; i++)
            {
                // Motion data setting
                MotionDataForMove[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;	// Work coordinate system
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;	// Incremental value specified
                MotionDataForMove[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;	// Speed [reference unit/s]
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;		// Time constant specified [ms]
                MotionDataForMove[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;	// Moving average filter (simplified S-curve)
                MotionDataForMove[i].DataType = 0;										// All parameters directly specified
                /* Not Use MotionData[i].MaxVelocity      = NULL; */
                MotionDataForMove[i].Acceleration = AccData[i];								// Acceleration time constant [ms] 
                MotionDataForMove[i].Deceleration = DecData[i];								// Deceleration time constant [ms]
                MotionDataForMove[i].FilterTime = 10;                                       // Filter time [0.1 ms]
                MotionDataForMove[i].Velocity = VelData[i];                                // Speed [reference unit/s]					
                                                                                           /* Not Use MotionData[i].ApproachVelocity = NULL; */
                                                                                           /* Not Use MotionData[i].CreepVelocity    = NULL; */
                Direction[i] = (Int16)CMotionAPI.ApiDefs.DIRECTION_NEGATIVE;
                Timeout[i] = 1;
            }
            rc = CMotionAPI.ymcMoveJOG(g_hDevice, MotionDataForMove, Direction, Timeout, 0, "Start", 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveJOG Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }
        #endregion
        #region btn_JOG_Stop_Click
        private void btn_JOG_Stop_Click(object sender, EventArgs e)
        {
            // Definition of Motion API Variables
            UInt16[] WaitForCompletion = new UInt16[3];  // Completion attribute storage variable (for 3 axes)
            UInt32 rc;                                 // Motion API return value
            Int16 i;                                  // Index of number of axes

            //============================================================================ To Contents of Processing
            // Sets the target board to 1.
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            //============================================================================
            // Stops the axis motion.
            //============================================================================
            for (i = 0; i < 2; i++)
            {
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }
            rc = CMotionAPI.ymcStopJOG(g_hDevice, 0, "Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopJOG Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
        }
        #endregion
        #region btn_movedie_xpositive_Click
        private void btn_movedie_xpositive_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance + die_count * _acquisitionTab.DieWidth,
                                ReadParameter.moveToWaferCenterPointYDistance,
                                ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movedie_xnegative_Click
        private void btn_movedie_xnegative_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance - die_count * _acquisitionTab.DieWidth,
                                 ReadParameter.moveToWaferCenterPointYDistance,
                                 ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movedie_ypositive_Click
        private void btn_movedie_ypositive_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance,
                                ReadParameter.moveToWaferCenterPointYDistance - die_count * _acquisitionTab.DieHeight,
                                ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movedie_ynegative_Click
        private void btn_movedie_ynegative_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance,
                                ReadParameter.moveToWaferCenterPointYDistance + die_count * _acquisitionTab.DieHeight,
                                ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_moveto_leftbottom_Click
        private void btn_moveto_leftbottom_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToLeftBottomXDistance, ReadParameter.moveToLeftBottomYDistance, ReadParameter.moveToLeftBottomZDistance);
        }
        #endregion
        #region btn_moveto_lefttop_Click
        private void btn_moveto_lefttop_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToLeftTopXDistance, ReadParameter.moveToLeftTopYDistance, ReadParameter.moveToLeftTopZDistance);
        }
        #endregion
        #region btn_moveto_rightbottom_Click
        private void btn_moveto_rightbottom_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToRightBottomXDistance, ReadParameter.moveToRightBottomYDistance, ReadParameter.moveToRightBottomZDistance);
        }
        #endregion
        #region btn_moveto_righttop_Click
        private void btn_moveto_righttop_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToRightTopXDistance, ReadParameter.moveToRightTopYDistance, ReadParameter.moveToRightTopZDistance);
        }
        #endregion
        #region btn_movedie_lefttop_Click
        private void btn_movedie_lefttop_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance - die_count * _acquisitionTab.DieWidth,
                                 ReadParameter.moveToWaferCenterPointYDistance - die_count * _acquisitionTab.DieHeight,
                                 ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movedie_righttop_Click
        private void btn_movedie_righttop_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance + die_count * _acquisitionTab.DieWidth,
                                 ReadParameter.moveToWaferCenterPointYDistance - die_count * _acquisitionTab.DieHeight,
                                 ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movedie_leftbottom_Click
        private void btn_movedie_leftbottom_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance - die_count * _acquisitionTab.DieWidth,
                                 ReadParameter.moveToWaferCenterPointYDistance + die_count * _acquisitionTab.DieHeight,
                                 ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_movedie_rightbottom_Click
        private void btn_movedie_rightbottom_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance + die_count * _acquisitionTab.DieWidth,
                                 ReadParameter.moveToWaferCenterPointYDistance + die_count * _acquisitionTab.DieHeight,
                                 ReadParameter.moveToWaferCenterPointZDistance);
        }
        #endregion
        #region btn_load_wafer_Click
        private void btn_load_wafer_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance,
                                 ReadParameter.moveToWaferCenterPointYDistance,
                                 0);
        }
        #endregion
        #region btn_unload_wafer_Click
        private void btn_unload_wafer_Click(object sender, EventArgs e)
        {
            movePositionAbsolute(ReadParameter.moveToWaferCenterPointXDistance,
                                 -128500,
                                 0);
        }
        #endregion
        #region Get_X_MotorPos
        private int Get_X_MotorPos()
        {
            #region ymcOpenController
            //在執行任何其他API之前，必須執行此API
            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            #endregion
            //============================================================================ To Contents of Processing
            // Gets the register data handle.
            // The obtained register number can be used in other threads.
            //============================================================================
            // OL Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OLx, ref hRegister_OLx);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle OL \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            //============================================================================ To Contents of Processing
            // Reads in the set register and displays the read-in data. 
            //============================================================================
            RegisterDataNumber = 1;

            return Reg_LongDataX[0];
        }
        #endregion
        #region Get_Y_MotorPos
        private int Get_Y_MotorPos()
        {
            #region ymcOpenController
            //在執行任何其他API之前，必須執行此API
            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            #endregion
            //============================================================================ To Contents of Processing
            // Gets the register data handle.
            // The obtained register number can be used in other threads.
            //============================================================================
            // OL Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OLy, ref hRegister_OLy);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle OL \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            //============================================================================ To Contents of Processing
            // Reads in the set register and displays the read-in data. 
            //============================================================================
            RegisterDataNumber = 1;
            rc = CMotionAPI.ymcGetRegisterData(hRegister_OLx, RegisterDataNumber, Reg_LongDataX, ref ReadDataNumber);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterData OLx \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            rc = CMotionAPI.ymcGetRegisterData(hRegister_OLy, RegisterDataNumber, Reg_LongDataY, ref ReadDataNumber);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterData OLy \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }

            return Reg_LongDataY[0];
        }
        #endregion
        #region Get_Z_MotorPos
        private int Get_Z_MotorPos()
        {
            #region ymcOpenController
            //在執行任何其他API之前，必須執行此API
            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            #endregion
            //============================================================================ To Contents of Processing
            // Gets the register data handle.
            // The obtained register number can be used in other threads.
            //============================================================================
            // OL Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OLz, ref hRegister_OLz);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle OL \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }
            //============================================================================ To Contents of Processing
            // Reads in the set register and displays the read-in data. 
            //============================================================================
            RegisterDataNumber = 1;
            rc = CMotionAPI.ymcGetRegisterData(hRegister_OLz, RegisterDataNumber, Reg_LongDataZ, ref ReadDataNumber);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterData OLz \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return 0;
            }

            return Reg_LongDataZ[0];
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
        private void OnInitDisplay(Form form)
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

        }
        #endregion   
        #region _OnUpdateInitDisplay
        private void _OnUpdateInitDisplay(Form form)
        {
            //SODX graphic-----------------------------------------------------------------
            ctrl_zgc_sodx.DisplayInit();
            ctrl_zgc_sodx.SetXAxisTitle("Fibers", Color.Black, Color.SkyBlue, 8);
            ctrl_zgc_sodx.SetYAxisTitle("Value", Color.Black, Color.SkyBlue, 8);
            ctrl_zgc_sodx.GraphPane.YAxis.Title.FontSpec.Angle = 90;
            ctrl_zgc_sodx.GraphPane.XAxis.Scale.Min = 90;
            ctrl_zgc_sodx.GraphPane.XAxis.Scale.Max = _generalSettings.General.Sensor.NumberOfFibers;
            ctrl_zgc_sodx.GraphPane.YAxis.Scale.Min = 0;
            ctrl_zgc_sodx.GraphPane.YAxis.Scale.Max = 0x7FFF;
            ctrl_zgc_sodx.AxisChange();
            btn_connection_Click(null, null);
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

                ntb_x_cur_pos.Text = "";
                ntb_y_cur_pos.Text = "";
                ntb_z_cur_pos.Text = "";

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
        private void DisplaySodxAcquisition(Form form)
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
        private void FocusClimbing()
        {
            int zpos = Get_Z_MotorPos();
            int zpos_MaxIntensity = Get_Z_MotorPos();
            if (-49000 < zpos && zpos < -48000)
            {
                for (int i = 0; i < 100; i++)
                {
                    movePositionRelative(2, -1, 1);
                    if (_fifoDataSample != null)
                    {
                        lock (_fifoDataSample)
                        {
                            while (_fifoDataSample.Count > 0)
                            {
                                cDataSample clsDataSample = (cDataSample)_fifoDataSample.Dequeue();
                                if (dataIntensityAverage < clsDataSample.SignalDataList[6].Average(0, true))
                                {
                                    dataIntensityAverage = clsDataSample.SignalDataList[6].Average(0, true);
                                    zpos = Get_Z_MotorPos();
                                }
                                else
                                {
                                    zpos_MaxIntensity = Get_Z_MotorPos();
                                }
                            }
                        }
                    }
                }
                movePositionAbsolute(Get_X_MotorPos(), Get_Y_MotorPos(), zpos_MaxIntensity);
            }
            else
            {
                movePositionAbsolute(Get_X_MotorPos(), Get_Y_MotorPos(), -48001);
                FocusClimbing();
            }
        }
    }
}

