using System;
using System.Collections.Generic;
using System.Text;

namespace Elements_of_higher_mathematics
{
    public class Matrix
    {
        public int[,] MatrixValue { get; private set; }

        public Matrix() { }

        public Matrix(int[,] matrixValue)
        {
            MatrixValue = matrixValue;
        }

        /// <summary>
        /// Метод сложения матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <returns> Результат сложения матриц. </returns>
        public static Matrix MatrixAddition(Matrix matrixA, Matrix matrixB)
        {
            Matrix matrixResult = AdditionAndSubtraction(matrixA, matrixB, enumAdditionAndSubtraction.Addition);

            return matrixResult;
        }

        /// <summary>
        /// Метод вычитания матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <returns> Результат вычитания матриц. </returns>
        public static Matrix MatrixSubtraction(Matrix matrixA, Matrix matrixB)
        {
            Matrix matrixResult = AdditionAndSubtraction(matrixA, matrixB, enumAdditionAndSubtraction.Subtraction);

            return matrixResult;
        }

        /// <summary>
        /// Метод перемножения матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <returns> результат перемножения матриц. </returns>
        public static Matrix MatrixMultiplication(Matrix matrixA, Matrix matrixB)
        {
            var matrixAColumnLength = matrixA.MatrixValue.GetLength(0); // длина колонки матрицы А.
            var matrixARowLength = matrixA.MatrixValue.GetLength(1); // длина строки матрицы А.

            var matrixBColumnLength = matrixB.MatrixValue.GetLength(0); // длина колонки матрицы В. 
            var matrixBRowLength = matrixB.MatrixValue.GetLength(1); // длина строки матрицы В.

            Matrix newMatrix = new Matrix(new int[matrixAColumnLength, matrixBRowLength]); // новая матрица.

            if (matrixARowLength == matrixBColumnLength)
            {
                int sum;
                for (int i = 0; i < matrixAColumnLength; i++)
                {
                    for (int j = 0; j < matrixBRowLength; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < matrixARowLength; k++)
                        {
                            sum = sum + (matrixA.MatrixValue[i, k] * matrixB.MatrixValue[k, j]);
                        }
                        newMatrix.MatrixValue[i, j] = sum;
                    }
                }
            }
            else
            {
                Console.WriteLine("Эти матрицы не могут быть перемножены.");
            }

            return newMatrix;
        }

        /// <summary>
        /// Метод перемножения матрицы на число.
        /// </summary>
        /// <param name="number"> Число. </param>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Матрица умноженная на число. </returns>
        public static Matrix MatrixMultiplication(int number, Matrix matrix)
        {
            var matrixColumnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var matrixRowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            Matrix matrixResult = new Matrix(new int[matrixColumnLength, matrixRowLength]); // результат перемножения.

            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    matrixResult.MatrixValue[i, j] = number * matrix.MatrixValue[i, j];
                }
            }

            return matrixResult;
        }

        /// <summary>
        /// Метод сложения и вычитания матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <param name="additionOrSubtraction"> Выбор какое действие должно происходить сложение или вычитание. </param>
        /// <returns> Результат сложения или вычитания матриц. </returns>
        private static Matrix AdditionAndSubtraction(Matrix matrixA, Matrix matrixB, enumAdditionAndSubtraction additionOrSubtraction)
        {
            var matrixAColumnLength = matrixA.MatrixValue.GetLength(0); // длина колонки матрицы А.
            var matrixARowLength = matrixA.MatrixValue.GetLength(1); // длина строки матрицы А.

            var matrixBColumnLength = matrixB.MatrixValue.GetLength(0); // длина колонки матрицы В. 
            var matrixBRowLength = matrixB.MatrixValue.GetLength(1); // длина строки матрицы В.

            Matrix matrixResult = new Matrix(new int[matrixAColumnLength, matrixBRowLength]); // результат сложения.

            if (matrixAColumnLength == matrixBColumnLength && matrixARowLength == matrixBRowLength)
            {
                for (int i = 0; i < matrixAColumnLength; i++)
                {
                    for (int j = 0; j < matrixBRowLength; j++)
                    {
                        if (additionOrSubtraction == enumAdditionAndSubtraction.Addition)
                        {
                            matrixResult.MatrixValue[i, j] = matrixA.MatrixValue[i, j] + matrixB.MatrixValue[i, j];
                        }
                        else if (additionOrSubtraction == enumAdditionAndSubtraction.Subtraction)
                        {
                            matrixResult.MatrixValue[i, j] = matrixA.MatrixValue[i, j] - matrixB.MatrixValue[i, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Эти матрицы не равны.");
            }

            return matrixResult;
        }


        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            return MatrixAddition(matrixA, matrixB);
        }

        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            return MatrixSubtraction(matrixA, matrixB);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            return MatrixMultiplication(matrixA, matrixB);
        }

        public static Matrix operator *(int Number, Matrix matrixB)
        {
            return MatrixMultiplication(Number, matrixB);
        }

    }
}
