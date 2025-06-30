//Домашнее задание #6. Статистическая обработка результатов эксперимента
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=19065


using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace HW_06
{
    static public class HW_06
    {
        //Площадь поперечного сечения образца м^2
        const double S = 0.02 * 0.002;
        //Длина образца мкм
        const double L = 0.5 * 1000 * 1000;

        private static List<List<double>> dataLines = new();
        private static List<double> youngsModulusRaw = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        /// <param name="dataSetNumber"></param>
        static public void PrintCalculations(string path, int dataSetNumber)
        {
            if (dataSetNumber < 0 || dataSetNumber > 5)
                throw new ArgumentOutOfRangeException("dataSetNumber",
                    "В файле с заданием существуют только наборы данных с нулевого по пятый включительно");
            dataLines = GetDataLines(path);
            youngsModulusRaw = YoungsModulusRaw(
                dataLines.GetDataRows(4 * dataSetNumber).ToList(),
                dataLines.GetDataRows(4 * dataSetNumber + 1).ToList(),
                dataLines.GetDataRows(4 * dataSetNumber + 2).ToList(),
                dataLines.GetDataRows(4 * dataSetNumber + 3).ToList(),
                S, L);
            youngsModulusRaw.MainCalculations();
        }

        /// <summary>
        /// Получаем наборы данных из документа построчно, игнорируем строки не начинающиеся с чисел
        /// </summary>
        /// <returns>
        /// List&lt;double&gt; для каждой строки из чисел
        /// </returns>
        static private List<List<double>> GetDataLines(string path)
        {
            List<List<double>> data = new();

            //Подключаем кодировки, иначе windows-1251 не находится
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Только строки с числами
            var lines = File.ReadLines(path, Encoding.GetEncoding("windows-1251"))
                .Where(str => Regex.IsMatch(str, @"^[0-9,]+\b"))
                .Select(str => str.Split(' ', '\t'))
                .Select(nums =>
                {
                    List<double> result = new();
                    foreach (string num in nums)
                        if (double.TryParse(num, out double value))
                            result.Add(value);
                    return result;
                })
                .ToList();

            return lines;
        }

        static private IEnumerable<double> GetDataRows(this List<List<double>> dataLines, int rowNumber)
        {
            foreach (var line in dataLines)
                if (line.Count() > rowNumber)
                    yield return line[rowNumber];
                else yield break;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="force">
        /// N, продольное усилие, приложенное к материалу (Н, ньютоны)
        /// </param>
        /// <param name="length">
        /// Ход (мкм, микрометры). 
        /// Из постановки задачи непонятно ход чего и куда, 
        /// видимо для понимания нужно быть знакомым с устройством экстензометра.
        /// </param>
        /// <param name="mesuredLength">
        /// Удлинение экстензометра (мкм, микрометры)
        /// </param>
        /// <param name="S">
        /// S, площадь поперечного сечения образца (м^2, метры квадратные)
        /// </param>
        /// <param name="l">
        /// l, длина образца (мкм, микрометры)
        /// </param>
        /// <returns></returns>
        static private List<double> YoungsModulusRaw(
            List<double> time,
            List<double> force,
            List<double> length,
            List<double> mesuredLength,
            double S,
            double l)
        {
            List<double> results = new();

            /*
             Относительное удлинение ε образца:
	            ε = Δl / l
            где:
            Δl — удлинение образца (мкм),
            l — длина образца (мкм).

            Удлинение образца Δl = ход (мкм) - удлинение экстензометра (мкм), тогда
            ε = (ход - удлинение экстензометра) / l = (length - mesuredLength) / l

            Напряжение σ находим по формуле σ = N / S, где:
            N - продольное усилие
            S - площадь поперечного сечения образца
            σ = force / S

            Модуль Юнга (Е) измеряется в Паскалях. Он равен:
            Е = σ / ε = 
            = (force / S) / ((length - mesuredLength) / l) =
            = (force * l) / (S * (length - mesuredLength))
             */

            //"В начальный момент времени (при t=0) продольная деформация равна нулю.
            //Эти данные не должны обрабатываться."
            for (int i = 1; i < force.Count; i++)
            {
                results.Add(
                    (force[i] * l) / (S * (length[i] - mesuredLength[i]))
                    );
            }

            return results;
        }

        //Математическое ожидание
        //X¯ = (1 / N) * ∑(Xi)
        private static double ExpectedValue(this IEnumerable<double> nums) =>
            nums.Sum() / nums.Count();

        //Дисперсия
        //Sx^2 = [1 / (N − 1)] * ∑[(Xi − X¯) ^ 2]
        private static double Dispersion(this IEnumerable<double> nums)
        {
            double X = nums.ExpectedValue();
            return nums
                .Select(num => Math.Pow(num - X, 2))
                .Sum() / (nums.Count() - 1);
        }

        //Среднее квадратичное отклонение 
        //Sx = √Sx^2
        private static double StandardDeviation(double Dispersion) =>
            Math.Sqrt(Dispersion);

        //Среднее квадратичное отклонение 
        //Sx = √Sx^2
        private static double StandardDeviation(this IEnumerable<double> nums) =>
            Math.Sqrt(nums.Dispersion());

        private static void MainCalculations(this IEnumerable<double> nums)
        {
            //Исключаем из выборки значений наибольшее и наименьшее
            nums = nums
                .Order()
                .Skip(1)
                .SkipLast(1);

            //Производим анализ в целях обнаружения грубых ошибок и промахов.
            //Известно множество методов определения грубых ошибок статистического ряда.
            //Наиболее простой метод - правило трех сигм: разброс случайных величин от среднего значения
            //не должен превышать:
            //Xmin,max = X¯ ± 3σ = X¯ ± 3Sx
            //убираем из выборки значения, которые не вписываются в интервал
            double Sx = nums.StandardDeviation();
            double ExVal = nums.ExpectedValue();
            nums = nums.Where(num => (num > ExVal - 3 * Sx) && (num < ExVal + 3 * Sx));

            //Находим новые значения X¯, Sx^2 и Sx
            //Находим доверительный интервал 2μ по формуле
            //μ = Sx * t / √N
            //где t -аргумент функции Лапласа, если доверительная вероятность равняется 0,95, то t = 1.96.
            double N = nums.Count();
            double t = 1.96;
            Sx = nums.StandardDeviation();
            double u = Sx * t / Math.Sqrt(N);

            //Определяем погрешность 
            //ϵ = μ ∗ 100 / X¯
            ExVal = nums.ExpectedValue();
            double e = u * 100 / ExVal;

            //Запишем истинное значение измеряемой величины 
            //X = X¯ ± μ
            Console.WriteLine("Математическое ожидание = " + ExVal.Format());
            Console.WriteLine("Стандартное отклонение = " + Sx.Format());
            Console.WriteLine("Коэффициент вариации = " + (Sx / (nums.Sum() / N)).Format());
            Console.WriteLine($"Истинное значение измеряемой величины принадлежит интервалу ");
            Console.WriteLine($"[{(Sx - u).Format()}, {(Sx + u).Format()}]" +
                $" с вероятностью 95%");
            Console.WriteLine($"Модуль Юнга для аллюминия согласно википедии = {(70.0 * 1000 * 1000 * 1000).Format()}"); 
        }

        static private string Format(this double num) =>
            String.Format(
                CultureInfo.InvariantCulture,
                "{0:0.###E+0}", num);
    }

}
