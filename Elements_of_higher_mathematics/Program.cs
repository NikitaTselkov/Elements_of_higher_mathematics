using System;

namespace Elements_of_higher_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix matrix = new Matrix();

            var array = new int[3, 3] { { 7, -4, 2 }, { -2, 3, 0 }, { 5, -1, -8 } };

            var array2 = new int[2, 2] { { 1, 2 }, { 4, 5 } };

            var array3 = new int[4, 4] { { -1, 3, 2, -3 }, { 4, -2, 5, 1 }, { -5, 0, 4, 0 }, {9, 7, 8, -7 } };

            var test = new int[4, 4] { { 2, 4, 1, 1 }, { 0, 2, 0, 0 }, { 2, 1, 1, 3 }, {4, 0, 2, 3 } };

            var array4 = new int[3, 3] { { 5, 7, 1 }, { -4, 1, 0 }, { 2, 0, 3 } };



            Console.WriteLine($" Определитель второго порядка: {matrix.FindDeterminantOfTheSecondOrder(array)}");

            Console.WriteLine($" Минор: {matrix.FindMinor(array4, 1, 2)}");

           Console.WriteLine($" Алгебраическое дополнение: {matrix.FindCofactor(array4, 2, 1)}");

           Console.WriteLine($" Определитель: {matrix.FindDeterminant(array, 1, enumMatrix.column)}");


        }

        private static int InputNum()
        {
            int num;

            do
            {
                Console.WriteLine("Введите число");

                var input = Console.ReadLine();

                if (int.TryParse(input, out num))
                {
                    break;
                }

            } while (true);

            return num;
        }
    }
}
