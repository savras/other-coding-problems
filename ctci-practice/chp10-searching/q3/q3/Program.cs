/*
 * Scenario 1: All unique integers.
 * Scenario 2: Nonunique integers - return earliest occurrence
 */ 
using System;

namespace q3
{
    class Program
    {
        static int FindPivot(int[] A, int low, int high)
        {
            var mid = low + ((high - low) / 2);
            var result = -1;

            if (A[low] > A[mid])
            {
                result = Math.Max(FindPivot(A, low, mid), result);
            }
            else if (A[mid + 1] > A[high])
            {
                result = Math.Max(FindPivot(A, mid + 1, high), result);
            }
            else
            {
                result = mid + 1;
            }

            return result;
        }

        static int FindElement(int[] A, int e, int low, int high)
        {
            var mid = low + (high - low) / 2;
            var result = -1;

            if (low == high && A[low] == e)
            {
                result = low;
            }
            else if (high > low)
            {
                if (e <= A[mid])
                {
                    result = Math.Max(FindElement(A, e, low, mid), result);
                }
                else
                {
                    result = Math.Max(FindElement(A, e, mid + 1, high), result);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            var A = new[] { 10, 14, 16, 18, 20, 21, 1, 5 };
            //var A = new[] { 4, 5, 5, 5, 5, 5, 1, 1, 1, 2};
            var n = A.Length;
            var low = 0;
            var high = n - 1;

            var e = int.Parse(Console.ReadLine());
            var startIndex = FindPivot(A, low, high);

            if (A[startIndex] <= e && A[high] >= e) 
            {
                low = startIndex; 
            }
            else if (A[low] <= e && A[startIndex - 1] >= e)
            {
                high = startIndex - 1;
            }

            var result = FindElement(A, e, low, high);

            if (result >= 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Element not found");
            }
        }
    }
}
