using LB8 = Lab_08.Lab_08;
using PT = PerfomanceTests.PerfomanceTests;

namespace Lab_08_Tests
{
    [TestClass]
    public sealed class Lab_08_Tests
    {
        [TestMethod]
        public void Lab_08_01()
        {
            Assert.AreEqual(true, LB8.Lab_08_01(""));
            Assert.AreEqual(true, LB8.Lab_08_01("([]{ })[]"));
            Assert.AreEqual(false, LB8.Lab_08_01("([]]"));
            Assert.AreEqual(true, LB8.Lab_08_01("(2 + 2) * 2 * (3 + 3)"));
            Assert.AreEqual(false, LB8.Lab_08_01("(2 + 2 * 2 * (3 + 3)"));
            Assert.AreEqual(false, LB8.Lab_08_01("(2 + 2) * 2 * 3 + 3)"));
        }

        [TestMethod]
        public void Lab_08_02()
        {
            List<int> expected = [1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, 16, 18, 20,
                24, 25, 27, 30, 32, 36, 40, 45, 48, 50, 54, 60, 64, 72, 75, 80];
            List<int> actual = LB8.Lab_08_02(30);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_08_03()
        {
            List<int> source = [2, 1, 2, 3, 4, 5, 6, 7, 8, 9];
            List<int> expected = [1, 3, 5, 7, 9];
            List<int> actual = LB8.Lab_08_03(source);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_08_04()
        {
            List<int> source = [1, 2, 3, 4, 5, 5, 6, 6, 8, 10, 11, 13, 15];
            List<int> expected = [1, 2, 3, 4, 5, 0, 5, 6, 0, 6, 0, 8, 0, 10, 11, 0, 13, 0, 15];
            List<int> actual = LB8.Lab_08_04(source);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_08_05_03()
        {
            LinkedList<int> source = new([2, 1, 2, 3, 4, 5, 6, 7, 8, 9]);
            LinkedList<int> expected = new([1, 3, 5, 7, 9]);
            LinkedList<int> actual = LB8.Lab_08_05_03(source);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lab_08_05_04()
        {
            LinkedList<int> source = new([1, 2, 3, 4, 5, 5, 6, 6, 8, 10, 11, 13, 15]);
            LinkedList<int> expected = new([1, 2, 3, 4, 5, 0, 5, 6, 0, 6, 0, 8, 0, 10, 11, 0, 13, 0, 15]);
            LinkedList<int> actual = LB8.Lab_08_05_04(source);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 6. Продемонстрировать использование классов List и LinkedList на примере следующего сценария:
        /// Генерируется длинный(100000 элементов) список случайных целых чисел.
        /// Выполняется проход по списку и из списка удаляются все числа, делящиеся на первый элемент.
        /// Между любыми двумя элементами одной чётности вставляется число 0.
        /// Организуйте сравнение времени решения предыдущей задачи с помощью классов List и LinkedList.
        /// </summary>
        [TestMethod]
        public void Lab_08_06()
        {
            int[] source = new int[500000];

            for (int i = 0; i < source.Length; i++)
                source[i] = Random.Shared.Next();
            source[0] = 3;

            List<int> sourceList = source.ToList();

            Console.WriteLine("List - удаление чисел делящихся на 3");
            sourceList = PT.Test(LB8.Lab_08_03, sourceList);
            Console.WriteLine("List - добавление 0 между элементами одинаковой чётности");
            sourceList = PT.Test(LB8.Lab_08_04, sourceList);

            LinkedList<int> sourceLinkedList = new(source);

            Console.WriteLine("LinkedList - удаление чисел делящихся на 3");
            sourceLinkedList = PT.Test(LB8.Lab_08_05_03, sourceLinkedList);
            Console.WriteLine("LinkedList - добавление 0 между элементами одинаковой чётности");
            sourceLinkedList = PT.Test(LB8.Lab_08_05_04, sourceLinkedList);
        }

        [TestMethod]
        public void Lab_08_07()
        {
            string direcrory = Directory.GetCurrentDirectory();
            Console.WriteLine(direcrory);

            string path1 = Path.Combine(direcrory, "Lab_08_07_01.txt");
            string path2 = Path.Combine(direcrory, "Lab_08_07_02.txt");

            List<string> names = LB8.Lab_08_07(path1, path2);

            foreach (string name in names)
                Console.WriteLine(name);
        }

        [TestMethod]
        public void Lab_08_08()
        {
            string direcrory = Directory.GetCurrentDirectory();
            Console.WriteLine(direcrory);

            string path = Path.Combine(direcrory, "Lab_08_08.txt");

            Console.WriteLine(LB8.Lab_08_08(path));
        }

        [TestMethod]
        public void Lab_08_0910()
        {
            string direcrory = Directory.GetCurrentDirectory();
            Console.WriteLine(direcrory);

            string path = Path.Combine(direcrory, "Lab_08_0910_01.txt");
            LB8.Lab_08_0910(path);
            Console.WriteLine();

            path = Path.Combine(direcrory, "Lab_08_0910_02.txt");
            LB8.Lab_08_0910(path);

        }
    }
}
