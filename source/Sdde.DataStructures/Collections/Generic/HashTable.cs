using System.Collections;
using System.Runtime.Serialization;

namespace Sdde.Collections.Generic;

public class HashTable<T> : ICollection<T>,
    IEnumerable<T>,
    IReadOnlyCollection<T>,
    IReadOnlySet<T>,
    ISet<T>,
    IDeserializationCallback,
    ISerializable
{
    private int _count;

    int ICollection<T>.Count => _count;
    public bool IsReadOnly { get; }


    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    bool ICollection<T>.Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        _count--;
        return true;
    }

    public void OnDeserialization(object? sender)
    {
        throw new NotImplementedException();
    }

    int IReadOnlyCollection<T>.Count => _count;

    bool IReadOnlySet<T>.IsProperSubsetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool IReadOnlySet<T>.IsProperSupersetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool IReadOnlySet<T>.IsSubsetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool IReadOnlySet<T>.IsSupersetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool IReadOnlySet<T>.Overlaps(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool IReadOnlySet<T>.SetEquals(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool IReadOnlySet<T>.Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.IsProperSubsetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.IsProperSupersetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.IsSubsetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.IsSupersetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.Overlaps(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.SetEquals(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void UnionWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    bool ISet<T>.Add(T item)
    {
        throw new NotImplementedException();
    }

    public bool Add(T item)
    {
        _count++;
        return true;
    }
}
