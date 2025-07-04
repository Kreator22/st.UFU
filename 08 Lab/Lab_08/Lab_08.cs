//Лабораторная работа #8. Коллекции
//https://edu.mmcs.sfedu.ru/mod/assign/view.php?id=19116

/*
1. Дана строка, содержащая скобки трёх видов (круглые, квадратные и фигурные) и любые другие символы. 
Проверить, корректно ли в ней расставлены скобки. 
Например, в строке ([]{})[] скобки расставлены корректно, а в строке ([]] — нет. 
Указание: задача решается однократным проходом по символам заданной строки слева направо; 
для каждой открывающей скобки в строке в стек помещается соответствующая закрывающая, 
каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека
(при этом скобка с вершины стека снимается); в конце прохода стек должен быть пуст.

2. Напечатать в порядке возрастания первые n натуральных чисел, 
в разложение которых на простые множители входят только числа 2, 3, 5.
Указание: идея решения состоит в использовании трёх очередей, в которых хранятся числа, 
в 2 (3, 5) раз большие уже напечатанных, но не напечатанные; 
всякий раз из очередей выбирается наименьшее, расположенное в вершине одной из очередей значение,
оно печатается, а в хвосты очередей добавляются соответствующие кратные ему; 
процесс запускается с печати числа 1.

3. Дан список целых чисел (List<int>). Удалить из него все числа, делящиеся на первый элемент.

4. Дан список целых чисел. Между любыми двумя элементами одной чётности вставить число 0.

5. Решить две предыдущие задачи для двусвязного списка целых чисел (LinkedList<int>).

6. Продемонстрировать использование классов List и LinkedList на примере следующего сценария:
Генерируется длинный (100000 элементов) список случайных целых чисел.
Выполняется проход по списку и из списка удаляются все числа, делящиеся на первый элемент.
Между любыми двумя элементами одной чётности вставляется число 0.
Организуйте сравнение времени решения предыдущей задачи с помощью классов List и LinkedList.
Для сравнения удобно использовать методы класса Stopwatch.

7. Даны несколько текстовых файлов, каждая срока которых содержит фамилию и имя студента.
Найти студентов, имена которых присутствуют во всех файлах. 
Указание: в решении этой задачи удобно сформировать массив множеств HashSet с именами студентов, 
а затем вычислить их пересечение.

8. Найти самое часто встречающееся слово в текстовом файле.

9. Дан текстовый файл, каждая строка которого содержит 
а) идентификатор некоторой вершины ориентированного графа и 
б) список идентификаторов инцидентных ей вершин, то есть тех, в которые из вершины,
указанной в начале строки, выходит дуга 
(идентификаторы — это последовательности латинских букв и цифр, 
идентификаторы разделяются пробелами, список вершин может быть пустым). 
Можно считать, что параллельных дуг (с совпадающими началами и концами) в графе нет. Пример файла:

v1    v2 v3
v2
v3    v1
Проверить, что граф задан этим файлом корректно, а именно:
идентификаторы вершин, указанных первыми, не повторяются;
все упомянутые в списках вершин идентификаторы в одной из строк указаны на первой позиции.

10. Для графа, заданного файлом в формате из предыдущего упражнения, выполнить следующее:
посчитать общее количество дуг в графе;
построить матрицу инцидентности;
найти вершины, в которые не входит ни одной дуги.
 */

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Lab_08
{
    public class Lab_08
    {
        /// <summary>
        /// 1. Дана строка, содержащая скобки трёх видов (круглые, квадратные и фигурные) и любые другие символы. 
        /// Проверить, корректно ли в ней расставлены скобки.
        /// Например, в строке ([]{ })[] скобки расставлены корректно, а в строке ([]] — нет.
        /// </summary>
        public static bool Lab_08_01(string s)
        {
            Stack<char> brackets = new();
            Dictionary<char, char> bracketsSymbols = new() { 
                { ')', '(' },
                { ']', '[' },
                { '}', '{' } 
            };
            char openBracket;

            foreach (char c in s)
            {
                //Открывающую скобку кладём в стэк
                if (bracketsSymbols.ContainsValue(c))
                    brackets.Push(c);

                //Для закрывающей скобки:
                if (bracketsSymbols.TryGetValue(c, out openBracket))
                {
                    //нет открывающей скобки (стэк пуст)
                    if (brackets.Count == 0) 
                        return false;

                    //сверху стэка лежала неподходящая открывающая скобка
                    if(brackets.Pop() != openBracket) 
                        return false;
                }    
            }

            //В стэке остались скобки, значит не совпало количество открывающих и закрывающих скобок
            return brackets.Count == 0;
        }

        /// <summary>
        /// 2. Напечатать в порядке возрастания первые n натуральных чисел, 
        /// в разложение которых на простые множители входят только числа 2, 3, 5.
        /// </summary>
        public static List<int> Lab_08_02(int n)
        {
            //Очереди с вычисленными числами
            Queue<int> Q2 = new();
            Queue<int> Q3 = new();
            Queue<int> Q5 = new();
            List<int> results = new();

            //Текущее найденное число
            int current = 1;

            //Числа наверху очередей
            int p2, p3, p5;

            for(int i = 0; i < n; i++)
            {
                results.Add(current);
                Console.WriteLine(current);

                Q2.Enqueue(current * 2);
                Q3.Enqueue(current * 3);
                Q5.Enqueue(current * 5);

                pUpdate();

                //Одинаковые числа в очередях - удалить
                if (p2 == p3)
                    Q3.Dequeue();
                if (p2 == p5)
                    Q5.Dequeue();
                if (p3 == p5)
                    Q5.Dequeue();

                pUpdate();

                //Число в очереди совпадает с текущим - удалить
                if (p2 == current)
                    Q2.Dequeue();
                if (p3 == current)
                    Q3.Dequeue();
                if (p5 == current)
                    Q5.Dequeue();

                pUpdate();

                //Минимальное число из верха очередей становится текущим найденным
                if (p2 < p3 && p2 < p5)
                {
                    current = p2;
                    Q2.Dequeue();
                }
                else if(p3 < p5)
                {
                    current = p3;
                    Q3.Dequeue();
                }
                else
                {
                    current = p5;
                    Q5.Dequeue();
                }
            }

            void pUpdate()
            {
                p2 = Q2.Peek();
                p3 = Q3.Peek();
                p5 = Q5.Peek();
            }

            return results;
        }

        /// <summary>
        /// 3. Дан список целых чисел (List<int>). Удалить из него все числа, делящиеся на первый элемент.
        /// </summary>
        public static List<int> Lab_08_03(List<int> source) =>
            source
            .Where(num => num % source.First() != 0)
            .ToList();

        /// <summary>
        /// 4. Дан список целых чисел. Между любыми двумя элементами одной чётности вставить число 0.
        /// </summary>
        public static List<int> Lab_08_04(List<int> source)
        {
            List<int> zerosPositions = new();

            for(int i = 0; i < source.Count - 1; i++)
                if (source[i] % 2 == source[i + 1] % 2)
                    zerosPositions.Add(i + zerosPositions.Count + 1);

            foreach (int pos in zerosPositions)
                source.Insert(pos, 0);

            return source;
        }

        /// <summary>
        /// 5. Решить две предыдущие задачи для двусвязного списка целых чисел (LinkedList<int>).
        /// 3. Дан список целых чисел (List<int>). Удалить из него все числа, делящиеся на первый элемент.
        /// </summary>
        public static LinkedList<int> Lab_08_05_03(LinkedList<int> source) =>
            new LinkedList<int>(
                source
                .Where(num => num % source.First() != 0)
                );

        /// <summary>
        /// 5. Решить две предыдущие задачи для двусвязного списка целых чисел (LinkedList<int>).
        /// 4. Дан список целых чисел. Между любыми двумя элементами одной чётности вставить число 0.
        /// </summary>
        public static LinkedList<int> Lab_08_05_04(LinkedList<int> source)
        {
            LinkedListNode<int> node = source.First;

            while (node.Next != null)
            {
                if (node.Value % 2 == node.Next.Value % 2)
                {
                    source.AddAfter(node, 0);
                    node = node.Next.Next;
                }
                else
                    node = node.Next;      
            }  

            return source;
        }

        /// <summary>
        /// 7. Даны несколько текстовых файлов, каждая срока которых содержит фамилию и имя студента.
        ///Найти студентов, имена которых присутствуют во всех файлах.
        /// </summary>
        public static List<string> Lab_08_07(params string[] paths)
        {
            foreach (string path in paths)
                if (!File.Exists(path))
                    throw new FileNotFoundException("Файл не найден ", path);

            HashSet<string>[] names = new HashSet<string>[paths.Length];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = File.ReadAllLines(paths[i]).ToHashSet();
                if (i >= 1)
                    names[0].IntersectWith(names[i]);
            }

            return names[0].ToList();   
        }

        /// <summary>
        /// 8. Найти самое часто встречающееся слово в текстовом файле.
        /// </summary>
        static public KeyValuePair<string, int> Lab_08_08(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("Файл не найден ", path);

            Dictionary<string, int> keyValues = new();

            string[] strings = File.ReadAllLines(path);

            string word;
            foreach(string s in strings)
                foreach(Match match in Regex.Matches(s, @"\b[а-яА-Яa-zA-Z]+\b"))
                {
                    word = match.Value;

                    if (keyValues.ContainsKey(word))
                        keyValues[word]++;
                    else
                        keyValues.Add(word, 1);
                }

            KeyValuePair<string, int> result = new("", 0);
            foreach (var pair in keyValues)
                if (pair.Value > result.Value)
                    result = pair;

            return result;
        }

        /// <summary>
        /// 9. Дан текстовый файл, каждая строка которого содержит 
        /// а) идентификатор некоторой вершины ориентированного графа и
        /// б) список идентификаторов инцидентных ей вершин, то есть тех, в которые из вершины,
        /// указанной в начале строки, выходит дуга
        /// (идентификаторы — это последовательности латинских букв и цифр,
        /// идентификаторы разделяются пробелами, список вершин может быть пустым). 
        /// Можно считать, что параллельных дуг(с совпадающими началами и концами) в графе нет.Пример файла:

        /// v1 v2 v3
        /// v2
        /// v3 v1
        /// Проверить, что граф задан этим файлом корректно, а именно:
        /// идентификаторы вершин, указанных первыми, не повторяются;
        /// все упомянутые в списках вершин идентификаторы в одной из строк указаны на первой позиции.

        /// 10. Для графа, заданного файлом в формате из предыдущего упражнения, выполнить следующее:
        /// посчитать общее количество дуг в графе;
        /// построить матрицу инцидентности;
        /// найти вершины, в которые не входит ни одной дуги.
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void Lab_08_0910(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден ", path);

            Graph graph = new(path);
            graph.PrintIncidenceMatrix();
            Console.WriteLine($"Общее количество дуг в графе = {graph.GetArcsNomber()}");
            Console.WriteLine($"Вершины, в которые не входит ни одной дуги: ");
            foreach (var name in graph.GetFreeVertexesNames())
                Console.Write(name + ", ");
        }        

        public class Graph 
        {
            Dictionary<string, Node> graph = new();

            public Graph(string path) =>
                CreateGraph(path);

            private void CreateGraph(string path)
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("Файл не найден ", path);

                string[][] graphRawData = File.ReadAllLines(path)
                    .Select(str => str.Split(' ', '\t'))
                    .ToArray();

                //Сначала добавляем все существующие вершины
                foreach (string[] vertexData in graphRawData)
                    if (graph.ContainsKey(vertexData[0]))
                        throw new Exception
                            ($"Идентификатор вершины {vertexData[0]} повторяется в исходных данных");
                    else
                        graph.Add(vertexData[0], new Node(vertexData[0]));

                //Далее для каждой вершины привязываем ссылки на другие вершины
                foreach (string[] vertexData in graphRawData)
                {
                    Node node = graph.GetValueOrDefault(vertexData[0]);

                    for(int i = 1; i < vertexData.Length; i++)
                    {

                        Node target;
                        if (!graph.TryGetValue(vertexData[i], out target))
                            throw new Exception
                                ($"Дуга из вершины {node.name} в вершину {vertexData[i]} " +
                                $"не может существовать, т.к. вершина {vertexData[i]} " +
                                $"не задана в исходных данных");
                        else
                        {
                            node.nodeTargets.Add(target);
                            target.nodeSourses.Add(node);
                        }     
                    }
                }
            }

            /// <summary>
            /// посчитать общее количество дуг в графе;
            /// </summary>
            public int GetArcsNomber()
            {
                int i = 0;
                foreach (var pair in graph)
                    i += pair.Value.nodeTargets.Count;
                return i;
            }

            /// <summary>
            /// найти вершины, в которые не входит ни одной дуги.
            /// </summary>
            /// <remarks>
            /// "Не входит" трактую как вершины, которые не являются концом дуг,
            ///  но могут являться началом дуг
            /// </remarks>
            public List<string> GetFreeVertexesNames()
            {
                List<string> result = new();
                foreach (var pair in graph)
                    if (pair.Value.nodeSourses.Count == 0)
                        result.Add(pair.Key);
                return result;
            }

            /// <summary>
            /// Вывести матрицу инцидентности
            /// </summary>
            public void PrintIncidenceMatrix()
            {
                int vertrxesNomber = graph.Count();
                int arcsNomber = GetArcsNomber();

                string[] vertexNames = graph.Keys.Order().ToArray();
                string[] arcsNames = new string[arcsNomber + 1];
                arcsNames[0] = "";

                int[,] incidenceMatrix = new int[vertrxesNomber, arcsNomber];

                int column = 0;
                int rowSourceNomber, rowTargetNomber;

                //Перебираем все вершины графа
                foreach(var pairSource in graph)
                    //Для каждого вытаскиваем все уходящие дуги
                    foreach(var arcToTarget in pairSource.Value.GetArcsToTargets())
                    //Для каждой дуги переносим данные в матрицу инцидентности
                    {
                        rowSourceNomber = Array.IndexOf(vertexNames, pairSource.Key);
                        rowTargetNomber = Array.IndexOf(vertexNames, arcToTarget.Value.name);
                        arcsNames[column + 1] = arcToTarget.Key;
                        incidenceMatrix[rowSourceNomber, column] = -1;
                        incidenceMatrix[rowTargetNomber, column] = 1;
                        column++;
                    }

                //Первая строка с именами дуг
                for (int i = 0; i < arcsNames.Length; i++)
                    Console.Write($"{arcsNames[i], 8}");
                Console.WriteLine();

                //Остальные строки
                for(int row = 0; row < incidenceMatrix.GetUpperBound(0) + 1; row++)
                {
                    Console.Write($"{vertexNames[row], 8}");

                    for (column = 0; column < incidenceMatrix.GetUpperBound(1) + 1; column++)
                        Console.Write($"{incidenceMatrix[row, column],8}");
                    Console.WriteLine();
                }
            }

            class Node : IComparable
            {
                public readonly string name;
                public Node(string name)
                {
                    this.name = name;
                }

                //Вершины, из которых в эту вершину приходят дуги (рёбра)
                public SortedSet<Node> nodeSourses = new();
                //Вершины, в которые из этой вершины уходят дуги (рёбра)
                public SortedSet<Node> nodeTargets = new();

                public SortedDictionary<string, Node> GetArcsToTargets()
                {
                    string arcName;
                    SortedDictionary<string, Node> arcsToTargets = new();
                    
                    foreach(var nodeTarget in nodeTargets)
                    {
                        arcName = this.name + "-" + nodeTarget.name;
                        arcsToTargets.Add(arcName, nodeTarget);
                    }

                    return arcsToTargets;
                }

                public override bool Equals(object? obj) => 
                    obj is Node node && name == node.name;
                
                public override int GetHashCode() =>
                    HashCode.Combine(name);

                public int CompareTo(object? obj)
                {
                    if (obj is not Node node)
                        throw new ArgumentException("obj is not Node");
                    return string.Compare(name, node.name);
                }
            }
        }
    }
}
