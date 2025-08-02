using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model.Equations
{
    public interface IEquation
    {
        string Name { get; }
        string Description { get; }
        Func<double, double> F_x { get; }
    }
}
