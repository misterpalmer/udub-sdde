using System.Collections;

namespace Sdde.Collections.Generic;

public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
{
    private IDoublyNode<T> _current;
    private readonly IDoublyNode<T> _head;

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
        return _current is not null;
    }

    public void Reset()
    {
        _current = _head;
    }
}
