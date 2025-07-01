using LB7 = Lab_07.Lab_07;

namespace Lab_07_Tests
{
    [TestClass]
    public sealed class Lab_07_Tests
    {
        [TestMethod]
        public void Factorial()
        {
            Assert.AreEqual(1, LB7.Factorial(0));
            Assert.AreEqual(1, LB7.Factorial(1));
            Assert.AreEqual(2, LB7.Factorial(2));
            Assert.AreEqual(6, LB7.Factorial(3));
            Assert.AreEqual(24, LB7.Factorial(4));
            Assert.AreEqual(120, LB7.Factorial(5));

            for (int i = 0; i <= 10; i++)
                Console.WriteLine($"{i}! = {LB7.Factorial(i)}");
        }

        [TestMethod]
        public void IntNumbersPrint()
        {
            LB7.IntNumbersPrint(1, 10);
        }

        [TestMethod]
        public void IntNumbersPrintAD()
        {
            LB7.IntNumbersPrintAD(1, 9);
            LB7.IntNumbersPrintAD(10, 1);
        }

        [TestMethod]
        public void IntNumbersPrintAscending()
        {
            LB7.IntNumbersPrintAscending(1, 9);
            LB7.IntNumbersPrintAscending(10, 1);
        }

        [TestMethod]
        public void DegreeOfTwo()
        {
            Console.WriteLine(1 & 0);
            Assert.AreEqual(false, LB7.DegreeOfTwo(0));
            Assert.AreEqual(false, LB7.DegreeOfTwo(1));
            Assert.AreEqual(true, LB7.DegreeOfTwo(2));
            Assert.AreEqual(false, LB7.DegreeOfTwo(7));
            Assert.AreEqual(true, LB7.DegreeOfTwo(8));
            Assert.AreEqual(false, LB7.DegreeOfTwo(9));
        }

        [TestMethod]
        public void GreatestCommonDivisor()
        {
            Assert.AreEqual(12, LB7.GreatestCommonDivisor(48, 36));
            Assert.AreEqual(12, LB7.GreatestCommonDivisor(36, 48));
        }

        [TestMethod]
        public void ListSum()
        {
            List<int> source = [1, 2, 3, 4, 5];
            int expected = 15;

            int actual = LB7.ListSum(source, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void fib()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"fib({i}) = " + LB7.fib(i));

            Assert.AreEqual(55, LB7.fib(9));
        }

        [TestMethod]
        public void DigProduct()
        {
            Assert.AreEqual(120, LB7.DigProduct(12345));
        }

        [TestMethod]
        public void PrimeFactors()
        {
            LB7.PrimeFactors(10);
            LB7.PrimeFactors(864);
        }
    }
}
