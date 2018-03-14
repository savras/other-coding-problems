using System;
using System.Security.Claims;

namespace ConsoleApplication1
{
    class Solution
    {
        public static void LongestPalindromicSequence(char[] arr)
        {
            var len = arr.Length;
            var dp = new bool[len, len];
            for (var i = 0; i < len; i++)
            {
                dp[i, i] = true;

                if (i < len - 1)
                {
                    dp[i + 1, i] = true;
                }
            }

            var max = 0;
            var start = 0;
            var end = 0;
            for (var i = 1; i < len; i++)
            {
                for (var col = i; col < len; col++)
                {
                    var row = col - i;
                    if (arr[col] == arr[row] && dp[row + 1, col - 1])
                    {
                        dp[row, col] = true;
                        if (col - row + 1 > max)
                        {
                            max = col - row + 1;
                            start = row;
                            end = col;
                        }
                    }

                }
            }
            if (start != end)
            {
                for (var i = start; i <= end; i++)
                {
                    Console.Write(arr[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(max);
        }

        static void Main(string[] args)
        {
            LongestPalindromicSequence(new[] {'g', 'e', 'e', 'g', 's', 's'});
        }
    }
}