using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Elements_of_higher_mathematics.Matrixes
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


            Console.WriteLine();
            Console.WriteLine("Определитель квадратной матрицы второго порядка");
            Console.WriteLine();


            var mainDiagonal = FindMainDiagonal(columnLength, rowLength, matrix); // главная диагональ.
            var sideDiagonal = FindSideDiagonal(columnLength, rowLength, matrix); // побочная диагональ.

            var determinantOfTheSecondOrder = mainDiagonal - sideDiagonal; // Вычисление определителя квадратной матрицы второго порядка.

            if (columnLength == 1 && rowLength == 1)
            {
                determinantOfTheSecondOrder = mainDiagonal;
            }

            Console.WriteLine();
            Console.WriteLine($"{mainDiagonal} - {sideDiagonal} = {determinantOfTheSecondOrder}");

            Console.WriteLine();


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


            Console.WriteLine();
            Console.WriteLine("Определитель квадратной матрицы третьего порядка");
            Console.WriteLine();
            Console.WriteLine($"({matrix[0, 0]} * {matrix[1, 1]} * {matrix[2, 2]}) + " +
                $"({matrix[0, 1]} * {matrix[1, 2]} * {matrix[2, 0]}) + ({matrix[0, 2]}" +
                $" * {matrix[1, 0]} * {matrix[2, 1]}) - ({matrix[0, 2]} * {matrix[1, 1]}" +
                $" * {matrix[2, 0]}) - ({matrix[0, 1]} * {matrix[1, 0]} * {matrix[2, 2]})" +
                $" - ({matrix[0, 0]} * {matrix[1, 2]} * {matrix[2, 1]}) = {mainDiagonal}" +
                $" + {firstPlusTriangle} + {secondPlusTriangle} - {sideDiagonal} " +
                $"- {firstMinusTriangle} - {secondMinusTriangle} = {determinantOfTheThirdOrder}");

            Console.WriteLine();

            return determinantOfTheThirdOrder;
        }

        /// <summary>
        /// Метод нахождения минора элемента квадратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num1"> Колонка. </param>
        /// <param name="num2"> Строка. </param>
        /// <returns> Минор элемента квадратной матрицы. </returns>
        public double FindMinorMatrixElement(Matrix matrix, int num1, int num2)
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
            Console.WriteLine();
            Console.WriteLine($"Алгебраическое дополнение {num1}, {num2}");
            Console.WriteLine();

            var minor = FindMinorMatrixElement(matrix, num1, num2);
            var cofactor = (int)Math.Pow(-1, num1 + num2) * minor;


            Console.WriteLine($"-1^{num1} + {num2} * {minor} = {cofactor}");
            Console.WriteLine();

            return cofactor;
        }

        /// <summary>
        /// Метод разложения матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num"> Строка или столбик. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Определитель. </returns>
        public double FindDecompositionOfMatrix(Matrix matrix, int num, enumMatrix enumMatrix = enumMatrix.row)
        {
            Console.WriteLine();

            Console.WriteLine($"Разложение матрицы по {enumMatrix} {num}");
            var array = new List<double>();


            var determinant = 0.0;
            var cofactor = 0.0;

            if (enumMatrix == enumMatrix.row)
            {
                var rowLength = matrix.MatrixValue.GetLength(1); // длина строки.

                for (int i = 0; i < rowLength; i++)
                {
                    cofactor = FindCofactor(matrix, num, i + 1);
                    determinant += matrix.MatrixValue[num - 1, i] * cofactor;

                    array.Add(cofactor);
                }

                Console.Write(matrix.CommonMultiplier);

                Console.WriteLine();

                for (int i = 0; i < rowLength; i++)
                {
                    if (i < rowLength - 1)
                    {
                        Console.Write($"{matrix.MatrixValue[num - 1, i]} * {array[i]} + ");
                    }
                    else
                    {
                        Console.Write($"{matrix.MatrixValue[i, num - 1]} * {array[i]} = {determinant * matrix.CommonMultiplier}");
                    }
                }
            }
            else if (enumMatrix == enumMatrix.column)
            {
                var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки.

                for (int i = 0; i < columnLength; i++)
                {
                    cofactor = FindCofactor(matrix, i + 1, num);
                    determinant += matrix.MatrixValue[i, num - 1] * cofactor;

                    array.Add(cofactor);
                }

                Console.Write(matrix.CommonMultiplier);

                Console.WriteLine();

                for (int i = 0; i < columnLength; i++)
                {
                    if (i < columnLength - 1)
                    {
                        Console.Write($"{matrix.MatrixValue[i, num - 1]} * {array[i]} + ");
                    }
                    else
                    {
                        Console.Write($"{matrix.MatrixValue[i, num - 1]} * {array[i]} = {determinant * matrix.CommonMultiplier}");
                    }
                }
            }

            return determinant * matrix.CommonMultiplier;
        }

        /// <summary>
        /// Метод нахождения союзной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Союзная матрица. </returns>
        public Matrix FindUnionMatrix(Matrix matrix)
        {
            Console.WriteLine();
            Console.WriteLine("Союзная матрица.");
            Console.WriteLine();

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

            unionMatrix = unionMatrix.LoadMatrixData(matrix, unionMatrix);

            unionMatrix = unionMatrix.MatrixTransposition(); // Транспонирование матрицы.

            unionMatrix.IsMatrixUnion = !matrix.IsMatrixUnion;

            Console.WriteLine();
            Console.WriteLine("Союзная матрица.");
            Console.WriteLine();
            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($" {unionMatrix.MatrixValue[i, j]} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            return unionMatrix;
        }

        /// <summary>
        ///  Метод нахождения обратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Обратная матрица. </returns>
        public Matrix FindInverseMatrix(Matrix matrix)
        {

            Console.WriteLine();
            Console.WriteLine("Обратная матрица.");
            Console.WriteLine();

            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var inverseMatrix = new Matrix(new double[columnLength, rowLength]); // Обратная матрица.

            var det = FindDecompositionOfMatrix(matrix, 1); // Определитель матрицы.

            if (det != 0)
            {
                var unionMatrix = FindUnionMatrix(matrix);


                Console.WriteLine();
                Console.WriteLine($"1 / {det} * {unionMatrix}");
                Console.WriteLine();

                Console.WriteLine();
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        Console.Write($" {unionMatrix.MatrixValue[i, j]} ");
                    }

                    Console.WriteLine();
                }
                Console.WriteLine();


                inverseMatrix = (1.0 / det) * unionMatrix;

                inverseMatrix = inverseMatrix.LoadMatrixData(matrix, inverseMatrix);

                inverseMatrix.IsMatrixUnion = false;

                inverseMatrix.IsMatrixInverse = !matrix.IsMatrixInverse;
            }
            else
            {
                Console.WriteLine("Обратной матрицы не существует");
            }

            Console.WriteLine();
            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($" {inverseMatrix.MatrixValue[i, j]} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            return inverseMatrix;
        }

        /// <summary>
        /// Метод находящий определитель матрицы путем элементарных преобразований.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель. </returns>
        public double FindDeterminant(Matrix matrix)
        {
            Console.WriteLine();
            Console.WriteLine("Нахождение определителя");
            Console.WriteLine();

            var savedMatrix = SaveMatrixValue(matrix);

            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.
            var determinant = 0.0;

            if (columnLength == rowLength)
            {
                if (columnLength == 2)
                {
                    determinant = FindDeterminantOfTheSecondOrder(matrix);

                    matrix = savedMatrix;

                    Console.WriteLine();
                    Console.WriteLine($"Определитель: {determinant}");

                    return determinant;
                }
                else if (columnLength == 3)
                {
                    determinant = FindDeterminantOfTheThirdOrder(matrix);

                    matrix = savedMatrix;

                    Console.WriteLine();
                    Console.WriteLine($"Определитель: {determinant}");

                    return determinant;
                }
                else
                {
                    matrix = matrix.MethodThatResetsTheColumnValues(0, 0);

                    determinant = FindDecompositionOfMatrix(matrix, 1, enumMatrix.column);

                    matrix = savedMatrix;

                    Console.WriteLine();
                    Console.WriteLine($"Определитель: {determinant}");
                }
            }

            return determinant;
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

            Console.WriteLine($"{matrix.MatrixValue[0, 0]} * {matrix.MatrixValue[1, 1]} = {result}");

            return result;
        }

        /// <summary>
        /// Метод сохраняющий значения нетрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Матрица. </returns>
        private Matrix SaveMatrixValue(Matrix matrix)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]);

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];
                }
            }

            return newMatrix;
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

            Console.WriteLine($"{matrix.MatrixValue[0, 1]} * {matrix.MatrixValue[1, 0]} = {result}");

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

            newMatrix = newMatrix.LoadMatrixData(matrix, newMatrix);


            Console.WriteLine();

            Console.WriteLine($"Минор элемента {column}, {row}");

            Console.WriteLine();
            Console.WriteLine($"Множмтель: {newMatrix.CommonMultiplier}");
            Console.WriteLine();

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                   Console.Write($" {matrix.MatrixValue[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Множмтель: {newMatrix.CommonMultiplier}");
            Console.WriteLine();

            for (int i = 0; i < columnLength - 1; i++)
            {
                for (int j = 0; j < rowLength - 1; j++)
                {
                  Console.Write($" {newMatrix.MatrixValue[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            return newMatrix;
        }
    }
}
