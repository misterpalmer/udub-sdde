using System.Collections;

namespace Sdde.Collections.Generic;
public class MinMaxHeap<T> where T : IComparable<T>
{
    public const int DEFAULT_CAPACITY = 4;
    public T[] Heap { get; private set; }
    private int _count;
    public int Count { get { return _count > 0 ? _count : 0;} private set { _count = value; } }
    public bool IsEmpty => Count == 0;
    public int Capacity => Heap.Length;
    private IComparer<T> _comparer;
    public IComparer<T> Comparer => _comparer ?? MinMaxHeapNodeComparer<T>.Default;
    // private Comparer<T> _comparer;
    // public Comparer<T> Comparer => _comparer ?? MinMaxHeapNodeComparer<T>.Comparer;
    public Func<T, T, int> ComparisonFunc => Comparer.Compare;

    public MinMaxHeap(IEnumerable<T> array, IComparer<T> comparer)
    {
        Heap = array.ToArray();
        Count = array.Count();
        _comparer = comparer;
        BuildHeap();
    }

    // public MinMaxHeap(IEnumerable<T> array, Comparer<T> comparer)
    // {
    //     Heap = array.ToArray();
    //     Count = array.Count();
    //     _comparer = comparer;
    //     BuildHeap();
    // }
    public MinMaxHeap() : this(new T[DEFAULT_CAPACITY], Comparer<T>.Default) => _count = 0;
    public MinMaxHeap(IEnumerable<T> array) : this(array, Comparer<T>.Default) { }
    // public MinMaxHeap(Comparer<T> comparer) : this(new T[DEFAULT_CAPACITY], comparer) => _count = 0;
    public MinMaxHeap(IComparer<T> comparer) : this(new T[DEFAULT_CAPACITY], comparer) => _count = 0;

    /// <summary>
    /// Returns the index of the parent of the element at the given index
    /// </summary>
    private void Heapify(int index = 0)
    {
        while (index < Count)
        {
            if (GetLeftChildIndex(index) >= Count) break;

            int current = GetLeftChildIndex(index);
            if (GetRightChildIndex(index) < Count
                && Compare(Heap[GetLeftChildIndex(index)], Heap[GetRightChildIndex(index)]) > 0)
            {
                current = GetRightChildIndex(index);
            }

            if (Compare(Heap[index], Heap[current]) < 0) break;
            Swap(index, current);
            index = current;
        }
    }

    private void Heapify2(int index = 0)
    {
        var current = index;

        if (GetLeftChildIndex(index) < Count
            && Compare(Heap[GetLeftChildIndex(index)], Heap[current]) < 0)
        {
            current = GetLeftChildIndex(index);
        }

        if (GetRightChildIndex(index) < Count
            && Compare(Heap[GetRightChildIndex(index)], Heap[current]) < 0)
        {
            current = GetRightChildIndex(index);
        }

        if (current != index)
        {
            Swap(index, current);
            Heapify2(current);
        }
    }

    /// <summary>
    /// Build the heap
    /// </summary>
    public void BuildHeap()
    {
        ArgumentNullException.ThrowIfNull(Heap);

        // Perform level order traversal
        // first index of non-leaf node
        int startIndex = (Count / 2) - 1;
        for (int parentIndex = startIndex; parentIndex >= 0; parentIndex--)
        {
            Heapify(parentIndex);
		    // Heapify2(parentIndex);
	    }

    }

    /// <summary>
    /// Build the heap
    /// </summary>
    public virtual void BuildMinHeap(int index = 0)
    {
        ArgumentNullException.ThrowIfNull(Heap);

        // first index of non-leaf node
        int startIndex = (Count / 2) - 1;
        for (int parentIndex = startIndex; parentIndex >= 0; parentIndex--)
        {
            int childIndex = parentIndex;
            (var left, var right) = (GetLeftChildIndex(parentIndex), GetRightChildIndex(parentIndex));
            if (Compare(Heap[left], Heap[right]) < 0)
            {
                childIndex = left;
            }
            else if (Compare(Heap[left], Heap[right]) > 0)
            {
                childIndex = right;
            }

            if ((childIndex < Count) && (childIndex != parentIndex)) Swap(parentIndex, childIndex);
        }
    }

