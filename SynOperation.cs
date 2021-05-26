using Avva.CameraFramework;
using Avva.MotionFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using Velociraptor.ImageProc;

namespace Velociraptor
{
    class SynOperation
    {
        public enum eScanType { Scan5Um, Scan1Um };

        private AvvaMotion _motion;
        private AvvaCamera _camera;
        private ParamReader _paraReader;
        private double[] _target_pos = new double[9];
        private char[] _target_axis;
        private bool hasGoHome = false;
        private log4net.ILog _log;

        public SynOperation(string para_path, AvvaCamera camera, log4net.ILog log = null,log4net.ILog log_motion = null)
        {
        _camera = camera;
        _log = log;
        IAvvaMotion yaskawa = new YaskawaMotion();
        string path = Path.Combine(para_path, Constants.motionParaFilename);
        _motion = new AvvaMotion(yaskawa, path, log_motion);
        path = Path.Combine(para_path, Constants.paraFilename);
        _paraReader = new ParamReader(path);
        AsyncMove += OnAsyncMove;
        EncoderSet = new AutoResetEvent(false);
        DataSaved = new AutoResetEvent(false);
        ScanFileIndex = -1;
        }
        #region Find Angle
        public delegate void FindAngleDelegate(Bitmap mymap, double[] die_size, int threshold);
        private FindScribe _fs = new FindScribe();
        private double[] _estimatedDieSide = new double[2];
        public double[] EstimatedDieSide { get { return _estimatedDieSide; } }
        public double AngleAverage { get { return _fs.AngleAverage;  } }
        public void Draw(ref Bitmap bmp) { _fs.Draw(ref bmp); }
        public Bitmap Threshold(Bitmap mymap, int threshold) { return _fs.DoThreshold(mymap, threshold); }
        public bool FindAngleOK { get; set; }
        public void FindAngle(Bitmap mymap, double[] die_size, int threshold)
        {
            VisionCalibrator vc = new VisionCalibrator();
            try
            {
                FindAngleOK = true;
                Console.WriteLine("Synop findangle _cur_map:" + mymap.Width);
                _fs.FindAngle(mymap, threshold, die_size);
                _estimatedDieSide[Constants.WAY_HORIZONTAL] = vc.Pixel2Um_X(_fs.WidthAverage);
                _estimatedDieSide[Constants.WAY_VERTICAL] = vc.Pixel2Um_X(_fs.HeightAverage);
                //Bitmap bmp = new Bitmap(_cur_bitmap.Width, _cur_bitmap.Height);
            }
            catch (Exception ex)
            {
                SynOpErrorArgs arg = new SynOpErrorArgs();
                arg.Ex = ex;
                arg.Message = "SynOp.FindAngle()";
                FindAngleOK = false;
                OnError(this, arg);
            }
        }
        #endregion
        #region Scan & measure
        public delegate void MeasureDelegate(List<string> pathname, List<PointF> pos
                                           , eScanType scan_type, int measureDistance
                                           , Bitmap mymap, double[] die_size, int threshold);
        public delegate void CameraAutoFocusDelegate();
        public delegate void MoveDelegate(MoveEventArgs m_args);
        public bool IsScanning { get; set; }
        public string ScanFileName { get; set; }
        public int ScanFileIndex { get; set; }
        public bool EncoderParamSetOk { get; set; }

        //Delegate For move 1um/5um testing
        public delegate void ScanMoveDelegate(int distance);
        public event EventHandler AsyncMove;
        public event EventHandler ScanParamSet;
        public event EventHandler OnError;
        public AutoResetEvent EncoderSet;
        public AutoResetEvent DataSaved;

