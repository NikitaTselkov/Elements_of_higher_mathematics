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
        public Matrix Matrix { get; set; }

        /// <summary>
        /// Значения расширения матрицы.
        /// </summary>
        public double[,] AugmentedValue { get; set; }

        /// <summary>
        /// Значения расширенной матрицы.
        /// </summary>
        public Matrix AugmentedMatrixValue { get; set; }


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

    }
}
