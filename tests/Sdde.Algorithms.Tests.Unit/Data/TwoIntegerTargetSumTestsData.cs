namespace Sdde.Algorithms.Tests.Unit.Data;

public class TargetSumTestsData
{
    public static IEnumerable<object[]> TwoIntegerTargetSumTestData =>
        new List<object[]>
        {

            new[] {(object) new[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 49, 51}, 100},
            new[] {(object) new[] {0, -1, -2, -3, -4, -6, -7, -8, -9, -49, -51}, -100},
            new[] {(object) new[] {0, -1, -2, -3, -4, -6, -7, -8, -9, 151, -51}, 100},
            new[] {(object) new[] {0, 1, 2, 3, 4, 6, 7, 8, 9}, 0},
        };
}
