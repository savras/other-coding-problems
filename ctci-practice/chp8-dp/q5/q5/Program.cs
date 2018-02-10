using System;

namespace q5
{
    class Program
    {
        // Primitive method
        // Doesn't handle negative numbers.
        static int Primitive(int val, int count)
        {
            if (count == 0)
            {
                return 0;
            }
            
            return CallMultiplyWithSmallerAsFirstArgument(val, count - 1) + val;
        }

        // More optimal method
        static int CallMultiplyWithSmallerAsFirstArgument(int a, int b)
        {
            var smaller = a;
            var larger = b;
            if (a > b)
            {
                smaller = b;
                larger = a;
            }
            return Multiply(smaller, larger);
        }

        static int Multiply(int smaller, int larger)
        {
            if (smaller == 0) { return 0; }
            if (smaller == 1) { return larger; }

            var newSmaller = smaller >> 1;  // Half the value
            return Multiply(newSmaller, larger) << 1;
        }

        static void Main(string[] args)
        {
            var a = 4;
            var b = 8;

            var result = Multiply(a, b);
            
            Console.WriteLine(result);
        }
    }
}
