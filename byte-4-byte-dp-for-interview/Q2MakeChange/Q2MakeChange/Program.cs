using System;
using System.Collections.Generic;

namespace Q2MakeChange
{
    class Program
    {
        private static readonly List<int> Denominations = new List<int> { 10, 6, 1 };
        public static int MakeChange(int n, int[] cache)
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
                    cache[n] = Math.Min(cache[n], 1 + MakeChange(n - denom, cache));
                }
            }

            return cache[n];
        }

        static void Main(string[] args)
        {
            var n = 10;
            var cache = new int[n+1];

            // So that cache[0] is 0, the rest are -1, and cache[0] is used as termination condition for recursion.
            for (var i = 1; i < n + 1; i++)  
            {
                cache[i] = -1;
            }

            var result = MakeChange(n, cache);
            Console.WriteLine(result);
        }
    }
}
