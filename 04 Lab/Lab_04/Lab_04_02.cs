﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Лабораторная работа #4 - Последовательности
// Блок заданий 2 - Методы расширения последовательностей
// https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18953

/*
1. Дана целочисленная последовательность, содержащая как положительные, так и отрицательные числа. 
Вывести ее первый положительный элемент и последний отрицательный элемент.
Указание Используем методы First и Last. В качестве параметров используем лямбда-выражения.

2. Дана цифра D (однозначное целое число) и целочисленная последовательность A. 
Вывести первый положительный элемент последовательности A, оканчивающийся цифрой D. 
Если требуемых элементов в последовательности A нет, то вывести 0.
Указание Используем метод FirstOrDefault.
Указание Для проверки D на то, что он является цифрой, используем Debug.Assert.

3. Дан символ С и строковая последовательность A. 
Если A содержит единственный элемент, оканчивающийся символом C, то вывести этот элемент; 
если требуемых строк в A нет, то вывести пустую строку; 
если требуемых строк больше одной, то вывести строку «Error».
Указание Используем метод SingleOrDefault.
Указание Также удобно использовать операцию ??

4. Дан символ С и строковая последовательность A. 
Найти количество элементов A, которые содержат более одного символа и при этом начинаются 
и оканчиваются символом C.
Указание Используем метод Count.
Указание Для определения длины строки используем свойство Length. 
Доступ к элементу строки - по индексу. Индексация начинается с нуля.

5. Дана строковая последовательность. Найти сумму длин всех строк, входящих в данную последовательность.
Указание Используем метод Sum.

6. Дано целое число N (> 0). Используя методы Range, Select и Sum, найти сумму 
1 + (1/2) + … + (1/N) (как вещественное число).

7. Дана целочисленная последовательность. 
Извлечь из нее все положительные числа, сохранив их исходный порядок следования. (Используем Where)

8. Дана целочисленная последовательность. 
Извлечь из нее все нечетные числа, сохранив их исходный порядок следования и удалив все  
вхождения повторяющихся элементов, кроме первых. (Используем Distinct)

9. Даны целые числа K1 и K2 и целочисленная последовательность A; 
1 ≤ K1 < K2 ≤ N, где N — размер последовательности A. 
Найти сумму положительных элементов последовательности с порядковыми номерами от K1 до K2 включительно.
(Используем Skip, Take)

10. Дана целочисленная последовательность. 
Обрабатывая только положительные числа, получить последовательность их последних цифр 
и удалить в полученной последовательности все вхождения одинаковых цифр, кроме первого. 
Порядок полученных цифр должен соответствовать порядку исходных чисел. (Where, Select, Distinct)


 */


namespace Lab_04
{
    public static class Lab_04_02
    {
        /// <summary>
        /// 1. Дана целочисленная последовательность, содержащая как положительные, так и отрицательные числа.<br/> 
        /// Вывести ее первый положительный элемент и последний отрицательный элемент. <br/>
        /// Указание Используем методы First и Last.В качестве параметров используем лямбда-выражения.
        /// </summary>
        public static IEnumerable<int> Lab_04_02_01(
            this IEnumerable<int> seq,
            Func<int, bool> f_pred,
            Func<int, bool> l_pred)
        {
            yield return seq.First(f_pred);
            yield return seq.Last(l_pred);
        }

        /// <summary>
        /// 1. Дана целочисленная последовательность, содержащая как положительные, так и отрицательные числа.<br/> 
        /// Вывести ее первый положительный элемент и последний отрицательный элемент. <br/>
        /// </summary>
        public static IEnumerable<int> Lab_04_02_01(this IEnumerable<int> seq) =>
            Lab_04_02_01(seq, f => f > 0, l => l < 0);

        /// <summary>
        /// 2. Дана цифра D (однозначное целое число) и целочисленная последовательность A. <br/>
        /// Вывести первый положительный элемент последовательности A, оканчивающийся цифрой D.<br/>
        /// Если требуемых элементов в последовательности A нет, то вывести 0.<br/>
        /// Указание Используем метод FirstOrDefault.<br/>
        /// Указание Для проверки D на то, что он является цифрой, используем Debug.Assert.<br/>
        /// </summary>
        public static int Lab_04_02_02(this IEnumerable<int> seq, int d)
        {
            Debug.Assert(d < 10);

            return seq.FirstOrDefault(a => a % 10 == d, 0);
        }

