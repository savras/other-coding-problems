using System;
using System.Collections.Generic;
using System.Linq;

namespace q13
{
    class Program
    {
        static void GetMaxHeight(List<List<int>> boxes, List<int> cache)
        {
            for (var i = 0; i < boxes.Count; i++)
            {
                var lastPickedIndex = i;
                for (var j = i; j < boxes.Count; j++)
                {
                    if (i == j)
                    {
                        cache[i] = Math.Max(boxes[i][0], cache[i]);
                    }
                    else if (boxes[j][0] < boxes[lastPickedIndex][0] &&
                             boxes[j][1] < boxes[lastPickedIndex][1] &&
                             boxes[j][2] < boxes[lastPickedIndex][2])
                    {
                        cache[j] = Math.Max(boxes[j][0] + cache[lastPickedIndex], cache[j]);
                        lastPickedIndex = j;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var orderedBoxes = new List<List<int>> { new List<int>{ 5, 5, 5 },
                                              new List<int>{ 4, 6, 4},
                                              new List<int>{ 3, 3, 3},
                                              new List<int>{ 2, 5, 2},
                                            };

            var cache = orderedBoxes.Select(b => 0).ToList();
            GetMaxHeight(orderedBoxes, cache);
            Console.WriteLine(cache[orderedBoxes.Count - 1]);
        }

        static List<List<int>> OrderBoxesByHeight(List<List<int>> boxes)
        {
            return boxes;
        }
    }
}
