using System;

namespace Elements_of_higher_mathematics
{
    class Matrix
    {
        /// <summary>
        /// Метод нахождения определителя матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель. </returns>
        public int FindDeterminant(int[,] matrix)
        {          
            var rowLength = matrix.GetLength(1); // длина строки.
            var columnLength = matrix.GetLength(0); // длина колонки.

            var mainDiagonal = FindMainDiagonal(columnLength, rowLength, matrix); // главная диагональ.
            var sideDiagonal = FindSideDiagonal(columnLength, rowLength, matrix); // побочная диагональ.

            var determinant = mainDiagonal - sideDiagonal; // Вычисление определителя.

            return determinant;
        }

        /// <summary>
        /// Получает главную диагональ.
        /// </summary>
        /// <param name="columnLength"> Длина колонки матрицы. </param>
        /// <param name="rowLength"> Длина строки матрицы. </param>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Главная диагональ. </returns>
        private int FindMainDiagonal(int columnLength, int rowLength, int[,] matrix)
        {
            var result = 1;

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (i == j)
                    {
                        result *= matrix[i, j];
                        Console.WriteLine(matrix[i, j]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получает побочную диагональ.
        /// </summary>
        /// <param name="columnLength"> Длина колонки матрицы. </param>
        /// <param name="rowLength"> Длина строки матрицы. </param>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> побочная диагональ. </returns>
        private int FindSideDiagonal(int columnLength, int rowLength, int[,] matrix)
        {
            var result = 1;
            var number = 0;

            for (int i = columnLength - 1; i >= 0; i--)
            {
                var repeat = 0;
                var isRepeat = false;
                for (int j = 0; j < rowLength; j++)
                {
                    if (isRepeat == false)
                    {
                        if (repeat == number)
                        {
                            number++;
                            isRepeat = true;
                            result *= matrix[i, j];
                            Console.WriteLine(matrix[i, j]);
                        }
                        else
                        {
                            repeat++;
                        }
                    }
                }
            }

            return result;
        }

    }
}
