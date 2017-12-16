using System;

namespace q5
{
    class Program
    {
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }
        }

        private static int previousVisited { get; set; }

        public static bool InorderCheckIsBst(Node node)
        {
            if (node == null) { return true; }

            var result = InorderCheckIsBst(node.Left);
            result = result && (node.Value >= previousVisited);
            previousVisited = node.Value;
            result = result && InorderCheckIsBst(node.Right);
            return result;
        }

        static Node GetBinaryTree()
        {
            var root = new Node
            {
                Value = 50,
                Left = new Node
                {
                    Value = 10,
                    Left = new Node
                    {
                        Value = 5
                    },
                    Right = new Node
                    {
                        Value = 25
                    }
                },
                Right = new Node
                {
                    Value = 100,
                    Left = new Node
                    {
                        Value = 75,
                        Left = new Node
                        {
                            Value = 62
                        },
                        Right = new Node
                        {
                            Value = 80
                        }
                    }
                }
            };
            return root;
        }

        static bool RangeCheckIsBst(Node node, int min, int max)
        {
            var result = true;
            if (node != null)
            {
                result = (RangeCheckIsBst(node.Left, min, node.Value)) && 
                         (node.Value >= min && node.Value <= max) && 
                         (RangeCheckIsBst(node.Right, node.Value, max));
            }
            return result;
        }

        static void Main(string[] args)
        {
            var btRoot = GetBinaryTree();
            //var isBst = InorderCheckIsBst(btRoot);
            var isBst = RangeCheckIsBst(btRoot, int.MinValue, int.MaxValue);

            Console.WriteLine(isBst);
        }
    }
}