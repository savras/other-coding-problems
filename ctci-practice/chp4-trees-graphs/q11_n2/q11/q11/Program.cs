/*
 *  This is a BST not a Binary Tree as stated in the question.
 */ 
using System;
using System.Dynamic;
using System.Security.Policy;

namespace q11
{
    class Program
    {
        public static int[] GetArrayBst()
        {
            return new[] { 10, 5, 20, 2, 7, 15, 25 };
        }

        static int GetRandomIndex(int size)
        {
            var rand = new Random();
            return rand.Next(0, size - 1);
        }

        private static void ArraySolution()
        {
            var bst = GetArrayBst();
            var size = bst.Length;

            var randomIndex = GetRandomIndex(size);
            Console.WriteLine(bst[randomIndex]);
        }

        public class Node
        {
            public Node() { }
            public Node(int value)
            {
                Value = value;
            }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }
            public int LeftChildCount { get; set; }
            public int RightChildCount { get; set; }
        }

        public static Node GetBst()
        {
            Node root = null;
            root = Insert(root, 50);
            Insert(root, 25);
            Insert(root, 10);
            Insert(root, 30);
            Insert(root, 100);
            Insert(root, 75);
            Insert(root, 150);
            Insert(root, 200);
            Insert(root, 140);
            Insert(root, 120);
            Insert(root, 125);
            return root;
        }

        public static int GetDirection(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            var rand = new Random();
            var max = current.LeftChildCount + current.RightChildCount;
            var inclusiveOffset = 1;
            return rand.Next(0, max + inclusiveOffset);
        }

        public static Node GetRandomNode(Node current)
        {
            var direction = -1;
            Node randomNode = null;
            while (direction != 0)
            {
                direction = GetDirection(current);

                if (direction == 0)
                {
                    randomNode = current;
                }
                else if (direction <= current.LeftChildCount)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return randomNode;
        }

        // Find remains the same
        // Insert && Delete updates the child count of parent nodes
        public static Node Insert(Node current, int value)
        {
            if (current == null)
            {
                current = new Node(value);
            }

            else if (value <= current.Value)
            {
                current.LeftChildCount++;
                current.Left = Insert(current.Left, value);
            }
            else
            {
                current.RightChildCount++;
                current.Right = Insert(current.Right, value);
            }

            return current;
        }

        public static Node GetSuccessor(Node current)
        {
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public static Node Delete(Node current, int value)
        {
            if (current == null)
            {
                return null;
            }

            if (current.Value == value)
            {
                if (current.Left != null && current.Right != null)
                {
                    var sucessor = GetSuccessor(current.Right);
                    current.Value = sucessor.Value;
                    current.Right = Delete(current.Right, sucessor.Value);
                }
                else if (current.Right != null)
                {
                    current = current.Right;
                }
                else if (current.Left != null)
                {
                    current = current.Left;
                }
                else
                {
                    current = null;
                }
            }
            else if (value <= current.Value)
            {
                current.LeftChildCount--;
                current.Left = Delete(current.Left, value);
            }
            else
            {
                current.RightChildCount--;
                current.Right = Delete(current.Right, value);
            }

            return current;
        }

        private static void NodeSolution()
        {
            var bst = GetBst();
            var randomNode = GetRandomNode(bst);
            if (randomNode != null)
            {
                Console.WriteLine(randomNode.Value);
            }
        }

        static void Main(string[] args)
        {
            //ArraySolution();
            NodeSolution();
        }
    }
}
