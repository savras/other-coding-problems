namespace q3
{
    class Node()
    {
        
    }

    class Program
    {
        static void DeleteNode(Node node)   // Will not be given head nor tail.
        {
            var current = node;
            var next = current.Next;
            var last = null;
            while (next != null)
            {
                if (next.Next == null)
                {
                    last = next;
                }
                current.Value = next.Value;

                if (last != null)
                {
                    current.Next = null
                }
                else
                {
                    current = next;
                }
                next = next.Next;
            }
            previous.Next = null;
        }
        static void Main(string[] args)
        {
        }
    }
}
