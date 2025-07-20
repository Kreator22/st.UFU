using Lab_10;

namespace Lab_10_Tests
{
    [TestClass]
    public sealed class Lab_10_Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Matrix matrix = new(5, 5);
            matrix.FillMatrixWithRandom<int>();
            Console.WriteLine(matrix.ToString());
            Console.WriteLine(matrix.GetSubmatrix(1, 1, 3, 3));

            Matrix left = new(2, 2);
            left.FillMatrixWithRandom<int>();
            Matrix right = new(2, 2);
            right.FillMatrixWithRandom<int>();

            Console.WriteLine();
            Console.WriteLine(left + "  +");
            Console.WriteLine(right + "  =");
            Console.WriteLine((left + right));

            Console.WriteLine();
            Console.WriteLine(left + "  -");
            Console.WriteLine(right + "  =");
            Console.WriteLine((left - right));

            Console.WriteLine();
            Console.WriteLine(left + "  *");
            Console.WriteLine(right + "  =");
            Console.WriteLine((left * right));

            Console.WriteLine();
            Console.WriteLine(left + "  * (матричное произведение)");
            Console.WriteLine(right + "  =");
            Console.WriteLine((left.MultiplyMatrixesNaive(right)));

            SquareMatrix square = new(2, [1, 4, 6, 3]);
            Console.WriteLine("Матрица, для которой ищем LU разложение");
            Console.WriteLine(square);
            (uint row, uint column) = square.GetMaxElementIndexes();
            (SquareMatrix L, SquareMatrix U) = square.GetLandUMatrixes();
            Console.WriteLine("L = ");
            Console.WriteLine(L);
            Console.WriteLine("U = ");
            Console.WriteLine(U);
            Console.WriteLine("(матричное произведение) L * U = ");
            var LU = L.MultiplyMatrixesNaive(U);
            LU.SwapRows(0, row);
            LU.SwapColumns(0, column);
            Console.WriteLine(LU);

            square = new(3, [1, 4, 7, 5, 6, 9, 2, 3, 8]);
            Console.WriteLine("Матрица, для которой ищем LU разложение");
            Console.WriteLine(square);
            (row, column) = square.GetMaxElementIndexes();
            (L, U) = square.GetLandUMatrixes();
            Console.WriteLine("L = ");
            Console.WriteLine(L);
            Console.WriteLine("U = ");
            Console.WriteLine(U);
            Console.WriteLine("(матричное произведение) L * U = ");
            LU = L.MultiplyMatrixesNaive(U);
            LU.SwapRows(0, row);
            LU.SwapColumns(0, column);
            Console.WriteLine(LU);


        }


    }
}
