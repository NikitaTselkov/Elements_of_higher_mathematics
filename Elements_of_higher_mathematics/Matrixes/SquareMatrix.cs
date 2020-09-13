using System;
using System.Collections.Generic;

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
            Console.WriteLine();
            Console.WriteLine($"Алгебраическое дополнение {num1}, {num2}");
            Console.WriteLine();

            var minor = FindMinor(matrix, num1, num2);
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

            unionMatrix = LoadMatrixData(matrix, unionMatrix);

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

                inverseMatrix = LoadMatrixData(matrix, inverseMatrix);

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

            Console.WriteLine($"Меняем {enumMatrix} {num1} и {num2} местами");

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

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($" {newMatrix.MatrixValue[i, j]} ");
                }

                Console.WriteLine();
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

            newMatrix.CommonMultiplier = matrix.CommonMultiplier;
            newMatrix.IsMatrixInverse = matrix.IsMatrixInverse;
            newMatrix.IsMatrixTransposition = matrix.IsMatrixTransposition;
            newMatrix.IsMatrixUnion = matrix.IsMatrixUnion;

            Console.WriteLine();
            Console.WriteLine("Шестое свойство определителя");
            Console.WriteLine();
            Console.WriteLine($"Множмтель: {newMatrix.CommonMultiplier}");
            Console.WriteLine();
            Console.WriteLine($"Множитель шестого правила: {multiplier}");
            Console.WriteLine();

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

                                Console.Write($"({matrix.MatrixValue[num1 - 1, j]} * {multiplier} + {matrix.MatrixValue[num2 - 1, j]})");
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];

                                Console.Write($"{newMatrix.MatrixValue[i, j]} ");
                            }
                        }
                        Console.WriteLine();
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

                                Console.Write($"({matrix.MatrixValue[i, num1 - 1]} * {multiplier} + {matrix.MatrixValue[i, num2 - 1]})");
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = matrix.MatrixValue[i, j];

                                Console.Write($"{newMatrix.MatrixValue[i, j]} ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }

            newMatrix = LoadMatrixData(matrix, newMatrix);

            Console.WriteLine();
            Console.WriteLine($"Множмтель: {newMatrix.CommonMultiplier}");
            Console.WriteLine();
            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($"{newMatrix.MatrixValue[i, j]} ");
                }
                Console.WriteLine();
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

           // matrix = FindTheCommonMultiplier(matrix);

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


            Console.WriteLine($"Общий множитель");

            Console.WriteLine();

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($" {matrix.MatrixValue[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.Write($"Множитель: {newMatrix.CommonMultiplier}");

            Console.WriteLine();

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($" {newMatrix.MatrixValue[i, j]}");
                }
                Console.WriteLine();
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

            Console.WriteLine($"{matrix.MatrixValue[0, 0]} * {matrix.MatrixValue[1, 1]} = {result}");

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

            newMatrix = LoadMatrixData(matrix, newMatrix);


            Console.WriteLine();

            Console.WriteLine($"Минор {column}, {row}");

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
