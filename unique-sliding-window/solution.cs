using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Solution
    {
        // Unique sliding window
        // Assume num <= size of string.

        public static List<string> GetMinimumSlidingWindow(string str, int num)
        {
            var result = new List<string>();

            // Initial window
            var hs = new HashSet<char>();
            for (var i = 0; i < num; i++)
            {
                if (!hs.Contains(str[i]))
                {
                    hs.Add(str[i]);
                }
            }

            if (hs.Count == num)
            {
                result.Add(str.Substring(0, num));
            }

            // Start moving window
            for (var i = 0; i < str.Length - num; i++)
            {
                if(hs.Count == num)
                {
                    hs.Remove(str[i]);      // Remove old item from window
                }
                hs.Add(str[i + num]);   // Add in the next item in the window and keep window size

                if (hs.Count == num)
                {
                    var substring = str.Substring(i + 1, num);
                    if (!result.Contains(substring))
                    {
                        result.Add(str.Substring(i + 1, num));
                    }
                }
            }

            return result;
        }



        static void Main(string[] args)
        {
            var result = GetMinimumSlidingWindow("awaglknagawunagwkwagl", 4);
        }
    }
}