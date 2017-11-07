namespace q3
{
    class Node
    {
        int _value;
        Node _next;

        public Node(int value)
        {
            _value = value;
            _next = null ;
        }

        public void AddNext(int value)
        {
            var node = new Node(value);

            var current = this;
            while (current._next != null)
            {
                current = current._next;
            }
            current._next = node;
        }

        public int Value()
        {
            return _value;
        }

        public Node Next()
        {
            return _next;
        }

        public void SetNext(Node node)
        {
            _next = node;
        }

        public void SetValue(int value)
        {
            _value = value;
        }
    }

    class Program
    {
        static void DeleteNode(Node node)   // Will not be given head nor tail.
        {
            var current = node;
            var next = current.Next();
            Node last = null;
            while (next != null)
            {
                if (next.Next() == null)
                {
                    last = next;
                }
                current.SetValue(next.Value());

                if (last != null)
                {
                    current.SetNext(null);
                }
                else
                {
                    current = next;
                }
                next = next.Next();
            }
            current.SetNext(null);
        }

        static void Main(string[] args)
        {
            var node = new Node(12);
            node.AddNext(5);
            node.AddNext(6);
            node.AddNext(8);
            node.AddNext(9);
            node.AddNext(15);

            var nodeToDelete = node.Next().Next().Next();   // 8
            DeleteNode(nodeToDelete);   // 12 -> 5 -> 6 -> 9 -> 15
        }
    }
}
