using System.Diagnostics;

namespace PerfomanceTests
{
    public static class PerfomanceTests
    {
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
