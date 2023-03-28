using System;
using System.Collections;

namespace Sdde.Collections.Generic;

public class SinglyLinkedList<T> : ISinglyLinkedList<T> //where T : class
{
    private ISinglyNode<T>? _head;
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

    public SinglyLinkedList()
    {
        _count = 0;
    }

    public SinglyLinkedList(ISinglyNode<T> input)
    {
        _head = input;
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
            AddLast(new SinglyNode<T>(element));
        }
    }

    public void AddAfter(ISinglyNode<T> node, T input)
    {
        AddAfter(node, new SinglyNode<T>(input));
    }

    public void AddAfter(ISinglyNode<T> node, ISinglyNode<T> input)
    {
        ISinglyNode<T> current = First;
        if (AddValidation(node, input))
        {
            input.Next = current.Next;
            current.Next = input;
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
        if (IsLinked(input)) return;
        if (First is null)
        {
            First = input;
            Count++;
            return;
        }
        
        input.Next = First;
        First = input;
        Count++;
    }

    public void AddLast(T input)
    {
        AddLast(new SinglyNode<T>(input));
    }

    public void AddLast(ISinglyNode<T> input)
    {
        // validate it does not belong to a list
        if (IsLinked(input)) return;
        if (First is null)
        {
            First = input;
            Count++;
            return;
        }
        
        ISinglyNode<T> current = First;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        
        current.Next = input;
        Count++;
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
        ISinglyNode<T> current = First;
        while(current is not null)
        {
            if(current.Data!.Equals(input))
            {
                return current;
            }
            current = current.Next!;
        }
        return null;
    }

    public ISinglyNode<T>? Find(ISinglyNode<T> input)
    {
        if (First is null) return null;
        
        ISinglyNode<T> current = First;
        while(current is not null)
        {
            if(current.Equals(input))
            {
                return current;
            }
            current = current.Next!;
        }
        return null;
    }

    public ISinglyNode<T>? FindLast(T input)
    {
        if (First is null) return null;
        
        // Node<T>(T input) checks for null input, throws exception
        ISinglyNode<T> value = new SinglyNode<T>(input);
        ISinglyNode<T> current = First;
        ISinglyNode<T>? node = null;
        while(current is not null)
        {
            if(Equals(current.Data, value.Data))
            {
                node = current;
            }
            current = current.Next!;
        }
        return node;
    }

    public bool Remove(T input)
    {
        if (First is null) return false;
        
        if (Equals(First.Data, input))
        {
            First = Find(First)!.Next!;
            Count--;
            return true;
        }
        
        ISinglyNode<T> current = First;
        while (current.Next is not null)
        {
            if (Equals(current.Next!.Data, input))
            {
                current.Next = Find(current.Next)!.Next;
                Count--;
                return true;
            }
            
            current = current.Next!;
        }

        return true;
    }
    
    public void Remove(ISinglyNode<T> input)
    {
        if (First is null) return;

        if (Equals(First, input))
        {
            First = input.Next!;
            Count--;
            return;
        }
        
        ISinglyNode<T> current = First;
        while (current is not null)
        {
            if (Equals(current.Next, input))
            {
                current.Next = input.Next!;
                Count--;
                return;
            }
            current = current.Next!;
        }
    }

    public bool RemoveAll(T input)
    {
        if (First is null) return false;
        
        bool found = false;
        if (Equals(First.Data, input))
        {
            First = Find(First)!.Next!;
            Count--;
            found = true;
            if (First is null) return found;
        }
        
        ISinglyNode<T>? current = First;
        while(current.Next! is not null)
        {
            if (Equals(current.Next!.Data, input))
            {
                current.Next = Find(current.Next)!.Next;
                Count--;
                found = true;
            }
            
            current = current.Next!;
            if (current is null) return found;
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
            First = default!;
            Count = 0;
            return;
        }
        
        ISinglyNode<T> previous = First;
        ISinglyNode<T> current = First;
        while(current.Next is not null)
        {
            previous = current;
            current = current.Next;
        }
        previous.Next = null;
        Count--;
    }

    public void Clear()
    {
        First = default!;
        Count = 0;
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
        ISinglyNode<T> node = First;
    }

    private bool AddValidation(ISinglyNode<T> node, ISinglyNode<T> input)
    {
        if (!Exists(node))
        {
            const string message = $"{nameof(node)} must belong to this LinkedList.";
            throw new InvalidOperationException(message);
        }

        if (IsLinked(input))
        {
            const string message = $"{nameof(input)} must not be linked to another node.";
            throw new InvalidOperationException(message);
        }

        return true;
    }

    // fix
    private void RemoveValidation(ISinglyNode<T> input)
    {
        if (!Exists(input))
        {
            const string message = $"{nameof(input)} must belong to this LinkedList.";
            throw new InvalidOperationException(message);
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
        if (First is null) return false;
        
        ISinglyNode<T> current = First;
        while(current is not null)
        {
            if (current.Equals(input))
            {
                return true;
            }
            current = current.Next!;
        }
        return false;
    }

    private bool IsLinked(ISinglyNode<T> node)
    {
        if (node.Next is null) return false;
        return (node.Next is not null);
    }

}
