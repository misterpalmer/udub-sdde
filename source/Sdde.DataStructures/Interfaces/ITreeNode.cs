namespace Sdde.Interfaces;

public interface ITreeNode<T> where T : IComparable<T>
{
    T Node { get; }
    ITree<T> Tree { get; }
    ITreeNode<T> Parent { get; }
    ITreeNode<T> LeftChild { get; }
    ITreeNode<T> RightChild { get; }
    int ChildCount { get; }
    bool IsParent { get; }
    bool IsLeftChild { get; }
    bool IsRightChild { get; }
    bool IsLeaf { get; }
    bool HasLeftChild { get; }
    bool HasRightChild { get; }
}
