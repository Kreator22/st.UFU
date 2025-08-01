using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    public abstract class AbstractSolver : IEquationSolver
    {
        /// <summary>
        /// Счётчик итераций
        /// </summary>
        public int Iterations { get; protected set; } 
        public Func<double, double> Equation { get; protected set; }
        public double Epsilon { get; protected set; }
        public double A { get; protected set; }
        public double B { get; protected set; }
        public double C { get; protected set; }
        public abstract string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equation">Уравнение</param>
        /// <param name="a">Аргумент A. Решение C ищется между A и B. </param>
        /// <param name="b">Аргумент B. Решение C ищется между A и B. </param>
        /// <param name="epsilon">Погрешность решения (по умолчанию 0.1e-6)</param>
        protected AbstractSolver(Func<double, double> equation, double a, double b,
            double epsilon = 0.1e-6) =>
            SetParameters(equation, a, b, epsilon);

        /// <summary>
        /// 
        /// </summary>
        protected AbstractSolver(IEquationSolver solver) :
            this(solver.Equation, solver.A, solver.B, solver.Epsilon) { }

        public void SetParameters(Func<double, double> equation, double a, double b,
            double epsilon = 0.1e-6)
        {
            //if (equation.GetInvocationList().Length == 0)
              //  throw new NullReferenceException("Не передано уравнение для решения");

            Equation = equation;
            A = a;
            B = b;
            Epsilon = epsilon;
        }

        protected abstract void OneStep();
        public void SolveTheEquation()
        {
            if (Equation.GetInvocationList().Length == 0)
                throw new NullReferenceException("Нет уравнения для решения");

            while (Math.Abs(B - A) > Epsilon)
            {
                Iterations++;
                OneStep();
            }
        }

        /// <summary>
        /// Проверка равенства знаков
        /// </summary>
        /// <returns>true, если а и б одного знака (оба положительные или оба отрицательные)</returns>
        protected static bool HasSameSign(double a, double b) =>
            Math.CopySign(1, a) == Math.CopySign(1, b);
    }
}
