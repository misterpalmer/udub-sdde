using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public class ArrayStack<T> : IStack<T>, IEnumerable<T>, IReadOnlyCollection<T>, ICollection
{
    private const int MaxArrayLength = 256 * 2;
    private const int DefaultCapacity = 128 * 1;
    private readonly double LoadFactor = 0.9;

    private T[] _items;
    private T[] Items
    {
        get
        {
            return _items ?? new T[DefaultCapacity];
        }
        set
        {
            if(value is null) _items = new T[DefaultCapacity];
            _items = value;
        }
    }
    private int _size;
    public int Capacity 
    { 
        get { return _size; }
        private set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(Capacity));
            if (value > MaxArrayLength) throw new OutOfMemoryException(nameof(Capacity));
            if(_size < value) _size = value;
        }
    }
    private int _count;
    public int Count
    {
        get
        {
            if (_count < 0)
            {
                _count = 0;
            }
            return _count;
        }
        private set { _count = value;}
    }
    
    public bool IsEmpty => Count == 0;
    public bool IsSynchronized => throw new NotImplementedException();
    public object SyncRoot => throw new NotImplementedException();
    
    private ArrayStack(T[] items, int capacity = DefaultCapacity)
    {
        ArgumentNullException.ThrowIfNull(items);

        Capacity = capacity;
        Capacity = EnsureCapacity(capacity);
        if (Capacity > capacity)
        {
            _items = new T[Capacity];
            items.CopyTo(_items, 0);
        }
        else
        {
            _items = items;
        }
        Count = _items.Count();
    }

    public ArrayStack(T[] items) : this(items, items.Length)
    {
        
    }

    public ArrayStack() : this(DefaultCapacity)
    {
       
    }

    public ArrayStack(int capacity)
    {
        Capacity = capacity;
        _items = new T[Capacity];
        Count = 0;
    }


    public void Clear()
    {
        Items = new T[Capacity];
    }

    public bool Contains(T item)
    {
        return Items.Contains(item);
    }

    public void CopyTo(Array array, int index)
    {
        Items.CopyTo(array, index);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Items.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Ensures that the capacity of this stack is at least the given minimum value.
    /// If the current capacity of the stack is less than min,
    /// then the capacity is increased to twice the current capacity or to min, whichever is larger.
    /// </summary>
    /// <param name="min">The minimum capacity to ensure</param>
    /// <returns>The new capacity</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if min is less than 0</exception>
    /// <exception cref="OutOfMemoryException">Thrown if the required capacity is greater than <see cref="MaxArrayLength"/></exception>
    public int EnsureCapacity(int capacity)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(Capacity));
        if (capacity > MaxArrayLength) throw new OutOfMemoryException(nameof(Capacity));

        var currentLoadFactor = Count / Capacity;
        if (currentLoadFactor >= LoadFactor)
        {
            var newCapacity = Capacity * 2;
            if (newCapacity < capacity)
            {
                newCapacity = capacity;
            }
            if (newCapacity > MaxArrayLength)
            {
                newCapacity = MaxArrayLength;
            }
            Capacity = newCapacity;

            T[] temp = new T[Capacity];
            CopyTo(temp, 0);
            Items = temp;
        }

        return Capacity;
    }

    public T Peek()
    {
        T temp = Items[Count - 1];
        return temp;
    }

    public T Pop()
    {
        T temp = Items[Count - 1];
        Items[Count - 1] = default;
        Count--;
        return temp;
    }

    public void Push(T item)
    {
        Items[Count++] = item;
        EnsureCapacity(Count);
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    public void TrimExcess()
    {
        throw new NotImplementedException();
    }

    public bool TryPeek(out T result)
    {
        throw new NotImplementedException();
    }

    public bool TryPop(out T result)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        var data = Items;
        for (int index = --Count; index >= 0; index--)
        {
            yield return data[index];
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}