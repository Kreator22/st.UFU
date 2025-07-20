using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_09.Point_Comparators
{
    public class PointdistanceToXEqualYFunction : IComparer<Point>
    {
        public int Compare(Point? x, Point? y)
        {
            if (x is null || y is null)
                throw new NullReferenceException();

            return
                Math.Abs(x.X - x.Y) / Math.Sqrt(2) >
                Math.Abs(y.X - y.Y) / Math.Sqrt(2) ?
                1 : -1;
        }
    }
}
