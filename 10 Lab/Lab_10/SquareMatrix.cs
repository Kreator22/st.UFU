using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(uint rows) : base(rows, rows) { }
        public SquareMatrix(uint rows, params double[] elements) : base(rows, rows, elements) { }
        public SquareMatrix(SquareMatrix squareMatrix) : base(squareMatrix)
        {
            if (squareMatrix.Rows != squareMatrix.Columns)
                throw new ArgumentException
                    ("Нельзя создать квадратную матрицу на основе прямоугольной", nameof(squareMatrix));
        }
    }
}
