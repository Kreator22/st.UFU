namespace HW_09
{
    public class Temperature : IComparable<Temperature>
    {
        //температура в градусах Кельвина
        private double tempK;
        //исходное представление температуры
        private string orig;
        //описание температуры
        private string desc;

        public double C { get { return KtoC(tempK); } }
        public double F { get { return KtoF(tempK); } }
        public double K { get { return tempK; } }

        public Temperature(string temperature, string description)
        {
            if (!double.TryParse(temperature.Substring(0, temperature.Length - 1), out double temp))
                throw new ArgumentException("Не строка с температурой", temperature);

            switch (temperature.Last())
            {
                case 'C' or 'c':
                    tempK = CtoK(temp);
                    break;
                case 'F' or 'f':
                    tempK = FtoK(temp);
                    break;
                case 'K' or 'k':
                    tempK = temp;
                    break;
                default:
                    throw new ArgumentException("Неизвестная шкала температуры", temperature);
            }

            if (tempK < 0)
                throw new ArgumentException
                    ("Температура не может быть ниже абсолютного ноля", nameof(temperature));

            orig = temperature;
            desc = description;
        }

        static double KtoC(double k) => k - 273.15;
        static double KtoF(double k) => (k - 273.15) * 1.8 + 32.00;
        static double CtoK(double c) => c + 273.15;
        static double CtoF(double c) => c * 1.80 + 32.00;
        static double FtoK(double f) => (f - 32) / 1.8 + 273.5;
        static double FtoC(double f) => (f - 32) / 1.8;

        public override string ToString() =>
            orig + " " + desc;

        public int CompareTo(Temperature? other)
        {
            if (other is null)
                throw new NullReferenceException();

            return K.CompareTo(other.K);
        }
    }
}
