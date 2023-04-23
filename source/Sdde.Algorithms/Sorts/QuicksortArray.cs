namespace Sdde.Algorithms.Sorts;

public class QuicksortArray
{
    public static void Execute<T>(T[] array, PivotMethod pivotMethod) where T : IComparable<T>
    {
        Sort<T>(array, 0, array.Length - 1, pivotMethod);
    }

    private static void Sort<T>(T[] array, int left, int right, PivotMethod pivotMethod) where T : IComparable<T>
    {
        if (left.CompareTo(right) >= 0) return;

        // var start = left;
        // var end = right;

        int pivotIndex = PickAPivotIndex(left, right, pivotMethod);
        (var start, var end) = Partition(array, left, right, pivotIndex);

        // Sort(array, left, start - 1, pivotMethod);
        // Sort(array, start, right, pivotMethod);

        if (left < end)
        {
            Sort(array, left, end, pivotMethod);
        }

        if (start < right)
        {
            Sort(array, start, right, pivotMethod);
        }

    }

    private static (int, int) Partition<T>(T[] array, int start, int end, int pivotIndex) where T : IComparable<T>
    {
        T pivotValue = array[pivotIndex];
        // obvious tweak
        if (array[start].CompareTo(array[end]) == 1) Swap(ref array[start], ref array[end]);
        while (start < end)
        {
            // T pivotValue = array[pivotIndex];
            while (array[start].CompareTo(pivotValue) == -1) start++;
            while (array[end].CompareTo(pivotValue) == 1) end--;
            if (start <= end) Swap(ref array[start++], ref array[end--]);
        }

        return (start, end);
    }

    public static void Swap<T>(ref T left, ref T right)
    {
        var temp = left;
        left = right;
        right = temp;
    }

    private static int PickAPivotIndex(int left, int right, PivotMethod pivotMethod)
    {
        int pivot;
        int length = right - left + 1;

        switch (pivotMethod)
        {
            case PivotMethod.Left:
                pivot = left;
                break;
            case PivotMethod.Right:
                pivot = right;
                break;
            case PivotMethod.Middle:
                pivot = length / 2;
                pivot = (left + right) / 2;
                break;
            case PivotMethod.Random:
                pivot =  new Random(DateTime.UtcNow.DayOfYear) .Next(left, right);
                break;
            case PivotMethod.BitShift:
                pivot =  (left + right) >> 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(pivotMethod), pivotMethod, null);
        }

        return pivot;
    }

    public enum PivotMethod
    {
        Left,
        Right,
        Middle,
        Random,
        BitShift
    }
}
