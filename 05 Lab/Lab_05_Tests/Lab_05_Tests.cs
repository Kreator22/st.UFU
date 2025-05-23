using Lab_05;
using LB5 = Lab_05.Lab_05;

namespace Lab_05_Tests
{
    [TestClass]
    public sealed class Lab_05_Tests
    {
        [TestMethod]
        public void Lab_05_01()
        {
            List<char> expected = ['A', 'B', 'C'];
            List<char> actual = LB5.Lab_05_01(3).ToList();
            CollectionAssert.AreEqual(expected, actual);

            LB5.Lab_05_01(26).ToList();
        }

        [TestMethod]
        public void Lab_05_02()
        {
            int actual;
            int expected;

            actual = LB5.Lab_05_02("abc123abc");
            expected = 3;
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_02("abcabc");
            expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_03()
        {
            string actual;
            string expected;

            expected = "abc";
            actual = LB5.Lab_05_03("___ abc ___");
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_03("___ abc ___ cde ___");
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_03("___ abc ");
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_03(" abc ");
            Assert.AreEqual(expected, actual);

            expected = "";
            actual = LB5.Lab_05_03("  abc");
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_03("abc  ");
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_03("___ abc");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_04()
        {
            string actual;
            string expected;
            string source;

            source = "abcdedcba";
            actual = LB5.Lab_05_04(source, "_", 'c');
            expected = "abc_dedc_ba";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll()
        {
            string actual;
            string expected;
            string source = "abcdedcba";

            actual = source.RemoveAll("c");
            expected = "abdedba";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_06()
        {
            string source;
            string actual;
            string expected;

            source = "abcde";
            actual = "abc";
            expected = "abc  ";
            LB5.Lab_05_06(ref source, ref actual);
            Assert.AreEqual(expected, actual);

            actual = "abc";
            LB5.Lab_05_06(ref actual, ref source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_07()
        {
            string actual;
            string expected;

            actual = LB5.Lab_05_07("0");
            expected = "0";
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_07("1");
            expected = "1";
            Assert.AreEqual(expected, actual);

            actual = LB5.Lab_05_07("2");
            expected = "10";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_08()
        {
            string actual;
            string expected;

            actual = LB5.Lab_05_08("1 2  3   4    2  ");
            expected = "1 2 3 4 2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_09()
        {
            string actual;
            string expected;

            actual = LB5.Lab_05_09("  ЯЯЯ   ЮЮЮ   ААА  ");
            expected = "ААА ЮЮЮ ЯЯЯ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_05_10()
        {
            int actual;
            int expected;

            actual = LB5.Lab_05_10("-1:1:-2:2:5:0");
            expected = 5;
            Assert.AreEqual(expected, actual);
        }
    }
}
