using System;

namespace solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[,]
            {
                { 1,  2,  3,  4},
                { 6,  7,  8,  9},
                {11, 12, 13, 14},
                {16, 17, 18, 19},
               //{ 1,  2,  3,  4,  5},
               //{ 6,  7,  8,  9, 10},
               //{11, 12, 13, 14, 15},
               //{16, 17, 18, 19, 20},
               //{21, 22, 23, 24, 25}
            };
            var n = arr.GetLength(0);

            var toggle = false;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    if (toggle)
                    {
                        Console.Write(arr[j, i - j] + " ");
                    }
                    else
                    {
                        Console.Write(arr[i - j, j] + " ");
                    }
                }
                toggle = !toggle;
            }

            var offset = 1;
            for (var i = 1; i < n; i++)
            {
                for (var j = i; j < n; j++)
                {
                    if (toggle)
                    {
                        Console.Write(arr[j, n - (j - i) - offset] + " ");
                    }
                    else
                    {
                        Console.Write(arr[n - (j - i) - offset, j] + " ");
                    }
                }
                toggle = !toggle;
            }
        }
    }
}
