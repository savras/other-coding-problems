using System.Collections.Generic;

namespace Dijkstra
{
    public class Heap<T> where T : Node
    {
        // Maps adjList node index to heap index
        private readonly Dictionary<int, int> _map;  // <key: node index of adjList, value: index in heap

        private readonly List<T> _heap;
        
        public Heap()
        {
            _map = new Dictionary<int, int>();
            _heap = new List<T>();
        }

        public void Replace(int nodeIndex, int value)
        {
            var heapIndex = _map[nodeIndex];
            MinHeapify(heapIndex, value);
        }

        private void MinHeapify(int heapIndex, int value)
        {
            var sieveUp = value > _heap[heapIndex].Distance;
            _heap[heapIndex].Distance = value;

            if (sieveUp)
            {
                SieveUp(heapIndex);
            }
            else
            {
                SieveDown(heapIndex);
            }
        }

        public T ExtractMin()
        {
            var currentIndex = 0;
            var min = _heap[currentIndex];

            // replace root with last child
            _heap[currentIndex] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);

            _map[_heap[currentIndex].Distance] = currentIndex;

            SieveDown(currentIndex);

            return min;
        }

        private void SieveDown(int currentIndex)
        {
            var leftChildIndex = GetLeftChildIndex(currentIndex);
            var rightChildIndex = GetRightChildIndex(currentIndex);

            var smallerChildIndex = GetSmallerChild(currentIndex, leftChildIndex, rightChildIndex);

            while (currentIndex != smallerChildIndex)
            {
                var temp = _heap[currentIndex];
                _heap[currentIndex] = _heap[smallerChildIndex];
                _heap[smallerChildIndex] = temp;

                _map[_heap[currentIndex].Distance] = currentIndex;
                _map[_heap[smallerChildIndex].Distance] = smallerChildIndex;

                leftChildIndex = GetLeftChildIndex(smallerChildIndex);
                rightChildIndex = GetRightChildIndex(smallerChildIndex);
                currentIndex = smallerChildIndex;

                smallerChildIndex = GetSmallerChild(currentIndex, leftChildIndex, rightChildIndex);
            }
        }

        private int GetSmallerChild(int currentIndex, int leftChildIndex, int rightChildIndex)
        {
            var smallerChildIndex = currentIndex;
            if (leftChildIndex < _heap.Count)
            {
                if (_heap[currentIndex].Distance > _heap[leftChildIndex].Distance)
                {
                    smallerChildIndex = leftChildIndex;
                }
            }
            if (rightChildIndex < _heap.Count)
            {
                if (_heap[smallerChildIndex].Distance > _heap[rightChildIndex].Distance)
                {
                    smallerChildIndex = rightChildIndex;
                }
            }
            return smallerChildIndex;
        }

        public void Insert(T item)
        {
            _heap.Add(item);
            var currentIndex = _heap.Count - 1;
            _map.Add(item.Distance, currentIndex);

            SieveUp(currentIndex);
        }

        private void SieveUp(int currentIndex)
        {
            var parentIndex = GetParentIndex(currentIndex);
            while (parentIndex >= 0 && _heap[currentIndex].Distance < _heap[parentIndex].Distance)
            {
                var temp = _heap[parentIndex];
                _heap[parentIndex] = _heap[currentIndex];
                _heap[currentIndex] = temp;

                _map[_heap[currentIndex].Distance] = currentIndex;
                _map[_heap[parentIndex].Distance] = parentIndex;

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