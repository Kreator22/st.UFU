using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.View
{
    public record struct PlotUserInput(
        string SolverMethod, 
        string Equation, 
        string LeftBoundary,
        string RightBoundary,
        string Epsilon
        ) { }
}
