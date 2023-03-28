using System;
using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public class SinglyLinkedList<T> : ISinglyLinkedList<T> //where T : class
{
    private ISinglyNode<T>? _head;
    private ISinglyNode<T>? _tail;
    private ISinglyNode<T>? _current;
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
    public ISinglyNode<T> First
    {
        get => _head!;
        private set
        {
            _head = value;
        }
    }
    public ISinglyNode<T> Last
    {
        get => _tail!;
        private set
        {
            _tail = value;
        }
    }
    public ISinglyNode<T> Current
    {
        get => _current!;
        private set => _current = value;
    }
    public ISinglyNode<T> Next => _current!.Next!;
    
    // create method to get by [index]
    // create method to Sort with Property IsSorted
    // create property for IsCircular???

    public SinglyLinkedList()
    {
        _count = 0;
    }

    public SinglyLinkedList(ISinglyNode<T> input)
    {
        _head = _tail = _current = input;
        Count++;
    }

    public SinglyLinkedList(T input) : this(new SinglyNode<T>(input))
    {
        // nothing
    }

    public SinglyLinkedList(IEnumerable<T> input)
    {
        if (input == null) throw new ArgumentNullException($"{nameof(input)} must contain a non-null value.");

        foreach(var element in input)
        {
            var node = new SinglyNode<T>(element);
            AddLast(element);
        }
    }

    public void AddAfter(ISinglyNode<T> node, T input)
    {
        AddAfter(node, new SinglyNode<T>(input));
    }

    public void AddAfter(ISinglyNode<T> node, ISinglyNode<T> input)
    {
        if (AddValidation(node, input))
        {
            input.Next = Current.Next;
            Current.Next = input;
            Count++;
        }
    }

    public void AddFirst(T input)
    {
        AddFirst(new SinglyNode<T>(input));
    }

    public void AddFirst(ISinglyNode<T> input)
    {
        // validate it does not belong to a list
        if (!IsLinked(input))
        {
            if (First is not null)
            {
                input.Next = First;
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
        AddLast(new SinglyNode<T>(input));
    }

    public void AddLast(ISinglyNode<T> input)
    {
        if (!IsLinked(input))
        {
            if(First is not null)
            {
                Last.Next = input;
                Last = Last.Next;
            }
            else
            {
                Current = First = Last = input;
            }

            Count++;
        }
    }

    // move support for LINQ Extension
    public bool Contains(T input)
    {
        if (Find(input) is not null) return true;
        return false;
    }

    public ISinglyNode<T>? Find(T input)
    {
        if (First is null) return null;

        // Node<T>(T input) checks for null input, throws exception
        Current = First;
        while(Current is not null)
        {
            if(Current.Data!.Equals(input))
            {
                return Current;
            }
            Current = Current.Next;
        }
        return null;
        return Find(new SinglyNode<T>(input));
    }

    public ISinglyNode<T>? Find(ISinglyNode<T> input)
    {
        if (First is null) return null;
        
        Current = First;
        while(Current is not null)
        {
            if(Current.Equals(input))
            {
                return Current;
            }
            Current = Current.Next;
        }
        return null;
    }

    public ISinglyNode<T>? FindLast(T input)
    {
        Current = First;
        
        if (Current is null || Current.Data is null) return null;
        // Node<T>(T input) checks for null input, throws exception
        ISinglyNode<T> value = new SinglyNode<T>(input);
        ISinglyNode<T>? node = null;
        while(Current is not null)
        {
            if(Current.Data.Equals(value.Data))
            {
                node = Current;
            }
            _current = Current.Next;
        }
        return node;
    }

    public bool Remove(T input)
    {
        if (First is null) return false;
        if (Equals(First.Data, input))
        {
            First = First.Next;
            return false;
        }
        
        Current = First;
        while (Current is not null)
        {
            if (Equals(Current.Data, input))
            {
                Current = Current.Next!;
                Count--;
                return true;
            }
            
            _current = Current.Next;
        }

        return false;
    }

    // need to check previous/next
    // must exist in LinkedList
    public void Remove(ISinglyNode<T> input)
    {
        if (First is null) return;
        if (Equals(First, input))
        {
            First = First.Next;
            return;
        }
        
        Current = First;
        while (Current is not null)
        {
            if (Equals(Current, input))
            {
                Current = Current.Next;
                Count--;
                return;
            }
            
            _current = Current.Next;
        }
    }

    public bool RemoveAll(T input)
    {
        bool found = false;

        Current = First;
        while(!Equals(Current, Last) || Current is not null)
        {
            if (Equals(Current.Data, input))
            {
                Current = Current.Next;
                Count--;
                found = true;
            }
            
            _current = Current.Next;
        }

        return found;
    }
    
    public void RemoveFirst()
    {
        First = First.Next!;
        Count--;
    }

    public void RemoveLast()
    {
        if (First is null) return;

        if (First.Next is null)
        {
            First = Last = Current = null;
            Count = 0;
            return;
        }
        
        Current = First;
        while(Current.Next is not null)
        {
            Last = Current;
            Current = Current.Next;
        }
        Last.Next = null;
        Count--;
    }

    public void Clear()
    {
        _head = _tail = _current = null;
        _count = 0;
    }
    
    public void Merge(ISinglyLinkedList<T> input)
    {
        throw new NotImplementedException();
    }

    public void Merge(IEnumerable<T> input)
    {
        throw new NotImplementedException();
    }

    public void Reverse()
    {
        ISinglyNode<T> node = Last;
    }

    private bool AddValidation(ISinglyNode<T> node, ISinglyNode<T> input)
    {
        if (!Exists(node))
        {
            const string Message = $"{nameof(node)} must belong to this LinkedList.";
            throw new InvalidOperationException(Message);
        }

        if (IsLinked(input))
        {
            const string Message1 = $"{nameof(input)} must not be linked to another node.";
            throw new InvalidOperationException(Message1);
        }

        return true;
    }

    // fix
    private void RemoveValidation(ISinglyNode<T> input)
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
        return new SinglyLinkedListEnumerator<T>(_head!);
    }

    private bool Exists(ISinglyNode<T> input)
    {
        var exists = false;
        ISinglyNode<T> node = First;
        while(!exists)
        {
            if (node.Equals(input))
            {
                Current = node;
                return true;
            }
            node = node.Next!;
        }
        return false;
    }

    private bool IsLinked(ISinglyNode<T> input)
    {
        if (input.Next is null) return false;
        
        return (input.Next is not null);
    }

}
