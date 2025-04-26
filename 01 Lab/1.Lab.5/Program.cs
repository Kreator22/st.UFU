//Лабораторная работа #1, задача 5.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

// Найти значение функции
//y = 4(x–3)^6–7⋅(x–3)^3 + 2
//при данном значении x. При решении используем вспомогательную переменную для величины (x–3)^3
//Новый метод принимает и возвращает значение типа double.

static double x3(double x) => Math.Pow(x - 3, 3);
static double result(double x) => 4 * Math.Pow(x3(x), 2) - 7 * x3(x) + 2;

Console.WriteLine(result(4));
Console.WriteLine(result(3));