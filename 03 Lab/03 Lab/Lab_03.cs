// Лабораторная работа #3 - Массивы
// https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18921

/*
1. Создать обобщенный метод, который выводит на консоль все элементы массива 
с использованием разделителя. (Обратите внимание на необязательный параметр delimiter)
static void PrintArray<T>(T[] array, string delimiter = ", ")
Продемонстрировать использование метода для различных типов данных и различных значений разделителя.
PrintArray(new int[] { 1, 2, 3, 4, 5 });
PrintArray(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 });


2. Создать метод
static int[] RandomIntArray(int size = 10, int min = -10, int max = 10)
создающий массив, заполненный случайными целыми числами в диапазоне от min до max.
Указание 1. Создать в классе приложения объект типа Random
static Random random = new Random();
Указание 2. Для генерации случайного целого числа используем метод Next(min, max)

3. Создать метод
static double[] RandomDoubleArray(int size = 10, double min = 0.0, double max = 1.0)
создающий массив, заполненный случайными вещественными числами в диапазоне от min до max.
Указание Для генерации случайного числа используем метод NextDouble()

4. Создать метод с переменным числом параметров
static double Average(params int[] numbers)
возвращающий среднее арифметическое чисел, переданных в качестве параметра. 
Продемонстрировать использование.
Console.WriteLine(Average(1,2,3));
Console.WriteLine(Average(1, 2, 3, 4));
Console.WriteLine(Average(1, 2, 3, 4, 5));

5. Дан массив целых чисел. Написать метод, которая находит и обнуляет максимальный элемент.

6. Дан массив целых чисел. Вычислить количество нечётных чисел в данном массиве, 
а также количество положительных чисел в нём. 
Для того, чтобы вернуть результат, используем кортеж
private static (int odd, int positive) OddPositive(int[] array)
Результат отображаем так:
var array = RandomIntArray();
PrintArray(array);
var (odd, positive) = OddPositive(array);
Console.WriteLine($"Нечётных элементов - {odd}");
Console.WriteLine($"Положительных элементов - {positive}");

7. Дан целочисленный массив размера N. 
Проверить, образуют ли его элементы арифметическую прогрессию. 
Если образуют, то вывести разность прогрессии, если нет — вывести 0.

8. Даны два массива A и B одинакового размера. 
Сформировать новый массив того же размера, каждый элемент которого 
равен максимальному из элементов массивов A и B с тем же индексом.

9. Дан массив целых чисел. Поменять местами его минимальный и максимальный элементы.

10. Дан целочисленный массив. Продублировать в нем все четные числа.*/

using System.Collections;
using System;

namespace _03_Lab
{
    public class Lab_03
    {
        /// <summary>
        /// 1. Создать обобщенный метод, который выводит на консоль 
        /// все элементы массива с использованием разделителя.
        /// </summary>
        static public void PrintArray<T>(T[] array, string delimiter = ", ")
        {
            foreach (T t in array)
                Console.Write($"{t}{delimiter}");
            Console.WriteLine();
        }

        /// <summary>
        /// Создать метод создающий массив, 
        /// заполненный случайными целыми числами в диапазоне от min до max.
        /// </summary>
        static public int[] RandomIntArray(int size = 10, int min = -10, int max = 10)
        {
            int[] arr = new int[size];
            Random r = new();

            Array.ForEach(arr, i =>
            {
                i = r.Next(min, max);
                Console.Write($"{i}, ");
            });

            Console.WriteLine();
            return arr;
        }

        /// <summary>
        /// 3. Создать метод создающий массив, 
        /// заполненный случайными вещественными числами в диапазоне от min до max.
        /// </summary>
        static public double[] RandomDoubleArray(int size = 10, double min = 0.0, double max = 1.0)
        {
            double[] arr = new double[size];
            Random r = new();

            Array.ForEach(arr, i =>
            {
                i = r.NextDouble() * (max - min);
                i += min >= 0 ? -min : min;
                Console.Write($"{i}, ");
            });

            Console.WriteLine();
            return arr;
        }

        /// <summary>
        /// 4. Создать метод с переменным числом параметров 
        /// возвращающий среднее арифметическое чисел, переданных в качестве параметра.
        /// </summary>
        static public double Average(params int[] numbers)
        {
            long sum = 0;

            foreach (int n in numbers)
                sum += n;

            return (double)sum / numbers.Length;
        }

        /// <summary>
        /// 5. Дан массив целых чисел. Написать метод, которая находит и обнуляет максимальный элемент.
        /// </summary>
        static public void Lab_03_05(ref int[] arr)
        {
            // Значение максимального элемента
            int max = int.MinValue;
            //порядковый номер максимального элемента
            int n = 0;

            for(int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                {
                    max = arr[i];
                    n = i;
                }

            arr[n] = 0;
        }

        /// <summary>
        /// Дан массив целых чисел. Вычислить количество нечётных чисел в данном массиве, 
        /// а также количество положительных чисел в нём.
        /// </summary>
        public static (int odd, int positive) OddPositive(int[] array)
        {
            int odd = 0;
            int positive = 0;

            foreach(int i in array)
            {
                if (i % 2 != 0) odd++;
                if (i > 0) positive++;
            }

            return (odd, positive);
        }

        /// <summary>
        /// 7. Дан целочисленный массив размера N. <br/>
        /// Проверить, образуют ли его элементы арифметическую прогрессию. <br/>
        /// Если образуют, то вывести разность прогрессии, если нет — вывести 0. <br/>
        /// </summary>
        static public int Lab_03_07(int[] arr)
        {
            int difference = arr[1] - arr[0];

            for (int i = 2; i < arr.Length; i++)
                if (arr[i] - arr[i - 1] != difference)
                    return 0;

            return difference;
        }

        /// <summary>
        /// 8. Даны два массива A и B одинакового размера.  <br/>
        /// Сформировать новый массив того же размера, каждый элемент которого
        /// равен максимальному из элементов массивов A и B с тем же индексом.
        /// </summary>
        static public int[] Lab_03_08(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
                result[i] = (arr1[i] > arr2[i] ? arr1[i] : arr2[i]);

            return result;
        }

        /// <summary>
        /// 9. Дан массив целых чисел.  <br/>
        /// Поменять местами его минимальный и максимальный элементы.
        /// </summary>
        static public void Lab_03_09(ref int[] arr)
        {
            (int value, int n) min = (int.MaxValue, 0);
            (int value, int n) max = (int.MinValue, 0);

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min.value)
                    min = (arr[i], i);

                if (arr[i] > max.value)
                    max = (arr[i], i);
            }

            arr[min.n] = max.value;
            arr[max.n] = min.value;
        }

        /// <summary>
        /// 10. Дан целочисленный массив. Продублировать в нем все четные числа
        /// </summary>
        static public int[] Lab_03_10(int[] arr)
        {
            //Наихудший случай - все числа в arr были четными
            List<int> result = new List<int>(arr.Length * 2);

            foreach(int i in arr)
            {
                result.Add(i);
                if (i % 2 == 0)
                    result.Add(i);
            }

            return result.ToArray();
        }
    }
}
