using System.Collections;

namespace Sdde.Collections.Generic;

public class MinMaxHeap<T> : IEnumerable<T> where T : IComparable<T>
{
    // public int MIN_HEAP_FUNC(T left, T right) => comparer.Compare(left, right);
    // public int MAX_HEAP_FUNC(T left, T right) => comparer.Compare(right, left);

    // public static int MIN_HEAP_FUNC(T left, T right) => left.CompareTo(right);
    // public static int MAX_HEAP_FUNC(T left, T right) => right.CompareTo(left);
    private Func<T, T, int> MIN_HEAP_FUNC = (x, y) => x.CompareTo(y);
    private Func<T, T, int> MAX_HEAP_FUNC = (x, y) => y.CompareTo(x);
    private Func<T, T, int> ComparisonFunc => IsMinHeap ? MIN_HEAP_FUNC : MAX_HEAP_FUNC;

    private int _count;
    public const int DefaultCapacity = 100;
    protected readonly IEnumerable<T> heap;
    protected readonly HeapType heapType;
    private readonly IComparer<T> comparer;
    public bool IsMinHeap => heapType == HeapType.Min;
    public bool IsEmpty => Count == 0;
    public int Count { get { return _count >= 0 ? _count : 0;} private set { _count += value; } }
    public int Capacity => heap.Count();
    public IComparer<T> Comparer => comparer ?? Comparer<T>.Default;

    public MinMaxHeap() : this(new T[DefaultCapacity], HeapType.Min, Comparer<T>.Default) => this._count = 0;
    public MinMaxHeap(IEnumerable<T> array) : this(array, HeapType.Min, Comparer<T>.Default) { }
    public MinMaxHeap(IEnumerable<T> array, HeapType heapType, IComparer<T> comparer)
    {
        this.Count = array.Count();
        this.heapType = heapType;
        this.comparer = comparer;
        this.heap = HeapSort(array.ToArray(), this.Count);
    }
    public MinMaxHeap(HeapType heapType) : this(new T[DefaultCapacity], heapType, Comparer<T>.Default) => this._count = 0;
    public MinMaxHeap(IComparer<T> comparer) : this(new T[DefaultCapacity], HeapType.Min, comparer) => this._count = 0;
    public MinMaxHeap(HeapType heapType, IComparer<T> comparer) : this(new T[DefaultCapacity], heapType, comparer) => this._count = 0;
    public MinMaxHeap(IEnumerable<T> array, HeapType heapType) : this(array, heapType, Comparer<T>.Default) { }
    public MinMaxHeap(IEnumerable<T> array, IComparer<T> comparer) : this(array, HeapType.Min, comparer) { }


    public T[] HeapSort(T[] array, int size)
    {
        ArgumentNullException.ThrowIfNull(array);
        if (size <= 1) return array;

        int startIndex = (size / 2) - 1;
        for (int currentIndex = startIndex; currentIndex >= 0; currentIndex--)
        {
            Heapify(array, size, currentIndex);
            // MinHeapify(array, size, currentIndex);
            // MaxHeapify(array, size, currentIndex);
        }

        return array;
    }

    /// <summary>
    /// Swaps the elements at the given indices
    /// </summary>
    public void Swap(ref T left, ref T right)
    {
        var temp = left;
        left = right;
        right = temp;
    }

    /// <summary>
    ///
    /// </summary>
    private void Heapify(T[] array, int size, int index)
    {
        var current = index;

        if (GetLeftChildIndex(index) < size
            && ComparisonFunc(array.ElementAt(GetLeftChildIndex(index)), array.ElementAt(current)) < 0)
        {
            current = GetLeftChildIndex(index);
        }

        if (GetRightChildIndex(index) < size
            && ComparisonFunc(array.ElementAt(GetRightChildIndex(index)), array.ElementAt(current)) < 0)
        {
            current = GetRightChildIndex(index);
        }

        if (current != index)
        {
            Swap(ref array[index], ref array[current]);
            Heapify(array, size, current);
        }
    }

    // // // /// <summary>
    // // // ///
    // // // /// </summary>
    // // // private void MinHeapify(T[] array, int size, int index)
    // // // {
    // // //     var current = index;

    // // //     if (GetLeftChildIndex(index) < size
    // // //         && ComparisonFunc(array.ElementAt(GetLeftChildIndex(index)), array.ElementAt(current)) < 0)
    // // //     {
    // // //         current = GetLeftChildIndex(index);
    // // //     }

