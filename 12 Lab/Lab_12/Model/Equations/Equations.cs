using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_12.Model.Equations.IEquation;

namespace Lab_12.Model.Equations
{
    /// <summary>
    /// Фабрика уравнений <see cref="IEquation"/>
    /// </summary>
    public class EquationsFabric
    {
        private List<IEquation> equations;
        public EquationsFabric()
        {
            equations = new();
            equations.Add(new Equation("Sin(x)", "f(x) = Sin(x)", Math.Sin));
            equations.Add(new Equation("x", "f(x) = x", x => x));
            equations.Add(new Equation("x^2 - 2", "f(x) = x^2 - 2", x => x * x - 2));
        }

        public void AddEquation(Equation equation) =>
            equations.Add(equation);

        public List<IEquation> GetEquations() =>
            [.. equations];
    }

    public record Equation(string Name, string Description, Func<double, double> F_x) : IEquation;
}
