using Lab_12.Model.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    /// <summary>
    /// Класс абстрактного решателя, реализует общий для всех решателей функционал
    /// </summary>
    public abstract class AbstractSolver : IEquationSolver, ISolution
    {
        /// <summary>
        /// Счётчик итераций
        /// </summary>
        public int Iterations { get; protected set; } 

        /// <summary>
        /// Уравнение для решения
        /// </summary>
        public Func<double, double> Equation { get; protected set; }

        /// <summary>
        /// Максимальная погрешность решения
        /// </summary>
        public double Epsilon { get; protected set; }

        /// <summary>
        /// Левая граница отрезка для поиска решения на текущей итерации
        /// </summary>
        public double A { get; protected set; }

        /// <summary>
        /// Правая граница отрезка для поиска решения на текущей итерации
        /// </summary>
        public double B { get; protected set; }

        /// <summary>
        /// Найденное решение x на текущей итерации
        /// </summary>
        public double C { get; protected set; }

        public abstract string Name { get; }

        /// <summary>
        /// Левая граница отрезка на котором ищется решение.
        /// </summary>
        protected double LeftBoundary { get; set; }

        /// <summary>
        /// Правая граница отрезка на котором ищется решение.
        /// </summary>
        protected double RightBoundary { get; set; }

        /// <summary>
        /// Точки, найденные в ходе итераций поиска решений и номера этих итераций
        /// </summary>
        protected List<(Point solution, int number)> SolutionPoints;

        /// <summary>
        /// значение Equation(a)
        /// </summary>
        private double fa;

        /// <summary>
        /// значение Equation(b)
        /// </summary>
        private double fb;

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
            if (equation.GetInvocationList().Length == 0)
                throw new NullReferenceException("Не передано уравнение для решения");

            Equation = equation;
            A = a;
            B = b;
            Epsilon = epsilon;
            SolutionPoints = [];
            LeftBoundary = A;
            RightBoundary = B;

            fa = Equation(a);
            fb = Equation(b);
            if (a > b)
                throw new ArgumentException("Аргумент \"b\" должен быть больше аргумента \"a\"");
            if (HasSameSign(fa, fb))
                throw new ArgumentException
                    ("Уравнение f(x) имеет решение между границами x = a и x = b если f(a) и f(b) имеют " +
                    "разные знаки (график уравнения пересекает ось оХ). " + Environment.NewLine +
                    "Для заданных границ a и b решения f(a) и f(b) имеют одинаковый знак");
        }

        /// <summary>
        /// Одна итерация решения
        /// </summary>
        protected abstract void OneStep();

        /// <summary>
        /// Начать решение уравнения f(x) = 0
        /// </summary>
        public virtual void SolveTheEquation()
        {
            if (Equation.GetInvocationList().Length == 0)
                throw new NullReferenceException("Нет уравнения для решения");
        }

        /// <summary>
        /// Проверка равенства знаков
        /// </summary>
        /// <returns>
        /// true, если а и б одного знака (оба положительные или оба отрицательные)
        /// </returns>
        protected static bool HasSameSign(double a, double b) =>
            Math.CopySign(1, a) == Math.CopySign(1, b);

        /// <summary>
        /// Получить точки графика уравнения с заданной переодичностью
        /// </summary>
        /// <param name="step">Переодичность точек по оси x</param>
        public IEnumerable<Point> GetGraphPoints(double step = 0.1)
        {
            double left = LeftBoundary;

            while(left < RightBoundary)
            {
                yield return new Point(left, Equation(left));
                left += step;
            }
            yield return new Point(RightBoundary, Equation(RightBoundary));
            yield break;
        }

        /// <summary>
        /// Получить решения уравнения и их номер с переодичностью не ниже заданной
        /// </summary>
        /// <param name="step">Минимальная переодичность точек по оси x</param>
        public IEnumerable<(Point, int)> GetSolutionPoints(double step = 0.1)
        {
            if (!SolutionPoints.Any())
                throw new InvalidOperationException
                    ("Решения не найдены. Сначала выполните поиск решений через SolveTheEquation() метод");

            step = Math.Abs(step);
            double lastX = SolutionPoints.First().solution.X;
            yield return SolutionPoints[0];

            for (int i = 0; i < SolutionPoints.Count; i++)
            {
                double X = SolutionPoints[i].solution.X;
                if (X < lastX - step || X > lastX + step)
                {
                    lastX = X;
                    yield return SolutionPoints[i];
                } 
            }
            yield return SolutionPoints.Last();
            yield break;
        }
    }
}
