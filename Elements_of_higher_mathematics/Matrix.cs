using System;
using System.Collections.Generic;
using System.Text;

namespace Elements_of_higher_mathematics
{
    public class Matrix
    {
        public int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            var matrixAColumnLength = matrixA.GetLength(0); // длина колонки матрицы А.
            var matrixARowLength = matrixA.GetLength(1); // длина строки матрицы А.

            var matrixBColumnLength = matrixB.GetLength(0); // длина колонки матрицы В. 
            var matrixBRowLength = matrixB.GetLength(1); // длина строки матрицы В.

            int[,] newMatrix = default;

            if (matrixARowLength == matrixBColumnLength)
            {
                newMatrix = new int[matrixAColumnLength, matrixBRowLength]; // новая матрица.
                var columnLength = newMatrix.GetLength(0); // длина колонки новой матрицы. 
                var rowLength = newMatrix.GetLength(1); // длина строки новой матрицы.

                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        var result = 0;
                        var res = 0;

                        int Aj = 0;
                        int Bi = 0;

                        cycle:

                        if (Aj < matrixARowLength)
                        {
                            res = matrixA[i, Aj];
                            Aj++;
                        }
                        if (Bi < matrixBColumnLength)
                        {
                            res *= matrixB[Bi, j];
                            Bi++;
                            result += res;

                            goto cycle;
                        }

                        newMatrix[i, j] = result;
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
