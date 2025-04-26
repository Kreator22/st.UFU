//Лабораторная работа #1, задача 9.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

//Создать метод, который принимает два вещественных параметра и одновременно вычисляет
//среднее арифметическое и среднее геометрическое двух чисел. Его сигнатура следующая
//
//static void AGAverage(double a, double b, out double a, out double b) { }
//
//Метод использует два out-параметра или выходных параметра.
//Ключевое слово out используется как при определении метода, так и при его вызове.
//Определять новые переменные для выходных параметров можно непосредственно при вызове метода.
//
//AGAverage(1, 2, out int aMean, out int gMean);
//
//При вызове метода нужно убедится, что два числа, переданные в качестве параметров,
//являются положительными числами. Используем команду
//
//Debug.Assert(a>0 && b>0);

using System.Diagnostics;

Console.WriteLine("Вычисление среднего арифметического и среднего геометрического двух чисел");

string? _a, _b;
double a, b;
do
{
    Console.WriteLine("Введите первое число: ");
    _a = Console.ReadLine();
}
while (!double.TryParse(_a, out a));

do
{
    Console.WriteLine("Введите второе число: ");
    _b = Console.ReadLine();
}
while (!double.TryParse(_b, out b));

Debug.Assert(a > 0 && b > 0, "Одно из введёных чисел меньше или равно нулю");

double aMean, gMean;
AGAverage(a, b, out aMean, out gMean);

Console.WriteLine($"Среднее арифметическое {a} и {b} = {aMean}");
Console.WriteLine($"Среднее геометрическое {a} и {b} = {gMean}");

static void AGAverage(double a, double b, out double aMean, out double gMean)
{
    aMean = (a + b) / 2;
    gMean = Math.Sqrt(a * b);
}
