using System.Collections;

namespace Sdde.Interfaces;

public interface ITree<T> : ICollection<T> where T : IComparable<T>
{
    ITreeNode<T> Root { get; }
    bool IsReadOnly { get; }
    int Count { get; }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    int GetHeight();
    int GetHeight(T item);
    int GetHeight(ITreeNode<T> node);
    int GetDepth();
    int GetDepth(T item);
    int GetDepth(ITreeNode<T> node);
    void Add(T item);
    void AddNode(ITreeNode<T> node);
    void Find(T item);
    void Remove(T item);
    void Remove(ITreeNode<T> node);
    void Clear();
    IEnumerator<T> GetEnumerator();
}
