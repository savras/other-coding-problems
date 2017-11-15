using System;

namespace q1
{
    class Program
    {
        static int GetSteps(int n)
        {
            if (n <= 0)
            {
                return 1;
            }
            
            var result = 0;
            for (var i = 1; i <= 3; i++)
            {
                if (i <= n)
                {
                    result += GetSteps(n - i);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = GetSteps(n);
            Console.WriteLine(result);
        }
    }
}
