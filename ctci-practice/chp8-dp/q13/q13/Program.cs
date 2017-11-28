using System;
using System.Collections.Generic;

namespace q13
{
    class Program
    {
        static int GetMaxHeight(List<List<int>> boxes, int currentIndex, int lastPickedIndex, List<int> cache)
        {
            if (currentIndex >= boxes.Count)
            {
                return 0;
            }

            if (cache[currentIndex] != 0)
            {
                return cache[currentIndex];
            }

            var result = boxes[currentIndex][0];
            if (currentIndex == lastPickedIndex)
            {
                result += GetMaxHeight(boxes, currentIndex + 1, currentIndex, cache);
            }
            else    // currentIndex > 0 && currentIndex < boxes.Count
            {
                if (boxes[currentIndex][0] < boxes[lastPickedIndex][0] &&
                    boxes[currentIndex][1] < boxes[lastPickedIndex][1] &&
                    boxes[currentIndex][2] < boxes[lastPickedIndex][2])
                {
                    result += GetMaxHeight(boxes, currentIndex + 1, currentIndex, cache);
                }
                else
                {
                    result = 0;
                    result += GetMaxHeight(boxes, currentIndex + 1, lastPickedIndex, cache);
                }
            }

            cache[currentIndex] = result;
            return cache[currentIndex];
        }

        static void Main(string[] args)
        {
            var boxes = new List<List<int>> { new List<int>{ 5, 5, 5 },
                                              new List<int>{ 4, 6, 4},
                                              new List<int>{ 3, 3, 3},
                                            };
            var orderedBoxes = OrderBoxesByHeight(boxes);
            var cache = new List<int>(boxes.Count) { 0, 0, 0 };
            for(var i = 0; i < boxes.Count; i++)
            {
                if (cache[i] == 0)
                {
                    GetMaxHeight(orderedBoxes, i, i, cache);
                }
            }
        }

        static List<List<int>> OrderBoxesByHeight(List<List<int>> boxes)
        {
            return boxes ;
        }
    }
}
