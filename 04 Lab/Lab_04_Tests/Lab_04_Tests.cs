using Lab_04;
using LB41 = Lab_04.Lab_04_01;
using LB42 = Lab_04.Lab_04_02;

namespace Lab_04_Tests
{
    [TestClass]
    public sealed class Lab_04_01_Tests
    {
        [TestMethod]
        public void PrintSequence()
        {
            int[] actual_int = [1, 2, 3];
            string expected = "1, 2, 3";
            Assert.AreEqual(expected, actual_int.PrintSequence());

            char[] actual_char = ['a', 'b', 'c'];
            expected = "a.b.c";
            Assert.AreEqual(expected, actual_char.PrintSequence("."));
        }

        [TestMethod]
        public void GenerateRandomSequence()
        {
            LB41.GenerateRandomSequence(10).PrintSequence();
            LB41.GenerateRandomSequence(10, -3, 3).PrintSequence(" : ");
        }

        [TestMethod]
        public void GenerateEvenNumbers()
        {
            List<int> actual;
            List<int> expected;

            expected = new List<int>(){};
            actual = LB41.GenerateEvenNumbers(0).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 0 };
            actual = LB41.GenerateEvenNumbers(1).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 0, 2, 4 };
            actual = LB41.GenerateEvenNumbers(3).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Lab_04_01_04()
        {
            List<int> expected = new List<int>() 
                { 2017, 2012, 2007, 2002, 1997, 1992, 1987, 1982, 1977, 1972 };
            List<int> actual = LB41.Lab_04_01_04().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_04_01_05()
        {
            List<int> actual;
            List<int> expected;

            expected = new List<int>() { };
            actual = LB41.Lab_04_01_05(0).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1 };
            actual = LB41.Lab_04_01_05(1).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1, 2 };
            actual = LB41.Lab_04_01_05(2).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1, 2, 5 };
            actual = LB41.Lab_04_01_05(3).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1, 2, 5, 12 };
            actual = LB41.Lab_04_01_05(4).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_04_01_06()
        {
            LB41.Lab_04_01_06(4).PrintSequence();
        }

        // Сгенерируйте с помощью метода последовательность Фибоначчи.
        // Примените его для решения двух предыдущих задач. 
        // В качестве последнего аргумента используем лямбда-выражения.
        [TestMethod]
        public void Lab_04_01_07()
        {
            List<int> actual;
            List<int> expected;

            // Фибоначи
            expected = new List<int>() { };
            actual = LB41.Generate(0, 0, 0, (a1, a2) => (a1 + a2)).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1, 1, 2, 3, 5, 8};
            actual = LB41.Generate(6, 1, 1, (a1, a2) => (a1 + a2)).ToList();
            CollectionAssert.AreEqual(expected, actual);

            // a1 = 1, a2 = 2, ak = ak−2 + 2 * ak−1
            expected = new List<int>() { };
            actual = LB41.Generate(0, 0, 0, (a1, a2) => (a1 + 2 * a2)).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1, 2, 5, 12 };
            actual = LB41.Generate(4, 1, 2, (a1, a2) => (a1 + 2 * a2)).ToList();
            CollectionAssert.AreEqual(expected, actual);

            // a1 = 1, a2 = 2, ak = (ak−2 + 2 * ak−1) / 3
            LB41.Generate<double>(4, 1, 2, (a1, a2) => (a1 + 2 * a2) / 3).PrintSequence();
        }

        [TestMethod]
        public void Cycle()
        {
            List<int> actual;
            List<int> expected;

            expected = new List<int>() { 1, 2, 3, 1, 2, 3};
            actual = LB41.Cycle([1, 2, 3]).Take(6).ToList();
            CollectionAssert.AreEqual(expected, actual);

            expected = new List<int>() { 1, 2, 3, 1, 2, 3, 1 };
            actual = LB41.Cycle([1, 2, 3]).Take(7).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DoubleRange()
        {
            List<double> actual;
            List<double> expected;

            expected = [0, 1.5, 3];
            actual = LB41.DoubleRange(0, 3, 1.5).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        
        [TestMethod]
        public void ApproximateSquareRoots()
        {
            //Сходится на 7м члене
            LB41.ApproximateSquareRoots(4).Take(10).PrintSequence();

            //Сходится на 1м члене
            LB41.ApproximateSquareRoots(4, 2).Take(10).PrintSequence();

            //Сходится на 5м члене
            LB41.ApproximateSquareRoots(4, 3).Take(10).PrintSequence();

            //Сходится на 6м члене
            LB41.ApproximateSquareRoots(4, 4).Take(10).PrintSequence();
        }
    }

    [TestClass]
    public sealed class Lab_04_02_Tests
    {
        [TestMethod]
        public void Lab_04_02_01()
        {
            List<int> actual = [-1, 1, -2, 2];
            List<int> expected = [1, -2];
            actual = actual.Lab_04_02_01().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_04_02_02()
        {
            int actual;
            int expected;
            List<int> seq = [123, 312, 231];

            actual = seq.Lab_04_02_02(0);
            expected = 0;
            Assert.AreEqual(expected, actual);

            actual = seq.Lab_04_02_02(1);
            expected = 231;
            Assert.AreEqual(expected, actual);

            actual = seq.Lab_04_02_02(2);
            expected = 312;
            Assert.AreEqual(expected, actual);

            actual = seq.Lab_04_02_02(3);
            expected = 123;
            Assert.AreEqual(expected, actual);

            //actual = seq.Lab_04_02_02(10);
        }

        [TestMethod]
        public void Lab_04_02_03()
        {
            string actual;
            string exepted;
            List<string> seq = ["qwe", "rty", "q", "y"];

            actual = seq.Lab_04_02_03('e');
            exepted = "qwe";
            Assert.AreEqual(exepted, actual);

            actual = seq.Lab_04_02_03('E');
            exepted = "";
            Assert.AreEqual(exepted, actual);

            actual = seq.Lab_04_02_03('q');
            exepted = "q";
            Assert.AreEqual(exepted, actual);

            actual = seq.Lab_04_02_03('y');
            exepted = "Error";
            Assert.AreEqual(exepted, actual);
        }

        [TestMethod]
        public void Lab_04_02_04()
        {
            int actual;
            int expeqted;
            List<string> seq = ["qwq", "qq", "q", "qw", "wq"];

            actual = seq.Lab_04_02_04('q');
            expeqted = 2;
            Assert.AreEqual(expeqted, actual);

            actual = seq.Lab_04_02_04('w');
            expeqted = 0;
            Assert.AreEqual(expeqted, actual);
        }

        [TestMethod]
        public void Lab_04_02_05()
        {
            int actual = 10;
            int expeqted;
            List<string> seq = ["", "qwq", "qq", "q", "qw", "wq"];
            expeqted = seq.Lab_04_02_05();
            Assert.AreEqual(expeqted, actual);
        }

        [TestMethod]
        public void Lab_04_02_06()
        {
            double actual;
            double expeqted;

            actual = LB42.Lab_04_02_06(0);
            expeqted = 0;
            Assert.AreEqual(expeqted, actual);

            actual = LB42.Lab_04_02_06(1);
            expeqted = 1;
            Assert.AreEqual(expeqted, actual);

            actual = LB42.Lab_04_02_06(2);
            expeqted = 1.5;
            Assert.AreEqual(expeqted, actual);
        }

        [TestMethod]
        public void Lab_04_02_07()
        {
            List<int> actual = new() { -1, 1, -2, 2, 0 };
            List<int> expected = [1, 2];
            actual = actual.Lab_04_02_07().ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Lab_04_02_08()
        {
            List<int> actual = new() { -1, 1, -2, 2, 0, -1, 1, -2, 2};
            List<int> expected = [-1, 1];
            actual = actual.Lab_04_02_08().ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Lab_04_02_09()
        {
            int actual;
            int expected;

            List<int> seq = new() { -1, 1, -2, 2, 0, -1, 1, 3, 2 };
            actual = seq.Lab_04_02_09(3, 8);
            expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_04_02_10()
        {
            List<int> actual = new() { -100, 100, -101, 101, -102, 102, -101, 101 };
            List<int> expected = [0, 1, 2];
            actual = actual.Lab_04_02_10().ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
