using System;
using System.Collections.Generic;
using System.Text;

namespace Elements_of_higher_mathematics.Matrixes
{
    public class MatrixEquationSystems
    {
        /// <summary>
        /// Метод решающий матричное Уравнение.
        /// </summary>
        /// <param name="matrixA"> Матрица которая дана. </param>
        /// <param name="matrixResult"> Результат умножения данной матрицы и неизвестной. </param>
        /// <returns> Неизвестная матрица. </returns>
        public Matrix CalculateMatrixEquation(Matrix matrixA, Matrix matrixResult)
        {
            SquareMatrix squareMatrix = new SquareMatrix();

            var result = squareMatrix.FindInverseMatrix(matrixA) * matrixResult;

            return result;
        }

        /// <summary>
        /// Иследование матрицы на совместность по теореме Кронекера-Капелли.
        /// </summary>
        /// <param name="augmentedMatrix"> Расширенная матрица. </param>
        /// <returns> Если матрица совместная. </returns>
        public enumNamesOfTheSystem StudyOfTheMatrixOnTheConsistency(AugmentedMatrix augmentedMatrix)
        {
            enumNamesOfTheSystem isTheSystemOfEquationsCompatible;

            var savedMatrix = SaveAugmentedMatrix(augmentedMatrix);

            var rankMatrix = augmentedMatrix.Matrix.FindRank();

            var rankAugmentedMatrix = augmentedMatrix.AugmentedMatrixValue.FindRank();

            if (rankMatrix == rankAugmentedMatrix)
            {            
                if (rankMatrix == augmentedMatrix.Matrix.MatrixValue.GetLength(0))
                {
                    isTheSystemOfEquationsCompatible = enumNamesOfTheSystem.UniqueSolution;
                }
                else
                {
                    isTheSystemOfEquationsCompatible = enumNamesOfTheSystem.WithoutANumericalSetOfSolutions;
                }
            }
            else
            {
                isTheSystemOfEquationsCompatible = enumNamesOfTheSystem.Inconsistent;
            }

            augmentedMatrix = savedMatrix;


            Console.WriteLine();

            Console.WriteLine($"Rank(A) = {rankMatrix}");

            Console.WriteLine();

            Console.WriteLine($"Rank(A|B) = {rankAugmentedMatrix}");

            Console.WriteLine();

            return isTheSystemOfEquationsCompatible;
        }

        /// <summary>
        /// Метод иследующий СЛАУ и решающий её.
        /// </summary>
        /// <param name="augmentedMatrix"> Расширенная матрица. </param>
        /// <returns> Матрица не известных значений. </returns>
        public Matrix SolvingSystemLinearEquationsByKramerMethod(AugmentedMatrix augmentedMatrix)
        {
            var columnLengthAugmentedValue = augmentedMatrix.AugmentedValue.GetLength(0); // длина колонки матрицы.
            var rowLengthAugmentedValue = augmentedMatrix.AugmentedValue.GetLength(1); // длина строки матрицы.

            var savedAugmentedMatrix = SaveAugmentedMatrix(augmentedMatrix);

            var matrixResult = new Matrix(new double[columnLengthAugmentedValue, rowLengthAugmentedValue]); // Матрица с результатом.

            switch (StudyOfTheMatrixOnTheConsistency(augmentedMatrix))
            {
                case enumNamesOfTheSystem.Inconsistent:

                    Console.WriteLine("Система не совместная");
                    break;

                case enumNamesOfTheSystem.UniqueSolution:

                    Console.WriteLine("Система имеет 1 решение");
                    matrixResult = savedAugmentedMatrix.MethodOfKramer(savedAugmentedMatrix);
                    break;

                case enumNamesOfTheSystem.WithoutANumericalSetOfSolutions:

                    Console.WriteLine("Система имеет безчисленное множество решений");
                    matrixResult = savedAugmentedMatrix.MethodOfKramer(savedAugmentedMatrix);
                    break;
            }

            return matrixResult;
        }

        /// <summary>
        /// Метод сохраняющий Расширенную матрицу.
        /// </summary>
        /// <param name="augmentedMatrix"> Расширенная матрица. </param>
        /// <returns> Расширенная матрица. </returns>
        public AugmentedMatrix SaveAugmentedMatrix(AugmentedMatrix augmentedMatrix)
        {
            var matrixColumnLength = augmentedMatrix.Matrix.MatrixValue.GetLength(0); // длина колонки матрицы.
            var matrixRowLength = augmentedMatrix.Matrix.MatrixValue.GetLength(1); // длина строки матрицы.

            var augmentedMatrixValueColumnLength = augmentedMatrix.AugmentedValue.GetLength(0); // длина колонки матрицы.
            var augmentedMatrixValueRowLength = augmentedMatrix.AugmentedValue.GetLength(1); // длина строки матрицы.

            var newMatrix = new Matrix(new double[matrixColumnLength, matrixRowLength]);

            var newAugmentedMatrixValue = new Matrix(new double[augmentedMatrixValueColumnLength, augmentedMatrixValueRowLength]);


            for (int i = 0; i < matrixColumnLength; i++)
            {
                for (int j = 0; j < matrixRowLength; j++)
                {
                    newMatrix.MatrixValue[i, j] = augmentedMatrix.Matrix.MatrixValue[i, j];
                }
            }

            for (int i = 0; i < augmentedMatrixValueColumnLength; i++)
            {
                for (int j = 0; j < augmentedMatrixValueRowLength; j++)
                {
                    newAugmentedMatrixValue.MatrixValue[i, j] = augmentedMatrix.AugmentedValue[i, j];
                }
            }

            var AugmentedMatrix = new AugmentedMatrix(newMatrix, newAugmentedMatrixValue);

            return AugmentedMatrix;
        }

    }
}
