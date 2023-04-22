namespace Sdde.Algorithms.Tests.Unit.Data;

public class ArrayTestsData
{
    public static IEnumerable<object[]> QuicksortAllTestData =>
        new List<object[]>
        {

            new[] {(object) new[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}},
            new[] {(object) new[] {0, -1, -2, -3, -4, -6, -7, -8, -9}},
            new[] {(object) new[] {0, 1, 2, 3, 4, 6, 7, 8, 9}},
        };

    public static IEnumerable<object[]> QuicksortUnsortedTestData =>
        new List<object[]>
        {
            new[] {(object) new[] {8, 2, 5, 9, 0, 6, 3}},
            new[] {(object) new[] {8, 2, 5, 9, 5, 6, 3}},
            new[]
            {
                (object) new[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"}
            }
        };

    public static IEnumerable<object[]> QuicksortSortedTestData =>
        new List<object[]>
        {
            new[] {(object) new[] {0, 1, 2, 3, 4, 6, 7, 8, 9}},
            new[] {(object) new[] {0, -1, -2, -3, -4, -6, -7, -8, -9}},
        };


    public static IEnumerable<object[]> QuicksortRangeTestData =>
        new List<object[]>
        {
            new object[] {0, 100, 12},
            new object[] {0, 1000, 345},
            new object[] {0, 10000, 6789}
        };
}

