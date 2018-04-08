using System;

namespace ConsoleApplication1
{
    class Solution
    {
        public static int MinRooms(TimeSpan[] arr, TimeSpan[] dep)
        {
            var n = arr.Length;
            if (n == 0) { return 0; }

            var s = 0;
            var e = 0;
            var max = 1;

            while (s < n)
            {
                if (dep[e] > arr[s])
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
            var arrTimes = new[]
            {
                new TimeSpan(0, 9, 0, 0),
                new TimeSpan(0, 9, 40, 0),
                new TimeSpan(0, 9, 50, 0),
                new TimeSpan(0, 11, 0, 0),
                new TimeSpan(0, 15, 0, 0),
                new TimeSpan(0, 18, 0, 0)
            };
            var depTimes = new[]
            {
                new TimeSpan(0, 9, 10, 0),
                new TimeSpan(0, 12, 0, 0),
                new TimeSpan(0, 11, 20, 0),
                new TimeSpan(0, 11, 30, 0),
                new TimeSpan(0, 19, 0, 0),
                new TimeSpan(0, 20, 0, 0),
                new TimeSpan(0, 18, 0, 0)
            };

            var result = MinRooms(arrTimes, depTimes);
        }
    } 
}