//Домашнее задание #1, задача 10.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18863

//Даны целые числа a, b, c, являющиеся сторонами некоторого треугольника.
//Проверить истинность высказывания:
//«Треугольник со сторонами a, b, c является прямоугольным».

namespace HW01_10
{
    public static class SquareTriangle
    {
        public static bool IsSquareTriangle(int a, int b, int c)
        {
            int a2 = a * a;
            int b2 = b * b;
            int c2 = c * c;
            return
                a2 + b2 == c2 ||
                b2 + c2 == a2 ||
                c2 + a2 == b2;
        }
    }
}
