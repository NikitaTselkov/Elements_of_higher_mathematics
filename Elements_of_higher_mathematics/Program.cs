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

            //var array = new Matrix(new double[3, 3] { { 7, -4, 2 }, { -2, 3, 0 }, { 5, -1, -8 } });

            //var array2 = new Matrix(new double[2, 2] { { 1, 2 }, { 4, 5 } });

            //var array3 = new Matrix(new double[4, 4] { { -1, 3, 2, -3 }, { 4, -2, 5, 1 }, { -5, 0, 4, 0 }, {9, 7, 8, -7 } });

            //var test = new Matrix(new double[4, 4] { { 3, -2, 6, 4 }, { 8, -6, 2, 12 }, { 5, -2, 3, 4 }, {7, 3, 0, 5 } });

            //var array4 = new Matrix(new double[3, 3] { { 5, 7, 1 }, { -4, 1, 0 }, { 2, 0, 3 } });



            //Console.WriteLine($" Определитель второго порядка: {squareMatrix.FindDeterminantOfTheSecondOrder(array2)}");

            //Console.WriteLine($" Минор: {squareMatrix.FindMinor(array4, 1, 2)}");

            //Console.WriteLine($" Алгебраическое дополнение: {squareMatrix.FindCofactor(array4, 1, 2)}");

            //Console.WriteLine($" Определитель: {squareMatrix.FindDecompositionOfMatrix(array, 1, enumMatrix.column)}");

            //#endregion


            //var array5 = new Matrix(new double[2, 3] { { 2, 3, -1 }, { 6, 1, -2 } });

            //var array6 = new Matrix(new double[3, 2] { { 4, -5 }, { -3, 0 }, { 1, 2 } });

            //var array7 = new Matrix(new double[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } });

            //var array8 = new Matrix(new double[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } });

            //Matrix matrixA = array;
            //Matrix matrixB = array4;

            //Matrix matrixC = matrixA * matrixB;
            //Matrix matrixD = matrixA - matrixB;
            //Matrix matrixF = matrixC + matrixD;

            //Matrix matrixG = array.MatrixTransposition();

            //foreach (var item in matrixG.MatrixValue)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(matrixG.IsMatrixTransposition);

            //Console.WriteLine($" Определитель: {squareMatrix.FindDecompositionOfMatrix(matrixG, 1, enumMatrix.column)}");

            //matrixG = matrixG.MatrixTransposition();

            //foreach (var item in matrixG.MatrixValue)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(matrixG.IsMatrixTransposition);

            //Console.WriteLine($" Определитель: {squareMatrix.FindDecompositionOfMatrix(array4, 1)}");
            //Console.WriteLine($" Определитель: {squareMatrix.FindDeterminantOfTheThirdOrder(array4)}");

            //var array9 = new Matrix(new double[3, 3] { { 2, -1, 4 }, { -3, 0, -2 }, { 2, 3, 1 } });

            //var array10 = new Matrix(new double[3, 2] { { 2, -1 }, { 4, 3}, { 0, -2 } });

            //var result = array9 * array10;

            //Console.WriteLine("Перемножение матриц A B");
            //Console.WriteLine();

            //foreach (var item in result.MatrixValue)
            //{
            //    Console.WriteLine(" " + item);
            //}

            //Console.WriteLine("Союзная матрица");
            //Console.WriteLine();

            //var array11 = new Matrix(new double[3, 3] { { 2, 4, 1 }, { 0, 2, 1 }, { 2, 1, 1 } });
            //var array12 = new Matrix(new double[3, 3] { {0, 0, 0 }, { 0, 2, 1 }, { 2, 1, 1 } });

            //foreach (var item in squareMatrix.FindInverseMatrix(array12).MatrixValue)
            //{
            //    Console.WriteLine(" " + item);
            //}

            var matrixA = new Matrix(new double[3, 3] { { 7, -4, 5 }, { 8, -1, 0 }, { 6, 9, -3 } });
            //var matrixA = new Matrix(new double[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } });
            //var matrixA = new Matrix(new double[3, 3] { { 0.5, 0.5, 0.5 }, { 2, 2, 2 }, { 3, 3, 3 } });
            var matrixB = squareMatrix.FindTheCommonMultiplier(matrixA);
            
            //matrixA = squareMatrix.FindUnionMatrix(matrixA);
            matrixA = squareMatrix.FindInverseMatrix(matrixA);
            matrixA = matrixA.MatrixTransposition();

            matrixA = squareMatrix.SwapColumnsOrRows(matrixA, 1, 2);
            Console.WriteLine(squareMatrix.FindDecompositionOfMatrix(matrixA, 2));
            //var matrixC = squareMatrix.FindDecompositionOfMatrix(matrixA, 2);


            foreach (var item in matrixB.MatrixValue)
            {
                Console.WriteLine(" " + item);
            }

            //Console.WriteLine(matrixB.CommonMultiplier);

            Console.WriteLine();

            //Console.WriteLine(matrixC);

            Console.WriteLine(matrixA.CommonMultiplier);
            Console.WriteLine(matrixA.IsMatrixInverse);
            Console.WriteLine(matrixA.IsMatrixTransposition);
            Console.WriteLine(matrixA.IsMatrixUnion);

            //Console.WriteLine(matrixB.DeterminantSign);
            //Console.WriteLine();

            //matrixB = squareMatrix.SwapColumnsOrRows(matrixB, 2, 1, enumMatrix.column);

            //foreach (var item in matrixB.MatrixValue)
            //{
            //    Console.WriteLine(" " + item);
            //}

            //Console.WriteLine(matrixB.DeterminantSign);
            //Console.WriteLine();

            //matrixB = squareMatrix.SwapColumnsOrRows(matrixB, 2, 1, enumMatrix.column);

            //foreach (var item in matrixB.MatrixValue)
            //{
            //    Console.WriteLine(" " + item);
            //}

            //Console.WriteLine(matrixB.DeterminantSign);
            //Console.WriteLine();

            //matrixB = squareMatrix.SwapColumnsOrRows(matrixB, 2, 1, enumMatrix.column);

            //foreach (var item in matrixB.MatrixValue)
            //{
            //    Console.WriteLine(" " + item);
            //}

            //Console.WriteLine(matrixB.DeterminantSign);



        }
    }
}
