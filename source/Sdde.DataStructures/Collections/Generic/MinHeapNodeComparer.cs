namespace Sdde.Collections.Generic;

public class MinHeapNodeComparer<T> : MinMaxHeapNodeComparer<T> where T : IComparable<T>
{
    public static new MinHeapNodeComparer<T> Comparer { get; } = new();

    public override int Compare(T? left, T? right)
    {
        var result = left!.CompareTo(right!);
        return result;
    }
}
