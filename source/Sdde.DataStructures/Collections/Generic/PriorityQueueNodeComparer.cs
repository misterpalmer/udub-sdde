namespace Sdde.Collections.Generic;

public class PriorityQueueNodeComparer<T> : IComparer<Tuple<T>>
{
    public PriorityQueueNodeComparer(IComparer<T> source)
    {
        Source = source ?? Comparer<T>.Default;
    }

    public IComparer<T> Source { get; }

    public int Compare(Tuple<T>? x, Tuple<T>? y)
    {
        return Source.Compare(x!.Item1, y!.Item1);
    }
}
