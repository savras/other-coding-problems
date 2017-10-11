using System.Collections.Generic;

namespace Dijkstra
{
    public class Heap<T> where T : Entity
    {
        private readonly List<T> _heap;
        
        public Heap()
        {
            _heap = new List<T>();
        }

        public T ExtractMin()
        {
            var currentIndex = 0;
            var min = _heap[currentIndex];

            // replace root with last child
            _heap[currentIndex] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);

            // sieve-down
            var leftChildIndex = GetLeftChildIndex(currentIndex);
            var rightChildIndex = GetRightChildIndex(currentIndex);

            int smallerChildIndex = 0;
            if (leftChildIndex < _heap.Count && rightChildIndex < _heap.Count)
            {
                smallerChildIndex = _heap[leftChildIndex].Id > _heap[rightChildIndex].Id ? rightChildIndex : leftChildIndex;
            }

            while (leftChildIndex < _heap.Count && rightChildIndex < _heap.Count && _heap[currentIndex].Id > _heap[smallerChildIndex].Id)
            {
                var temp = _heap[currentIndex];
                _heap[currentIndex] = _heap[smallerChildIndex];
                _heap[smallerChildIndex] = temp;

                leftChildIndex = GetLeftChildIndex(smallerChildIndex);
                rightChildIndex = GetRightChildIndex(smallerChildIndex);
                currentIndex = smallerChildIndex;

                if (leftChildIndex < _heap.Count && rightChildIndex < _heap.Count)
                {
                    smallerChildIndex = _heap[leftChildIndex].Id > _heap[rightChildIndex].Id ? rightChildIndex : leftChildIndex;
                }
            }

            return min;
        }

        public void Insert(T item)
        {
            _heap.Add(item);

            // sieve-up
            var currentIndex = _heap.Count - 1;
            var parentIndex = GetParentIndex(currentIndex);
            while (parentIndex >= 0 && _heap[currentIndex].Id < _heap[parentIndex].Id)
            {
                var temp = _heap[parentIndex];
                _heap[parentIndex] = _heap[currentIndex];
                _heap[currentIndex] = temp;

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(parentIndex);
            }
        }

        private int GetParentIndex(int index)
        {
            if (index == 0)
            {
                return -1;
            }

            return (index - 1) / 2;
        }

        private int GetRightChildIndex(int index)
        {
            return (2 * index) + 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return (2 * index) + 1;
        }
    }
}