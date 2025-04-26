//Лабораторная работа #1, задача 7.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

//Даны координаты трех вершин треугольника: (x1,y1), (x2, y2), (x3, y3).
//Найти его периметр и площадь, используя формулу для расстояния между двумя точками на плоскости
//(используем метод из предыдущей задачи).
//Для нахождения площади треугольника со сторонами a, b, c использовать формулу Герона: ( p(p−a)(p−b)(p−c) )^0.5
//p - полупериметр треугольника

Point p1 = new();
Point p2 = new(4, 0);
Point p3 = new(0, 4);

//Длины сторон
double a = Point.pointDistanse(p1, p2);
double b = Point.pointDistanse(p2, p3);
double c = Point.pointDistanse(p3, p1);
//Console.WriteLine(a + " " + b + " " + c);

//Полупериметр
double per = (a + b + c) / 2;

//Площадь по формуле Герона
double s = Math.Sqrt(per * (per - a) * (per - b) * (per - c));

Console.WriteLine(s);