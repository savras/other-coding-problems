using System;
using System.Collections.Generic;

namespace q1
{
    class Program
    {

        // Top Down
        static int GetStepsMemoize(int n, Dictionary<int, int> cache)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            var one = GetStepsBruteforce(n - 1);
            var two = GetStepsBruteforce(n - 2);
            var three = GetStepsBruteforce(n - 3);

            var result = one + two + three;
            if (!cache.ContainsKey(one))
            {
                cache.Add(n, result);
            }

            return cache[n];

            // Old logic
            //if (n <= 0)
            //{
            //    return 1;
            //}

            //if (cache.ContainsKey(n))
            //{
            //    return cache[n];
            //}

            //var result = 0;
            //for (var i = 1; i <= 3; i++)
            //{
            //    if (i <= n)
            //    {
            //        result += GetStepsMemoize(n - i, cache);
            //    }
            //}
            //cache.Add(n, result);

            //return result;
        }

        static int GetStepsBruteforce(int n)
        {
            if (n == 1 || n == 2) return n;
            if (n == 3) return 4;

            return GetStepsBruteforce(n - 1) + GetStepsBruteforce(n - 2) + GetStepsBruteforce(n - 3);

            // Logic 2 - Correct but inelegent
            //if (n <= 0)
            //{
            //    return 1;
            //}

            //var result = 0;
            //for (var i = 1; i <= 3; i++)
            //{
            //    if (i <= n)
            //    {
            //        result += GetStepsBruteforce(n - i);
            //    }
            //}
            //return result;
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result2 = GetStepsBruteforce(n);

            var cache = new Dictionary<int, int> { {1, 1}, {2, 2}, {3, 4} };
            var result = GetStepsMemoize(n, cache);

            Console.WriteLine(result);
        }
    }
}