using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdde.Interfaces;

public interface ITree<T> : ICollection<T> where T : IComparable<T>
{
    ITreeNode<T> Root { get; }
    bool IsReadOnly { get; }
    int Count { get; }
    int GetHeight();
    int GetHeight (T item);
    int GetHeight (ITreeNode<T> node);
    int GetDepth();
    int GetDepth (T item);
    int GetDepth (ITreeNode<T> node);
    void Add(T item);
    void AddNode(ITreeNode<T> node);
    void Find(T item);
    void Remove(T item);
    void Remove(ITreeNode<T> node);
    void Clear();
    IEnumerator<T> GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
