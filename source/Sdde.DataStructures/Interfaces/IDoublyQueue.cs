namespace Sdde.Interfaces;

public interface IDoublyQueue<T> : IQueue<T>
{
    T PeekLast();
    T DequeueLast();
}
