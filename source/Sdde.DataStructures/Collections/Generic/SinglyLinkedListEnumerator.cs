using System.Collections;

namespace Sdde.Collections.Generic;

public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
{
    private ISinglyNode<T> _current;
    private readonly ISinglyNode<T> _head;

    public SinglyLinkedListEnumerator(ISinglyNode<T> input)
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
