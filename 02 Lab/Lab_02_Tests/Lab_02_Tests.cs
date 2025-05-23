﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;


//Лабораторная работа #2, блок задач 1
using l21 = Lab_02_01.Lab_02_01;
//Лабораторная работа #2, блок задач 2, класс 1
using l221 = Lab_02_02.Lab_02_02_01;
//Лабораторная работа #2, блок задач 2, класс 2
using l222 = Lab_02_02.Lab_02_02_02;
//Лабораторная работа #2, блок задач 3
using l23 = Lab_02_03.Lab_02_03;

namespace Lab_02_Tests
{
    /// <summary>
    /// Лабораторная работа #2, блок задач 1 - условный оператор
    /// </summary>
    [TestClass]
    public sealed class Lab_02_01_Tests
    {

        [TestMethod]
        public void Lab_02_01_01()
        {
            int actual;

            actual = l21.Lab_02_01_01(-1);
            Assert.AreEqual(-1, actual);

            actual = l21.Lab_02_01_01(0);
            Assert.AreEqual(0, actual);

            actual = l21.Lab_02_01_01(1);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Lab_02_01_02()
        {
            int actual;

            actual = l21.Lab_02_01_02(-1);
            Assert.AreEqual(1, actual);

            actual = l21.Lab_02_01_02(0);
            Assert.AreEqual(2, actual);

            actual = l21.Lab_02_01_02(1);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Lab_02_01_03()
        {
            int actual;

            actual = l21.Lab_02_01_03(-1);
            Assert.AreEqual(1, actual);

            actual = l21.Lab_02_01_03(0);
            Assert.AreEqual(10, actual);

            actual = l21.Lab_02_01_03(1);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Lab_02_01_04()
        {
            int a = 1, b = 1;

            l21.Lab_02_01_04(ref a, ref b);
            Assert.AreEqual(0, a);
            Assert.AreEqual(0, b);

            a = 1;
            b = 2;
            l21.Lab_02_01_04(ref a, ref b);
            Assert.AreEqual(3, a);
            Assert.AreEqual(3, b);
        }
        [TestMethod]
        public void Lab_02_01_05()
        {
            int actual;

            actual = l21.Lab_02_01_05(-1, -1, -1);
            Assert.AreEqual(0, actual);

            actual = l21.Lab_02_01_05(0, 0, 0);
            Assert.AreEqual(0, actual);

            actual = l21.Lab_02_01_05(1, 1, 1);
            Assert.AreEqual(3, actual);
        }
        [TestMethod]
        public void Lab_02_01_06()
        {
            int a = 1, b = 0, c;

            l21.Lab_02_01_06(ref a, ref b);
            Assert.AreEqual(0, a);
            Assert.AreEqual(1, b);

            l21.Lab_02_01_06(ref a, ref b);
            Assert.AreEqual(0, a);
            Assert.AreEqual(1, b);

            (a, b, c) = (1, 2, 3);
            l21.Lab_02_01_06(ref a, ref b, ref c);
            Assert.AreEqual((1, 3, 2), (a, b, c));

            (a, b, c) = (1, 3, 2);
            l21.Lab_02_01_06(ref a, ref b, ref c);
            Assert.AreEqual((1, 3, 2), (a, b, c));

            (a, b, c) = (2, 1, 3);
            l21.Lab_02_01_06(ref a, ref b, ref c);
            Assert.AreEqual((1, 3, 2), (a, b, c));

            (a, b, c) = (2, 3, 1);
            l21.Lab_02_01_06(ref a, ref b, ref c);
            Assert.AreEqual((1, 3, 2), (a, b, c));

            (a, b, c) = (3, 1, 2);
            l21.Lab_02_01_06(ref a, ref b, ref c);
            Assert.AreEqual((1, 3, 2), (a, b, c));

            (a, b, c) = (3, 2, 1);
            l21.Lab_02_01_06(ref a, ref b, ref c);
            Assert.AreEqual((1, 3, 2), (a, b, c));
        }

        [TestMethod]
        public void Lab_02_01_07()
        {
            int actual;

            actual = l21.Lab_02_01_07(0, 1);
            Assert.AreEqual(-1, actual);

            actual = l21.Lab_02_01_07(2, 0);
            Assert.AreEqual(-2, actual);

            actual = l21.Lab_02_01_07(2, 3);
            Assert.AreEqual(13, actual);

            actual = l21.Lab_02_01_07(-2, -3);
            Assert.AreEqual(13, actual);

            actual = l21.Lab_02_01_07(2, -3);
            Assert.AreEqual(12, actual);

            actual = l21.Lab_02_01_07(-2, 3);
            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void Lab_02_01_08()
        {
            int actual;

            actual = l21.Lab_02_01_08(1, 2, 3);
            Assert.AreEqual(5, actual);
        }
    }

    /// <summary>
    /// Лабораторная работа #2, блок задач 2 - перечисления и оператор выбора
    /// </summary>
    [TestClass]
    public sealed class Lab_02_02_Tests
    {
        [TestMethod]
        public void Lab_02_02_01()
        {
            int actual;

            actual = l221.Days(l221.Months.Январь);
            Assert.AreEqual(31, actual);
        }
        [TestMethod]
        public void Lab_02_02_02()
        {
            double actual;

            actual = l222.Meters(1, 10);
            Assert.AreEqual(1, actual);

            actual = l222.Meters(2, 1.5);
            Assert.AreEqual(1500, actual);

            actual = l222.Meters(3, 666);
            Assert.AreEqual(666, actual);

            actual = l222.Meters(4, 1100);
            Assert.AreEqual(1.1, actual);

            actual = l222.Meters(5, 150);
            Assert.AreEqual(1.5, actual);
        }
    }
    /// <summary>
    /// Лабораторная работа #2, блок задач 3 - циклы
    /// </summary>
    [TestClass]
    public sealed class Lab_02_03_Tests
    {
        [TestMethod]
        public void Lab_02_03_01()
        {
            bool equality;
            int actual;
            IEnumerable<int> IEactual;

            (IEactual, actual) = l23.Lab_02_03_01(1, 5);
            IEnumerable<int> IEExpected = [2, 3, 4];

            equality = Enumerable.SequenceEqual(IEactual, IEExpected);
            Assert.AreEqual((true, 3), (equality, actual));

            (IEactual, actual) = l23.Lab_02_03_01(0, 1);
            IEExpected = [];

            equality = Enumerable.SequenceEqual(IEactual, IEExpected);
            Assert.AreEqual((true, 0), (equality, actual));

            (IEactual, actual) = l23.Lab_02_03_01(0, 0);
            IEExpected = [];

            equality = Enumerable.SequenceEqual(IEactual, IEExpected);
            Assert.AreEqual((true, 0), (equality, actual));

            (IEactual, actual) = l23.Lab_02_03_01(1, 0);
            IEExpected = [];

            equality = Enumerable.SequenceEqual(IEactual, IEExpected);
            Assert.AreEqual((true, 0), (equality, actual));

            (IEactual, actual) = l23.Lab_02_03_01(-5, 1);
            IEExpected = [-4, -3, -2, -1, 0];

            equality = Enumerable.SequenceEqual(IEactual, IEExpected);
            Assert.AreEqual((true, 5), (equality, actual));

            (IEactual, actual) = l23.Lab_02_03_01(-5, -1);
            IEExpected = [-4, -3, -2];

            equality = Enumerable.SequenceEqual(IEactual, IEExpected);
            Assert.AreEqual((true, 3), (equality, actual));

            //foreach (var s in IEactual) Console.WriteLine(s);
        }
        [TestMethod]
        public void Lab_02_03_02()
        {
            double actual;

            actual = l23.Lab_02_03_02(1);
            Assert.AreEqual(1.0, actual);

            actual = l23.Lab_02_03_02(2);
            Assert.AreEqual(1.5, actual);

            actual = l23.Lab_02_03_02(6);
            Assert.AreEqual(2.45, actual);
        }

        [TestMethod]
        public void Lab_02_03_03()
        {
            double actual;

            actual = l23.Lab_02_03_03(1, 2);
            Assert.AreEqual(2, actual);

            actual = l23.Lab_02_03_03(0, 2);
            Assert.AreEqual(0, actual);

            actual = l23.Lab_02_03_03(0, 0);
            Assert.AreEqual(0, actual);

            actual = l23.Lab_02_03_03(2, 5);
            Assert.AreEqual(120, actual);

            actual = l23.Lab_02_03_03(-1, 1);
            Assert.AreEqual(0, actual);

            actual = l23.Lab_02_03_03(-5, -2);
            Assert.AreEqual(120, actual);

            actual = l23.Lab_02_03_03(-5, -1);
            Assert.AreEqual(-120, actual);
        }

        [TestMethod]
        public void Lab_02_03_04()
        {
            double actual;
            double expected;
            double delta = 0.000000000000001;

            actual = l23.Lab_02_03_04(0, 1);
            expected = Math.Pow(Math.E, 0);
            Assert.AreEqual(expected, actual);

            actual = l23.Lab_02_03_04(0, 5000);
            expected = Math.Pow(Math.E, 0);
            Assert.AreEqual(expected, actual);

            actual = l23.Lab_02_03_04(1, 50);
            expected = Math.Pow(Math.E, 1);
            Assert.AreEqual(expected, actual, delta);

            actual = l23.Lab_02_03_04(1, 1);
            expected = Math.Pow(Math.E, 1);
            Assert.AreNotEqual(expected, actual, delta);

            delta = 0.00000000001;
            actual = l23.Lab_02_03_04(10, 500);
            expected = Math.Pow(Math.E, 10);
            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void Lab_02_03_05()
        {
            decimal actual;

            actual = l23.Lab_02_03_05(10, 1);
            Assert.AreEqual(0, actual);

            actual = l23.Lab_02_03_05(10, 3);
            Assert.AreEqual(1, actual);

            actual = l23.Lab_02_03_05(10, 1.1m);
            Assert.AreEqual(0.1m, actual);
        }

        [TestMethod]
        public void Lab_02_03_06()
        {
            int actual;

            actual = l23.Lab_02_03_06_02(1);
            Assert.AreEqual(1, actual);

            actual = l23.Lab_02_03_06_02(2);
            Assert.AreEqual(1, actual);

            actual = l23.Lab_02_03_06_02(3);
            Assert.AreEqual(2, actual);

            actual = l23.Lab_02_03_06_02(4);
            Assert.AreEqual(3, actual);

            actual = l23.Lab_02_03_06_02(5);
            Assert.AreEqual(5, actual);

            actual = l23.Lab_02_03_06_02(6);
            Assert.AreEqual(8, actual);

            Console.WriteLine();
            Console.WriteLine("Рекурсивное решение");
            actual = PerformanceTests<int, int>(l23.Lab_02_03_06_01, 40);

            Console.WriteLine("Решение без рекурсии");
            actual = PerformanceTests<int, int>(l23.Lab_02_03_06_02, 40);
            Assert.AreEqual(102334155, actual);
        }


        public K PerformanceTests<T, K>(Func<T, K> method, T parametr)
        {
            long before = GC.GetTotalMemory(false);
            Stopwatch sw = Stopwatch.StartNew(); //запускаем таймер

            K result = method(parametr);

            sw.Stop(); //останавливаем таймер
            long after = GC.GetTotalMemory(false);

            Console.WriteLine($"Время выполнения операции { sw.ElapsedTicks} тактов");
            Console.WriteLine($"Время выполнения операции {sw.ElapsedMilliseconds} миллисекунд");

            string postfix = "b";
            long divider = 1;
            long consumedInBytes = (after - before);

            const long Kb = 1024;
            const long Mb = 1024 * 1024;

            switch (consumedInBytes)
            {
                case > Kb and < Mb:
                    divider = Kb;
                    postfix = " Kb";
                    break;
                case > Mb:
                    divider = Mb;
                    postfix = " Mb";
                    break;
            }

            Console.WriteLine($"Затрачено памяти {consumedInBytes / divider} {postfix}");
            Console.WriteLine();
            return result;
        }

        [TestMethod]
        public void Lab_02_03_07()
        {
            int actual_quotient;
            int actual_remainder;
            int expected_quotient;
            int expected_remainder;

            (actual_quotient, actual_remainder) = l23.Lab_02_03_07(10, 3);
            (expected_quotient, expected_remainder) = int.DivRem(10, 3);

            Assert.AreEqual(
                (expected_quotient, expected_remainder), 
                (actual_quotient, actual_remainder)
                );
        }

        [TestMethod]
        public void Lab_02_03_08()
        {
            bool actual;

            actual = l23.Lab_02_03_08(27);
            Assert.AreEqual(true, actual);

            actual = l23.Lab_02_03_08(28);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Lab_02_03_09()
        {
            int actual_quantity;
            int actual_sum;

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(5);
            Assert.AreEqual((1, 5), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(125);
            Assert.AreEqual((3, 8), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(999);
            Assert.AreEqual((3, 27), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(1111);
            Assert.AreEqual((4, 4), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(0);
            Assert.AreEqual((1, 0), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(-5);
            Assert.AreEqual((1, 5), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(-125);
            Assert.AreEqual((3, 8), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(-999);
            Assert.AreEqual((3, 27), (actual_quantity, actual_sum));

            (actual_quantity, actual_sum) = l23.Lab_02_03_09_01(-1111);
            Assert.AreEqual((4, 4), (actual_quantity, actual_sum));

            Console.WriteLine("Решение через деление на 10");
            PerformanceTests<int, (int, int)>(l23.Lab_02_03_09_01, int.MaxValue);

            Console.WriteLine("Решение через преобразование в строку");
            PerformanceTests<int, (int, int)>(l23.Lab_02_03_09_02, int.MaxValue);
        }

        [TestMethod]
        public void Lab_02_03_10()
        {
            byte[] b_actual;
            int actual;

            b_actual = l23.Lab_02_03_10(0);
            actual = Bytes_To_Int(b_actual);
            Assert.AreEqual(0, actual);

            b_actual = l23.Lab_02_03_10(1);
            actual = Bytes_To_Int(b_actual);
            Assert.AreEqual(1, actual);

            b_actual = l23.Lab_02_03_10(255);
            actual = Bytes_To_Int(b_actual);
            Assert.AreEqual(255, actual);

            b_actual = l23.Lab_02_03_10(256);
            actual = Bytes_To_Int(b_actual);
            Assert.AreEqual(256, actual);

            b_actual = l23.Lab_02_03_10(257);
            actual = Bytes_To_Int(b_actual);
            Assert.AreEqual(257, actual);

            b_actual = l23.Lab_02_03_10(int.MaxValue);
            actual = Bytes_To_Int(b_actual);
            Assert.AreEqual(int.MaxValue, actual);

            int Bytes_To_Int(byte[] bytes)
            {
                int result = 0;

                for (int i = 0; i < bytes.Length; i++)
                    result += bytes[i] << i * 8;

                return result;
            }
        }
    }
}

