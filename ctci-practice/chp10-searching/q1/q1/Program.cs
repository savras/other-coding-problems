/*
 * Assume both lists are sorted ascending and last result is also sorted ascending
 * and also that all values are distinct
 */

using System;

namespace q1
{
    class Program
    {
        const int Empty = int.MaxValue;
        static int GetLastPointerForA(int[] A)
        {
            var lastIndex = A.Length - 1;
            for (var i = lastIndex; i >= 0; i--)
            {
                if (A[i] != Empty)
                {
                    lastIndex = i;
                    break;
                }
            }

            return lastIndex;
        }

        static void Main(string[] args)
        {
            //var A = new[] {-150, -23, 0, 3, Empty, Empty, Empty, Empty, Empty, Empty};
            //var B = new[] {6, 10, 57, 89, 100, 200};
            var A = new[] {6, 10, 57, 89, 100, 200, Empty, Empty, Empty, Empty};
            var B = new[] {-150, -23, 0, 3};
            //var A = new[] { -150, 0, 6, 89, 200, Empty, Empty, Empty, Empty, Empty };
            //var B = new[] { -23, 3, 10, 57, 100 };

            var lastEmptyIndex = A.Length - 1;
            var bLastPtr = B.Length - 1;
            var aLastPtr = GetLastPointerForA(A);

            while (aLastPtr >= 0 && bLastPtr >= 0)
            {
                if (A[aLastPtr] > B[bLastPtr])
                {
                    A[lastEmptyIndex] = A[aLastPtr];
                    aLastPtr--;
                    lastEmptyIndex--;
                }
                else
                {
                    A[lastEmptyIndex] = B[bLastPtr];
                    lastEmptyIndex--;
                    bLastPtr--;
                }
            }

            if (bLastPtr > 0)
            {
                for (var i = 0; i <= bLastPtr; i++)
                {
                    A[i] = B[i];
                }
            }

            for (var i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
        }
    }
}
