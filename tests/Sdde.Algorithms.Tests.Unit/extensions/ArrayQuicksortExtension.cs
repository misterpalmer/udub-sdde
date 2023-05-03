namespace Sdde.Algorithms.Tests.Unit.Extensions;

public static class ArrayQuicksortExtension
{
    public static void QuickSort(this int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            var pivot = Partition(array, left, right);

            if (pivot > 1)
            {
                QuickSort(array, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                QuickSort(array, pivot + 1, right);
            }
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        var pivot = array[left];
        while (true)
        {
            while (array[left] < pivot)
            {
                left++;
            }

            while (array[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (array[left] == array[right])
                {
                    return right;
                }

                var temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
            else
            {
                return right;
            }
        }
    }
}
