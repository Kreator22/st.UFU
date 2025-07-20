using System.Text;

namespace Lab_11
{
    public class LinePrinter
    {
        public int N
        {
            get { return n; }
            set { n = value >= 1 ? value : 1; }
        }
        internal int n;

        public LinePrinter(int subLength = 11) =>
            N = subLength;

        public virtual void Print(string line)
        {
            for (int i = 0; i < line.Length / n; i++)
                Console.WriteLine(line.Substring(i * n, n));
        }

        public void FancyPrint(IEnumerable<string> strings)
        {
            int length = 0;
            foreach (var str in strings)
                if (str.Length > length)
                    length = str.Length;

            foreach (var str in strings)
                Print(PadFancy(str, length));
        }

        protected string PadFancy(string str, int N)
        {
            if(str.Length < N)
            {
                StringBuilder sb = new();
                sb.Append(str);
                for (int i = 0; i < N - str.Length; i++)
                    sb.Append(Random.Shared.Next(10));
                str = sb.ToString();
            }

            return str;
        }
    }

    public class NumberedLinePrinter : LinePrinter
    {
        public NumberedLinePrinter(int subLength = 11) : base(subLength) { }

        public override void Print(string line)
        {
            for (int i = 0; i < line.Length / n; i++)
                Console.WriteLine(i + ". " + line.Substring(i * n, n));
        }
    }

    public class HidingLinePrinter : LinePrinter
    {
        public char[] hidenChars { get; set; }
        public HidingLinePrinter(char[] hidenChars, int subLength = 11) : base(subLength) 
        {
            this.hidenChars = hidenChars;
        }
        

        public override void Print(string line)
        {
            StringBuilder sb = new(line.Length);

            for(int i = 0; i < line.Length; i++)
            {
                if (hidenChars.Contains(line[i]))
                {
                    sb.Append('*');
                    continue;
                }
                sb.Append(line[i]);
            }

            line = sb.ToString();
            for (int i = 0; i < line.Length / n; i++)
                Console.WriteLine(i + ". " + line.Substring(i * n, n));
        }
    }

    public class NumberedLinePrinterWithLinesNumber : LinePrinter
    {
        public NumberedLinePrinterWithLinesNumber(int subLength = 11) : base(subLength) { }

        public override void Print(string line)
        {
            Console.WriteLine("Всего строк " + line.Length / n);
            for (int i = 0; i < line.Length / n; i++)
                Console.WriteLine(i + ". " + line.Substring(i * n, n));
        }
    }
}
