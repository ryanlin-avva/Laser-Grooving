using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Velociraptor
{
    class Tuner
    {
        private List<TuningData> param_list;
        private TuningData cur_data;
        public Tuner(int[] line_num, int[] die_side, int[] img_side
                    ,bool isDark, int th
                    , int maxDist = Constants.COLINE_MAX_DIST
                    , double angle = Constants.COLINE_ANGLE)
        {
            //考慮到交界處的skeleton可能比較混亂
            //目前SelectContourMinLength最小長度先暫且設為die高度*0.9
            //最大長度則不需特別限制
            //此參數目前尚未用於auto-tuning中
            //有可能是大die，所以必須考慮影像size
            int min_side = Math.Min(Math.Min(die_side[0], die_side[1])
                                  , Math.Min(img_side[0], img_side[1]));
            cur_data = new TuningData(th, maxDist, angle, isDark, min_side);
            param_list = new List<TuningData>();
        }
        public TuningData GetCurParam()
        {
            return cur_data;
        }
        public bool GenNextRoundData(int[] diff, int[] ori_cnt)
        {
            TuningData data = new TuningData(cur_data);
            if (diff[Constants.WAY_HORIZONTAL] == 0) //horizontal
            {                
                if (diff[Constants.WAY_VERTICAL] == 0) return true;
                else GenSingleWayData(Constants.WAY_VERTICAL, diff[Constants.WAY_VERTICAL]
                                        , ori_cnt[Constants.WAY_VERTICAL], ref data);
            }
            else
            {
                if (diff[Constants.WAY_VERTICAL] == 0) 
                    GenSingleWayData(Constants.WAY_HORIZONTAL, diff[Constants.WAY_HORIZONTAL]
                                        , ori_cnt[Constants.WAY_HORIZONTAL], ref data);
                else GenTwoWayData(diff, ori_cnt, ref data);
            }
            param_list.Add(cur_data);
            cur_data = data;
            return false;
        }

        //或許是因為所需的線段本身因為長度問題被剔除了
        //縮短select的長度試試看
        public void GenShrinkedData()
        {
            TuningData data = new TuningData(param_list[0]);
            data.ShrinkLength();
            cur_data = data;
        }
        private void ScaleThreshold(bool to_shrink, ref TuningData data)
        {
            for (int i = param_list.Count - 1; i >= 0; i--)
            {
                if ((to_shrink && param_list[i] < cur_data)
                    || (!to_shrink && param_list[i] > cur_data))
                {
                    int new_th = (param_list[i].Threshold() + data.Threshold()) / 2;
                    //如果重算的閥值已經使用過，則直接用找到的值(符合變化方向)做變化
                    if (param_list.Exists(x => x.Threshold() == new_th))
                    {
                        data.SetThreshold(param_list[i].Threshold());
                        data.Scale(to_shrink);
                    }
                    else
                        data.SetThreshold(new_th);
                    return;
                }
            }
            data.Scale(to_shrink);
        }
        private void GenSingleWayData(int idx, int diff, int ori_cnt, ref TuningData data)
        {
            //長度最接近邊長的前半數組別與其左方組別中
            //找不到兩者角度差都落在THETA_ALLOWANCE範圍內的組別
            //縮小collinear的max_dist或angle
            if (diff == Constants.E_TARGETNOTFOUND)
            {
                data.CollinearAngle *= 0.95;
                data.CollinearDistance = (int)(data.CollinearDistance * 0.8);
                return;
            }

            //運用另一組推估角度搜尋符合線條失敗
            //或是找到的線段總數小於預期數目
            //放寬threshold範圍
            //情況一還可以考慮增加collinear的max_dist (目前未使用)
            if (diff == Constants.E_INFERREDLINEFAIL || ori_cnt < 0)
            {
                ScaleThreshold(false, ref data);
                return;
            }

            //超過可容許群組數量後的回傳值(E_NOISETOOMUCH)
            //或是找到的線段總數大於預期數目(diff > 0)
            //目前處理方式：縮減threshold的容許範圍
            ScaleThreshold(true, ref data);
        }
        private void GenTwoWayData(int[] diff, int[] ori_cnt, ref TuningData data)
        {
            //找到的水平與垂直線段總數都小於預期數目
            if (ori_cnt[0]<0 && ori_cnt[1]<0)
            {
                ScaleThreshold(false, ref data);
                return;
            }

            //找到的水平與垂直線段總數都大於預期數目
            //或是有Error
            if ((diff[0] > 0 && diff[1] > 0))
            {
                //如果兩個方向都是target not found，就比照單向的處理
                //否則就先縮減threshold
                if (diff[0] == Constants.E_TARGETNOTFOUND && diff[1] == Constants.E_TARGETNOTFOUND)
                {
                    data.CollinearAngle *= 0.95;
                    data.CollinearDistance = (int)(data.CollinearDistance * 0.8);
                    return;
                }
                ScaleThreshold(true, ref data);
                return;
            }

            //如果兩個方向的變動方向相異

            //如果有一者是E_TARGETNOTFOUND，則先比照辦理，試試看能不能先取得單一方向正確
            if (diff[0] == Constants.E_TARGETNOTFOUND || diff[1] == Constants.E_TARGETNOTFOUND)
            {
                data.CollinearAngle *= 0.95;
                data.CollinearDistance = (int)(data.CollinearDistance * 0.8);
                return;
            }
            //如果有一者是E_NOISETOOMUCH，則先縮減threshold
            if (diff[0] == Constants.E_NOISETOOMUCH || diff[1] == Constants.E_NOISETOOMUCH)
            {
                ScaleThreshold(true, ref data);
                return;
            }
            //依照差距最小的方向作調整
            if (Math.Abs(ori_cnt[0]) < Math.Abs(ori_cnt[1]))
            {
                GenSingleWayData(0, diff[0], ori_cnt[0], ref data);
            }
            else
            {
                GenSingleWayData(1, diff[1], ori_cnt[1], ref data);
            }
        }
    }
}
