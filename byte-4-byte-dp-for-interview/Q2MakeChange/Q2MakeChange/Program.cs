using System;
using System.Collections.Generic;

namespace Q2MakeChange
{
    class Program
    {
        public static int MakeChange(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            List<int> denominations = new List<int>{ 10, 6, 1 };

            var result = int.MaxValue;
            foreach (var denom in denominations)
            {
                if (n >= denom)
                {
                    result = Math.Min(result, 1 + MakeChange(n - denom));
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var result = MakeChange(6);
            Console.WriteLine(result);
        }
    }
}
