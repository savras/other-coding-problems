using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Solution
    {
        public static void KthOccurrence(int[] arr, int k)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 1);
                }
                else
                {
                    dict[arr[i]]++;
                }
            }

            var sortedDict = dict.OrderByDescending(d => d.Value)
                .ThenByDescending(d => d.Key).ToList();

            for (var i = 0; i < k; i++)
            {
                Console.WriteLine(sortedDict[i].Key);
            }
        }

        static void Main(string[] args)
        {
            KthOccurrence(new[] {7, 3, 2, 4, 7, 9, 3, 2, 3, 3, 9, 7, 5, 9}, 3);
        }
    } 
}