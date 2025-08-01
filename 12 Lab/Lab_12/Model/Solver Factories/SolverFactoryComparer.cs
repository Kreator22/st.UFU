using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model.Solver_Factories
{
    public class SolverFactoryComparer : IEqualityComparer<ISolverFactory>
    {
        public bool Equals(ISolverFactory? x, ISolverFactory? y) =>
            x is not null &&
            y is not null &&
            x.SolverName == y.SolverName;

        public int GetHashCode([DisallowNull] ISolverFactory obj) =>
            obj.SolverName.GetHashCode();
    }
}
