using System;
using System.Runtime.InteropServices;

namespace q2
{
    class Program
    {
        class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public Node Next;
            public readonly int Value;
        }

        static void Main(string[] args)
        {
            var list = new Node(1);
            list.Next = new Node(2);
            list.Next.Next = new Node(3);           // 2nd from last
            list.Next.Next.Next = new Node(4);      // 1st from last
            list.Next.Next.Next.Next = new Node(5);
            KToLast(list, 2);
        }

        static void KToLast(Node node, int k)
        {
            var p1 = node;
            var p2 = node;

            for (var i = 0; i < k; i++)
            {
                p1 = p1.Next;
            }

            while (p1.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            Console.WriteLine(p2.Value);
        }
    }
}
