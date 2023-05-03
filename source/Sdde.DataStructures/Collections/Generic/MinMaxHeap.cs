namespace Sdde.Collections.Generic;

public class MinMaxHeap<T> where T : IComparable<T>
{
    private const int DefaultCapacity = 100;
    protected readonly IEnumerable<T> heap;
    protected readonly HeapType heapType;
    private readonly IComparer<T> comparer;
    public bool IsMinHeap => heapType == HeapType.Min;
    public bool IsEmpty => Count == 0;
    public int Count { get { return heap.Count()>= 0 ? heap.Count() : 0;} private set { Count += value; } }
    public int Capacity => heap.Count();
    public IComparer<T> Comparer => comparer ?? Comparer<T>.Default;

    public MinMaxHeap() : this(new T[DefaultCapacity], HeapType.Min, Comparer<T>.Default) { }

    public MinMaxHeap(IEnumerable<T> array) : this(array, HeapType.Min, Comparer<T>.Default)
    {
        this.heap = array;
    }

    public MinMaxHeap(HeapType heapType) : this(new T[DefaultCapacity], heapType, Comparer<T>.Default)
    {
        this.heapType = heapType;
    }

    public MinMaxHeap(IComparer<T> comparer) : this(new T[DefaultCapacity], HeapType.Min, comparer)
    {
        this.comparer = comparer;
    }

    public MinMaxHeap(
        HeapType heapType,
        IComparer<T> comparer) : this(new T[DefaultCapacity], heapType, comparer)
    {
        this.comparer = comparer;
        this.heapType = heapType;
    }

    public MinMaxHeap(
        IEnumerable<T> array,
        HeapType heapType,
        IComparer<T> comparer)
    {
        this.heap = array;
        this.heapType = heapType;
        this.comparer = comparer;
        // this.heap = buildHeap(array);
    }










    // public IEnumerable<T> buildHeap(IEnumerable<T> array)
    // {
    //     // Write your code here.
    //     return new List<T>();
    // }

    // public void siftDown(int currentIdx, int endIdx, List<int> heap)
    // {
    //     // Write your code here.
    // }

    // public void siftUp(int currentIdx, List<int> heap)
    // {
    //     // Write your code here.
    // }

    // public int Peek()
    // {
    //     // Write your code here.
    //     return -1;
    // }

    // public int Remove()
    // {
    //     // Write your code here.
    //     return -1;
    // }

    // public void Insert(int value)
    // {
    //     // Write your code here.
    // }

    // public void Swap<T>(ref T left, ref T right)
    // {
    //     var temp = left;
    //     left = right;
    //     right = temp;
    // }
}


public enum HeapType
{
    Min,
    Max
}
