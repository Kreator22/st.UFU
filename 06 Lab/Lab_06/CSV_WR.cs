using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    /// <summary>
    /// CSV writer/reader
    /// </summary>
    public static class CSV_WR
    {
        /// <summary>
        /// Запись CSV файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Набор строк с наборами значений для записи в CSV файл</param>
        /// <param name="delimiter">Разделитель значений в CSV файле. Обычно используется ',' или ';'</param>
        /// <param name="path">Директория, в которой следует записать файл</param>
        /// <param name="fileName">Имя файла</param>
        /// <param name="title">Набор заголовоков для CSV файла. Необязательный параметр</param>
        public static void CSV_Writer<T>
            (IEnumerable<IEnumerable<T>> values, char delimiter, 
            string path, string fileName, IEnumerable<string>? title = null)
        {
            path = Path.Combine(path, fileName);
            CSV_Writer(values, delimiter, path, title);
        }

        /// <summary>
        /// Запись CSV файла
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Набор строк с наборами значений для записи в CSV файл</param>
        /// <param name="delimiter">Разделитель значений в CSV файле. Обычно используется ',' или ';'</param>
        /// <param name="path">Полный путь к файлу</param>
        /// <param name="title">Набор заголовоков для CSV файла. Необязательный параметр</param>
        public static void CSV_Writer<T>
            (IEnumerable<IEnumerable<T>> values, 
            char delimiter, string path, IEnumerable<string>? title = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Неверный путь к каталогу");
                Console.WriteLine(path);
                return;
            }

            using(FileStream fs = new(path, FileMode.Create))
            using(StreamWriter sw = new(fs))
            {
                StringBuilder str = new();

                if (title != null)
                {
                    str.AppendJoin(delimiter, title);
                    str.Append(Environment.NewLine);
                }

                foreach (IEnumerable<T> line in values)
                {
                    str.AppendJoin(delimiter, line);
                    str.Append(Environment.NewLine);
                }
                sw.Write(str);
            }
        }

        /// <summary>
        /// Чтение CSV файла
        /// </summary>
        /// <param name="delimiter">Разделитель значений в CSV файле. Обычно используется ',' или ';'</param>
        /// <param name="path">Директория, в которой следует искать файл</param>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        public static (List<List<int>>, List<string>) CSV_Reader
            (char delimiter, string path, string fileName)
        {
            path = Path.Combine(path, fileName);
            return CSV_Reader(delimiter, path);
        }


        /// <summary>
        /// Чтение CSV файла
        /// </summary>
        /// <remarks>
        /// По хорошему надо еще сравнивать количество элементов во всех строках,
        /// проверять, что в качестве разделителя выбран подходящий символ,
        /// обрезать пробелы и проверять кучу всего, что входит в стандарт.
        /// </remarks>
        /// <param name="delimiter">Разделитель значений в CSV файле. Обычно используется ',' или ';'</param>
        /// <param name="path">Полный путь к файлу</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static (List<List<int>>, List<string>) CSV_Reader
            (char delimiter, string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("Неверный путь к файлу", path);

            List<string> title = new();
            List<List<int>> result = new();
            
            using(FileStream fs = new(path, FileMode.Open))
            using(StreamReader sr = new(fs))
            {
                //Проверяем были ли в первой строке заголовки
                if (sr.Peek() != -1)
                {
                    var firstLine = sr.ReadLine().Split(delimiter);

                    //В первой строке заголовки
                    if (!int.TryParse(firstLine[1], out _))
                        title = firstLine.ToList();
                    //В первой строке уже данные, возвращаем указатель и разбираем
                    //её вместе с остальными строками
                    else fs.Seek(0, SeekOrigin.Begin);
                }
                
                //Разбираем все остальные строки
                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine().Split(delimiter);

                    result.Add(
                        line.First() != "" ? 
                        line.Select(str => int.Parse(str)).ToList() :
                        new List<int>()
                        );
                }
            }

            return (result, title);
        }
    }
}