        /// <summary>
        /// 3. Дан символ С и строковая последовательность A.  <br/>
        /// Если A содержит единственный элемент, оканчивающийся символом C, то вывести этот элемент; <br/>
        /// если требуемых строк в A нет, то вывести пустую строку;  <br/>
        /// если требуемых строк больше одной, то вывести строку «Error». <br/>
        /// Указание Используем метод SingleOrDefault. <br/>
        /// Указание Также удобно использовать операцию ?? <br/>
        /// </summary>
        public static string Lab_04_02_03(this IEnumerable<string> a, char c)
        {
            try
            {
                return a.SingleOrDefault(s => s.Last() == c, "");
            }
            catch
            {
                return "Error";
            }
        }

        /// <summary>
        /// 4. Дан символ С и строковая последовательность A.  <br/>
        /// Найти количество элементов A, которые содержат более одного символа и при этом начинаются
        /// и оканчиваются символом C. <br/> <br/>
        /// Указание Используем метод Count. <br/>
        /// Указание Для определения длины строки используем свойство Length.  <br/>
        /// Доступ к элементу строки - по индексу. Индексация начинается с нуля. <br/>
        /// </summary>
        public static int Lab_04_02_04(this IEnumerable<string> a, char c) =>
            a.Count(s => s.Length > 1 && s.First() == c && s.Last() == c);

        /// <summary>
        /// 5. Дана строковая последовательность.  <br/>
        /// Найти сумму длин всех строк, входящих в данную последовательность. <br/> <br/>
        /// Указание Используем метод Sum.
        /// </summary>
        public static int Lab_04_02_05(this IEnumerable<string> seq) =>
            seq.Sum(s => s.Length);

        /// <summary>
        /// 6. Дано целое число N (&gt; 0). Используя методы Range, Select и Sum, найти сумму  <br/>
        /// 1 + (1/2) + … + (1/N) (как вещественное число).
        /// </summary>
        public static double Lab_04_02_06(int n)
        {
            IEnumerable<int> seq = Enumerable.Range(1, n);
            return seq.Select(a => (double)a).Sum(a => 1 / a);
        }

        /// <summary>
        /// 7. Дана целочисленная последовательность.  <br/>
        /// Извлечь из нее все положительные числа, сохранив их исходный порядок следования. (Используем Where)
        /// </summary>
        public static IEnumerable<int> Lab_04_02_07(this IEnumerable<int> seq) =>
            seq.Where(a => a > 0);

        /// <summary>
        /// 8. Дана целочисленная последовательность.  <br/>
        /// Извлечь из нее все нечетные числа, сохранив их исходный порядок следования и удалив все
        /// вхождения повторяющихся элементов, кроме первых. (Используем Distinct)
        /// </summary>
        public static IEnumerable<int> Lab_04_02_08(this IEnumerable<int> seq) =>
            seq.Where(a => a % 2 != 0).Distinct();

        /// <summary>
        /// 9. Даны целые числа K1 и K2 и целочисленная последовательность A;  <br/>
        /// 1 ≤ K1 &lt; K2 ≤ N, где N — размер последовательности A. <br/>
        /// Найти сумму положительных элементов последовательности с порядковыми номерами 
        /// от K1 до K2 включительно. (Используем Skip, Take)
        /// </summary>
        public static int Lab_04_02_09(this IEnumerable<int> seq, int k1, int k2) =>
            seq.Skip(k1).Take(k2 - k1).Where(a => a > 0).Sum();

        /// <summary>
        /// 10. Дана целочисленная последовательность. 
        /// Обрабатывая только положительные числа, получить последовательность их последних цифр
        /// и удалить в полученной последовательности все вхождения одинаковых цифр, кроме первого.
        /// Порядок полученных цифр должен соответствовать порядку исходных чисел. (Where, Select, Distinct)
        /// </summary>
        public static IEnumerable<int> Lab_04_02_10(this IEnumerable<int> seq) =>
            seq.Where(a => a > 0).Select(a => a % 10).Distinct();
    }
}
