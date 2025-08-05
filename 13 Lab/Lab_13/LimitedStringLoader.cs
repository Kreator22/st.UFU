using System.IO.Enumeration;
using System.Text.RegularExpressions;

namespace Lab_13
{
    /// <summary>
    /// Загрузка файла с предуставновленными ограничениями
    /// </summary>
    public class LimitedStringLoader
    {
        /// <summary>
        /// Запрещенные символы
        /// </summary>
        public string Prohibited { get; protected set; }

        /// <summary>
        /// Ошибочные символы
        /// </summary>
        public string Erroneus { get; protected set; }

        /// <summary>
        /// Ограничение на количество запрещенных символов
        /// </summary>
        public int ProLimit { get; protected set; }

        /// <summary>
        /// Счетчик встреченных запрещенных символов
        /// </summary>
        private int proTimes;

        private List<string> strings;
        public List<string> Strings {
            get
            {
                if (strings is not null && strings.Any())
                    return strings;
                else
                    throw new Exception("DataNotLoaded");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prohibited">Запрещенные символы</param>
        /// <param name="erroneus">Ошибочные символы</param>
        /// <param name="proLimit"></param>
        public LimitedStringLoader(string prohibited, string erroneus, int proLimit)
        {
            Prohibited = prohibited;
            Erroneus = erroneus;
            ProLimit = proLimit;

            var intersection = prohibited.ToHashSet().Intersect(erroneus.ToHashSet());

            if (intersection.Any())
                throw new InconsistentLimits(intersection);
        }

        public void Load(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("Файл не найден", fileName);

            List<string> _strings = new();

            int i = 0;
            foreach(string line in File.ReadLines(fileName))
            {
                char first = line[0];

                if (Prohibited.Contains(first))
                    if (proTimes >= ProLimit)
                        throw new TooManyProhibitedLines();
                    else
                        proTimes++;

                else if (Erroneus.Contains(first))
                    throw new WrongStartingSymbol(first, i);

                else if (!Regex.IsMatch(first.ToString(), @"[A-Z]"))
                    throw new IncorrectString(i);

                _strings.Add(line);
                i++;
            }

            strings = _strings;
        }
    }

    public class InconsistentLimits : ArgumentException
    {
        private static string _message =
            "В запрещённых и одинаковых символах не может быть одинаковых символов";
        public InconsistentLimits(IEnumerable<char> symbols) : base(_message)
        {
            foreach (char c in symbols)
                Data.Add(c, c);
        }

        public InconsistentLimits(char c) : base(_message) =>
            Data.Add(c, c);
    }

    public class WrongStartingSymbol : Exception
    {
        private static string _message =
            "Строка начинается с ошибочного (erroneus) символа";

        public WrongStartingSymbol(char c, int stringNumber) : base(_message) =>
            Data.Add(stringNumber, c);
    }

    public class TooManyProhibitedLines : Exception
    {
        private static string _message =
            "Запрещенные (prohibited) символы встретились слишком много раз";

        public TooManyProhibitedLines() : base(_message) { }
    }

    public class IncorrectString : Exception
    {
        private static string _message =
            "Строка началась не с заглавной латинской буквы";

        public IncorrectString(int stringNumber) : base(_message) =>
            Data.Add(stringNumber, stringNumber);
    }
}
