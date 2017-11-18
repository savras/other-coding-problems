using System;
using System.Collections.Generic;

namespace Q2MakeChange
{
    class Program
    {
        private static readonly List<int> Denominations = new List<int> { 10, 6, 1 };

        // Memoization
        public static int MakeChangeTopDown(int n, int[] cache)
        {
            if (cache[n] >= 0)
            {
                return cache[n];
            }

            cache[n] = int.MaxValue;
            foreach (var denom in Denominations)
            {
                if (n >= denom)
                {
                    cache[n] = Math.Min(cache[n], 1 + MakeChangeTopDown(n - denom, cache));
                }
            }

            return cache[n];
        }

        public static int MakeChangeBottomUp(int n, int[] cache)
        {
            var size = n + 1;
            for (var i = 1; i < size; i++)
            {
                if (i%6 == 0)
                {
                    cache[i] = cache[i - 6] + 1;
                }
                else if (i%10 == 0)
                {
                    cache[i] = cache[i - 10] + 1;
                }
                else
                {
                    cache[i] = cache[i - 1] + 1;

                }
            }
            return cache[n];
        }

        static void Main(string[] args)
        {
            var n = 7;
            var cache = new int[n+1];

            // So that cache[0] is 0, the rest are -1, and cache[0] is used as termination condition for recursion.
            for (var i = 1; i < n + 1; i++)  
            {
                cache[i] = -1;
            }

            //var result = MakeChangeTopDown(n, cache);
            var result = MakeChangeBottomUp(n, cache);
            Console.WriteLine(result);
        }
    }
}
