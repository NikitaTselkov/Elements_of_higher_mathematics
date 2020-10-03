using Elements_of_higher_mathematics.ComplexNumbers;
using Elements_of_higher_mathematics.Matrixes;
using Elements_of_higher_mathematics.SystemOfEquations;
using System;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace Elements_of_higher_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            # region Matrix

            SquareMatrix squareMatrix = new SquareMatrix();
            Matrix matrix = new Matrix();
            MatrixEquationSystems matrixEquationSystems = new MatrixEquationSystems();
            AugmentedMatrix augmentedMatrix = new AugmentedMatrix();
            


            var matrixA = new Matrix(new double[3, 5] { { 2, -1, 3, -2, 4 }, { 4, -2, 5, 1, 7 }, { 2, -1, 1, 8, 2 } });

            var matrixB = new Matrix(new double[4, 4] { { 2, -5, 1, 2 }, { -3, 7, -1, 4 }, { 5, -9, 2, 7 }, { 4, -6, 1, 2 } });

            var matrixC = new Matrix(new double[3, 3] { { 2, 3, 2 }, { 1, 2, -3 }, { 3, 4, 1 } });

            var matrixD = new Matrix(new double[3, 4] { { 1, 2, 4, -5 }, { -4, 1, 3, 7 }, { -2, 5, 11, -3 } });

            var matrixE = new Matrix(new double[2, 2] { { 7, -4 }, { 8, -1 } });

            var matrixF = new Matrix(new double[4, 5] { { 11, -13, 61, 10, -11 }, { 2, -2, 11, 2, -2 }, { -3, 5, -17, -2, 3 }, { 4, 0, 24, 7, -8 } });


            var matrix_1_27 = new Matrix(new double[4, 4] { { 3, 1, 2, -3 }, { 8, 0, -4, -1 }, { 2, -2, 3, 4 }, { 2, 1, 1, 2 } });

            var matrix_2_27 = new Matrix(new double[3, 4] { { 1, 5, 4, 3 }, { 2, -1, 2, -1 }, { 5, 3, 8, 1 } });

            var matrix2_2_27 = new Matrix(new double[3, 1] { { 1 }, { 0 }, { 1 } });



            var matrixK = new Matrix(new double[4, 4] { { 1, -2, 3, -1 }, { 3, 3, -2, -5 }, { 1, -1, 2, 3 }, { 3, 2, 7, -2 } });
            var matrixK2 = new Matrix(new double[4, 1] { { 1 }, { 2 }, { 10 }, { 1 } });


            var AugmentedMatrix = new AugmentedMatrix(matrixK, matrixK2);

            // var y = AugmentedMatrix.MethodOfKramer(AugmentedMatrix);

            #endregion

            #region ComplexNumber

            //var z = new ComplexNumber("3y - 3xi - x + 2yi + 10i - 6");

            //var z2 = new ComplexNumber("3x + 2i - 3yi + 5");

            //var z3 = new ComplexNumber("(5 - 3i) / 2");

            //var z4 = new ComplexNumber(Math.Sqrt(3), -1);

            //var z5 = new ComplexNumber(5, "-15i");

            //var V27N1z1 = new ComplexNumber("x^2 + yi - 12");
            
            //var V27N1z2 = new ComplexNumber("-y - x^2i - 4i");

            // V27N1z1.MethodLeadingToStandardView();
            // V27N1z2.MethodLeadingToStandardView();

            // Console.WriteLine(V27N1z1);
            // Console.WriteLine(V27N1z2);

            // Console.WriteLine(z5.FindModule(true));


            // z.MethodLeadingToStandardView();
            //z2.MethodLeadingToStandardView();
            //z3.MethodLeadingToStandardView();

            //var t = z4 - z5;
            //var t2 = z4 + z5;
            //var t4 = z5.Pow(2, false);
            //var t5 = z4 / z5;
            // var t6 = z4.FindArg(true);

            //Console.WriteLine(t5);

            //Console.WriteLine();

            // Console.WriteLine(z);
            //Console.WriteLine(z2);
            //Console.WriteLine(z3);


            #endregion

            Equations z1 = new Equations("x^2 - 12", "-y");
            Equations z2 = new Equations("y", "x^2 + 4");

            СSystemOfEquations systemOfEquations = new СSystemOfEquations(z1, z2);


            foreach (var item in systemOfEquations.SystemOfEquations)
            {
                Console.WriteLine("{" + item.ToString());
            }

            Console.WriteLine();

            systemOfEquations.SystemOfEquations[1] = systemOfEquations.SystemOfEquations[1].MovingFromLeftToRight(1, 1);

            foreach (var item in systemOfEquations.SystemOfEquations)
            {              
                Console.WriteLine("{" + item.ToString());
            }

        }
    }
}
