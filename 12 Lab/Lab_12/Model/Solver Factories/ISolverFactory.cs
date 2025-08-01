using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    public interface ISolverFactory
    {
        string SolverName { get; }
        string SolverDescription { get; }
        IEquationSolver CreateSolver(Func<double, double> equation, double a, double b, double epsilon = 1E-07);

    }
}
