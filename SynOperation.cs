using Avva.CameraFramework;
using Avva.MotionFramework;
using OpenCvSharp;
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
        public enum eMagType { MaxMag, MinMag, UnknownMag };

        private AvvaMotion _motion;
        private AvvaCamera _camera;
        private ParamReader _paraReader;
        private double[] _target_pos = new double[9];
        private char[] _target_axis;
        private bool hasGoHome = false;
        private log4net.ILog _log;
        private double _maxMagFocusPos;
        private double _minMagFocusPos;
        private int _maxMagIntensity;
        private int _minMagIntensity;

        //Delegate for autofocus and change lens maginitude
        public delegate void SetMagDelegate(eMagType mag_type);
        public delegate void WaferLoadDelegate();

        private delegate double ComputeScoreDelegate(Object image);
        private ComputeScoreDelegate computeFocusScoreDelegate;
        private ComputeScoreDelegate computeLightScoreDelegate;
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
            computeFocusScoreDelegate = new ComputeScoreDelegate(Cv2LaplacianVariance);
            computeLightScoreDelegate = new ComputeScoreDelegate(ContrastVariance);
        }
        #region AutoFocus
        private long minAFFuncMs;
        private long maxAFFuncMs;
        public Mat ImgMat { get; set; }
        eMagType _cur_mag = eMagType.UnknownMag;
        public readonly AutoResetEvent imageFilterDone = new AutoResetEvent(false);
        public void ToMagPos(eMagType mag_type)
        {
            if (_cur_mag == mag_type)
            {
                _log.Debug("ToMagPos at the right pos");
                return;
            }
            try
            {
                _log.Debug("ToMagPos:" + Thread.CurrentThread.ManagedThreadId);
                MoveEventArgs moveEventArgs;
                if (mag_type == eMagType.MaxMag)
                {
                    _camera.MaxMagSet();
                    moveEventArgs = new MoveEventArgs('Z', _maxMagFocusPos, false);
                }
                else
                {
                    _camera.MinMagSet();
                    moveEventArgs = new MoveEventArgs('Z', _minMagFocusPos, false);
                }
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                SetLight(mag_type);
                _cur_mag = mag_type;
            }
            catch (Exception ex)
            {
                _cur_mag = eMagType.UnknownMag;
                SynOpErrorArgs arg = new SynOpErrorArgs();
                arg.Ex = ex;
                arg.Message = "SynOp.ToMagPos()";
                FindAngleOK = false;
                OnError(this, arg);
            }
        }
        public void WaferLoad()
        {
            MoveToCenter();
            MagAutoFocus(eMagType.MaxMag);
            MagAutoFocus(eMagType.MinMag);
        }
        private void MagAutoFocus(eMagType mag_type)
        {
            int beginPosition, endPosition, positionNo, positionId;
            MoveEventArgs moveEventArgs;
            int[] runPosition;
            IAsyncResult[] result;
            double[] variance;
            double maxVariance;
            Object[] runImage;

            _log.Debug("Auto Focusing First Run("+mag_type+":"+Thread.CurrentThread.ManagedThreadId);

            try
            {
                if (mag_type == eMagType.MaxMag)
                {
                    beginPosition = _paraReader.MaxMagAutoFocusBegin;
                    endPosition = _paraReader.MaxMagAutoFocusEnd;
                    _camera.MaxMagSet();
                }
                else
                {
                    beginPosition = _paraReader.MinMagAutoFocusBegin;
                    endPosition = _paraReader.MinMagAutoFocusEnd;
                    _camera.MinMagSet();
                }

                positionNo = (Math.Abs(endPosition - beginPosition)) / 100 + 1;

                minAFFuncMs = Int32.MaxValue;
                maxAFFuncMs = 0;

                runPosition = new int[positionNo];
                result = new IAsyncResult[positionNo];
                variance = new double[positionNo];
                runImage = new Object[positionNo];

                for (int position = beginPosition, i = 0; position <= endPosition; position += 100, i++)
                {
                    runPosition[i] = position;
                    moveEventArgs = new MoveEventArgs('Z', position, false);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();

                    imageFilterDone.Reset();
                    _camera.FilterImage(position, 1);
                    imageFilterDone.WaitOne();

                    runImage[i] = ImgMat;

                    result[i] = computeFocusScoreDelegate.BeginInvoke(runImage[i], null, null);
                }

                for (int i = 0; i < positionNo; i++)
                {
                    result[i].AsyncWaitHandle.WaitOne();
                    variance[i] = computeFocusScoreDelegate.EndInvoke(result[i]);
                    result[i].AsyncWaitHandle.Close();
                }

                maxVariance = variance[0];
                positionId = 0;
                for (int i = 0; i < positionNo; i++)
                {
                    Console.WriteLine("variance[" + i + "]= " + variance[i]);
                    if (variance[i] > maxVariance)
                    {
                        maxVariance = variance[i];
                        positionId = i;
                    }
                }

                _log.Debug("position id: " + positionId + ", position: " + runPosition[positionId] + ", variance: " + variance[positionId]);

                _log.Debug("Auto Focusing Second Run:");

                if (positionId == 0)
                    beginPosition = runPosition[0];
                else
                    beginPosition = runPosition[positionId - 1];

                if (positionId == positionNo - 1)
                    endPosition = runPosition[positionNo - 1];
                else
                    endPosition = runPosition[positionId + 1];

                positionNo = (Math.Abs(endPosition - beginPosition)) / 10 + 1;

                runPosition = new int[positionNo];
                result = new IAsyncResult[positionNo];
                variance = new double[positionNo];
                runImage = new Object[positionNo];

                for (int position = beginPosition, i = 0; position <= endPosition; position += 10, i++)
                {
                    runPosition[i] = position;
                    moveEventArgs = new MoveEventArgs('Z', position, false);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();

                    imageFilterDone.Reset();
                    _camera.FilterImage(position, 1);
                    imageFilterDone.WaitOne();

                    runImage[i] = ImgMat;

                    result[i] = computeFocusScoreDelegate.BeginInvoke(runImage[i], null, null);
                }

                for (int i = 0; i < positionNo; i++)
                {
                    result[i].AsyncWaitHandle.WaitOne();
                    variance[i] = computeFocusScoreDelegate.EndInvoke(result[i]);
                    result[i].AsyncWaitHandle.Close();
                }

                maxVariance = variance[0];
                positionId = 0;
                for (int i = 0; i < positionNo; i++)
                {
                    Console.WriteLine("variance[" + i + "]: " + variance[i]);
                    if (variance[i] > maxVariance)
                    {
                        maxVariance = variance[i];
                        positionId = i;
                    }
                }
                if (mag_type == eMagType.MaxMag) _maxMagFocusPos = runPosition[positionId];
                else _minMagFocusPos = runPosition[positionId];
                _cur_mag = mag_type;
                moveEventArgs = new MoveEventArgs('Z', runPosition[positionId], false);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                _log.Debug("position id: " + positionId + ", position: " + runPosition[positionId] + ", variance: " + variance[positionId]);
                _log.Debug("Max AF func elapsed ms: " + maxAFFuncMs + ", Min AF func elapsed ms: " + minAFFuncMs);
                AutoLight(mag_type);
            }
            catch (Exception ex)
            {
                SynOpErrorArgs arg = new SynOpErrorArgs();
                arg.Ex = ex;
                arg.Message = "SynOp.AutoFocus()";
                FindAngleOK = false;
                OnError(this, arg);
            }
        }
        private double Cv2LaplacianVariance(Object image)
        {
            Mat mat = (Mat)image;
            double variance;
            var watch = System.Diagnostics.Stopwatch.StartNew();

            using (var gray = new Mat())
            using (var laplacian = new Mat())
            {
                Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
                Cv2.Laplacian(gray, laplacian, MatType.CV_16S, 3);
                Cv2.MeanStdDev(laplacian, out var mean, out var stddev);
                variance = stddev.Val0 * stddev.Val0;
            }

            mat.Dispose();

            watch.Stop();

            if (watch.ElapsedMilliseconds < minAFFuncMs)
                minAFFuncMs = watch.ElapsedMilliseconds;
            else if (watch.ElapsedMilliseconds > maxAFFuncMs)
                maxAFFuncMs = watch.ElapsedMilliseconds;

            return variance;
        }
        private void SetLight(eMagType mag_type)
        {
            if (mag_type == eMagType.MaxMag) _camera.IntstSet(0, _maxMagIntensity);
            else _camera.IntstSet(0, _minMagIntensity);
        }
        private void AutoLight(eMagType mag_type)
        {
            int beginIntst, endIntst, intstId, intstNo, intstIdMax, intstIdMin;
            IAsyncResult[] result;
            int[] runIntst;
            double[] variance;
            double maxVariance, minVariance;
            Object[] runImage;

            beginIntst = 55;
            endIntst = 255;
            intstNo = (endIntst - beginIntst) / 10 + 1;

            runIntst = new int[intstNo];
            result = new IAsyncResult[intstNo];
            variance = new double[intstNo];
            runImage = new Object[intstNo];

            for (int intst = beginIntst, i = 0; intst <= endIntst; intst += 10, i++)
            {
                runIntst[i] = intst;

                _camera.IntstSet(0, intst);

                imageFilterDone.Reset();
                _camera.FilterImage(intst, 1);
                imageFilterDone.WaitOne();

                runImage[i] = ImgMat;

                result[i] = computeLightScoreDelegate.BeginInvoke(runImage[i], null, null);
            }

            for (int i = 0; i < intstNo; i++)
            {
                result[i].AsyncWaitHandle.WaitOne();
                variance[i] = computeLightScoreDelegate.EndInvoke(result[i]);
                result[i].AsyncWaitHandle.Close();
            }

            intstIdMax = intstIdMin = 0;
            maxVariance = minVariance = variance[0];
            for (int i = 0; i < intstNo; i++)
            {
                Console.WriteLine("variance[" + i + "]: " + variance[i] + ", intst: " + runIntst[i]);
                if (variance[i] > maxVariance)
                {
                    maxVariance = variance[i];
                    intstIdMax = i;
                }
                else if (variance[i] < minVariance)
                {
                    minVariance = variance[i];
                    intstIdMin = i;
                }
            }
            intstId = intstIdMax;

            //ColorHistShow((Mat)runImage[intstId]);

            for (int i = 0; i < intstNo; i++)
            {
                ((Mat)runImage[i]).Dispose();
            }

            _camera.IntstSet(0, runIntst[intstId]);
            if (mag_type == eMagType.MaxMag) _maxMagIntensity = runIntst[intstId];
            else _minMagIntensity = runIntst[intstId];

            Console.WriteLine("intst id: " + intstId + ", intst: " + runIntst[intstId] + ", variance: " + variance[intstId]);
        }
        private double ContrastVariance(Object image)
        {
            Mat mat = (Mat)image;
            double contrast;

            using (var yuv = new Mat())
            {
                Mat[] split = new Mat[3];

                Cv2.CvtColor(mat, yuv, ColorConversionCodes.BGR2YUV);
                Cv2.Split(yuv, out split);
                split[0].MinMaxIdx(out double min, out double max);
                Cv2.MeanStdDev(split[0], out var mean, out var stddev);
                contrast = stddev.Val0;
            }
            return contrast;
        }
        private void ColorHistShow(Mat image)
        {
            Mat[] planes;
            Mat[] hist;
            int[] channels = { 0 };
            int[] size = { 256 };
            Rangef[] range = { new Rangef(0.0F, 256.0F) };
            OpenCvSharp.Scalar[] color =
                new[] {
                    new OpenCvSharp.Scalar(255, 0, 0),
                    new OpenCvSharp.Scalar(0, 255, 0),
                    new OpenCvSharp.Scalar(0, 0, 255),
                };

            Cv2.Split(image, out planes);

            hist = new Mat[planes.Length];

            for (int i = 0; i < planes.Length; i++)
            {
                hist[i] = new Mat();
                Cv2.CalcHist(new Mat[] { planes[i] }, channels, null, OutputArray.Create(hist[i]), 1, size, range);
            }

            int hist_width = 512; int hist_height = 400;
            int bin_width = (int)Math.Round((double)hist_width / 256);

            Mat histImage = new Mat(hist_height, hist_width, MatType.CV_8UC3, new OpenCvSharp.Scalar(0, 0, 0));

            for (int i = 0; i < hist.Length; i++)
            {
                Cv2.Normalize(hist[i], hist[i], 0, histImage.Rows, NormTypes.MinMax, -1, null);
            }

            for (int i = 1; i < 256; i++)
            {
                for (int j = 0; j < color.Length; j++)
                {
                    Cv2.Line(histImage,
                             new OpenCvSharp.Point(bin_width * (i - 1), hist_height - (int)Math.Round(hist[j].At<float>(i - 1))),
                             new OpenCvSharp.Point(bin_width * (i), hist_height - (int)Math.Round(hist[j].At<float>(i))),
                             color[j], 2, LineTypes.Link8, 0);
                }
            }

            for (int i = 0; i < planes.Length; i++)
            {
                planes[i].Dispose();
            }

            for (int i = 0; i < hist.Length; i++)
            {
                hist[i].Dispose();
            }

            Cv2.NamedWindow("Color Histogram", WindowFlags.AutoSize);
            Cv2.ImShow("Color Histogram", histImage);
        }
        #endregion
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
            MoveEventArgs moveEventArgs = new MoveEventArgs('X', -Constants.MeasureScanBuffer, Constants.MeasureScanVelocity, true);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
            _log.Debug("AsyncMove5um 1st Wait over");
            moveEventArgs = new MoveEventArgs('X', measureDistance + Constants.MeasureScanBuffer, Constants.MeasureScanVelocity, true);
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
            MoveEventArgs moveEventArgs = new MoveEventArgs('X', -Constants.MeasureScanBuffer, Constants.MeasureScanVelocity, true);
            AsyncMove(this, moveEventArgs);
            AsyncMoveWait();
            _log.Debug("AsyncMove1um to begin pos");
            for (int i = 0; i < 5; i++)
            {
                moveEventArgs = new MoveEventArgs('X', move_x[i],Constants.MeasureScanVelocity, true);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                _log.Debug("AsyncMove1um finish line "+i.ToString());
                if (i < 4)
                {
                    moveEventArgs = new MoveEventArgs('Y', 1, Constants.MeasureScanVelocity, true);
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
            char[] axisZ = { 'Z' };
            char[] axisXY = { 'X', 'Y' };
            char[] axisXYZ = { 'X', 'Y', 'Z' };
            double[] CLStoBaslerDistance = { -40200 };
           
            
            try
            {
                MoveEventArgs moveEventArgs;
                moveEventArgs = new MoveEventArgs(axisZ, CLStoBaslerDistance, _motion.GetAxisDefaultSpeed(axisZ), false);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                for (int i = 0; i < pos.Count; i++)
                {                   
                    ScanFileName = pathname[i];
                    ScanFileIndex = i;
                    _log.Debug("MeasureScan filename:"+ ScanFileName);
                    double[] distance = { pos[i].X, pos[i].Y };
                    moveEventArgs = new MoveEventArgs(axisXY, distance,_motion.GetAxisDefaultSpeed(axisXY), false);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();
                    _camera.SaveImage(pathname + ".bmp");
                    double[] relative2Measure = { _paraReader.RelToMeasureCameraX
                                        , _paraReader.RelToMeasureCameraY};//放外面relative2Measure經過一次for loop會*10倍
                    moveEventArgs = new MoveEventArgs(axisXY, relative2Measure, _motion.GetAxisDefaultSpeed(axisXY), true);
                    AsyncMove(this, moveEventArgs);
                    AsyncMoveWait();
                    moveEventArgs = new MoveEventArgs('X', _paraReader.RelToMeasureCameraX, _motion.GetAxisDefaultSpeed('X'), true);
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
        public List<PointF> TransformDiePos(int die_row, int die_col, List<System.Drawing.Point> pts)
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
                ToMagPos(eMagType.MinMag);
                char[] axis = { 'X', 'Y' };
                double[] center = GetCenter();
                MoveEventArgs moveEventArgs = new MoveEventArgs(axis, GetCenter(), false);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                FindAngle(mymap, die_size, threshold);
                if (!FindAngleOK) return;
                moveEventArgs = new MoveEventArgs('R', _fs.AngleAverage * 1000, true);
                AsyncMove(this, moveEventArgs);
                AsyncMoveWait();
                ToMagPos(eMagType.MaxMag);
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
            MoveEventArgs moveEventArgs = new MoveEventArgs(axis, distance,_motion.GetAxisDefaultSpeed(axis), false);
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
        #endregion
    }
    public class MoveEventArgs : EventArgs
    {
        public MoveEventArgs(char[] axis, double[] position, bool isRelative)
        {
            Relative = isRelative;
            Position = position;
            Axis = axis;
            Velocity = Constants.MoveVelocity;
        }
        public MoveEventArgs(char[] axis, double[] position,double[] velocity, bool isRelative)
        {
            Relative = isRelative;
            Position = position;
            Axis = axis;
            Velocity = velocity;
        }
        public MoveEventArgs(char axis, double position, bool isRelative)
        {
            Relative = isRelative;
            double[] pos = { position };
            char[] a = { axis };
            Position = pos;
            Axis = a;
            Velocity = Constants.MoveVelocity;
        }
        public MoveEventArgs(char axis, double position,double velocity, bool isRelative)
        {
            Relative = isRelative;
            double[] pos = { position };
            char[] a = { axis };
            double[] vel = { velocity};
            Position = pos;
            Axis = a;
            Velocity = vel;
        }
        public bool Relative { get; set; }
        public double[] Position { get; set; }
        public char[] Axis { get; set; }
        public double[] Velocity { get; set; }
    }
}
