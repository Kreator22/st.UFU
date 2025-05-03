//Домашнее задание #1, задача 3.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18863

//Найти решение системы линейных уравнений вида
//A1x + B1y = C1
//A2x + B2y = C2
//заданной своими коэффициентами A1, B1, C1, A2, B2, C2,
//если известно, что данная система имеет единственное решение.

double x, y;
SLAU(0, 0, 0, 0, 0, 0, out x, out y);
Console.WriteLine($"x = {x}, y = {y}");

SLAU(3, 2, 1, 1, 2, 3, out x, out y);
Console.WriteLine($"x = {x}, y = {y}");

static void SLAU(
    double a1,
    double b1,
    double c1,
    double a2,
    double b2,
    double c2,
    out double x,
    out double y)
{
    // x1 = (c1 - b1y1) / a1
    // a2 * (c1 - b1y1) / a1 + b2y2 = c2
    // (a2c1 - a2b1y1) / a1 + b2y2 = c2
    // a2c1 - a2b1y1 + a1b2y2 = a1c2
    // a1b2y2 - a2b1y1 = a1c2 - a2c1
    // y * (a1b2 - a2b1) = a1c2 - a2c1
    // y = (a1c2 - a2c1) / (a1b2 - a2b1)
    // x = (c1 - b1y) / a1
    x = 0;
    y = 0;
    double k1 = a1 * b2 - a2 * b1;
    if (a1 != 0 && k1 != 0)
    {
        y = (a1 * c2 - a2 * c1) / k1;
        x = (c1 - b1 * y) / a1;
    }
    else Console.WriteLine("Коэффициент А1 не должен быть равен нулю");
}