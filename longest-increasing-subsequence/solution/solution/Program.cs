/*
 * Definition: * 
 * The Longest Increasing Subsequence (LIS) problem is to find the length of the longest 
 * subsequence of a given sequence such that all elements of the subsequence are sorted in increasing order. 
 * For example, the length of LIS for {10, 22, 9, 33, 21, 50, 41, 60, 80} is 6 and LIS is {10, 22, 33, 50, 60, 80}.
 */

using System.Collections.Generic;
using System.Dynamic;

namespace solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {10, 22, 9, 33, 21, 50, 41, 60, 80};
            var result = GetLis(list);
        }

        private static int GetLis(List<int> list)
        {
            return 0;
        }
    }
}
