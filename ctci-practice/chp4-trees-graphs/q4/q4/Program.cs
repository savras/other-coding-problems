using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q4
{
    class Program
    {
        public class Node
        {
            public Node(int val)
            {
                Val = val;
            }

            public int Val { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Balanced { get; set; }
        }

        static int GetMaxHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftHeight = GetMaxHeight(node.Left);
            var rightHeight = GetMaxHeight(node.Right);

            node.Balanced = Math.Abs(leftHeight - rightHeight) <= 1 &&
                            (node.Left == null || node.Left.Balanced) &&
                            (node.Right == null || node.Right.Balanced);

            return leftHeight + rightHeight + 1;
        }

        static void Main(string[] args)
        {
            var bst = new Node(4);
            bst.Left = new Node(1);
            bst.Left.Left = new Node(0);
            bst.Left.Right = new Node(2);
            bst.Right = new Node(6);
            bst.Right.Right = new Node(10);
            //bst.Right.Right.Right = new Node(15);

            GetMaxHeight(bst);
            Console.WriteLine(bst.Balanced);
        }
    }
}
