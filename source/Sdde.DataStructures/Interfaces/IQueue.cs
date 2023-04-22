namespace Sdde.Interfaces;

// public interface IQueue<T> : ICollection<T> where T : IComparable<T>
public interface IQueue<T> : IEnumerable<T>
{
    bool IsEmpty { get; }
    int Count { get; }
    T Peek();
    T Dequeue();
    void Enqueue(T item);
    bool Contains(T item);
    void Clear();
}
