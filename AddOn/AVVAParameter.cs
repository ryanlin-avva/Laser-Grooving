using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Velociraptor.AddOn
{
    
    public class AVVAParameter
    {
        private string filePath;
        private StringBuilder lpReturnedString;
        private int bufferSize;
        #region trigger parameter
        public int EnableTriggerDuringReturnMovement;
        public int ChooseAxis;
        public int EndlessRountripTrigger;
        public int SetStopPosition;
        public int SetTriggerInterval;
        public int SetStartPosition;
        public int SelectEncoderTriggerSource;
        public int MeasureDistance;
        #endregion
        #region pos parameter
        public int measAxis0VelData;
        public int measAxis0AccData;
        public int measAxis0DecData;
        
        public int measAxis1VelData;
        public int measAxis1AccData;
        public int measAxis1DecData;
        public int measAxis1PosData;
        public int measAxis2VelData;
        public int measAxis2AccData;
        public int measAxis2DecData;
        public int measAxis2PosData;

        public int moveAxis0VelData;
        public int moveAxis0AccData;
        public int moveAxis0DecData;

        public int moveAxis1VelData;
        public int moveAxis1AccData;
        public int moveAxis1DecData;

        public int moveAxis2VelData;
        public int moveAxis2AccData;
        public int moveAxis2DecData;

        public int moveJOGAxis0VelData;
        public int moveJOGAxis1VelData;
        public int moveJOGAxis2VelData;


        public int moveToWaferCenterPointXDistance;
        public int moveToWaferCenterPointYDistance;
        public int moveToWaferCenterPointZDistance;
        public int moveToLeftTopXDistance;
        public int moveToLeftTopYDistance;
        public int moveToLeftTopZDistance;
        public int moveToLeftBottomXDistance;
        public int moveToLeftBottomYDistance;
        public int moveToLeftBottomZDistance;
        public int moveToRightTopXDistance;
        public int moveToRightTopYDistance;
        public int moveToRightTopZDistance;
        public int moveToRightBottomXDistance;
        public int moveToRightBottomYDistance;
        public int moveToRightBottomZDistance;
       

        public int OriginReturnVelocity;
        public int OriginReturnApproachVelocity;
        public int OriginReturnCreepVelocity;
        #endregion
        #region Scan parameter
        public int ScanningMode;
        #endregion
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string lpString, string lpFileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        

        public AVVAParameter(string iniPath)
        {
            filePath = iniPath;
            bufferSize = 512;
            lpReturnedString = new StringBuilder(bufferSize);

           

            #region Sets the trigger parameter
            EnableTriggerDuringReturnMovement = int.Parse(ReadIniFile("TriggerParameter", "EnableTriggerDuringReturnMovement", "0"));
            ChooseAxis = int.Parse(ReadIniFile("TriggerParameter", "ChooseAxis", "0"));
            EndlessRountripTrigger = int.Parse(ReadIniFile("TriggerParameter", "EndlessRountripTrigger", "0"));
            SetStopPosition = int.Parse(ReadIniFile("TriggerParameter", "SetStopPosition", "0"));
            SetTriggerInterval = int.Parse(ReadIniFile("TriggerParameter", "SetTriggerInterval", "0"));
            SetStartPosition = int.Parse(ReadIniFile("TriggerParameter", "SetStartPosition", "0"));
            SelectEncoderTriggerSource = int.Parse(ReadIniFile("TriggerParameter", "SelectEncoderTriggerSource", "0"));
            MeasureDistance = int.Parse(ReadIniFile("TriggerParameter", "MeasureDistance", "0"));
            #endregion
            #region Sets the pos parameter
            measAxis0VelData = int.Parse(ReadIniFile("PositioningParameter", "measAxis0VelData", "0"));
            measAxis0AccData = int.Parse(ReadIniFile("PositioningParameter", "measAxis0AccData", "0"));
            measAxis0DecData = int.Parse(ReadIniFile("PositioningParameter", "measAxis0DecData", "0"));
            
            measAxis1VelData = int.Parse(ReadIniFile("PositioningParameter", "measAxis1VelData", "0"));
            measAxis1AccData = int.Parse(ReadIniFile("PositioningParameter", "measAxis1AccData", "0"));
            measAxis1DecData = int.Parse(ReadIniFile("PositioningParameter", "measAxis1DecData", "0"));
            measAxis1PosData = int.Parse(ReadIniFile("PositioningParameter", "measAxis1PosData", "0"));
            measAxis2VelData = int.Parse(ReadIniFile("PositioningParameter", "measAxis2VelData", "0"));
            measAxis2AccData = int.Parse(ReadIniFile("PositioningParameter", "measAxis2AccData", "0"));
            measAxis2DecData = int.Parse(ReadIniFile("PositioningParameter", "measAxis2DecData", "0"));
            measAxis2PosData = int.Parse(ReadIniFile("PositioningParameter", "measAxis2PosData", "0"));

            moveAxis0VelData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis0VelData", "0"));
            moveAxis0AccData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis0AccData", "0"));
            moveAxis0DecData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis0DecData", "0"));

            moveAxis1VelData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis1VelData", "0"));
            moveAxis1AccData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis1AccData", "0"));
            moveAxis1DecData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis1DecData", "0"));

            moveAxis2VelData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis2VelData", "0"));
            moveAxis2AccData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis2AccData", "0"));
            moveAxis2DecData = int.Parse(ReadIniFile("PositioningParameter", "moveAxis2DecData", "0"));

            moveJOGAxis0VelData = int.Parse(ReadIniFile("PositioningParameter", "moveJOGAxis0VelData", "0"));
            moveJOGAxis1VelData = int.Parse(ReadIniFile("PositioningParameter", "moveJOGAxis1VelData", "0"));
            moveJOGAxis2VelData = int.Parse(ReadIniFile("PositioningParameter", "moveJOGAxis2VelData", "0"));


            moveToWaferCenterPointXDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToWaferCenterPointXDistance", "0"));
            moveToWaferCenterPointYDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToWaferCenterPointYDistance", "0"));
            moveToWaferCenterPointZDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToWaferCenterPointZDistance", "0"));
            moveToLeftTopXDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToLeftTopXDistance", "0"));
            moveToLeftTopYDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToLeftTopYDistance", "0"));
            moveToLeftTopZDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToLeftTopZDistance", "0"));
            moveToLeftBottomXDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToLeftBottomXDistance", "0"));
            moveToLeftBottomYDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToLeftBottomYDistance", "0"));
            moveToLeftBottomZDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToLeftBottomZDistance", "0"));
            moveToRightTopXDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToRightTopXDistance", "0"));
            moveToRightTopYDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToRightTopYDistance", "0"));
            moveToRightTopZDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToRightTopZDistance", "0"));
            moveToRightBottomXDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToRightBottomXDistance", "0"));
            moveToRightBottomYDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToRightBottomYDistance", "0"));
            moveToRightBottomZDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToRightBottomZDistance", "0"));


            OriginReturnVelocity = int.Parse(ReadIniFile("PositioningParameter", "OriginReturnVelocity", "0"));
            OriginReturnApproachVelocity = int.Parse(ReadIniFile("PositioningParameter", "OriginReturnApproachVelocity", "0"));
            OriginReturnCreepVelocity = int.Parse(ReadIniFile("PositioningParameter", "OriginReturnCreepVelocity", "0"));
            #endregion
            #region Sets the Scan parameter
            ScanningMode = int.Parse(ReadIniFile("ScanParameter", "ScanningMode", "0"));
            #endregion
        }

        // read ini date depend on section and key
        public string ReadIniFile(string section, string key, string defaultValue)
        {
            lpReturnedString.Clear();
            GetPrivateProfileString(section, key, defaultValue, lpReturnedString, bufferSize, filePath);
            
            return lpReturnedString.ToString();
        }

        // write ini data depend on section and key
        public void WriteIniFile(string section, string key, Object value)
        {
            WritePrivateProfileString(section, key, value.ToString(), filePath);
        }


        
    }
}
