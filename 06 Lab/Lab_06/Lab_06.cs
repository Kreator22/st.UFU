//Лабораторная работа #6. Файлы.
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=19024

/*
 
1. Создайте метод
static void CreateTheNewFile(string path, params int[] values)
который записывает в файл целых чисел набор значений, перечисленных через запятую. 

2. Создайте метод
static void ReadFile(string path, uint n = 10, string delimiter = ", ")
который принимает имя файла целых чисел и выводит их на консоль по N чисел в каждой строке
(значение по умолчанию для N = 10, N > 0). 
Для пустого файла выводить сообщение <empty file>.
(Используем свойство Length объекта FileStream)

3. Дан бинарный файл целых чисел. 
Обнулить его минимальный элемент (считать, что в файле он единственный). 
Если файл пуст, ничего не делать.
Указание. Во-первых, следует найти позицию минимального элемента (пользуясь Position).
Во вторых, с помощью метода Seek, следует перейти в позицию минимального элемента 
и записать в файл переменную с нулевым значением.
Тестирование. В основной программе явно создайте и обработайте четыре файла 
(обязательно проверить пустой и файл из одного элемента). 
Для каждого файла: распечатать исходное содержимое, обнулить минимальный элемент, 
распечатать содержимое файла после изменения. 
Указание к тестированию. Удобно записать имена созданных файлов в массив строк и обработать их в цикле.

4. Дан бинарный файл целых чисел. Увеличить все его элементы в два раза.
Тестирование. В основной программе явно создайте и обработайте четыре файла 
(обязательно проверить пустой и файл из одного элемента).

5. Дан файл целых чисел (возможно пустой). 
Инвертировать его (то есть изменить в нём порядок элементов на обратный).
Замечание. Не забудьте, что использовать вспомогательный файл запрещается.
Тестирование. В основной программе создать и обработать четыре файла 
(обязательно проверить пустой, файл из одного и двух элементов). 

6. Дан бинарный файл. Удвоить его размер, записав в конец файла все его исходные элементы в обратном порядке.
Замечание. Не забудьте, что использовать вспомогательный файл запрещается.
Тестирование. В основной программе явно создайте и обработайте три файла
(обязательно пустой файл, файл из одного целого числа).

7. Дан текстовый файл. 
Вывести все символы, содержащиеся в этом файле, и их коды (используйте метод Read()) . 
Посчитать общее количество символов в выходную переменную метода. 
Выяснить, какие коды у символов, обозначающих конец строки (ответ укажите в виде комментария). 
Выяснить код пробела.

8. Дано целое неотрицательное число N и символ C. 
Создать текстовый файл, содержащий N строк, первая из которых состоит из одного символа C, 
вторая — из двух, третья — из трёх и т.д. (Пользуемся методами Write() и WriteLine()) 

9. Даны два текстовых файла. Дописать содержимое второго файла в конец первого. 
(Используем StreamWriter, найдите подходящий конструктор)

10. Дан текстовый файл. Удалить из него все пустые строки.
Указание. Все задачи на изменение содержимого текстового файла (кроме дополнения) 
решаются с использованием временного файла. Создание временного файла обсуждается на данной странице 
(http://it.mmcs.sfedu.ru/wiki/%D0%92%D1%81%D0%BF%D0%BE%D0%BC%D0%BE%D0%B3%D0%B0%D1%82%D0%B5%D0%BB%D1%8C%D0%BD%D1%8B%D0%B5_%D1%84%D0%B0%D0%B9%D0%BB%D1%8B). 
Вам необходимо написать вспомогательную функцию MakeTempFileName для генерации имени временного файла. 
Переделайте функцию с данной страницы 
(http://it.mmcs.sfedu.ru/wiki/%D0%92%D1%81%D0%BF%D0%BE%D0%BC%D0%BE%D0%B3%D0%B0%D1%82%D0%B5%D0%BB%D1%8C%D0%BD%D1%8B%D0%B5_%D1%84%D0%B0%D0%B9%D0%BB%D1%8B)
на язык C# и инициализируйте newFileName по описанному на странице принципу.

11. Дан текстовый файл.
Определить количество пустых строк в этом файле, 
используя статический метод ReadLines класса System.IO.File.

12. Дан csv-файл, содержащий целые числа. 
Найти сумму чисел в каждой строке файла 
(решение оформить в виде функции, возвращающей массив целых чисел).
Для пустой строки следует возвращать ноль.
Замечание 1. Каждая строка файла в формате CSV 
(comma-separated values — значения, разделённые запятыми) 
содержит значения, разделённые запятыми.
Указание 1. Использовать метод Split для извлечения чисел из строк и метод int.Parse 
для преобразования их к типу integer для суммирования.
Замечание 2. Задачу можно решать с использованием явных циклов, 
либо с использованием методов последовательностей.

13. Данная задача не требует чтения содержимого файлов.
Создать в текущем каталоге папку text_files, 
создать там несколько текстовых файлов просто «руками», можете скопировать туда имеющиеся файлы).
Вывести имена файлов каталога text_files (процедура с одним параметром — именем каталога).
Переименовать все текстовые файлы каталога text_files, добавив к именам префикс help-. 
Это следует выполнить в процедуру с двумя параметрами — именем каталога и префиксом).
Снова вывести имена файлов каталога.
Указания.
Чтобы получить список имён файлов каталога, используйте статический метод System.IO.Directory.GetFiles. 
Текущему каталогу соответствует имя '.', родительскому — '..'.
Чтобы отделить собственно имя файла от всего пути к файлу (абсолютного или относительного) 
используйте статический метод System.IO.Path.GetFileName.
Для формирования имени файла с путём по пути и имени используйте System.IO.Path.Combine.
Чтобы переименовать файл, используйте статический метод System.IO.File.Move.

14. Дано натуральное число K и текстовый файл, содержащий слова. 
Создать текстовый файл и записать в него все слова длины K из исходного файла по одному слову в строке.
Указание. Воспользуйтесь методом System.IO.File.ReadAllText для чтения исходного файла 
и System.IO.File.WriteAllLines для записи нового файла.
Замечание. Словом считать набор символов, не содержащий пробелов, знаков препинания 
и ограниченный пробелами, знаками препинания или началом/концом строки. 
Если исходный файл не содержит слов длины K, то оставить результирующий файл пустым.
Тестирование. Создать каталог input-files/task-04 и добавить туда несколько входных текстовых файлов, 
на которых вы проводите тестирование. Убедиться, что соответствующие результирующие файлы содержат то, что нужно.

15. Дан текстовый файл, в каждой строке которого записано одно или несколько слов. 
Создать новый текстовый файл из одной строки, в которой через пробел записаны первые слова строк исходного файла, 
заканчивающиеся на заданную подстроку.
 */

