using System;

namespace q4
{
    class Program
    {
        class Node
        {
            public Node(int val)
            {
                Value = val;
            }
            public Node Next;
            public int Value;
        }

        static void Main(string[] args)
        {
            var list = new Node(3);
            list.Next = new Node(5);
            list.Next.Next = new Node(8);
            list.Next.Next.Next = new Node(5);
            list.Next.Next.Next.Next = new Node(10);
            list.Next.Next.Next.Next.Next = new Node(2);
            list.Next.Next.Next.Next.Next.Next = new Node(1);

            var val = 5;
            var head = Partition(list, val);

            var current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }

        static Node Partition(Node node, int val)
        {
            if (node == null)
            {
                return node;
            }

            var head = node;
            var prev = node;
            var current = node.Next;

            while (current != null)
            {
                if (current.Value < val)
                {
                    prev.Next = current.Next;
                    current.Next = head;
                    head = current;
                    current = prev.Next;
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            }

            return head;
        }
    }
}
