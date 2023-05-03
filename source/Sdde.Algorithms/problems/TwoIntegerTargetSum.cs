using Sdde.Algorithms.Sorts;

namespace Sdde.Algorithms.Problems;

public static class TwoIntegerTargetSum
{
    public static int[] ExecuteTwoNumbersSum(int[] array, int targetSum)
        {
            var response = Array.Empty<int>();
            Array.Sort(array);
            var minValue = array[array.GetLowerBound(0)];
            var maxValue = array[array.GetUpperBound(0)];


            int index = 0;
            var found = false;
            do
            {
                var searchValue = targetSum - array[index];
                int searchPosition = 0;
                while ((found == false) && (searchPosition < array.Length) && (searchValue >= minValue) && (searchValue <= maxValue))
                {
                    if (searchValue == array[searchPosition] && index != searchPosition)
                    {
                        response = response.Append(searchValue).ToArray();
                        response = response.Append(array[index]).ToArray();
                        found = true;
                    }
                    searchPosition++;
                }
                index++;
            } while (found == false && index < array.Length);

            return response;
        }

        public static (int, int) ExecuteUsingHash(int[] array, int targetSum)
        {
            var response = Array.Empty<int>();
            var ledger = new HashSet<int>();
            var found = false;

            while (!found)
            {

            }

            return (0, 0);
        }

        public static int[] ExecuteUsing(int[] array, int targetSum)
        {
            var response = Array.Empty<int>();
            Array.Sort(array);
            var lower = array.GetLowerBound(0);
            var upper = array.GetUpperBound(0);
            var found = false;

            while (!found && (lower < upper))
            {
                var actualSum = array[upper] + array[lower];
                if (actualSum == targetSum)
                {
                    response = response.Append(array[lower]).Append(array[upper]).ToArray();
                    found = true;
                }
                else if (actualSum < array[lower] || actualSum > array[upper])
                {
                    // move the left pointer
                    //lower++;
                    // move the right pointer
                    upper--;
                }
                else /*if ( || actualSum < array[upper])*/
                {
                    // move the left pointer
                    lower++;
                    // move the right pointer
                    //upper--;
                }
            }

            return response;
        }






    public static bool Execute(int[] numbers, int target)
    {
        QuicksortArray.Execute(numbers, QuicksortArray.PivotMethod.Left);
        var left = 0;
        var right = numbers.Length - 1;
        while (left < right)
        {
            var sum = numbers[left] + numbers[right];
            if (sum == target) return true;
            else if (sum < target) left++;
            else right--;
        }
        return false;
    }
}
