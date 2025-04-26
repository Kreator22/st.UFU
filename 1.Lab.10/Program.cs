//Лабораторная работа #1, задача 9.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

//Создать метод, который возвращает истину, если целое число, переданное в качестве параметра,
//совпадает с номером високосного года.

int year = 2024;
Console.WriteLine(IsLeapYear(year));
year = 2025;
Console.WriteLine(IsLeapYear(year));

static bool IsLeapYear(int year) => year % 4 == 0;