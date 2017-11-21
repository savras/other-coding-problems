using System;
using System.Xml.Schema;

namespace q3
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {-40, -20, 0, -2, 5, 5, 29};
            var len = numbers.Length;
            var result = FindMagicNumber(numbers, 0, len);
            Console.WriteLine(result);
        }

        private static int FindMagicNumber(int[] numbers, int low, int high)
        {
            if (high == low)
            {
                return -1;
            }

            var mid = low + (high - low)/2;
            if (numbers[mid] == mid)
            {
                return mid;
            }

            if (numbers[mid] < mid)
            {
                return FindMagicNumber(numbers, mid + 1, high);
            }
            return FindMagicNumber(numbers, 0, mid - 1); 
        }
    }
}
