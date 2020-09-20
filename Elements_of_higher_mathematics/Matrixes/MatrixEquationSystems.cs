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
        /// Иследование матрицы по теореме Кронекера-Капелли на совместность.
        /// </summary>
        /// <param name="augmentedMatrix"> Расширенная матрица. </param>
        /// <returns> Если матрица совместная. </returns>
        public bool IsTheSystemOfEquationsCompatible(AugmentedMatrix augmentedMatrix)
        {
            var isTheSystemOfEquationsCompatible = false;

            var rankMatrix = augmentedMatrix.Matrix.FindRank();

            var rankAugmentedMatrix = augmentedMatrix.AugmentedMatrixValue.FindRank();

            if (rankMatrix == rankAugmentedMatrix)
            {
                isTheSystemOfEquationsCompatible = true;
            }


            Console.WriteLine();

            Console.WriteLine($"Rank(A) = {rankMatrix}");

            Console.WriteLine();

            Console.WriteLine($"Rank(A|B) = {rankAugmentedMatrix}");

            Console.WriteLine();

            return isTheSystemOfEquationsCompatible;
        }

    }
}
