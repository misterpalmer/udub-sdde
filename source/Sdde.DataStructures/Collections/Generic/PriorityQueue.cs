using System.Collections;

namespace Sdde.Collections.Generic;

public class PriorityQueue<TItem, TPriority> : IEnumerable<TItem>
{
    private readonly IComparer<Tuple<TPriority>>? _comparer;
    private readonly Func<TItem, TPriority> PriorityGetter;


    public PriorityQueue(Func<TItem, TPriority> priority, IEnumerable<TItem>? items = null,
        IComparer<TPriority>? comparer = null)
    {
        PriorityGetter = priority;
        _comparer = new PriorityQueueNodeComparer<TPriority>(comparer!) ?? null;
        Data = new SortedDictionary<Tuple<TPriority>, Queue<TItem>>(_comparer);
        EnqueueRange(items!);
    }

    public int Count => Data.Count;
    public bool IsEmpty => Data.Count == 0;
    public SortedDictionary<Tuple<TPriority>, Queue<TItem>> Data { get; }

    public IEnumerator<TItem> GetEnumerator()
    {
        return (IEnumerator<TItem>) from kvp in Data
            from item in kvp.Value
            select item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private Tuple<TPriority> T(TPriority priority)
    {
        return Tuple.Create(priority);
    }


    public TItem Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("The queue is empty");
        return Data.First().Value.Peek();
    }

    public void Enqueue(TItem item)
    {
        Queue<TItem>? queue = null;
        var key = T(PriorityGetter(item));

        if (!Data.TryGetValue(key, out queue))
        {
            queue = new Queue<TItem>();
            Data.Add(key, queue);
        }

        queue.Enqueue(item);
    }

    public void EnqueueRange(IEnumerable<TItem> items)
    {
        foreach (var item in items ?? Enumerable.Empty<TItem>())
            Enqueue(item);
    }

    public TItem Dequeue()
    {
        var head = Data.First();
        var result = head.Value.Dequeue();
        if (head.Value.Count == 0) Data.Remove(head.Key);
        return result;
    }

    public bool Contains(TItem item)
    {
        return Data.Any(kvp => kvp.Value.Contains(item));
    }

    public void Clear()
    {
        Data.Clear();
    }
}

public static class PriorityQueue
{
    public static PriorityQueue<T, TPriority> Create<T, TPriority>(Func<T, TPriority> priority, IEnumerable<T> items,
        IComparer<TPriority>? comparer = null)
    {
        return new PriorityQueue<T, TPriority>(priority, items, comparer);
    }
}
