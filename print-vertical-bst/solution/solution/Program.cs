using System;
using System.Collections.Generic;
using System.Linq;

namespace solution
{
    class Program
    {
        static int GetLeft(int index)
        {
            return (2*index) + 1;
        }

        static int GetRight(int index)
        {
            return (2 * index) + 2;
        }

        static void GetVerticalNodesFromBst(int[] bst, Dictionary<int, List<int>> dict, int index, int key)
        {
            if (index < bst.Length)
            {
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<int> { bst[index] });
                }
                else
                {
                    dict[key].Add(bst[index]);
                }

                GetVerticalNodesFromBst(bst, dict, GetLeft(index), key + 1);
                
                GetVerticalNodesFromBst(bst, dict, GetRight(index), key - 1);
            }
        }

        static void Main(string[] args)
        {
            var bst = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var dict = new Dictionary<int, List<int>>();
            GetVerticalNodesFromBst(bst, dict, 0, 0);

            // Print(dict);
            foreach (var list in dict.OrderByDescending(d => d.Key))
            {
                foreach (var value in list.Value)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
