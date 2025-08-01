using Lab_12.Model;
using Lab_12.Model.Equations;
using Lab_12.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Presenter
{
    class SolverPresenter : IPresentor
    {
        IPlotFormView PlotFormView;
        List<ISolverFactory> solverFactories;
        List<IEquation> equations;


        public SolverPresenter(IPlotFormView plotFormView)
        {
            PlotFormView = plotFormView;

            solverFactories = [];
            equations = [];

            plotFormView.SolveTheEquation += Solve;
        }

        private void Solve(object? sender, PlotUserInput e)
        {
            throw new NotImplementedException();
        }

        #region Регистрация фабрик решений
        public void AddSolverFactory(ISolverFactory solverFactory)
        {
            if (!solverFactories.Contains(solverFactory))
                solverFactories.Add(solverFactory);
        }

        public void AddSolverFactories(params ISolverFactory[] solverFactories)
        {
            foreach (var factory in solverFactories)
                AddSolverFactory(factory);
        }
        #endregion

        #region Регистрация уравнений
        public void AddEquation(IEquation equation)
        {
            if (!equations.Contains(equation))
                equations.Add(equation);
        }

        public void AddEquations(params IEquation[] equations)
        {
            foreach (var equation in equations)
                AddEquation(equation);
        }

        public void AddEquations(IEnumerable<IEquation> equations)
        {
            foreach (var equation in equations)
                AddEquation(equation);
        }
        #endregion




        public void Run()
        {
            PlotFormView.AddSolverMethods(
                solverFactories
                .Select(s => (s.SolverName, s.SolverDescription))
                .ToList());

            PlotFormView.AddEquations(
                equations
                .Select(eq => (eq.Name, eq.Description))
                .ToList());

            PlotFormView.Show();
        }



    }
}
