using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Avva.MotionFramework
{
    public class AvvaMotion
    {
        public enum EAvvaMotionState { On, Off, Move, AsyncMove, StopMove, JogStart, JogStop, ClearAlarm, GoHome };
        private enum EAvvaMotionType { Async, Sync };

        private IAvvaMotion _motion;
        private static log4net.ILog _log;
        private MotionParamReader _paraReader;
        private Dictionary<char, int> axis_map = new Dictionary<char, int>();
        private Dictionary<char, double> _default_speed = new Dictionary<char, double>();
        private double[] _units;
        private Object _motionLock;
        private EAvvaMotionState _motionState = EAvvaMotionState.Off;
        public bool IsSimulate { get; set; }
        private bool _hasHome = false;
        public EAvvaMotionState MotionState() 
        { 
            return _motionState; 
        } 
        //public EAvvaMotionState MotionState { get { return _motionState; } }
        public AvvaMotion(IAvvaMotion avvaMotion, string parafile = null, log4net.ILog log = null)
        {
            try
            {
                _motion = avvaMotion;
                _motionLock = new Object();
                if (log == null)
                {
                    ILoggerRepository repository = log4net.LogManager.CreateRepository("AvvaMotion");
                    log4net.Config.XmlConfigurator.ConfigureAndWatch(repository,
                        new FileInfo(Path.GetDirectoryName(
                            Assembly.GetAssembly(typeof(AvvaMotion)).Location) + @"\" + "AvvaMotion.log4net.xml"));
                    Console.WriteLine(Path.GetDirectoryName(
                            Assembly.GetAssembly(typeof(AvvaMotion)).Location) + @"\" + "AvvaMotion.log4net.xml");
                    _log = log4net.LogManager.GetLogger("AvvaMotion", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                }
                else
                {
                    _log = log;
                    _motion.log = _log;
                }
                Init(parafile);
                _motionState = EAvvaMotionState.Off;
            }
            catch (Exception ex)
            {
                _log.Fatal("AvvaMotion()" + Environment.NewLine + ex.ToString());
                throw new AvvaMotionException("Exception in AvvaMotion()", ex);
            }
        }
        ~AvvaMotion()
        {
            if (!IsSimulate && _motion!=null)
            {
                try
                {
                    _motion.MotorOff();
                    _motion.Dispose();
                }
                catch (Exception) { }
            }
        }
        private void Init(string paraFilename)
        {
            if (_motion == null)
            {
                IsSimulate = true;
                return;
            }
            Debug.WriteLine("[MotionParamReader] current directory: " + Directory.GetCurrentDirectory());
            if (paraFilename == null)
                paraFilename = Path.Combine(Directory.GetCurrentDirectory(), "AVVAMotionConfig.ini");
            if (!File.Exists(paraFilename))
            {
                throw new AvvaMotionException("找不到設定檔 " + paraFilename);
            }
            _paraReader = new MotionParamReader(paraFilename);
            IsSimulate = _paraReader.IsSimulate;
            _paraReader.BuildAxisAndDefaultSpeedMapping(axis_map, _default_speed);
            _units = _paraReader.Units;

            if (IsSimulate) return;
            _motion.Init(_paraReader.GetAllAxisData(), _paraReader.GetHomeData());
        }
        public void MotorOn()
        {
            if (IsSimulate)
            {
                _motionState = EAvvaMotionState.On;
                return;
            }
            lock (_motionLock)
            {
                try
                {
                    if (_motionState == EAvvaMotionState.On) return;
                    _motion.MotorOn();
                    _motionState = EAvvaMotionState.On;
                }
                catch (Exception ex)
                {
                    _log.Fatal("MotorOn()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MotorOn()", ex);
                }
            }
        }
        public void MotorOff()
        {
            if (IsSimulate)
            {
                _motionState = EAvvaMotionState.Off;
                return;
            }
            lock (_motionLock)
            {
                try
                {
                    if (_motionState == EAvvaMotionState.Off) return;
                    _motion.MotorOff();
                    _motionState = EAvvaMotionState.Off;
                }
                catch (Exception ex)
                {
                    _log.Fatal("MotorOff()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MotorOff()", ex);
                }
            }

        }
        public void MoveTo(char axis_char, double distance, bool isRelative = true)
        {
            MyMove(axis_char, distance, _default_speed[axis_char], isRelative, EAvvaMotionType.Sync);
        }
        public void MoveTo(char axis_char, double distance, double velocity, bool isRelative = true)
        {
            MyMove(axis_char, distance, velocity, isRelative, EAvvaMotionType.Sync);
        }
        public void MoveTo(char[] axis_char, double[] distance, bool isRelative = true)
        {
            MyMove(axis_char, distance, GetAxisDefaultSpeed(axis_char), isRelative, EAvvaMotionType.Sync);
        }
        public void MoveTo(char[] axis_char, double[] distance,double[] velocity, bool isRelative = true)
        {
            MyMove(axis_char, distance, velocity, isRelative, EAvvaMotionType.Sync);
        }
        public void AsyncMoveTo(char axis_char, double distance, bool isRelative = true)
        {
            MyMove(axis_char, distance, _default_speed[axis_char], isRelative, EAvvaMotionType.Async);
        }
        public void AsyncMoveTo(char axis_char, double distance,double velocity, bool isRelative = true)
        {
            MyMove(axis_char, distance, velocity, isRelative, EAvvaMotionType.Async);
        }

        public void AsyncMoveTo(char[] axis_char, double[] distance, bool isRelative = true)
        {
            MyMove(axis_char, distance, GetAxisDefaultSpeed(axis_char), isRelative, EAvvaMotionType.Async);
        }
        public void AsyncMoveTo(char[] axis_char, double[] distance,double[] velocity, bool isRelative = true)
        {
            MyMove(axis_char, distance, velocity, isRelative, EAvvaMotionType.Async);
        }
        private void MyMove(char[] axis_char, double[] distance, double[] velocity, bool isRelative, EAvvaMotionType m_type)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int[] axis = MoveArrayConvert(axis_char, distance, velocity);
                    if (m_type == EAvvaMotionType.Async)
                        _motion.AsyncMoveTo(axis, distance, velocity, isRelative);
                    else
                        _motion.MoveTo(axis, distance, velocity, isRelative);
                    _motionState = EAvvaMotionState.AsyncMove;
                }
                catch (Exception ex)
                {
                    _log.Fatal("AsyncMoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in AsyncMoveTo()", ex);
                }
            }
        }
        private void MyMove(char axis_char, double distance, double velocity, bool isRelative, EAvvaMotionType m_type)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int axis = GetAxisNum(axis_char);
                    if (m_type == EAvvaMotionType.Async)
                        _motion.AsyncMoveTo(axis, distance * _units[axis]
                                          , velocity * _units[axis], isRelative);
                    else
                        _motion.MoveTo(axis, distance * _units[axis]
                                     , velocity * _units[axis], isRelative);
                    _motionState = EAvvaMotionState.AsyncMove;
                }
                catch (Exception ex)
                {
                    _log.Fatal("AsyncMoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in AsyncMoveTo()", ex);
                }
            }
        }
        public void StopMove()
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    _motion.StopMove();
                    _motionState = EAvvaMotionState.StopMove;
                }
                catch (Exception ex)
                {
                    _log.Fatal("StopMove()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MotorOff()", ex);
                }
            }
        }
        public double GetPos(char axis_char)
        {
            if (IsSimulate) return 1;
            lock (_motionLock)
            {
                try
                {
                    int my_axis = GetAxisNum(axis_char);
                    return _motion.GetPos(my_axis) / _units[my_axis];
                }
                catch (Exception ex)
                {
                    //_log.Warn("GetPos()" + Environment.NewLine + ex.ToString());
                    Debug.WriteLine("GetPos Exception"+ex);
                    return -1;
                }
            }
        }
        public void JogStart(char axis_char, bool isPositive = true)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    int my_axis = GetAxisNum(axis_char);
                    _motion.JogStart(my_axis, isPositive);
                    _motionState = EAvvaMotionState.JogStart;
                }
                catch (Exception ex)
                {
                    _log.Fatal("JogStart()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in JogStart()", ex);
                }
            }
        }
        public void JogStop()
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    _motion.JogStop();
                    _motionState = EAvvaMotionState.JogStop;
                }
                catch (Exception ex)
                {
                    _log.Fatal("JogStop()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in JogStop()", ex);
                }
            }
        }
        public void ClearAlarm()
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    _motion.ClearAlarm();
                    _motionState = EAvvaMotionState.ClearAlarm;
                }
                catch (Exception ex)
                {
                    _log.Fatal("ClearAlarm()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in ClearAlarm()", ex);
                }
            }
        }
        public void GoHome()
        {
            if (IsSimulate)
            {
                _hasHome = true;
                return;
            }
            lock (_motionLock)
            {
                try
                {
                    _motion.GoHome();
                    _motionState = EAvvaMotionState.GoHome;
                    _hasHome = true;
                }
                catch (Exception ex)
                {
                    _log.Fatal("GoHome()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in GoHome()", ex);
                }
            }
        }
        public void GoHome(char[] axis_char)
        {
            if (IsSimulate)
            {
                _hasHome = true;
                return;
            }
            lock (_motionLock)
            {
                try
                {
                    int[] my_axis = GetAxisNumArray(axis_char);
                    _motion.GoHome(my_axis);
                    _motionState = EAvvaMotionState.GoHome;
                }
                catch (Exception ex)
                {
                    _log.Fatal("JogStop()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in JogStop()", ex);
                }
            }
        }
        private int GetAxisNum(char axis)
        {
            int my_axis = axis_map[axis];
            //如果輸入的axis不存在，系統會丟出keyNotFoundException
            //所以就先不另外處理了
            if (my_axis == -1)
            {
                throw new AvvaMotionException("Axis" + axis + " NOT Found");
            }
            return my_axis;
        }
        public double GetAxisDefaultSpeed(char axis)
        {                  
            double speed = _default_speed[axis];
            return speed;
        }
        public double[] GetAxisDefaultSpeed(char[] axis)
        {
            double[] speed = new double[axis.Length];
            for (int i = 0; i < axis.Length; i++)
                speed[i] = _default_speed[axis[i]];
            return speed;
        }      
        private int[] GetAxisNumArray(char[] axis)
        {
            int[] axis_array = new int[axis.Length];
            for (int i = 0; i < axis.Length; i++)
            {
                int my_axis = axis_map[axis[i]];
                if (my_axis == -1)
                {
                    throw new AvvaMotionException("Axis" + axis + " NOT Found");
                }
                axis_array[i] = my_axis;
            }
            return axis_array;
        }
        private int[] MoveArrayConvert(char[] axis, double[] distance, double[] velocity)
        {
            int[] axis_array = new int[axis.Length];
            for (int i = 0; i < axis.Length; i++)
            {
                int my_axis = AxisNo(axis[i]);
                axis_array[i] = my_axis;
                distance[i] *= _units[my_axis];
                velocity[i] *= _units[my_axis];
            }
            return axis_array;
        }
        private int AxisNo(char axis)
        {
            int my_axis = axis_map[axis];
            if (my_axis == -1)
            {
                throw new AvvaMotionException("Axis" + axis + " NOT Found");
            }
            return my_axis;
        }
    }
}
