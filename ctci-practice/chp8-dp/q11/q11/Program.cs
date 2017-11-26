using System;
using System.Collections.Generic;

namespace q11
{
    class Program
    {
        static readonly List<int> Denominations = new List<int> { 25, 10, 5 };

        static int GetNumberOfWaysToRepresentNMemo(int n, Dictionary<int, int> cache)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n < 0)
            {
                return 0;

            }

            var result = 0;

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            foreach (var denom in Denominations)
            {
                result += GetNumberOfWaysToRepresentNMemo(n - denom, cache);
            }
            cache.Add(n, result);
            return cache[n];
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n % 5 != 0)
            {
                Console.WriteLine("Cannot fully represent n with the denominations");
            }
            else
            {
                var cache = new Dictionary<int, int>();
                var result = GetNumberOfWaysToRepresentNMemo(n, cache);
                Console.WriteLine(result);
            }

        }
    }
}
