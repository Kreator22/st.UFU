using System.Diagnostics;

namespace PerfomanceTests
{
    public static class PerfomanceTests
    {
        /// <summary>
        /// Делегат, тип, экземпляры которого будут хранить ссылки на методы сортировки.
        /// </summary>
        public delegate void SortMethod<T>(ref T[] arr) 
            where T : IComparable;

        public static K Test<T, K>(Func<T, K> method, T parametr)
        {
            Tester tester = new();
            tester.Start();

            K result = method(parametr);

            tester.Stop();
            tester.PrintResult();

            return result;
        }

        public static K Test<T, K>(Func<T, T, K> method, T parametr_1, T parametr_2)
        {
            Tester tester = new();
            tester.Start();

            K result = method(parametr_1, parametr_2);

            tester.Stop();
            tester.PrintResult();

            return result;
        }

        public static K Test<K>(Func<K, K, K> method, K parametr_1, K parametr_2)
        {
            Tester tester = new();
            tester.Start();

            K result = method(parametr_1, parametr_2);

            tester.Stop();
            tester.PrintResult();

            return result;
        }

        public static void Test<T>(Action<T> method, T parametr)
        {
            Tester tester = new();
            tester.Start();

            method(parametr);

            tester.Stop();
            tester.PrintResult();
        }

        public static void Test<T>(SortMethod<T> method, T[] parametr) 
            where T : IComparable
        {
            Tester tester = new();
            tester.Start();

            method(ref parametr);

            tester.Stop();
            tester.PrintResult();
        }
    }

    internal class Tester
    {
        long before;
        long after;
        Stopwatch sw;

        internal void Start()
        {
            before = GC.GetTotalMemory(false);
            sw = Stopwatch.StartNew(); //запускаем таймер
        }

        internal void Stop()
        {
            sw.Stop(); //останавливаем таймер
            after = GC.GetTotalMemory(false);
        }

        internal void PrintResult()
        {
            Console.WriteLine($"Время выполнения операции {sw.ElapsedTicks} тактов");
            Console.WriteLine($"Время выполнения операции {sw.ElapsedMilliseconds} миллисекунд");

            string postfix = "b";
            long divider = 1;
            long consumedInBytes = (after - before);

            const long Kb = 1024;
            const long Mb = 1024 * 1024;

            switch (consumedInBytes)
            {
                case >= Kb and < Mb:
                    divider = Kb;
                    postfix = " Kb";
                    break;
                case >= Mb:
                    divider = Mb;
                    postfix = " Mb";
                    break;
            }

            Console.WriteLine($"Затрачено памяти {consumedInBytes / divider} {postfix}");
            Console.WriteLine();
        }
    }
}
