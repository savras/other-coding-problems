using System.Collections.Generic;

namespace q3
{
    class Program
    {
        public class LinkedListNode
        {
            public int Value { get; set; }
            public LinkedListNode Next { get; set; }
        }

        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        static Node BuildBst()
        {
            var node = new Node
            {
                Value = 5,
                Left = new Node {Value = 2, Left = new Node {Value = 1}, Right = new Node {Value = 3}},
                Right = new Node {Value = 7, Left = new Node {Value = 6}, Right = new Node {Value = 8, Right = new Node {Value = 9}}}
            };
            return node;
        }

        static void BuildLinkedList(int value, List<LinkedListNode> linkedLists, int level)
        {
            const int offset = 1;
            if (linkedLists.Count < level)
            {
                linkedLists.Add(new LinkedListNode {Value = value});
            }
            else
            {
                var current = linkedLists[level - offset];
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new LinkedListNode { Value = value };
            }
        }

        static void PreOrder(Node root, List<LinkedListNode> linkedLists, int level)
        {
            if (root != null)
            {
                BuildLinkedList(root.Value, linkedLists, level);
                PreOrder(root.Left, linkedLists, level + 1);
                PreOrder(root.Right, linkedLists, level + 1);
            }
        }

        static void Main(string[] args)
        {
            // If we get array representation of bst we can just loop and add to a new linked list every 2^n traversal.
            // var bst = new[] {5, 2, 7, 1, 3, 6, 8};	
            var root = BuildBst();

            var linkedLists = new List<LinkedListNode>();

            PreOrder(root, linkedLists, 1);
        }
    }
}
