﻿//Лабораторная работа #2, блок задач 2 - перечисления и оператор выбора
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18888

//Создать перечисление из 12 элементов, каждый из которых соответствует одному из месяцев.
//Создать функцию, которая определяет количество дней в месяце невисокосного года.

//Единицы длины пронумерованы следующим образом:
//1 — дециметр, 2 — километр, 3 — метр, 4 — миллиметр, 5 — сантиметр.
//Дан номер единицы длины (целое число в диапазоне 1–5) и длина отрезка в этих единицах
//(вещественное положительное число). Найти длину отрезка в метрах.

namespace Lab_02_02
{
    /// <summary>
    /// Создать перечисление из 12 элементов, каждый из которых соответствует одному из месяцев.<br/>
    /// Создать функцию, которая определяет количество дней в месяце невисокосного года.
    /// </summary>
    public static class Lab_02_02_01
    {
        /// <summary>
        /// Создать функцию, которая определяет количество дней в месяце невисокосного года.
        /// </summary>
        public static int Days(Months month) => month switch
        {
            Months.Январь => 31,
            Months.Февраль => 28,
            Months.Март => 31,
            Months.Апрель => 30,
            Months.Май => 31,
            Months.Июнь => 30,
            Months.Июль => 31,
            Months.Август => 31,
            Months.Сентябрь => 30,
            Months.Октябрь => 31,
            Months.Ноябрь => 30,
            Months.Декабрь => 31,
            _ => throw new NotImplementedException()
        };

        public enum Months
        {
            Январь,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
    }

    /// <summary>
    /// Единицы длины пронумерованы следующим образом:<br/>
    /// 1 — дециметр, 2 — километр, 3 — метр, 4 — миллиметр, 5 — сантиметр.<br/>
    /// Дан номер единицы длины (целое число в диапазоне 1–5) и длина отрезка в этих единицах
    /// (вещественное положительное число). <br/>Найти длину отрезка в метрах.
    /// </summary>
    public static class Lab_02_02_02
    {
        /// <summary>
        /// Перевод длины отрезка в метры
        /// </summary>
        /// <param name="prefix">Единица измерения <br/>
        /// 1 — дециметр, 2 — километр, 3 — метр, 4 — миллиметр, 5 — сантиметр</param>
        /// <param name="segment">Длина в единицах измерения</param>
        /// <returns>Длина в метрах</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static double Meters(int prefix, double segment)
        {
            Lengths length = (Lengths)prefix;
            return (length) switch
            {
                (Lengths.Дециметр) =>   segment / 10,
                (Lengths.Километр) =>   segment * 1000,
                (Lengths.Метр) =>       segment,
                (Lengths.Миллиметр) =>  segment / 1000,
                (Lengths.Сантиметр) =>  segment / 100,
                (_) => throw new NotImplementedException()
            };
        }
        public enum Lengths
        {
            Дециметр = 1,
            Километр, 
            Метр, 
            Миллиметр,
            Сантиметр
        }
    }
}
