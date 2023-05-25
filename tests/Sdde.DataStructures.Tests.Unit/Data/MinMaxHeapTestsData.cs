namespace Sdde.DataStructures.Tests.Unit.Data;

public class MinMaxHeapTestsData
{
    public static IEnumerable<object[]> MinHeap =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
            // values = new int[] {12, 2, 24, 51, 8, -5};
            // expectedValues = new int[] { -5, 2, 8, 12, 24, 51 };
            // values = new int[] { 10, 1, 23, 50, 7, -4 };
            // expectedValues = new int[] { -4, 1, 7, 10, 23, 50 };
            // values = new int[] { 5, 9, 3, 1, 8, 6 };
            // expectedValues = new int[] { 1, 3, 5, 6, 8, 9 };
            // values = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
            // expectedValues = new int[] { 1, 2, 3, 4, 7, 9, 10, 14, 8, 16 };
        };

    public static IEnumerable<object[]> MaxHeap =>
        new List<object[]>
        {
            // int[] values = new int[] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17};
            // int[] expectedValues = new int[] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 };
            // values = new int[] {12, 2, 24, 51, 8, -5};
            // expectedValues = new int[] { 51, 12, 24, 2, 8, -5 };
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };

    public static IEnumerable<object[]> MinHeapWithRemoval =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
        };

    public static IEnumerable<object[]> MaxHeapWithRemoval =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };

    public static IEnumerable<object[]> MinHeapWithInsertion =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
        };

    public static IEnumerable<object[]> MaxHeapWithInsertion =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };

    public static IEnumerable<object[]> MinHeapWithMultiInsertion =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
        };

    public static IEnumerable<object[]> MaxHeapWithMultiInsertion =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };

    public static IEnumerable<object[]> MinHeapWithMultiInsertionRemoval =>
        new List<object[]>
        {
            new object [] { new [] { 73, 57, 49, 99, 133, 20, 1 }, new [] { 1, 57, 20, 99, 133, 73, 49 } },
            new object [] { new [] { 3, 9, 2, 1, 4, 5 }, new [] { 1, 3, 2, 9, 4, 5 } },
            new object [] { new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' }, new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' } },
        };

    public static IEnumerable<object[]> MaxHeapWithMultiInsertionRemoval =>
        new List<object[]>
        {
            new object [] { new [] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17}, new [] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 } },
            new object [] { new [] { 12, 2, 24, 51, 8, -5 }, new [] { 51, 12, 24, 2, 8, -5 } },
            new object [] { new [] { 'C', 'D', 'P', 'E', 'Z','X', 'R' }, new [] { 'Z', 'E', 'X', 'C', 'D','P', 'R' } },
        };
}