    public virtual void BuildMinHeap2(int index = 0)
    {
        ArgumentNullException.ThrowIfNull(Heap);

        // first index of non-leaf node
        int startIndex = (Count / 2) - 1;
        for (int parentIndex = startIndex; parentIndex >= 0; parentIndex--)
        {
            int childIndex = parentIndex;
            while(HasLeftChild(childIndex))
            {
                (var left, var right) = (GetLeftChildIndex(parentIndex), GetRightChildIndex(parentIndex));
                if ((right < Count) && (Compare(Heap[left], Heap[right]) < 0))
                {
                    childIndex = left;
                }
                else if ((right < Count) && (Compare(Heap[left], Heap[right]) > 0))
                {
                    childIndex = right;
                }

                if ((childIndex == parentIndex) || (Compare(Heap[childIndex], Heap[parentIndex])) >= 0)
                {
                    int ndx = childIndex % 2 == 0 ? childIndex : childIndex - 1;
                    parentIndex = GetParentIndex(ndx);
                    break;
                }
                Swap(parentIndex, childIndex);
                parentIndex = childIndex;
            }
        }
    }

    // /// <summary>
    // /// Build the heap
    // /// </summary>
    // public virtual void BuildMaxHeap()
    // {
    //     ArgumentNullException.ThrowIfNull(Heap);

    //     SiftUp();
    //     // int childIndex = 0;
    //     // while (childIndex < Count - 1)
    //     // {
    //     //     int parentIndex = GetParentIndex(childIndex);
    //     //     if (Compare(Heap[childIndex], Heap[parentIndex]) > 0)
    //     //     {
    //     //         Swap(childIndex, parentIndex);
    //     //     }

    //     //     childIndex++;
    //     // }
    // }

    /// <summary>
    private void SiftDown(int index)
    {
        ArgumentNullException.ThrowIfNull(Heap);
        if (IsEmpty || Count == 1) return;

        while (index < Count)
        {
            int childIndex = index;
            if (GetLeftChildIndex(index) < Count && Compare(Heap[GetLeftChildIndex(index)], Heap[index]) < 0)
                childIndex = GetLeftChildIndex(index);

            if (GetRightChildIndex(index) < Count && Compare(Heap[GetRightChildIndex(index)], Heap[index]) < 0)
                childIndex = GetRightChildIndex(index);

            if (Compare(Heap[childIndex], Heap[index]) >= 0)
                return;

            if (index != childIndex)
                Swap(index, childIndex);

            // index = childIndex;
        }
    }

    /// <summary>
    /// Sifts the element at the given index up the heap
    /// </summary>
    public void SiftUp()
    {
        ArgumentNullException.ThrowIfNull(Heap);
        if (IsEmpty || Count == 1) return;

        var index = Count - 1;
        var parentIndex = GetParentIndex(index);
        while (Compare(Heap[index], Heap[GetParentIndex(index)]) < 0)
        {
            Swap(index, parentIndex);
            index = parentIndex;

            var next = GetParentIndex((index - 1) / 2);
            parentIndex = GetParentIndex(next);
        }
    }

    /// <summary>
    /// Swaps the elements at the given indices
    /// </summary>
    public void Swap(int left, int right)
    {
        var temp = Heap[left];
        Heap[left] = Heap[right];
        Heap[right] = temp;
    }

    /// <summary>
    /// Compares two elements of the heap
    /// </summary>
    public int Compare(T left, T right)
    {
        // encapsulates the Min vs Max logic
        var compare = ComparisonFunc(left, right);
        return compare;
    }

    /// <summary>
    /// Returns the heap property (Min/Max) value
    /// </summary>
    public T Peek()
    {
        ArgumentNullException.ThrowIfNull(Heap);

        return Heap[0];
    }

    /// <summary>
    /// Adds an item to the heap
    /// </summary>
    public void Insert(T item)
    {
        ArgumentNullException.ThrowIfNull(Heap);

        EnsureCapacity();
        Heap[Count] = item;
        Count++;

        if (Compare(GetLeftChild(0), Heap[0]) < 0 && Compare(GetRightChild(0), Heap[0]) < 0)
            SiftUp();
    }

