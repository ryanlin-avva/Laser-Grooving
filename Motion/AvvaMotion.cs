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

        private IAvvaMotion _motion;
        private static log4net.ILog _log;
        private MotionParamReader _paraReader;
        private Dictionary<char, int> axis_map = new Dictionary<char, int>();
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
            if (IsSimulate) return;

            _paraReader.BuildAxisMapping(axis_map);
            _units = _paraReader.Units;

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
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int my_axis = GetAxisNum(axis_char);
                    _motion.MoveTo(my_axis, distance * _units[my_axis], isRelative);
                    _motionState = EAvvaMotionState.Move;
                }
                catch (Exception ex)
                {
                    _log.Fatal("MoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MoveTo()", ex);
                }
            }
        }
        public void MoveTo(char axis_char, double distance, double velocity,bool isRelative = true)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int my_axis = GetAxisNum(axis_char);
                    _motion.MoveTo(my_axis, distance * _units[my_axis], velocity * _units[my_axis], isRelative);
                    _motionState = EAvvaMotionState.Move;
                }
                catch (Exception ex)
                {
                    _log.Fatal("MoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MoveTo()", ex);
                }
            }
        }
        public void MoveTo(char[] axis_char, double[] distance, bool isRelative)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int[] axis = MoveArrayConvert(axis_char, distance);
                    _motion.MoveTo(axis, distance, isRelative);
                    _motionState = EAvvaMotionState.Move;
                }
                catch (Exception ex)
                {
                    _log.Fatal("MoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MoveTo()", ex);
                }
            }
        }
        public void MoveTo(char[] axis_char, double[] distance,double[] velocity, bool isRelative)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int[] axis = MoveArrayConvert(axis_char, distance,velocity);
                    _motion.MoveTo(axis, distance,velocity, isRelative);
                    _motionState = EAvvaMotionState.Move;
                }
                catch (Exception ex)
                {
                    _log.Fatal("MoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in MoveTo()", ex);
                }
            }
        }
        public void AsyncMoveTo(char axis_char, double distance, bool isRelative = true)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int my_axis = GetAxisNum(axis_char);
                    _motion.AsyncMoveTo(my_axis, distance * _units[my_axis], isRelative);
                    _motionState = EAvvaMotionState.AsyncMove;
                }
                catch (Exception ex)
                {
                    _log.Fatal("AsyncMoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in AsyncMoveTo()", ex);
                }
            }
        }
        public void AsyncMoveTo(char axis_char, double distance,double velocity, bool isRelative = true)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int my_axis = GetAxisNum(axis_char);
                    _motion.AsyncMoveTo(my_axis, distance * _units[my_axis], velocity * _units[my_axis], isRelative);
                    _motionState = EAvvaMotionState.AsyncMove;
                }
                catch (Exception ex)
                {
                    _log.Fatal("AsyncMoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in AsyncMoveTo()", ex);
                }
            }
        }

        public void AsyncMoveTo(char[] axis_char, double[] distance, bool isRelative)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int[] axis = MoveArrayConvert(axis_char, distance);
                    _motion.AsyncMoveTo(axis, distance, isRelative);
                    _motionState = EAvvaMotionState.AsyncMove;
                }
                catch (Exception ex)
                {
                    _log.Fatal("AsyncMoveTo()" + Environment.NewLine + ex.ToString());
                    throw new AvvaMotionException("Exception in AsyncMoveTo()", ex);
                }
            }
        }
        public void AsyncMoveTo(char[] axis_char, double[] distance,double[] velocity, bool isRelative)
        {
            if (IsSimulate) return;
            lock (_motionLock)
            {
                try
                {
                    if (!isRelative && !_hasHome)
                        throw new AvvaMotionException("Absolute Move Before Go Zero");
                    int[] axis = MoveArrayConvert(axis_char, distance,velocity);
                    _motion.AsyncMoveTo(axis, distance,velocity, isRelative);
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
        private int[] MoveArrayConvert(char[] axis, double[] distance)
        {
            int[] axis_array = new int[axis.Length];
            for (int i=0; i<axis.Length; i++)
            {
                int my_axis = axis_map[axis[i]];
                if (my_axis == -1)
                {
                    throw new AvvaMotionException("Axis" + axis + " NOT Found");
                }
                axis_array[i] = my_axis;
                distance[i] *= _units[my_axis];
            }
            return axis_array;
        }
        private int[] MoveArrayConvert(char[] axis, double[] distance,double[] velocity)
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
                distance[i] *= _units[my_axis];
                velocity[i] *= _units[my_axis];
            }
            return axis_array;
        }
    }
}
