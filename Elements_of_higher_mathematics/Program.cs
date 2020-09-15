using Elements_of_higher_mathematics.Matrixes;
using System;
using System.Net.Http.Headers;

namespace Elements_of_higher_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            //# region squareMatrix

            SquareMatrix squareMatrix = new SquareMatrix();
            Matrix matrix = new Matrix();
            MatrixEquationSystems matrixEquationSystems = new MatrixEquationSystems();



            var matrixA = new Matrix(new double[3, 3] { { 7, -4, 5 }, { 8, -1, 0 }, { 6, 9, -3 } });

            var matrixB = new Matrix(new double[4, 4] { { 2, -5, 1, 2 }, { -3, 7, -1, 4 }, { 5, -9, 2, 7 }, { 4, -6, 1, 2 } });

            var matrixC = new Matrix(new double[3, 3] { { 2, 3, 2 }, { 1, 2, -3 }, { 3, 4, 1 } });

            var matrixD = new Matrix(new double[4, 4] { { 6, 8, 9, -12 }, { 4, 6, -6, -9 }, { -3, -4, 6, 8 }, { -2, -3, 4, 6 } });

            var matrixE = new Matrix(new double[2, 2] { { 7, -4 }, { 8, -1 } });


            var matrix_1_27 = new Matrix(new double[4, 4] { { 3, 1, 2, -3 }, { 8, 0, -4, -1 }, { 2, -2, 3, 4 }, { 2, 1, 1, 2 } });

            var matrix_2_27 = new Matrix(new double[3, 3] { { 2, 1, 3 }, { 3, 2, 4 }, { 2, -3, 1 } });

            var matrix2_2_27 = new Matrix(new double[3, 1] { { 3 }, { 7 }, { 1 } });

            var matrixMinor = new Matrix(new double[3, 5] { { 2, -1, 5, 0, 6 }, { 7, 2, 3, 1, 3 }, { 1, 4, 2, 0, 3 } });

            var result = squareMatrix.FindMinorMatrix(matrixMinor, 3, 3, 4);

            Console.WriteLine(result);

            //for (int i = 0; i < result.MatrixValue.GetLength(0); i++)
            //{
            //    for (int j = 0; j < result.MatrixValue.GetLength(1); j++)
            //    {
            //        Console.Write($"{result.MatrixValue[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
