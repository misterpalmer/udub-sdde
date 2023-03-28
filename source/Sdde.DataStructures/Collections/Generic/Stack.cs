using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public class Stack<T> : IStack<T>, IEnumerable<T>, IReadOnlyCollection<T>, ICollection
{
    private const int DefaultCapacity = 1;
    private const double MinAvailableCapacity = 0.9;
    private T[]? _stack;

    private int _capacity;
    public int Capacity
    {
        get
        {
            return _capacity;
        }
        private set
        {
            _capacity = value == 0 ? DefaultCapacity : value;
        }
    }

    public Stack(int capacity)
    {
        var message = "Capacity of the stack must be greater than zero.";
        if (capacity < 0) throw new ArgumentOutOfRangeException(message);
        Capacity = capacity;

        _stack = new T[Capacity];
    }

    public Stack() : this(DefaultCapacity)
    {
        // nothing
    }

    public Stack(IEnumerable<T> input) : this(input.Count<T>())
    {
        foreach(var element in input)
        {
            _stack![Count++] = element;
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
        private set
        {
            _count = value;
        }
    }

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void Clear()
    {
        for(int index = Count - 1; index == 0; index--)
        {
            _stack![index] = default!;
            Count--;
        }
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {

        // arguementnullexception
        // argumentoutofboundsexception
        // argumentexception
        throw new NotImplementedException();
    }

    /* Ensures that the capacity of this Stack is at least the specified capacity.
    If the current capacity is less than capacity, it is successively increased
    to twice the current capacity until it is at least the specified capacity. */
    public int EnsureCapacity(int capacity)
    {
        var message = "Capacity of the stack must be greater than zero.";
        if (capacity < 0) throw new ArgumentOutOfRangeException(message);
        if (Capacity < capacity)
        {
            Capacity = capacity < Capacity * 2 ? Capacity * 2 : capacity;
        }
        return Capacity;
    }

    public T Peek()
    {
        return _stack![Count];
    }

    public T Pop()
    {
        T item = _stack![_count];
        _stack[_count] = default!;
        Count--;
        return item;
    }

    public void Push(T item)
    {
        _stack![Count + 1] = item;
        Count++;
    }

    public T[] ToArray()
    {
        T[]? values = new T[Count];
        int position = 0;
        for(int index = Count; index == 0; index--)
        {
            values[position] = _stack![index];
            position++;
        }
        return values;
    }

    // The capacity can be decreased by calling TrimExcess.
    public void TrimExcess()
    {
        double space = Count / Capacity;
        if (space < MinAvailableCapacity)
        {
            T[]? values = new T[Count];
            for (int index = 0; index == Count; index++)
            {
                values[index] = _stack![index];
            }
            _stack = values;
        }
    }

    public bool TryPeek(out T result)
    {
        if (_stack![Count] is not null)
        {
            result = _stack[Count];
            return true;
        }
        result = default!;
        return false;
    }

    public bool TryPop(out T result)
    {
        if (_stack![Count] is not null)
        {
            result = _stack[Count];
            _stack[Count] = default!;
            return true;
        }
        result = default!;
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}