    // // //     if (GetRightChildIndex(index) < size
    // // //         && ComparisonFunc(array.ElementAt(GetRightChildIndex(index)), array.ElementAt(current)) < 0)
    // // //     {
    // // //         current = GetRightChildIndex(index);
    // // //     }

    // // //     if (current != index)
    // // //     {
    // // //         Swap(ref array[index], ref array[current]);
    // // //         MinHeapify(array, size, current);
    // // //     }
    // // // }


    // // // /// <summary>
    // // // ///
    // // // /// </summary>
    // // // private void MaxHeapify(T[] array, int size, int index)
    // // // {
    // // //     var current = index;

    // // //     if (GetLeftChildIndex(index) < size
    // // //         && ComparisonFunc(array.ElementAt(GetLeftChildIndex(index)), array.ElementAt(current)) < 0)
    // // //     {
    // // //         current = GetLeftChildIndex(index);
    // // //     }

    // // //     if (GetRightChildIndex(index) < size
    // // //         && ComparisonFunc(array.ElementAt(GetRightChildIndex(index)), array.ElementAt(current)) < 0)
    // // //     {
    // // //         current = GetRightChildIndex(index);
    // // //     }

    // // //     if (current != index)
    // // //     {
    // // //         Swap(ref array[index], ref array[current]);
    // // //         MaxHeapify(array, size, current);
    // // //     }
    // // // }

    /// <summary>
    public void siftDown(int index)
    {
        ArgumentNullException.ThrowIfNull(heap);
        if (this.IsEmpty || this.Count == 1 || index <= 0 || index > this.Count) return;

        var (left, right) = GetChildren(index);
        if (left.CompareTo(right) < 0)
        {
            Swap(ref left, ref heap.ToArray()[index]);
            siftDown(GetLeftChildIndex(index));
        }
        else if (left.CompareTo(right) < 0)
        {
            Swap(ref right, ref heap.ToArray()[index]);
            siftDown(GetRightChildIndex(index));
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Sifts the element at the given index up the heap
    /// </summary>
    public void siftUp(int index)
    {
        ArgumentNullException.ThrowIfNull(heap);
        if (this.IsEmpty || this.Count == 1 || index <= 0 || index > this.Count) return;

        if (Compare(heap.ElementAt(index), heap.ElementAt(GetParentIndex(index))) < 0)
        {
            Swap(ref heap.ToArray()[index], ref heap.ToArray()[GetParentIndex(index)]);
            siftUp(GetParentIndex(index));
        }
    }


    /// <summary>
    /// Compares two elements of the heap
    /// </summary>
    public int Compare(T left, T right)
    {
        // encapsulates the Min vs Max logic
        return IsMinHeap ? Comparer.Compare(left, right) : Comparer.Compare(right, left);
    }

    /// <summary>
    /// Returns the children of the element at the given index
    /// </summary>
    public (T, T) GetChildren(int index)
    {
        ArgumentNullException.ThrowIfNull(heap);
        T left = heap.ElementAt(GetLeftChildIndex(index));
        T right = heap.ElementAt(GetRightChildIndex(index));
        return (left, right);
    }

    /// <summary>
    /// Returns the heap property (Min/Max) value
    /// </summary>
    public T Peek()
    {
        ArgumentNullException.ThrowIfNull(heap);
        return heap.ElementAt(0);
    }

    /// <summary>
    /// Removes the root element from the heap
    /// </summary>
    public T Remove()
    {
        ArgumentNullException.ThrowIfNull(heap);
        T value = heap.ElementAt(0);
        heap.ToArray()[0] = heap.ElementAt(this.Count - 1);
        this.Count--;
        return value;
    }

    public void Insert(T value)
    {
        ArgumentNullException.ThrowIfNull(heap);
        heap.ToArray()[this.Count] = value;
        this.Count++;
    }

    public void Clear()
    {
        heap.ToList().Clear();
        this.Count = 0;
    }

    public bool Contains(T value)
    {
        ArgumentNullException.ThrowIfNull(heap);
        return heap.Contains(value);
    }

    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < this.Capacity;
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < this.Capacity;
    private bool IsRoot(int elementIndex) => elementIndex == 0;

    private T GetLeftChild(int elementIndex) => heap.ElementAt(GetLeftChildIndex(elementIndex));
    private T GetRightChild(int elementIndex) => heap.ElementAt(GetRightChildIndex(elementIndex));
    private T GetParent(int elementIndex) => heap.ElementAt(GetParentIndex(elementIndex));

    public IEnumerator<T> GetEnumerator() => heap.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public enum HeapType
{
    Min,
    Max
}
