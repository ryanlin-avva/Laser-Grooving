using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using MotionAPI;

namespace Velociraptor
{
    public class MotionParamReader
    {
        private string filePath;
        private StringBuilder lpReturnedString;
        private int bufferSize;
        #region axis parameter
        private int axis_x;
        private int axis_y;
        private int axis_z;
        private int axis_r;
        private int axis_a; //leave for extension
        private int axis_b;
        private int axis_num;
        private int isSim;
        #endregion
        #region pos parameter
        public int moveToWaferCenterPointXDistance;
        public int moveToWaferCenterPointYDistance;
        public int moveToWaferCenterPointZDistance;
        #endregion
        #region Scan parameter
        public int ScanningMode;
        #endregion
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string lpString, string lpFileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public MotionParamReader(string iniPath)
        {
            filePath = iniPath;
            bufferSize = 512;
            lpReturnedString = new StringBuilder(bufferSize);

            #region Gets Axis parameters
            axis_x = int.Parse(ReadIniFile("AxisMapping", "X", "-1"));
            axis_y = int.Parse(ReadIniFile("AxisMapping", "Y", "-1"));
            axis_z = int.Parse(ReadIniFile("AxisMapping", "Z", "-1"));
            axis_r = int.Parse(ReadIniFile("AxisMapping", "R", "-1"));
            axis_a = int.Parse(ReadIniFile("AxisMapping", "A", "-1"));
            axis_b = int.Parse(ReadIniFile("AxisMapping", "B", "-1")); 
            axis_num = int.Parse(ReadIniFile("AxisMapping", "Num", "4")); 
            isSim = int.Parse(ReadIniFile("AxisMapping", "Simulate", "0"));
            #endregion

            //Get Wafer Center Position
            moveToWaferCenterPointXDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToWaferCenterPointXDistance", "0"));
            moveToWaferCenterPointYDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToWaferCenterPointYDistance", "0"));
            moveToWaferCenterPointZDistance = int.Parse(ReadIniFile("PositioningParameter", "moveToWaferCenterPointZDistance", "0"));

            //Gets the Scan parameter
            ScanningMode = int.Parse(ReadIniFile("ScanParameter", "ScanningMode", "0"));
        }
        public bool IsSimulate()
        {
            return (isSim == 1)? true: false;
        }
        public int SetAxes(ref Dictionary<char, int> axis_map)
        {
            axis_map.Add('X', axis_x);
            axis_map.Add('Y', axis_y);
            axis_map.Add('Z', axis_z);
            axis_map.Add('R', axis_r);
            axis_map.Add('A', axis_a);
            axis_map.Add('B', axis_b);
            return axis_num;
        }
        
        public void SetAxisData(ref CMotionAPI.MOTION_DATA[] MotionDataForMea
                              , ref CMotionAPI.MOTION_DATA[] MotionDataForMove
                              , ref CMotionAPI.MOTION_DATA[] MotionDataForJogY
                              , ref CMotionAPI.MOTION_DATA[] MotionDataForHome
                                )
        {
            //sets the positioning parameter
            for (int i = 0; i < axis_num; i++)
            {
                #region Measure Motion Data Setting
                string phrase = "measAxis" + i.ToString();
                MotionDataForMea[i].Velocity = int.Parse(ReadIniFile("PositioningParameter", phrase + "VelData", "0"));
                MotionDataForMea[i].Acceleration = int.Parse(ReadIniFile("PositioningParameter", phrase + "AccData", "0"));
                MotionDataForMea[i].Deceleration = int.Parse(ReadIniFile("PositioningParameter", phrase + "DecData", "0"));
                MotionDataForMea[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                MotionDataForMea[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
                MotionDataForMea[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                MotionDataForMea[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                MotionDataForMea[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;
                MotionDataForMea[i].DataType = 0;
                MotionDataForMea[i].FilterTime = 10;
                MotionDataForMea[i].MaxVelocity = 2000;
                #endregion

                #region Move Motion Data Setting
                string phrase1 = "moveAxis" + i.ToString();
                MotionDataForMove[i].Velocity = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "VelData", "0"));
                MotionDataForMove[i].Acceleration = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "AccData", "0"));
                MotionDataForMove[i].Deceleration = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "DecData", "0"));
                MotionDataForMove[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;	// Work coordinate system
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;	// Incremental value specified
                MotionDataForMove[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;	// Speed [reference unit/s]
                MotionDataForMove[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;		// Time constant specified [ms]
                MotionDataForMove[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;	// Moving average filter (simplified S-curve)
                MotionDataForMove[i].DataType = 0;										// All parameters directly specified
                MotionDataForMove[i].FilterTime = 10;                                       // Filter time [0.1 ms]
                #endregion

                #region JOG Motion Data Setting
                string phrase2 = "moveJOGAxis" + i.ToString();
                MotionDataForJogY[i].Velocity = int.Parse(ReadIniFile("PositioningParameter", phrase2 + "VelData", "0")); // Speed [reference unit/s]					
                MotionDataForJogY[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;	// Work coordinate system
                MotionDataForJogY[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;	// Incremental value specified
                MotionDataForJogY[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;	// Speed [reference unit/s]
                MotionDataForJogY[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;		// Time constant specified [ms]
                MotionDataForJogY[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;	// Moving average filter (simplified S-curve)
                MotionDataForJogY[i].DataType = 0;										// All parameters directly specified
                MotionDataForJogY[i].FilterTime = 10;                                       // Filter time [0.1 ms]
                MotionDataForJogY[i].Acceleration = MotionDataForMove[i].Acceleration;
                MotionDataForJogY[i].Deceleration = MotionDataForMove[i].Deceleration;
                #endregion

                #region Home Setting
                MotionDataForHome[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                MotionDataForHome[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;    // Speed [reference unit/s]
                MotionDataForHome[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;        // Time constant specified [ms]
                MotionDataForMove[i].DataType = 0;                 // All parameters directly specified
                MotionDataForMove[i].Acceleration = 100;               // Acceleration time constant [ms] 
                MotionDataForMove[i].Deceleration = 100;               // Deceleration time constant [ms]
                MotionDataForMove[i].Velocity = int.Parse(ReadIniFile("PositioningParameter", "OriginReturnVelocity", "0"));
                MotionDataForMove[i].ApproachVelocity = int.Parse(ReadIniFile("PositioningParameter", "OriginReturnApproachVelocity", "0"));
                MotionDataForMove[i].CreepVelocity = int.Parse(ReadIniFile("PositioningParameter", "OriginReturnCreepVelocity", "0"));
                #endregion
            }
        }
        // read ini date depend on section and key
        private string ReadIniFile(string section, string key, string defaultValue)
        {
            lpReturnedString.Clear();
            GetPrivateProfileString(section, key, defaultValue, lpReturnedString, bufferSize, filePath);
            
            return lpReturnedString.ToString();
        }

        // write ini data depend on section and key
        private void WriteIniFile(string section, string key, Object value)
        {
            WritePrivateProfileString(section, key, value.ToString(), filePath);
        }       
    }
}
