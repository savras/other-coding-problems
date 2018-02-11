using System;

namespace q5
{
    class Program
    {
        // O(log n) solution.
        static int CallMultiplyWithSmallerAsFirstArgument(int a, int b)
        {
            var smaller = a > b ? b : a;
            var larger = a > b ? a : b;
            return Multiply(smaller, larger);
        }

        static int Multiply(int smaller, int larger)
        {
            if (smaller == 0) { return 0; }
            if (smaller == 1) { return larger; }

            var newSmaller = smaller >> 1;

            var result = Multiply(newSmaller, larger);
            if ((smaller & 1) > 0)
            {
                return (result << 1) + larger;
            }
            return result << 1;
        }

        static void Main(string[] args)
        {
            var a = -4;
            var b = 8;

            var result = CallMultiplyWithSmallerAsFirstArgument(a, b);
            
            Console.WriteLine(result);
        }
    }
}
