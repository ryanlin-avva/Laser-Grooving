using MagicServerLibrary;
using MotionAPI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Velociraptor
{
    /************************************************
     * For all public motion functions
     * ADD SIMULATION ASSERTION
     * *********************************************/

    public class Motions
    {
        private bool isSimulate;
        private Dictionary<char, int> axis_map = new Dictionary<char, int>();
        private int _axis_num;
        private int _scan_mode;
        private MotionParamReader _paraReader;
        private string err_msg = "";
        #region YASKAWA servor parameter control
        UInt32 g_hController = 0; // Controller handle				
        UInt32 g_hDevice;  // Device handle
        private CMotionAPI.MOTION_DATA[] MotionDataForMove = null;
        private CMotionAPI.MOTION_DATA[] MotionDataForJogY = null;
        private CMotionAPI.MOTION_DATA[] MotionDataForMea = null;
        private CMotionAPI.MOTION_DATA[] MotionDataForHome = null;
        private CMotionAPI.POSITION_DATA[] PosForMove = null;
        private String[] _registerName = { "IL8010", "IL8090", "IL8110" };
        private UInt16[] Direction = null; // Moving direction
        private UInt16[] WaitForCompletion = null;
        private UInt16[] WaitForStart = null;
        private UInt32[] hAxis = null;  // Axis handle
        private UInt32 rc; // Motion API return value
        #endregion
        public bool Init(string filename)
        {
            string cur_path = AppDomain.CurrentDomain.BaseDirectory;
            _paraReader = new MotionParamReader(cur_path+filename);
            isSimulate = _paraReader.IsSimulate();
            if (isSimulate) return true;
            _axis_num = _paraReader.SetAxes(ref axis_map);
            _scan_mode = _paraReader.ScanningMode;
            #region Variables allocation
            MotionDataForMea = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            MotionDataForMove = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            MotionDataForJogY = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            MotionDataForHome = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            PosForMove = new CMotionAPI.POSITION_DATA[_axis_num];
            Direction = new UInt16[_axis_num]; 
            WaitForCompletion = new UInt16[_axis_num]; 
            WaitForStart = new UInt16[_axis_num]; 
            hAxis = new UInt32[_axis_num];
            #endregion
            #region variables initialization
            //Set variables from parameter files
            _paraReader.SetAxisData(ref MotionDataForMea
                        , ref MotionDataForMove
                        , ref MotionDataForJogY
                        , ref MotionDataForHome
                        );
            //Set variables with frequently used values
            int my_y = axis_map['Y'];
            for (int i=0; i<_axis_num; i++)
            {
                PosForMove[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                PosForMove[i].PositionData = 0;
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
                // By setting the completion attribute to "COMMAND_STARTED (starting the command)," 
                // the control returns to the application immediately after positioning command execution.
                WaitForStart[i] = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;
                Direction[i] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
                //將非Y方向的JOG速度都設為0
                if (i != my_y) MotionDataForJogY[i].Velocity = 0;
            }
            #endregion
            #region H/W initialization
            if (!SetMotorOn()) return false;
            #endregion
            return true;
        }

        public int ScanMode()
        {
            return _scan_mode;
        }
        public bool MoveTo(char axis_char, int distance, bool isRelative = true)
        {
            if (isSimulate) return true;
            int my_axis = axis_map[axis_char];
            CMotionAPI.POSITION_DATA[] move_pos = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
            move_pos[my_axis].PositionData = distance;
            //Keep other axis to be relative, and pos = 0
            //=> No impact on axis except the assigned one
            for (int i = 0; i < _axis_num; i++)
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
            if (!isRelative)
                MotionDataForMove[my_axis].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMove, move_pos, 0, "Start", WaitForStart, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        //Default use relative move
        //If use absolute move, ONLY SPECIFIED AXIS ARE SET TO ABS
        public bool MoveTo(char[] axis_char, int[] distance, bool isRelative)
        {
            if (isSimulate) return true;
            CMotionAPI.POSITION_DATA[] move_pos = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
            for (int i = 0; i < _axis_num; i++)
                MotionDataForMove[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;

            for (int i = 0; i < axis_char.Length; i++)
            {
                int my_axis = axis_map[axis_char[i]];
                move_pos[my_axis].PositionData = distance[i];
                if (!isRelative)
                    MotionDataForMove[my_axis].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
            }
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMove, move_pos, 0, "Start", WaitForStart, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        public int GetPos(char axis_char)
        {
            if (isSimulate) return 1;
            int my_axis = axis_map[axis_char];
            UInt32 hRegister = 0;
            rc = CMotionAPI.ymcGetRegisterDataHandle(_registerName[my_axis], ref hRegister);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcGetRegisterDataHandle OL \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return 0;
            }
            Int32[] RegData = new Int32[1];
            UInt32 ReadDataNumber = 0;
            rc = CMotionAPI.ymcGetRegisterData(hRegister, 1, RegData, ref ReadDataNumber);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcGetRegisterData OLy \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return 0;
            }
            return RegData[0];
        }
        public bool Move5um(int measureDistance)
        {
            if (isSimulate) return true;
            CMotionAPI.POSITION_DATA[] pos = new CMotionAPI.POSITION_DATA[_axis_num];
            pos = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
            pos[0].PositionData = measureDistance;
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea
                                , PosForMove, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            err_msg = "Move succeeded";
            return true;
        }
        public bool Move1um(int measureDistance)
        {
            if (isSimulate) return true;
            int[] move_x = { measureDistance, -measureDistance + 1 , measureDistance - 1
                            , -measureDistance + 1 , measureDistance - 1};
            CMotionAPI.POSITION_DATA[] PosForMeaMoveX = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
            CMotionAPI.POSITION_DATA[] PosForMeaMoveDownY = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
            PosForMeaMoveDownY[1].PositionData = 1;
            for (int i=0; i< 5; i++)
            {
                PosForMeaMoveX[0].PositionData = move_x[i];
                rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveX, 0, "Start", WaitForCompletion, 0);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                    return false;
                }
                Thread.Sleep(80);
                rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionDataForMea, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                    return false;
                }
            }
            err_msg = "Move succeeded";
            return true;
        }
        public bool JogY(bool toStart, bool isPositive=true)
        {
            if (isSimulate) return true;
            if (toStart)
            {
                ushort[] timeout = new ushort[_axis_num];
                short[] direction = new short[_axis_num];
                timeout[axis_map['Y']] = 1;
                direction[axis_map['Y']] = (isPositive)
                                            ? (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE
                                            : (Int16)CMotionAPI.ApiDefs.DIRECTION_NEGATIVE;
                rc = CMotionAPI.ymcMoveJOG(g_hDevice, MotionDataForJogY, direction, timeout, 0, "Start", 0);
            }
            else
            {
                rc = CMotionAPI.ymcStopJOG(g_hDevice, 0, "Stop", WaitForCompletion, 0);
            }
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveJOG/StopJOG Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        public bool GoHome()
        {
            if (isSimulate) return true;
            UInt16[] WaitForCompletion = new UInt16[_axis_num];
            UInt16[] HomeMethod = new UInt16[_axis_num];
            for (int i=0; i<_axis_num; i++)
            {
                HomeMethod[i] = (UInt16)CMotionAPI.ApiDefs.HMETHOD_POT_ONLY; // Zero point return method
            }
            rc = CMotionAPI.ymcMoveHomePosition(g_hDevice, MotionDataForHome, PosForMove, HomeMethod, Direction, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveHomePositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        public void GetCenterPos(ref int[] distance)
        {
            distance[0] = _paraReader.moveToWaferCenterPointXDistance;
            distance[1] = _paraReader.moveToWaferCenterPointYDistance;
            distance[2] = 0;
        }
        public void GetLoadPos(ref int[] distance)
        {
            distance[0] = _paraReader.moveToWaferCenterPointXDistance;
            distance[1] = -128500;
            distance[2] = 0;
        }
        public bool StopMove()
        {
            if (isSimulate) return true;
            rc = CMotionAPI.ymcStopMotion(g_hDevice, MotionDataForMove, "Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        public bool ClearAlarm()
        {
            if (isSimulate) return true;
            rc = CMotionAPI.ymcClearAlarm(0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcClearAlarm \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        public void MotorOff()
        {
            if (isSimulate) return;
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
        public string GetErrorMsg()
        {
            return err_msg;
        }
        private bool SetMotorOn()
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
                err_msg = String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            #region Sets the motion API timeout                               
            // Sets the motion API timeout.			
            rc = CMotionAPI.ymcSetAPITimeoutValue(50000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            #region Clear and reCreates the axis handle      
            // Deletes the axis handle that is held by the Machine Controller.
            rc = CMotionAPI.ymcClearAllAxes();
            //rc = CMotionAPI.ymcClearAxis(hAxis[0]);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            for (int i = 0; i < _axis_num; i++)
            {
                string AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    err_msg = String.Format("Error ymcDeclareAxis \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                    return false;
                }
            }
            #endregion
            #region Gets the device handle
            rc = CMotionAPI.ymcDeclareDevice((ushort)_axis_num, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            #region Executes servo ON
            //打開由設備手柄指定軸的伺服
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            #endregion
            return true;
        }
    }
}
