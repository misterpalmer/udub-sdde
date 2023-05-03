namespace Sdde.DataStructures.Tests.Unit.Data;

public class LinkedListTestsData
{
    public static IEnumerable<object[]> SummationTestData =>
        new List<object[]>
        {
            new object[] {0, 10, 45},
            new object[] {100, 1001, 495550},
            new object[] {1, 10001, 50005000}
        };

    public static IEnumerable<object[]> CreateLinkedListFromIEnumerableData =>
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

    public static IEnumerable<object[]> ThreeNodeData =>
        new List<object[]>
        {
            new object[] {23, 45, 67},
            new object[] {98, 76, 54},
            new object[] {0, 10, 45},
            new object[] {100, 1001, 495550},
            new object[] {"linked", "list", "node"},
            new object[] {"singly", "doubly", "circular"},
            new object[] {true, true, true},
            new object[] {true, true, false}
        };

    public static IEnumerable<object[]> NegativeSearchData =>
        new List<object[]>
        {
            new[] {(object) new[] {0}, 1},
            new[] {(object) new[] {100, 99}, 1},
            new[] {(object) new[] {1, 2, 3, 4, 5}, 1000},
            new[] {(object) new[] {23, 45, 67}, 0},
            new[] {(object) new[] {98, 76, 54}, 10000},
            new object[] {new[] {"One", "Two", "Three", "Four", "Five"}, "Zero"},
            new object[] {new[] {"linked", "list", "node"}, "stack"},
            new object[] {new[] {"singly", "doubly", "circular"}, "heap"},
            new[] {(object) new[] {true}, false},
            new[] {(object) new[] {true, true}, false},
            new[] {(object) new[] {true, true, true}, false}
        };

    public static IEnumerable<object[]> PositiveSearchDataSingleOccurrence =>
        new List<object[]>
        {
            new[] {(object) new[] {0}, 0, 1},
            new[] {(object) new[] {0, 1}, 0, 1},
            new[] {(object) new[] {1, 0, 2}, 0, 1},
            new[] {(object) new[] {3, 2, 1, 0}, 0, 1},
            new object[] {new[] {"zero", "Zero", "One", "Two", "Three", "Four", "Five"}, "zero", 1},
            new object[] {new[] {"stack", "linked", "list", "node", "stack", "STACK"}, "STACK", 1},
            new object[]
            {
                new[]
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
                    "singly"
                },
                "heap",
                1
            },
            new[] {(object) new[] {true}, true, 1},
            new[] {(object) new[] {true, false}, true, 1},
            new[] {(object) new[] {false, true, false}, true, 1},
            new[] {(object) new[] {false, false, false, false, true}, true, 1}
        };

    public static IEnumerable<object[]> PositiveSearchDataMultipleOccurrences =>
        new List<object[]>
        {
            new[] {(object) new[] {0, 0}, 0, 2},
            new[] {(object) new[] {0, 0, 0}, 0, 3},
            new[] {(object) new[] {0, 0, 0, 0}, 0, 4},
            new[] {(object) new[] {100, 99, 0, 0}, 0, 2},
            new[] {(object) new[] {0, 100, 99, 0}, 0, 2},
            new[] {(object) new[] {1, 2, 3, 4, 1}, 1, 2},
            new[] {(object) new[] {1, 2, 1, 4, 1}, 1, 3},
            new[] {(object) new[] {1, 1, 1, 4, 5}, 1, 3},
            new object[]
            {
                new[] {"zero", "Zero", "zero", "One", "zero", "Two", "zero", "Three", "zero", "Four", "zero", "Five"},
                "zero", 6
            },
            new object[] {new[] {"STACK", "stack", "linked", "list", "node", "stack", "STACK"}, "STACK", 2},
            new object[]
            {
                new[]
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
            new[] {(object) new[] {true, true}, true, 2},
            new[] {(object) new[] {true, true, true}, true, 3},
            new[] {(object) new[] {true, false, false, false, true}, true, 2}
        };
}
