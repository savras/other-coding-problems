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
            // Order by multiplication of base dimensions
            // Key observation: two factors of a number will always have one 
            // factor (in the same position e.g. width) larger or smaller than the other.
            // By ordering them by area we are getting small pieces of valid stacks. 
            // When we loop over the dp table array we are essentially looping past all smaller, valid box stacks
            // and looking for the one with the largest height.
            var orderedList = new List<List<int>>
            {
                new List<int> {3, 1, 2},
                new List<int> {2, 1, 3},
                new List<int> {1, 2, 3},
                new List<int> {6, 4, 5},
                new List<int> {5, 4, 6},
                new List<int> {7, 4, 6},
                new List<int> {6, 4, 7},
                new List<int> {4, 5, 6},
                new List<int> {4, 6, 7},
                new List<int> {32, 10, 12},
                new List<int> {12, 10, 32},
                new List<int> {10, 12, 32}
            };

            var result = GetGreatestHeight(orderedList, orderedList.Count);
            Console.WriteLine(result);
        }

        private static object GetGreatestHeight(List<List<int>> list, int n)
        {
            var cache = new int[n];
            for (var i = 0; i < n; i++)
            {
                cache[i] = list[i][0];
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    if (list[j][1] < list[i][1] &&
                        list[j][2] < list[i][2])
                    {
                        cache[i] = Math.Max(cache[i], list[i][0] + cache[j]);
                    }
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
