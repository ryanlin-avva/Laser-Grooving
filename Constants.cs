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
       

        //----------------------------------------
        //Timer設定 (unit:ms)
        //----------------------------------------
        public const int INTL_gui_update = 100;
        public const int INTL_Engineering_mode = 300000;
        public const int INTL_DataSaveDelay = 300000;
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
        //錯誤代碼
        //----------------------------------------
        public const int E_OK = 0;
        public const int E_ERROR = E_NOISETOOMUCH;
        //超過可容許群組數量後的回傳值
        //目前處理方式：縮減threshold的容許範圍
        public const int E_NOISETOOMUCH = 1000;
        //長度最接近邊長的前半數組別與其左方組別中
        //找不到兩者角度差都落在THETA_ALLOWANCE範圍內的組別
        //縮小collinear的max_dist或angle
        public const int E_TARGETNOTFOUND = 1001;
        //運用另一組推估角度搜尋符合線條失敗
        //放寬threshold範圍
        //或是增加collinear的max_dist
        public const int E_INFERREDLINEFAIL = 1002;
        //找不到任何線段
        public const int E_NOLINEFOUND = 1003;

        //----------------------------------------
        //線段grouping運算
        //----------------------------------------
        //可容許的水平/垂直傾斜量，超過的線條會被略過
        //如果MAX_THETA_LIMIT設得比THETA_ALLOWANCE大太多
        //且裡面可選擇的群組太少，可能會得到E_TARGETNOTFOUND的錯誤
        public const double MAX_THETA_LIMIT = Math.PI * 3 / 180f;
        //每組線段經合併後最多可容許幾條
        public const int MAX_GROUP_NUM = 3;
        //組內線段可允許的最大距離為min(GROUP_TOLERENCE*Die邊長,MAX_GROUP_TOLERENCE)
        public const double GROUP_TOLERENCE_RATE = 0.05;
        public const double MAX_GROUP_TOLERENCE = 80;
        //組內線段合併可允許的座標偏移量(pixels)
        public const int CONCAT_ALLOWANCE = 20;
        //1. 組內線段合併可允許的角度偏移量(about 0.5 degree)
        //2. 標竿群組配對時，兩條線段可允許的角度差異
        public const double THETA_ALLOWANCE = 0.009;
        //組間距離與邊長倍數差的可接受範圍比
        public const double MAX_GAP_DEVIATION_RATE = 0.1; //將近30度

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
