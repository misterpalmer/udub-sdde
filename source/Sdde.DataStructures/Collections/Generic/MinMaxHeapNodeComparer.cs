namespace Sdde.Collections.Generic;

public class MinMaxHeapNodeComparer<T> : Comparer<T> where T : IComparable<T>
{
    public static MinMaxHeapNodeComparer<T> Comparer { get; } = new();

    public override int Compare(T? left, T? right)
    {
        var result = left!.CompareTo(right!);
        return result;
    }
}
