using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.View
{
    /// <summary>
    /// Данные от пользователя
    /// </summary>
    /// <param name="SolverMethod">Метод решения уравнения</param>
    /// <param name="Equation">Уравнение</param>
    /// <param name="LeftBoundary">Левая граница отрезка, на котором ищется решение</param>
    /// <param name="RightBoundary">Правая граница отрезка, на котором ищется решение</param>
    /// <param name="Epsilon">Максимальная погрешность найденного решения</param>
    public record struct PlotUserInput(
        string SolverMethod, 
        string Equation, 
        string LeftBoundary,
        string RightBoundary,
        string Epsilon
        ) { }
}
