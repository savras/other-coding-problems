/*
 * Trick is to traverse in a non-diagonal direction in the matrix where one direction gives you a different
 * property from the other (e.g. going left increases the value while going up decreases the value
 */

using System;
using System.Collections.Generic;

namespace q9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<List<int>>
            {
                new List<int>{-5, 18, 50, 124, 230, 300 },
                new List<int>{19, 21, 60, 130, 250, 360},
                new List<int>{30, 35, 78, 135, 270, 400},
                new List<int>{40, 65, 80, 165, 290, 440},
                new List<int>{43, 85, 108, 235, 370, 500},
            };

            var n = input.Count;
            var m = input[0].Count;

            var value = int.Parse(Console.ReadLine());
            var nC = n - 1;
            var mC = 0;
            
            while (nC >= 0 && mC < m)
            {
                if (input[nC][mC] == value)
                {
                    Console.WriteLine($"Row:{nC}, Col: {mC}");
                    break;
                }

                if (input[nC][mC] > value)
                {
                    nC--;
                }
                else
                {
                    mC++;
                }
            }

            if (nC < 0 || mC < 0)
            {
                Console.WriteLine("Value not Found");
            }
        }
    }
}
