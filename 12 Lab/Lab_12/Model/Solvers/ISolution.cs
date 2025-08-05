using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model.Solvers
{
    /// <summary>
    /// Интерфейс классов содержащих в себе решение уравнения
    /// </summary>
    public interface ISolution
    {
        /// <summary>
        /// Точки графика
        /// </summary>
        /// <param name="step">Шаг отображения графика</param>
        /// <returns>Все точки графика</returns>
        IEnumerable<Point> GetGraphPoints(double step = 1E-1);

        /// <summary>
        /// Точки (итерации) решения и их номера
        /// </summary>
        /// <param name="step">
        /// Шаг отображения решения. 
        /// Выходной набор будет содержать решение первой итерации, последней и промежуточные
        /// не чаще этого шага.
        /// </param>
        /// <returns>Точки итераций решения уравнения f(x) = 0 для этого графика</returns>
        IEnumerable<(Point point, int number)> GetSolutionPoints(double step = 1E-1);
    }
}
