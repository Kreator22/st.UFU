using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.View
{
    public interface IPlotFormView : IView, IError
    {
        /// <summary>
        /// Добавить методы решения для выбора пользователем
        /// </summary>
        void AddSolverMethods(IEnumerable<(string name, string description)> solvers);

        /// <summary>
        /// Добавить уравенения для выбора пользователем
        /// </summary>
        void AddEquations(IEnumerable<(string name, string description)> equations);

        /// <summary>
        /// Данные введённые пользователем
        /// </summary>
        PlotUserInput GetUserInputData();

        /// <summary>
        /// Событие "начать решение уравнения"
        /// </summary>
        event EventHandler<PlotUserInput> SolveTheEquation;

        /// <summary>
        /// Отображение данных решения (текстовое)
        /// </summary>
        void PrintSolution(double solution, int iterations);

        /// <summary>
        /// Событие "отобразить график уравнения и решения на нём"
        /// </summary>
        event EventHandler PlotResults;

        /// <summary>
        /// Отображение графика уравнения
        /// </summary>
        void PlotGraph(IEnumerable<(double X, double Y)> points);

        /// <summary>
        /// Отображение итераций решения на графике уравнения
        /// </summary>
        void PlotSolution(IEnumerable<(double X, double Y, int number)> solutions);

        
    }
}
