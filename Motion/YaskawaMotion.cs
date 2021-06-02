using MotionAPI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Avva.MotionFramework
{
    public class YaskawaMotion: IAvvaMotion, IDisposable
    {
        private static log4net.ILog _log;
		private int _axis_num;
		#region YASKAWA servor parameter control
		UInt32 g_hController = 0; // Controller handle				
        UInt32 g_hDevice;  // Device handle
        private CMotionAPI.COM_DEVICE ComDevice;
        private CMotionAPI.MOTION_DATA[] MotionData = null;
        private CMotionAPI.POSITION_DATA[] PosForMove = null;
        private String[] _registerName = {"IL8010","IL8090","IL8110","IL818E" };
        private UInt16[] WaitForCompletion = null;
        private UInt16[] WaitForStart = null;
        private UInt32[] hAxis = null;  // Axis handle
        private UInt32 rc; // Motion API return value
		#endregion
		private bool IsDisposed { get; set; }
		public log4net.ILog log { set { _log = value; } }
		public YaskawaMotion() { }
		public void Init(AxisData[] axes, AxisData[] home)
        {
			_axis_num = axes.Length;
			#region Yaskawa Variables allocation
			MotionData = new CMotionAPI.MOTION_DATA[_axis_num]; // MOTION_DATA structure
            PosForMove = new CMotionAPI.POSITION_DATA[_axis_num];
            WaitForCompletion = new UInt16[_axis_num];
            WaitForStart = new UInt16[_axis_num]; 
            hAxis = new UInt32[_axis_num];
            #endregion
            #region variables initialization
            //Set variables with frequently used values
            for (int i = 0; i < _axis_num; i++)
            {
				#region Motion Data Setting
				MotionData[i].Velocity = (int)(axes[i].Velocity);
				MotionData[i].Acceleration = (int)(axes[i].Acceleration);
				MotionData[i].Deceleration = (int)(axes[i].Deceleration);
				MotionData[i].CoordinateSystem = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
				MotionData[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
				MotionData[i].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
				MotionData[i].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
				MotionData[i].FilterType = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;
				MotionData[i].DataType = 0;
				MotionData[i].FilterTime = 10;
				MotionData[i].MaxVelocity = 200000;
				MotionData[i].Acceleration = 100;               // Acceleration time constant [ms] 
				MotionData[i].Deceleration = 100;               // Deceleration time constant [ms]
				MotionData[i].ApproachVelocity = (int)(home[i].Velocity);
				MotionData[i].CreepVelocity = (int)(home[i].Velocity);
                #endregion
				//Position template
                PosForMove[i].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
				PosForMove[i].PositionData = 0;
				//Wait Type template
				WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
				WaitForStart[i] = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;
            }
            #endregion
        }
		public void MoveTo(int axis, double distance,double velocity, bool isRelative = true)
		{
			BaseMoveTo(axis, distance, velocity, WaitForCompletion,isRelative);
		}
		public void MoveTo(int[] axis, double[] distance,double[] velocity, bool isRelative)
		{
			BaseMoveTo(axis, distance,velocity, WaitForCompletion, isRelative);
		}
		public void AsyncMoveTo(int axis, double distance,double velocity, bool isRelative = true)
		{
			BaseMoveTo(axis, distance,velocity, WaitForStart, isRelative);
		}
		public void AsyncMoveTo(int[] axis, double[] distance,double[] velocity, bool isRelative)
        {
            BaseMoveTo(axis, distance,velocity, WaitForStart, isRelative);
        }
		private void BaseMoveTo(int axis, double distance, double velocity, UInt16[] waitType, bool isRelative = true)
		{
			CMotionAPI.POSITION_DATA[] move_pos = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
			CMotionAPI.MOTION_DATA[] motion_data = (CMotionAPI.MOTION_DATA[])MotionData.Clone();
			move_pos[axis].PositionData = (int)distance;
			//Keep other axis to be relative, and pos = 0
			//=> No impact on axis except the assigned one
			motion_data[axis].Velocity = (int)velocity;
			for (int i = 0; i < _axis_num; i++)
				motion_data[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
			if (!isRelative)
				motion_data[axis].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
			OpenController();
			DeclareDevice();
			rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, motion_data, move_pos, 0, "Start", waitType, 0);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				throw new AvvaMotionException("ymcMoveDriverPositioning error-" + MyErrorCode.ErrorMessage(rc));
			}
			ClearDevice();
		}
		//Default use relative move
		//If use absolute move, ONLY SPECIFIED AXIS ARE SET TO ABS
		private void BaseMoveTo(int[] axis, double[] distance,double[] velocity, UInt16[] waitType, bool isRelative)
		{
			CMotionAPI.POSITION_DATA[] move_pos = (CMotionAPI.POSITION_DATA[])PosForMove.Clone();
			for (int i = 0; i < _axis_num; i++)
			{
				MotionData[i].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
			}

			for (int i = 0; i < axis.Length; i++)
			{
				move_pos[axis[i]].PositionData = (int)distance[i];
				MotionData[axis[i]].Velocity = (int)velocity[i];
				if (!isRelative)
					MotionData[axis[i]].MoveType = (Int16)CMotionAPI.ApiDefs.MTYPE_ABSOLUTE;
			}
			OpenController();
			DeclareDevice();
			rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionData, move_pos, 0, "Start", waitType, 0);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				throw new AvvaMotionException("ymcMoveDriverPositioning error-" + MyErrorCode.ErrorMessage(rc));
			}
			ClearDevice();
		}
		public double GetPos(int axis)
        {
            UInt32 hRegister = 0;
			OpenController();
			rc = CMotionAPI.ymcGetRegisterDataHandle(_registerName[axis], ref hRegister);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcGetRegisterDataHandle error-" + MyErrorCode.ErrorMessage(rc));
			}
			Int32[] RegData = new Int32[1];
            UInt32 ReadDataNumber = 0;
            rc = CMotionAPI.ymcGetRegisterData(hRegister, 1, RegData, ref ReadDataNumber);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcGetRegisterData error-" + MyErrorCode.ErrorMessage(rc));
			}
			CloseController();
			return RegData[0];
        }
        public void JogStart(int axis, bool isPositive = true)
        {
            ushort[] timeout = new ushort[_axis_num];
            short[] direction = new short[_axis_num];

            timeout[axis] = 1;
            direction[axis] = (isPositive)
                                ? (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE
                                : (Int16)CMotionAPI.ApiDefs.DIRECTION_NEGATIVE;

			CMotionAPI.MOTION_DATA[] MotionDataForJog = (CMotionAPI.MOTION_DATA[])MotionData.Clone();
			for (int i = 0; i < _axis_num; i++)
			{
				//將非JOG方向的速度都設為0
				if (i != axis) MotionDataForJog[i].Velocity = 0;
			}
			
			rc = CMotionAPI.ymcMoveJOG(g_hDevice, MotionDataForJog, direction, timeout, 0,"Start", 0);

            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcMoveJOG error-" + MyErrorCode.ErrorMessage(rc));
			}
		
		}
        public void JogStop()
        {
		
			rc = CMotionAPI.ymcStopJOG(g_hDevice, 0,"Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcStopJOG error-" + MyErrorCode.ErrorMessage(rc));
			}
		
		}
        public void GoHome()
        {
            UInt16[] HomeMethod = new UInt16[_axis_num];
			UInt16[] Direction = new UInt16[_axis_num];
			
			for (int i = 0; i < _axis_num; i++)
            {
				Direction[i] = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
				HomeMethod[i] = (UInt16)CMotionAPI.ApiDefs.HMETHOD_POT_ONLY; // Zero point return method
            }
            rc = CMotionAPI.ymcMoveHomePosition(g_hDevice, MotionData, PosForMove, HomeMethod, Direction, 0,"Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcMoveHomePosition error-" + MyErrorCode.ErrorMessage(rc));
			}
		
		}
        public void GoHome(int[] axis)
        {
            throw new AvvaMotionException("Only all axes go home supported");
        }
        public void StopMove()
        {
			
			rc = CMotionAPI.ymcStopMotion(g_hDevice, MotionData,"Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcStopMotion error-" + MyErrorCode.ErrorMessage(rc));
			}
			
		}
        
        public void MotorOff()
        {
			DeclareDevice();
			// Executes servo OFF-- By best effort
			rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
			if (rc != CMotionAPI.MP_SUCCESS)
				throw new AvvaMotionException("ymcClearAlarm error-" + MyErrorCode.ErrorMessage(rc));
			ClearDevice();
			CloseController();
		}
		public void MotorOn()
        {
            //YASKAWA servor setting
            #region ymcOpenController
            //Sets the ymcOpenController parameters                             

            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCIe_MODE;
            ComDevice.PortNumber = 1;
            ComDevice.CpuNumber = 1;    //cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber = 0;
            ComDevice.IPAddress ="";
            ComDevice.Timeout = 10000;


			OpenController();
			#endregion
			#region Sets the motion API timeout                               
			// Sets the motion API timeout.			
			rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcSetAPITimeoutValue error-" + MyErrorCode.ErrorMessage(rc));
			}
			#endregion
			#region Clear and reCreates the axis handle      
			// Deletes the axis handle that is held by the Machine Controller.
			rc = CMotionAPI.ymcClearAllAxes();
            //rc = CMotionAPI.ymcClearAxis(hAxis[0]);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcClearAllAxes error-" + MyErrorCode.ErrorMessage(rc));
			}
			for (int i = 0; i < _axis_num; i++)
            {
                string AxisName ="Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
					throw new AvvaMotionException("ymcDeclareAxis error-" + MyErrorCode.ErrorMessage(rc));
				}
			}
			#endregion
			#region Gets the device handle
			DeclareDevice();
			#endregion
			#region Executes servo ON
			//打開由設備手柄指定軸的伺服
			rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
				throw new AvvaMotionException("ymcServoControl error-" + MyErrorCode.ErrorMessage(rc));
			}
			#endregion
		}
        #region Basic Function
        #region ClearDevice
		public void ClearDevice()
        {
			//Deletes the device handle created in this thread. 
			rc = CMotionAPI.ymcClearDevice(g_hDevice);
			if (rc != CMotionAPI.MP_SUCCESS)
				throw new AvvaMotionException("ymcClearDevice error-" + MyErrorCode.ErrorMessage(rc));
		}
        #endregion
        #region DeclareDevice
        public void DeclareDevice()
        {
			rc = CMotionAPI.ymcDeclareDevice((UInt16)_axis_num, hAxis, ref g_hDevice);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				throw new AvvaMotionException("ymcDeclareDevice error-" + MyErrorCode.ErrorMessage(rc));
			}
		}
		#endregion
		#region OpenController
		public void OpenController()
        {
			//在執行任何其他API之前，必須執行此API
			rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				throw new AvvaMotionException("ymcOpenController error-" + MyErrorCode.ErrorMessage(rc));
			}
		}
        #endregion
        #region CloseController
		public void CloseController()
        {
			//Close the Controller.
			rc = CMotionAPI.ymcCloseController(g_hController);
			if (rc != CMotionAPI.MP_SUCCESS)
				throw new AvvaMotionException("ymcCloseController error-" + MyErrorCode.ErrorMessage(rc));
		}
		#endregion
		#region ClearAlarm()
		public void ClearAlarm()
		{
			rc = CMotionAPI.ymcClearAlarm(0);
			if (rc != CMotionAPI.MP_SUCCESS)
			{
				throw new AvvaMotionException("ymcClearAlarm error-" + MyErrorCode.ErrorMessage(rc));
			}
		}
        #endregion
        #endregion
        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			try
			{
				if (!this.IsDisposed)
				{
					if (isDisposing) { }
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				this.IsDisposed = true;
			}
		}
		private class MyErrorCode
        {
			static public string ErrorMessage(uint rc)
            {
				switch (rc)
                {
					case CMotionAPI.MP_SUCCESS:
						return"MP_SUCCESS";
					case CMotionAPI.MP_FAIL:
						return"MP_FAIL";
					case CMotionAPI.WDT_OVER_ERR:
						return"WDT_OVER_ERR";
					case CMotionAPI.MANUAL_RESET_ERR:
						return"MANUAL_RESET_ERR";
					case CMotionAPI.TLB_MLTHIT_ERR:
						return"TLB_MLTHIT_ERR";
					case CMotionAPI.UBRK_ERR:
						return"UBRK_ERR";
					case CMotionAPI.ADR_RD_ERR:
						return"ADR_RD_ERR";
					case CMotionAPI.TLB_MIS_RD_ERR:
						return"TLB_MIS_RD_ERR";
					case CMotionAPI.TLB_PROTECTION_RD_ERR:
						return"TLB_PROTECTION_RD_ERR";
					case CMotionAPI.GENERAL_INVALID_INS_ERR:
						return"GENERAL_INVALID_INS_ERR";
					case CMotionAPI.SLOT_ERR:
						return"SLOT_ERR";
					case CMotionAPI.GENERAL_FPU_DISABLE_ERR:
						return"GENERAL_FPU_DISABLE_ERR";
					case CMotionAPI.SLOT_FPU_ERR:
						return"Slot FPU exception error";
					case CMotionAPI.ADR_WR_ERR:
						return"Data address write error";
					case CMotionAPI.TLB_MIS_WR_ERR:
						return"TLB write mis error";
					case CMotionAPI.TLB_PROTECTION_WR_ERR:
						return"TLB protection write vaiolation error";
					case CMotionAPI.FPU_EXP_ERR:
						return"FPU exception error";
					case CMotionAPI.INITIAL_PAGE_EXP_ERR:
						return"Initial page write exception error";
					case CMotionAPI.ROM_ERR:
						return"ROM  error";
					case CMotionAPI.RAM_ERR:
						return"RAM  error";
					case CMotionAPI.MPU_ERR:
						return"CPU  error";
					case CMotionAPI.FPU_ERR:
						return"FPU  error";
					case CMotionAPI.CERF_ERR:
						return"CERF  error";
					case CMotionAPI.EXIO_ERR:
						return"EXIO  error";
					case CMotionAPI.BUSIF_ERR:
						return"Common RAM error for OEM";
					case CMotionAPI.ALM_MK_OS_ERR_MBOX1:
						return"Major failure: Mail box creation error (mail box for request for Motion Kernel Move object execution)";
					case CMotionAPI.ALM_MK_OS_ERR_MBOX2:
						return"Major failure: Mail box creation error (mail box for request for Motion Kernel action execution)";
					case CMotionAPI.ALM_MK_OS_ERR_SEND_MSG1:
						return"Major failure: Message sending error at OS level (MK to EM: Notification of event detection)";
					case CMotionAPI.ALM_MK_OS_ERR_SEND_MSG2:
						return"Major failure: Message sending error at OS level (MK to MM: Move completion message)";
					case CMotionAPI.ALM_MK_OS_ERR_SEND_MSG3:
						return"Major failure: Message sending error at OS level (EM to MM: Notification of Action)";
					case CMotionAPI.ALM_MK_OS_ERR_SEND_MSG4:
						return"Major failure: Message sending error at OS level (Others)";
					case CMotionAPI.ALM_MM_OS_ERR_MBOX1:
						return"Major failure: Mail box creation error (mail box to start up Motion Manager)";
					case CMotionAPI.ALM_MM_OS_ERR_SEND_MSG1:
						return"Major failure: Message sending error at OS level (Motion Manager to Motion Kernel)";
					case CMotionAPI.ALM_MM_OS_ERR_SEND_MSG2:
						return"Major failure: Message sending error at OS level (Motion Manager to Event Manager)";
					case CMotionAPI.ALM_MM_OS_ERR_RCV_MSG1:
						return"Major failure: Message receiving error at OS level";
					case CMotionAPI.ALM_IM_DEVICEID_ERR:
						return"DeviceID error or non-supported Device";
					case CMotionAPI.ALM_IM_REGHANDLE_ERR:
						return"Register handle error";
					case CMotionAPI.ALM_IM_GLOBALHANDLE_ERR:
						return"Global data handle error";
					case CMotionAPI.ALM_IM_DEVICETYPE_ERR:
						return"Non-supported data type";
					case CMotionAPI.ALM_IM_OFFSET_ERR:
						return"Incorrect offset value";
					case CMotionAPI.AM_ER_UNDEF_COMMAND:
						return"Illegal command code";
					case CMotionAPI.AM_ER_UNDEF_CMNDTYPE:
						return"Illegal command type";
					case CMotionAPI.AM_ER_UNDEF_OBJTYPE:
						return"Illegal object type";
					case CMotionAPI.AM_ER_UNDEF_HANDLETYPE:
						return"Illegal handle type";
					case CMotionAPI.AM_ER_UNDEF_PKTDAT:
						return"Illegal packet data";
					case CMotionAPI.AM_ER_UNDEF_AXIS:
						return"axis not defined";
					case CMotionAPI.AM_ER_MSGBUF_GET_FAULT:
						return"Acquisition failure of  message buffer managed table";
					case CMotionAPI.AM_ER_ACTSIZE_GET_FAULT:
						return"Acquisition failure of ACT size";
					case CMotionAPI.AM_ER_APIBUF_GET_FAULT:
						return"Acquisition failure of API buffer managed table";
					case CMotionAPI.AM_ER_MOVEOBJ_GET_FAULT:
						return"Acquisition failure of MOVE object managed table";
					case CMotionAPI.AM_ER_EVTTBL_GET_FAULT:
						return"Acquisition failure of event managed table";
					case CMotionAPI.AM_ER_ACTTBL_GET_FAULT:
						return"Acquisition failure of Action managed table";
					case CMotionAPI.AM_ER_1BY1APIBUF_GET_FAULT:
						return"Acquisition failure of Sequence managed table";
					case CMotionAPI.AM_ER_AXSTBL_GET_FAULT:
						return"Acquisition failure of AXIS handle managed table";
					case CMotionAPI.AM_ER_SUPERPOSEOBJ_GET_FAULT:
						return"Acquisition failure of Distribution synthetic object managed table";
					case CMotionAPI.AM_ER_SUPERPOSEOBJ_CLEAR_FAULT:
						return"Deletion failure of Distribution synthetic object";
					case CMotionAPI.AM_ER_AXIS_IN_USE:
						return"axis in use";
					case CMotionAPI.AM_ER_HASHTBL_GET_FAULT:
						return"Hash table acquisition failure for axial name management";
					case CMotionAPI.AM_ER_UNMATCH_OBJHNDL:
						return"MOVE object handle mismatched";
					case CMotionAPI.AM_ER_UNMATCH_OBJECT:
						return"Object mismatched";
					case CMotionAPI.AM_ER_UNMATCH_APIBUF:
						return"API buffer mismatched";
					case CMotionAPI.AM_ER_UNMATCH_MSGBUF:
						return"Message buffer mismatched";
					case CMotionAPI.AM_ER_UNMATCH_ACTBUF:
						return"Action execution management buffer mismatched";
					case CMotionAPI.AM_ER_UNMATH_SEQUENCE:
						return"Sequence number mismatched";
					case CMotionAPI.AM_ER_UNMATCH_1BY1APIBUF:
						return"Sequential API management table mismatched";
					case CMotionAPI.AM_ER_UNMATCH_MOVEOBJTABLE:
						return"MOVE object management table mismatched";
					case CMotionAPI.AM_ER_UNMATCH_MOVELISTTABLE:
						return"MOVE LIST management table mismatched";
					case CMotionAPI.AM_ER_UNMATCH_MOVELIST_OBJECT:
						return"MOVE LIST object mismatched";
					case CMotionAPI.AM_ER_UNMATCH_MOVELIST_OBJHNDL:
						return"MOVE LIST object handle mismatched";
					case CMotionAPI.AM_ER_UNGET_MOVEOBJTABLE:
						return"MOVE object management table not assured";
					case CMotionAPI.AM_ER_UNGET_MOVELISTTABLE:
						return"MOVE LIST object management table not assured";
					case CMotionAPI.AM_ER_UNGET_1BY1APIBUFTABLE:
						return"Sequential API management table not assured";
					case CMotionAPI.AM_ER_NOEMPTYTBL_ERROR:
						return"No unused table among interpolation tables";
					case CMotionAPI.AM_ER_NOTGETSEM_ERROR:
						return"Failure to get AM-MK semaphore  (Dynamic)";
					case CMotionAPI.AM_ER_NOTGETTBLADD_ERROR:
						return"Failure to get interpolation table address";
					case CMotionAPI.AM_ER_NOTWRTTBL_ERROR:
						return"Failure to write in table at execution (Static)";
					case CMotionAPI.AM_ER_TBLINDEX_ERROR:
						return"Index setting error (Static)";
					case CMotionAPI.AM_ER_ILLTBLTYPE_ERROR:
						return"Invalid table type specified";
					case CMotionAPI.AM_ER_UNSUPORTED_EVENT:
						return"Event not supported or argument error";
					case CMotionAPI.AM_ER_WRONG_SEQUENCE:
						return"Sequence error";
					case CMotionAPI.AM_ER_MOVEOBJ_BUSY:
						return"MOVE object under execution";
					case CMotionAPI.AM_ER_MOVELIST_BUSY:
						return"MOVE LIST under execution";
					case CMotionAPI.AM_ER_MOVELIST_ADD_FAULT:
						return"MOVE OBJ cannot be registered.";
					case CMotionAPI.AM_ER_CONFLICT_PHI_AXS:
						return"Physical axes overlapped";
					case CMotionAPI.AM_ER_CONFLICT_LOG_AXS:
						return"Logic axes overlapped";
					case CMotionAPI.AM_ER_PKTSTS_ERROR:
						return"Receiving packet status error";
					case CMotionAPI.AM_ER_CONFLICT_NAME:
						return"Axis name overlapped";
					case CMotionAPI.AM_ER_ILLEGAL_NAME:
						return"Incorrect axis name";
					case CMotionAPI.AM_ER_SEMAPHORE_ERROR:
						return"Incorrect semaphore at host PC interruption";
					case CMotionAPI.AM_ER_LOG_AXS_OVER:
						return"Logical axis number exceeded";
					case CMotionAPI.MP_FILE_ERR_GENERAL:
						return"General error.";
					case CMotionAPI.MP_FILE_ERR_NOT_SUPPORTED:
						return"Feature not supported.";
					case CMotionAPI.MP_FILE_ERR_INVALID_ARGUMENT:
						return"Invalid argument";
					case CMotionAPI.MP_FILE_ERR_INVALID_HANDLE:
						return"Invalid handle";
					case CMotionAPI.MP_FILE_ERR_NO_FILE:
						return"No such file (or directory).";
					case CMotionAPI.MP_FILE_ERR_INVALID_PATH:
						return"Invalid path.";
					case CMotionAPI.MP_FILE_ERR_EOF:
						return"End of file detected.";
					case CMotionAPI.MP_FILE_ERR_PERMISSION_DENIED:
						return"Not arrowed to access the file.";
					case CMotionAPI.MP_FILE_ERR_TOO_MANY_FILES:
						return"Too many files opened.";
					case CMotionAPI.MP_FILE_ERR_FILE_BUSY:
						return"File is in use.";
					case CMotionAPI.MP_FILE_ERR_TIMEOUT:
						return"Timeout occured.";
					case CMotionAPI.MP_FILE_ERR_BAD_FS:
						return"Invalid or unexepected logical filesystem in the medium";
					case CMotionAPI.MP_FILE_ERR_INVALID_LFM:
						return"Invalid LFM specified.";
					case CMotionAPI.MP_FILE_ERR_TOO_MANY_LFM:
						return"LFM table is full.";
					case CMotionAPI.MP_FILE_ERR_INVALID_PDM:
						return"Invalid PDM specified.";
					case CMotionAPI.MP_FILE_ERR_INVALID_MEDIA:
						return"Invalid media specified.";
					case CMotionAPI.MP_FILE_ERR_TOO_MANY_PDM:
						return"Too many PDM.";
					case CMotionAPI.MP_FILE_ERR_TOO_MANY_MEDIA:
						return"Too many media.";
					case CMotionAPI.MP_FILE_ERR_WRITE_PROTECTED:
						return"Write protected media.";
					case CMotionAPI.MP_FILE_ERR_INVALID_DEVICE:
						return"Invalid device specified.";
					case CMotionAPI.MP_FILE_ERR_DEVICE_IO:
						return"Error occured in accessing the device.";
					case CMotionAPI.MP_FILE_ERR_DEVICE_BUSY:
						return"Device is in use.";
					case CMotionAPI.MP_FILE_ERR_NO_CARD:
						return"CF CARD not mounted.";
					case CMotionAPI.MP_FILE_ERR_CARD_POWER:
						return"CF CARD Power-OFF.";
					case CMotionAPI.MP_CARD_SYSTEM_ERR:
						return"Card System Error.";
					case CMotionAPI.ERROR_CODE_GET_DIREC_OFFSET:
						return"Directory area offset cannot be got.";
					case CMotionAPI.ERROR_CODE_GET_DIREC_INFO:
						return"Directory area offset cannot be got.";
					case CMotionAPI.ERROR_CODE_FUNC_TABLE:
						return"Failure to get directory information";
					case CMotionAPI.ERROR_CODE_SLEEP_TASK:
						return"Failure to get system call function table";
					case CMotionAPI.ERROR_CODE_DEVICE_HANDLE_FULL:
						return"Sleep error";
					case CMotionAPI.ERROR_CODE_ALLOC_MEMORY:
						return"Number of device handles exceeds the maximum value.";
					case CMotionAPI.ERROR_CODE_BUFCOPY:
						return"Failure to get the area.";
					case CMotionAPI.ERROR_CODE_GET_COMMEM_OFFSET:
						return"MemoryCopy(),name_copy() error";
					case CMotionAPI.ERROR_CODE_CREATE_SEMPH:
						return"Failure to get common memory offset value";
					case CMotionAPI.ERROR_CODE_DELETE_SEMPH:
						return"Semaphore creation error";
					case CMotionAPI.ERROR_CODE_LOCK_SEMPH:
						return"Semaphore deletion error";
					case CMotionAPI.ERROR_CODE_UNLOCK_SEMPH:
						return"Error at semaphore lock";
					case CMotionAPI.ERROR_CODE_PACKETSIZE_OVER:
						return"Error at semaphore release";
					case CMotionAPI.ERROR_CODE_UNREADY:
						return"Error when controller is being initialized";
					case CMotionAPI.ERROR_CODE_CPUSTOP:
						return"Error when CPU is stopping";
					case CMotionAPI.ERROR_CODE_CNTRNO:
						return"CPU number is illegal";
					case CMotionAPI.ERROR_CODE_SELECTION:
						return"Device number";
					case CMotionAPI.ERROR_CODE_LENGTH:
						return"Illegal selected value (0 or 1)";
					case CMotionAPI.ERROR_CODE_OFFSET:
						return"Data length";
					case CMotionAPI.ERROR_CODE_DATACOUNT:
						return"Offset value";
					case CMotionAPI.ERROR_CODE_DATREAD:
						return"Number of data items";
					case CMotionAPI.ERROR_CODE_DATWRITE:
						return"Failure to read out from common memory";
					case CMotionAPI.ERROR_CODE_BITWRITE:
						return"Failure to write in to common memory";
					case CMotionAPI.ERROR_CODE_DEVCNTR:
						return"Failure to write in bit data to common memory";
					case CMotionAPI.ERROR_CODE_NOTINIT:
						return"DeviceIoControl() completed erroneously.";
					case CMotionAPI.ERROR_CODE_SEMPHLOCK:
						return"Driver initialization error";
					case CMotionAPI.ERROR_CODE_SEMPHUNLOCK:
						return"Packet sending semaphore locked";
					case CMotionAPI.ERROR_CODE_DRV_PROC:
						return"Packet receiving semaphore not locked";
					case CMotionAPI.ERROR_CODE_GET_DRIVER_HANDLE:
						return"Driver processing completed erroneously.";
					case CMotionAPI.ERROR_CODE_SEND_MSG:
						return"Failure to get driver file handle";
					case CMotionAPI.ERROR_CODE_RECV_MSG:
						return"Message sending error";
					case CMotionAPI.ERROR_CODE_INVALID_RESPONSE:
						return"Message receiving error";
					case CMotionAPI.ERROR_CODE_INVALID_ID:
						return"Receiving packet illegal";
					case CMotionAPI.ERROR_CODE_INVALID_STATUS:
						return"Receiving packet ID illegal";
					case CMotionAPI.ERROR_CODE_INVALID_CMDCODE:
						return"Receiving packet status illegal";
					case CMotionAPI.ERROR_CODE_INVALID_SEQNO:
						return"Receiving packet command code illegal";
					case CMotionAPI.ERROR_CODE_SEND_RETRY_OVER:
						return"Receiving packet sequence number illegal";
					case CMotionAPI.ERROR_CODE_RECV_RETRY_OVER:
						return"Number of retries exceeded (packet sending)";
					case CMotionAPI.ERROR_CODE_RESPONSE_TIMEOUT:
						return"Number of retries exceeded (packet receiving)";
					case CMotionAPI.ERROR_CODE_WAIT_FOR_EVENT:
						return"Response waiting timeout error";
					case CMotionAPI.ERROR_CODE_EVENT_OPEN:
						return"Event waiting error";
					case CMotionAPI.ERROR_CODE_EVENT_RESET:
						return"Failure to open event";
					case CMotionAPI.ERROR_CODE_EVENT_READY:
						return"Failure to reset event";
					case CMotionAPI.ERROR_CODE_PROCESSNUM:
						return"Failure to prepare for waiting for event";
					case CMotionAPI.ERROR_CODE_GET_PROC_INFO:
						return"Number of processes exceeded";
					case CMotionAPI.ERROR_CODE_THREADNUM:
						return"Process information getting error";
					case CMotionAPI.ERROR_CODE_GET_THRD_INFO:
						return"Number of threads exceeded";
					case CMotionAPI.ERROR_CODE_CREATE_MBOX:
						return"Thread information getting error";
					case CMotionAPI.ERROR_CODE_DELETE_MBOX:
						return"Mail box creation error";
					case CMotionAPI.ERROR_CODE_GET_TASKID:
						return"Mail box deletion error";
					case CMotionAPI.ERROR_CODE_NO_THREADINFO:
						return"Failure to get task ID";
					case CMotionAPI.ERROR_CODE_COMDEVICENUM:
						return"COM initialization error";
					case CMotionAPI.ERROR_CODE_GET_COM_DEVICE_HANDLE:
						return"Number of ComDevice exceeded";
					case CMotionAPI.ERROR_CODE_COM_DEVICE_FULL:
						return"Failure to get ComDevice information structure";
					case CMotionAPI.ERROR_CODE_CREATE_PANELOBJ:
						return"ComDevice exceeds the maximum number.";
					case CMotionAPI.ERROR_CODE_OPEN_PANELOBJ:
						return"Failure to create panel command object";
					case CMotionAPI.ERROR_CODE_CLOSE_PANELOBJ:
						return"Failure to open panel command object";
					case CMotionAPI.ERROR_CODE_PROC_PANELOBJ:
						return"Failure to close panel command object";
					case CMotionAPI.ERROR_CODE_CREATE_CNTROBJ:
						return"Failure to process panel command object";
					case CMotionAPI.ERROR_CODE_OPEN_CNTROBJ:
						return"Failure to create panel command object";
					case CMotionAPI.ERROR_CODE_CLOSE_CNTROBJ:
						return"Failure to open panel command object";
					case CMotionAPI.ERROR_CODE_PROC_CNTROBJ:
						return"Failure to close panel command object";
					case CMotionAPI.ERROR_CODE_CREATE_COMDEV_MUTEX:
						return"Failure to process panel command object";
					case CMotionAPI.ERROR_CODE_CREATE_COMDEV_MAPFILE:
						return"Failure to create Mutex for ComDevice table";
					case CMotionAPI.ERROR_CODE_OPEN_COMDEV_MAPFILE:
						return"Failure to create MapFile for ComDevice table";
					case CMotionAPI.ERROR_CODE_NOT_OBJECT_TYPE:
						return"Failure to open MapFile for ComDevice table";
					case CMotionAPI.ERROR_CODE_COM_NOT_OPENED:
						return"Object type error";
					case CMotionAPI.ERROR_CODE_PNLCMD_CPU_CONTROL:
						return"Not opened";
					case CMotionAPI.ERROR_CODE_PNLCMD_SFILE_READ:
						return"CPU control error";
					case CMotionAPI.ERROR_CODE_PNLCMD_SFILE_WRITE:
						return"Failure to read out source file";
					case CMotionAPI.ERROR_CODE_PNLCMD_REGISTER_READ:
						return"Failure to write in source file";
					case CMotionAPI.ERROR_CODE_PNLCMD_REGISTER_WRITE:
						return"Failure to read out register";
					case CMotionAPI.ERROR_CODE_PNLCMD_API_SEND:
						return"Failure to write in register";
					case CMotionAPI.ERROR_CODE_PNLCMD_API_RECV:
						return"API Send command error";
					case CMotionAPI.ERROR_CODE_PNLCMD_NO_RESPONSE:
						return"API Recv command error";
					case CMotionAPI.ERROR_CODE_PNLCMD_PACKET_READ:
						return"No response packet is received at API Recv.";
					case CMotionAPI.ERROR_CODE_PNLCMD_PACKET_WRITE:
						return"Failure to read packet";
					case CMotionAPI.ERROR_CODE_PNLCMD_STATUS_READ:
						return"Failure to write packet";
					case CMotionAPI.ERROR_CODE_NOT_CONTROLLER_RDY:
						return"ERROR_CODE_NOT_CONTROLLER_RDY";
					case CMotionAPI.ERROR_CODE_DOUBLE_CMD:
						return"ERROR_CODE_DOUBLE_CMD";
					case CMotionAPI.ERROR_CODE_DOUBLE_RCMD:
						return"ERROR_CODE_DOUBLE_RCMD";
					case CMotionAPI.ERROR_CODE_FILE_NOT_OPENED:
						return"Failure to read status";
					case CMotionAPI.ERROR_CODE_OPENFILE_NUM:
						return"File is not opened.";
					case CMotionAPI.MP_CTRL_SYS_ERROR:
						return"";
					case CMotionAPI.MP_CTRL_PARAM_ERR:
						return"";
					case CMotionAPI.MP_CTRL_FILE_NOT_FOUND:
						return"";
					case CMotionAPI.MP_NOTMOVEHANDLE:
						return"Undefined Move handle";
					case CMotionAPI.MP_NOTTIMERHANDLE:
						return"Undefined timer handle";
					case CMotionAPI.MP_NOTINTERRUPT:
						return"Undefined virtual interruption number";
					case CMotionAPI.MP_NOTEVENTHANDLE:
						return"Undefined event handle";
					case CMotionAPI.MP_NOTMESSAGEHANDLE:
						return"Undefined message handle";
					case CMotionAPI.MP_NOTUSERFUNCTIONHANDLE:
						return"Undefined user function handle";
					case CMotionAPI.MP_NOTACTIONHANDLE:
						return"Undefined action handle";
					case CMotionAPI.MP_NOTSUBSCRIBEHANDLE:
						return"Undefined Subscribe handle";
					case CMotionAPI.MP_NOTDEVICEHANDLE:
						return"Undefined device handle";
					case CMotionAPI.MP_NOTAXISHANDLE:
						return"Undefined axis handle";
					case CMotionAPI.MP_NOTMOVELISTHANDLE:
						return"Undefined MoveList handle";
					case CMotionAPI.MP_NOTTRACEHANDLE:
						return"Undefined Trace handle";
					case CMotionAPI.MP_NOTGLOBALDATAHANDLE:
						return"Undefined global data handle";
					case CMotionAPI.MP_NOTSUPERPOSEHANDLE:
						return"Undefined Superpose handle";
					case CMotionAPI.MP_NOTCONTROLLERHANDLE:
						return"Undefined Controller handle";
					case CMotionAPI.MP_NOTFILEHANDLE:
						return"Undefined file handle";
					case CMotionAPI.MP_NOTREGISTERDATAHANDLE:
						return"Undefined register handle";
					case CMotionAPI.MP_NOTALARMHANDLE:
						return"Undefined alarm handle";
					case CMotionAPI.MP_NOTCAMHANDLE:
						return"Undefined CAM handle";
					case CMotionAPI.MP_NOTHANDLE:
						return"Undefined handle";
					case CMotionAPI.MP_NOTEVENTTYPE:
						return"Undefined event type";
					case CMotionAPI.MP_NOTDEVICETYPE:
						return"Undefined device type";
					case CMotionAPI.MP_NOTDATAUNITSIZE:
						return"Undefined unit data size";
					case CMotionAPI.MP_NOTDEVICE:
						return"Undefined device";
					case CMotionAPI.MP_NOTACTIONTYPE:
						return"Undefined action type";
					case CMotionAPI.MP_NOTPARAMNAME:
						return"Undefined parameter name";
					case CMotionAPI.MP_NOTDATATYPE:
						return"Undefined data type";
					case CMotionAPI.MP_NOTBUFFERTYPE:
						return"Undefined buffer type";
					case CMotionAPI.MP_NOTMOVETYPE:
						return"Undefined Move type";
					case CMotionAPI.MP_NOTANGLETYPE:
						return"Undefined Angle type";
					case CMotionAPI.MP_NOTDIRECTION:
						return"Undefined rotating direction";
					case CMotionAPI.MP_NOTAXISTYPE:
						return"Undefined axis type";
					case CMotionAPI.MP_NOTUNITTYPE:
						return"Undefined unit type";
					case CMotionAPI.MP_NOTCOMDEVICETYPE:
						return"Undefined ComDevice type";
					case CMotionAPI.MP_NOTCONTROLTYPE:
						return"Undefined Control type";
					case CMotionAPI.MP_NOTFILETYPE:
						return"Undefined file type";
					case CMotionAPI.MP_NOTSEMAPHORETYPE:
						return"Undefined semaphore type";
					case CMotionAPI.MP_NOTSYSTEMOPTION:
						return"Undefined system option";
					case CMotionAPI.MP_TIMEOUT_ERR:
						return"Timeout error";
					case CMotionAPI.MP_TIMEOUT:
						return"Timeout";
					case CMotionAPI.MP_NOTSUBSCRIBETYPE:
						return"Undefined scan type";
					case CMotionAPI.MP_NOTSCANTYPE:
						return"Undefined scan type";
					case CMotionAPI.MP_DEVICEOFFSETOVER:
						return"Out-of-range device offset";
					case CMotionAPI.MP_DEVICEBITOFFSETOVER:
						return"Out-of-range bit offset";
					case CMotionAPI.MP_UNITCOUNTOVER:
						return"Out-of-range quantity";
					case CMotionAPI.MP_COMPAREVALUEOVER:
						return"Out-of-range compared value";
					case CMotionAPI.MP_FCOMPAREVALUEOVER:
						return"Out-of-range floating-point compared value";
					case CMotionAPI.MP_EVENTCOUNTOVER:
						return"Out-of-range virtual interruption number";
					case CMotionAPI.MP_VALUEOVER:
						return"Out-of-range value";
					case CMotionAPI.MP_FVALUEOVER:
						return"Out-of-range floating point";
					case CMotionAPI.MP_PSTOREDVALUEOVER:
						return"Out-of-range storage position pointer";
					case CMotionAPI.MP_PSTOREDFVALUEOVER:
						return"Out-of-range storage position pointer (floating decimal point value)";
					case CMotionAPI.MP_SIZEOVER:
						return"Out-of-range size";
					case CMotionAPI.MP_RECEIVETIMEROVER:
						return"Out-of-range waiting time value for receiving";
					case CMotionAPI.MP_RECNUMOVER:
						return"Out-of-range number of records (MoveList)";
					case CMotionAPI.MP_PARAMOVER:
						return"Out-of-range parameter";
					case CMotionAPI.MP_FRAMEOVER:
						return"Out-of-range number of frames";
					case CMotionAPI.MP_RADIUSOVER:
						return"Out-of-range radius";
					case CMotionAPI.MP_CONTROLLERNOOVER:
						return"Out-of-range device number";
					case CMotionAPI.MP_AXISNUMOVER:
						return"Out-of-range number of axes";
					case CMotionAPI.MP_DIGITOVER:
						return"Out-of-range number of digits";
					case CMotionAPI.MP_CALENDARVALUEOVER:
						return"Out-of-range calendar data";
					case CMotionAPI.MP_OFFSETOVER:
						return"Out-of-range offset";
					case CMotionAPI.MP_NUMBEROVER:
						return"Out-of-range number of registers has been specified.";
					case CMotionAPI.MP_RACKOVER:
						return"Out-of-range rack number has been specified.";
					case CMotionAPI.MP_SLOTOVER:
						return"Out-of-range slot number has been specified.";
					case CMotionAPI.MP_FIXVALUEOVER:
						return"Fixed decimal point type data has been out of range.";
					case CMotionAPI.MP_REGISTERINFOROVER:
						return"Out-of-range number of register infomation has been specified.";
					case CMotionAPI.PC_MEMORY_ERR:
						return"PC memory shortage";
					case CMotionAPI.MP_NOCOMMUDEVICETYPE:
						return"Communication device type specification error";
					case CMotionAPI.MP_NOTPROTOCOLTYPE:
						return"Invalid protocol type";
					case CMotionAPI.MP_NOTFUNCMODE:
						return"Invalid function mode";
					case CMotionAPI.MP_MYADDROVER:
						return"Out-of-range local station address has been set.";
					case CMotionAPI.MP_NOTPORTTYPE:
						return"Invalid port type";
					case CMotionAPI.MP_NOTPROTMODE:
						return"Invalid protocol mode";
					case CMotionAPI.MP_NOTCHARSIZE:
						return"Invalid character bit length";
					case CMotionAPI.MP_NOTPARITYBIT:
						return"Invalid parity bit";
					case CMotionAPI.MP_NOTSTOPBIT:
						return"Invalid stop bit";
					case CMotionAPI.MP_NOTBAUDRAT:
						return"Invalid transmission speed";
					case CMotionAPI.MP_TRANSDELAYOVER:
						return"Out-of-range sending delay has been specified.";
					case CMotionAPI.MP_PEERADDROVER:
						return"Out-of-range remote station address has been specified.";
					case CMotionAPI.MP_SUBNETMASKOVER:
						return"Out-of-range subnet mask has been specified.";
					case CMotionAPI.MP_GWADDROVER:
						return"Out-of-range GW address has been specified.";
					case CMotionAPI.MP_DIAGPORTOVER:
						return"Out-of-range diagnostic port has been specified.";
					case CMotionAPI.MP_PROCRETRYOVER:
						return"Out-of-range number of retries has been specified.";
					case CMotionAPI.MP_TCPZEROWINOVER:
						return"Out-of-range TCP zero window timer";
					case CMotionAPI.MP_TCPRETRYOVER:
						return"Out-of-range TCP resending timer value";
					case CMotionAPI.MP_TCPFINOVER:
						return"Out-of-range completion timer value";
					case CMotionAPI.MP_IPASSEMBLEOVER:
						return"Out-of-range IP incorporating timer value";
					case CMotionAPI.MP_MAXPKTLENOVER:
						return"Out-of-range maximum packet length";
					case CMotionAPI.MP_PEERPORTOVER:
						return"Out-of-range remote station port";
					case CMotionAPI.MP_MYPORTOVER:
						return"Out-of-range local station port";
					case CMotionAPI.MP_NOTTRANSPROT:
						return"Invalid transport layer protocol";
					case CMotionAPI.MP_NOTAPPROT:
						return"Invalid application layer protocol";
					case CMotionAPI.MP_NOTCODETYPE:
						return"Invalid code type";
					case CMotionAPI.MP_CYCTIMOVER:
						return"Out-of-range communication cycle has been specified.";
					case CMotionAPI.MP_NOTIOMAPCOM:
						return"Invalid I/O commands";
					case CMotionAPI.MP_NOTIOTYPE:
						return"Invalid I/O type specification";
					case CMotionAPI.MP_IOOFFSETOVER:
						return"Out-of-range I/O offset has been allocated.";
					case CMotionAPI.MP_IOSIZEOVER:
						return"Out-of-range I/O size has been allocated (individualy).";
					case CMotionAPI.MP_TIOSIZEOVER:
						return"Out-of-range I/O size has been allocated (total).";
					case CMotionAPI.MP_MEMORY_ERR:
						return"Controller memory shortage";
					case CMotionAPI.MP_NOTPTR:
						return"Invalid pointer (communication device specification structure/device inherent information/pointer error to objective communication device handle)";
					case CMotionAPI.MP_TABLEOVER:
						return"Event detection table resource cannot be got.";
					case CMotionAPI.MP_ALARM:
						return"Alarm has occurred.";
					case CMotionAPI.MP_MEMORYOVER:
						return"Memory resource cannot be got.";
					case CMotionAPI.MP_EXEC_ERR:
						return"System execution error";
					case CMotionAPI.MP_NOTLOGICALAXIS:
						return"Logical axis number error";
					case CMotionAPI.MP_NOTSUPPORTED:
						return"Not supported";
					case CMotionAPI.MP_ILLTEXT:
						return"Out-of-range length of character string was input.";
					case CMotionAPI.MP_NOFILENAME:
						return"File name has not been set.";
					case CMotionAPI.MP_NOTREGSTERNAME:
						return"Specified register data name cannot be found.";
					case CMotionAPI.MP_FILEALREADYOPEN:
						return"The same file has already been opened.";
					case CMotionAPI.MP_NOFILEPACKET:
						return"Specified source file packet cannot be found.";
					case CMotionAPI.MP_NOTFILEPACKETSIZE:
						return"Source file packet size is incorrect.";
					case CMotionAPI.MP_NOTUSERFUNCTION:
						return"Specified user funtion does not exist.";
					case CMotionAPI.MP_NOTPARAMETERTYPE:
						return"Specified parameter type does not exist.";
					case CMotionAPI.MP_ILLREGHANDLETYPE:
						return"Erroneous register handle type specified.";
					case CMotionAPI.MP_ILLREGTYPE:
						return"Erroneous register type specified.";
					case CMotionAPI.MP_ILLREGSIZE:
						return"Erroneous register size specified.(other than WORD)";
					case CMotionAPI.MP_REGNUMOVER:
						return"Out-of-range register";
					case CMotionAPI.MP_RELEASEWAIT:
						return"Waiting status released";
					case CMotionAPI.MP_PRIORITYOVER:
						return"Priority that can not be set";
					case CMotionAPI.MP_NOTCHANGEPRIORITY:
						return"Priority that cannot be changed";
					case CMotionAPI.MP_SEMAPHOREOVER:
						return"Semaphore definition over";
					case CMotionAPI.MP_NOTSEMAPHOREHANDLE:
						return"Undefined semaphore handle specification";
					case CMotionAPI.MP_SEMAPHORELOCKED:
						return"Specified semaphore handle being locked";
					case CMotionAPI.MP_CONTINUE_RELEASEWAIT:
						return"Waiting status released during ymcContinueWaitForCompletion";
					case CMotionAPI.MP_NOTTABLENAME:
						return"Undefined Table name";
					case CMotionAPI.MP_ILLTABLETYPE:
						return"Illegal Table Type";
					case CMotionAPI.MP_TIMEOUTVALUEOVER:
						return"Out-of-range timeout value has been specified";
					case CMotionAPI.MP_OTHER_ERR:
						return"Other errors";
					default:
						return string.Format("ErrorCode[0x{ 0} ]", rc.ToString("X"));
				}
            }

		}
	}
}