    /// <summary>
    /// Removes the root element from the heap
    /// </summary>
    public T Remove()
    {
        ArgumentNullException.ThrowIfNull(Heap);

        T item = Heap[0];
        Swap(0, Count - 1);
        Heap[Count - 1] = default(T);
        Count--;

        if (Compare(GetLeftChild(0), Heap[0]) > 0 && Compare(GetRightChild(0), Heap[0]) > 0)
            SiftDown(0);

        return item;
    }

    /// <summary>
    /// Removes all elements from the heap
    /// </summary>
    public void Clear()
    {
        Heap = new T[DEFAULT_CAPACITY];
        Count = 0;
    }

    /// <summary>
    /// Grows the heap using the a growth factor of Capacity >> 1
    /// </summary>
    public void Resize()
    {
        int resizeCapacity = Capacity < DEFAULT_CAPACITY ? DEFAULT_CAPACITY : Capacity >> 1;
        T[] resizedArray = new T[resizeCapacity];

        int counter = 0;
        while (counter < Count)
        {
            resizedArray[counter] = Heap[counter];
            counter++;
        }

        Heap = resizedArray;
    }

    private bool EnsureCapacity()
    {
        if (Count == Capacity)
        {
            Resize();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Returns the parent of the element at the given index
    /// </summary>
    private T GetParent(int elementIndex) => Heap[GetParentIndex(elementIndex)];

    /// <summary>
    /// Returns the children of the element at the given index
    /// </summary>
    public (T, T) GetChildren(int index)
    {
        ArgumentNullException.ThrowIfNull(Heap);

        T left = Heap[GetLeftChildIndex(index)];
        T right = Heap[GetRightChildIndex(index)];
        return (left, right);
    }

    /// <summary>
    /// Returns the left child of the parent element at the given index
    /// </summary>
    private T GetLeftChild(int elementIndex) => Heap[GetLeftChildIndex(elementIndex)];

    /// <summary>
    /// Returns the right child of the parent element at the given index
    /// </summary>
    private T GetRightChild(int elementIndex) => Heap[GetRightChildIndex(elementIndex)];

    /// <summary>
    /// Returns the parent index of the child element at the given index
    /// </summary>
    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

    /// <summary>
    /// Returns the left child index of the parent element at the given index
    /// </summary>
    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;

    /// <summary>
    /// Returns the right child index of the parent element at the given index
    /// </summary>
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;

    /// <summary>
    /// Evaluates if the element at the given index has a left child
    /// </summary>
    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < this.Capacity;

    /// <summary>
    /// Evaluates if the element at the given index has a right child
    /// </summary>
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < this.Capacity;
}


// public static class MinHeap
// {
//     public static MinMaxHeap<T> Create<T, TPriority>(Func<T, TPriority> priority, IEnumerable<T> items,
//         IComparer<TPriority>? comparer = null)
//     {
//         return new MinMaxHeap<T>(priority, items, comparer);
//     }
// }

// public static class MaxHeap
// {
//     public static MinMaxHeap<T, TPriority> Create<T, TPriority>(Func<T, TPriority> priority, IEnumerable<T> items,
//         IComparer<TPriority>? comparer = null)
//     {
//         return new MinMaxHeap<T>(priority, items, comparer);
//     }
// }


/// <summary>
/// Evaluates if the heap satisfies the heap property
// /// </summary>
// public static bool IsHeap(IList<T> array, int size)
// {
//     return true;
// }


/// <summary>
/// Returns the index of the parent of the element at the given index
/// </summary>
// private void Heapify(int index)
// {
//     var current = index;

//     if (GetLeftChildIndex(index) < Count
//         && Compare(Heap[GetLeftChildIndex(index)], Heap[current]) < 0)
//     {
//         current = GetLeftChildIndex(index);
//     }

//     if (GetRightChildIndex(index) < Count
//         && Compare(Heap[GetRightChildIndex(index)], Heap[current]) < 0)
//     {
//         current = GetRightChildIndex(index);
//     }

//     if (current != index)
//     {
//         Swap(index, current);
//         Heapify(current);
//     }
// }
