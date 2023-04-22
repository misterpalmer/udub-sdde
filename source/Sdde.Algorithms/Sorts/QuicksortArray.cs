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

        Sort(array, left, start - 1, pivotMethod);
        Sort(array, start, right, pivotMethod);



        // // // // // // // // sorts but never exits
        // Sort(array, left, start, pivotMethod);
        // Sort(array, start + 1, right, pivotMethod);


        // // // // // // // // sorts but never exits
        // Sort(array, left, end + 1, pivotMethod);
        // Sort(array, end - 1, right, pivotMethod);


        // // // // // // // // sorts but never exits
        // // // // // // Sort(array, left, start, pivotMethod);
        // // // // // // Sort(array, end, right, pivotMethod);

        // // // // // // // // sorts but never exits
        // // // // Sort(array, left, right, pivotMethod);

        // // // // // // // // sorts but never exits
        // Sort(array, left, end + 1, pivotMethod);
        // Sort(array, start - 1, right, pivotMethod);
    }

    private static (int, int) Partition<T>(T[] array, int start, int end, int pivotIndex) where T : IComparable<T>
    {
        T pivotValue = array[pivotIndex];
        // obvious optimization
        // if (array[start].CompareTo(array[end]) == 1) Swap(ref array[start], ref array[end]);
        while (start <= end) // while (true) // while (start <= end)
        {
            // T pivotValue = array[pivotIndex];
            while (array[start].CompareTo(pivotValue) == -1) start++;
            while (array[end].CompareTo(pivotValue) == 1) end--;
            // if (start < end) Swap(ref array[start++], ref array[end--]);
            if (start <= end) Swap(ref array[start++], ref array[end--]);
            // return (start, end);

            // if (start >= end) return (start, end);
            // Swap(ref array[start++], ref array[end--]);
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
                pivot = 0;
                break;
            case PivotMethod.Right:
                pivot = length - 1;
                break;
            case PivotMethod.Middle:
                pivot = (left + right) / 2;
                break;
            case PivotMethod.Random:
                pivot =  new Random(DateTime.UtcNow.DayOfYear) .Next(left, right);
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
        Random
    }
}
