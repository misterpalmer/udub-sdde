namespace Sdde.Collections.Generic;

public class SinglyNode<T> : ISinglyNode<T>
{
    public SinglyNode(T input)
    {
        if (input is null) throw new ArgumentNullException($"{nameof(input)} must contain non-null value.");

        Data = input;
    }

    public T Data { get; set; }

    public ISinglyNode<T>? Next { get; set; }
}
