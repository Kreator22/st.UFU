using lb3 = _03_Lab.Lab_03;

namespace Lab_03_Tests
{
    [TestClass]
    public sealed class Lab_03_Tests
    {
        [TestMethod]
        public void PrintArray()
        {
            lb3.PrintArray<int>(new int[] { 1, 2, 3 });
            lb3.PrintArray<double>(new double[] { 1.5, 2.5, 3.5 }, " - ");
        }

        [TestMethod]
        public void RandomIntArray()
        {
            lb3.RandomIntArray();
            lb3.RandomIntArray(5, -5, 5);
        }

        [TestMethod]
        public void RandomDoubleArray()
        {
            lb3.RandomDoubleArray();
            lb3.RandomDoubleArray(5, -5, 5);
        }

        [TestMethod]
        public void Average()
        {
            double actual;

            actual = lb3.Average(new int[] { 1, 2, 3 });
            Assert.AreEqual(2, actual);

            actual = lb3.Average(new int[] { 1, 2, 1, 2 });
            Assert.AreEqual(1.5, actual);
        }

        [TestMethod]
        public void Lab_03_05()
        {
            int[] actual;
            int[] expected;

            actual = [1, 2, 3];
            lb3.Lab_03_05(ref actual);
            expected = [1, 2, 0];
            CollectionAssert.AreEqual(expected, actual);

            actual = [1, 1, 1];
            lb3.Lab_03_05(ref actual);
            expected = [0, 1, 1];
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OddPositive()
        {
            (int, int) actual;

            actual = lb3.OddPositive([1, 2, 3]);
            Assert.AreEqual((2, 3), actual);

            actual = lb3.OddPositive([-1, 0, -1]);
            Assert.AreEqual((2, 0), actual);
        }


        [TestMethod]
        public void Lab_03_07()
        {
            int actual;

            actual = lb3.Lab_03_07([1, 3, 5, 7]);
            Assert.AreEqual(2, actual);

            actual = lb3.Lab_03_07([-1, -3, -5, -7]);
            Assert.AreEqual(-2, actual);

            actual = lb3.Lab_03_07([0, 3, 5, 7]);
            Assert.AreEqual(0, actual);

            actual = lb3.Lab_03_07([1, 3, 5, 6]);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Lab_03_08()
        {
            int[] actual;
            int[] expected;

            actual = lb3.Lab_03_08([1, 2, 3], [3, 2, 1]);
            expected = [3, 2, 3];
            CollectionAssert.AreEqual(expected, actual);

            actual = lb3.Lab_03_08([-1, -2, -3], [-3, -2, -1]);
            expected = [-1, -2, -1];
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_03_09()
        {
            int[] actual;
            int[] expected;

            actual = [1, 2];
            lb3.Lab_03_09(ref actual);
            expected = [2, 1];
            CollectionAssert.AreEqual(expected, actual);

            actual = [1, 2, 3];
            lb3.Lab_03_09(ref actual);
            expected = [3, 2, 1];
            CollectionAssert.AreEqual(expected, actual);

            actual = [-1, 0, -2];
            lb3.Lab_03_09(ref actual);
            expected = [-1, -2, 0];
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_03_10()
        {
            int[] actual;
            int[] expected;

            actual = lb3.Lab_03_10([1, 2]);
            expected = [1, 2, 2];
            CollectionAssert.AreEqual(expected, actual);

            actual = lb3.Lab_03_10([-2, -1, 0, 1, 2]);
            expected = [-2, -2, -1, 0, 0, 1, 2, 2];
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
