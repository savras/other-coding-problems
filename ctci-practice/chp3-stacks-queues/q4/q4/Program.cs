using System.Collections.Generic;

namespace q4
{
    class Program
    {
        public class MyQueue
        {
            Stack<int> _push;
            Stack<int> _pop;

            public MyQueue()
            {
                _push = new Stack<int>();
                _pop = new Stack<int>();
            }

            public void Enqueue(int item)
            {
                _push.Push(item);
            }

            public int Dequeue()
            {
                if (_pop.Count == 0)
                {
                    while (_push.Count > 0)
                    {
                        _pop.Push(_push.Pop());
                    }
                }

                return _pop.Pop();
            }
        }

        static void Main(string[] args)
        {
            var q = new MyQueue();
            q.Enqueue(1);
            q.Dequeue();
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Dequeue();
            q.Dequeue();
            q.Enqueue(5);
            q.Dequeue();
            q.Dequeue();
            q.Enqueue(6);
        }
    }
}
