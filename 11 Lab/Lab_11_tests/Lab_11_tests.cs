using Lab_11;

namespace Lab_11_tests
{
    [TestClass]
    public sealed class Lab_11_tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string source = "Meantime we shall express our darker purpose.";

            List<LinePrinter> printers = new();
            printers.Add(new LinePrinter(5));
            printers.Add(new NumberedLinePrinter(5));
            printers.Add(new HidingLinePrinter(['i', 'e', 'a'], 5));
            printers.Add(new NumberedLinePrinterWithLinesNumber(5));

            foreach (var p in printers)
            {
                p.Print(source);
                Console.WriteLine();
            }

            string[] sources =
                [
                    "Meantime we shall express our darker purpose.",
                    "Meantime we shall express our darker",
                    "Meantime we shall express our",
                    "Meantime we shall express",
                    "Meantime we shall",
                ];

            foreach (var p in printers)
            {
                p.N = 45;
                p.FancyPrint(sources);
                Console.WriteLine();
            }
        }
    }
}
