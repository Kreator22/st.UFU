using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model.Solver_Factories
{
    public abstract class SolverFactory(string solverName, string solverDescription) : ISolverFactory
    {
        public string SolverName { get; } = solverName;

        public string SolverDescription { get; } = solverDescription;

        public abstract IEquationSolver CreateSolver
            (Func<double, double> equation, double a, double b, double epsilon = 1E-07);

        public override bool Equals(object? obj) =>
            obj is not null &&
            obj is ISolverFactory factory &&
            factory.SolverName == this.SolverName;

        public override int GetHashCode() =>
            SolverName.GetHashCode();
    }
}
