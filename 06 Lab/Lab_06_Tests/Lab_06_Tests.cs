using Newtonsoft.Json.Linq;
using System.IO;
using LB6 = Lab_06.Lab_06;
using LB6Bin = Lab_06.Binary_WR;
using LB6Str = Lab_06.Stream_WR;
using LB6csv = Lab_06.CSV_WR;

namespace Lab_06_Tests
{
    [TestClass]
    public sealed class Lab_06_Tests
    {
        [TestMethod]
        public void CreateTheNewFile()
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "TEST_CreateTheNewFile.txt";

            Console.WriteLine("The current directory is {0}", directory + Environment.NewLine);

            int[] values = [1, 2, 3, 16, 32, 65535, 65536, int.MinValue, int.MaxValue];

            string path = "";
            List<string> filesPaths = new();

            path = LB6.CreateTheNewFile(directory, fileName, LB6.WriteMode.FileStream, values);
            filesPaths.Add(path);
            path = LB6.CreateTheNewFile(directory, fileName, LB6.WriteMode.StreamWriter, values);
            filesPaths.Add(path);
            path = LB6.CreateTheNewFile(Path.Combine(directory, fileName), LB6.WriteMode.BinaryWriter, values);
            filesPaths.Add(path);

            /*foreach (string _path in filesPaths)
                File.Delete(_path);*/
        }

        [TestMethod]
        public void ReadFile()
        {
            string path = Directory.GetCurrentDirectory();

            string path_FS = Directory.GetFiles(path, "FS_*.txt").First();
            string path_SR = Directory.GetFiles(path, "SW_*.txt").First();
            string path_BR = Directory.GetFiles(path, "BW_*.txt").First();

           LB6.ReadFile(path_FS, LB6.ReadMode.FileStream);
           LB6.ReadFile(path_SR, LB6.ReadMode.StreamReader);
           LB6.ReadFile(path_BR, LB6.ReadMode.BinaryReader);
        }

