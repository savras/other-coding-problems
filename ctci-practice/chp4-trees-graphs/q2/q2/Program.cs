namespace q2
{
    class Program
    {
        public class Node
        {
            public Node() { }

            public Node(int val)
            {
                Val = val;
            }
            public int Val { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        static Node BuildBstRecursive(int[] arr, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            var mid = start + (end - start)/2;
            var node = new Node
            {
                Val = arr[mid],
                Left = BuildBstRecursive(arr, start, mid - 1),
                Right = BuildBstRecursive(arr, mid + 1, end)
            };

            return node;
        }

        static Node BuildBst(int[] arr)
        {
            var size = arr.Length;
            var root = BuildBstRecursive(arr, 0, size - 1);
            return root;
        }

        static void Main(string[] args)
        {
            var arr = new[] {0, 1 , 2, 3, 4, 5, 6, 7, 8};
            var bst = BuildBst(arr);
        }
    }
}
