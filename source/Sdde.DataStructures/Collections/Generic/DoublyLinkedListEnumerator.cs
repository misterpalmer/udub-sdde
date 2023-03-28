using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;


public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
{
    private IDoublyNode<T> _head;
    private IDoublyNode<T> _current;
    public DoublyLinkedListEnumerator(IDoublyNode<T> input)
    {
        _current = _head = input;
    }

    public T Current => _current.Data!;
    object IEnumerator.Current => Current!;

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        if (_current is null) return false;
        
        _current = _current.Next!;
        return (_current is not null);
    }

    public void Reset()
    {
        _current = _head;
    }
}
