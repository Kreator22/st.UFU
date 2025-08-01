using Lab_12.Model.Solver_Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    class SecantFactory() : AbstractSolverFactory("Secant", "Метод хорд")
    {
        public override IEquationSolver CreateSolver(
            Func<double, double> equation,
            double a,
            double b,
            double epsilon = 1E-07) =>
            new Dichotomia(equation, a, b, epsilon);
    }
}
