namespace Sdde.Algorithms;

public class Quicksort
{
    public static void Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        var pivot = array[(left + right) / 2];
        var index = Partition(array, left, right, pivot);
        Sort(array, left, index - 1);
        Sort(array, index, right);
    }

    private static int Partition(int[] array, int left, int right, int pivot)
    {
        while (left <= right)
        {
            while (array[left] < pivot)
            {
                left++;
            }

            while (array[right] > pivot)
            {
                right--;
            }

            if (left <= right)
            {
                Swap(array, left, right);
                left++;
                right--;
            }
        }

        return left;
    }

    private static void Swap(int[] array, int left, int right)
    {
        var temp = array[left];
        array[left] = array[right];
        array[right] = temp;
    }
}
