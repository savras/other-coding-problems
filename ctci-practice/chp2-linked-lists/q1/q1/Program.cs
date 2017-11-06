using System.Collections.Generic;

namespace q1
{
    class Node
    {
        private readonly int _value;
        private Node _next;

        public Node(int value)
        {
            _value = value;
            _next = null;
        }

        public int Value()
        {
            return _value;
        }

        public Node Next()
        {
            return _next;
        }

        public void SetNext(Node next)
        {
            _next = next;
        }
    }

    class LinkedList
    {
        private Node _head;
        private Node _tail;
        private int _length;

        public LinkedList()
        {
            _head = null;
            _tail = null;
            _length = 0;
        }
        public LinkedList(int value)
        {
            var node = new Node(value);
            _head = node;
            _tail = node;
            _length = 1;
        }

        public void DecrementLength()
        {
            _length--;
        }

        public void AddNext(int value)
        {
            var node = new Node(value);
            if (_length == 0)
            {
                
                _head = node;
                _tail = node;
                _length = 1;
            }
            else
            {
                _tail.SetNext(node);
                _tail = node;
                _length++;
            }
        }

        public Node Head()
        {
            return _head;
        }

        public Node Tail()
        {
            return _tail;
        }

        public int Length()
        {
            return _length;
        }
    }

    class Program
    {
        private static LinkedList _linkedList;

        static void RemoveDuplicateUsingBuffer()
        {
            if (_linkedList.Length() <= 1)
            {
                return;
            }

            var hashset = new HashSet<int> {_linkedList.Head().Value()};

            var current = _linkedList.Head().Next();
            var previous = _linkedList.Head();
            while (current != null)
            {
                if (hashset.Contains(current.Value()))
                {
                    previous.SetNext(current.Next());
                    current.SetNext(null);
                    _linkedList.DecrementLength();
                }
                else
                {
                    hashset.Add(current.Value());
                    previous = current;
                }
                current = previous.Next();
            }
        }

        static void RemoveDuplicate()
        {
            if (_linkedList.Length() <= 1)
            {
                return;
            }

            var start = _linkedList.Head();
            while (start != null)
            {
                var current = start.Next();
                var previous = start;
                while (current != null)
                {
                    if (start.Value() == current.Value())
                    {
                        previous.SetNext(current.Next());
                        previous = previous.Next();
                        current.SetNext(null);
                        current = previous.Next();
                        _linkedList.DecrementLength();
                    }
                    else
                    {
                        previous = previous.Next();
                        current = previous.Next();
                    }
                }
                start = start.Next();
            }
        }

        static void Main(string[] args)
        {
            _linkedList = new LinkedList(5);
            _linkedList.AddNext(6);
            _linkedList.AddNext(2);
            _linkedList.AddNext(5);
            _linkedList.AddNext(2);
            _linkedList.AddNext(6);
            _linkedList.AddNext(8);
            //RemoveDuplicateUsingBuffer();
            RemoveDuplicate();
        }
    }
}