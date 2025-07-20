using HW_09;
using HW_09.Point_Comparators;
using System.Text;

namespace HW_09_Tests
{
    [TestClass]
    public sealed class HW_09_Tests
    {
        [TestMethod]
        public void TemperatureTests()
        {
            string directory = Directory.GetCurrentDirectory();
            Console.WriteLine(directory);

            string path = Path.Combine(directory, "data.txt");
            List<Temperature> temperatures = new();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            foreach (string str in File.ReadAllLines(path, Encoding.GetEncoding(1251)))
            {
                int space = str.IndexOf(' ');
                string temperature = str.Substring(0, space);
                string description = str.Substring(space + 1, str.Length - space - 1);
                temperatures.Add(new Temperature(temperature, description));
            }

            foreach (var t in temperatures)
                Console.WriteLine(t);
            Console.WriteLine();

            temperatures.Sort();

            foreach (var t in temperatures)
                Console.WriteLine(t);
            Console.WriteLine();

            temperatures.Sort((t1, t2) => t1.K < t2.K ? 1 : -1);

            foreach (var t in temperatures)
                Console.WriteLine(t);
            Console.WriteLine();
        }

        [TestMethod]
        public void PointTests()
        {
            List<Point> points = new();
            points.Add(new Point(1, 1));
            points.Add(new Point(1, 2));
            points.Add(new Point(2, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(0, 1));
            points.Add(new Point(1, 0));
            points.Add(new Point(-10, -10));

            Console.WriteLine("Сортировка по расстоянию до точки (0, 0)");
            points.Sort(new PointDistanceToZeroZero());
            Print(points);

            Console.WriteLine("Сортировка по расстоянию до оси X");
            points.Sort(new PointDistanceToXAxis());
            Print(points);

            Console.WriteLine("Сортировка по расстоянию до оси Y");
            points.Sort(new PointDistanceToYAxis());
            Print(points);

            Console.WriteLine("Сортировка по расстоянию до диагонали X = Y");
            points.Sort(new PointdistanceToXEqualYFunction());
            Print(points);


            void Print(IEnumerable<Point> points)
            {
                foreach (Point p in points)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
                
        }
    }
}
