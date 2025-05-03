//Домашнее задание #1, задачи 4, 5, 6.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18863

// Дано двузначное число. Найти его левую и правую цифры (выходные параметры метода).
// Для нахождения десятков использовать операцию деления нацело (/),
// для нахождения единиц - операцию взятия остатка от деления (%).
// Дано двузначное число. Найти сумму и произведение его цифр.
// Дано двузначное число. Вывести число, полученное при перестановке цифр исходного числа.

int number = 35;
Console.WriteLine("Сумма цифр = " + DoOperation(Operation.Addition, number));
Console.WriteLine("Произведение цифр = " + DoOperation(Operation.Multiplication, number));
Console.WriteLine("Изменение порядка цифр: " + DoOperation(Operation.Reverse, number));

static int DoOperation(Operation operation, int number)
{
    int digit_1 = number / 10;
    int digit_2 = number % 10;

    Func<int, int, int> func;

    switch (operation)
    {
        case Operation.Addition:
            func = (digit_1, digit_2) => digit_1 + digit_2;
            break;
        case Operation.Multiplication:
            func = (digit_1, digit_2) => digit_1 * digit_2;
            break;
        case Operation.Reverse:
            func = (digit_1, digit_2) => digit_2 * 10 + digit_1;
            break;
        default:
            func = (_, _) => 0;
            break;
    }
    return func(digit_1, digit_2);
}
enum Operation
{
    Addition,
    Multiplication,
    Reverse
}