using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.View
{
    public interface IPlotFormView : IView, IError
    {
        void AddSolverMethods(IEnumerable<(string name, string description)> solvers);
        void AddEquations(IEnumerable<(string name, string description)> equations);

        PlotUserInput GetUserInputData();

        event EventHandler<PlotUserInput> SolveTheEquation;
    }
}
