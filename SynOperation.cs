using HalconDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velociraptor
{
    class SynOperation
    {
        public string Err_msg="";
        private Motions _motion;
        private HalconProc _hp;
        public SynOperation(Motions m, HalconProc hp)
        {
            _motion = m;
            _hp = hp;
        }
        public bool DoAlignment(HObject cur_img, int threshold, ref double[] die_side)
        {
            double angle = 0;
            if (!find_angle(cur_img, threshold, ref die_side, ref angle)) return false;
            if (!_motion.MoveTo('R', (int)(angle*1000.0)))
            {
                Err_msg = "轉正失敗：請重新調整焦距或切割道閥值\n" + _motion.GetErrorMsg();
                return false;
            }
            return true;
        }
        public bool find_angle(HObject cur_img, int threshold, ref double[] die_side, ref double angle)
        {
            if (die_side[0] == 0 || die_side[1] == 0)
            {
                Err_msg = "Die Size is required";
                return false;
            }
            HObject gray_img = null;
            _hp.PrepareGrayImage(cur_img, out gray_img);
            if (gray_img == null)
            {
                Err_msg = "No Gray Image Generated";
                return false;
            }
            int[] side_int = new int[die_side.Length];
            for (int i = 0; i < die_side.Length; i++)
                side_int[i] = (int)die_side[i];
            GridBuilder grid = new GridBuilder(gray_img, side_int
                                    , Constants.SCRIBE_IS_DARK
                                    , threshold, _hp);
            if (!grid.DoLineSegment(_hp))
            {
                Err_msg = grid.ErrMsg;
                return false;
            }
            //hp.DrawGrid(cur_img, grid.Getlines(0), grid.Getlines(1));
            _hp.DrawGrid(null, grid.Getlines(0), grid.Getlines(1));
            die_side[0] = grid.EstimatedWidth();
            die_side[1] = grid.EstimatedHeight();
            angle = grid.EstimatedThetaByDegree();
            return true;
        }
    }
}
