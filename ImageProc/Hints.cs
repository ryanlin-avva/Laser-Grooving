using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Velociraptor
{
    class Hints
    {
        private List<MyPair> p_list = new List<MyPair>();
        private int _side;
        public int Count()
        {
            return p_list.Count;
        }
        
        public bool Create(List<double> projections, bool is_dark
                         , int side, int _line_width)
        {
            double min = projections.Min();
            double max = projections.Max();

            double bound = (is_dark) ? min : max;
            double avg = (min + max) / 2;
            double tolerance = Math.Abs(avg - bound) / Constants.HINT_TOLERNCE;
            double lower = (is_dark) ? bound : bound - tolerance;
            double upper = (is_dark) ? bound + tolerance : bound;
            int sign = (is_dark) ? 1 : -1;
            bool inLine = false;
            MyPair pair = new MyPair();
            int bound_idx = 0;
            int local_bound_idx = 0;
            double local_bound = 255 * sign;
            for (int j = 0; j < projections.Count; j++)
            {
                if (projections[j] == bound) bound_idx = j;
                if (MyUtil.InRange(projections[j], lower, upper))
                {
                    if (!inLine)
                    {
                        pair.SetPairS(j);
                        inLine = true;
                        local_bound_idx = j;
                        local_bound = projections[j] * sign;
                    }
                    else
                    {
                        if (projections[j] * sign < local_bound)
                        {
                            local_bound = projections[j] * sign;
                            local_bound_idx = j;
                        }
                    }
                }
                else
                {
                    if (inLine)
                    {
                        pair.SetPairE(j - 1);
                        pair.SetBoundPos(local_bound_idx);
                        MyAdd(pair);
                        pair = new MyPair();
                        inLine = false;
                    }
                }
            }
            //計算hint時，要輸入的邊長是與線段垂直的邊長
            //所以使用1-i
            //Debug.WriteLine("Hints before adjust: " + this.ToString());
            int cnt = p_list.Count;
            bool res = Adjust(side, _line_width, bound_idx, projections, sign);
            //Debug.WriteLine("hints: got " + cnt.ToString()
            //                + ", and adjust to " + p_list.Count.ToString());
            //Debug.WriteLine("after adjust: " + this.ToString());
            return res;
        }
        private bool Adjust(int side, int _line_width, int bound_idx
                            , List<double> projections, int sign)
        {
            _side = side;
            //切割道附近的灰階值可能會因為些微波動而形成幾個小的區間
            //合併太窄(<切割道寬度*3--預留防崩邊*2+切割道)
            //且與下一區段距離不到2個切割道寬度的區段
            int idx = 0;
            while (idx < p_list.Count)
            {
                //則進行合併
                while (p_list[idx].GetWidth() < _line_width*3
                    && idx < p_list.Count - 1
                    && (p_list[idx + 1].GetPairS() - p_list[idx].GetPairE())
                        < _line_width*2)
                {
                    int cur_bound = p_list[idx].GetBoundPos();
                    int next_bound = p_list[idx + 1].GetBoundPos();
                    p_list[idx].SetPairE(p_list[idx + 1].GetPairE());
                    if ((projections[next_bound] - projections[cur_bound]) * sign < 0)
                        p_list[idx].SetBoundPos(next_bound);
                    p_list.RemoveAt(idx + 1);
                }
                idx++;
            }
            if (p_list.Count == 0) return false;
            if (p_list.Count == 1) return true;

            int benchmarker = (int)Math.Ceiling((double)bound_idx / _side) - 1;
            int pos = bound_idx - benchmarker * side;

            int range = _line_width / 2;
            idx = 0;
            int inferred_number = 0;
            while (idx < p_list.Count)
            {
                if (idx > 0 && pos < p_list[idx].GetPairS()) 
                    pos += side;
                //如果合併後的距離仍小於切割道
                //為了降低誤差
                //先擴充至切割道大小
                if (p_list[idx].GetWidth() < _line_width)
                {
                    int b = p_list[idx].GetBoundPos();
                    int m = b - _line_width;
                    if (m < p_list[idx].GetPairS()) p_list[idx].SetPairS(m);
                    m = b + _line_width;
                    if (m > p_list[idx].GetPairE()) p_list[idx].SetPairE(m);
                }
                //在該組範圍中找不到對應的pos
                if (!MyUtil.InRange(pos, p_list[idx].GetPairS(), p_list[idx].GetPairE()))
                {
                    if (idx < p_list.Count - 1)
                    {
                        //如果pos落於下一組之中
                        //則移除該組
                        if (MyUtil.InRange(pos, p_list[idx + 1].GetPairS(), p_list[idx + 1].GetPairE()))
                        {
                            p_list.RemoveAt(idx);
                            continue;
                        }
                        //該組沒有對應到推估位置，但對應到下一推估位置
                        //則在其前方新增一組參考值
                        else if (MyUtil.InRange(pos + side, p_list[idx].GetPairS(), p_list[idx].GetPairE()))
                        {
                            MyPair p = new MyPair(pos - _line_width, pos + _line_width, pos);
                            p.SetEstimated();
                            inferred_number++;
                            p_list.Insert(idx, p);
                            idx++;
                            pos += side;
                            continue;
                        }
                    }
                    //如果對應範圍小於切割道寬度
                    //擴充範圍再檢查一次
                    int bound_pos = p_list[idx].GetBoundPos();
                    if (!MyUtil.InRange(pos, bound_pos - _line_width, bound_pos + _line_width))
                    {
                        p_list.RemoveAt(idx);
                        continue;
                    }
                }

                //移除過大範圍
                //if (p_list[idx].GetWidth() > range)
                //{
                //    p_list[idx].SetPair(Math.Min(p_list[idx].GetBoundPos(), pos) - _line_width
                //                    , Math.Max(p_list[idx].GetBoundPos(), pos) + _line_width);
                //}
                idx++;
            } //end while
            if (inferred_number > (p_list.Count / 2 + 1)) return false;
            else return true;
        }
        private void MyAdd(MyPair p)
        {
            p_list.Add(p);
        }
        //找出num落入那一段區間
        //並且回傳該區間編號
        //失敗則回傳-1
        public int Has(int num)
        {
            int idx = Math.Max(num / _side - 1, 0);
            int limit = Math.Min(idx + 3, p_list.Count);
            for (int i = idx; i < limit; i++)
                if (MyUtil.InRange(num, p_list[i].GetPairS(), p_list[i].GetPairE())) 
                    return i;
            return -1;
        }
        public int GetBenchmarkPos(int i)
        {
            return p_list[i].GetBoundPos();
        }
        public override string ToString()
        {
            string str = "";
            for (int i=0; i<p_list.Count; i++)
            {
                str += p_list[i].ToString() + ",";
            }
            return str;
        }
    }
}
