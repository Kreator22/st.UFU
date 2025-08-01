using Lab_12.Model;
using Lab_12.Model.Equations;
using Lab_12.Presenter;

namespace Lab_12
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            SolverPresenter presentor = new(new PlotForm());
            presentor.AddSolverFactories(new DichotomiaFactory(), new SecantFactory());
            presentor.AddEquations(new EquationsFabric().GetEquations());
            presentor.Run();

        }
    }
}