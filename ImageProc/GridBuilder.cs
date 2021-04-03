
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Velociraptor
{
    class GridBuilder
    {
        private GMList[] grouper_list = new GMList[2];
        private HObject my_img;
        private HalconProc hp;
        private int[] line_num = { 0, 0 };
        private int[] die_side;
        private bool is_dark;
        private Hints[] hints = new Hints[2];
        private Tuner tuner;
        private double fit_theta;
        private double[] fit_side = { 0, 0 };
        public string ErrMsg { get; set; }
        public GridBuilder(HObject img, int[] die_side
                            , bool isDark, int th, HalconProc halcon_proc)
        {
            my_img = img;
            hp = halcon_proc;
            this.die_side = die_side;
            this.is_dark = isDark;
            int[] img_side;
            hp.GetImageSize(img, out img_side);
            tuner = new Tuner(line_num, die_side, img_side, isDark, th);
            for (int i=0; i<2; i++)
            {
                hints[i] = new Hints();
                grouper_list[i] = new GMList();
            }
        }
        public bool DoLineSegment(HalconProc hp)
        {
            List<double>[] projections;
            hp.GrayProjection(my_img, out projections);
            CreateHints(projections);
            int trycnt = 0;
            bool found = false;
            while (true)
            {
                //Debug.WriteLine("*************SegmentLines**** " + trycnt.ToString()
                //                + ":" + tuner.GetCurParam().ToString());
                List<MyLine> keeper = new List<MyLine>();
                hp.SegmentLines(my_img, tuner.GetCurParam(), ref keeper);
                int[] ori_cnt = new int[2]; //segmentLines找到的線段總數-應有數量
                if (trycnt > Constants.IMAGE_PROC_MAX_COUNT)
                {
                    FilterLinesByContours(keeper, ref ori_cnt);
                }
                else
                {
                    FilterLines(keeper, ref ori_cnt);
                }
                int[] diff = new int[2]; //經過grouper之後找到的線段總數-應有數量或錯誤代碼
                if (FindMostSuitable(ref diff))
                {
                    found = true;
                    //Debug.WriteLine("Lines found: Ori_cnt= " + ori_cnt[0].ToString() + ", " + ori_cnt[1].ToString()
                    //    + " diff= " + diff[0].ToString() + ", " + diff[1].ToString());
                    break;
                }
                //Debug.WriteLine("Move to next try: Ori_cnt= " + ori_cnt[0].ToString() + ", " + ori_cnt[1].ToString()
                //   + " diff= " + diff[0].ToString() + ", " + diff[1].ToString());
                //或許是因為所需的線段本身因為長度問題被剔除了
                //最後再縮短select的長度試試看
                if (trycnt == Constants.IMAGE_PROC_MAX_COUNT)
                {
                    tuner.GenShrinkedData();
                    trycnt++;
                    continue;
                }
                else if (trycnt > Constants.IMAGE_PROC_MAX_COUNT)
                {
                    break;
                }
                tuner.GenNextRoundData(diff, ori_cnt);
                trycnt++;
            }                
       
            double[] end_px = new double[4];
            double[] end_py = new double[4];

            SelectRectPoints(end_px, end_py);
            hp.FindSmallestRect(my_img, end_px, end_py, ref fit_side, ref fit_theta);
            if (!found) 
                ErrMsg = "Auto Retry failed! Adjust your Image parameters";
            return found;
        }
        public List<MyLine> Getlines(int idx)
        {
            return grouper_list[idx].GetFilteredList();
        }
        public double EstimatedHeight()
        {
            return fit_side[1];
            //return grouper_list[Constants.WAY_HORIZONTAL].GetEstimatedLength();
        }
        public double EstimatedWidth()
        {
            return fit_side[0];
            //return grouper_list[Constants.WAY_VERTICAL].GetEstimatedLength();
        }
        //(Horizontal+Vertical)/2/pi*180=(H+V)*90/pi
        public double EstimatedThetaByDegree()
        {
            /*
            double degree = (grouper_list[0].GetEstimatedTheta() + grouper_list[1].GetEstimatedTheta()) * 90 / Math.PI;

            Debug.WriteLine(grouper_list[0].GetEstimatedTheta().ToString()
                            + "," + grouper_list[1].GetEstimatedTheta().ToString()
                            + "," + degree.ToString());
            return (grouper_list[0].GetEstimatedTheta() + grouper_list[1].GetEstimatedTheta()) 
                    * 90 / Math.PI;
             */
            return fit_theta * 180 / Math.PI;
        }
        private void SelectRectPoints(double[] end_px, double[] end_py)
        {
            int[] img_side;
            hp.GetImageSize(my_img, out img_side);
            MyLine upper_line = new MyLine();
            MyLine lower_line = new MyLine(); 
            MyLine left_line = new MyLine(); 
            MyLine right_line = new MyLine();
            //形成矩形
            int h = grouper_list[0].GetRectSide(ref upper_line, ref lower_line);
            if (h == 0)
            {
                double[] x = { 0, img_side[0] - 1 };
                double[] y = { 0, 0 };
                upper_line = new MyLine(x, y);
                y[0] = img_side[1] - 1; y[1] = img_side[1] - 1;
                lower_line = new MyLine(x, y);
            } 
            int v = grouper_list[1].GetRectSide(ref left_line, ref right_line);
            if (v == 0)
            {
                double[] x = { 0, 0 };
                double[] y = { 0, img_side[1] - 1 };
                left_line = new MyLine(x, y);
                x[0] = img_side[0] - 1; x[1] = img_side[0] - 1;
                right_line = new MyLine(x, y);
            }

            PointF pt, pt1;
            MyLine temp = upper_line;
            //選擇較長的那段來做smallest_rectangle
            //做出來的角度應該會比較準
            if (h == 1 && v > 0)
            {
                upper_line.GetIntersectPoint(left_line, out pt1);
                if (pt1.Y > (img_side[1]-pt1.Y))
                {
                    upper_line = lower_line.ShiftLine(true, 0);
                    temp = lower_line; //用來記錄真正的列位置
                }
                else
                    lower_line = upper_line.ShiftLine(false, img_side[1] - 1);
            }
            if (v == 1 && h > 0)
            {
                left_line.GetIntersectPoint(temp, out pt1);
                if (pt1.X > (img_side[0]-pt1.X))
                    left_line = right_line.ShiftLine(true, 0);
                else
                    right_line = left_line.ShiftLine(false, img_side[0] - 1);
            }
            List<double> ptx = new List<double>();
            List<double> pty = new List<double>();
            upper_line.GetIntersectPoint(right_line, out pt1);
            end_px[0] = pt1.X; end_py[0] = pt1.Y;
            right_line.GetIntersectPoint(lower_line, out pt);
            end_px[1] = pt.X; end_py[1] = pt.Y;
            lower_line.GetIntersectPoint(left_line, out pt);
            end_px[2] = pt.X; end_py[2] = pt.Y;
            left_line.GetIntersectPoint(upper_line, out pt);
            end_px[3] = pt.X; end_py[3] = pt.Y;
        }
        private bool FindMostSuitable(ref int[]diff)
        {
            for (int i = 0; i < 2; i++)
            {
                diff[i] = grouper_list[i].FindMostSuitable();
            }
            //如果兩者都曾經出現過符合數目的線段
            if (diff[0] == 0 && diff[1] == 0) return true;
            else return false;
        }
        private bool CreateHints(List<double>[] projections)
        {
            bool res = true;
            for (int i = 0; i < 2; i++)
            {
                if (res)
                    res = hints[i].Create(projections[i], is_dark, die_side[1 - i], die_side[2]);
                line_num[i] = hints[i].Count();
            }
            return res;
        }
        private void FilterLinesByContours(List<MyLine> lines, ref int[] ori_cnt, bool use_hints = true)
        {
            FilterLines(lines, ref ori_cnt, false);
        }

        //return negative if returned lines are less than pre-defined
        private void FilterLines(List<MyLine> lines, ref int[] ori_cnt, bool use_hints=true)
        {
            //將線段分為垂直/水平兩組
            List<MyLine>[] mylines = new List<MyLine>[2];
            mylines[0] = new List<MyLine>();
            mylines[1] = new List<MyLine>();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Wayward != -1) mylines[lines[i].Wayward].Add(lines[i]);
            }
            ori_cnt[0] = mylines[0].Count - line_num[0];
            ori_cnt[1] = mylines[1].Count - line_num[1];
            GrouperMgr[] grouper = new GrouperMgr[2];
            int[] img_side;
            hp.GetImageSize(my_img, out img_side);
            double[] compare_angles = { 0, Math.PI / 2 };
            for (int i = 0; i < 2; i++)
            {
                if (use_hints)
                {
                    grouper[i] = new GrouperMgr(die_side[i], line_num[i], i);
                    grouper[i].FilterLinesByHints(mylines[i], hints[i]);
                }
                else
                {
                    grouper[i] = new GrouperMgr(die_side[i]
                                        , img_side[i] / die_side[i] + 1, i);
                    grouper[i].FilterLinesByContours(mylines[i], die_side[2]
                                        , img_side[i], compare_angles[i]);
                }
            }
            //如果有一方找到對應線段
            //加上對應角度再嘗試一次
            double half_pi = Math.PI / 2;
            if (grouper[0].GetFilterResult() >= Constants.E_ERROR)
            {
                if (grouper[1].GetFilterResult() < Constants.E_ERROR)
                {
                    if (use_hints) grouper[0].FilterLinesByHints(mylines[0], hints[0]
                                                , grouper[1].Theta_estimate - half_pi);
                    else
                        grouper[0].FilterLinesByContours(mylines[0], die_side[2], img_side[0]
                                                , grouper[1].Theta_estimate - half_pi);
                }
            }
            else
            {
                if (grouper[1].GetFilterResult() >= Constants.E_ERROR)
                {
                    if (use_hints) grouper[1].FilterLinesByHints(mylines[1], hints[1]
                                                , grouper[0].Theta_estimate + half_pi);
                    else
                        grouper[1].FilterLinesByContours(mylines[1], die_side[2], img_side[1]
                                                , grouper[0].Theta_estimate + half_pi);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                //先計算線段數量誤差
                grouper[i].ComputeLineNumberDiff();
                grouper_list[i].Add(grouper[i]);
            }
        }
        public int GetLineNumber(int idx)
        {
            return line_num[idx];
        }
    }
}
