using HW_06;
using HW06 = HW_06.HW_06;

namespace HW_06_Tests
{
    [TestClass]
    public sealed class HW_06_Tests
    {
        [TestMethod]
        public void HW_06_Test()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "measurements.txt");
            Console.WriteLine(path + Environment.NewLine);

            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine(Environment.NewLine + $"Набор данных #{i + 1}");
                HW06.PrintCalculations(path, i);
            }
        }
    }
}
