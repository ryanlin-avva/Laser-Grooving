using System;

namespace Velociraptor
{
    class Constants
    {
        static public string paraFilename = "AVVAParam.ini";
        static public string motionParaFilename = "AVVAMotionConfig.ini";
        static public string appConfigFolder = "c:/avva/MeasureConfig/";
        static public int AutoMeasureDistance = 1000; //um
        static public int MeasureScanBuffer = 100; //um
        static public int MeasureScanVelocity = 1000; //um
        static public double[] MoveVelocity = { 10000, 10000, 10000, 5000 }; //um,um,um,0.001度
        static public double XLimitBuffer = -10;
        public const string RDPassword = "80480662";
        //----------------------------------------
        //Timer設定 (unit:ms)
        //----------------------------------------
        public const int INTL_gui_update = 100;
        public const int INTL_Engineering_mode = 300000;
        public const int INTL_DataSaveDelay = 10000;
        public const int INTL_ConnectRetryDelay = 10000;
        //----------------------------------------
        //Precitec參數
        //----------------------------------------
        public const int PREC_FirstChannel = 0;
        public const int PREC_NumberOfChannels = 192;

        //----------------------------------------
        //方向代碼
        //----------------------------------------
        public const int WAY_HORIZONTAL = 0;
        public const int WAY_VERTICAL = 1;
        public const int WAY_NOTHING = -1;
        public const int WAY_CNT = 2;

        //----------------------------------------
        //影像處理
        //----------------------------------------
        public const int COLINE_MAX_DIST = 100;
        public const double COLINE_ANGLE = 0.174;
        public const int IMAGE_PROC_MAX_COUNT = 5;
        public const int LINE_THICKNESS = 5;
        //與最低/高投影量在HINT_TOLERNCE之內者，視為是切割道
        public const double HINT_TOLERNCE = 5;
        //在擬線前，線段選取範圍的最小長度不能大於這個值(大約1/4 FOV)
        //否則碰到大die，很可能找不到適當的線段
        public const int SELECT_LENGTH_LOWER_BOUND = 500;
        //切割道寬度
        public const int SCRIBE_LINE_WIDTH = 40;
        //切割道顏色
        public const bool SCRIBE_IS_DARK = true;
    }
}
