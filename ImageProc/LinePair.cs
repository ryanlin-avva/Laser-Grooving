using System;

namespace Velociraptor
{
    class LinePair : IComparable<LinePair>
    {
        public int[] Line_idx = new int[2];
        public double Distance = 0; //有正負號
        public int Gap = 0;

        public LinePair(int i, int j, double gap, double side)
        {
            Line_idx[0] = i;
            Line_idx[1] = j;
            Distance = Math.Abs(gap - side);
        }
        public LinePair(Grouper g1, Grouper g2, double side)
        {
            Line_idx[0] = g1.SequenceNo;
            Line_idx[1] = g2.SequenceNo;
            //兩者之間的距離，可能差距gap個邊長
            double diff = g2.Coor - g1.Coor;
            Gap = (int)(diff / side + 0.5);
            Distance = diff - side * Gap;
        }
        public int CompareTo(LinePair other)
        {
            if (null == other) return 1;
            double temp = Math.Abs(this.Distance);
            return temp.CompareTo(Math.Abs(other.Distance));
        }
        public override string ToString()
        {
            return "Line " + Line_idx[0].ToString() + "-" + Line_idx[1]
                    + " with Distance " + Distance.ToString() + ", Gap " + Gap.ToString();
        }
    }
}
