//Лабораторная работа #1, задача 8.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

//Поменять местами содержимое переменных A и B и вывести новые значения A и B.
//Создаём метод, принимающий два параметра по ссылке
//static void Swap(ref int a, ref int b) { }
//При передаче параметров по ссылке важно помнить, что ключевое слово ref используется
//не только в списке параметров метода, но и при вызове метода. В метод Main добавляем код:
/*
Console.WriteLine("Введите два числа:");
a = int.Parse(Console.ReadLine());
b = int.Parse(Console.ReadLine());
Console.WriteLine($"a = {a}, b = {b}");
Swap(ref a, ref b);
Console.WriteLine($"a = {a}, b = {b}");
*/
static void Swap(ref int a, ref int b)
{
    int c = a;
    a = b;
    b = c;
}

Console.WriteLine("Введите два числа:");
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
Console.WriteLine($"a = {a}, b = {b}");
Swap(ref a, ref b);
Console.WriteLine($"a = {a}, b = {b}");