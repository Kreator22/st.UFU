using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_09.Point_Comparators
{
    public class PointDistanceToZeroZero : IComparer<Point>
    {
        public int Compare(Point? x, Point? y)
        {
            if (x is null || y is null)
                throw new NullReferenceException();

            return
            Math.Sqrt(Math.Pow(x.X, 2) + Math.Pow(x.Y, 2)) >
            Math.Sqrt(Math.Pow(y.X, 2) + Math.Pow(y.Y, 2)) ?
            1 : -1;
        }
    }
}
