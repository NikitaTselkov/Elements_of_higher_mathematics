using System;

namespace Elements_of_higher_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix matrix = new Matrix();

            var array = new int[3, 3] { { 7, 8, 6 }, { 2, 2, 2 }, { 9, 3, 3 } };

            var array2 = new int[2, 2] { { 7, 8 }, { 9, 3 } };

            var array3 = new int[4, 4] { { 7, 8, 6, 4 }, { 2, 2, 2, 4 }, { 9, 3, 3, 3 }, {5, -2, 1, 0 } };


            Console.WriteLine(matrix.FindDeterminant(array));

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
