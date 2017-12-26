using System;

namespace q11_n2
{
    class Program
    {
        public static Node GetT1()
        {
            var root = new Node(0);
            root.Right = new Node(2);
            root.Left = new Node(1);
            root.Left.Left = new Node(3);
            root.Left.Right = new Node(4);
            root.Left.Right.Right = new Node(10);
            return root;
        }

        public static Node GetT2()
        {
            var root = new Node(1);
            root.Left = new Node(3);
            root.Right = new Node(4);
            root.Right.Right = new Node(10);
            return root;
        }

        public class Node
        {
            public Node(int value)
            {
                Value = value;
            }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }
        }

        public static bool IsT2SameAsCurrentNodeInT1(Node t1Current, Node t2Current)
        {
            if (t1Current == null && t2Current == null)
            {
                return true;
            }

            if (t1Current == null || t2Current == null || t1Current.Value != t2Current.Value)
            {
                return false;
            }

            return IsT2SameAsCurrentNodeInT1(t1Current.Left, t2Current.Left) &&
                   IsT2SameAsCurrentNodeInT1(t1Current.Right, t2Current.Right);
        }

        public static bool IsT2SubTreeOfT1(Node current, Node t2)
        {
            if (current == null)
            {
                return false;
            }

            if (t2 == null)
            {
                return false;
            }

            if (current.Value == t2.Value && IsT2SameAsCurrentNodeInT1(current, t2))
            {
                return true;
            }

            return IsT2SubTreeOfT1(current.Left, t2) || IsT2SubTreeOfT1(current.Right, t2);
        }

        static void Main(string[] args)
        {
            var t1 = GetT1();
            var t2 = GetT2();

            var result = IsT2SubTreeOfT1(t1, t2);
            Console.WriteLine(result ? "T2 is subtree of T1" : "T2 is NOT a subtree of T1");
        }
    }
}