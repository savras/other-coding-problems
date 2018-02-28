using System;

namespace ConsoleApplication1
{
    class Program
    {
        class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        static void PrintBoundary(Node root)
        {
            if (root == null) { return; }

            Console.WriteLine(root.Value);

            // Print left side.
            PrintLeftBoundary(root.Left);

            // Print right boundary	
            PrintRightBoundary(root.Right);
        }

        static void PrintLeafNodes(Node current)
        {
            if (current == null) { return; }

            PrintLeafNodes(current.Left);
            if (current.Left == null && current.Right == null)
            {
                Console.WriteLine(current.Value);
            }
            PrintLeafNodes(current.Right);
        }

        static void PrintLeftBoundary(Node current)
        {
            if (current == null) { return; }

            Console.WriteLine(current.Value);
            PrintLeftBoundary(current.Left);
            PrintLeafNodes(current.Right);
        }

        static void PrintRightBoundary(Node current)
        {
            if (current == null) { return; }

            PrintLeafNodes(current.Left);
            PrintRightBoundary(current.Right);
            Console.WriteLine(current.Value);
        }

        static void Main(string[] args)
        {
            var root = new Node(1);
            root.Left = new Node(2);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            root.Left.Right.Right = new Node(9);
            root.Left.Right.Right.Left = new Node(12);
            root.Left.Right.Left = new Node(8);

            root.Right = new Node(3);
            root.Right.Left = new Node(6);

            root.Right.Right = new Node(7);
            root.Right.Right.Left = new Node(10);
            root.Right.Right.Left.Right = new Node(14);
            root.Right.Right.Left.Right.Right = new Node(17);
            root.Right.Right.Right = new Node(11);

            root.Right.Right.Left.Left = new Node(13);
            root.Right.Right.Left.Left.Left = new Node(15);
            root.Right.Right.Left.Left.Right = new Node(16);
            root.Right.Right.Left.Left.Right.Left = new Node(18);

            PrintBoundary(root);
        }
    }
}
