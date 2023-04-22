namespace Sdde.Collections.Generic;

public interface ISinglyLinkedList<T> : IEnumerable<T>
{
    ISinglyNode<T>? First { get; }
    int Count { get; }
    void AddAfter(ISinglyNode<T> node, T input);
    void AddAfter(ISinglyNode<T> node, ISinglyNode<T> input);
    void AddFirst(T input);
    void AddFirst(ISinglyNode<T> input);
    void AddLast(T input);
    void AddLast(ISinglyNode<T> input);
    bool Contains(T input);
    ISinglyNode<T>? Find(T input);
    ISinglyNode<T>? FindLast(T input);
    bool Remove(T input);
    void Remove(ISinglyNode<T> input);
    bool RemoveAll(T input);
    void RemoveFirst();
    void RemoveLast();
    void Clear();
    void Reverse();
    void Merge(ISinglyLinkedList<T> input);
    void Merge(IEnumerable<T> input);
}
