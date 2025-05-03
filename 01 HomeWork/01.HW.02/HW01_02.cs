//Домашнее задание #1, задача 2.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18863

//Дано значение угла α в градусах (0 < α < 360).
//Определить значение этого же угла в радианах, учитывая, что 180° = π радианов.
//В качестве значения использовать π использовать Math.Pi

Console.WriteLine(RadianAngle(360));
Console.WriteLine(RadianAngle(180));

static double RadianAngle(double a) => a * 2 * Math.PI / 360;
