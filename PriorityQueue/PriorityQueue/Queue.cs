namespace PriorityQueue;

/// <summary>
/// Class queue with priority.
/// </summary>
public class Queue
{
    private (string Value, int Priority, int Order)[] heap;
    private int size;
    private int counter;

    public Queue()
    {
        this.heap = [];
        this.size = 0;
        this.counter = 0;
    }

    public bool Empty => this.size == 0;

    public void Enqueue(string value, int priority)
    {
        if (this.size == this.heap.Length)
        {
            this.Resize();
        }

        this.heap[this.size] = (value, priority, this.counter++);
        this.HeapifyUp(this.size);
        this.size++;
    }

    public string Dequeue()
    {
        (string Value, int Priority, int Order) root = this.heap[0];
        this.heap[0] = this.heap[this.size - 1];
        this.size--;
        this.HeapifyD(0);
        return root.Value;
    }

    public void HeapifyD(int index)
    {
        while (true)
        {
            int leftChild = (2 * index) + 1;
            int rightChild = (2 * index) + 2;
            int small = index;
            if (leftChild < this.size && (this.heap[leftChild].Priority < this.heap[small].Priority ||
                (this.heap[leftChild].Priority == this.heap[small].Priority && this.heap[leftChild].Order < this.heap[small].Order)))
            {
                small = leftChild;
            }

            if (rightChild < this.size && (this.heap[rightChild].Priority < this.heap[rightChild].Priority ||
                (this.heap[rightChild].Priority == this.heap[small].Priority && this.heap[rightChild].Order < this.heap[small].Order)))
            {
                small = rightChild;
            }

            if (small != index)
            {
                this.Swap(index, small);
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
            if (this.heap[index].Priority < this.heap[parentIndex].Priority ||
                (this.heap[index].Priority == this.heap[parentIndex].Priority && this.heap[index].Order < this.heap[parentIndex].Order))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Resize()
    {
        int newCapacity = (this.heap.Length == 0) ? 4 : this.heap.Length * 2;
        (string Value, int Priority, int Order)[] newHeap = new (string Value, int Priority, int Order)[newCapacity];
        Array.Copy(this.heap, newHeap, this.heap.Length);
        this.heap = newHeap;
    }

    private void Swap(int i, int j)
    {
        (this.heap[j], this.heap[i]) = (this.heap[i], this.heap[j]);
    }
}
