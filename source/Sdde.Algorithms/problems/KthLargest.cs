namespace Sdde.Algorithms.Problems;

public static class KthLargest
{
    public static int Execute(int[] array, int k)
    {
        var response = 0;
        Array.Sort(array);
        var lower = array.GetLowerBound(0);
        var upper = array.GetUpperBound(0);
        var found = false;

        while (!found && (lower < upper))
        {
            var actualSum = array[upper] + array[lower];
            if (actualSum == k)
            {
                response = array[upper];
                found = true;
            }
            else if (actualSum > k)
            {
                upper--;
            }
            else
            {
                lower++;
            }
        }

        return response;
    }
}
