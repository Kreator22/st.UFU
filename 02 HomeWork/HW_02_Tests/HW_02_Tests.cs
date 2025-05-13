//Домашнее задание #2, индивидуальное задание 1
using System.Diagnostics;
using HW21 = HW_02.HW_02_01;
//Домашнее задание #2, индивидуальное задание 2
using HW22 = HW_02.HW_02_02;

using Tests = PerfomanceTests.PerfomanceTests;

namespace HW_02_Tests
{
    [TestClass]
    public sealed class HW_02_01_Tests
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

    [TestClass]
    public sealed class HW_02_02_Tests
    {
        [TestMethod]
        public void HW_02_02_01()
        {
            int actual;

            actual = HW22.HW_02_02_01(1, 2, 3);
            Assert.AreEqual(2, actual);

            actual = HW22.HW_02_02_01(-1, -2, -3);
            Assert.AreEqual(-2, actual);

            actual = HW22.HW_02_02_01(0, 10, 5);
            Assert.AreEqual(5, actual);

            actual = HW22.HW_02_02_01(5, 10, 0);
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void HW_02_02_02()
        {
            double a;
            double b;
            double c;

            (a, b, c) = (1, 2, 3);
            HW22.HW_02_02_02(ref a, ref b, ref c);
            Assert.AreEqual((2, 4, 6), (a, b, c));

            (a, b, c) = (3, 2, 1);
            HW22.HW_02_02_02(ref a, ref b, ref c);
            Assert.AreEqual((6, 4, 2), (a, b, c));

            (a, b, c) = (3.5, 2, 7);
            HW22.HW_02_02_02(ref a, ref b, ref c);
            Assert.AreEqual((7, 2, 3.5), (a, b, c));
        }

        [TestMethod]
        public void HW_02_02_03()
        {
            string actual;
            string expected;

            expected = "Нечетное однозначное число";
            actual = HW22.HW_02_02_03(1);
            Assert.AreEqual(expected, actual);

            expected = "Четное однозначное число";
            actual = HW22.HW_02_02_03(2);
            Assert.AreEqual(expected, actual);

            expected = "Нечетное двузначное число";
            actual = HW22.HW_02_02_03(11);
            Assert.AreEqual(expected, actual);

            expected = "Четное двузначное число";
            actual = HW22.HW_02_02_03(12);
            Assert.AreEqual(expected, actual);

            expected = "Нечетное трехзначное число";
            actual = HW22.HW_02_02_03(101);
            Assert.AreEqual(expected, actual);

            expected = "Четное трехзначное число";
            actual = HW22.HW_02_02_03(102);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_02_02_04()
        {
            double actual;

            actual = HW22.HW_02_02_04(1, 1);
            Assert.AreEqual(0, actual);

            actual = HW22.HW_02_02_04(1, 2);
            Assert.AreEqual(1, actual);

            actual = HW22.HW_02_02_04(2, 3);
            Assert.AreEqual(-5, actual);

            actual = HW22.HW_02_02_04(0, 0);
            Assert.AreEqual(1, actual);

            actual = HW22.HW_02_02_04(2, 0);
            Assert.AreEqual(1, actual);

            actual = HW22.HW_02_02_04(0, 2);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void HW_02_02_05()
        {
            double actual;

            actual = HW22.HW_02_02_05(1);
            Assert.AreEqual(1, actual);

            actual = HW22.HW_02_02_05(2);
            Assert.AreEqual(1.5, actual);

            actual = HW22.HW_02_02_05(3);
            Assert.AreEqual(1.6666666666666667, actual);
        }

        [TestMethod]
        public void HW_02_02_06()
        {
            bool actual;

            actual = HW22.HW_02_02_06(0);
            Assert.AreEqual(false, actual);

            actual = HW22.HW_02_02_06(-2);
            Assert.AreEqual(false, actual);

            actual = HW22.HW_02_02_06(111);
            Assert.AreEqual(true, actual);

            actual = HW22.HW_02_02_06(222);
            Assert.AreEqual(false, actual);

            actual = HW22.HW_02_02_06(int.MinValue);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void HW_02_02_07()
        {
            long actual;

            actual = HW22.HW_02_02_07_01(125, 10);
            Assert.AreEqual(5, actual);

            actual = HW22.HW_02_02_07_01(15, 10);
            Assert.AreEqual(5, actual);

            actual = HW22.HW_02_02_07_01(28399689500, 80484950000);
            Assert.AreEqual(114978500, actual);

            actual = HW22.HW_02_02_07_01(1, 1);
            Assert.AreEqual(1, actual);

            actual = HW22.HW_02_02_07_02(28399689500, 80484950000);
            Assert.AreEqual(114978500, actual);

            Console.WriteLine("Решение без рекурсии");
            Tests.Test<long>(HW22.HW_02_02_07_01, long.MaxValue, 28399689500);

            Console.WriteLine();
            Console.WriteLine("Рекурсивное решение");
            Tests.Test<long>(HW22.HW_02_02_07_02, long.MaxValue, 28399689500);
        }

        
    }
}
