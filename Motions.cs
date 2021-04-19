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
        private MotionParamReader _paraReader;
        public int _axis_num;
        public int _scan_mode;     
        private string err_msg = "";
        private int center_pos_x;
        private int center_pos_y;
        
        #region YASKAWA servor parameter control
        UInt32 g_hController = 0; // Controller handle				
        UInt32 g_hDevice;         // Device handle
        UInt32[] hAxis = null;    // Axis handle
        private CMotionAPI.COM_DEVICE ComDevice ;
        private CMotionAPI.MOTION_DATA[] MotionData = null;     
        private CMotionAPI.POSITION_DATA[] Pos = null;
        private String[] _registerName = { "IL8010", "IL8090", "IL8110" ,"IL818E"};//X，Y，Z，R
        private UInt16[] Direction = null; // Moving direction
        private UInt16[] WaitForCompletion = null;       
        private UInt32 rc;                 // Motion API return value
        #endregion

        #region Init
        public bool Init(string filename)
        {
            string cur_path = AppDomain.CurrentDomain.BaseDirectory;
            _paraReader = new MotionParamReader(cur_path+filename);

            isSimulate = _paraReader.IsSimulate();
            if (isSimulate) return true;

            
            _axis_num = _paraReader.SetAxesMap(ref axis_map);
            _scan_mode = _paraReader.ScanningMode;

            #region Variables allocation
            MotionData = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure          
            Pos = new CMotionAPI.POSITION_DATA[_axis_num];
            Direction = new UInt16[_axis_num]; 
            WaitForCompletion = new UInt16[_axis_num]; 
            hAxis = new UInt32[_axis_num];
            #endregion


            #region variables initialization
            //Set variables from parameter files
            _paraReader.SetAxisMotionData(ref MotionData);

            for (int i=0; i<_axis_num; i++)
            {
                Pos[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                Pos[i].PositionData = 0;
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
                // By setting the completion attribute to "COMMAND_STARTED (starting the command)," 
                // the control returns to the application immediately after positioning command execution.
                Direction[i] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;       
            }
            #endregion

            #region H/W initialization
            if (!MotorOn()) return false;
            #endregion
            return true;
        }
        #endregion
        #region MotorOn
        public bool MotorOn()
        {
            //YASKAWA servor setting
            SetComDevice();
            if (!OpenController()) return false;                         
            if (!SetAPITimeoutValue()) return false;
            if (!ClearAllAxes()) return false;
            if (!CreateAxisHandle()) return false;
            if (!DeclareDevice()) return false;
            if (!ServoControlOn()) return false;

            return true;
        }
        #endregion
        #region MotorOff
        public void MotorOff()
        {
            if (isSimulate) return;

            // Executes servo OFF-- By best effort      
            if (!ServoControlOff()) return;

            //Deletes the device handle created in this thread. 
            if (!ClearDevice()) return;

            //Close the Controller.
            rc = CMotionAPI.ymcCloseController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS) return;
        }
        #endregion
        #region GoHome
        public bool GoHome()
        {
            if (isSimulate) return true;

           
            UInt16[] HomeMethod = new UInt16[_axis_num];
            for (int i = 0; i < _axis_num; i++)
            {
                HomeMethod[i] = (UInt16)CMotionAPI.ApiDefs.HMETHOD_POT_ONLY; // Zero point return method
                Direction[i] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
                MotionData[i].Velocity = 100000;
            }

            rc = CMotionAPI.ymcMoveHomePosition(g_hDevice, MotionData, Pos, HomeMethod, Direction, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveHomePositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region JogY
        public bool JogY(bool toStart, bool isPositive = true)
        {
            if (isSimulate) return true;
            #region Velocity To 0
            CMotionAPI.MOTION_DATA[] JogMotionData = (CMotionAPI.MOTION_DATA[])MotionData.Clone();
            for (int i = 0; i < _axis_num; i++)
            {
                JogMotionData[i].Velocity = 0; 
            }
            #endregion
            if (toStart)
            {
                ushort[] timeout = new ushort[_axis_num];
                short[] direction = new short[_axis_num];
                int my_axis = axis_map['Y'];
                if (my_axis == -1)
                {
                    err_msg = "Axis Y NOT Found";
                    return false;
                }

                timeout[my_axis] = 1;
                JogMotionData[my_axis].Velocity = 20;
                direction[my_axis] = (isPositive)
                                            ? (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE
                                            : (Int16)CMotionAPI.ApiDefs.DIRECTION_NEGATIVE;
                rc = CMotionAPI.ymcMoveJOG(g_hDevice, JogMotionData, direction, timeout, 0, "Start", 0);
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
        #endregion
        #region GetPos
        public int GetPos(char axis_char)
        {
            if (isSimulate) return 1;

            int my_axis = axis_map[axis_char];
            if (my_axis == -1) return 0;
            UInt32 hRegister = 0;

            if (!OpenController()) return 0;

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
        #endregion
        #region MoveTo
        public bool MoveTo(char axis_char, double distance, bool isRelative = true)
        {
            if (isSimulate) return true;
            //TO-DO 加上轉動的double

            return true;
        }
        #endregion
        #region MoveTo
        public bool MoveTo(char axis_char, int distance, bool isRelative = true)
        {
            if (isSimulate) 
            {
                MoveTest(0,distance);
                return true; 
            }
               

            int my_axis = axis_map[axis_char];
            if (my_axis == -1)
            {
                err_msg = "Axis " + axis_char + " NOT Found";
                return false;
            }

            CMotionAPI.POSITION_DATA[] move_pos = (CMotionAPI.POSITION_DATA[])Pos.Clone();
            CMotionAPI.MOTION_DATA[] motion_data = (CMotionAPI.MOTION_DATA[])MotionData.Clone();
            move_pos[my_axis].PositionData = distance;

            //Keep other axis to be relative, and pos = 0
            //=> No impact on axis except the assigned one
            for (int i = 0; i < _axis_num; i++)
                motion_data[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
            if (!isRelative)
                motion_data[my_axis].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
            if (motion_data[my_axis].Velocity == 0)
                return false;

            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, motion_data, move_pos, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region MoveTo
        //Default use relative move
        //If use absolute move, ONLY SPECIFIED AXIS ARE SET TO ABS
        public bool MoveTo(char[] axis_char, int[] distance, bool isRelative)
        {
            if (isSimulate) return true;

            CMotionAPI.POSITION_DATA[] move_pos = (CMotionAPI.POSITION_DATA[])Pos.Clone();
            CMotionAPI.MOTION_DATA[] motion_data = (CMotionAPI.MOTION_DATA[])MotionData.Clone();
            for (int i = 0; i < _axis_num; i++)
                motion_data[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;

            for (int i = 0; i < axis_char.Length; i++)
            {
                int my_axis = axis_map[axis_char[i]];
                if (my_axis == -1)
                {
                    err_msg = "Axis " + axis_char[i] + " NOT Found";
                    return false;
                }
                move_pos[my_axis].PositionData = distance[i];
                if (!isRelative)
                    motion_data[my_axis].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
                if (motion_data[my_axis].Velocity == 0)
                    return false;
            }

            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, motion_data, move_pos, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region Move5um
        public bool Move5um(int measureDistance)
        {
            for (int i = 0; i < _axis_num; i++)
            {             
                MotionData[i].Velocity = 10000;
            }
            if (MoveTo('X', measureDistance, true) != true)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region Move1um
        public bool Move1um(int measureDistance)
        {
            if (isSimulate) return true;

            int[] move_x = { measureDistance, -measureDistance + 1 , measureDistance - 1
                            , -measureDistance + 1 , measureDistance - 1};
            CMotionAPI.POSITION_DATA[] PosForMeaMoveX = (CMotionAPI.POSITION_DATA[])Pos.Clone();
            CMotionAPI.POSITION_DATA[] PosForMeaMoveDownY = (CMotionAPI.POSITION_DATA[])Pos.Clone();

            PosForMeaMoveDownY[1].PositionData = 1;
            for (int i = 0; i < _axis_num; i++)
            {
                MotionData[i].Velocity = 10000;
            }
            for (int i=0; i< 5; i++)
            {
                PosForMeaMoveX[0].PositionData = move_x[i];
                rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionData, PosForMeaMoveX, 0, "Start", WaitForCompletion, 0);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                    return false;
                }

                Thread.Sleep(80);

                rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionData, PosForMeaMoveDownY, 0, "Start", WaitForCompletion, 0);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                    return false;
                }
            }
            err_msg = "Move succeeded";
            return true;
        }
        #endregion
        #region StopMove
        public bool StopMove()
        {
            if (isSimulate) return true;

            rc = CMotionAPI.ymcStopMotion(g_hDevice, MotionData, "Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region ClearAlarm
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
        #endregion
        #region GetErrorMsg
        public string GetErrorMsg()
        {
            return err_msg;
        }
        #endregion
        #region ScanMode
        public int ScanMode()
        {
            return _scan_mode;
        }
        #endregion
        #region GetCenterPos
        public void GetCenterPos(ref int[] distance)
        {
            distance[0] = _paraReader.moveToWaferCenterPointXDistance;
            distance[1] = _paraReader.moveToWaferCenterPointYDistance;
            distance[2] = 0;
        }
        #endregion
        #region GetLoadPos
        public void GetLoadPos(ref int[] distance)
        {
            distance[0] = _paraReader.moveToWaferCenterPointXDistance;
            distance[1] = -128500;
            distance[2] = 0;
        }
        #endregion 
        
        private void MoveTest(int axis,int distance)
        {     
            SetComDevice();
            if (!OpenController()) return;
            if(!SetAPITimeoutValue())return;
            if (!ClearAllAxes()) return;
            if (!CreateAxisHandle()) return;
            if (!DeclareDevice()) return;
            if (!ServoControlOn()) return;


            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionData, Pos, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return;
            }
        }



        #region basic Function
        #region SetComDevice
        public void SetComDevice()
        {
            //============================================================================ To Contents of Processing
            // Establishes the communications with the Machine Controller.
            // Must be called for each thread.
            //============================================================================
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCIe_MODE;
            ComDevice.PortNumber = 1;
            ComDevice.CpuNumber = 1;    //cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber = 0;
            ComDevice.IPAddress = "";
            ComDevice.Timeout = 10000;
        }
        #endregion
        #region ClearDevice
        private bool ClearDevice()
        {
            // Deletes the device handle.
            rc = CMotionAPI.ymcClearDevice(g_hDevice);
            // Error check processing
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region  SetAPITimeoutValue
        private bool SetAPITimeoutValue()
        {
            //============================================================================ To Contents of Processing
            // Sets the motion API timeout.			
            // Prevents the host application from freezing due to Machine Controller fault.

            //***** Must be called for each thread.******//

            //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region CreateAxisHandle
        private bool CreateAxisHandle()
        {
            //============================================================================ To Contents of Processing
            // Creates an axis handle.
            // The obtained axis handle can be used as global data by processing.
            // The following calls the ymcDeclareAxis as many times as the connected axes set in the window and creates an axis handle.
            //============================================================================                                                         
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
            return true;
        }
        #endregion
        #region DeclareDevice
        private bool DeclareDevice()
        {
            //============================================================================ To Contents of Processing
            // Creates a device handle using the axis handle obtained by the ymcDeclareAxis.
            // The following sets the number of connected axes as one device.
            // The device handle is needed for each thread.
            // Therefore, the device handle created here cannot be used for any other thread.
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice((UInt16)_axis_num, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region  OpenController
        private bool OpenController()
        {
            //在執行任何其他API之前，必須執行此API
            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcOpenController  \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region ServoControlOn
        private bool ServoControlOn()
        {
            //============================================================================ To Contents of Processing
            // Executes servo ON.							
            // Servo ON is executed using the created device handle.
            // All the set axes connected are servo ON.
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region ServoControlOff
        private bool ServoControlOff()
        {
            //============================================================================ To Contents of Processing
            // Executes servo Off.						
            // Servo Off is executed using the created device handle.
            // All the set axes connected are servo Off.
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion
        #region  ClearAllAxes
        private bool ClearAllAxes()
        {
            // Deletes the axis handle that is held by the Machine Controller.
            rc = CMotionAPI.ymcClearAllAxes();
            //rc = CMotionAPI.ymcClearAxis(hAxis[0]);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                err_msg = String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]", rc.ToString("X"));
                return false;
            }
            return true;
        }
        #endregion      
        #endregion
    }
}
