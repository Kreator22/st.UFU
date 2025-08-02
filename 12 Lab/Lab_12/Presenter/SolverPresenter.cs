using Lab_12.Model;
using Lab_12.Model.Equations;
using Lab_12.Model.Solver_Factories;
using Lab_12.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Presenter
{
    /// <summary>
    /// Класс (presentor/представитель) связывающий воедино варианты решений уравнений (model/модель) 
    /// и пользовательский интерфейс (view/представление) согласно модели MVP 
    /// </summary>
    class SolverPresenter : IPresentor
    {
        private IPlotFormView PlotFormView;
        //Фабрики решений
        private List<ISolverFactory> solverFactories;
        //Уравнения для решения
        private List<IEquation> equations;
        //Решение
        private IEquationSolver solver;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plotFormView"></param>
        /// <remarks>
        /// После создания объекта требуется регистрация фабрик решений: <br/>
        /// <see cref="AddSolverFactory"/> <br/>
        /// <see cref="AddSolverFactories"/> <br/><br/>
        /// После создания объекта требуется регистрация уравнений для решения: <br/>
        /// <see cref="AddEquation"/><br/>
        /// <see cref="AddEquations"/><br/>
        /// </remarks>
        public SolverPresenter(IPlotFormView plotFormView)
        {
            PlotFormView = plotFormView;

            solverFactories = [];
            equations = [];

            plotFormView.SolveTheEquation += Solve;
        }

        #region Регистрация фабрик решений
        public void AddSolverFactory(ISolverFactory solverFactory)
        {
            if (!solverFactories.Contains(solverFactory, new SolverFactoryComparer()))
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


        /// <summary>
        /// Парсит данные пользователя. <br/>
        /// При успехе создаёт экземпляр <see cref="IEquationSolver"/> для класса. <br/>
        /// При ошибке вызывает <see cref="ShowError"/> с ошибками для всех ошибочных полей <see cref="PlotUserInput"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="userInput">Данные введенные пользователем</param>
        private void Solve(object? sender, PlotUserInput userInput)
        {
            bool errorFlag = false;
            StringBuilder error = new();

            ISolverFactory? solverFactory =
                solverFactories
                .Find(sf => sf.SolverName == userInput.SolverMethod);
            if(solverFactory is null)
            {
                errorFlag = true;
                error.Append($"Не найден метод решенеия {userInput.SolverMethod}" + Environment.NewLine);
            }

            IEquation? equation =
                equations
                .Find(eq => eq.Name == userInput.Equation);
            if(equation is null)
            {
                errorFlag = true;
                error.Append($"Не найдено уравнение {userInput.Equation}" + Environment.NewLine);
            }

            double leftBoundary;
            if(!double.TryParse(userInput.LeftBoundary, out leftBoundary))
            {
                errorFlag = true;
                error.Append($"Не удалось преобразовать в число левую границу {userInput.LeftBoundary}" + Environment.NewLine);
            }

            double rightBoundary;
            if(!double.TryParse(userInput.RightBoundary, out rightBoundary))
            {
                errorFlag = true;
                error.Append($"Не удалось преобразовать в число правую границу {userInput.RightBoundary}" + Environment.NewLine);
            }

            double epsilon;
            if(!double.TryParse(userInput.Epsilon, CultureInfo.InvariantCulture, out epsilon))
            {
                errorFlag = true;
                error.Append($"Не удалось преобразовать в число погрешность {userInput.Epsilon}" + Environment.NewLine);
            }

            if (errorFlag)
                ShowError(error.ToString());
            else
            {
                solver = solverFactory!
                    .CreateSolver(equation!.F_x, leftBoundary, rightBoundary, epsilon);
                PlotResult();
            }
        }

        /// <summary>
        /// Вызов окна с ошибкой
        /// </summary>
        /// <param name="errorText">Текст ошибки</param>
        /// <param name="errorCaption">Заголовок окна ошибки</param>
        private void ShowError(string errorText, string errorCaption = "Ошибка") =>
            PlotFormView.ShowError(errorText, errorCaption);

        /// <summary>
        /// Вывести результат в View
        /// </summary>
        private void PlotResult()
        {

        }



        public void Run()
        {
            //Отправляем в форму зарегистрированные методы решения
            PlotFormView.AddSolverMethods(
                solverFactories
                .Select(s => (s.SolverName, s.SolverDescription))
                .ToList());

            //Отправляем в форму зарегистрированные виду уравнений
            PlotFormView.AddEquations(
                equations
                .Select(eq => (eq.Name, eq.Description))
                .ToList());

            PlotFormView.Show();
        }



    }
}
