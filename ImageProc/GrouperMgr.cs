using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Velociraptor
{
    class GrouperMgr
    {
        public double Side_estimate = 0;
        public double Theta_estimate = 0;
        public double Pos_diff_avg;
        public int Line_num_diff;
        private List<Grouper> groupers;
        private List<MyLine> selected_lines;
        private int _best_chooser;
        private double _tolerance;
        private double _max_gap_deviation;
        private int _default_die_side;
        private int _line_number;
        public int _line_found;
        private int wayward;
        private string[] way_str = { "Horizontal", "Vertical" };
        private double[] way_theta = { 0, Math.PI / 2 };
        private int ori_line_num = 0;
        //private double _theta_stddev;

        public GrouperMgr(int side, int num, int way)
        {
            _line_number = num;
            _default_die_side = side;
            _max_gap_deviation = side * Constants.MAX_GAP_DEVIATION_RATE;
            _tolerance = Math.Min((double)side * Constants.GROUP_TOLERENCE_RATE, Constants.MAX_GROUP_TOLERENCE);
            wayward = way;
            selected_lines = new List<MyLine>();
            groupers = new List<Grouper>();
        }
        public int GetFilterResult()
        {
            return _line_found;
        }
        public void ComputeLineNumberDiff()
        {
            Line_num_diff = (_line_found>=Constants.E_ERROR) ?
                            _line_found : _line_found - _line_number;
        }
        public void FilterLinesByHints(List<MyLine> lines, Hints hints
                                      , double theta = double.NaN)
        {
            ori_line_num = lines.Count;
            _line_found = 0;
            if (lines.Count == 0) return;

            GroupLines(lines, hints, theta);

            int[] weight = { 1, 1, 3 };
            if (!double.IsNaN(theta))
            {
                Theta_estimate = theta;
                SelectLineInGroup(Theta_estimate, weight);
            }
            else
            {
                weight[1] = 0; //選線段時不考慮角度
                SelectLineInGroup(way_theta[wayward], weight);
                EstimateThetaByLine();
            }
            EstimateSide(hints);
            _line_found = selected_lines.Count;
        }

        public void FilterLinesByContours(List<MyLine> lines
                                        , double line_width
                                        , int img_side 
                                        , double theta=double.NaN)
        {
            ori_line_num = lines.Count;
            _line_found = 0;
            if (lines.Count == 0) return;
            if (!GroupLinesNoHints(lines, theta)) return;

            int[] weight = { 1, 1, 3 };

            //影像中只有一條線段
            if (groupers.Count == 1)
            {
                if (!double.IsNaN(theta))
                {
                    Theta_estimate = theta;
                    SelectLineInGroup(theta, weight);
                }
                else
                {
                    weight[1] = 0; //選線段時不考慮角度
                    SelectLineInGroup(way_theta[wayward], weight);
                }
                Theta_estimate = selected_lines[0].GetTheta();
                Side_estimate = _default_die_side;
                _line_found = 1;
                return;
            }

            //計算可能的間距與傾斜角度
            int target = SelectTarget(theta, img_side);


            if (double.IsNaN(theta))
                weight[1] = 0; //選線段時不考慮角度
            SelectLineInGroup(Theta_estimate, weight);
            //Debug.WriteLine("Estimated Length=" + Side_estimate.ToString()
            //                + ", Theta=" + Theta_estimate.ToString());
            _line_found = selected_lines.Count;
            return;
        }

        public List<MyLine> GetFilteredList()
        {
            return selected_lines;
        }

        //GroupLines將範圍內的線段放在同組
        //如果回傳false
        //表示相鄰範圍內的線段經過合併後超過MAX_GROUP_NUM條以上
        //表示臨界值設得太寬鬆，以至於背景太雜亂
        //或是過濾掉的不夠多
        //而過濾掉的不夠多，則可能是線段長度設得太短
        //所以周圍的雜訊都進來了
        //目前暫時只處理臨界值的情況
        //Second iteration:
        //輸入的角度不等於nan
        //重新用輸入的角度做grouping
        public bool GroupLinesNoHints(List<MyLine> lines, double angle)
        {
            groupers.Clear();

            if (!double.IsNaN(angle))
            {
                int i = 0;
                while (i < lines.Count)
                {
                    if (MyUtil.ThetaDiff(lines[i].GetTheta(), angle) > Constants.MAX_THETA_LIMIT)
                        lines.RemoveAt(i);
                    i++;
                }
            }
            if (lines.Count == 0) return true;

            //先做sort，否則add lines[0]可能會設到非開頭的線段
            lines.Sort();
            double coor = lines[0].GetComparePropAvg();
            Grouper g = new Grouper(0);
            g.Add(lines[0]);
            groupers.Add(g);
            int g_cnt = 1;
            for (int i = 1; i < lines.Count; i++)
            {
                double coor1 = lines[i].GetComparePropAvg();
                double d = coor1 - coor;
                //與前一條的距離不超過Die邊長*GROUP_TOLERENCE
                if (d <= _tolerance)
                {
                    //如果相鄰範圍內的線段經過合併仍超過MAX_GROUP_NUM
                    //表示臨界值設得太寬鬆，以至於背景太雜亂
                    //或是過濾掉的不夠多
                    //而過濾掉的不夠多，則可能是線段長度設得太短
                    //所以周圍的雜訊都進來了
                    if (!g.Add(lines[i]))
                    {
                        //Debug.WriteLine("In GroupLines(failed): " + this.ToString());
                        //Debug.WriteLine("GroupLines failed: with " + i.ToString()
                        //    + "th " + lines[i].ToString()
                        //    + " in " + g.ToString());
                        _line_found = Constants.E_NOISETOOMUCH;
                        return false;
                    }
                }
                else
                {
                    g = new Grouper(g_cnt++);
                    g.Add(lines[i]);
                    groupers.Add(g);
                }
                coor = coor1;
            }
            //Debug.WriteLine("In GroupLines(ok): " + this.ToString());
            _line_found = groupers.Count;
            return true;
        }


        private void GroupLines(List<MyLine>lines, Hints hints, double angle)
        {
            groupers.Clear();
            //如果有指定角度，先移除不符合的線段
            if (!double.IsNaN(angle))
            {
                int i = 0;
                while (i < lines.Count)
                {
                    if (Math.Abs(lines[i].GetTheta() - angle) > Constants.MAX_THETA_LIMIT)
                        lines.RemoveAt(i);
                    i++;
                }
            }
            if (lines.Count == 0) return;

            //先做sort，否則add lines[0]可能會設到非開頭的線段
            for (int i = 0; i < hints.Count(); i++)
            {
                Grouper g = new Grouper(i);
                groupers.Add(g);
            }
            for (int i = 0; i < lines.Count; i++)
            {
                int idx = hints.Has((int)lines[i].GetComparePropAvg());
                if (idx >= 0) groupers[idx].Add(lines[i]);
            }
        }

        private void EstimateThetaByLine()
        {
            if (selected_lines.Count <= 0) return;
            Theta_estimate = 0;
            foreach (var item in selected_lines)
                Theta_estimate += item.GetTheta();
            Theta_estimate /= selected_lines.Count;
        }

        //如果只有一條，則兩條回傳線段都設為同一條
        public void GetBestLines(ref MyLine line1, ref MyLine line2)
        {
            if (selected_lines.Count == 0) return;
            if (selected_lines.Count == 1)
            {
                line1 = selected_lines[0];
                line2 = selected_lines[0];
                return;
            }
            double theta1 = 3.14;
            double theta2 = 3.14;
            double theta = Math.Abs(selected_lines[_best_chooser].GetTheta());
            if (_best_chooser > 0)
                theta1 = Math.Abs(selected_lines[_best_chooser - 1].GetTheta())-theta;
            if (_best_chooser < selected_lines.Count - 1)
                theta2 = Math.Abs(selected_lines[_best_chooser + 1].GetTheta())-theta;
            if (Math.Abs(theta1) < Math.Abs(theta2))
            {
                line1 = selected_lines[_best_chooser - 1];
                line2 = selected_lines[_best_chooser];
            }
            else
            {
                line1 = selected_lines[_best_chooser];
                line2 = selected_lines[_best_chooser + 1];
            }
        }
        private void EstimateSide(Hints hints)
        {
            if (selected_lines.Count <= 0) return;
            Pos_diff_avg = selected_lines[0].GetCompareProp(0) - hints.GetBenchmarkPos(0);
            Side_estimate = 0;
            double min_diff = Pos_diff_avg;
            _best_chooser = 0;
            for (int i=1; i < selected_lines.Count; i++)
            {
                Side_estimate += selected_lines[i].GetCompareProp(0) - selected_lines[i - 1].GetCompareProp(0);
                double diff = selected_lines[i].GetCompareProp(0) - hints.GetBenchmarkPos(i);
                Pos_diff_avg += diff;
                if (diff < min_diff)
                {
                    min_diff = diff;
                    _best_chooser = i;
                }
            }
            if (selected_lines.Count > 1) Side_estimate /= (selected_lines.Count - 1);
            Pos_diff_avg /= selected_lines.Count;
        }

        private int SelectTarget(double angle, int img_side)
        {
            if (groupers.Count == 1)
            {
                Theta_estimate = groupers[0].Theta;
                Side_estimate = groupers[0].Coor;
                return 1;
            }

            //將邊長與組間距離相減
            //取最接近邊長的前chooser個item來算平均邊長
            List<LinePair> tuples = new List<LinePair>();
            double dist_limit = _tolerance * 2;
            for (int i=0; i < groupers.Count-1; i++)
            {
                for (int j=i+1; j < groupers.Count; j++)
                {
                    LinePair p = new LinePair(groupers[i], groupers[j], _default_die_side);
                    //兩者距離跟邊長的倍數相差太遠
                    if (p.Distance > dist_limit) continue;
                    //檢查gap，避開兩者屬於相同位置者
                    if (p.Gap > 0) tuples.Add(p);
                }
            }
            if (tuples.Count == 0) return Constants.E_TARGETNOTFOUND;

            tuples.Sort();
            //選擇最接近邊長的一對做為估計邊長
            int idx0 = tuples[0].Line_idx[0];
            int idx1 = tuples[0].Line_idx[1];
            Side_estimate = (groupers[idx1].Coor 
                            - groupers[idx0].Coor) 
                            / tuples[0].Gap;
            groupers[idx0].IsSelect = true;
            groupers[idx1].IsSelect = true;

            double pos;
            int idx = idx0 - 1;
            if (idx >= 0)
            {
                pos = groupers[idx0].Coor - Side_estimate;
                while (pos + _tolerance > 0 && idx >= 0)
                {
                    double min_len = Side_estimate;
                    int min_idx = -1;
                    double cur_len = Math.Abs(groupers[idx].Coor - pos);
                    while (cur_len < dist_limit)
                    {
                        if (cur_len < min_len)
                        {
                            min_idx = idx;
                            min_len = cur_len;
                        }
                        idx--;
                        if (idx < 0) break;
                        cur_len = Math.Abs(groupers[idx].Coor - pos);
                    }
                    if (min_idx >= 0)
                    {
                        groupers[min_idx].IsSelect = true;
                        pos = groupers[min_idx].Coor - Side_estimate;
                    }
                    else
                        pos -= Side_estimate;
                }
            }

            //往後搜尋合法解中最接近的值
            idx = idx1 + 1;
            if (idx < groupers.Count)
            {
                pos = groupers[idx1].Coor + Side_estimate;
                while (pos - _tolerance < img_side && idx < groupers.Count)
                {
                    double min_len = Side_estimate;
                    int min_idx = -1;
                    double cur_len = Math.Abs(groupers[idx].Coor - pos);
                    while (cur_len < dist_limit)
                    {
                        if (cur_len < min_len)
                        {
                            min_idx = idx;
                            min_len = cur_len;
                        }
                        idx++;
                        if (idx == groupers.Count) break;
                        cur_len = Math.Abs(groupers[idx].Coor - pos);
                    }
                    if (min_idx >= 0)
                    {
                        groupers[min_idx].IsSelect = true;
                        pos = groupers[min_idx].Coor + Side_estimate;
                    }
                    else
                        pos += Side_estimate;
                }
            }

            for (int i = groupers.Count - 1; i >= 0; i--)
            {
                if (!groupers[i].IsSelect) groupers.RemoveAt(i);
            }
            return groupers.Count;
        }

        private void SelectLineInGroup(double theta, int [] weight)
        {
            int idx = 0;
            while (idx < groupers.Count)
            {
                if (groupers[idx].LinesContained() == 0)
                {
                    groupers.RemoveAt(idx);
                    continue;
                }
                groupers[idx].Select(theta, weight);
                selected_lines.Add(groupers[idx].SelectedLine());
                idx++;
            }
            /*
            Debug.WriteLine("Selected lines in Group:");
            foreach (var line in selected_lines)
            {
                Debug.WriteLine(line.ToString());
            }
            */
        }

        public override string ToString()
        {
            string str = "=== " + way_str[wayward] + " Group Lines === " + selected_lines.Count.ToString() + " \n";
            foreach (var g in groupers)
            {
                str += g.ToString();
            }
            return str;
        }
    }
}
