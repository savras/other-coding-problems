using System;

namespace q11
{
    class Program
    {
        public static int[] GetBst()
        {
            return new[] { 10, 5, 20, 2, 7, 15, 25 };
        }

        static int GetRandomNode(int size)
        {
            var rand = new Random();
            return rand.Next(0, size - 1);
        }
        static void Main(string[] args)
        {
            var bst = GetBst();
            var size = bst.Length;

            var randomNode = GetRandomNode(size);
            Console.WriteLine(bst[randomNode]);
        }
    }
}
