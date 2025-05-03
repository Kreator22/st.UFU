//Домашнее задание #1, задачи 4, 5, 6.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18863

//Даны три целых числа: A, B, C.
//Проверить истинность высказывания: «Число B находится между числами A и C».

//Даны два целых числа: A, B.
//Проверить истинность высказывания: «Каждое из чисел A и B нечетное».

//Даны два целых числа: A, B.
//Проверить истинность высказывания: «Числа A и B имеют одинаковую четность»

public static class HW01_07_08_09
{
    public static bool IS_B_InTheMiddle(int a, int b, int c) =>
        (a < b && b < c) || (a > b && b > c);
    public static bool AreOdd(int a, int b) =>
        a % 2 == 1 && b % 2 == 1;
    public static bool AreSameParity(int a, int b) =>
        a % 2 == b % 2;
}
