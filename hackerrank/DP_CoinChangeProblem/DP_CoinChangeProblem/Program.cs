using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    static long getWays(long n, List<long> c, Dictionary<string, long> memo)
    {
        var key = n + "_" + c.Count;
        if (memo.ContainsKey(key)) { return memo[key]; }

        long result = 0;
        for (var i = 0; i < c.Count; i++)
        {
            if (c[i] == n)
            {
                result += 1;
            }
            else if (c[i] < n)
            {
                var subC = new List<long>();
                for (int j = i; j < c.Count; j++)
                {
                    subC.Add(c[j]);
                }
                result += getWays(n - c[i], subC, memo);
            }
        }
        memo.Add(key, result);
        return memo[key];
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        //int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        long[] c = Array.ConvertAll(c_temp, Int64.Parse);

        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'
        var memo = new Dictionary<string, long>();
        long ways = getWays(n, c.ToList(), memo);

        Console.WriteLine(ways);
    }
}
