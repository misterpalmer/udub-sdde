namespace Sdde.Collections.Generic;

public class MaxHeapNodeComparer<T> : MinMaxHeapNodeComparer<T> where T : IComparable<T>
{
    public static new MaxHeapNodeComparer<T> Comparer { get; } = new();

    public override int Compare(T? left, T? right)
    {
        var result = right!.CompareTo(left!);
        return result;
    }
}
