using System;
using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public class DoublyLinkedList<T> : IDoublyLinkedList<T> //where T : class
{
    private IDoublyNode<T>? _head;
    private IDoublyNode<T>? _tail;
    private IDoublyNode<T>? _current;
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
    public IDoublyNode<T> First
    {
        get => _head!;
        private set
        {
            _head = value;
        }
    }
    public IDoublyNode<T> Last
    {
        get => _tail!;
        private set
        {
            _tail = value;
        }
    }
    public IDoublyNode<T> Current
    {
        get => _current!;
        private set => _current = value;
    }
    public IDoublyNode<T> Previous => _current!.Previous!;
    public IDoublyNode<T> Next => _current!.Next!;
    

    // create method to get by [index]
    // create method to Sort with Property IsSorted
    // create property for IsCircular???

    public DoublyLinkedList()
    {
        _count = 0;
    }

    public DoublyLinkedList(IDoublyNode<T> input)
    {
        _head = input;
        _tail = input;
        _current = input;
        Count = 1;
    }

    public DoublyLinkedList(T input) : this(new DoublyNode<T>(input))
    {
        // nothing
    }

    public DoublyLinkedList(IEnumerable<T> input)
    {
        if (input == null) throw new ArgumentNullException($"{nameof(input)} must contain a non-null value.");

        foreach(var element in input)
        {
            var node = new DoublyNode<T>(element);
            AddLast(element);
        }
    }

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
        // validate it does not belong to a list
        if (!IsLinked(input))
        {
            if (First is not null)
            {
                // IDoublyNode<T> previous = First;
                input.Next = First;
                First.Previous = input;
                First = input;
            }
            else
            {
                Current = First = Last = input;
            }
            Count++;
        }
    }

    public void AddLast(T input)
    {
        AddLast(new DoublyNode<T>(input));
    }

    public void AddLast(IDoublyNode<T> input)
    {
        if (!IsLinked(input))
        {
            if (First is not null)
            {
                Last.Next = input;
                input.Previous = Last;
                Last = input;
            }
            else
            {
                Current = First = Last = input;
            }
        }
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
        while(Current is not null)
        {
            if(Current.Data.Equals(value.Data))
            {
                return Current;
            }
            _current = Current.Next;
        }
        return null;
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
        while(Current is not null)
        {
            if(Current.Equals(input))
            {
                return Current;
            }
            _current = Current.Next;
        }
        return null;
    }

    public IDoublyNode<T>? FindLast(T input)
    {
        // Node<T>(T input) checks for null input, throws exception
        IDoublyNode<T> value = new DoublyNode<T>(input);
        Current = Last;
        
        if (Current is null || Current.Data is null) return null;
        while(Current is not null)
        {
            if(Current.Data.Equals(value.Data))
            {
                return Current;
            }
            _current = Current.Previous;
        }
        return null;
    }

    public bool Remove(T input)
    {
        IDoublyNode<T>? node = Find(input);

        if (node is null)
        {
            return false;
        }
        
        // Node<T>(T input) checks for null input, throws exception
        // Previous/Next not instantiated to null
        // null check not necessary
        IDoublyNode<T> previous = node.Previous!;
        IDoublyNode<T> next = node.Next!;

        Previous.Next = next;
        Next.Previous = previous;
        Count--;
        return true;
    }

    // need to check previous/next
    // must exist in LinkedList
    public void Remove(IDoublyNode<T> input)
    {
        IDoublyNode<T>? node = Find(input);

        if (node is not null)
        {
            // Node<T>(T input) checks for null input, throws exception
            // Previous/Next not instantiated to null
            // null check not necessary
            IDoublyNode<T> previous = node.Previous!;
            IDoublyNode<T> next = node.Next!;

            Previous.Next = next;
            Next.Previous = previous;
            Count--;
        }
    }

    public bool RemoveAll(T input)
    {
        Current = First;
        bool found = false;

        while(Current != Last || Current is not null)
        {
            found = Remove(input);
            _current = Current.Next;
        }

        return found;
    }
    
    public void RemoveFirst()
    {
        _head = First.Next;
        First.Previous = Last;
        Last.Next = First;
        Count--;
    }

    public void RemoveLast()
    {
        _tail = Last.Previous;
        Last.Next = First;
        First.Previous = Last;
        Count--;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _current = null;
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
        IDoublyNode<T> node = Last;
    }

    private void AddValidation(IDoublyNode<T> node, IDoublyNode<T> input)
    {
        if (!Exists(node))
        {
            const string Message = $"{nameof(node)} must belong to this LinkedList.";
            throw new InvalidOperationException(Message);
        }

        if (IsLinked(input))
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

    public IEnumerator<T> GetEnumerator()
    {
        var node = _head;
        while(node is not null)
        {
            yield return node.Data!;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new DoublyLinkedListEnumerator<T>(_head!);
    }

    private bool Exists(IDoublyNode<T> input)
    {
        var exists = false;
        IDoublyNode<T> node = First;
        while(!exists)
        {
            if (node.Equals(input)) return true;
            if(node.Equals(_tail)) return false;

            node = node.Next!;
        }
        return false;
    }

    private bool IsLinked(IDoublyNode<T> input)
    {
        if (input.Previous is null && input.Next is null) return false;
        
        return (input.Previous is not null && input.Next is not null);
    }

}

