using System;
using System.Collections.Generic;

namespace q2
{
    class Program
    {
        public class MyStack
        {
            private readonly Stack<int> _min;
            private readonly Stack<int> _stack;

            public MyStack()
            {
                _min = new Stack<int>();
                _stack = new Stack<int>();
            }

            public MyStack(IEnumerable<int> items)
            {
                _stack = new Stack<int>(items);
            }

            public int Pop()
            {
                if (_stack.Peek() == _min.Peek())
                {
                    _min.Pop();
                }
                return _stack.Pop();
            }

            public void Push(int item)
            {
                if (_stack.Count == 0 || item <= _min.Peek())
                {
                    _min.Push(item);
                }
                _stack.Push(item);

            }

            public int Min()
            {
                return _min.Peek();
            }
        }
        static void Main(string[] args)
        {
            var ms = new MyStack();
            ms.Push(4);
            Console.WriteLine(ms.Min());
            ms.Push(5);
            Console.WriteLine(ms.Min());
            ms.Push(6);
            Console.WriteLine(ms.Min());
            ms.Push(7);
            Console.WriteLine(ms.Min());
            ms.Push(3);
            Console.WriteLine(ms.Min());
            ms.Push(1);
            Console.WriteLine(ms.Min());
            ms.Push(2);
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Pop());
            Console.WriteLine(ms.Min());
            ms.Push(1);
            ms.Push(4);
            Console.WriteLine(ms.Min());
            Console.WriteLine(ms.Pop());
        }
    }
}
