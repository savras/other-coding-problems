/*
 * Definition: * 
 * The Longest Increasing Subsequence (LIS) problem is to find the length of the longest 
 * subsequence of a given sequence such that all elements of the subsequence are sorted in increasing order. 
 * For example, the length of LIS for {10, 22, 9, 33, 21, 50, 41, 60, 80} is 6 and LIS is {10, 22, 33, 50, 60, 80}.
 * 
 * ToDo: O (n log n) solution
 */

using System;
using System.Collections.Generic;
using System.Dynamic;

namespace solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int> {10, 22, 9, 33, 21, 50, 41, 60, 80};
            var list = new List<int> {3, 4, -1, 0, 6, 2, 3};
            var len = list.Count;
            Console.WriteLine(GetLIS(list, len));
        }

        private static int GetLIS(List<int> list, int len)
        {
            var dpTable = new int[len];
            for (var i = 0; i < len; i++)
            {
                dpTable[i] = 1; // All elements have LIS 1 when there is only one digit.
            }

            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (list[j] < list[i])
                    {
                        dpTable[i] = Math.Max(dpTable[j] + 1, dpTable[i]);
                    }
                }
            }

            return GetMaxInDpTable(dpTable, len);
        }

        private static int GetMaxInDpTable(int[] dpTable, int len)
        {
            var result = 0;
            for (var i = 0; i < len; i++)
            {
                result = Math.Max(dpTable[i], result);
            }
            return result;
        }
    }
}
