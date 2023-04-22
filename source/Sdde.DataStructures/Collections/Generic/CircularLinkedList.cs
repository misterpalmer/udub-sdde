using System.Collections;

namespace Sdde.Collections.Generic;

public class CircularLinkedList<T> : IDoublyLinkedList<T> //where T : class
{
    private int _count;


    // create method to get by [index]
    // create method to Sort with Property IsSorted
    // create property for IsCircular???

    public CircularLinkedList()
    {
    }

    public CircularLinkedList(IDoublyNode<T> input)
    {
        First = input;
        Last = input;
        Current = input;
        Count++;
    }

    public CircularLinkedList(T input) : this(new DoublyNode<T>(input))
    {
        // nothing
    }

    public CircularLinkedList(IEnumerable<T> input)
    {
        if (input == null) throw new ArgumentNullException($"{nameof(input)} must contain a non-null value.");

        foreach (var element in input)
        {
            var node = new DoublyNode<T>(element);
            AddLast(element);
        }
    }

    public int Count
    {
        get
        {
            if (_count < 0) _count = 0;
            return _count;
        }
        private set => _count = value;
    }

    public IDoublyNode<T> First { get; private set; }

    public IDoublyNode<T> Last { get; private set; }

    public IDoublyNode<T> Current { get; private set; }

    public IDoublyNode<T> Previous => Current!.Previous!;
    public IDoublyNode<T> Next => Current!.Next!;

    public void AddAfter(IDoublyNode<T> node, T input)
    {
        AddAfter(node, new DoublyNode<T>(input));
    }

    public void AddAfter(IDoublyNode<T> node, IDoublyNode<T> input)
    {
        AddValidation(node, input);
        Count++;
    }

    public void AddBefore(IDoublyNode<T> node, T input)
    {
        AddBefore(new DoublyNode<T>(input), node);
    }

    public void AddBefore(IDoublyNode<T> node, IDoublyNode<T> input)
    {
        AddValidation(node, input);
        Count++;
    }

    public void AddFirst(T input)
    {
        AddFirst(new DoublyNode<T>(input));
    }

    public void AddFirst(IDoublyNode<T> input)
    {
        if (!NotExists(input))
        {
            const string Message = $"{nameof(input)} must not belong to another LinkedList.";
            throw new InvalidOperationException(Message);
        }

        var node = First!;
        First = input;

        Count++;
    }

    public void AddLast(T input)
    {
        IDoublyNode<T> node = new DoublyNode<T>(input)!;
        AddLast(node);
    }

    public void AddLast(IDoublyNode<T> input)
    {
        var node = Last!;
        Last!.Next = input;
        Last.Next = node.Previous;
        First!.Previous = Last;
        Count++;
    }

    // move support for LINQ Extension
    public bool Contains(T input)
    {
        if (Find(input) != null) return true;
        return false;
    }

    public IDoublyNode<T>? Find(T input)
    {
        // Node<T>(T input) checks for null input, throws exception
        IDoublyNode<T> value = new DoublyNode<T>(input);
        Current = First;

        if (Current is null || Current.Data is null) return null;
        while (Current is not null)
        {
            if (Current.Data.Equals(value.Data)) return Current;
            Current = Current.Next;
        }

        return null;
    }

    public IDoublyNode<T>? FindLast(T input)
    {
        // Node<T>(T input) checks for null input, throws exception
        IDoublyNode<T> value = new DoublyNode<T>(input);
        Current = Last;

        if (Current is null || Current.Data is null) return null;
        while (Current is not null)
        {
            if (Current.Data.Equals(value.Data)) return Current;
            Current = Current.Previous;
        }

        return null;
    }

    public bool Remove(T input)
    {
        var node = Find(input);

        if (node is null) return false;

        // Node<T>(T input) checks for null input, throws exception
        // Previous/Next not instantiated to null
        // null check not necessary
        var previous = node.Previous!;
        var next = node.Next!;

        Previous.Next = next;
        Next.Previous = previous;
        Count--;
        return true;
    }

    // need to check previous/next
    // must exist in LinkedList
    public void Remove(IDoublyNode<T> input)
    {
        var node = Find(input);

        if (node is not null)
        {
            // Node<T>(T input) checks for null input, throws exception
            // Previous/Next not instantiated to null
            // null check not necessary
            var previous = node.Previous!;
            var next = node.Next!;

            Previous.Next = next;
            Next.Previous = previous;
            Count--;
        }
    }

    public bool RemoveAll(T input)
    {
        Current = First;
        var found = false;

        while (Current != Last || Current is not null)
        {
            found = Remove(input);
            Current = Current.Next;
        }

        return found;
    }

    public void RemoveFirst()
    {
        First = First.Next;
        First.Previous = Last;
        Last.Next = First;
        Count--;
    }

    public void RemoveLast()
    {
        Last = Last.Previous;
        Last.Next = First;
        First.Previous = Last;
        Count--;
    }

    public void Clear()
    {
        First = null;
        Last = null;
        Current = null;
        _count = 0;
    }

    public void Merge(IDoublyLinkedList<T> input)
    {
        throw new NotImplementedException();
    }

    public void Merge(IEnumerable<T> input)
    {
        throw new NotImplementedException();
    }

    public void Reverse()
    {
        var node = Last;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = First;
        while (node is not null)
        {
            yield return node.Data!;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new DoublyLinkedListEnumerator<T>(First!);
    }

    // private IDoublyNode<T> Find(IDoublyNode<T> input)
    // {
    //     if (Current is null || Current.Data is null) return null;
    //     while(Current is not null)
    //     {
    //         if(Current.Data.Equals(value.Data))
    //         {
    //             return Current;
    //         }
    //         _current = Current.Next;
    //     }
    //     return null;
    // }

    // this should be a reference equals
    public IDoublyNode<T>? Find(IDoublyNode<T> input)
    {
        Current = First;

        if (Current is null || Current.Data is null) return null;
        while (Current is not null)
        {
            if (Current.Equals(input)) return Current;
            Current = Current.Next;
        }

        return null;
    }

    private void AddValidation(IDoublyNode<T> node, IDoublyNode<T> input)
    {
        if (!Exists(node))
        {
            const string Message = $"{nameof(node)} must belong to this LinkedList.";
            throw new InvalidOperationException(Message);
        }

        if (NotExists(input))
        {
            const string Message1 = $"{nameof(input)} must not belong to another LinkedList.";
            throw new InvalidOperationException(Message1);
        }
    }

    // fix
    private void RemoveValidation(IDoublyNode<T> input)
    {
        if (!Exists(input))
        {
            const string Message1 = $"{nameof(input)} must belong to this LinkedList.";
            throw new InvalidOperationException(Message1);
        }
    }

    private bool Exists(IDoublyNode<T> input)
    {
        var exists = false;
        var node = First;
        while (!exists)
        {
            if (node.Equals(input)) return true;
            if (node.Equals(Last)) return false;

            node = node.Next!;
        }

        return false;
    }

    private bool NotExists(IDoublyNode<T> input)
    {
        if (input.Previous != null && input.Next != null) return true;
        return false;
    }
}
