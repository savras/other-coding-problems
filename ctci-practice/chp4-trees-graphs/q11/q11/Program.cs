using System;

namespace q11
{
    class Program
    {
        static int[] GetT1()
        {
            return new[] {0, 1, 2, 3, 4, -1, -1, -1, -1, -1, 5, -1, -1, -1, -1};
        }

        static int[] GetT2()
        {
            return new[] {-1, -1, -1, -1, 4, -1, -1, -1, -1, -1, 5, -1, -1, -1, -1};
        }

        static bool IsT2SubtreeOfT1(int[] t1, int[] t2)
        {
            return false;
        }

        static void Main(string[] args)
        {
            var t1 = GetT1();
            var t2 = GetT2();

            var result = IsT2SubtreeOfT1(t1, t2);

            Console.WriteLine(result);
        }
    }
}