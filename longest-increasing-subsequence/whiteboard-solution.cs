using System;

namespace ConsoleApplication1
{
    class Solution
    {
        public static int GetLongestIncreasingCount(int[] arr)
        {
            var result = 0;
            var dp = new int[arr.Length];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            for (var i = 1; i < dp.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                    if (dp[i] > result)
                    {
                        result = dp[i];
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var result = GetLongestIncreasingCount(new [] {2, 3, -1, 4, 0, -2, 1, 3, 6});
        }
    }
}