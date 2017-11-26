using System;
using System.Collections.Generic;

namespace q9
{
    class Program
    {
        static void PrintBrackets(int n, int openingBraceCount, int closingBraceCount, int totalBrackets, List<string> permutations, string currentBraceShape)
        {
            if (totalBrackets == n)
            {
                permutations.Add(currentBraceShape);
            }
            if (openingBraceCount < n / 2)
            {
                PrintBrackets(n, openingBraceCount + 1, closingBraceCount, totalBrackets + 1, permutations, currentBraceShape + "(");
            }
            if (closingBraceCount < openingBraceCount)
            {
                PrintBrackets(n, openingBraceCount, closingBraceCount + 1, totalBrackets + 1, permutations, currentBraceShape + ")");
            }
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n%2 != 0)
            {
                Console.WriteLine("Cannot form proper brackets with odd numbers");
            }

            var permutations = new List<string>();
            var currentBraceShape = "(";
            PrintBrackets(n, 1, 0, 1, permutations, currentBraceShape);

            foreach (var pattern in permutations)
            {
                Console.WriteLine(pattern);
            }
        }
    }
}