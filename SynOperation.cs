using Avva.CameraFramework;
using Avva.MotionFramework;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Velociraptor
{
    class SynOperation
    {
        public enum eScanType { Scan5Um, Scan1Um };

        private AvvaMotion _motion;
        private AvvaCamera _camera;
        private HalconProc _hp;
        private ParamReader _paraReader;
        private double[] _2_mea = new double[3];
        private double[] _target_pos = new double[9];
        private char[] _target_axis;
        private bool hasGoHome = false;

        #region Scan
        public delegate void MeasureDelegate(List<string> pathname, List<PointF> pos
                                           , eScanType scan_type
                                           , int measureDistance);
        public delegate void CameraAutoFocusDelegate();
        public delegate void MoveDelegate(MoveEventArgs m_args);
        public bool IsScanning { get; set; }
        public string ScanFileName { get; set; }
        public bool EncoderParamSetOk { get; set; }
        public delegate void ScanMoveDelegate(int distance);
        public event EventHandler AsyncMove;
        public event EventHandler ScanParamSet;
        public event EventHandler OnError;
        public AutoResetEvent EncoderSet;
        #endregion

        public SynOperation(HalconProc hp, string para_path, AvvaCamera camera, log4net.ILog log = null)
        {
            _hp = hp;
            _camera = camera;
            IAvvaMotion yaskawa = new YaskawaMotion();
            string path = Path.Combine(para_path, Constants.motionParaFilename);
            _motion = new AvvaMotion(yaskawa, path, log);
            path = Path.Combine(para_path, Constants.paraFilename);
            _paraReader = new ParamReader(path);
            AsyncMove += OnAsyncMove;
            EncoderSet = new AutoResetEvent(false);
        }
        public void MotorOn() { _motion.MotorOn(); }
        public void MotorOff() { _motion.MotorOff(); }
        public void GoHome() { _motion.GoHome(); }
        public void StopMove() { _motion.StopMove(); }
        public void ClearAlarm() { _motion.ClearAlarm(); }
        public bool IsSimulate { get { return _motion.IsSimulate; } }
        public int DataDirection { get { return _paraReader.DataDirection; } }
        public int TriggerInterval { get { return _paraReader.TriggerInterval; } }
        public string SavingPath { get { return _paraReader.SavingPath; } }
        public int MaxMagAutoFocusBegin { get { return _paraReader.MaxMagAutoFocusBegin; } }
        public int MaxMagAutoFocusEnd { get { return _paraReader.MaxMagAutoFocusEnd; } }
        public void AsyncMoveTo(char axis_char, double distance, bool isRelative = true)
        {
            Debug.WriteLine("SynOp AsyncMoveTo:" + Thread.CurrentThread.ManagedThreadId.ToString());
            _motion.AsyncMoveTo(axis_char, distance, isRelative);
        }
        public void AsyncMoveTo(char[] axis_char, double[] distance, bool isRelative = true)
        {
            Debug.WriteLine("SynOp AsyncMoveTo:" + Thread.CurrentThread.ManagedThreadId.ToString());
            _motion.AsyncMoveTo(axis_char, distance, isRelative);
        }
        public void SyncMoveTo(MoveEventArgs moveEventArgs)
        {
            Debug.WriteLine("SynOp MoveTo Emu:" + Thread.CurrentThread.ManagedThreadId.ToString());
            //AsyncMove.BeginInvoke(this, moveEventArgs, new AsyncCallback(SyncMoveEmu_Callback), null);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
        }
        public void DoAlignment(HObject cur_img, int threshold, ref double[] die_side)
        {
            double angle = 0;
            try
            {
                find_angle(cur_img, threshold, ref die_side, ref angle);
                _motion.MoveTo('R', angle * 1000.0);
            }
            catch (Exception ex)
            {
                throw new AvvaException("轉正失敗：請重新調整焦距或切割道閥值", ex);
            }
        }
        public void find_angle(HObject cur_img, int threshold, ref double[] die_side, ref double angle)
        {
            if (die_side[0] == 0 || die_side[1] == 0)
                throw new AvvaException("Die Size is required");
            HObject gray_img = null;
            _hp.PrepareGrayImage(cur_img, out gray_img);
            if (gray_img == null)
                throw new AvvaException("No Gray Image Generated");
            int[] side_int = new int[die_side.Length];
            for (int i = 0; i < die_side.Length; i++)
                side_int[i] = (int)die_side[i];
            GridBuilder grid = new GridBuilder(gray_img, side_int
                                    , Constants.SCRIBE_IS_DARK
                                    , threshold, _hp);
            if (!grid.DoLineSegment(_hp))
                throw new AvvaException(grid.ErrMsg);

            //hp.DrawGrid(cur_img, grid.Getlines(0), grid.Getlines(1));
            _hp.DrawGrid(null, grid.Getlines(0), grid.Getlines(1));
            die_side[0] = grid.EstimatedWidth();
            die_side[1] = grid.EstimatedHeight();
            angle = grid.EstimatedThetaByDegree();
        }
        public double GetPos(char axis_char)
        {
            return _motion.GetPos(axis_char);
        }
        //public void MoveToMeasurePos()
        //{
        //    char[] axes = { 'X', 'Y', 'Z' };
        //    MoveTo(axes, _2_mea, true);
        //}
        private void OnAsyncMove(Object sender, EventArgs e)
        {
            MoveEventArgs moveEventArgs = (MoveEventArgs)e;
            _target_axis = moveEventArgs.Axis;
            _target_pos = new double[_target_axis.Length];
            if (moveEventArgs.Relative)
            {
                for (int i = 0; i < _target_axis.Length; i++)
                {
                    _target_pos[i] = moveEventArgs.Position[i]
                                   + _motion.GetPos(_target_axis[i]);
                }
            }
            else
            {
                _target_pos = moveEventArgs.Position;
            }
            Debug.WriteLine("SynOp OnAsyncMove:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void AsyncMoveWait()
        {
            Debug.WriteLine("SynOp AsyncMoveWait:" + Thread.CurrentThread.ManagedThreadId.ToString());
            if (IsSimulate)
            {
                Thread.Sleep(1000);
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

        public void AsyncMove5um(int measureDistance)
        {
            Debug.WriteLine("AsyncMove5um with distance="
                            +measureDistance.ToString()+":" 
                            + Thread.CurrentThread.ManagedThreadId);
            Debug.WriteLine("AsyncMove5um 1st Wait over");
            MoveEventArgs moveEventArgs = new MoveEventArgs('X', measureDistance + 200, true);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
            Debug.WriteLine("AsyncMove5um 2nd Wait over");
        }
        public void AsyncMove1um(int measureDistance)
        {
            int buffer2 = Constants.MeasureScanBuffer * 2;
            double[] move_x = { measureDistance+buffer2, -measureDistance-buffer2 
                              , measureDistance+buffer2, -measureDistance-buffer2  
                              , measureDistance+Constants.MeasureScanBuffer };
            Debug.WriteLine("AsyncMove1um to begin pos");
            for (int i = 0; i < 5; i++)
            {
                MoveEventArgs moveEventArgs = new MoveEventArgs('X', move_x[i], true);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                Debug.WriteLine("AsyncMove1um finish line "+i.ToString());
                if (i < 4)
                {
                    moveEventArgs = new MoveEventArgs('Y', 1, true);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();
                    Debug.WriteLine("AsyncMove1um Move Y ");
                }
            }
        }
        public void MeasureScan(List<string> pathname, List<PointF> pos
                                , eScanType scan_type, int measureDistance)
        {
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
                    Debug.WriteLine("MeasureScan filename:"+ ScanFileName);
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
                        if (scan_type == eScanType.Scan5Um) AsyncMove5um(measureDistance);
                        else AsyncMove1um(measureDistance);
                    }
                }
            }
            catch(Exception ex)
            {
                SynOpErrorArgs arg = new SynOpErrorArgs();
                arg.Ex = ex;
                arg.Message = "MeasureScan()";
                OnError(this, arg);
            }
        }
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
        public List<PointF> TransformDiePos(int die_row, int die_col, double[] estimated_size, List<Point> pts)
        {
            double[] _center_pos = { _paraReader.MoveToWaferCenterPointXDistance
                                    , _paraReader.MoveToWaferCenterPointYDistance };
            int offset_x = 0;
            int offset_y = 0;
            if (die_col % 2 == 1)
            {
                _center_pos[0] -= estimated_size[0] / 2;
            }
            else
            {
                offset_x = 1;
            }
            if (die_row % 2 == 1)
            {
                _center_pos[1] -= estimated_size[1] / 2;
            }
            else
            {
                offset_y = 1;
            }
            List<PointF> pos = new List<PointF>();
            foreach (var p in pts)
            {
                float x = (float)((p.X > 0)
                            ? _center_pos[0] + (p.X - offset_x) * estimated_size[0]
                            : _center_pos[0] + p.X * estimated_size[0]);
                float y = (float)((p.Y > 0)
                            ? _center_pos[1] + (p.Y - offset_y) * estimated_size[1]
                            : _center_pos[1] + p.Y * estimated_size[1]);
                PointF f = new PointF(x, y);
                pos.Add(f);
            }
            return pos;
        }
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
