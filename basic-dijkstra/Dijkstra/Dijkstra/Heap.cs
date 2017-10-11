using System.Collections.Generic;

namespace Dijkstra
{
    public class Heap<T> where T : Entity
    {
        private List<T> _heap;

        public Heap()
        {
            _heap = new List<T>();
        }

        public T ExtractMin()
        {
            return null;
        }

        public void Insert(T item)
        {
            _heap.Add(item);

            // sieve-up
            var currentIndex = _heap.Count - 1;
            var parentIndex = GetParentIndex(currentIndex);
            while (parentIndex >= 0 && _heap[currentIndex].Id > _heap[parentIndex].Id)
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

        private T GetRightChild(int index)
        {
            var rightIndex = (2 * index) + 2;
            return _heap[rightIndex];
        }

        private T GetLeftChild(int index)
        {
            var leftIndex = (2*index) + 1;
            return _heap[leftIndex];
        }
    }
}