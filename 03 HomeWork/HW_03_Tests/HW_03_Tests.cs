using static PerfomanceTests.PerfomanceTests;
using HW3 = HW_03.HW_03_01;
using LB3 = _03_Lab.Lab_03;
using PT = PerfomanceTests.PerfomanceTests;

namespace HW_03_Tests
{
    

    [TestClass]
    public sealed class HW_03_Tests
    {
        /// <summary>
        /// Делегат, тип, экземпляры которого будут хранить ссылки на методы сортировки.
        /// </summary>
        //public delegate void SortMethod(ref int[] arr);

        [TestMethod]
        public void BubbleSort()
        {
            TestSorts(HW3.BubbleSort);
        }

        [TestMethod]
        public void SelectionSortMax()
        {
            TestSorts(HW3.SelectionSortMax);
        }

        [TestMethod]
        public void SelectionSortMin()
        {
            TestSorts(HW3.SelectionSortMin);
        }

        [TestMethod]
        public void MakeItSorted()
        {
            int[] actual = [1, 2, 3, 4, 5, 6, 7, 8, 10, 9]; ;
            int[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            HW3.MakeItSorted(ref actual);
            CollectionAssert.AreEqual(expected, actual);

            actual = [2, 3, 4, 5, 6, 7, 8, 9, 10, 1]; ;
            expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            HW3.MakeItSorted(ref actual);
            CollectionAssert.AreEqual(expected, actual);

            actual = [1, 2, 3, 2]; ;
            expected = [1, 2, 2, 3];
            HW3.MakeItSorted(ref actual);
            CollectionAssert.AreEqual(expected, actual);

            actual = [1, 2, 3, 1]; ;
            expected = [1, 1, 2, 3];
            HW3.MakeItSorted(ref actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertSort()
        {
            TestSorts(HW3.InsertSort);
        }

        [TestMethod]
        public void CheckPerformance()
        {
            SortMethod<int> methods;
            List<string> names = new();

            methods = HW3.BubbleSort;
            names.Add("Пузырьковая сортировка");

            methods += HW3.SelectionSortMax;
            names.Add("Сортировка выбором через поиск максимального");

            methods += HW3.SelectionSortMin;
            names.Add("Сортировка выбором через поиск минимльного");

            methods += HW3.InsertSort;
            names.Add("Сортировка вставками");

            CheckPerfomance(methods, names, 20000);
        }

        public void TestSorts(SortMethod<int> sort)
        {
            int[] actual = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]; ;
            int[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            for (int i = 0; i < 1000; i++)
            {
                Random.Shared.Shuffle(actual);
                Print(actual);
                sort(ref actual);
                Print(actual);
                CollectionAssert.AreEqual(expected, actual);
                Console.WriteLine();
            }

            void Print(int[] arr)
            {
                foreach (int i in arr)
                    Console.Write($"{i}, ");
                Console.WriteLine();
            }

            actual = [2, 1];
            expected = [1, 2];
            Print(actual);
            sort(ref actual);
            Print(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Сравнение методов сортировки для массива заданной длинны
        /// </summary>
        /// <param name="methods">Делегат со ссылками на методы сортировки</param>
        /// <param name="names">Названия методов сортировки</param>
        /// <param name="size">Размер массива для тестирования методово сортировки</param>
        public void CheckPerfomance(SortMethod<int> methods, IEnumerable<string> names, int size)
        {
            if (methods is null) return;

            //Вытаскиваем методы из делегата и складываем в массив
            Delegate[] methods_arr = methods.GetInvocationList();
            int i = 0;

            foreach(SortMethod<int> method in methods_arr)
            {
                int[] arr = LB3.RandomIntArray(size, int.MinValue, int.MaxValue);
                Console.WriteLine(names.ElementAt(i++));
                Console.WriteLine(method.Method.Name);
                PT.Test(method, arr);
            }
        }
    }
}
