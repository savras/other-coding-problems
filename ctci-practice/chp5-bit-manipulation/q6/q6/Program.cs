using System;

namespace q6
{
    class Program
    {
        static int GetNumberOfOnesToFlip(int value1, int value2)
        {
            var xor = value1 ^ value2;

            var result = 0;
            while (xor > 0)
            {
                if ((xor & 1) == 1)
                {
                    result++;
                }
                xor = xor >> 1;
            }

            return result;
        }

        static void Main(string[] args)
        {
            var value1 = 23423;
            var value2 = 7654;
            var result = GetNumberOfOnesToFlip(value1, value2);
            Console.WriteLine(result);
        }
    }
}
