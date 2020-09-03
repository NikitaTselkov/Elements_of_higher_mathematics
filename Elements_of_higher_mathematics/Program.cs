using System;

namespace Elements_of_higher_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix matrix = new Matrix();

            var array = new int[3, 3] { { 4, -5, 3 }, { 2, 0, -1 }, { -4, 7, 12 } };

            var array2 = new int[2, 2] { { 1, 2 }, { 4, 5 } };

            var array3 = new int[4, 4] { { 6, 8, 9, -12 }, { 4, 6, -6, -9 }, { -3, -4, 6, 8 }, {-2, -3, 4, 6 } };

            var array4 = new int[3, 3] { { 2, 3, 2 }, { 1, 2, -3 }, { 3, 4, 1 } };



            Console.WriteLine($" Определитель: {matrix.FindDeterminant(array)}");

            Console.WriteLine($" Минор: {matrix.FindMinor(array, 3, 2)}");

            Console.WriteLine($" Алгебраическое дополнение: {matrix.FindCofactor(array, 3, 2)}");

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