using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using File = System.IO.File;

namespace Lab_06
{
    public class Lab_06
    {
        public enum WriteMode
        {
            FileStream,
            StreamWriter,
            BinaryWriter
        }

        public enum ReadMode
        {
            FileStream,
            StreamReader,
            BinaryReader
        }

        /// <summary>
        /// 1. Создайте метод
        /// static void CreateTheNewFile(string path, params int[] values)
        /// который записывает в файл целых чисел набор значений, перечисленных через запятую.
        /// </summary>
        /// <param name="path">Существующая директория для создания файла</param>
        /// <param name="fileName">Имя для создания файла</param>
        /// <param name="readWriteMode">Способ создания файла. В зависимости от способа имя файла будет изменено</param>
        /// <param name="values">Набор значений для записи в файл</param>
        public static string CreateTheNewFile
            (string path, string fileName, WriteMode readWriteMode, params int[] values) =>
            CreateTheNewFile(Path.Combine(path, fileName), readWriteMode, values);

        /// <summary>
        /// 1. Создайте метод
        /// static void CreateTheNewFile(string path, params int[] values)
        /// который записывает в файл целых чисел набор значений, перечисленных через запятую.
        /// </summary>
        /// <param name="path">Существующая директория и имя файла для создания</param>
        /// <param name="readWriteMode">Способ создания файла. В зависимости от способа имя файла будет изменено</param>
        /// <param name="values">Набор значений для записи в файл</param>
        public static string CreateTheNewFile(string path, WriteMode readWriteMode, params int[] values)
        {
            string? directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException("Неверный путь к директории" + Environment.NewLine + path);

            string writingMethod =
                readWriteMode == WriteMode.FileStream ? "FS" :
                readWriteMode == WriteMode.StreamWriter ? "SW" :
                "BW";

            //Изменяем имя файла в адресе в соответствии со способом его записи
            path = Path.Combine(directory, writingMethod + "_" + Path.GetFileName(path)); 

            FileStreamOptions options = new();
            options.Share = FileShare.Read;
            options.Mode = FileMode.Append;
            options.Access = FileAccess.Write;

            switch (readWriteMode)
            {
                case WriteMode.FileStream:
                    using (FileStream fs = new(path, FileMode.Append))
                        foreach (int i in values)
                        {
                            byte[] buffer = BitConverter.GetBytes(i);
                            byte[] delimiter = Encoding.Default.GetBytes(", ");

                            fs.Write(buffer);
                            fs.Write(delimiter);
                        }
                    Print("FileStream", path);
                    break;

                case WriteMode.StreamWriter:
                    using (FileStream fs = new(path, options))
                    using (StreamWriter sw = new(fs, Encoding.Default))
                        foreach (int i in values)
                            sw.Write(i + ", ");
                    Print("StreamWriter", path);
                    break;

                case WriteMode.BinaryWriter:
                    using (FileStream fs = new(path, options))
                    using (BinaryWriter bw = new(fs, Encoding.Default))
                        foreach (int i in values)
                            bw.Write(i + ", ");
                    Print("BinaryWriter", path);
                    break;
            }  
            
            static void Print(string method, string path)
            {
                Console.WriteLine($"Данные записаны с использованием {method} в");
                Console.WriteLine(path + Environment.NewLine);
            }

            return path;
        }

