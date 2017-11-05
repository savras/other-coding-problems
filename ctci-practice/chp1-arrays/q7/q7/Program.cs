/* Initial
 * { 1, 2, 3, 4},
 * { 5, 6, 7, 8},
 * { 9, 10, 11, 12 },
 * { 13, 14, 15, 16 }
 * 
 * Result
 * { 13, 9, 5, 1},
 * { 14, 10, 6, 2},
 * { 15, 11, 7, 3 },
 * { 16, 12, 8, 4 } 
 */

using System;

namespace q7
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var arr = new[, ]
            {
                { 1, 2, 3, 4},
                { 5, 6, 7, 8},
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };


            // if n %2 != 0, outer loop loops from i = 0 to i = n/2 (incl)
            // if n %2 == 0, outer loop loops from i = 0 to < n/2 -1
            var limit = n / 2;

            for (var i = 0; i < limit; i++)
            {
                var maxIndex = n - i - 1;
                for (var j = i; j < maxIndex; j++)
                {
                    var descendingIndex = maxIndex - j + i;

                    var temp = arr[i,j];
                    arr[i,j] = arr[descendingIndex, i];
                    arr[descendingIndex, i] = arr[maxIndex, descendingIndex];
                    arr[maxIndex, descendingIndex] = arr[j,maxIndex];
                    arr[j,maxIndex] = temp;
                }
            }
        }
    }
}
