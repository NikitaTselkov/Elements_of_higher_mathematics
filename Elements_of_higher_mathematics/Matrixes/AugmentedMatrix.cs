using System;
using System.Collections.Generic;
using System.Text;

namespace Elements_of_higher_mathematics.Matrixes
{
    public class AugmentedMatrix
    {
        /// <summary>
        /// Значения матрицы.
        /// </summary>
        public Matrix Matrix { get; private set; }

        /// <summary>
        /// Значения расширения матрицы.
        /// </summary>
        public double[,] AugmentedValue { get; private set; }

        /// <summary>
        /// Значения расширенной матрицы.
        /// </summary>
        public Matrix AugmentedMatrixValue { get; private set; }


        public AugmentedMatrix() { }

        public AugmentedMatrix(Matrix matrix, Matrix augmentedValue)
        {
            Matrix = matrix;
            AugmentedValue = augmentedValue.MatrixValue;

            var columnLength = Matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = Matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            AugmentedMatrixValue = new Matrix(new double[columnLength, rowLength + 1]); // Расширенная матрица.

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    AugmentedMatrixValue.MatrixValue[i, j] = Matrix.MatrixValue[i, j];
                }

                AugmentedMatrixValue.MatrixValue[i, rowLength] = AugmentedValue[i, 0];
            }
        }

        /// <summary>
        /// Метод Крамера.
        /// </summary>
        /// <returns> Матрица не известных значений. </returns>
        public Matrix MethodOfKramer(AugmentedMatrix augmentedMatrix)
        {
            Console.WriteLine();
            Console.WriteLine("Метод Крамера");
            Console.WriteLine();

            SquareMatrix squareMatrix = new SquareMatrix();
            MatrixEquationSystems matrixEquationSystems = new MatrixEquationSystems();

            var columnLengthAugmentedValue = AugmentedValue.GetLength(0); // длина колонки матрицы.
            var rowLengthAugmentedValue = AugmentedValue.GetLength(1); // длина строки матрицы.

            var columnLength = Matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = Matrix.MatrixValue.GetLength(1); // длина строки матрицы.


            var matrixResult = new Matrix(new double[columnLengthAugmentedValue, rowLengthAugmentedValue]); // Матрица с результатом.

            var newAugmentedMatrix = matrixEquationSystems.SaveAugmentedMatrix(augmentedMatrix);

            var determinant = squareMatrix.FindDeterminant(Matrix);

            if (determinant != 0 && columnLength == rowLength)
            {
                var iterator = 0;
                var systemDeterminant = 0.0;            

                while (true)
                {
                    var newMatrix = new Matrix(new double[columnLength, rowLength]); // Измененая матрица.

                    for (int i = 0; i < columnLength; i++)
                    {
                        for (int j = 0; j < rowLength; j++)
                        {
                            if (j == iterator)
                            {
                                newMatrix.MatrixValue[i, j] = newAugmentedMatrix.AugmentedValue[i, 0];
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = newAugmentedMatrix.Matrix.MatrixValue[i, j];
                            }
                        }
                    }

                    systemDeterminant = squareMatrix.FindDeterminant(newMatrix);

                    matrixResult.MatrixValue[iterator, 0] = systemDeterminant / determinant;

                    Console.WriteLine();
                    Console.WriteLine($"X {iterator + 1} = {matrixResult.MatrixValue[iterator, 0]}");
                    Console.WriteLine();

                    iterator++;

                    augmentedMatrix = newAugmentedMatrix;

                    if (iterator == columnLengthAugmentedValue)
                    {
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Через метод Крамера решения нет");
            }

            return matrixResult;
        }


    }
}