        [TestMethod]
        public void BinaryWriter()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);

            int[] values = [1, 2, 3, 16, 32, 65535, 65536, int.MinValue, int.MaxValue];

            LB6Bin.BinaryWriter(path + "\\BW1.txt", values);
            LB6Bin.BinaryWriter(path, "BW2.txt", values);
            LB6Bin.BinaryWriter(path.Remove(path.Length), "BW3.txt", values);
            //Не будет создано
            LB6Bin.BinaryWriter(path + "\\BW4.txt", "BW4.txt", values);
        }

        [TestMethod]
        public void BinaryReader()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);

            List<int> actual = new();
            List<int> expected = [1, 2, 3, 16, 32, 65535, 65536, int.MinValue, int.MaxValue];

            actual = LB6Bin.BinaryReader(path + "\\BW1.txt");
            CollectionAssert.AreEqual(expected, actual);

            actual = LB6Bin.BinaryReader(path, "BW2.txt");
            CollectionAssert.AreEqual(expected, actual);

            actual = LB6Bin.BinaryReader(path.Remove(path.Length), "BW3.txt");
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тестирование. В основной программе явно создайте и обработайте четыре файла 
        /// (обязательно проверить пустой и файл из одного элемента). 
        /// Для каждого файла: распечатать исходное содержимое, обнулить минимальный элемент, 
        /// распечатать содержимое файла после изменения.
        /// Указание к тестированию.
        /// Удобно записать имена созданных файлов в массив строк и обработать их в цикле.
        /// </summary>
        [TestMethod]
        public void Lab_06_03()
        {
            int[][] source = new int[4][];
            source[0] = Array.Empty<int>();
            source[1] = [666];
            source[2] = [3, 2, 1, 2, 3];
            source[3] = [3, 2, 1, 1, 2, 3];

            int[][] expected = new int[4][];
            expected[0] = Array.Empty<int>();
            expected[1] = [0];
            expected[2] = [3, 2, 0, 2, 3];
            expected[3] = [3, 2, 0, 1, 2, 3];

            FilesManipulationChecker
                (source, expected, LB6.Lab_06_03, "Lab_06_03", "Обнуление минимального элемента в файле");
        }

        [TestMethod]
        public void Lab_06_04()
        {
            int[][] source = new int[4][];
            source[0] = Array.Empty<int>();
            source[1] = [10];
            source[2] = [3, 2, 1, 2, 3];
            source[3] = [3, 2, 1, 1, 2, 3];

            int[][] expected = new int[4][];
            expected[0] = Array.Empty<int>();
            expected[1] = [20];
            expected[2] = [6, 4, 2, 4, 6];
            expected[3] = [6, 4, 2, 2, 4, 6];

            FilesManipulationChecker
                (source, expected, LB6.Lab_06_04, "Lab_06_04", "Увеличение всех элементов в два раза");
        }

        [TestMethod]
        public void Lab_06_05()
        {
            int[][] source = new int[3][];
            source[0] = Array.Empty<int>();
            source[1] = [10];
            source[2] = [1, 2, 3];

            int[][] expected = new int[3][];
            expected[0] = Array.Empty<int>();
            expected[1] = [10];
            expected[2] = [3, 2, 1];

            FilesManipulationChecker
                (source, expected, LB6.Lab_06_05, "Lab_06_05", "Изменение порядка элементов на обратный");
        }

        [TestMethod]
        public void Lab_06_06()
        {
            int[][] source = new int[3][];
            source[0] = Array.Empty<int>();
            source[1] = [10];
            source[2] = [1, 2, 3];

            int[][] expected = new int[3][];
            expected[0] = Array.Empty<int>();
            expected[1] = [10, 10];
            expected[2] = [1, 2, 3, 3, 2, 1];

            FilesManipulationChecker
                (source, expected, LB6.Lab_06_06, "Lab_06_06", "Добавление элементов в обратном порядке в конец файла");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">Набор исходных данных</param>
        /// <param name="expected">Набор ожидаемых данных</param>
        /// <param name="manipulation">Метод, преобразовывающий исходные данные</param>
        /// <param name="fileName">Основная часть называния создаваемых файлов с наборами данных</param>
        /// <param name="manipulationDescription">
        /// Строка с описанием преобразования исходных данных для вывода на консоль</param>
        public void FilesManipulationChecker
            (int[][] source, int[][] expected, Action<string> manipulation,
            string fileName, string manipulationDescription)
        {
            string[] paths = new string[source.Length];
            string directory = Directory.GetCurrentDirectory();

            for (int i = 0; i < paths.Length; i++)
            {
                paths[i] = Path.Combine(directory, $"{fileName}_{i}");

                LB6Bin.BinaryWriter(paths[i], source[i]);

                Console.WriteLine(paths[i]);
                Console.WriteLine("Содержимое файла до изменения");

                foreach (int num in LB6Bin.BinaryReader(paths[i]))
                    Console.WriteLine(num);

                Console.Write("Содержимое файла после изменения. ");
                Console.WriteLine(manipulationDescription);

                manipulation(paths[i]);
                var actual = LB6Bin.BinaryReader(paths[i]);
                foreach (int num in actual)
                    Console.WriteLine(num);

                Console.WriteLine("--------------");

                CollectionAssert.AreEqual(expected[i], actual);

                File.Delete(paths[i]);
            }
        }

        [TestMethod]
        public void StreamWriter()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);

            List<string> strings = ["1", "2", "3", "Последняя строка"];

            LB6Str.StreamWriter(strings, path + "\\SW1.txt");
            LB6Str.StreamWriter(strings, path, "SW2.txt");
            LB6Str.StreamWriter(strings, path.Remove(path.Length), "SW3.txt");
            //Не будет создано
            LB6Str.StreamWriter(strings, path + "\\SW4.txt", "SW4.txt");
        }

        [TestMethod]
        public void StreamReader()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);

            List<string> actual = new();
            List<string> expected = ["1", "2", "3", "Последняя строка"];

            string fullPath = path + "\\SW1.txt";
            actual = LB6Str.StreamReader(fullPath).ToList();
            CollectionAssert.AreEqual(expected, actual);
            File.Delete(fullPath);

            fullPath = path + "\\SW2.txt";
            actual = LB6Str.StreamReader(path, "SW2.txt").ToList();
            CollectionAssert.AreEqual(expected, actual);
            File.Delete(fullPath);

            fullPath = path + "\\SW3.txt";
            actual = LB6Str.StreamReader(path.Remove(path.Length), "SW3.txt").ToList();
            CollectionAssert.AreEqual(expected, actual);
            File.Delete(fullPath);
        }

        [TestMethod]
        public void Lab_06_07()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            path += "\\Lab_06_07_01.txt";

            List<string> source = ["1", "2", "3", "Последняя строка"];
            int expected = 19;

            LB6Str.StreamWriter(source, path);
            int actual = LB6.Lab_06_07(path);

            Assert.AreEqual(expected, actual);
            File.Delete(path);
        }

        [TestMethod]
        public void Lab_06_08()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            path += "\\Lab_06_08.txt";

            List<string> expected = ["A", "AA", "AAA", "AAAA"];
            LB6.Lab_06_08(path, 4, 'A');
            List<string> actual = LB6Str.StreamReader(path).ToList();

            CollectionAssert.AreEqual(expected, actual);
            File.Delete(path);
        }

        [TestMethod]
        public void Lab_06_09()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            
            string path_1 = path + "\\Lab_06_09_01.txt";
            string path_2 = path + "\\Lab_06_09_02.txt";

            LB6Str.StreamWriter(["1", "2", "3"], path_1);
            LB6Str.StreamWriter(["4", "5", "6"], path_2);
            List<string> expected = ["1", "2", "3", "4", "5", "6"];

            LB6.Lab_06_09(path_1, path_2);
            List<string> actual = LB6Str.StreamReader(path_1).ToList();

            CollectionAssert.AreEqual(expected, actual);
            File.Delete(path_1);
            File.Delete(path_2);
        }

        [TestMethod]
        public void Lab_06_10()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            path += "\\Lab_06_10.txt";

            LB6Str.StreamWriter(["1", "", "3", " ", "5"], path);
            List<string> expected = ["1", "3", " ", "5"];
            
            LB6.Lab_06_10(path);
            List<string> actual = LB6Str.StreamReader(path).ToList();

            CollectionAssert.AreEqual(expected, actual);
            File.Delete(path);
        }

        [TestMethod]
        public void Lab_06_11()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            path += "\\Lab_06_11.txt";

            LB6Str.StreamWriter(["1", "", "3", " ", "5"], path);
            int expected = 4;
            int actual = LB6.Lab_06_11(path);

            Assert.AreEqual(expected, actual);
            File.Delete(path);
        }

        [TestMethod]
        public void CSV_Writer()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            string filename_1 = "CSV_test_1.csv";
            string filename_2 = "CSV_test_2.csv";

            string[] title = ["I", "II", "III"];
            int[][] source = new int[3][];
            source[0] = [1, 2, 3];
            source[1] = [4, 5, 6];
            source[2] = [7, 8, 9];

            LB6csv.CSV_Writer(source, ';', path, filename_1, title);
            LB6csv.CSV_Writer(new List<List<int>>(), ';', path, filename_2);            
        }

        [TestMethod]
        public void CSV_Reader()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            string filename_1 = "CSV_test_1.csv";
            string filename_2 = "CSV_test_2.csv";

            List<string> actual_title = new();
            List<List<int>> actual_values = new();

            Console.WriteLine("Содержимое файла " + filename_1);
            (actual_values, actual_title) = LB6csv.CSV_Reader(';', path, filename_1);
            CSV_Printer(actual_values, actual_title);

            Console.WriteLine("Содержимое файла " + filename_2);
            (actual_values, actual_title) = LB6csv.CSV_Reader(';', path, filename_2);
            CSV_Printer(actual_values, actual_title);

            File.Delete(path + "\\" + filename_1);
            File.Delete(path + "\\" + filename_2);
        }

        [TestMethod]
        public void CSV_Printer<T>
            (IEnumerable<IEnumerable<T>> values, IEnumerable<string> title = null)
        {
            if(title.Any())
            {
                foreach (string str in title)
                    Console.Write(str + "\t");
                Console.Write(Environment.NewLine);
            }

            foreach (var line in values)
            {
                foreach (T num in line)
                    Console.Write(num + "\t");
                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine);
        }

        [TestMethod]
        public void Lab_06_12()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            string filename = "Lab_06_12.csv";

            string[] title = ["I", "II", "III", "Сумма"];
            int[][] source = new int[4][];
            source[0] = [1, 2, 3];
            source[1] = [4, 5, 6];
            source[2] = Array.Empty<int>();
            source[3] = [7, 8, 9];

            LB6csv.CSV_Writer(source, ';', path, filename, title);

            List<string> actual_title = new();
            List<List<int>> actual_values = new();

            Console.WriteLine("Содержимое файла" + filename);
            (actual_values, actual_title) = LB6csv.CSV_Reader(';', path, filename);
            CSV_Printer(actual_values, actual_title);

            int[] sums = LB6.Lab_06_12(path, filename);
            int i = actual_title.Any() ? 1 : 0;
            foreach (var line in actual_values)
                line.Add(sums[i++]);

            Console.WriteLine("Результаты суммирования");
            CSV_Printer(actual_values, actual_title);

            File.Delete(Path.Combine(path, filename));
        }

        [TestMethod]
        public void Lab_06_13()
        {
            LB6.Lab_06_13();
        }

        [TestMethod]
        public void Lab_06_1415()
        {
            
            string path = Path.Combine(Directory.GetCurrentDirectory(), "input-files\\task-04");
            Directory.CreateDirectory(path);
            Console.WriteLine("The current directory is {0}", path + Environment.NewLine);
            string fileName = "Lab_06_14.txt";
            string filePath = Path.Combine(path, fileName);

            string text = "Дано натуральное число K и текстовый файл, содержащий слова. " +
                "Создать текстовый файл и записать в него все слова длины K из исходного файла по одному слову в строке." + Environment.NewLine + 
                "Указание. Воспользуйтесь методом System.IO.File.ReadAllText для чтения исходного файла и " +
                "System.IO.File.WriteAllLines для записи нового файла." + Environment.NewLine +
                "Замечание. Словом считать набор символов, не содержащий пробелов, знаков препинания " +
                "и ограниченный пробелами, знаками препинания или началом/концом строки. " +
                "Если исходный файл не содержит слов длины K, то оставить результирующий файл пустым." + Environment.NewLine +
                "Тестирование. Создать каталог input-files/task-04 и добавить туда несколько входных текстовых файлов, " +
                "на которых вы проводите тестирование. " +
                "Убедиться, что соответствующие результирующие файлы содержат то, что нужно.";

            using (FileStream fs = File.Create(filePath)) { };
            File.WriteAllText(filePath, text);

            List<string> filesPaths = new();

            for(int i = 2; i <= 6; i++)
                filesPaths.Add(LB6.Lab_06_14(filePath, i));
            filesPaths.Add(LB6.Lab_06_15(filePath, "ание"));

           Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "input-files"), true);
        }
    }
}
