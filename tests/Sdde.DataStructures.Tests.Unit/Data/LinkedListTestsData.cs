using System.Collections.Generic;


namespace Sdde.DataStructures.Tests.Unit.Data;

public class LinkedListTestsData
{
     public static IEnumerable<object[]> SummationTestData =>
        new List<object[]>
            {
                new object[] { 0, 10, 45 },
                new object[] { 100, 1001, 495550 },
                new object[] { 1, 10001, 50005000 },
            };

    public static IEnumerable<object[]> CreateLinkedListFromIEnumerableData =>
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
    
    public static IEnumerable<object[]> ThreeNodeData =>
        new List<object[]>
            {
                new object[] { 23, 45, 67 },
                new object[] { 98, 76, 54 },
                new object[] { 0, 10, 45 },
                new object[] { 100, 1001, 495550 },
                new object[] { "linked", "list", "node" },
                new object[] { "singly", "doubly", "circular" },
                new object[] { true, true, true },
                new object[] { true, true, false },
            };

    public static IEnumerable<object[]> NegativeSearchData =>
        new List<object[]>
            {
                new object[] { (object) new int[] { 0 }, 1 },
                new object[] { (object) new int[] { 100, 99 }, 1 },
                new object[] { (object) new int[] { 1, 2, 3, 4, 5 }, 1000 },
                new object[] { (object) new int[] { 23, 45, 67 }, 0 },
                new object[] { (object) new int[] { 98, 76, 54 }, 10000 },
                new object[] { new string[] { "One", "Two", "Three", "Four", "Five" }, "Zero" },
                new object[] { new string[] { "linked", "list", "node" }, "stack" },
                new object[] { new string[] { "singly", "doubly", "circular" }, "heap" },
                new object[] { (object) new bool[] { true }, false },
                new object[] { (object) new bool[] { true, true }, false },
                new object[] { (object) new bool[] { true, true, true }, false },
            };
    
    public static IEnumerable<object[]> PositiveSearchDataSingleOccurrence =>
        new List<object[]>
        {
            new object[] { (object) new int[] { 0 }, 0, 1 },
            new object[] { (object) new int[] { 0, 1 }, 0, 1 },
            new object[] { (object) new int[] { 1, 0, 2 }, 0, 1 },
            new object[] { (object) new int[] { 3, 2, 1, 0 }, 0, 1 },
            new object[] { new string[] { "zero", "Zero", "One", "Two", "Three", "Four", "Five" }, "zero", 1 },
            new object[] { new string[] { "stack", "linked", "list", "node", "stack", "STACK" }, "STACK", 1 },
            new object[]
            {
                new string[]
                {
                    "linked",
                    "list",
                    "node",
                    "stack",
                    "singly",
                    "doubly",
                    "circular",
                    "stack",
                    "heap",
                    "stack",
                    "circular",
                    "doubly",
                    "singly",
                },
                "heap",
                1
            },
            new object[] { (object) new bool[] { true }, true, 1 },
            new object[] { (object) new bool[] { true, false }, true, 1 },
            new object[] { (object) new bool[] { false, true, false }, true, 1 },
            new object[] { (object) new bool[] { false, false, false, false, true }, true, 1 },
        };
    
    public static IEnumerable<object[]> PositiveSearchDataMultipleOccurrences =>
        new List<object[]>
        {
            new object[] { (object) new int[] { 0 }, 0, 1 },
            new object[] { (object) new int[] { 0, 0 }, 0, 2 },
            new object[] { (object) new int[] { 0, 0, 0 }, 0, 3 },
            new object[] { (object) new int[] { 0, 0, 0, 0 }, 0, 4 },
            new object[] { (object) new int[] { 100, 99, 0, 0 }, 0, 2 },
            new object[] { (object) new int[] { 0, 100, 99, 0 }, 0, 2 },
            new object[] { (object) new int[] { 1, 2, 3, 4, 1 }, 1, 2 },
            new object[] { (object) new int[] { 1, 2, 1, 4, 1 }, 1, 3 },
            new object[] { (object) new int[] { 1, 1, 1, 4, 5 }, 1, 3 },
            new object[] { new string[] { "zero", "Zero", "One", "Two", "Three", "Four", "Five" }, "zero", 1 },
            new object[] { new string[] { "STACK", "stack", "linked", "list", "node", "stack", "STACK" }, "STACK", 2 },
            new object[]
            {
                new string[]
                {
                    "heap",
                    "linked",
                    "list",
                    "node",
                    "stack",
                    "singly",
                    "doubly",
                    "circular",
                    "stack",
                    "heap",
                    "heap",
                    "stack",
                    "circular",
                    "doubly",
                    "singly",
                    "heap"
                },
                "heap",
                4
            },
            new object[] { (object) new bool[] { true }, true, 1 },
            new object[] { (object) new bool[] { true, true }, true, 2 },
            new object[] { (object) new bool[] { true, true, true }, true, 3 },
            new object[] { (object) new bool[] { true, false, false, false, true }, true, 2 },
            new object[] { (object) new bool[] { true, false }, true, 1 },
            new object[] { (object) new bool[] { true, false, true }, false, 1 },
        };
}