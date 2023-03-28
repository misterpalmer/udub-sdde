using System.Collections;
using System.Collections.Generic;

namespace Sdde.Collections.Generic;

public interface IStack<T>
{
    void Clear();
    bool Contains(T item);
    void CopyTo(T[] array, int arrayIndex);
    int EnsureCapacity(int capacity);
    T Peek();
    T Pop();
    void Push(T item);
    T[] ToArray();
    void TrimExcess();
    bool TryPeek(out T result);
    bool TryPop(out T result);
}