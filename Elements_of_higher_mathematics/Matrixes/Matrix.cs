using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Elements_of_higher_mathematics.Matrixes
{
    public class Matrix
    {
        /// <summary>
        /// Значения матрицы.
        /// </summary>
        public double[,] MatrixValue { get; private set; }

        /// <summary>
        /// Общий множитель.
        /// </summary>
        public double CommonMultiplier { get; set; } = 1;

        /// <summary>
        /// Была ли матрица транспонированна.
        /// </summary>
        public bool IsMatrixTransposition { get; set; }

        /// <summary>
        /// Если это союзная матрица.
        /// </summary>
        public bool IsMatrixUnion { get; set; }

        /// <summary>
        /// Если это обратная матрица.
        /// </summary>
        public bool IsMatrixInverse { get; set; }

        public Matrix() { }

        public Matrix(double[,] matrixValue)
        {
            MatrixValue = matrixValue;
        }

        public Matrix(Matrix matrix)
        {
            MatrixValue = matrix.MatrixValue;
            CommonMultiplier = matrix.CommonMultiplier;
            IsMatrixTransposition = matrix.IsMatrixTransposition;
            IsMatrixUnion = matrix.IsMatrixUnion;
            IsMatrixInverse = matrix.IsMatrixInverse;
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

            Matrix newMatrix = new Matrix(new double[matrixAColumnLength, matrixBRowLength]); // новая матрица.

            if (matrixARowLength == matrixBColumnLength)
            {
                double sum;
                for (int i = 0; i < matrixAColumnLength; i++)
                {
                    for (int j = 0; j < matrixBRowLength; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < matrixARowLength; k++)
                        {                       
                            sum = Math.Round(sum + (matrixA.MatrixValue[i, k] * matrixB.MatrixValue[k, j]), 2);
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
        public static Matrix MatrixMultiplication(double number, Matrix matrix)
        {
            var matrixColumnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var matrixRowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            Matrix matrixResult = matrix; // результат перемножения.

            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    matrixResult.MatrixValue[i, j] = Math.Round(number * matrix.MatrixValue[i, j], 3);
                }
            }

            return matrixResult;
        }

        /// <summary>
        /// Метод транспонирующий матрицу.
        /// </summary>
        /// <returns> Измененая матрица. </returns>
        public Matrix MatrixTransposition()
        {
            Console.WriteLine();
            Console.WriteLine("Трансаонирование матрицы.");
            Console.WriteLine();

            var matrixColumnLength = MatrixValue.GetLength(0); // длина колонки матрицы.
            var matrixRowLength = MatrixValue.GetLength(1); // длина строки матрицы.

            Matrix matrixResult = new Matrix(new double[matrixColumnLength, matrixRowLength]); // результат транспонирования.

            matrixResult.IsMatrixTransposition = !IsMatrixTransposition;

            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    matrixResult.MatrixValue[i, j] = MatrixValue[j, i];
                }
            }

            matrixResult.IsMatrixInverse = IsMatrixInverse;
            matrixResult.IsMatrixUnion = IsMatrixUnion;
            matrixResult.CommonMultiplier = CommonMultiplier;


            Console.WriteLine();
            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    Console.Write($" {MatrixValue[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    Console.Write($" {matrixResult.MatrixValue[i, j]} ");
                }

                Console.WriteLine();
            }

            return matrixResult;
        }

        /// <summary>
        /// Метод меняющий элементы в матрицах местами.
        /// </summary>
        /// <param name="num1"> Первая строка или столбик. </param>
        /// <param name="num2"> Вторая строка или столбик. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Измененая матрица. </returns>
        public Matrix SwapColumnsOrRows(int num1, int num2, enumMatrix enumMatrix = enumMatrix.row)
        {
            var columnLength = MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]); // Новая матрица.

            if (enumMatrix == enumMatrix.row)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        if (i == num1 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = MatrixValue[num2 - 1, j];
                        }
                        else if (i == num2 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = MatrixValue[num1 - 1, j];
                        }
                        else
                        {
                            newMatrix.MatrixValue[i, j] = MatrixValue[i, j];
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
                            newMatrix.MatrixValue[i, j] = MatrixValue[i, num2 - 1];
                        }
                        else if (j == num2 - 1)
                        {
                            newMatrix.MatrixValue[i, j] = MatrixValue[i, num1 - 1];
                        }
                        else
                        {
                            newMatrix.MatrixValue[i, j] = MatrixValue[i, j];
                        }
                    }
                }
            }

            newMatrix = LoadMatrixData(this, newMatrix);

            newMatrix.CommonMultiplier = CommonMultiplier * -1;


            Console.WriteLine();

            Console.WriteLine($"Меняем {enumMatrix} {num1} и {num2} местами");

            Console.WriteLine();

            Console.WriteLine($"Множмтель: {newMatrix.CommonMultiplier}");

            Console.WriteLine();

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($" {MatrixValue[i, j]} ");
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

            MatrixValue = newMatrix.MatrixValue;
            CommonMultiplier = newMatrix.CommonMultiplier;

            return newMatrix;
        }

        /// <summary>
        /// Метод умножающий строку или колонку num1 на number и складывающий ее со строкой или колонкой num2.
        /// </summary>
        /// <param name="multiplier"> Множитель. </param>
        /// <param name="num1"> Первая строка или столбик. </param>
        /// <param name="num2"> Вторая строка или столбик. </param>
        /// <param name="enumMatrix"> Переключатель между строкой или столбиком. </param>
        /// <returns> Измененая матрица. </returns>
        public Matrix SixthPropertyOfTheDeterminant(double multiplier, int num1, int num2, enumMatrix enumMatrix = enumMatrix.row)
        {
            var columnLength = MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]); // Новая матрица.

            newMatrix = LoadMatrixData(this, newMatrix);

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
                                newMatrix.MatrixValue[i, j] = MatrixValue[num1 - 1, j] * multiplier + MatrixValue[num2 - 1, j];

                                Console.Write($"({MatrixValue[num1 - 1, j]} * {multiplier} + {MatrixValue[num2 - 1, j]})");
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = MatrixValue[i, j];

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
                                newMatrix.MatrixValue[i, j] = MatrixValue[i, num1 - 1] * multiplier + MatrixValue[i, num2 - 1];

                                Console.Write($"({MatrixValue[i, num1 - 1]} * {multiplier} + {MatrixValue[i, num2 - 1]})");
                            }
                            else
                            {
                                newMatrix.MatrixValue[i, j] = MatrixValue[i, j];

                                Console.Write($"{newMatrix.MatrixValue[i, j]} ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }

            
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

            MatrixValue = newMatrix.MatrixValue;

            return newMatrix;
        }

        /// <summary>
        /// Метод находящий и выносящий общий множитель из матрицы.
        /// </summary>
        /// <returns> Измененая матрица. </returns>
        public Matrix FindTheCommonMultiplier()
        {
            var columnLength = MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[columnLength, rowLength]);

            newMatrix = LoadMatrixData(this, newMatrix);

            newMatrix.MatrixValue = this.MatrixValue;

            for (int i = 0; i < columnLength; i++)
            {
                var commonMultiplier = 1.0;
                var isThereCommonMultiplier = true;
                for (int j = 0; j < rowLength; j++)
                {
                    if (MatrixValue[i, j] != 1)
                    {
                        if (rowLength != j + 1)
                        {
                            if (commonMultiplier == 1.0)
                            {
                                commonMultiplier = GCF(MatrixValue[i, j], MatrixValue[i, j + 1]);
                            }
                            else
                            {
                                if (commonMultiplier % GCF(MatrixValue[i, j], MatrixValue[i, j + 1]) != 0)
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

                    newMatrix = TakeOutTheTotalMultiplier(this, i + 1, commonMultiplier, enumMatrix.row);
                }
            }

            return newMatrix;
        }

        /// <summary>
        /// Метод находящий минор матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="order"> Порядок матрицы. </param>
        /// <param name="lastColumn"> Последняя колонка новой матрицы. </param>
        /// <param name="lastRow"> Последняя строчка новой матрицы. </param>
        /// <returns> Минор матрицы. </returns>
        public double FindMinorMatrix(Matrix matrix, int order, int lastColumn, int lastRow)
        {
            Console.WriteLine();
            Console.WriteLine("Минор матрицы.");
            Console.WriteLine();

            if (order > lastColumn || order > lastRow)
            {
                throw new ArgumentException();
            }

            var result = 0.0;

            var columnLength = matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[order, order]);

            var newColumnLength = newMatrix.MatrixValue.GetLength(0); // длина колонки новой матрицы.
            var newRowLength = newMatrix.MatrixValue.GetLength(1); // длина строки новой матрицы.

            var lastRowLength = lastRow;
            var isStartFillingNewMatrix = false;

            var squareMatrix = new SquareMatrix();

            newColumnLength = newMatrix.MatrixValue.GetLength(0) - 1;

            for (int i = columnLength; i > 0; i--)
            {
                newRowLength = newMatrix.MatrixValue.GetLength(1) - 1; // длина строки новой матрицы.

                var remainderRowFilling = order;

                for (int j = rowLength; j > 0; j--)
                {
                    if (lastColumn == i)
                    {
                        isStartFillingNewMatrix = true;
                    }
                    if (lastRowLength == j && remainderRowFilling != 0 && isStartFillingNewMatrix == true)
                    {
                        newMatrix.MatrixValue[newColumnLength, newRowLength] = matrix.MatrixValue[i - 1, j - 1];

                        remainderRowFilling -= 1;

                        newRowLength--;

                        lastRowLength--;
                    }
                }

                lastColumn--;
                newColumnLength--;
                lastRowLength = lastRow;
                isStartFillingNewMatrix = false;

                if (newColumnLength < 0)
                {
                    break;
                }
            }

            Console.WriteLine();

            newColumnLength = newMatrix.MatrixValue.GetLength(0); // длина колонки новой матрицы.
            newRowLength = newMatrix.MatrixValue.GetLength(1); // длина строки новой матрицы.

            for (int i = 0; i < newColumnLength; i++)
            {
                for (int j = 0; j < newRowLength; j++)
                {
                    Console.Write($" {newMatrix.MatrixValue[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            switch (order)
            {
                case 1:
                    result = newMatrix.MatrixValue[0, 0];
                    break;

                case 2:
                    result = squareMatrix.FindDeterminantOfTheSecondOrder(newMatrix); // Вычисление определителя матрицы 2-ого порядка.
                    break;

                case 3:
                    result = squareMatrix.FindDeterminantOfTheThirdOrder(newMatrix); // Вычисление определителя матрицы 3-ого порядка.
                    break;

                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Метод находящий ранг матрицы.
        /// </summary>
        /// <returns> Ранг матрицы. </returns>
        public int FindRank()
        {
            var columnLength = MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = MatrixValue.GetLength(1); // длина строки матрицы.

            var rank = 0;

            var newMatrix = this.MethodThatResetsTheColumnValues(0, 0);


            for (int i = 0; i < columnLength - 1 ; i++)
            {
                newMatrix = this.MethodThatResetsTheColumnValues(i, i);
            }

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (MatrixValue[i, j] != 0)
                    {
                        rank++;

                        break;
                    }
                }
            }

            return rank;
        }

        public Matrix LoadMatrixData(Matrix matrix, Matrix newMatrix)
        {
            newMatrix.CommonMultiplier = matrix.CommonMultiplier;
            newMatrix.IsMatrixTransposition = matrix.IsMatrixTransposition;
            newMatrix.IsMatrixUnion = matrix.IsMatrixUnion;
            newMatrix.IsMatrixInverse = matrix.IsMatrixInverse;

            return newMatrix;
        }

        /// <summary>
        /// Метод который обнуляет значения столбцов.
        /// </summary>
        /// <returns> Матрица. </returns>
        public Matrix MethodThatResetsTheColumnValues(int column, int row)
        {
            var columnLength = MatrixValue.GetLength(0); // длина колонки матрицы.
            var rowLength = MatrixValue.GetLength(1); // длина строки матрицы.

            var matrixResult = new Matrix(new double[columnLength, rowLength]);

            if (column == 0 && row == 0)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        if (MatrixValue[i, j] == 1)
                        {
                            if (i > 0)
                            {
                                matrixResult = SwapColumnsOrRows(row + 1, i + 1);
                            }
                            if (j > 0)
                            {
                                matrixResult = SwapColumnsOrRows(column + 1, j + 1, enumMatrix.column);
                            }

                            goto Break;
                        }
                    }
                }
            }

        Break:

            var isЕlementZero = false;

            if (MatrixValue[column, row] == 0)
            {
                column--;
                row--;
                isЕlementZero = true;
            }

            while (true)
            {
                if (MatrixValue[column, row] != 1)
                {
                    var result = 0.0;
                    var multiplier = 0.0;
                    var multiplier2 = 1.0;

                    if (MatrixValue[column, row] > 0)
                    {
                        if (MatrixValue[column + 1, row] > 0)
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
                        if (MatrixValue[column + 1, row] > 0)
                        {
                            multiplier2 *= 1;
                        }
                        else
                        {
                            multiplier2 *= -1;
                        }
                    }

                    var resultValue = 1.0;

                    if (column != 0 && row != 0)
                    {
                        resultValue = 0;
                    }

                    var iterator = 0;
                    do
                    {
                        iterator++;

                        result = MatrixValue[column, row] * multiplier + MatrixValue[column + 1, row];

                        if (result != resultValue)
                        {
                            multiplier += 0.1 * multiplier2;
                            multiplier = Math.Round(multiplier, 2);
                        }
                        if (iterator == 100)
                        {
                            matrixResult.MatrixValue = MatrixValue;
                            goto End;
                        }
                    }
                    while (result != resultValue);

                    if (multiplier == 0)
                    {
                        multiplier = multiplier2;
                    }

                    if (isЕlementZero == true)
                    {
                        matrixResult = SixthPropertyOfTheDeterminant(multiplier, row + 1, row + 3);
                    }
                    else
                    {
                        matrixResult = SixthPropertyOfTheDeterminant(multiplier, row + 1, row + 2);
                    }

                    if (column == 0 && row == 0)
                    {
                         matrixResult = SwapColumnsOrRows(row + 1, row + 2);
                    }

                    End:

                    MatrixValue = matrixResult.MatrixValue;
                }
                else
                {
                    for (int i = 1; i < columnLength; i++)
                    {
                        var multiplier = MatrixValue[i, row];

                        if (multiplier != 0)
                        {
                            matrixResult = SixthPropertyOfTheDeterminant(multiplier * -1, row + 1, i + 1);

                            MatrixValue = matrixResult.MatrixValue;
                        }
                    }

                    break;
                }

                if (column != 0 && row != 0)
                {
                    break;
                }

            }

            return matrixResult;
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

            Matrix matrixResult = new Matrix(new double[matrixAColumnLength, matrixBRowLength]); // результат сложения.

            if (matrixAColumnLength == matrixBColumnLength && matrixARowLength == matrixBRowLength)
            {
                for (int i = 0; i < matrixAColumnLength; i++)
                {
                    for (int j = 0; j < matrixBRowLength; j++)
                    {
                        if (additionOrSubtraction == enumAdditionAndSubtraction.Addition)
                        {
                            matrixResult.MatrixValue[i, j] = Math.Round(matrixA.MatrixValue[i, j] + matrixB.MatrixValue[i, j], 3);
                        }
                        else if (additionOrSubtraction == enumAdditionAndSubtraction.Subtraction)
                        {
                            matrixResult.MatrixValue[i, j] = Math.Round(matrixA.MatrixValue[i, j] - matrixB.MatrixValue[i, j], 3);
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

        public static Matrix operator *(double Number, Matrix matrixB)
        {
            return MatrixMultiplication(Number, matrixB);
        }

    }
}
