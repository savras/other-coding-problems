namespace q6
{
    class Program
    {
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
            list.Next.Next.Next.Next = new Node("c");
            list.Next.Next.Next.Next.Next = new Node("b");
            list.Next.Next.Next.Next.Next.Next = new Node("a");

            var result = IsPalindrome(list);

        }

        static bool IsPalindrome(Node node)
        {

            return false;
        }
    }
}
