using Lab_12.Model;

namespace Lab_12_Tests;


[TestClass]
public sealed class Lab_12_Tests
{
    [TestMethod]
    public void DichotomiaTest()
    {
        //f(x) = Sin(x), f(x) = 0 при x = Pi ~ 3.14
        IEquationSolver solver = new Dichotomia(Math.Sin, 1, 4, 0.1e-6);
        solver.SolveTheEquation();

        Assert.IsTrue(Math.Abs(solver.C) - Math.PI < 0.1e-6);
        Console.WriteLine("C = " + solver.C);
        Console.WriteLine("f(C) = sin(C) = " + Math.Sin(solver.C) + Environment.NewLine);

        //f(x) = x, f(x) = 0 при x = 0
        solver = new Dichotomia(x => x, -1, 1);
        solver.SolveTheEquation();

        Assert.IsTrue(Math.Abs(solver.C) < 0.1e-6);
        Console.WriteLine("C = " + solver.C);
        Console.WriteLine("f(C) = C = " + Math.Sin(solver.C) + Environment.NewLine);

        //f(x) = x^2 - 2, f(x) = 0 при x = 2^1/2 ~ 1.41
        solver = new Dichotomia(x => x * x - 2, 0, 5);
        solver.SolveTheEquation();

        Assert.IsTrue((Math.Pow(solver.C, 2) - 2) < 0.1e-6);
        Console.WriteLine("C = " + solver.C);
        Console.WriteLine("f(C) = C * C - 2 = " + (Math.Pow(solver.C, 2) - 2));
    }
}