        /// <summary>
        /// 2. Создайте метод <br/>
        /// static void ReadFile(string path, uint n = 10, string delimiter = ", ") <br/>
        /// который принимает имя файла целых чисел и выводит их на консоль по N чисел в каждой строке
        /// (значение по умолчанию для N = 10, N &gt; 0).  <br/>
        /// Для пустого файла выводить сообщение &lt; empty file &gt;.  <br/>
        /// (Используем свойство Length объекта FileStream)
        /// </summary>
        public static void ReadFile(string path, ReadMode readWriteMode, uint n = 2, string delimiter = ", ")
        {
            if(!File.Exists(path))
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            FileStreamOptions options = new();
            options.Share = FileShare.Read;
            options.Mode = FileMode.Open;
            options.Access = FileAccess.Read;

            switch (readWriteMode)
            {
                case ReadMode.FileStream:
                    using (FileStream fs = new(path, FileMode.Open))
                    {
                        if(fs.Length == 0)
                        {
                            Console.WriteLine("<Empty file>");
                            break;
                        }

                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer);

                        List<int> nums = new((int)fs.Length / 6);

                        for (int i = 0; i < fs.Length; i += 6)
                            nums.Add(BitConverter.ToInt32(buffer, i));

                        Print(nums, n, delimiter, "FileStream", path);
                    }
                    break;

                case ReadMode.StreamReader:
                    using(FileStream fs = new(path, options))
                    using(StreamReader sr = new(fs, Encoding.Default))
                    {
                        if (fs.Length == 0)
                        {
                            Console.WriteLine("<Empty file>");
                            break;
                        }

                        List<int> nums = 
                            sr.ReadToEnd()
                            .Split(", ")
                            .Select(n => {
                                int result;
                                return new { valid = int.TryParse(n, out result), result };
                                })
                            .Where(pair => pair.valid == true)
                            .Select(pair => pair.result)
                            .ToList();

                        Print(nums, n, delimiter, "StreamReader", path);
                    }
                    break;


                case ReadMode.BinaryReader:
                    using (FileStream fs = new(path, options))
                    using(BinaryReader br = new(fs, Encoding.Default))
                    {
                        if (fs.Length == 0)
                        {
                            Console.WriteLine("<Empty file>");
                            break;
                        }

                        List<string> strings = new();

                        while (br.PeekChar() != -1)
                            strings.Add(br.ReadString().TrimEnd(new[] {' ', ','}) );

                        List<int> nums = strings
                            .Select(s => int.Parse(s))
                            .ToList();

                        Print(nums, n, delimiter, "BinaryReader", path);
                    }
                    break;
            }

