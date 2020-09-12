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



            var matrixA = new Matrix(new double[3, 3] { { 7, -4, 5 }, { 8, -1, 0 }, { 6, 9, -3 } });

            var matrixB = new Matrix(new double[4, 4] { { 2, -5, 1, 2 }, { -3, 7, -1, 4 }, { 5, -9, 2, 7 }, { 4, -6, 1, 2 } });

            var matrixC = new Matrix(new double[3, 3] { { 2, 3, 2 }, { 1, 2, -3 }, { 3, 4, 1 } });

            var matrixD = new Matrix(new double[4, 4] { { 6, 8, 9, -12 }, { 4, 6, -6, -9 }, { -3, -4, 6, 8 }, { -2, -3, 4, 6 } });


            Console.WriteLine(squareMatrix.FindDeterminant(matrixA));

        }
    }
}
