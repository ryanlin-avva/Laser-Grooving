using Avva.CameraFramework;
using Avva.MotionFramework;
using HalconDotNet;
using System;
using System.IO;

namespace Velociraptor
{
    class SynOperation
    {
        private AvvaMotion _motion;
        private HalconProc _hp;
        private ParamReader _paraReader;
        private double[] _2_mea = new double[3];
        private int _scan_mode;
        private AvvaCamera _camera;
        public SynOperation(HalconProc hp, AvvaCamera camera, string para_path, log4net.ILog log = null)
        {
            _hp = hp;
            _camera = camera;
            IAvvaMotion yaskawa = new YaskawaMotion();
            string path = Path.Combine(para_path, Constants.motionParaFilename);
            _motion = new AvvaMotion(yaskawa, path, log);
            path = Path.Combine(para_path, Constants.paraFilename);
            _paraReader = new ParamReader(path);
            _scan_mode = _paraReader.ScanningMode;
        }
        public void MotorOn() { _motion.MotorOn(); }
        public void MotorOff() { _motion.MotorOff(); }
        public void GoHome() { _motion.GoHome(); }
        public void StopMove() { _motion.StopMove(); }
        public void ClearAlarm() { _motion.ClearAlarm(); }
        public int ScanMode() { return _scan_mode; }
        public bool IsSimulat() { return _motion.IsSimulate; }
        public void AutoFocus()
        {

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
        
        public void MoveTo(char axis_char, double distance, bool isRelative = true)
        {
            _motion.MoveTo(axis_char, distance, isRelative);
        }
        //Default use relative move
        //If use absolute move, ONLY SPECIFIED AXIS ARE SET TO ABS
        public void MoveTo(char[] axis_char, double[] distance, bool isRelative)
        {
            _motion.MoveTo(axis_char, distance, isRelative);
        }
        public int GetPos(char axis_char)
        {
            return (int)_motion.GetPos(axis_char);
        }
        public void MoveToMeasurePos()
        {
            char[] axes = { 'X', 'Y', 'Z' };
            MoveTo(axes, _2_mea, true);
        }
        public void Move5um(int measureDistance)
        {
            MoveTo('X', -100);
            MoveTo('X', measureDistance + 100, true);
        }
        public void Move1um(int measureDistance)
        {
            double[] move_x = { measureDistance+200, -measureDistance-200 , measureDistance+200
                            , -measureDistance-200  , measureDistance+100 };
            MoveTo('X', -100);
            for (int i = 0; i < 5; i++)
            {
                _motion.MoveTo('X', move_x[i]);
                if (i < 4)
                    _motion.MoveTo('Y', 1);
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
            char[] axis = { 'X', 'Y' };
            double[] distance = { _paraReader.moveToWaferCenterPointXDistance
                                , _paraReader.moveToWaferCenterPointYDistance };
            _motion.MoveTo(axis, distance, false);
        }
        public void GetCenterPos(double[] distance)
        {
            distance[0] = _paraReader.moveToWaferCenterPointXDistance;
            distance[1] = _paraReader.moveToWaferCenterPointYDistance;
            distance[2] = 0;
        }
        public void GetLoadPos(ref double[] distance)
        {
            distance[0] = _paraReader.moveToWaferCenterPointXDistance;
            distance[1] = _paraReader.moveToWaferUnloadPointYDistance;
            distance[2] = 0;
        }
    }
}
