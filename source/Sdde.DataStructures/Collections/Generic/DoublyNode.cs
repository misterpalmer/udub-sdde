namespace Sdde.Collections.Generic;

public class DoublyNode<T> : IDoublyNode<T>
{
    public DoublyNode(T input)
    {
        if (input is null) throw new ArgumentNullException($"{nameof(input)} must contain non-null value.");

        Data = input;
    }

    public T Data { get; set; }

    public IDoublyNode<T>? Previous { get; set; }
    public IDoublyNode<T>? Next { get; set; }
}
