
using System;
using System.Collections.Generic;
using System.Linq;

namespace Velociraptor
{
    class Grouper
    {
        private List<MyLine> lines;
        public double Coor;
        public double Theta;
        public double LengthSquare;
        public int SequenceNo = 0;
        public int Belong_to_line;
        public bool IsSelect = false;
        private int _concate_allowance = Constants.CONCAT_ALLOWANCE;
        private double expected_coor;
        private double coor_diff;
        private int selected_line_idx = 0;
        private double _theta_allowance = Constants.THETA_ALLOWANCE;
        public Grouper(int seq)
        {
            lines = new List<MyLine>();
            SequenceNo = seq;
        }

        public int LinesContained()
        {
            return lines.Count;
        }
        public MyLine SelectedLine()
        {
            return lines[selected_line_idx];
        }

        public double SetSelectedGroup(int res_idx, double pos)
        {
            IsSelect = true;
            Belong_to_line = res_idx;
            expected_coor = pos;
            coor_diff = Math.Abs(expected_coor - Coor);
            return coor_diff;
        }
        
        public double GetDiff2ExpectPos()
        {
            return coor_diff;
        }

        public double SetExpectGroupCoor(double pos)
        {
            expected_coor = pos;
            coor_diff = Math.Abs(expected_coor - Coor);
            return coor_diff;
        }

        //將位置相近的線條放入同一group
        //如果有很接近的線條，直接合併
        public bool Add(MyLine line, bool check_number = false)
        {
            //如果相近位置的線條超過數量上限，直接回傳失敗
            //表示原始影像的處理太瑣碎了
            if (check_number && lines.Count >= Constants.MAX_GROUP_NUM) return false;
            if (lines.Count > 0) //已經有相近線段了
            {
                //如果有上下兩條可以相連，先接在一起
                //如果有幾乎貼在一起的，也可以先合併
                //否則就新增一條線段
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].MergeLine(line, _concate_allowance, _theta_allowance)) break;
                }
                AverageProperty();
            }
            else
            {
                Coor = line.GetComparePropAvg();
                Theta = line.GetTheta();
                LengthSquare = line.Length_Square();
            }
            lines.Add(line);
            return true;
        }

        //從group中選擇最適合的線段回傳
        //分數= 最大長度者得weight[0]分
        //    + 與指定夾角最接近者得weight[1]分
        //    + 與預期位置最接近者得weight[2]分
        public void Select(double selected_theta, int[] weight)
        {
            int cnt = lines.Count;
            if (cnt == 1)
            {
                selected_line_idx = 0;
                return;
            }
            //根據長度、角度、和與預期位置的距離來給分
            //先找出符合最大長度、最接近標竿角度、和最接近預期位置的值
            double max_len = 0;
            double min_theta = Math.PI / 4.0;
            List<double> theta_diff = new List<double>();
            double min_pos = expected_coor;
            List<double> pos_diff = new List<double>();
            for (int i=0; i<cnt; i++)
            {
                if (lines[i].Length_Square() > max_len) max_len = lines[i].Length_Square();
                theta_diff.Add(Math.Abs(lines[i].GetTheta() - selected_theta));
                if (theta_diff[i] < min_theta) min_theta = theta_diff[i];
                pos_diff.Add(Math.Abs(lines[i].GetComparePropAvg() - expected_coor));
                if (pos_diff[i] < min_pos) min_pos = pos_diff[i];
            }
            int[] score = new int[cnt];
            int max_score = 0;           
            //選擇最高分者
            //目前未處理同分情況，只取最先找到者
            for (int i = 0; i < cnt; i++)
            {
                if (lines[i].Length_Square() >= max_len) score[i] += weight[0];
                if (theta_diff[i] <= min_theta) score[i] += weight[1];
                if (pos_diff[i] <= min_pos) score[i] += weight[2];
                if (score[i] > max_score)
                {
                    max_score = score[i];
                    selected_line_idx = i;
                }
            }
        }

        private void AverageProperty()
        {
            double sum_theta = 0;
            double sum_coor = 0;
            double sum_len = 0;
            for (int i=0; i<lines.Count; i++)
            {
                sum_theta += lines[i].GetTheta();
                sum_coor += lines[i].GetCompareProp(0);
                sum_len += lines[i].Length_Square();
            }
            Theta = sum_theta / lines.Count;
            Coor = sum_coor / lines.Count;
            LengthSquare = sum_len / lines.Count;
        }

        public override string ToString()
        {
            string str="Group " + SequenceNo.ToString() + " \n";
            foreach(var line in lines)
            {
                str += line.ToString() + "\n";
            }
            return str;
        }
    }
}
