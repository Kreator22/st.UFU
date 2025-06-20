using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    /// <summary>
    /// Binary Writers & Readers
    /// </summary>
    public static class Binary_WR
    {       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <param name="fileName">Имя файла в каталоге</param>
        public static void BinaryWriter(string path, string fileName = "", params int[] values)
        {
            path = Path.Combine(path, fileName);
            BinaryWriter(path, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        public static void BinaryWriter(string path, params int[] values)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Неверный путь к каталогу");
                Console.WriteLine(path);
                return;
            }

            using (FileStream fs = new(path, FileMode.Create))
            using (BinaryWriter bw = new(fs))
                foreach (int num in values)
                    bw.Write(num);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <param name="fileName">Имя файла в каталоге</param>
        public static List<int> BinaryReader(string path, string fileName = "")
        {
            path = Path.Combine(path, fileName);
            return BinaryReader(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        public static List<int> BinaryReader(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("Неверный путь к каталогу");
                Console.WriteLine(path);
                return new List<int>();
            }

            List<int> nums = new();

            using (FileStream fs = new(path, FileMode.Open))
            using (BinaryReader bw = new(fs))
                while (bw.PeekChar() != -1)
                    nums.Add(bw.ReadInt32());

            return nums;
        }
    }
}
