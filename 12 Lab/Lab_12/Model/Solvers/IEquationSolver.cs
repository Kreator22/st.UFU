using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model
{
    public interface IEquationSolver
    {
        /// <summary>
        /// Имя метода решения
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Уравнение
        /// </summary>
        Func<double, double> Equation { get; }

        /// <summary>
        /// Погрешность решения 
        /// </summary>
        double Epsilon { get; }  
        /// <summary>
        /// Аргумент A. Решение C ищется между A и B. 
        /// </summary>
        double A { get; }
        /// <summary>
        /// Аргумент B. Решение C ищется между A и B. 
        /// </summary>
        double B { get; }
        /// <summary>
        /// Решение C ищется между A и B. f(C) ~ 0
        /// </summary>
        public double C { get; }                      

        void SolveTheEquation();
    }
}
