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
            AugmentedMatrix augmentedMatrix = new AugmentedMatrix();


            var matrixA = new Matrix(new double[3, 5] { { 2, -1, 3, -2, 4 }, { 4, -2, 5, 1, 7 }, { 2, -1, 1, 8, 2 } });

            var matrixB = new Matrix(new double[4, 4] { { 2, -5, 1, 2 }, { -3, 7, -1, 4 }, { 5, -9, 2, 7 }, { 4, -6, 1, 2 } });

            var matrixC = new Matrix(new double[3, 3] { { 2, 3, 2 }, { 1, 2, -3 }, { 3, 4, 1 } });

            var matrixD = new Matrix(new double[3, 4] { { 1, 2, 4, -5 }, { -4, 1, 3, 7 }, { -2, 5, 11, -3 } });

            var matrixE = new Matrix(new double[2, 2] { { 7, -4 }, { 8, -1 } });

            var matrixF = new Matrix(new double[4, 5] { { 11, -13, 61, 10, -11 }, { 2, -2, 11, 2, -2 }, { -3, 5, -17, -2, 3 }, { 4, 0, 24, 7, -8 } });


            var matrix_1_27 = new Matrix(new double[4, 4] { { 3, 1, 2, -3 }, { 8, 0, -4, -1 }, { 2, -2, 3, 4 }, { 2, 1, 1, 2 } });

            var matrix_2_27 = new Matrix(new double[3, 4] { { 1, 5, 4, 3 }, { 1, -1, 2, -1 }, { 5, 3, 8, 1 } });

            var matrix2_2_27 = new Matrix(new double[3, 1] { { 1 }, { 0 }, { 1 } });

            //var res = matrixA.MethodThatResetsTheColumnValues(0, 0);

            //var res2 = res.MethodThatResetsTheColumnValues(1, 1);

            Console.WriteLine(matrixD.FindRank());

            //var AugmentedMatrix = new AugmentedMatrix(matrix_2_27, matrix2_2_27);

            //AugmentedMatrix.Matrix = AugmentedMatrix.Matrix.SwapColumnsOrRows(1, 2);

            //for (int i = 0; i < res2.MatrixValue.GetLength(0); i++)
            //{
            //    for (int j = 0; j < res2.MatrixValue.GetLength(1); j++)
            //    {
            //        Console.Write($"{res2.MatrixValue[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
