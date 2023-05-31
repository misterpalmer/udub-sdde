namespace Sdde.DataStructures.Tests.Unit.Data;

public class MinMaxHeapTestsData
{
    public static IEnumerable<object[]> ClearHeap =>
        new List<object[]>
        {
            new object [] { new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
            new object [] { new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D', 'P', 'R' } },

        };

    public static IEnumerable<object[]> MinHeap =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
            // new object [] { new [] {12, 2, 24, 51, 8, -5}, new [] { -5, 2, 8, 12, 24, 51 } },
            // new object [] { new [] { 10, 1, 23, 50, 7, -4 }, new [] { -4, 1, 7, 10, 23, 50 } },
            // new object [] { new [] { 5, 9, 3, 1, 8, 6 }, new [] { 1, 3, 5, 6, 8, 9 } },
            // new object [] { new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }, new [] { 1, 2, 3, 4, 7, 9, 10, 14, 8, 16 };
        };

    public static IEnumerable<object[]> MaxHeap =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };

    public static IEnumerable<object[]> MinHeapLessX =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 20, 57, 49, 99, 133, 73 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 2, 3, 5, 9, 4 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'D', 'E', 'P', 'R', 'Z', 'X' } },
        };

    public static IEnumerable<object[]> MaxHeapLessX =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 15, 9, 13, 8, 6, 5, 10, 4, 1, 3 } },
            // new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'X', 'E', 'R', 'C', 'D','P' } },
        };

    public static IEnumerable<object[]> MinHeapReinsert =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'E', 'D', 'R', 'Z', 'X', 'P' } },
        };

    public static IEnumerable<object[]> MaxHeapReinsert =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 15, 9, 13, 8, 6, 5, 10, 4, 1, 3 } },
            // new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'X', 'E', 'R', 'C', 'D','P' } },
        };

    public static IEnumerable<object[]> MinHeapWithInsertion =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 4, 98 }, new [] { 1, 4, 20, 57, 133, 73, 49, 99, 98 } },
            // new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            // new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
        };

    public static IEnumerable<object[]> MaxHeapWithInsertion =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 2, 36 }, new [] { 36, 15, 17, 9, 6, 13, 10, 4, 8, 3, 1, 2, 5 } },
            // new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            // new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };

    public static IEnumerable<object[]> MinHeapWithInsertionRemoval =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 4, 98 }, new [] { 4, 57, 20, 98, 133, 73, 49, 99 } },
            // new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            // new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
        };

    public static IEnumerable<object[]> MaxHeapWithInsertionRemoval =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 2, 36 }, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1, 2 } },
            // new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            // new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };
}