            static void Print(IEnumerable<int> nums, uint n, string delimiter, string method, string path)
            {
                Console.WriteLine($"Данные прочитаны с использованием {method} из");
                Console.WriteLine(path);

                int i = 0;
                foreach (int num in nums)
                {
                    Console.Write(num + delimiter);
                    if ((i + 1) % n == 0)
                        Console.Write(Environment.NewLine);
                    i++;
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// 3. Дан бинарный файл целых чисел. 
        /// Обнулить его минимальный элемент(считать, что в файле он единственный). 
        /// Если файл пуст, ничего не делать.
        /// </summary>
        public static void Lab_06_03(string path)
        {
            if (!File.Exists(path))
                Console.WriteLine("Файл не найден" + Environment.NewLine + path);

            using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fs.Length == 0)
                    return;

                int min = int.MaxValue;
                int pos = 0;

                using (BinaryReader br = new(fs, Encoding.Default, true))
                {
                    while(br.PeekChar() != -1)
                    {
                        int num = br.ReadInt32();
                        if (num < min)
                            (min, pos) = (num, (int)fs.Position - 4);
                    }
                }
                
                fs.Seek(pos, SeekOrigin.Begin);

                using (BinaryWriter bw = new(fs))
                    bw.Write(0);
            }
        }

        /// <summary>
        /// 4. Дан бинарный файл целых чисел. Увеличить все его элементы в два раза.
        /// Тестирование.В основной программе явно создайте и обработайте четыре файла
        /// (обязательно проверить пустой и файл из одного элемента).
        /// </summary>
        /// <param name="path"></param>
        public static void Lab_06_04(string path)
        {
            if (!File.Exists(path))
                Console.WriteLine("Файл не найден" + Environment.NewLine + path);

            using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fs.Length == 0)
                    return;

                List<int> nums = new();

                using (BinaryReader br = new(fs, Encoding.Default, true))
                    while (br.PeekChar() != -1)
                        nums.Add(br.ReadInt32());

                fs.Seek(0, SeekOrigin.Begin);

