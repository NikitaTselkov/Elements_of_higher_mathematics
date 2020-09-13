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

    }
}
