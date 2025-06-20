using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public static class Stream_WR
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <param name="fileName">Имя файла в каталоге</param>
        public static void StreamWriter(IEnumerable<string> values, string path, string fileName = "")
        {
            path = Path.Combine(path, fileName);
            StreamWriter(values, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        public static void StreamWriter(IEnumerable<string> values, string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Неверный путь к каталогу");
                Console.WriteLine(path);
                return;
            }

            using (FileStream fs = new(path, FileMode.Create))
            using (StreamWriter sw = new(fs))
                foreach (string str in values)
                    sw.WriteLine(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <param name="fileName">Имя файла в каталоге</param>
        public static IEnumerable<string> StreamReader(string path, string fileName = "")
        {
            path = Path.Combine(path, fileName);
            return StreamReader(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        public static IEnumerable<string> StreamReader(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Неверный путь к каталогу");
                Console.WriteLine(path);
                yield break;
                //return new List<string>();
            }

            List<string> strings = new();

            using (FileStream fs = new(path, FileMode.Open))
            using (StreamReader sr = new(fs))
                while (sr.Peek() != -1)
                    //strings.Add(sr.ReadLine());
                    yield return sr.ReadLine();

            //return strings;
        }
    }
}
