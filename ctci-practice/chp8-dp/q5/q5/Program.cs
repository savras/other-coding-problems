using System;

namespace q5
{
    class Program
    {
        static int Multiply(int val, int count)
        {
            if (count == 0)
            {
                return 0;
            }
            return Multiply(val, count - 1) + val;
        }

        static void Main(string[] args)
        {
            var result = Multiply(4, 3);
            Console.WriteLine(result);
        }
    }
}
