using System;
using System.Collections.Generic;

namespace q13
{
    class Program
    {
        static int GetMaxHeight(List<List<int>> boxes, int currentIndex)
        {
            if (currentIndex >= boxes.Count)
            {
                return 0;
            }

            var result = boxes[currentIndex][0];    // ToDo:: Better way to handle currentIndex == 0 

            if (currentIndex > 0 && currentIndex < boxes.Count)
            {
                result = boxes[currentIndex][0];

                if (boxes[currentIndex][0] > boxes[currentIndex - 1][0] &&
                    boxes[currentIndex][1] > boxes[currentIndex - 1][1] &&
                    boxes[currentIndex][2] > boxes[currentIndex - 1][2])
                {
                    result += GetMaxHeight(boxes, currentIndex + 1);
                }
                else
                {
                    result += GetMaxHeight(boxes, currentIndex + 2);
                }
            }
            else
            {
                result += GetMaxHeight(boxes, currentIndex + 1);
            }
            return result;
        }

        static void Main(string[] args)
        {
            var boxes = new List<List<int>> { new List<int>{ 5, 4, 3 } };
            var orderedBoxes = OrderBoxesByHeight(boxes);
            var result = GetMaxHeight(orderedBoxes, 0);
            Console.WriteLine(result);
        }

        static List<List<int>> OrderBoxesByHeight(List<List<int>> boxes)
        {
            return new List<List<int>>();
        }
    }
}
