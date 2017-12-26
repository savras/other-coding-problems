using System;

namespace q11_n2
{
    class Program
    {
        public static Node GetT1()
        {
            var root = new Node
            {
                Left = new Node
                {
                    Left = new Node
                    {
                        Value = 3
                    },
                    Right = new Node
                    {
                        Value = 4
                    },
                    Value = 1
                },
                Right = new Node
                {
                    Value = 2
                },
                Value = 0
            };

            return root;
        }

        public static Node GetT2()
        {
            var root = new Node
            {
                Left = new Node
                {
                    Left = new Node
                    {
                        Value = 3
                    },
                    Right = new Node
                    {
                        Value = 4
                    },
                    Value = 0
                },
                Right = new Node
                {
                },
                Value = 1
            };

            return root;
        }

        public class Node
        {
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

            if (t1Current == null || t2Current == null || t1Current != t2Current)
            {
                return false;
            }

            return IsT2SameAsCurrentNodeInT1(t1Current.Left, t2Current.Left) ||
                   IsT2SameAsCurrentNodeInT1(t1Current.Right, t2Current.Right);
        }

        public static bool IsT2SubTreeOfT1(Node current, Node t2)
        {
            if (current == null)
            {
                return true;
            }

            if (current.Value == t2.Value)
            {
                return IsT2SameAsCurrentNodeInT1(current, t2);
            }

            return IsT2SubTreeOfT1(current.Left, t2) || IsT2SubTreeOfT1(current.Right, t2);
        }

        static void Main(string[] args)
        {
            var t1 = GetT1();
            var t2 = GetT2();

            var result = true;
            if (t1 == null || t2 == null)
            {
                result = false;
            }
            else
            {
                result = IsT2SubTreeOfT1(t1, t2);
            }

            if (result)
            {
                Console.WriteLine("T2 is subtree of T1");
            }
            else
            {
                Console.WriteLine("T2 is not a subtree of T1");
            }
        }
    }
}