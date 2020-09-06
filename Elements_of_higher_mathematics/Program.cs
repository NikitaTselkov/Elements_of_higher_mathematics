using System;

namespace Elements_of_higher_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            # region squareMatrix

            SquareMatrix squareMatrix = new SquareMatrix();

            var array = new Matrix(new int[3, 3] { { 7, -4, 2 }, { -2, 3, 0 }, { 5, -1, -8 } });

            var array2 = new Matrix(new int[2, 2] { { 1, 2 }, { 4, 5 } });

            var array3 = new Matrix(new int[4, 4] { { -1, 3, 2, -3 }, { 4, -2, 5, 1 }, { -5, 0, 4, 0 }, {9, 7, 8, -7 } });

            var test = new Matrix(new int[4, 4] { { 2, 4, 1, 1 }, { 0, 2, 0, 0 }, { 2, 1, 1, 3 }, {4, 0, 2, 3 } });

            var array4 = new Matrix(new int[3, 3] { { 5, 7, 1 }, { -4, 1, 0 }, { 2, 0, 3 } });



            Console.WriteLine($" Определитель второго порядка: {squareMatrix.FindDeterminantOfTheSecondOrder(array2)}");

            Console.WriteLine($" Минор: {squareMatrix.FindMinor(array4, 1, 2)}");

            Console.WriteLine($" Алгебраическое дополнение: {squareMatrix.FindCofactor(array4, 1, 2)}");

            Console.WriteLine($" Определитель: {squareMatrix.FindDeterminant(array, 1, enumMatrix.column)}");

            #endregion


            var array5 = new Matrix(new int[2, 3] { { 2, 3, -1 }, { 6, 1, -2 } });

            var array6 = new Matrix(new int[3, 2] { { 4, -5 }, { -3, 0 }, { 1, 2 } });

            var array7 = new Matrix(new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } });

            var array8 = new Matrix(new int[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } });

            Matrix matrix = new Matrix();

            Matrix matrixA = array;
            Matrix matrixB = array4;

            Matrix matrixC = matrixA * matrixB;
            Matrix matrixD = matrixA - matrixB;
            Matrix matrixF = matrixC + matrixD;

            Matrix matrixG = array8.MatrixTransposition();

            foreach (var item in matrixG.MatrixValue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(matrixG.IsMatrixTransposition);

            matrixG = matrixG.MatrixTransposition();

            foreach (var item in matrixG.MatrixValue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(matrixG.IsMatrixTransposition);
        }
    }
}
