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
        /// Метод разложения матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num"> Строка или столбик. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Определитель. </returns>
        public double FindDecompositionOfMatrix(Matrix matrix, int num, enumMatrix enumMatrix = enumMatrix.row)
        {
            var determinant = 0.0;

            if (enumMatrix == enumMatrix.row)
            {
                var rowLength = matrix.MatrixValue.GetLength(1); // длина строки.

                for (int i = 0; i < rowLength; i++)
                {
                    determinant += matrix.MatrixValue[num - 1, i] * FindCofactor(matrix, num, i + 1);

                    Console.Write($"{matrix.MatrixValue[num - 1, i]} * {FindCofactor(matrix, num, i + 1)} +");
                }
            }
            else if (enumMatrix == enumMatrix.column)
            {
                var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки.

                for (int i = 0; i < columnLength; i++)
                {
                    determinant += matrix.MatrixValue[i, num - 1] * FindCofactor(matrix, i + 1, num);

                    Console.Write($"{matrix.MatrixValue[i, num - 1]} * {FindCofactor(matrix, i + 1, num)} +");
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

            unionMatrix = LoadMatrixData(matrix, unionMatrix);

            unionMatrix = unionMatrix.MatrixTransposition(); // Транспонирование матрицы.

            unionMatrix.IsMatrixUnion = !matrix.IsMatrixUnion;

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

            var det = FindDecompositionOfMatrix(matrix, 1); // Определитель матрицы.

            if (det != 0)
            {
                inverseMatrix = (1.0 / det) * FindUnionMatrix(matrix);

                inverseMatrix = LoadMatrixData(matrix, inverseMatrix);

                inverseMatrix.IsMatrixUnion = false;

                inverseMatrix.IsMatrixInverse = !matrix.IsMatrixInverse;
            }
            else
            {
                Console.WriteLine("Обратной матрицы не существует");
            }

            return inverseMatrix;
        }

        /// <summary>
        /// Метод меняющий элементы в матрицах местами.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num1"> Первая строка или столбик. </param>
        /// <param name="num2"> Вторая строка или столбик. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Измененая матрица. </returns>
        public Matrix SwapColumnsOrRows(Matrix matrix, int num1, int num2, enumMatrix enumMatrix = enumMatrix.row)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]); // Новая матрица.

            if (enumMatrix == enumMatrix.row)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        if (i == num1 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[num2 - 1, j];
                        }
                        else if (i == num2 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[num1 -1 , j];
                        }
                        else
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];
                        }
                    }
                }
            }
            else if (enumMatrix == enumMatrix.column)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        if (j == num1 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, num2 - 1];
                        }
                        else if (j == num2 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, num1 - 1];
                        }
                        else
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];
                        }
                    }
                }
            }

            newMatrix = LoadMatrixData(matrix, newMatrix);

            newMatrix.CommonMultiplier = matrix.CommonMultiplier * -1;


            Console.WriteLine();

            Console.WriteLine("Меняем колонки местами");

            Console.WriteLine($"Множитель: {newMatrix.CommonMultiplier}");

            Console.WriteLine();

            foreach (var item in newMatrix.MatrixValue)
            {
                Console.Write(item);
            }

            Console.WriteLine();


            return newMatrix;
        }

        /// <summary>
        /// Метод умножающий строку или колонку num1 на number и складывающий ее со строкой или колонкой num2.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="multiplier"> Множитель. </param>
        /// <param name="num1"> Первая строка или столбик. </param>
        /// <param name="num2"> Вторая строка или столбик. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Измененая матрица. </returns>
        public Matrix SixthPropertyOfTheDeterminant(Matrix matrix, double multiplier, int num1, int num2, enumMatrix enumMatrix = enumMatrix.row)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]); // Новая матрица.

            if (num1 != num2)
            {
                if (enumMatrix == enumMatrix.row)
                {
                    for (int i = 0; i < columnLength; i++)
                    {
                        for (int j = 0; j < rowLength; j++)
                        {
                            if (num2 - 1 == i)
                            {
                                newMatrix.MatrixValue[i, j] = matrix.MatrixValue[num1 - 1, j] * multiplier + matrix.MatrixValue[num2 - 1, j];

                                Console.WriteLine($"{matrix.MatrixValue[num1 - 1, j]} * {multiplier} + {matrix.MatrixValue[num2 - 1, j]}");
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];

                                Console.WriteLine(matrix.MatrixValue[i, j]);
                            }
                        }
                    }
                }
                else if (enumMatrix == enumMatrix.column)
                {
                    for (int i = 0; i < columnLength; i++)
                    {
                        for (int j = 0; j < rowLength; j++)
                        {
                            if (num2 - 1 == j)
                            {
                                newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, num1 - 1] * multiplier + matrix.MatrixValue[i, num2 - 1];
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];
                            }
                        }
                    }
                }
            }

            newMatrix = LoadMatrixData(matrix, newMatrix);


            Console.WriteLine("Шестое свойство определителя");

            Console.WriteLine();

            Console.WriteLine($"Множитель: {newMatrix.CommonMultiplier}");

            Console.WriteLine();

            foreach (var item in newMatrix.MatrixValue)
            {
                Console.Write(item);
            }

            Console.WriteLine();


            return newMatrix;
        }     

        /// <summary>
        /// Метод находящий и выносящий общий множитель из матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Измененая матрица. </returns>
        public Matrix FindTheCommonMultiplier(Matrix matrix)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]);

            newMatrix = new Matrix(matrix);


            for (int i = 0; i < columnLength; i++)
            {
                var commonMultiplier = 1.0;
                var isThereCommonMultiplier = true;
                for (int j = 0; j < rowLength; j++)
                {
                    if (matrix.MatrixValue[i, j] != 1)
                    {
                        if (rowLength != j + 1)
                        {
                            if (commonMultiplier == 1.0)
                            {
                                commonMultiplier = GCF(matrix.MatrixValue[i, j], matrix.MatrixValue[i, j + 1]);
                            }
                            else
                            {
                                if (commonMultiplier % GCF(matrix.MatrixValue[i, j], matrix.MatrixValue[i, j + 1]) != 0)
                                {
                                    isThereCommonMultiplier = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        commonMultiplier = 1.0;
                        isThereCommonMultiplier = false;
                    }
                }
                if (isThereCommonMultiplier == true && commonMultiplier != -1)
                {
                    if (commonMultiplier < 0)
                    {
                        commonMultiplier *= -1;
                    }

                    newMatrix = TakeOutTheTotalMultiplier(matrix, i + 1, commonMultiplier, enumMatrix.row);
                }
            }

            return newMatrix;
        }

        /// <summary>
        /// Метод находящий определитель матрицы путем элементарных преобразований.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель. </returns>
        public double FindDeterminant(Matrix matrix)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.
            var determinant = 0.0;

            matrix = FindTheCommonMultiplier(matrix);

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (matrix.MatrixValue[i, j] == 1) 
                    {
                        if (i > 0)
                        {
                            matrix = SwapColumnsOrRows(matrix, 1, i + 1);
                        }
                        if (j > 0)
                        {
                            matrix = SwapColumnsOrRows(matrix, 1, j + 1, enumMatrix.column);
                        }

                        goto Break;
                    }
                }
            }

            Break:

            while (true)
            {
                if (matrix.MatrixValue[0, 0] != 1)
                {
                    var result = 0.0;
                    var multiplier = 1.0;
                    var multiplier2 = 1.0;

                    if (matrix.MatrixValue[0, 0] > 0)
                    {
                        if (matrix.MatrixValue[1, 0] > 0)
                        {
                            multiplier2 *= -1;
                        }
                        else
                        {
                            multiplier2 *= 1;
                        }
                    }
                    else
                    {
                        if (matrix.MatrixValue[1, 0] > 0)
                        {
                            multiplier2 *= 1;
                        }
                        else
                        {
                            multiplier2 *= -1;
                        }
                    }

                    while (result != 1.0)
                    {
                        result = matrix.MatrixValue[0, 0] * multiplier + matrix.MatrixValue[1, 0];

                        if (result != 1.0)
                        {
                            multiplier += 0.1 * multiplier2;
                            multiplier = Math.Round(multiplier, 2);
                        }
                    }

                    matrix = SixthPropertyOfTheDeterminant(matrix, multiplier, 1, 2);

                    matrix = SwapColumnsOrRows(matrix, 1, 2);
                }
                else
                {
                    for (int i = 1; i < columnLength; i++)
                    {
                        var multiplier = matrix.MatrixValue[i, 0];

                        if (multiplier != 0)
                        {
                            matrix = SixthPropertyOfTheDeterminant(matrix, multiplier * -1, 1, i + 1);
                        }
                    }

                    break;
                }
            }

            determinant = FindDecompositionOfMatrix(matrix, 1, enumMatrix.column);

            return determinant;
        }


        /// <summary>
        /// Метод выносящий общий множитель из матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="num"> Строка или колонка. </param>
        /// <param name="commonMultiplier"> Общий множитель. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Измененая матрица. </returns>
        private Matrix TakeOutTheTotalMultiplier(Matrix matrix, int num, double commonMultiplier, enumMatrix enumMatrix = enumMatrix.row)
        {
            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]); // Новая матрица.

            if (enumMatrix == enumMatrix.row)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        if (num - 1 == i)
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[num - 1, j] / commonMultiplier;
                        }
                        else
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];
                        }
                    }
                }
            }
            else if (enumMatrix == enumMatrix.column)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        if (num - 1 == j)
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, num - 1] / commonMultiplier;
                        }
                        else
                        {
                            newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];
                        }
                    }
                }
            }

            newMatrix = LoadMatrixData(matrix, newMatrix);

            newMatrix.CommonMultiplier = commonMultiplier * matrix.CommonMultiplier;


            Console.WriteLine($"Общий множитель: {newMatrix.CommonMultiplier}");

            Console.WriteLine();

            Console.WriteLine($"Множитель: {newMatrix.CommonMultiplier}");

            Console.WriteLine();

            foreach (var item in newMatrix.MatrixValue)
            {
                Console.Write(item);
            }

            Console.WriteLine();


            return newMatrix;
        }

        /// <summary>
        /// Метод нахождения НОД.
        /// </summary>
        /// <param name="a"> Первое число. </param>
        /// <param name="b"> Второе число. </param>
        /// <returns> НОД. </returns>
        private double GCF(double a, double b)
        {
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
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

            newMatrix = LoadMatrixData(matrix, newMatrix);

            return newMatrix;
        }

        private Matrix LoadMatrixData(Matrix matrix, Matrix newMatrix)
        {
            newMatrix.CommonMultiplier = matrix.CommonMultiplier;
            newMatrix.IsMatrixTransposition = matrix.IsMatrixTransposition;
            newMatrix.IsMatrixUnion = matrix.IsMatrixUnion;
            newMatrix.IsMatrixInverse = matrix.IsMatrixInverse;

            return newMatrix;
        }

    }
}
