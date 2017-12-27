/*
 *  This is a BST not a Binary Tree as stated in the question.
 */ 
using System;

namespace q11
{
    class Program
    {
        public static int[] GetBst()
        {
            return new[] { 10, 5, 20, 2, 7, 15, 25 };
        }

        static int GetRandomIndex(int size)
        {
            var rand = new Random();
            return rand.Next(0, size - 1);
        }

        static void Main(string[] args)
        {
            var bst = GetBst();
            var size = bst.Length;

            var randomIndex = GetRandomIndex(size);
            Console.WriteLine(bst[randomIndex]);
        }
    }
}
