//Домашнее задание #1, задача 1.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18863

//Дано вещественное число A.
//Вычислить A8, используя вспомогательную переменную и три! операции умножения.

Console.WriteLine(A8(2));

static double A8(double a)
{
    double A2 = Math.Pow(a, 2);
    return A2 * A2 * A2 * A2;
}
