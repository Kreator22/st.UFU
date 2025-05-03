using System.Collections.Generic;
using l21 = Lab_02_01.Lab_02_01;

namespace Lab_02_Tests
{
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
}