                using (BinaryWriter bw = new(fs))
                    foreach (int num in nums)
                        bw.Write(num * 2);
            }
        }

        /// <summary>
        /// 5. Дан файл целых чисел (возможно пустой). 
        /// Инвертировать его(то есть изменить в нём порядок элементов на обратный).
        /// Замечание.Не забудьте, что использовать вспомогательный файл запрещается.
        /// </summary>
        public static void Lab_06_05(string path)
        {
            if (!File.Exists(path))
                Console.WriteLine("Файл не найден" + Environment.NewLine + path);

            using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fs.Length == 0)
                    return;

                List<int> nums = new();

                using (BinaryReader br = new(fs, Encoding.Default, true))
                    while (br.PeekChar() != -1)
                        nums.Add(br.ReadInt32());

                nums.Reverse();
                fs.Seek(0, SeekOrigin.Begin);

                using (BinaryWriter bw = new(fs))
                    foreach (int num in nums)
                        bw.Write(num);
            }
        }

        /// <summary>
        /// 6. Дан бинарный файл. 
        /// Удвоить его размер, записав в конец файла все его исходные элементы в обратном порядке.
        /// Замечание.Не забудьте, что использовать вспомогательный файл запрещается.
        /// </summary>
        public static void Lab_06_06(string path)
        {
            if (!File.Exists(path))
                Console.WriteLine("Файл не найден" + Environment.NewLine + path);

            using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fs.Length == 0)
                    return;

                List<int> nums = new();

                using (BinaryReader br = new(fs, Encoding.Default, true))
                    while (br.PeekChar() != -1)
                        nums.Add(br.ReadInt32());

                nums.Reverse();

                using (BinaryWriter bw = new(fs))
                    foreach (int num in nums)
                        bw.Write(num);
            }
        }

        /// <summary>
        /// 7. Дан текстовый файл. 
        /// Вывести все символы, содержащиеся в этом файле, и их коды(используйте метод Read()) . 
        /// Посчитать общее количество символов в выходную переменную метода.
        /// Выяснить, какие коды у символов, обозначающих конец строки (ответ укажите в виде комментария). 
        /// Выяснить код пробела.
        /// </summary>
        /// <remarks>
        /// Символы конца строки не считаем.
        /// Код пробела - U+0032
        /// Коды конца строки:
        /// 0d 0a - HEX
        /// \r\n, Environment.NewLine()
        /// </remarks>
        /// <param name="path">Полный путь к файлу</param>
        /// <returns>Количество символов в файле</returns>
        public static int Lab_06_07(string path)
        {
            int i = 0;
            foreach(string str in Stream_WR.StreamReader(path))
                foreach(char c in str)
                {
                    i++;
                    Console.WriteLine($"{c} - {(int)c}");
                }
            
            return i;
        }

        /// <summary>
        /// 8. Дано целое неотрицательное число N и символ C. 
        /// Создать текстовый файл, содержащий N строк, первая из которых состоит из одного символа C,
        /// вторая — из двух, третья — из трёх и т.д. (Пользуемся методами Write() и WriteLine())
        /// </summary>
        public static void Lab_06_08(string path, int n, char c)
        {
            List<string> strings = new();

            for(int i = 1; i <= n; i++)
                strings.Add( new string(c, i) );

            Stream_WR.StreamWriter(strings, path);
        }

        /// <summary>
        /// 9. Даны два текстовых файла. Дописать содержимое второго файла в конец первого. 
        /// (Используем StreamWriter, найдите подходящий конструктор)
        /// </summary>
        public static void Lab_06_09(string path_1, string path_2)
        {
            if (!File.Exists(path_1) || !File.Exists(path_2))
                Console.WriteLine("Неверный путь к файлу");

            using (StreamReader sr = new(path_2))
            using (StreamWriter sw = new(path_1, true))
                while (sr.Peek() != -1)
                    sw.WriteLine(sr.ReadLine());
        }

        /// <summary>
        /// 10. Дан текстовый файл. Удалить из него все пустые строки.
        /// Указание.Все задачи на изменение содержимого текстового файла(кроме дополнения)
        /// решаются с использованием временного файла.Создание временного файла обсуждается на данной странице
        /// </summary>
        public static void Lab_06_10(string path)
        {
            string path_2 = Path.GetTempFileName();
            Console.WriteLine("Создан временный файл" + Environment.NewLine + path_2);
            File.Copy(path, path_2, true);

            using (FileStream fs = new(path_2, FileMode.Open))
            {
                using(StreamReader sr = new(fs))
                using(StreamWriter sw = new (path, false))
                    while(sr.Peek() != -1)
                    {
                        string str = sr.ReadLine();
                        if (str != String.Empty)
                            sw.WriteLine(str);
                    }
            }

            File.Delete(path_2);
        }

        /// <summary>
        /// 11. Дан текстовый файл.
        /// Определить количество пустых строк в этом файле, 
        /// используя статический метод ReadLines класса System.IO.File.
        /// </summary>
        public static int Lab_06_11(string path)
        {
            int i = 0;
            foreach (string str in File.ReadLines(path))
                if (str != String.Empty)
                    i++;
            return i;
        }


        public static int[] Lab_06_12(string path, string filename) =>
            Lab_06_12(Path.Combine(path, filename));

        /// <summary>
        /// 12. Дан csv-файл, содержащий целые числа. 
        /// Найти сумму чисел в каждой строке файла
        /// (решение оформить в виде функции, возвращающей массив целых чисел).
        /// Для пустой строки следует возвращать ноль.
        /// </summary>
        public static int[] Lab_06_12(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Неверный путь к файлу", path);

            List<List<int>> values;
            List<string> title;
            List<int> result = new();

            (values, title) = CSV_WR.CSV_Reader(';', path);

            if (title != null)
                result.Add(0);

            foreach (var line in values)
                result.Add(line.Sum());

            return result.ToArray();
        }

        /// <summary>
        /// 13. Данная задача не требует чтения содержимого файлов.
        /// Создать в текущем каталоге папку text_files,
        /// создать там несколько текстовых файлов просто «руками», можете скопировать туда имеющиеся файлы).
        /// Вывести имена файлов каталога text_files(процедура с одним параметром — именем каталога).
        /// Переименовать все текстовые файлы каталога text_files, добавив к именам префикс help-. 
        /// Это следует выполнить в процедуру с двумя параметрами — именем каталога и префиксом).
        /// Снова вывести имена файлов каталога.
        /// Указания.
        /// Чтобы получить список имён файлов каталога, используйте статический метод System.IO.Directory.GetFiles.
        /// Текущему каталогу соответствует имя '.', родительскому — '..'.
        /// Чтобы отделить собственно имя файла от всего пути к файлу(абсолютного или относительного)
        /// используйте статический метод System.IO.Path.GetFileName.
        /// Для формирования имени файла с путём по пути и имени используйте System.IO.Path.Combine.
        /// Чтобы переименовать файл, используйте статический метод System.IO.File.Move.
        /// </summary>
        /// <remarks>
        /// Не нашел способа собрать новый полный путь к файлу строго через Path.Combine 
        /// с двумя параметрами - "именем каталога и префиксом"
        /// </remarks>
        public static void Lab_06_13()
        {
            string directory = Directory.GetCurrentDirectory() + "\\text_files";
            Directory.CreateDirectory(directory);

            Console.WriteLine("Current directory " + directory + Environment.NewLine);

            for (int i = 0; i < 5; i++)
                using (FileStream fs = File.Create(directory + "\\" + i + ".txt")){};

            Console.WriteLine("Список файлов в директории" + Environment.NewLine + directory);
            var filePaths = Directory.GetFiles(directory);

            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                Console.WriteLine(fileName);
                string new_filename = String.Concat("help-", fileName);
                File.Move(filePath, Path.Combine(directory, new_filename));
            }

            Console.WriteLine(Environment.NewLine + "Список файлов после переименования в директории" +
                Environment.NewLine + directory);
            filePaths = Directory.GetFiles(directory);
            foreach (string filePath in filePaths)
                Console.WriteLine( Path.GetFileName(filePath) );

            Directory.Delete(directory, true);
        }


        public static string Lab_06_14(string path, string fileName, int k) =>
            Lab_06_14(Path.Combine(path, fileName), k);

        /// <summary>
        /// 14. Дано натуральное число K и текстовый файл, содержащий слова. 
        /// Создать текстовый файл и записать в него все слова длины K из исходного файла по одному слову в строке.
        /// Указание.Воспользуйтесь методом System.IO.File.ReadAllText для чтения исходного файла
        /// и System.IO.File.WriteAllLines для записи нового файла.
        /// Замечание.Словом считать набор символов, не содержащий пробелов, знаков препинания
        /// и ограниченный пробелами, знаками препинания или началом/концом строки.
        /// Если исходный файл не содержит слов длины K, то оставить результирующий файл пустым.
        /// Тестирование.Создать каталог input-files/task-04 и добавить туда несколько входных текстовых файлов,
        /// на которых вы проводите тестирование.Убедиться, что соответствующие результирующие файлы содержат то, что нужно.
        /// </summary>
        /// <remarks>
        /// После выполнения понял, что 14 и 15 задания просятся быть сделанными одним методом.
        /// </remarks>
        /// <returns>Путь к файлу с результатами</returns>
        public static string Lab_06_14(string path, int k) =>
            Lab_06_1415(path, k.ToString(), @"\b[a-zA-Zа-яА-Я]{" + k + @"}\b");


        public static string Lab_06_15(string path, string fileName, string subString) =>
            Lab_06_15(Path.Combine(path, fileName), subString);

        /// <summary>
        /// Дан текстовый файл, в каждой строке которого записано одно или несколько слов. 
        /// Создать новый текстовый файл из одной строки, в которой через пробел записаны 
        /// первые слова строк исходного файла, заканчивающиеся на заданную подстроку.
        /// </summary>
        /// <returns>Путь к файлу с результатами</returns>
        public static string Lab_06_15(string path, string subString) =>
            Lab_06_1415(path, subString, @"(?:^|\r\n)(\w*ание\b)", true);

        /// <summary>
        /// Общее решение для 14 и 15 заданий
        /// </summary>
        /// <param name="path"></param>
        /// <param name="new_file_prefix"></param>
        /// <param name="pattern"></param>
        /// <returns>Путь к файлу с результатами</returns>
        static string Lab_06_1415(string path, string new_file_prefix, string pattern, bool join_words = false, char separator = ' ')
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Неверный путь к файлу", path);

            var words = Regex.Matches(File.ReadAllText(path), pattern).Select(m => m.Value.Trim('\r', '\n'));

            //Путь к файлу с результатами
            string newPath = Path.GetDirectoryName(path) + "\\" + new_file_prefix + "_" + Path.GetFileName(path);

            if (join_words)
                File.WriteAllText(newPath, String.Join(separator, words));
            else
                File.WriteAllLines(newPath, words);

            return newPath;
        }
    }
}
