namespace Sdde.Collections.Generic;


public class PriorityQueueNodeComparer<T> : IComparer<Tuple<T>>
{
    public IComparer<T> Source { get; private set; }
    
    public PriorityQueueNodeComparer(IComparer<T> source)
    {
        this.Source = source??Comparer<T>.Default;
    }

    public int Compare(Tuple<T> x, Tuple<T> y)
    {
        return Source.Compare(x.Item1, y.Item1);
    }
}
