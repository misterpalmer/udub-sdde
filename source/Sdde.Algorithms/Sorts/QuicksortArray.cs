namespace Sdde.Algorithms.Sorts;

public class QuicksortArray
{
    public static void Execute<T>(T[] array, PivotMethod pivotMethod) where T : IComparable<T>
    {
        var left = 0;
        var right = array.Length - 1;

        Sort<T>(array, 0, array.Length - 1, pivotMethod);
    }

    private static void Sort<T>(T[] array, int left, int right, PivotMethod pivotMethod) where T : IComparable<T>
    {
        if (left.CompareTo(right) > 0) return;

        // var start = left;
        // var end = right;

        int pivotIndex = PickAPivotIndex(left, right, pivotMethod);
        (var start, var end) = Partition(array, left, right, pivotIndex);
        // // // // // // // // sorts but never exits
        // // // // // // Sort(array, left, start, pivotMethod);
        // // // // // // Sort(array, end, right, pivotMethod);

        Sort(array, left, start, pivotMethod);
        Sort(array, end + 1, right, pivotMethod);

        // if ((pivotIndex - left) < (right - pivotIndex))
        // {
        //     Sort(array, start, pivotIndex - 1, pivotMethod);
        //     // start = pivotIndex + 1;
        // }
        // else
        // {
        //     Sort(array, pivotIndex + 1, end, pivotMethod);
        //     // end = pivotIndex - 1;
        // }



        // sorts but never exits
        // if (left < end)
        // {
        //     Sort(array, left, pivotIndex, pivotMethod);
        // }

        // if (right > start)
        // {
        //     Sort(array, pivotIndex, right, pivotMethod);
        // }
    }

    private static (int, int) Partition<T>(T[] array, int start, int end, int pivotIndex) where T : IComparable<T>
    {
        // obvious optimization
        if (array[start].CompareTo(array[end]) == 1) Swap(ref array[start], ref array[end]);
        while (start <= end) // while (true) // while (start <= end)
        {
            T pivotValue = array[pivotIndex];
            while (array[start].CompareTo(pivotValue) < 0) start++;
            while (array[end].CompareTo(pivotValue) > 0) end--;
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
                pivot = length / 2;
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
