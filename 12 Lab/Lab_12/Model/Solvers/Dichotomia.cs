using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    public class Dichotomia : AbstractSolver
    {
        public override string Name { get => "Метод половинного деления"; }

        /// <summary>
        /// значение Equation(a)
        /// </summary>
        private double fa;
        /// <summary>
        /// значение Equation(b)
        /// </summary>
        private double fb;

        public Dichotomia(Func<double, double> equation, double a, double b, double epsilon = 1E-07) : 
            base(equation, a, b, epsilon)
        {
            fa = Equation(a);
            fb = Equation(b);
            if (a > b)
                throw new ArgumentException("Аргумент \"b\" должен быть больше аргумента \"a\"");
            if (HasSameSign(fa, fb))
                throw new ArgumentException
                    ("Уравнение f(x) имеет решение между x = a и x = b если f(a) и f(b) имеют" +
                    "разные знаки (график уравнения пересекает ось оХ). " +
                    "Для заданных a и b решения f(a) и f(b) имеют один знак");
        }

        public Dichotomia(IEquationSolver solver) : 
            this(solver.Equation, solver.A, solver.B, solver.Epsilon) { }

        //Перегрузите OneStep() так, чтобы метод SolveEquation выполнял метод половинного деления.
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
