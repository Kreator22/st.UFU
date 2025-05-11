//Лабораторная работа #2, блок задач 3 - циклы
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18888

/*
1.Даны целые числа A и B (A < B).
Вывести в порядке возрастания все целые числа, расположенные между A и B
(не включая сами числа A и B), а также количество N этих чисел.

2. Дано целое число N > 0. Найти сумму
1 + 1/2 + 1/3 + ... + 1/N
Проверьте правильность вашей программы не менее чем на двух наборах данных.
Обязательно проверьте случай N = 1.

3. Даны целые числа A и B (A ≤ B). 
Найти произведение всех целых чисел от A до B включительно.

4. Дано вещественное число X и целое число N > 0. Найти значение выражения
1 + x + x^2 / 2! + x^3 / 3! + ... + x^N / N!

5. Даны положительные числа A и B (A ≥ B). 
На отрезке длины A размещено максимально возможное количество отрезков длины B (без наложений). 
Не используя операции умножения и деления, найти длину незанятой части отрезка A.

6. Дано целое число N ≥ 1. 
Последовательность Fk чисел Фибоначчи определяется следующим образом:
F1 = 1,F2 = 1,Fk = Fk−2 + Fk−1, где k = 3,4,…
Вывести элементы F1, F2, …, FN.
Указание. Для вычисления чисел Фибоначчи разрешается использовать не более трёх переменных.

7 Даны целые положительные числа N и K. 
Используя только операции сложения и вычитания, найти частное от деления нацело N на K, 
а также остаток от этого деления.

8. Проверить, является ли заданное целое положительное число степенью тройки.

9. Дано целое число. Найти количество его цифр и их сумму.

10. Дано положительное целое число. Вывести его запись в двоичной системе счисления.
*/

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace Lab_02_03
{
    public class Lab_02_03
    {
        /// <summary>
        /// 1.Даны целые числа A и B (A &lt; B).
        /// Вывести в порядке возрастания все целые числа, расположенные между A и B
        /// (не включая сами числа A и B), а также количество N этих чисел.
        /// </summary>
        /// <remarks>
        /// Моё решение так же поддерживает случаи A = B и A &gt; B.<br/> 
        /// Так же работает с отрицательными числами.
        /// </remarks>
        public static (IEnumerable<int>, int n) Lab_02_03_01(int a, int b)
        {
            int n = Math.Abs(a - b);
            if (n > 0) n--;

            return (Generator(a + 1, b), n);

            static IEnumerable<int> Generator(int min, int max)
            {
                for(int i = min; i < max; i++)
                    yield return i;
            }
        }

        /// <summary>
        /// 2. Дано целое число N > 0. Найти сумму
        /// 1 + 1/2 + 1/3 + ... + 1/N
        /// Проверьте правильность вашей программы не менее чем на двух наборах данных.
        /// Обязательно проверьте случай N = 1.
        /// </summary>
        public static double Lab_02_03_02(int n)
        {
            double result = 0;

            while(n > 0)
            {
                result += 1.0 / n;
                n--;
            }

            return result;
        }

        /// <summary>
        /// 3. Даны целые числа A и B (A ≤ B). 
        /// Найти произведение всех целых чисел от A до B включительно.
        /// </summary>
        public static int Lab_02_03_03(int a, int b)
        {
            int result = 1;

            while (a <= b)
            {
                result *= a;
                a++;
            }

            return result;
        }

        /// <summary>
        /// 4. Дано вещественное число X и целое число N &gt; 0.<br/>
        /// Найти значение выражения<br/>
        /// 1 + x + x^2 / 2! + x^3 / 3! + ... + x^N / N!
        /// </summary>
        /// <remarks>
        /// Ряд Маклорена - частный случай разложения в ряд Тейлора в нулевой точке.
        /// В задаче ряд для разложения e^x, 
        /// где N - количество членов ряда (точность разложения)
        /// </remarks>
        /// <param name="x">Степень</param>
        /// <param name="n">Количество членов ряда (точность разложения)</param>
        public static double Lab_02_03_04(double x, uint n)
        {
            // Первое решение, не работает для n > 20,
            // начинаются переполнения переменных.
            // Перейти к BigInteger тоже не получается, 
            // т.к. потом проблема их поделить друг на друга 
            // и получить число с плавающей запятой с нормальной точностью.
            /*double result = 1 + x;

            for (int i = 2; i < n; i++)
                result += Math.Pow(x, i) / Factorial(i);            
            
            static long Factorial(int n) => 
                n == 0 ? 1 : n * Factorial(n - 1);*/
            
            double result = 1 + x;

            //   1 + x + x^2 / 2! + x^3 / 3! + ... + x^N / N! =
            // = 1 + x +  term_2  +  term_3  + ... +  term_N
            for (int N = 2; N <= n; N++)
            {
                double term_N = 1;

                //x^N / N! = ( X * X * X * ... ) / ( 1 * 2 * 3 * ... )
                for (int i = 1; i <= N; i++) 
                    term_N = term_N * x / i;

                result += term_N;
            } 
                return result;
        }

        /// <summary>
        /// 5. Даны положительные числа A и B (A ≥ B). 
        /// На отрезке длины A размещено максимально возможное количество 
        /// отрезков длины B (без наложений). <br/>
        /// Не используя операции умножения и деления, 
        /// найти длину незанятой части отрезка A.
        /// </summary>
        public static decimal Lab_02_03_05(decimal a, decimal b)
        {
            while (a >= b)
                a -= b;
            return a;
        }

        /// <summary>
        /// 6. Дано целое число N ≥ 1. <br/>
        /// Последовательность Fk чисел Фибоначчи определяется следующим образом: <br/>
        /// F1 = 1, F2 = 1, Fk = Fk−2 + Fk−1, где k = 3, 4, … <br/>
        /// Вывести элементы F1, F2, …, FN. <br/>
        /// Указание.Для вычисления чисел Фибоначчи разрешается использовать 
        /// не более трёх переменных.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>FN - n-ное число Фибоначи</returns>
        /// <remarks>
        /// Способ решения с рекурсией.
        /// </remarks>
        public static int Lab_02_03_06_01(int n)
        {
            if ((n == 0) || (n == 1))
                return n;
            return Lab_02_03_06_01(n - 1) + Lab_02_03_06_01(n - 2);
        }

        /// <summary>
        /// 6. Дано целое число N ≥ 1. <br/>
        /// Последовательность Fk чисел Фибоначчи определяется следующим образом: <br/>
        /// F1 = 1, F2 = 1, Fk = Fk−2 + Fk−1, где k = 3, 4, … <br/>
        /// Вывести элементы F1, F2, …, FN. <br/>
        /// Указание.Для вычисления чисел Фибоначчи разрешается использовать 
        /// не более трёх переменных.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>FN - n-ное число Фибоначи</returns>
        ///<remarks>
        /// Способ решения без рекурсии.
        /// </remarks>
        public static int Lab_02_03_06_02(int n)
        {
            int result_prev = 1;
            int result = 1;

            switch (n)
            {
                case 1:
                    Console.WriteLine(1);
                    return 1;

                case 2:
                    Console.WriteLine(1);
                    Console.WriteLine(1);
                    return (1);

                case > 2:
                    Console.WriteLine(1);
                    Console.WriteLine(1);
                    while (n-- > 2)
                    {
                        (result_prev, result) = (result, result_prev + result);
                        Console.WriteLine(result);
                    };
                    return result;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 7. Даны целые положительные числа N и K. <br/>
        /// Используя только операции сложения и вычитания, 
        /// найти частное от деления нацело N на K, а также остаток от этого деления.
        /// </summary>
        public static (int Quotient, int Remainder) Lab_02_03_07(int n, int k)
        {
            int Quotient = 0;

            while(n > k)
            {
                Quotient++;
                n -= k;
            }

            return (Quotient, n);
        }

        /// <summary>
        /// 8. Проверить, является ли заданное целое положительное число степенью тройки.
        /// </summary>
        public static bool Lab_02_03_08(int n) =>
            //int.DivRem(n, 3).Quotient == 0; 
            int.DivRem(n, 3) is (_, 0);

        /// <summary>
        /// 9. Дано целое число. Найти количество его цифр и их сумму.
        /// </summary>
        /// <remarks>
        /// Решение через деление на 10
        /// </remarks>
        public static (int quantity, int sum) Lab_02_03_09_01(int n)
        {
            //quantity - количество цифр
            int q = 0; 
            int sum = 0;

            // Во всех циклах деления к сумме добавляем остаток от деления
            do
            {
                q++;

                (int Quotient, int Remainder) = int.DivRem(n, 10);

                sum += int.Abs(Remainder);
                n = Quotient;
                
                // В последнем цикле деления пытаемся делить одноразрядное число,
                // оно не разделится, добавляем к сумме само это число и заканчиваем
                if (Quotient == 0)
                {
                    sum += int.Abs(Quotient);
                    break;
                }
            }
            while (n != 0);

            return (q, sum);
        }

        /// <summary>
        /// 9. Дано целое число. Найти количество его цифр и их сумму.
        /// </summary>
        /// <remarks>
        /// Решение через преобразование в строку
        /// </remarks>
        public static (int quantity, int sum) Lab_02_03_09_02(int n)
        {
            string s = n.ToString();

            int quantity = s.Length;

            int sum = 0;
            foreach (char c in s)
                sum += (int)char.GetNumericValue(c);

            return (quantity, sum);
        }

        /// <summary>
        /// 10. Дано положительное целое число. Вывести его запись в двоичной системе счисления.
        /// </summary>
        public static byte[] Lab_02_03_10(int n)
        {
            byte[] bytes = BitConverter.GetBytes(n);

            foreach (byte b in bytes)
                Console.Write($"{b:b}".PadLeft(8, '0') + " ");
            Console.WriteLine();

            return bytes;
        }
    }
}