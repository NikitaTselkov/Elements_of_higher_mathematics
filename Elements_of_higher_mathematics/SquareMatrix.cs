using System;
using System.Collections.Generic;

namespace Elements_of_higher_mathematics
{
    class SquareMatrix
    {
        /// <summary>
        /// Метод нахождения определителя квадратной матрицы второго порядка.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель квадратной матрицы второго порядка. </returns>
        public double FindDeterminantOfTheSecondOrder(Matrix matrix)
        {          
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки.

            var mainDiagonal = FindMainDiagonal(columnLength, rowLength, matrix); // главная диагональ.
            var sideDiagonal = FindSideDiagonal(columnLength, rowLength, matrix); // побочная диагональ.

            var determinantOfTheSecondOrder = mainDiagonal - sideDiagonal; // Вычисление определителя квадратной матрицы второго порядка.

            if (columnLength == 1 && rowLength == 1)
            {
                determinantOfTheSecondOrder = mainDiagonal;
            }

            return determinantOfTheSecondOrder;
        }

        /// <summary>
        ///  Метод нахождения определителя квадратной матрицы третьего порядка.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель квадратной матрицы третьего порядка. </returns>
        public double FindDeterminantOfTheThirdOrder(Matrix _matrix)
        {
            #region Kоординаты вершин треугольников

            var matrix = _matrix.MatrixValue;

            var mainDiagonal = matrix[0, 0] * matrix[1, 1] * matrix[2, 2];

            var firstPlusTriangle = matrix[0, 1] * matrix[1, 2] * matrix[2, 0];

            var secondPlusTriangle = matrix[0, 2] * matrix[1, 0] * matrix[2, 1];

            var sideDiagonal = matrix[0, 2] * matrix[1, 1] * matrix[2, 0];

            var firstMinusTriangle = matrix[0, 1] * matrix[1, 0] * matrix[2, 2];

            var secondMinusTriangle = matrix[0, 0] * matrix[1, 2] * matrix[2, 1];

            var determinantOfTheThirdOrder = mainDiagonal + firstPlusTriangle + secondPlusTriangle - sideDiagonal - firstMinusTriangle - secondMinusTriangle;

            #endregion

            return determinantOfTheThirdOrder;
        }

        /// <summary>
        /// Метод нахождения минора квадратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num1"> Колонка. </param>
        /// <param name="num2"> Строка. </param>
        /// <returns> Минор квадратной матрицы. </returns>
        public double FindMinor(Matrix matrix, int num1, int num2)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки.

            var newMatrix = GetChangedMinorMatrix(matrix, columnLength, rowLength, num1, num2); // Изменение матрицы.

            double minor;

            if (rowLength == 4 && columnLength == 4)
            {
                minor = FindDeterminantOfTheThirdOrder(newMatrix); // Вычисление определителя матрицы 3-ого порядка.
            }
            else
            {
                minor = FindDeterminantOfTheSecondOrder(newMatrix); // Вычисление определителя матрицы 2-ого порядка.
            }

            return minor;
        }

        /// <summary>
        /// Метод нахождения алгебраического доболнения.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num1"> Колонка. </param>
        /// <param name="num2"> Строка. </param>
        /// <returns> Алгебраическое дополнение квадратной матрицы. </returns>
        public double FindCofactor(Matrix matrix, int num1, int num2)
        {
            var cofactor = (int)Math.Pow(-1, num1 + num2) * FindMinor(matrix, num1, num2);

            Console.WriteLine($"cofactor: {cofactor}");

            return cofactor;
        }

        /// <summary>
        /// Метод нахождения определителя.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num"> Строка или столбик. </param>
        /// <param name="enumMatrix"> переключатель между строкой или столбиком. </param>
        /// <returns> Определитель. </returns>
        public double FindDeterminant(Matrix matrix, int num, enumMatrix enumMatrix = enumMatrix.row)
        {
            var determinant = 0.0;

            if (enumMatrix == enumMatrix.row)
            {
                var rowLength = matrix.MatrixValue.GetLength(1); // длина строки.

                for (int i = 0; i < rowLength; i++)
                {
                    determinant += matrix.MatrixValue[num - 1, i] * FindCofactor(matrix, num, i + 1);
                }
            }
            else if (enumMatrix == enumMatrix.column)
            {
                var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки.

                for (int i = 0; i < columnLength; i++)
                {
                    determinant += matrix.MatrixValue[i, num - 1] * FindCofactor(matrix, i + 1, num);
                }
            }

            return determinant;
        }

        /// <summary>
        /// Метод нахождения союзной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Союзная матрица. </returns>
        public Matrix FindUnionMatrix(Matrix matrix)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var unionMatrix = new Matrix(new double[columnLength, rowLength]); // Союзная матрица.

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    unionMatrix.MatrixValue[i, j] = FindCofactor(matrix, i + 1, j + 1);
                }
            }

            unionMatrix = unionMatrix.MatrixTransposition(); // Транспонирование матрицы.

            unionMatrix.IsMatrixUnion = !unionMatrix.IsMatrixUnion;

            return unionMatrix;
        }

        /// <summary>
        ///  Метод нахождения обратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Обратная матрица. </returns>
        public Matrix FindInverseMatrix(Matrix matrix)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var inverseMatrix = new Matrix(new double[columnLength, rowLength]); // Обратная матрица.

            var det = FindDeterminant(matrix, 1);

            if (det != 0)
            {
                inverseMatrix = (1.0 / det) * FindUnionMatrix(matrix);

                inverseMatrix.IsMatrixInverse = !inverseMatrix.IsMatrixInverse;
            }
            else
            {
                Console.WriteLine("Обратной матрицы не существует");
            }

            return inverseMatrix;
        }


        /// <summary>
        /// Получает главную диагональ.
        /// </summary>
        /// <param name="columnLength"> Длина колонки матрицы. </param>
        /// <param name="rowLength"> Длина строки матрицы. </param>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Главная диагональ. </returns>
        private double FindMainDiagonal(int columnLength, int rowLength, Matrix matrix)
        {
            double result = 1;

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (i == j)
                    {
                        result *= matrix.MatrixValue[i, j];
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
        private double FindSideDiagonal(int columnLength, int rowLength, Matrix matrix)
        {
            var result = 1.0;
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
                            result *= matrix.MatrixValue[i, j];
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
        private Matrix GetChangedMinorMatrix(Matrix matrix, int columnLength, int rowLength, int column, int row)
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

            var newMatrix = new Matrix(new double[rowLength - 1, columnLength - 1]);

            var list = new List<double>(); //Вспомогательный список.
            var num = 0; //Вспомогательная переменная для заполнения массива.

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (i != column - 1 && j != row - 1)
                    {
                        list.Add(matrix.MatrixValue[i, j]);
                    }
                }
            }

            for (int i = 0; i < columnLength - 1; i++)
            {
                for (int j = 0; j < rowLength - 1; j++)
                {
                    newMatrix.MatrixValue[i, j] = list[num++];
                }
            }

            return newMatrix;
        }

    }
}
