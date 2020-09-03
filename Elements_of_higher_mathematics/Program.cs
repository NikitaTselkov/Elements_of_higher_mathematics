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

            var array3 = new int[4, 4] { { 6, 8, 9, -12 }, { 4, 6, -6, -9 }, { -3, -4, 6, 8 }, {-2, -3, 4, 6 } };

            var array4 = new int[3, 3] { { 2, 3, 2 }, { 1, 2, -3 }, { 3, 4, 1 } };



            // Console.WriteLine($" Определитель второго порядка: {matrix.FindDeterminantOfTheSecondOrder(array)}");

            // Console.WriteLine($" Минор: {matrix.FindMinor(array, 3, 2)}");

            // Console.WriteLine($" Алгебраическое дополнение: {matrix.FindCofactor(array, 3, 2)}");

            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array4, 3)}");

            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 1, enumMatrix.column)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 2, enumMatrix.column)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 3, enumMatrix.column)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 4, enumMatrix.column)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 1, enumMatrix.row)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 2, enumMatrix.row)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 3, enumMatrix.row)}");
            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array3, 4, enumMatrix.row)}");

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
