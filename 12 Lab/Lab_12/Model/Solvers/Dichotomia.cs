using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    /// <summary>
    /// Класс реализующий решение уравнения методом половинного деления
    /// </summary>
    public class Dichotomia : AbstractSolver
    {
        public override string Name { get => "Метод половинного деления"; }

        public Dichotomia(Func<double, double> equation, double a, double b, double epsilon = 1E-07) : 
            base(equation, a, b, epsilon) { }

        public Dichotomia(IEquationSolver solver) : 
            this(solver.Equation, solver.A, solver.B, solver.Epsilon) { }

        public override void SolveTheEquation()
        {
            base.SolveTheEquation();

            while (Math.Abs(B - A) > Epsilon)
            {
                Iterations++;

                OneStep();
                SolutionPoints.Add((new Point(C, Equation(C)), Iterations));
            }
        }

        protected override void OneStep()
        {
            C = (B - A) / 2 + A;
            if (HasSameSign(Equation(A), Equation(C)))
                (A, B) = (C, B);
            else
                (A, B) = (A, C);
        }
    }
}
