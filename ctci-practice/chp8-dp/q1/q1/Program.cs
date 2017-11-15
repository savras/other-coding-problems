using System;
using System.Collections.Generic;

namespace q1
{
    class Program
    {
        static int GetStepsMemoize(int n, Dictionary<int, int> cache)
        {
            if (n <= 0)
            {
                return 1;
            }

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            var result = 0;
            for (var i = 1; i <= 3; i++)
            {
                if (i <= n)
                {
                    result += GetStepsMemoize(n - i, cache);
                }
            }
            cache.Add(n, result);

            return result;
        }

        static int GetStepsBruteforce(int n)
        {
            if (n <= 0)
            {
                return 1;
            }

            var result = 0;
            for (var i = 1; i <= 3; i++)
            {
                if (i <= n)
                {
                    result += GetStepsBruteforce(n - i);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine("0");
            }
            else
            {

                //var result = GetStepsBruteforce(n);

                var cache = new Dictionary<int, int>();
                var result = GetStepsMemoize(n, cache);

                //var result = GetStepsDp(n);
                Console.WriteLine(result);
            }
        }
    }
}