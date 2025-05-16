// Лабораторная работа #4 - Последовательности
// Блок заданий 1 - Задачи на генерацию последовательностей
// https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18953


/*
 * 1. Создайте метод расширения
static void PrintSequence<T>(this IEnumerable<T> seq, string delimiter = ", ")
выводящий на консоль все элементы последовательности

2. Создайте метод
static IEnumerable<int> GenerateRandomSequence(int n, int min = -100, int max = 100)
генерирующий последовательность из n случайных чисел в промежутке от min до max.

3. Создайте последовательность из N четных чисел, начиная с 0.

4. Создайте последовательность 2017 2012 2007 2002 1997 1992 1987 1982 1977 1972

5. Создайте последовательность из N целых чисел, заданных итерационным процессом: 
a1 = 1, a2 = 2, ak = ak−2 + 2 * ak−1

6. Создайте последовательность из N вещественных чисел, заданных итерационным процессом: 
a1 = 1, a2 = 2, ak = (ak−2 + 2 * ak−1) / 3

7. Создайте следующий метод, генерирующий последовательность
static IEnumerable<T> Generate<T>(int n, T first, T second, Func<T, T, T> function)
Func<in T1, in T2, out TResult> - тип делегата для вызова метода с двумя параметрами типов T1 и Т2, 
возвращающий TResult. 
Сгенерируйте с помощью метода последовательность Фибоначчи. 
Примените его для решения двух предыдущих задач. В качестве последнего аргумента используем лямбда-выражения.

8. Создать метод
static IEnumerable<T> Cycle<T>(params T[] array)
создающий бесконечную последовательность, в которой раз за разом повторяются элементы массива.

9. Создать метод
static IEnumerable<double> DoubleRange(double min, double max, double step)
создающий последовательность из вещественных чисел, расположенных на интервале [min, max] с интервалом step

10. Создать последовательность, состоящую из приближенных значений квадратного корня заданного числа x, 
найденных по формуле 
ak = (ak−1 + x/ak−1) / 2
 * */


using System.Text;

namespace Lab_04
{
    public static class Lab_04_01
    {

        /// <summary>
        /// 1. Создайте метод расширения выводящий на консоль все элементы последовательности
        /// </summary>
        public static string PrintSequence<T>(this IEnumerable<T> seq, string delimiter = ", ")
        {
            StringBuilder sb = new StringBuilder();

            foreach (T t in seq)
                sb.Append($"{t}{delimiter}");
            //Отрезаем последний разделитель
            sb.Length -= delimiter.Length;

            Console.WriteLine(sb);
            return (sb.ToString());
        }

        /// <summary>
        /// 2. Создайте метод генерирующий последовательность из n случайных чисел в промежутке от min до max.
        /// </summary>
        public static IEnumerable<int> GenerateRandomSequence(int n, int min = -100, int max = 100)
        {
            for(int i = 0; i < n; i++)
                yield return Random.Shared.Next(min, max);
            
        }

        /// <summary>
        /// 3. Создайте последовательность из N четных чисел, начиная с 0.
        /// </summary>
        public static IEnumerable<int> GenerateEvenNumbers(int n)
        {
            for (int i = 0; i < n; i++)
                yield return i * 2;
        }

        /// <summary>
        /// 4. Создайте последовательность 2017 2012 2007 2002 1997 1992 1987 1982 1977 1972
        /// </summary>
        public static IEnumerable<int> Lab_04_01_04()
        {
            for (int i = 2017; i >= 1972; i -= 5)
                yield return i;
        }

        /// <summary>
        /// 5. Создайте последовательность из N целых чисел, заданных итерационным процессом:  <br/>
        /// a1 = 1, a2 = 2, ak = ak−2 + 2 * ak−1
        /// </summary>
        public static IEnumerable<int> Lab_04_01_05(int n)
        {
            int a1 = 1;
            int a2 = 2;
            
            switch (n)
            {
                case 1:
                    yield return a1;
                    yield break;

                case 2:
                    yield return a1;
                    yield return a2;
                    yield break;

                case > 2:
                    yield return a1;
                    yield return a2;
                    for (int i = 3; i <= n; i++)
                    {
                        (a1, a2) = (a2, a1 + 2 * a2);
                        yield return a2;
                    }
                    yield break;
            } 
        }

        /// <summary>
        /// 6. Создайте последовательность из N вещественных чисел, заданных итерационным процессом: <br/>
        /// a1 = 1, a2 = 2, ak = (ak−2 + 2 * ak−1) / 3
        /// </summary>
        public static IEnumerable<double> Lab_04_01_06(int n)
        {
            double a1 = 1;
            double a2 = 2;

            switch (n)
            {
                case 1:
                    yield return a1;
                    yield break;

                case 2:
                    yield return a1;
                    yield return a2;
                    yield break;

                case > 2:
                    yield return a1;
                    yield return a2;
                    for (int i = 3; i <= n; i++)
                    {
                        (a1, a2) = (a2, (a1 + 2 * a2) / 3);
                        yield return a2;
                    }
                    yield break;
            }
        }

        /// <summary>
        /// 7. Создайте метод, генерирующий последовательность
        /// Func<in T1, in T2, out TResult> - тип делегата для вызова метода с двумя параметрами типов T1 и Т2,
        /// возвращающий TResult.
        /// Сгенерируйте с помощью метода последовательность Фибоначчи.
        /// Примените его для решения двух предыдущих задач. 
        /// В качестве последнего аргумента используем лямбда-выражения.
        /// </summary>
        public static IEnumerable<T> Generate<T>(int n, T first, T second, Func<T, T, T> function)
        {
            switch (n)
            {
                case 1:
                    yield return first;
                    yield break;

                case 2:
                    yield return first;
                    yield return second;
                    yield break;

                case > 2:
                    yield return first;
                    yield return second;
                    for (int i = 3; i <= n; i++)
                    {
                        (first, second) = (second, function(first, second));
                        yield return second;
                    }
                    yield break;
            }
        }

        /// <summary>
        /// 8. Создать метод создающий бесконечную последовательность, 
        /// в которой раз за разом повторяются элементы массива.
        /// </summary>
        public static IEnumerable<T> Cycle<T>(params T[] array)
        {
            int length = array.Length;

            for(int i = 0; ; i++)
            {
                if (i == length) i = 0;
                yield return array[i];
            }
        }

        /// <summary>
        /// 9. Создать метод создающий последовательность из вещественных чисел, 
        /// расположенных на интервале[min, max] с интервалом step
        /// </summary>
        public static IEnumerable<double> DoubleRange(double min, double max, double step)
        {
            yield return min;
            while (min < max)
                yield return min += step;
        }

        /// <summary>
        /// 10. Создать последовательность, состоящую из приближенных значений квадратного корня 
        /// заданного числа x, найденных по формуле
        /// ak = (ak−1 + x/ak−1) / 2
        /// </summary>
        /// <remarks>
        /// Итерацио́нная фо́рмула Геро́на <br/>
        /// Итерационная формула задаёт убывающую (начиная со 2-го элемента) последовательность, 
        /// которая при любом выборе a1 быстро сходится к величине x^1/2
        /// </remarks>
        /// <param name="x">Число, корни которого мы ищем </param>
        /// <param name="a1">Произвольное число. Чем ближе к искому корню, 
        /// тем быстрее сходится последовательность</param>
        /// <returns></returns>
        public static IEnumerable<double> ApproximateSquareRoots(double x, double a = 1)
        {
            while(true)
            {
                a = (a + x / a) / 2;
                yield return a;
            }
        }

    }
}
