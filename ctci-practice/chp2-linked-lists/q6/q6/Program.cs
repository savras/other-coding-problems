using System;
using System.Collections.Generic;

namespace q6
{
    class Program
    {
        public static int Current = -1; // zero based

        public class Node
        {
            public Node(string val)
            {
                Value = val;
            }
            public Node Next;
            public string Value;
        }
        static void Main(string[] args)
        {

            var list = new Node("a");
            list.Next = new Node("b");
            list.Next.Next = new Node("c");
            list.Next.Next.Next = new Node("d");
            list.Next.Next.Next.Next = new Node("b");
            list.Next.Next.Next.Next.Next = new Node("a");

            var size = 6;
            var result = IsPalindrome(list, size, new Stack<string>());
            Console.WriteLine(result);
        }

        static bool IsPalindrome(Node node, int size, Stack<string> s)
        {
            Current++;
            if (node == null || Current >= size)
            {
                return true;
            }

            if (size%2 != 0 && Current == size/2)
            {
                // Is middle value for odd no. size
                return IsPalindrome(node.Next, size, s);
            }

            if (Current < (size/2))
            {
                s.Push(node.Value);
                return IsPalindrome(node.Next, size, s);
            }
            return s.Pop() == node.Value && IsPalindrome(node.Next, size, s);
        }
    }
}
