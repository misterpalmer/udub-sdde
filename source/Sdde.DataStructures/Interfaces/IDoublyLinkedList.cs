using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public interface IDoublyLinkedList<T> : IEnumerable<T>
{
    IDoublyNode<T>? First { get; }
    IDoublyNode<T>? Last { get; }
    IDoublyNode<T>? Current { get; }
    IDoublyNode<T>? Previous { get; }
    IDoublyNode<T>? Next { get; }
    int Count { get; }
    void AddAfter(IDoublyNode<T> node, T input);
    void AddAfter(IDoublyNode<T> node, IDoublyNode<T> input);
    void AddBefore(IDoublyNode<T> node, T input);
    void AddBefore(IDoublyNode<T> node, IDoublyNode<T> input);
    void AddFirst(T input);
    void AddFirst(IDoublyNode<T> input);
    void AddLast(T input);
    void AddLast(IDoublyNode<T> input);
    bool Contains(T input);
    IDoublyNode<T>? Find(T input);
    IDoublyNode<T>? FindLast(T input);
    bool Remove(T input);
    void Remove(IDoublyNode<T> input);
    bool RemoveAll(T input);
    void RemoveFirst();
    void RemoveLast();
    void Clear();
    void Reverse();
    void Merge(IDoublyLinkedList<T> input);
    void Merge(IEnumerable<T> input);
}