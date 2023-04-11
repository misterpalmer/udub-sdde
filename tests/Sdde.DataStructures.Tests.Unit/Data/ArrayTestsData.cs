

namespace Sdde.DataStructures.Tests.Unit.Data;

public class ArrayTestsData
{
    public static IEnumerable<object[]> CreateFromIEnumerableData =>
        new List<object[]>
            {
                new object[] { (object) new int[] { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10 } },
                new object[] { (object) new int[] { 0, -1, -2, -3, -4, -6, -7, -8, -9, -10 } },
                new object[] { (object) new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" } },
            };

    public static IEnumerable<object[]> SummationTestData =>
        new List<object[]>
            {
                new object[] { 0, 10, 45 },
                new object[] { 100, 1001, 495550 },
                new object[] { 1, 10001, 50005000 },
            };

    public static IEnumerable<object[]> CreateArrayFromIEnumerableData =>
        new List<object[]>
            {
                new object[] { (object) new int[] { 0 } },
                new object[] { (object) new int[] { 100, 99 } },
                new object[] { (object) new int[] { 1, 2, 3, 4, 5 } },
                new object[] { (object) new int[] { 23, 45, 67 } },
                new object[] { (object) new int[] { 98, 76, 54 } },
                new object[] { new string[] { "One", "Two", "Three", "Four", "Five" } },
                new object[] { new string[] { "linked", "list", "node" } },
                new object[] { new string[] { "singly", "doubly", "circular" } },
                new object[] { (object) new bool[] { true } },
                new object[] { (object) new bool[] { true, false } },
                new object[] { (object) new bool[] { true, true, true } },
            };
}