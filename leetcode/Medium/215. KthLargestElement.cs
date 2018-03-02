public class Solution {
    // Max heap
    public void Swap(int[] heap, int index1, int index2) {
        var temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
    
    public void SieveUp(int[] heap, int index)
    {
        if(index <= 0) { return; }
        
        var parent = (index - 1)/ 2;
        if(heap[parent] < heap[index])
        {
            Swap(heap, index, parent);
        }
        SieveUp(heap, parent);
    }
    
    public void InsertToHeap(int num, int[] heap, ref int size) 
    {
        heap[size] = num;
        SieveUp(heap, size);
        size++;
    }
    
    public void SieveDown(int[] heap, int index, int size)
        {
            var leftChild = (2 * index) + 1;
            var rightChild = (2 * index) + 2;

            var largerChildValue = heap[index];

            if (leftChild < size && largerChildValue < heap[leftChild])
            {
                largerChildValue = heap[leftChild];
            }
            if (rightChild < size && largerChildValue < heap[rightChild])
            {
                largerChildValue = heap[rightChild];
            }

            if (largerChildValue != heap[index])
            {
                var largerChild = leftChild;

                if (rightChild < size && heap[rightChild] == largerChildValue)
                {
                    largerChild = rightChild;
                }
                Swap(heap, index, largerChild);
                SieveDown(heap, largerChild, size);
            }
        }

        public int RemoveFromHeap(int[] heap, ref int size)
        {
            size--;
            var value = heap[0];
            Swap(heap, size, 0);
            SieveDown(heap, 0, size);

            return value;
        }

        public int FindKthLargest(int[] nums, int k)
        {
            var heap = new int[nums.Length];
            var size = 0;
            for (var i = 0; i < heap.Length; i++)
            {
                InsertToHeap(nums[i], heap, ref size);
            }

            for (var i = 0; i < k - 1; i++) // Assume valid k
            {
                RemoveFromHeap(heap, ref size);
            }
            return heap[0];
        }
}