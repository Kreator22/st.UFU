using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model.Solvers
{
    public class Secant(Func<double, double> equation, double a, double b, double epsilon = 1E-07) :
        AbstractSolver(equation, a, b, epsilon)
    {
        public override string Name { get => "Метод хорд"; }

        public override void SolveTheEquation()
        {
            base.SolveTheEquation();

            while (Math.Abs(C - A) > Epsilon)
            {
                if(Iterations > 0)
                    A = C;
                Iterations++;
                
                OneStep();
                SolutionPoints.Add((new Point(C, Equation(C)), Iterations));
            }
        }

        protected override void OneStep()
        {
            C = A - ((B - A) * Equation(A)) / (Equation(B) - Equation(A));
        }
    }
}
