using System;

namespace Elements_of_higher_mathematics
{
    public class Matrix
    {
        /// <summary>
        /// Метод перемножения матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <returns> результат перемножения матриц. </returns>
        public int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            var matrixAColumnLength = matrixA.GetLength(0); // длина колонки матрицы А.
            var matrixARowLength = matrixA.GetLength(1); // длина строки матрицы А.

            var matrixBColumnLength = matrixB.GetLength(0); // длина колонки матрицы В. 
            var matrixBRowLength = matrixB.GetLength(1); // длина строки матрицы В.

            int[,] newMatrix = new int[matrixAColumnLength, matrixBRowLength]; // новая матрица.

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
                            sum = sum + (matrixA[i, k] * matrixB[k, j]);
                        }
                        newMatrix[i, j] = sum;
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
        public int[,] MatrixMultiplication(int number, int[,] matrix)
        {
            var matrixColumnLength = matrix.GetLength(0); // длина колонки матрицы.
            var matrixRowLength = matrix.GetLength(1); // длина строки матрицы.

            int[,] matrixResult = new int[matrixColumnLength, matrixRowLength]; // результат перемножения.

            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    matrixResult[i, j] = number * matrix[i, j];
                }
            }

            return matrixResult;
        }

        /// <summary>
        /// Метод сложения матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <returns> Результат сложения матриц. </returns>
        public int[,] MatrixAddition(int[,] matrixA, int[,] matrixB)
        {
            int[,] matrixResult = AdditionAndSubtraction(matrixA, matrixB, enumAdditionAndSubtraction.Addition);

            return matrixResult;
        }

        /// <summary>
        /// Метод вычитания матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <returns> Результат вычитания матриц. </returns>
        public int[,] MatrixSubtraction(int[,] matrixA, int[,] matrixB)
        {
            int[,] matrixResult = AdditionAndSubtraction(matrixA, matrixB, enumAdditionAndSubtraction.Subtraction);

            return matrixResult;
        }

        /// <summary>
        /// Метод сложения и вычитания матриц.
        /// </summary>
        /// <param name="matrixA"> Матрица А. </param>
        /// <param name="matrixB"> Матрица В. </param>
        /// <param name="additionOrSubtraction"> Выбор какое действие должно происходить сложение или вычитание. </param>
        /// <returns> Результат сложения или вычитания матриц. </returns>
        private int[,] AdditionAndSubtraction(int[,] matrixA, int[,] matrixB, enumAdditionAndSubtraction additionOrSubtraction)
        {
            var matrixAColumnLength = matrixA.GetLength(0); // длина колонки матрицы А.
            var matrixARowLength = matrixA.GetLength(1); // длина строки матрицы А.

            var matrixBColumnLength = matrixB.GetLength(0); // длина колонки матрицы В. 
            var matrixBRowLength = matrixB.GetLength(1); // длина строки матрицы В.

            int[,] matrixResult = new int[matrixAColumnLength, matrixBRowLength]; // результат сложения.

            if (matrixAColumnLength == matrixBColumnLength && matrixARowLength == matrixBRowLength)
            {
                for (int i = 0; i < matrixAColumnLength; i++)
                {
                    for (int j = 0; j < matrixBRowLength; j++)
                    {
                        if (additionOrSubtraction == enumAdditionAndSubtraction.Addition)
                        {
                             matrixResult[i, j] = matrixA[i, j] + matrixB[i, j];
                        }
                        else if (additionOrSubtraction == enumAdditionAndSubtraction.Subtraction)
                        {
                            matrixResult[i, j] = matrixA[i, j] - matrixB[i, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Нельзя сложить эти матрицы.");
            }

            return matrixResult;
        }

    }
}
