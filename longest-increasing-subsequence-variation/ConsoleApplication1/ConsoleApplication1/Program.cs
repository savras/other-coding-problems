/*
 * Question from http://www.geeksforgeeks.org/dynamic-programming-set-21-box-stacking-problem/
 */

using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<List<int>>
            {
                new List<int> {1, 2, 3},
                new List<int> {3, 1, 2},
                new List<int> {2, 1, 3},
                new List<int> {4, 5, 6},
                new List<int> {4, 6, 7},
                new List<int> {5, 4, 6},
                new List<int> {7, 4, 6},
                new List<int> {6, 4, 5},
                new List<int> {6, 4, 7},
                new List<int> {10, 12, 32},
                new List<int> {12, 10, 32},
                new List<int> {32, 10, 12}
            };

            var result = GetGreatestHeight(list, list.Count);
            Console.WriteLine(result);
        }

        private static object GetGreatestHeight(List<List<int>> list, int n)
        {
            var cache = new int[n];
            for (var i = 0; i < n; i++)
            {
                cache[n] = list[i][0];
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {

                }
            }

            var result = 0;
            for (var i = 0; i < n; i++)
            {
                result = Math.Max(result, cache[i]);
            }
            return result;
        }
    }
}
