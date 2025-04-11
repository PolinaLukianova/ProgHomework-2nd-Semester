namespace PriorityQueue;

public class Queue
{
    public (string Value, int Priority, int Order)[] heap;
    public int size;
    public int counter;

    public Queue()
    {
        heap = [];
        size = 0;
        counter = 0;
    }
    public void Enqueue(string value, int priority)
    {
        if (size == heap.Length)
        {
            Resize();
        }
        heap[size] = (value, priority, counter++);
        HeapifyUp(size);
        size++;
    }

    private void Resize()
    {
        int newCapacity = (heap.Length == 0) ? 4 : heap.Length * 2;
        (string Value, int Priority, int Order)[] newHeap = new (string Value, int Priority, int Order)[newCapacity];
        Array.Copy(heap, newHeap, heap.Length);
        heap = newHeap;
    }
    public string Dequeue()
    {
        (string value, int priority, int order) root = heap[0];
        heap[0] = heap[size - 1];
        size--;
        HeapifyD(0);
        return root.value;
    }

    public  void HeapifyD(int index)
    {
        while (true)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int small = index;
            if (leftChild < size && (heap[leftChild].Priority < heap[small].Priority || 
                (heap[leftChild].Priority == heap[small].Priority && heap[leftChild].Order < heap[small].Order)))
            {
                small = leftChild;
            }

            if (rightChild < size && (heap[rightChild].Priority < heap[rightChild].Priority || 
                (heap[rightChild].Priority == heap[small].Priority && heap[rightChild].Order < heap[small].Order)))
            {
                small = rightChild;
            }

            if (small != index)
            {
                Swap(index, small);
                index = small;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index].Priority < heap[parentIndex].Priority ||
                (heap[index].Priority == heap[parentIndex].Priority && heap[index].Order < heap[parentIndex].Order))
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int i, int j)
    {
        (heap[j], heap[i]) = (heap[i], heap[j]);
    }

    public bool Empty => size == 0;
}
