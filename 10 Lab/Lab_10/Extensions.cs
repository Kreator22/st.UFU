using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public static class Extensions
    {
        /// <summary>
        /// Заполнить матрицу случайными числами
        /// </summary>
        /// <typeparam name="T">Int или double</typeparam>
        public static void FillMatrixWithRandom<T>(this Matrix matrix, double min = 0, double max = 10)
        {
            for (uint row = 0; row < matrix.Rows; row++)
                for (uint column = 0; column < matrix.Columns; column++)
                    matrix[row, column] =
                        typeof(T) == typeof(double) ?
                        Random.Shared.NextDouble() * (max - min) + min :
                        Random.Shared.Next((int)min, (int)max);
        }

        public static void SwapRows(this Matrix matrix, uint row1, uint row2)
        {
            CheckRowRange(matrix, row1);
            CheckRowRange(matrix, row2);

            for (uint column = 0; column < matrix.Columns; column++)
                (matrix[row1, column], matrix[row2, column]) = (matrix[row2, column], matrix[row1, column]);
        }

        static void CheckRowRange(this Matrix matrix, uint row)
        {
            if (row > matrix.Rows)
                throw new ArgumentOutOfRangeException
                    ($"Попытка обратиться к строке {row} в матрице с количеством строк {matrix.Rows}",
                    nameof(row));
        }

        public static void SwapColumns(this Matrix matrix, uint column1, uint column2)
        {
            CheckColumnRange(matrix, column1);
            CheckColumnRange(matrix, column2);

            for (uint row = 0; row < matrix.Rows; row++)
                (matrix[row, column1], matrix[row, column2]) = (matrix[row, column2], matrix[row, column1]);
        }

        static void CheckColumnRange(this Matrix matrix, uint column)
        {
            if (column > matrix.Columns)
                throw new ArgumentOutOfRangeException
                    ($"Попытка обратиться к строке {column} в матрице с количеством строк {matrix.Columns}",
                    nameof(column));
        }

        public static (uint row, uint column) GetMaxElementIndexes(this Matrix matrix)
        {
            double max = double.MinValue;
            uint row = 0, column = 0;
            for(uint i = 0; i < matrix.Rows; i++)
                for(uint j = 0; j < matrix.Columns; j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        column = j;
                    }
            return (row, column);   
        }

        public static void SwapMaxElementToUpLeftAngle(this Matrix matrix)
        {
            (uint row, uint column) = matrix.GetMaxElementIndexes();
            matrix.SwapRows(0, row);
            matrix.SwapColumns(0, column);
        }

        public static void MultiplyRow(this Matrix matrix, uint row, double multiplier)
        {
            CheckRowRange(matrix, row);

            for (uint column = 0; column < matrix.Columns; column++)
                matrix[row, column] *= multiplier;
        }

        /// <summary>
        /// minuend - subtrahend = result
        /// </summary>
        public static void SubstractRows(this Matrix matrix, uint minuend, uint subtrahend)
        {
            CheckRowRange(matrix, minuend);
            CheckRowRange(matrix, subtrahend);

            for (uint column = 0; column < matrix.Columns; column++)
                matrix[minuend, column] -= matrix[subtrahend, column];
        }

        /// <summary>
        /// Матричное произведение, сложность O(n^3)
        /// </summary>
        public static Matrix MultiplyMatrixesNaive(this Matrix left, Matrix right)
        {
            if (left.Columns != right.Rows)
                throw new ArgumentOutOfRangeException
                    ("Матрицы left и right могут быть перемножены, если они совместимы в том смысле, " +
                    "что число столбцов матрицы left равно числу строк матрицы right.");

            uint rows = left.Rows;
            uint columns = right.Columns;
            double[] result = new double[rows * columns];

            uint element = 0;
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < columns; j++, element++)
                    for (uint k = 0; k < left.Columns; k++)
                        result[element] += left[i, k] * right[k, j];

            return new Matrix(rows, columns, result);
        }

        public static Matrix GetSubmatrix(
            this Matrix matrix, 
            uint startRow, 
            uint startColumn, 
            uint endRow, 
            uint endColumn)
        {
            matrix.CheckRowRange(startRow);
            matrix.CheckColumnRange(startColumn);
            matrix.CheckRowRange(endRow);
            matrix.CheckColumnRange(endColumn);

            uint rows = endRow - startRow + 1;
            uint columns = endColumn - startColumn + 1;

            double[] elements = new double[rows * columns];
            for (uint row = startRow, i = 0; row <= endRow; row++)
                for (uint column = startColumn; column <= endColumn; column++, i++)
                    elements[i] = matrix[row, column];

            return new Matrix(rows, columns, elements);
        }

        public static SquareMatrix GetLUMatrix(this SquareMatrix matrix)
        {
            (SquareMatrix L, SquareMatrix U) = matrix.GetLandUMatrixes();
            return (SquareMatrix)(L + U);
        }

        public static (SquareMatrix L, SquareMatrix U) GetLandUMatrixes(this SquareMatrix matrix)
        {
            //В матрицах можно переставлять местами строки и столбцы
            matrix.SwapMaxElementToUpLeftAngle();

            SquareMatrix L = new(matrix.Rows);
            SquareMatrix U = new(matrix);

            for(uint column = 0; column < U.Columns - 1; column++)
                for(uint row = column + 1; row < U.Rows; row++)
                {
                    if (U[column, column] == 0)
                    {
                        (uint row, uint column) newMaxElement = matrix
                             .GetSubmatrix(row, column, U.Rows, U.Columns)
                             .GetMaxElementIndexes();
                        U.SwapRows(row, newMaxElement.row);
                        U.SwapColumns(column, newMaxElement.column);
                    }

                    double m = U[row, column] / U[column, column];
                    L[row, column] = m;

                    U.MultiplyRow(column, m);
                    U.SubstractRows(row, column);
                    U.MultiplyRow(column, 1 / m);
                }

            for (uint row = 0, column = 0; row < L.Rows; row++, column++)
                L[row, column] = 1;

            return (L, U);
        }
    }
}
