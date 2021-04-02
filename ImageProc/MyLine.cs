using System;
using System.Diagnostics;
using System.Drawing;

namespace Velociraptor
{
    class MyLine:IComparable<MyLine>
    {
        private double[] compare_s = new double[2];
        private double[] associate_s = new double[2];
        private double[] coor_x = new double[2];
        private double[] coor_y = new double[2];
        private double theta;
        private double length_square;
        //y = ax + b; a->coef, b->disp
        public double Coefficient = 1;
        public double Displacement = 0;
        public int Wayward = Constants.WAY_NOTHING;
        private bool is_horizontal;
        public MyLine() { }
        public MyLine(double[] x, double[] y)
        {
            theta = ComputeTheta(x, y);
            double angle_convert = MyUtil.ThetaDiff(theta, Math.PI);
            //Atan returns value between -pi~pi
            if (Math.Abs(theta) < Constants.MAX_THETA_LIMIT 
                || angle_convert < Constants.MAX_THETA_LIMIT) //horizontal
            {
                Wayward = Constants.WAY_HORIZONTAL;
                is_horizontal = true;
                if (x[0] < x[1])
                {
                    compare_s = y;
                    associate_s = x;
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        compare_s[i] = y[1 - i];
                        associate_s[i] = x[1 - i];
                    }
                }
                coor_x = associate_s;
                coor_y = compare_s;
                if (angle_convert < Constants.MAX_THETA_LIMIT){
                    if (theta < 0) theta += Math.PI;
                    else theta = Math.PI - theta;
                }
            }
            else if (MyUtil.ThetaDiff(theta, Math.PI / 2) < Constants.MAX_THETA_LIMIT) //vertical
            {
                Wayward = Constants.WAY_VERTICAL;
                is_horizontal = false;
                if (y[0] < y[1])
                {
                    compare_s = x;
                    associate_s = y;
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        compare_s[i] = x[1 - i];
                        associate_s[i] = y[1 - i];
                    }
                }
                coor_x = compare_s;
                coor_y = associate_s;
            }
            ComputeLengthSquare();
            CompFunctionParam();
        }
        public MyLine ShiftLine(bool to_less, int target)
        {
            double offset = (to_less) ? Math.Min(compare_s[1], compare_s[0]) - target
                                        : Math.Max(compare_s[1], compare_s[0]) - target;
            double[] temp = { compare_s[0] - offset, compare_s[1] - offset };
            if (is_horizontal)
                return new MyLine(coor_x, temp);
            else
                return new MyLine(temp, coor_y);
        }
        public void GetIntersectPoint(MyLine other, out PointF p)
        {
            //截距相同兩線重和存在無限多解，不同則無解
            if (Coefficient == other.Coefficient)
            {
                p = new PointF((float)double.PositiveInfinity, (float)double.PositiveInfinity);
                return;
            }
            //求解
            double x, y;
            if (Coefficient==0)
            {
                y = Displacement;
                x = other.InferXCoor(y);
            } 
            else if (double.IsInfinity(Coefficient))
            {
                x = Displacement;
                y = other.InferYCoor(x);
            }
            else
            {
                if (double.IsInfinity(other.Coefficient))
                {
                    x = other.Displacement;
                    y = InferYCoor(x);
                } 
                else if (other.Coefficient == 0)
                {
                    y = other.Displacement;
                    x = InferXCoor(y);
                }
                else
                {
                    x = (other.Displacement - Displacement) / (Coefficient - other.Coefficient);
                    y = x * Coefficient + Displacement;
                }
            }
            p = new PointF((float)x, (float)y);
        }
        public bool MergeLine(MyLine other, int dist_limit, double theta_limit)
        {
            double gap_max, gap_min;
            if (GetCompareProp(0) > GetCompareProp(1))
            {
                gap_max = GetCompareProp(0) + dist_limit;
                gap_min = GetCompareProp(1) - dist_limit;
            }
            else
            {                
                gap_max = GetCompareProp(1) + dist_limit;
                gap_min = GetCompareProp(0) - dist_limit;
            }

            //如果兩條線的傾斜角度相差不大，且高度座標距離在Limit之中
            //因為影像本身傾斜越大，座標差距會越大
            //所以如果theta_limit比較嚴格，可以考慮把dist_limit放寬
            if (Math.Abs(theta - other.GetTheta()) <= theta_limit
                && (MyUtil.InRange(other.GetCompareProp(0), gap_min, gap_max)
                || MyUtil.InRange(other.GetCompareProp(1), gap_min, gap_max)))
            {
                //以這兩條線最遠的端點作為座標
                //重新計算
                //可能不太精確
                //必要時再重新處理merge的動作
                //Debug.WriteLine("Merge Lines: " + this.ToString() + " + " + other.ToString());
                if (GetAssociateProp(0) > other.GetAssociateProp(0))
                {
                    SetProp(other.GetCompareProp(0), other.GetAssociateProp(0), 0);
                }
                if (GetAssociateProp(1) < other.GetAssociateProp(1))
                {
                    SetProp(other.GetCompareProp(1), other.GetAssociateProp(1), 1);
                }
                ComputeLengthSquare();
                theta = ComputeTheta(coor_x, coor_y);
                CompFunctionParam();
                return true;
            }
            return false;
        }
        public double GetCompareProp(int idx)
        {
            return compare_s[idx];
        }
        public double GetComparePropAvg()
        {
            return (compare_s[0] + compare_s[1]) / 2;
        }

        public double GetAssociateProp(int idx)
        {
            return associate_s[idx];
        }
        public double InferAssociateCoor(double coor) 
        { 
            if (Coefficient == 0 || double.IsInfinity(Coefficient))
            {
                return Displacement;
            }
            else
            {
                if (is_horizontal)
                    return Coefficient * coor + Displacement;
                else return (coor - Displacement) / Coefficient;
            }
        }
        public double InferXCoor(double y)
        {
            if (double.IsInfinity(Coefficient)) return Displacement;
            else if (Coefficient == 0) return double.PositiveInfinity;
            else return (y - Displacement) / Coefficient;
        }
        public double InferYCoor(double x)
        {
            if (double.IsInfinity(Coefficient)) return double.PositiveInfinity;
            else if (Coefficient == 0) return Displacement;
            else return Coefficient * x + Displacement;
        }
        public double GetCoorX(int idx)
        {
            return coor_x[idx];
        }
        public double GetCoorY(int idx)
        {
            return coor_y[idx];
        }
        public void ComputeLengthSquare()
        {
            double s1 = compare_s[1] - compare_s[0];
            double s2 = associate_s[1] - associate_s[0];
            length_square = s1 * s1 + s2 * s2;
        }
        public double Length_Square()
        {
            return length_square;
        }
        public void SetProp(double comp, double ass, int idx)
        {
            compare_s[idx] = comp;
            associate_s[idx] = ass;
        }
        public double GetTheta()
        {
            return theta;
        }
        public double GetTheta2Horizon()
        {
            if (!is_horizontal)
            {
                if (theta < 0) return theta + Math.PI / 2;
                else return theta - Math.PI / 2;
            }
            else return theta;
        }
        private void CompFunctionParam()
        {
            if ((coor_x[1] - coor_x[0]) == 0)
            {
                Coefficient = double.PositiveInfinity;
                Displacement = coor_x[0];
            }
            else
            {
                Coefficient = (coor_y[1] - coor_y[0])
                                / (coor_x[1] - coor_x[0]);
                Displacement = ((coor_y[1] + coor_y[0])
                               - Coefficient * (coor_x[1] + coor_x[0])) / 2.0;
            }
        }
        public int CompareTo(MyLine other)
        {
            if (null == other) return 1;
            return this.compare_s[0].CompareTo(other.GetCompareProp(0));
        }
        public override string ToString()
        {
            if (is_horizontal)
            {
                string str = "Horizontal Line ";
                for (int i = 0; i < 2; i++)
                {
                    str += "(" + associate_s[i].ToString("0.##") + ",";
                    str += compare_s[i].ToString("0.##") + ") ";
                }
                return str + "Theta=" + theta.ToString("0.#####");
            }
            else
            {
                string str = "Vertical Line ";
                for (int i = 0; i < 2; i++)
                {
                    str += "(" + compare_s[i].ToString("0.##") + ",";
                    str += associate_s[i].ToString("0.##") + ") ";
                }
                return str + "Theta=" + theta.ToString("0.#####");
            }
        }
        private double ComputeTheta(double[] x, double[] y)
        {
            return Math.Atan2(y[1] - y[0], x[1] - x[0]);
        }
    }
}