        public bool MeasureOK { get; set; }
        public void AsyncMove5um(int measureDistance)
        {
            _log.Debug("AsyncMove5um with distance="
                            +measureDistance.ToString()+":" 
                            + Thread.CurrentThread.ManagedThreadId);
            _log.Debug("AsyncMove5um 1st Wait over");
            MoveEventArgs moveEventArgs = new MoveEventArgs('X', measureDistance + 200, true);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
            _log.Debug("AsyncMove5um 2nd Wait over");
        }
        public void AsyncMove1um(int measureDistance)
        {
            int buffer2 = Constants.MeasureScanBuffer * 2;
            double[] move_x = { measureDistance+buffer2, -measureDistance-buffer2 
                              , measureDistance+buffer2, -measureDistance-buffer2  
                              , measureDistance+Constants.MeasureScanBuffer };
            _log.Debug("AsyncMove1um to begin pos");
            for (int i = 0; i < 5; i++)
            {
                MoveEventArgs moveEventArgs = new MoveEventArgs('X', move_x[i], true);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                _log.Debug("AsyncMove1um finish line "+i.ToString());
                if (i < 4)
                {
                    moveEventArgs = new MoveEventArgs('Y', 1, true);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();
                    _log.Debug("AsyncMove1um Move Y ");
                }
            }
        }
        public void MeasureScan(List<string> pathname, List<PointF> pos
                                , eScanType scan_type, int measureDistance
                                , Bitmap mymap, double[] die_size, int threshold)
        {
            MeasureOK = false;
            Alignment(mymap, die_size, threshold);
            if (!AlignmentOK) return;
            char[] axisXY = { 'X', 'Y' };
            char[] axisXYZ = { 'X', 'Y', 'Z' };
            double[] relative2Measure = { _paraReader.RelToMeasureCameraX-Constants.MeasureScanBuffer
                                        , _paraReader.RelToMeasureCameraY
                                        , _paraReader.RelToMeasureCameraZ };
            try
            {
                MoveEventArgs moveEventArgs;
                for (int i = 0; i < pos.Count; i++)
                {
                    ScanFileName = pathname[i];
                    ScanFileIndex = i;
                    _log.Debug("MeasureScan filename:"+ ScanFileName);
                    double[] distance = { pos[i].X, pos[i].Y };
                    moveEventArgs = new MoveEventArgs(axisXY, distance, false);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();
                    _camera.SaveImage(pathname + ".bmp");
                    moveEventArgs = new MoveEventArgs(axisXYZ, relative2Measure, true);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();
                    moveEventArgs = new MoveEventArgs('X', _paraReader.RelToMeasureCameraX, true);
                    EncoderSet.Reset();
                    ScanParamSet(this, moveEventArgs);
                    EncoderSet.WaitOne();
                    if (EncoderParamSetOk)
                    {
                        DataSaved.Reset();
                        if (scan_type == eScanType.Scan5Um) AsyncMove5um(measureDistance);
                        else AsyncMove1um(measureDistance);
                        DataSaved.WaitOne();                        
                    }
                    else
                    {
                        return;
                    }
                }
                MeasureOK = true;
            }
            catch(Exception ex)
            {
                SynOpErrorArgs arg = new SynOpErrorArgs();
                arg.Ex = ex;
                arg.Message = "MeasureScan()";
                OnError(this, arg);
            }
        }
        public List<PointF> TransformDiePos(int die_row, int die_col, List<Point> pts)
        {
            double[] _center_pos = { _paraReader.MoveToWaferCenterPointXDistance
                                    , _paraReader.MoveToWaferCenterPointYDistance };
            int offset_x = 0;
            int offset_y = 0;
            if (die_col % 2 == 1)
            {
                _center_pos[0] -= _estimatedDieSide[0] / 2;
            }
            else
            {
                offset_x = 1;
            }
            if (die_row % 2 == 1)
            {
                _center_pos[1] -= _estimatedDieSide[1] / 2;
            }
            else
            {
                offset_y = 1;
            }
            List<PointF> pos = new List<PointF>();
            foreach (var p in pts)
            {
                float x = (float)((p.X > 0)
                            ? _center_pos[0] + (p.X - offset_x) * _estimatedDieSide[0]
                            : _center_pos[0] + p.X * _estimatedDieSide[0]);
                float y = (float)((p.Y > 0)
                            ? _center_pos[1] + (p.Y - offset_y) * _estimatedDieSide[1]
                            : _center_pos[1] + p.Y * _estimatedDieSide[1]);
                PointF f = new PointF(x, y);
                pos.Add(f);
            }
            return pos;
        }
        #endregion
        #region alignment
        public bool AlignmentOK { get; set; }
        public void Alignment(Bitmap mymap, double[] die_size, int threshold)
        {
            try
            {
                AlignmentOK = false;
                _camera.MinMagSet();
                char[] axis = { 'X', 'Y' };
                double[] center = GetCenter();
                MoveEventArgs moveEventArgs = new MoveEventArgs(axis, GetCenter(), false);
                OnAsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                FindAngle(mymap, die_size, threshold);
                if (!FindAngleOK) return;
                moveEventArgs = new MoveEventArgs('R', _fs.AngleAverage * 1000, true);
                OnAsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                _camera.MaxMagSet();
                AlignmentOK = true;
            }
            catch (Exception ex)
            {
                SynOpErrorArgs arg = new SynOpErrorArgs();
                arg.Ex = ex;
                arg.Message = "SynOp.Alignment()";
                OnError(this, arg);
            }
        }
        #endregion
        #region Move and Jog
        public void JogY(bool toStart, bool isPositive = true)
        {
            if (toStart)
            {
                _motion.JogStart('Y', isPositive);
            }
            else
            {
                _motion.JogStop();
            }
        }
        private void OnAsyncMove(Object sender, EventArgs e)
        {
            MoveEventArgs moveEventArgs = (MoveEventArgs)e;
            _target_axis = moveEventArgs.Axis;
            _target_pos = new double[_target_axis.Length];
            for (int i = 0; i < _target_axis.Length; i++)
            {
                if (moveEventArgs.Relative)
                    _target_pos[i] = moveEventArgs.Position[i]
                               + _motion.GetPos(_target_axis[i]);
                else
                    _target_pos[i] = moveEventArgs.Position[i];
            }
            _log.Debug("SynOp OnAsyncMove:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void AsyncMoveWait()
        {
            _log.Debug("SynOp AsyncMoveWait:" + Thread.CurrentThread.ManagedThreadId.ToString());
            if (IsSimulate)
            {
                //Thread.Sleep(1000);
                return;
            }
            for (int i = 0; i < _target_axis.Length; i++)
            {
                while (GetPos(_target_axis[i]) != _target_pos[i])
                {
                    Thread.Sleep(50);
                }
            }
        }

        public void MoveToCenter()
        {
            char[] axis = { 'X', 'Y', 'R' };
            double[] distance = { _paraReader.MoveToWaferCenterPointXDistance
                                , _paraReader.MoveToWaferCenterPointYDistance
                                 ,_paraReader.MoveToWaferCenterPointRDistance};
            if (!hasGoHome) GoHome();
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis, distance, false);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
        }
        public double[] GetCenter()
        {
            double[] distance = { _paraReader.MoveToWaferCenterPointXDistance
                                , _paraReader.MoveToWaferCenterPointYDistance 
                                };
            return distance;
        }
        public void AsyncMoveTo(char axis_char, double distance, bool isRelative = true)
        {
            _log.Debug("SynOp AsyncMoveTo:" + Thread.CurrentThread.ManagedThreadId.ToString());
            _motion.AsyncMoveTo(axis_char, distance, isRelative);
        }
        public void AsyncMoveTo(char[] axis_char, double[] distance, bool isRelative = true)
        {
            _log.Debug("SynOp AsyncMoveTo:" + Thread.CurrentThread.ManagedThreadId.ToString());
            _motion.AsyncMoveTo(axis_char, distance, isRelative);
        }
        public void SyncMoveTo(MoveEventArgs moveEventArgs)
        {
            _log.Debug("SynOp MoveTo Emu:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //AsyncMove.BeginInvoke(this, moveEventArgs, new AsyncCallback(SyncMoveEmu_Callback), null);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
        }
        public void MoveToUnload()
        {
            if (!hasGoHome) GoHome();
            char[] axis = { 'X', 'Y', 'Z' };
            double[] distance = { _paraReader.MoveToWaferCenterPointXDistance
                                , _paraReader.MoveToWaferUnloadPointYDistance
                                , 0 };
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis, distance, false);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
        }
        #endregion
        #region Motor Operation
        public double GetPos(char axis_char)
        {
            return _motion.GetPos(axis_char);
        }
        public void MotorOn() { _motion.MotorOn(); }
        public void MotorOff() { _motion.MotorOff(); }
        public void GoHome() { _motion.GoHome(); }
        public void StopMove() { _motion.StopMove(); }
        public void ClearAlarm() { _motion.ClearAlarm(); }
        #endregion
        #region Get Param
        public bool IsSimulate { get { return _motion.IsSimulate; } }
        public int DataDirection { get { return _paraReader.DataDirection; } }
        public int TriggerInterval { get { return _paraReader.TriggerInterval; } }
        public string SavingPath { get { return _paraReader.SavingPath; } }
        public int MaxMagAutoFocusBegin { get { return _paraReader.MaxMagAutoFocusBegin; } }
        public int MaxMagAutoFocusEnd { get { return _paraReader.MaxMagAutoFocusEnd; } }
        #endregion
    }
    public class MoveEventArgs : EventArgs
    {
        public MoveEventArgs(char[] axis, double[] position, bool isRelative)
        {
            Relative = isRelative;
            Position = position;
            Axis = axis;
        }
        public MoveEventArgs(char axis, double position, bool isRelative)
        {
            Relative = isRelative;
            double[] pos = { position };
            char[] a = { axis };
            Position = pos;
            Axis = a;
        }
        public bool Relative { get; set; }
        public double[] Position { get; set; }
        public char[] Axis { get; set; }
    }
}
