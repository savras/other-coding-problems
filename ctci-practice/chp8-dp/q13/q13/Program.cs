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
                for (var j = i; j >= 0; j--)
                {
                    if (i == j)
                    {
                        cache[i] = boxes[i][0];
                    }
                    else if (boxes[j][0] < boxes[i][0] &&
                             boxes[j][1] < boxes[i][1] &&
                             boxes[j][2] < boxes[i][2])
                    {
                        // We have to loop to the end because there may be values in j later on
                        // that has sum greater than the current j.
                        cache[i] = Math.Max(boxes[i][0] + cache[j], cache[i]);  
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var orderedBoxes = new List<List<int>>
            {
                new List<int> {2, 5, 2},
                new List<int> {3, 3, 3},
                new List<int> {4, 6, 4},
                new List<int> {5, 5, 5}
            };

            var cache = orderedBoxes.Select(b => 0).ToList();
            GetMaxHeight(orderedBoxes, cache);
        }

        static List<List<int>> OrderBoxesByHeight(List<List<int>> boxes)
        {
            return boxes;
        }
    }
}
