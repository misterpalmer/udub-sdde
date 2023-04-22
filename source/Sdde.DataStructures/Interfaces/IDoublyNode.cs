namespace Sdde.Collections.Generic;

public interface IDoublyNode<T>
{
    T Data { get; set; }
    IDoublyNode<T>? Previous { get; set; }
    IDoublyNode<T>? Next { get; set; }
}
