//Домашнее задание #2, индивидуальное задание 1
using HW21 = HW_02.HW_02_01;

namespace HW_02_Tests
{
    [TestClass]
    public sealed class HW_02_Tests
    {
        [TestMethod]
        public void HW_02_01_01()
        {
            int actual;

            actual = HW21.HW_02_01_01(-1, 0, 1);
            Assert.AreEqual(-1, actual);

            actual = HW21.HW_02_01_01(300, 200, 100);
            Assert.AreEqual(100, actual);
        }

        [TestMethod]
        public void HW_02_01_02()
        {
            double a;
            double b;
            double c;

            (a, b, c) = (1, 2, 3);
            HW21.HW_02_01_02(ref a, ref b, ref c);
            Assert.AreEqual((2, 4, 6), (a, b, c));

            (a, b, c) = (3.5, 2, 0);
            HW21.HW_02_01_02(ref a, ref b, ref c);
            Assert.AreEqual((0, 2, 3.5), (a, b, c));
        }

        [TestMethod]
        public void HW_02_01_03()
        {
            string actual;
            string expected;

            expected = "Нулевое число";
            actual = HW21.HW_02_01_03(0);
            Assert.AreEqual(expected, actual);

            expected = "Положительное четное число";
            actual = HW21.HW_02_01_03(2);
            Assert.AreEqual(expected, actual);

            expected = "Положительное нечетное число";
            actual = HW21.HW_02_01_03(1);
            Assert.AreEqual(expected, actual);

            expected = "Отрицательное четное число";
            actual = HW21.HW_02_01_03(-2);
            Assert.AreEqual(expected, actual);

            expected = "Отрицательное нечетное число";
            actual = HW21.HW_02_01_03(-1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_02_01_04()
        {
            double actual;

            actual = HW21.HW_02_01_04(1, 1);
            Assert.AreEqual(2, actual);

            actual = HW21.HW_02_01_04(1, 2);
            Assert.AreEqual(3, actual);

            actual = HW21.HW_02_01_04(2, 3);
            Assert.AreEqual(15, actual);

            actual = HW21.HW_02_01_04(0, 0);
            Assert.AreEqual(1, actual);

            actual = HW21.HW_02_01_04(2, 0);
            Assert.AreEqual(1, actual);

            actual = HW21.HW_02_01_04(0, 2);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void HW_02_01_05()
        {
            double actual;

            actual = HW21.HW_02_01_05(1);
            Assert.AreEqual(1, actual);

            actual = HW21.HW_02_01_05(2);
            Assert.AreEqual(3, actual);

            actual = HW21.HW_02_01_05(5);
            Assert.AreEqual(153, actual);

            actual = HW21.HW_02_01_05(10);
            Assert.AreEqual(4037913, actual);
        }

        [TestMethod]
        public void HW_02_01_06()
        {
            bool actual;

            actual = HW21.HW_02_01_06(0);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_06(-2);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_06(111);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_06(112);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_06(int.MinValue);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void HW_02_01_07()
        {
            bool actual;

            actual = HW21.HW_02_01_07(2);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_07(3);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_07(4);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_07(5);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_07(6);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_07(7);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_07(8);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_07(9);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_07(10);
            Assert.AreEqual(false, actual);

            actual = HW21.HW_02_01_07(127);
            Assert.AreEqual(true, actual);

            actual = HW21.HW_02_01_07(240);
            Assert.AreEqual(false, actual);
        }

    }
}
