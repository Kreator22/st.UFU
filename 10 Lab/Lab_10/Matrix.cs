using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace Lab_10
{
    public class Matrix : ICloneable
    {
        public uint Rows { get; private set; }
        public uint Columns { get; private set; }
        double[,] Elements;

        public Matrix(uint rows, uint columns)
        {
            Rows = rows;
            Columns = columns;
            Elements = new double[rows, columns];
        }

        public Matrix(uint rows, uint columns, params double[] elements) : this(rows, columns)
        {
            if (elements.Length != rows * columns)
                throw new ArgumentOutOfRangeException(nameof(elements),
                    $"Количество элементов {elements.Length} не совпадает с " +
                    $"необходимым количеством элементов матрицы {rows} * {columns} = {rows * columns}");

            uint element = 0;
            for (uint row = 0; row < rows; row++)
                for (uint column = 0; column < columns; column++, element++)
                    Elements[row, column] = elements[element];
        }

        public Matrix(Matrix matrix) : this(matrix.Rows, matrix.Columns)
        {
            for (uint row = 0; row < matrix.Rows; row++)
                for (uint column = 0; column < matrix.Columns; column++)
                    Elements[row, column] = matrix[row, column];
        }

        //Индексатор
        public double this[uint row, uint column]
        {
            get 
            {
                CheckIndices(row, column);
                return Elements[row, column]; 
            }
            set
            {
                CheckIndices(row, column);
                Elements[row, column] = value;
            }
        }

        public double[,] GetElements() =>
            (double[,])Elements.Clone();

        private void CheckIndices(uint row, uint column)
        {
            if (row > Rows)
                throw new IndexOutOfRangeException
                    ($"Индекс row = {row} больше количества строк в матрице = {Rows}");

            if (column > Columns)
                throw new IndexOutOfRangeException
                    ($"Индекс row = {column} больше количества столбцов в матрице = {Columns}");
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            for (uint row = 0; row < Rows; row++)
            {
                for (uint column = 0; column < Columns; column++)
                    sb.Append($"{double.Round(this[row, column], 2), 8}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public object Clone() =>
            new Matrix(this);

        public static Matrix operator +(Matrix left, Matrix right) =>
            Operation(left, right, (l, r) => l + r);

        public static Matrix operator -(Matrix left, Matrix right) =>
            Operation(left, right, (l, r) => l - r);

        public static Matrix operator *(Matrix left, Matrix right) =>
            Operation(left, right, (l, r) => l * r);

        private static Matrix Operation(Matrix left, Matrix right, Func<double, double, double> operation)
        {
            CheckOperands(left, right);
            Matrix result = new Matrix(left.Rows, left.Columns);

            for (uint row = 0; row < result.Rows; row++)
                for (uint column = 0; column < result.Columns; column++)
                    result[row, column] = operation(left[row, column], right[row, column]);

            return result;
        }

        private static void CheckOperands(Matrix left, Matrix right)
        {
            if (left.Rows != right.Rows)
                throw new IndexOutOfRangeException("Количество строк в матрицах операндах не совпало");
            if (left.Columns != right.Columns)
                throw new IndexOutOfRangeException("Количество столбцов в матрицах операндах не совпало");
        }
    }
}
