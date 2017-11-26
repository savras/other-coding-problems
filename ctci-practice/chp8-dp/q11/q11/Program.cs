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
                //var result = GetNumberOfWaysToRepresentNMemo(n, cache);
                var result = GetNumberOfWaysToRepresentNDp(n);
                Console.WriteLine(result);
            }

        }

        private static int GetNumberOfWaysToRepresentNDp(int n)
        {
            var cache = new Dictionary<int, int>();
            cache.Add(0, 0);
            cache.Add(5, 1);
            cache.Add(10, 2);
            cache.Add(25, 9);

            if (n == 5)
            {
                return cache[5];
            }
            if (n == 10)
            {
                return cache[10];
            }
            if (n == 25)
            {
                return cache[25];
            }

            for (var i = 0; i <= n; i += 5)
            {
                var result = 0;

                var iMinusFive = i - 5;
                if (iMinusFive >= 0)
                {
                    result += cache[iMinusFive];
                }

                var iMinusTen = i - 10;
                if (iMinusTen >= 0)
                {
                    result += cache[iMinusTen];
                }

                var iMinusTwentyFive = i - 25;
                if (iMinusTwentyFive >= 0)
                {
                    result += cache[iMinusTwentyFive];
                }

                if (!cache.ContainsKey(i))
                {
                    cache.Add(i, result);
                }
            }

            return cache[n];
        }
    }
}
