//Лабораторная работа #1, задача 6.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=18850

//Найти расстояние между двумя точками с заданными координатами (x1,y1) и (x2, y2) на плоскости.
//Расстояние вычисляется по формуле ( (x1−x2)^2+(y1−y2)^2 ) ^ 0.5
//Для вычисления корня используем Math.Abs

Point p1 = new();
Point p2 = new(1, 1);
Console.WriteLine(Point.pointDistanse(p1, p2));

p2.X = 3;
p2.Y = 4;
Console.WriteLine(Point.pointDistanse(p1, p2));

public class Point
{
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;
    public static double pointDistanse(Point p1, Point p2) =>
        Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Point() { }
}