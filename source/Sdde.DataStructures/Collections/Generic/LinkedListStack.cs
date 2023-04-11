

using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public class LinkedListStack<T> : IStack<T>, IEnumerable<T>, IReadOnlyCollection<T>, ICollection
{
    public LinkedListStack()
    {
    }

    public int Count => throw new NotImplementedException();

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void Clear()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public int EnsureCapacity(int capacity)
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        throw new NotImplementedException();
    }

    public T Pop()
    {
        throw new NotImplementedException();
    }

    public void Push(T item)
    {
        throw new NotImplementedException();
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

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}