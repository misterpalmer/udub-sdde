using System;

namespace Sdde.Collections.Generic;

public class SinglyNode<T> : ISinglyNode<T>
{
    public T Data { get; set; }
    private ISinglyNode<T>? _next;

    public SinglyNode(T input)
    {
        if (input is null) throw new ArgumentNullException($"{nameof(input)} must contain non-null value.");

        Data = input;
    }

    public ISinglyNode<T>? Next
    {
        get
        {
            return _next;
        }
        set
        {
            _next = value;
        }
    }
}