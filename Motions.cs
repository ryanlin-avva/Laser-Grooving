using MagicServerLibrary;
using MotionAPI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Velociraptor
{
    class Motions
    {
        private bool isSimulate;
        private Dictionary<char, int> axis_map = new Dictionary<char, int>();
        private int _axis_num;
        private int _scan_mode;
        #region YASKAWA servor parameter control
        UInt32 g_hController = 0;				 // Controller handle				
        UInt32 g_hDevice;  // Device handle
        private CMotionAPI.MOTION_DATA[] MotionDataForMove = null;
        private CMotionAPI.POSITION_DATA[] PosForMove = null;
        private CMotionAPI.MOTION_DATA[] MotionDataForJog = null;
        private CMotionAPI.POSITION_DATA[] PosForJog = null;
        private CMotionAPI.MOTION_DATA[] MotionDataForMea = null;
        private CMotionAPI.POSITION_DATA[] PosForMea = null;
        private CMotionAPI.POSITION_DATA[] PosForMeaMoveDownY = null;
        private CMotionAPI.POSITION_DATA[] PosForMeaMoveForwardX = null;
        private CMotionAPI.POSITION_DATA[] PosForMeaMoveBackX = null;
        private Int16[] Direction = null;                                  // Moving direction
        private UInt16[] WaitForCompletion = null;
        private UInt16[] Timeout = null;
        private UInt16[] TimeoutMove = null;
        private UInt16[] HomeMethod = null;
        private UInt32[] hAxis = null;  // Axis handle
        private UInt32 rc;                                                           // Motion API return value
        #endregion
        public bool Init(string filename, ref string msg)
        {
            AVVAMotionParameters paraReader = new AVVAMotionParameters(filename);
            isSimulate = paraReader.IsSimulate();
            if (isSimulate) return true;
            _axis_num = paraReader.SetAxes(ref axis_map);
            _scan_mode = paraReader.ScanningMode;
            #region Variables allocation
            MotionDataForMea = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            PosForMea = new CMotionAPI.POSITION_DATA[_axis_num];    // POSITION_DATA structure
            PosForMeaMoveDownY = new CMotionAPI.POSITION_DATA[_axis_num];    // POSITION_DATA structure
            PosForMeaMoveForwardX = new CMotionAPI.POSITION_DATA[_axis_num];    // POSITION_DATA structure
            PosForMeaMoveBackX = new CMotionAPI.POSITION_DATA[_axis_num];    // POSITION_DATA structure
            MotionDataForMove = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            PosForMove = new CMotionAPI.POSITION_DATA[_axis_num];    // POSITION_DATA structure
            MotionDataForJog = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            PosForJog = new CMotionAPI.POSITION_DATA[_axis_num];    // POSITION_DATA structure
            Direction = new Int16[_axis_num];  //Jog direction                                // Moving direction
            WaitForCompletion = new UInt16[_axis_num];                          // Completion attribute storage variable
            Timeout = new UInt16[_axis_num];
            TimeoutMove = new UInt16[_axis_num];
            HomeMethod = new UInt16[_axis_num];
            hAxis = new UInt32[_axis_num];
            #endregion
            paraReader.SetAxisData(ref MotionDataForMea
                        , ref PosForMea
                        , ref PosForMeaMoveDownY
                        , ref PosForMeaMoveForwardX
                        , ref PosForMeaMoveBackX
                        , ref MotionDataForMove
                        , ref PosForMove
                        , ref MotionDataForJog
                        , ref PosForJog
                        , ref WaitForCompletion
                        , ref Direction
                        , ref TimeoutMove
                        , ref Timeout);
            #region H/W initialization
            if (!SetMotorOn(ref msg)) return false;
            return true;
        }

        public int ScanMode()
        {
            return _scan_mode;
        }
        private bool SetMotorOn(ref string msg)
        {
            //YASKAWA servor setting
            #region ymcOpenController
            //Sets the ymcOpenController parameters                             
            CMotionAPI.COM_DEVICE ComDevice;
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCIe_MODE;
            ComDevice.PortNumber = 1;
            ComDevice.CpuNumber = 1;    //cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber = 0;
            ComDevice.IPAddress = "";    //ctrl_ip_address.Text
            ComDevice.Timeout = 10000;

            //在執行任何其他API之前，必須執行此API
            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            #region Sets the motion API timeout                               
            // Sets the motion API timeout.			
            rc = CMotionAPI.ymcSetAPITimeoutValue(50000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            #region Clear and reCreates the axis handle      
            // Deletes the axis handle that is held by the Machine Controller.
            rc = CMotionAPI.ymcClearAllAxes();
            //rc = CMotionAPI.ymcClearAxis(hAxis[0]);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            for (int i = 0; i < _axis_num; i++)
            {
                string AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    msg = String.Format("Error ymcDeclareAxis \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                    return false;
                }
            }
            #endregion
            #region Gets the device handle
            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            #region Executes servo ON
            //打開由設備手柄指定軸的伺服
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            msg = "Servo On";
            return true;
            #endregion
        }
        public void MotorOff()
        {
            // Executes servo OFF-- By best effort
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if (rc != CMotionAPI.MP_SUCCESS) return;
            //Deletes the device handle created in this thread. 
            rc = CMotionAPI.ymcClearDevice(g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS) return;
            //Close the Controller.
            rc = CMotionAPI.ymcCloseController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS) return;
        }
        public bool Move5um(int measureDistance, ref string msg)
        {
            PosForMea[0].PositionData = measureDistance;
            for (int i=0; i<_axis_num; i++)
            {
                MotionDataForMea[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                MotionDataForMea[i].MaxVelocity = 2000;
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }
            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMea, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            // Deletes the device handle.
            rc = CMotionAPI.ymcClearDevice(g_hDevice);
            // Error check processing
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            msg = "Move succeeded";
            return true;
        }
        public bool Move1um(int measureDistance, ref string msg)
        {
            PosForMea[0].PositionData = measureDistance;
            for (int i=0; i<_axis_num; i++)
            {
                MotionDataForMea[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_UNIT_PAR;
                MotionDataForMea[i].MaxVelocity = 2000;
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.LATCH_COMPLETED;
            }
            PosForMeaMoveForwardX[0].PositionData = measureDistance - 1;
            PosForMeaMoveDownY[0].PositionData = 0;
            PosForMeaMoveBackX[0].PositionData = -measureDistance + 1;
            PosForMeaMoveForwardX[1].PositionData = 0;
            PosForMeaMoveDownY[1].PositionData = 1;
            PosForMeaMoveBackX[1].PositionData = PosForMea[1].PositionData;
            PosForMeaMoveForwardX[2].PositionData = 0;
            PosForMeaMoveDownY[2].PositionData = PosForMea[2].PositionData;
            PosForMeaMoveBackX[2].PositionData = PosForMea[2].PositionData;

            rc = CMotionAPI.ymcDeclareDevice(3, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            Thread.Sleep(80);
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMea, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }

            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            Thread.Sleep(80);
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveBackX, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }

            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            Thread.Sleep(80);
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveForwardX, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }

            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            Thread.Sleep(80);
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveBackX, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }

            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            Thread.Sleep(80);
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveForwardX, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            // Deletes the device handle.
            rc = CMotionAPI.ymcClearDevice(g_hDevice);
            // Error check processing
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                msg = String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            msg = "Move succeeded";
            return true;
        }

    }
}
