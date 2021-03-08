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
        #region trigger parameter
        public int MeasureDistance;
        #endregion
        #region pos parameter

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

        public MotionParamReader(string iniPath)
        {
            filePath = iniPath;
            bufferSize = 512;
            lpReturnedString = new StringBuilder(bufferSize);

            #region Gets Axis parameters
            axis_x = int.Parse(ReadIniFile("AxisMapping", "X", "0"));
            axis_y = int.Parse(ReadIniFile("AxisMapping", "Y", "1"));
            axis_z = int.Parse(ReadIniFile("AxisMapping", "Z", "2"));
            axis_r = int.Parse(ReadIniFile("AxisMapping", "R", "3"));
            axis_a = int.Parse(ReadIniFile("AxisMapping", "A", "-1"));
            axis_b = int.Parse(ReadIniFile("AxisMapping", "B", "-1")); 
            axis_num = int.Parse(ReadIniFile("AxisMapping", "Num", "4")); 
            isSim = int.Parse(ReadIniFile("AxisMapping", "Simulate", "0"));
            #endregion

            #region Gets the trigger parameter
            MeasureDistance = int.Parse(ReadIniFile("TriggerParameter", "MeasureDistance", "0"));
            #endregion

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
        public bool IsSimulate()
        {
            return (isSim == 1)? true: false;
        }
        public int SetAxes(ref Dictionary<char, int> axis_map)
        {
            if (axis_x != -1) axis_map.Add('X', axis_x);
            if (axis_y != -1) axis_map.Add('Y', axis_y);
            if (axis_z != -1) axis_map.Add('Z', axis_z);
            if (axis_r != -1) axis_map.Add('R', axis_r);
            if (axis_a != -1) axis_map.Add('A', axis_a);
            if (axis_b != -1) axis_map.Add('B', axis_b);
            return axis_num;
        }
        
        public void SetAxisData(ref CMotionAPI.MOTION_DATA[] MotionDataForMea
                              , ref CMotionAPI.POSITION_DATA[] PosForMea
                              , ref CMotionAPI.POSITION_DATA[] PosForMeaMoveDownY
                              , ref CMotionAPI.POSITION_DATA[] PosForMeaMoveForwardX
                              , ref CMotionAPI.POSITION_DATA[] PosForMeaMoveBackX
                              , ref CMotionAPI.MOTION_DATA[] MotionDataForMove
                              , ref CMotionAPI.POSITION_DATA[] PosForMove
                              , ref CMotionAPI.MOTION_DATA[] MotionDataForJog
                              , ref CMotionAPI.POSITION_DATA[] PosForJog
                              , ref UInt16[] WaitForCompletion
                              , ref Int16[] Direction                   // JOG direction specified (for 3 axes)
                              , ref UInt16[] TimeoutMove
                              , ref UInt16[] Timeout)
        {
            #region sets the positioning parameter
            for (int i = 0; i < axis_num; i++)
            {
                string phrase = "measAxis" + i.ToString();
                #region Measure Motion Data Setting
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
                //If no axis[0]'s positionData, use measureDistance
                PosForMea[i].PositionData = int.Parse(ReadIniFile("PositioningParameter", phrase + "PosData", MeasureDistance.ToString()));
                PosForMea[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                #endregion

                #region Move Motion Data Setting
                string phrase1 = "moveAxis" + i.ToString();
                MotionDataForMove[i].Velocity = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "VelData", "0"));
                MotionDataForMove[i].Acceleration = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "AccData", "0"));
                MotionDataForMove[i].Deceleration = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "DecData", "0"));
                PosForMove[i].PositionData = int.Parse(ReadIniFile("PositioningParameter", phrase1 + "PosData", "0"));
                #endregion

                #region JOG Motion Data Setting
                string phrase2 = "moveJOGAxis" + i.ToString();
                MotionDataForJog[i].Acceleration = MotionDataForMove[i].Acceleration; // ms
                MotionDataForJog[i].Deceleration = MotionDataForMove[i].Deceleration;// ms
                MotionDataForJog[i].Velocity = int.Parse(ReadIniFile("PositioningParameter", phrase2 + "VelData", "0")); // Speed [reference unit/s]					
                MotionDataForJog[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;	// Work coordinate system
                MotionDataForJog[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;	// Incremental value specified
                MotionDataForJog[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;	// Speed [reference unit/s]
                MotionDataForJog[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;		// Time constant specified [ms]
                MotionDataForJog[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;	// Moving average filter (simplified S-curve)
                MotionDataForJog[i].DataType = 0;                                      // All parameters directly specified
                MotionDataForJog[i].FilterTime = 10;                                       // Filter time [0.1 ms]
                #endregion

                #region 1um measurement setting
                string phrase3 = "moveAxis" + i.ToString();
                PosForMeaMoveDownY[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                PosForMeaMoveForwardX[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                PosForMeaMoveBackX[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                #endregion

                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
                Direction[i] = (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
                Timeout[i] = 0;
                TimeoutMove[i] = 1;
            }

            moveJOGAxis0VelData = 
            moveJOGAxis1VelData = int.Parse(ReadIniFile("PositioningParameter", "moveJOGAxis1VelData", "0"));
            moveJOGAxis2VelData = int.Parse(ReadIniFile("PositioningParameter", "moveJOGAxis2VelData", "0"));
            #region sets the motiondata position waitforcompletion
            // Loops as many times as the number of the connected axes in the window and sets as many parameters as the number of axes.
            // Performs positioning (ymcMoveDriverPositioning) after setting the data.
            // Motion data setting 
            #endregion
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
