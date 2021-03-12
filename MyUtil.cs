using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velociraptor
{
    class MyUtil
    {
        public static bool InRange(double t, double min, double max) => (t >= min && t <= max);
        public static bool InRange(int t, int min, int max) => (t >= min && t <= max);
        public static double ThetaDiff(double theta1, double theta2)
        {
            if (theta1 > theta2) return theta1 - theta2;
            else return theta2 - theta1;
        }

    }
}
