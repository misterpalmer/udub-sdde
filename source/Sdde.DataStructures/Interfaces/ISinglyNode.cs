namespace Sdde.Collections.Generic;

public interface ISinglyNode<T>
{
    T Data { get; set; }
    ISinglyNode<T>? Next { get; set; }
}
