using System;

namespace ConsoleApplication1
{
    public class Solution
    {
        public  static void PrintParenthesis(int openingBrktCount, int closingBrktCount, int index, char[] buffer, int num)
        {
            if (index >= num * 2)
            {
                PrintResult(buffer);
                return;
            }

            if (openingBrktCount < num)
            {
                buffer[index] = '(';
                PrintParenthesis(openingBrktCount + 1, closingBrktCount, index + 1, buffer, num);
            }

            if (closingBrktCount < openingBrktCount)
            {
                buffer[index] = ')';
                PrintParenthesis(openingBrktCount, closingBrktCount + 1, index + 1, buffer, num);
            }
        }

        public static void PrintResult(char[] buffer)
        {
            for (var i = 0; i < buffer.Length; i++)
            {
                Console.Write(buffer[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var num = 5;
            PrintParenthesis(0, 0, 0, new char[num * 2], num);
        }
    }
}