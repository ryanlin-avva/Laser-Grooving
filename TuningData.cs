using System;

namespace Velociraptor
{
    class TuningData 
    {
        //Image Processing parameters
        public int CollinearDistance;
        public double CollinearAngle;
        public int SelectContourMinLength;
        private int threshold_min = 0;
        private int threshold_max = 255;
        static private bool is_dark;

        public TuningData(int th, int maxDist, double angle, bool isDark, int min_side)
        {
            is_dark = isDark;
            SetThreshold(th);
            CollinearDistance = maxDist;
            CollinearAngle = angle;
            //考慮到交界處的skeleton可能比較混亂
            //目前線段最小長度先暫且設為min(die高度,img高度)*0.9或大約1/4 FOV
            //否則碰到大die，太長的lower bound很可能找不到適當的線段
            SelectContourMinLength = (int)Math.Min(min_side * 0.9, Constants.SELECT_LENGTH_LOWER_BOUND);
        }

        public TuningData(TuningData other)
        {
            threshold_min = other.threshold_min;
            threshold_max = other.threshold_max;
            CollinearDistance = other.CollinearDistance;
            CollinearAngle = other.CollinearAngle;
            SelectContourMinLength = other.SelectContourMinLength;
        }
        public void SetThreshold(int th)
        {
            if (is_dark) threshold_max = th;
            else threshold_min = th;
        }
        public int Threshold()
        {
            return is_dark ? threshold_max : threshold_min;
        }
        public void ShrinkLength()
        {
            SelectContourMinLength = (int)(SelectContourMinLength * 0.6);
        }
        public int ThresholdMax()
        {
            return threshold_max;
        }
        public int ThresholdMin()
        {
            return threshold_min;
        }

        public void Scale(bool to_shrink)
        {
            if (to_shrink)
            {
                if (is_dark) threshold_max = (int)(threshold_max * 0.8);
                else threshold_min = (int)(threshold_min * 1.2);
            }
            else
            { 
                if (is_dark) threshold_max = (int)(threshold_max * 1.2);
                else threshold_min = (int)(threshold_min * 0.8);
            }
        }
        public override string ToString()
        {
            return "Threshold = " + threshold_min.ToString()
                   + " ~ " + threshold_max.ToString()
                   + ", CollinearDistance = " + CollinearDistance.ToString()
                   + ", CollinearAngle = " + CollinearAngle.ToString()
                   + ", SelectLength = " + SelectContourMinLength.ToString();
        }

        public static bool operator >(TuningData a, TuningData b)
        {
            //如果線段比較暗，找更暗
            //如果線段比較亮，找更亮
            return is_dark ? a.threshold_max > b.threshold_max
                            : b.threshold_min > a.threshold_min;

        }
        public static bool operator <(TuningData a, TuningData b)
        {
            //如果線段比較暗，找更暗
            //如果線段比較亮，找更亮
            return is_dark ? a.threshold_max < b.threshold_max
                            : b.threshold_min > a.threshold_min;
        }
    }
}
