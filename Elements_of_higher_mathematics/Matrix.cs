using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
