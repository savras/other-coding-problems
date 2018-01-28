using System;

namespace q3
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetLongestConsecutiveOnes(433);
            Console.WriteLine(result);
        }

        static int GetLongestConsecutiveOnes(int number)
        {
            var result = 0;
            var prev = 0;
            var cur = 0;
            while (number > 0)
            {
                var extractedLsb = number & 1;
                if (extractedLsb == 0)
                {
                    cur = cur - prev;
                    prev = cur + 1;
                    
                }
                cur++;
                result = Math.Max(result, cur);
                number = number >> 1;
            }

            return result;
        }
    }
}