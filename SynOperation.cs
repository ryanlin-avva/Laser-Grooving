using Avva.CameraFramework;
using Avva.MotionFramework;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Velociraptor
{
    class SynOperation
    {
        private AvvaMotion _motion;
        private HalconProc _hp;
        private ParamReader _paraReader;
        private double[] _2_mea = new double[3];
        private bool hasGoHome = false;
       public SynOperation(HalconProc hp, string para_path, log4net.ILog log = null)
        {
            _hp = hp;
            IAvvaMotion yaskawa = new YaskawaMotion();
            string path = Path.Combine(para_path, Constants.motionParaFilename);
            _motion = new AvvaMotion(yaskawa, path, log);
            path = Path.Combine(para_path, Constants.paraFilename);
            _paraReader = new ParamReader(path);
        }
        public void MotorOn() { _motion.MotorOn(); }
        public void MotorOff() { _motion.MotorOff(); }
        public void GoHome() { _motion.GoHome(); }
        public void StopMove() { _motion.StopMove(); }
        public void ClearAlarm() { _motion.ClearAlarm(); }
        public bool IsSimulat { get { return _motion.IsSimulate; } }
        public int DataDirection { get { return _paraReader.DataDirection; } }
        public int TriggerInterval { get { return _paraReader.TriggerInterval; } }
        public string SavingPath { get { return _paraReader.SavingPath; } }
        public int MaxMagAutoFocusBegin { get { return _paraReader.MaxMagAutoFocusBegin; } }
        public int MaxMagAutoFocusEnd { get { return _paraReader.MaxMagAutoFocusEnd; } }
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
        public void AsyncMoveTo(char axis_char, double distance, bool isRelative = true)
        {
            _motion.AsyncMoveTo(axis_char, distance, isRelative);
        }
        public void AsyncMoveTo(char[] axis_char, double[] distance, bool isRelative)
        {
            _motion.AsyncMoveTo(axis_char, distance, isRelative);
        }

        public void MoveTo(char axis_char, double distance, bool isRelative = true)
        {
            _motion.MoveTo(axis_char, distance, isRelative);
        }
        public void MoveTo(char[] axis_char, double[] distance, bool isRelative)
        {
            _motion.MoveTo(axis_char, distance, isRelative);
        }
        public double GetPos(char axis_char)
        {
            return _motion.GetPos(axis_char);
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
            char[] axis = { 'X', 'Y', 'R' };
            double[] distance = { _paraReader.MoveToWaferCenterPointXDistance
                                , _paraReader.MoveToWaferCenterPointYDistance
                                 ,_paraReader.MoveToWaferCenterPointRDistance};
            if (!hasGoHome) GoHome();
            _motion.MoveTo(axis, distance, false);
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
            MoveTo(axis, distance, false);
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
}
