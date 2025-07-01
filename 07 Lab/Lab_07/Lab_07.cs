//Лабораторная работа #7. Рекурсия
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=19089

//Во всех заданиях запрещено применять циклы — пользуйтесь рекурсией.

using System.Diagnostics;

namespace Lab_07
{

    public static class Lab_07
    {
        /// <summary>
        /// 1. Найти факториал целого числа
        /// </summary>
        public static double Factorial(int n) =>
            n <= 1 ? 1 : n * Factorial(n - 1);

        /// <summary>
        /// 2. Написать рекурсивную подпрограмму, печатающую все целые числа от a до b включительно (a ≤ b)
        /// </summary>
        public static void IntNumbersPrint(int a, int b)
        {
            if (a <= b)
            {
                Console.WriteLine(a);
                IntNumbersPrint(a + 1, b);
            }
        }

        /// <summary>
        /// 3. Даны два целых числа a и b.
        /// Написать рекурсивную подпрограмму, которая выводит все числа от a до b включительно,
        /// в порядке возрастания, если a < b, или в порядке убывания в противном случае.
        /// </summary>
        public static void IntNumbersPrintAD(int a, int b)
        {
            Console.WriteLine(a);
            if (a != b)
                IntNumbersPrintAD(a + Math.Sign(b - a), b);
        }


        /// <summary>
        /// 4. Даны два целых числа a и b.
        /// Написать рекурсивную подпрограмму, которая выводит все числа от a до b включительно
        /// в порядке возрастания, независимо от того, какое из двух чисел a и b больше.
        /// </summary>
        public static void IntNumbersPrintAscending(int a, int b) =>
            IntNumbersPrint(a < b ? a : b, a < b ? b : a);

        /// <summary>
        /// 5. Дано натуральное число n. 
        /// Написать функцию, которая возвращает true, если число n является точной степенью двойки,
        /// или false в противном случае.
        /// </summary>
        public static bool DegreeOfTwo(int a) =>
            a > 1 && (a & (a - 1)) == 0;

        /// <summary>
        /// 6. Даны целые числа a и b.Найти их наибольший общий делитель, используя алгоритм Евклида:
        /// </summary>
        public static int GreatestCommonDivisor(int a, int b) =>
            b != 0 ? GreatestCommonDivisor(b, a % b) : a;

        /// <summary>
        /// 7. Дан список целых чисел. Вычислить сумму его элементов,
        /// пользуясь следующим рекурсивным определением:
        /// Сумма элементов = первый элемент + сумма всех остальных элементов.
        /// </summary>
        public static int ListSum(IList<int> list, int n = 0) =>
            n < list.Count() - 1 ? ListSum(list, n + 1) + list[n] : list[n];

        /// <summary>
        /// 8. Дано целое число N ≥ 1. 
        /// Последовательность Fk чисел Фибоначчи (названа в честь Леонардо Пизанского) 
        /// определяется следующим образом:
        /// F1 = 1,F2 = 1,Fk = Fk−2 + Fk−1, k = 3, 4, … 
        /// Это целые числа: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, … 
        /// Создать функцию, которая возвращает число Фибоначчи под номером n. 
        /// Метод должен принимать только положительные числа(используем Debug.Assert) 
        /// В задаче удобно воспользоваться вложенной функцией.
        /// </summary>
        public static int fib(int n, int a = 1, int b = 1) =>
            n < 2 ? 1 : 
            n == 2 ? a + b : fib(n - 1, b, a + b);

        /// <summary>
        /// 9. Создать функцию, которая возвращает произведение цифр числа.
        /// </summary>
        public static int DigProduct(int n) =>
            n == 0 ? 1 : n % 10 * DigProduct(n / 10);

        /// <summary>
        /// 10. Создать функцию, которая выводит на все консоль простые множители положительного числа 
        /// (единица и само исходное число не учитываются, используем цикл).
        /// </summary>
        public static void PrimeFactors(int n, int k = 2)
        {
            if (n > 0 && n >= k)
                if (n % k == 0)
                {
                    Console.WriteLine(k);
                    PrimeFactors(n / k, k);
                }
                else
                    PrimeFactors(n, k + 1);
            else return;
        }
    }
}
