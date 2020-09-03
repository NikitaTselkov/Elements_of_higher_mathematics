using System;
using System.Collections.Generic;

namespace Elements_of_higher_mathematics
{
    class Matrix
    {
        /// <summary>
        /// Метод нахождения определителя квадратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель квадратной матрицы. </returns>
        public int FindDeterminant(int[,] matrix)
        {          
            var columnLength = matrix.GetLength(0); // длина колонки.
            var rowLength = matrix.GetLength(1); // длина строки.

            var mainDiagonal = FindMainDiagonal(columnLength, rowLength, matrix); // главная диагональ.
            var sideDiagonal = FindSideDiagonal(columnLength, rowLength, matrix); // побочная диагональ.

            var determinant = mainDiagonal - sideDiagonal; // Вычисление определителя квадратной матрицы.

            if (columnLength == 1 && rowLength == 1)
            {
                determinant = mainDiagonal;
            }

            return determinant;
        }

        /// <summary>
        /// Метод нахождения минора квадратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num1"> Колонка. </param>
        /// <param name="num2"> Строка. </param>
        /// <returns> Минор квадратной матрицы. </returns>
        public int FindMinor(int[,] matrix, int num1, int num2)
        {
            var columnLength = matrix.GetLength(0); // длина колонки.
            var rowLength = matrix.GetLength(1); // длина строки.

            var newMatrix = GetChangedMinorMatrix(matrix, columnLength, rowLength, num1, num2); //Изменение матрицы.

            var minor = FindDeterminant(newMatrix); //Вычисление определителя квадратной матрицы.

            return minor;
        }

        /// <summary>
        /// Метод нахождения алгебраического доболнения.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num1"> Колонка. </param>
        /// <param name="num2"> Строка. </param>
        /// <returns> Алгебраическое доболнение квадратной матрицы. </returns>
        public int FindCofactor(int[,] matrix, int num1, int num2)
        {
            var cofactor = (int)Math.Pow(-1, num1 + num2) * FindMinor(matrix, num1, num2);

            return cofactor;
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
        /// <returns> Побочная диагональ. </returns>
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

        /// <summary>
        /// Метод изменения матрицы для Minor метода.
        /// </summary>
        /// <param name="columnLength"> Длина колонки матрицы. </param>
        /// <param name="rowLength"> Длина строки матрицы. </param>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="column"> Колонка. </param>
        /// <param name="row"> Строка. </param>
        /// <returns> Изменненая марица. </returns>
        private int[,] GetChangedMinorMatrix(int[,] matrix, int columnLength, int rowLength, int column, int row)
        {
            #region Проверка условий
            try
            {
                if (column > columnLength)
                {
                    throw new Exception("column не может быть больше чем columnLength");
                }
                if (row > rowLength)
                {
                    throw new Exception("row не может быть больше чем rowLength");
                }
                if (column < 0)
                {
                    throw new Exception("column не может быть меньше чем 0");
                }
                if (row < 0)
                {
                    throw new Exception("row не может быть меньше чем 0");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            var newMatrix = new int[rowLength - 1, columnLength - 1];

            var list = new List<int>(); //Вспомогательный список.
            var num = 0; //Вспомогательная переменная для заполнения массива.

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (i != column - 1 && j != row - 1)
                    {
                        list.Add(matrix[i, j]);
                    }
                }
            }

            for (int i = 0; i < columnLength - 1; i++)
            {
                for (int j = 0; j < rowLength - 1; j++)
                {
                    newMatrix[i, j] = list[num++];
                }
            }

            return newMatrix;
        }

    }
}
