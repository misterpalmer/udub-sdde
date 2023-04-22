namespace Sdde.DataStructures.Tests.Unit.Data;

public class ArrayTestsData
{
    public static IEnumerable<object[]> CreateFromIEnumerableData =>
        new List<object[]>
        {
            new[] {new[] {0, 1, 2, 3, 4, 6, 7, 8, 9, 10}},
            new[] {(object) new[] {0, -1, -2, -3, -4, -6, -7, -8, -9, -10}},
            new[]
            {
                (object) new[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"}
            }
        };

    public static IEnumerable<object[]> SummationTestData =>
        new List<object[]>
        {
            new object[] {0, 10, 45},
            new object[] {100, 1001, 495550},
            new object[] {1, 10001, 50005000}
        };

    public static IEnumerable<object[]> CreateArrayFromIEnumerableData =>
        new List<object[]>
        {
            new[] {new[] {0}},
            new[] {(object) new[] {100, 99}},
            new[] {(object) new[] {1, 2, 3, 4, 5}},
            new[] {(object) new[] {23, 45, 67}},
            new[] {(object) new[] {98, 76, 54}},
            new object[] {new[] {"One", "Two", "Three", "Four", "Five"}},
            new object[] {new[] {"linked", "list", "node"}},
            new object[] {new[] {"singly", "doubly", "circular"}},
            new[] {(object) new[] {true}},
            new[] {(object) new[] {true, false}},
            new[] {(object) new[] {true, true, true}}
        };
}
