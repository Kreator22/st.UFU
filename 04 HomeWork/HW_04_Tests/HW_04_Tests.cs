using HW_04;
using HW4 = HW_04.HW_04;

namespace HW_04_Tests
{
    [TestClass]
    public sealed class HW_04_Tests
    {
        [TestMethod]
        public void HW_04_01()
        {
            List<string> actual = 
                ["a1", "1a", "", "cd2", "2cd", "dc2", "2dc", "ab2", "2ab", "ba2", "2ba"];
            List<string> expected =
                ["ab2", "ba2", "cd2", "dc2"];

            actual = actual.HW_04_01(3).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_02()
        {
            List<int> actual =
                [5, 55, 555, 1, 11, 111, 2, 22, 222, 3, 33, 333, 4, 44, 444];
            List<int> expected =
                [33, 11];
            
            actual = actual.HW_04_02(3).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_03()
        {
            List<int> actual =
                [5, 55, 555, 1, 11, 111, 2, 22, 222, 3, 33, 333, 4, 44, 444];
            List<int> expected =
                [333, 33, 3, 111, 11, 1, 555];

            actual = actual.HW_04_03(111).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_04()
        {
            List<int> actual =
                [1, 1, 2, 9, 3, 10, 4, 1, 2];
            List<int> expected =
                [10, 4, 2, 1];

            actual = actual.HW_04_04(8, 6).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_05()
        {
            List<string> source =
                ["a__", "b__", "b__", "c__"];
            List<char> expected =
                ['c', 'b', 'b', 'a'];

            List<char> actual = source.HW_04_05().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_06()
        {
            List<int> source =
                [4, 3, 2, 1];
            List<string> expected =
                ["1", "3"];

            List<string> actual = source.HW_04_06().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_07()
        {
            List<int> source =
                [4, 3, 2, 1];
            List<string> expected =
                ["1", "3"];

            List<string> actual = source.HW_04_07().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HW_04_08()
        {
            List<int> actual =
                [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
            List<int> expected =
                [81, 64, 49, 36, 25, 16];

            actual = actual.HW_04_08().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void HW_04_09()
        {
            List<int> actual =
                [46, 56, 66, 55, 45, 35];
            List<int> expected =
                [55, 66];

            actual = actual.HW_04_09().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
