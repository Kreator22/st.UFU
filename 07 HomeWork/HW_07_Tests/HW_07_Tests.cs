using HW_07;

namespace HW_07_Tests
{
    [TestClass]
    public sealed class HW_07_Tests
    {
        [TestMethod]
        public void RPN()
        {
            string source = "3 + 4 * 2 / ( 1 - 5 ) ^ 2";
            string actual = HW_07.RPN.InfixToRPN(source);
            string expected = "3 4 2 * 1 5 − 2 ^ / +";
            StringAssert.Equals(expected, actual);

            Console.WriteLine("Infix:");
            Console.WriteLine(source);
            Console.WriteLine("RPN:");
            Console.WriteLine(actual + " = " + HW_07.RPN.CalculateRPN(actual));
        }
    }
}
