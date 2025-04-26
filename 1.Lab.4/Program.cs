//Лабораторная работа #1, задача 4.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

//Даны три целых числа: A, B, C.
//Проверить истинность высказывания: «Справедливо двойное неравенство A < B < C.
//Для решения задачи создаём метод static bool Inequality(int a, int b, int c) { }
//Метод возвращает результат типа bool, который принимает значение true/false (истина/ложь).
//Пользуемся операциями сравнения и логическими операциями. Для демонстрации работы вызываем новый метод из Main()


Console.WriteLine(Inequality(1, 2, 3));
Console.WriteLine(Inequality(2, 2, 2));
Console.WriteLine(Inequality(3, 2, 1));
Console.WriteLine(Inequality(1, 2, 1));
Console.WriteLine(Inequality(3, 2, 3));
static bool Inequality(int a, int b, int c) => a < b && b < c;


