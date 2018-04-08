using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Solution
    {
        public static int MinRooms(List<int[]> times)
        {
            var n = times.Count;
            if (n == 0) { return 0; }

            var sortedByStartTime = times.OrderBy(t => t[0]).ToList();
            var s = 0;
            var e = 0;
            var max = 1;

            while (s < n)
            {
                if (sortedByStartTime[e][1] > sortedByStartTime[s][0])
                {
                    max = Math.Max(max, s - e + 1);
                    s++;
                }
                else
                {
                    e++;
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            var times = new List<int[]>
            {
                new []{50, 60},
                new []{75, 80},
                new []{00, 75}
            };

            var result = MinRooms(times);
        }
    } 
}