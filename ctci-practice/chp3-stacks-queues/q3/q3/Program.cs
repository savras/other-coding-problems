using System.Collections.Generic;

namespace q3
{
    class Program
    {
        public class MyStack<T>
        {
            private int _currentIndex;
            private readonly List<Stack<T>> _stacks;
            private readonly int _limit;

            public MyStack(int limit)
            {
                _currentIndex = 0;
                _limit = limit;
                _stacks = new List<Stack<T>>();
                _stacks.Add( new Stack<T>());
            }

            public void Push(T val)
            {
                if (_stacks[_currentIndex].Count == _limit)
                {
                    _currentIndex++;

                    if (_stacks.Count <= _currentIndex)
                    {
                        _stacks.Add(new Stack<T>());

                    }
                }
                _stacks[_currentIndex].Push(val);
            }

            public T Pop()
            {
                // Find value in previous stacks
                if (_stacks[_currentIndex].Count == 0)
                {
                    _currentIndex--;
                    while (_stacks[_currentIndex].Count == 0 && _currentIndex > 0)
                    {
                        _currentIndex--;
                    }
                }
                var result =  _stacks[_currentIndex].Pop();    // Let Stack throw appropriate exception

                // Compress
                if (_stacks[_currentIndex].Count == 0 && _currentIndex > 0)
                {
                    _currentIndex--;
                }
                return result;
            }

            public T PopAt(int index)
            {
                return _stacks[index].Pop();
            }
        }

        static void Main(string[] args)
        {
            var ms = new MyStack<int>(4);
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            ms.Push(4);
            ms.Push(5);
            ms.PopAt(0);
            ms.PopAt(0);
            ms.PopAt(0);
            ms.PopAt(0);
            ms.Push(7);
            ms.Pop();
            ms.Pop();
            ms.Push(8);
            ms.Push(9);
            ms.Push(6);
            ms.Push(11);
            ms.Push(12);
            ms.Push(15);
            ms.Push(17);
            ms.Push(19);
            ms.Push(20);
            ms.PopAt(0);
            ms.PopAt(0);
            ms.Pop();
            ms.Pop();
            ms.Pop();
            ms.Pop();
            ms.Pop();
            ms.Push(24);
        }
    }
}
