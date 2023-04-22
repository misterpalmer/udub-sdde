namespace Sdde.DataStructures.Tests.Unit.Data;

public class MinHeapsTestsData
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] {0, 10, 45},
            new object[] {100, 1001, 495550},
            new object[] {1, 10001, 50005000}
        };
}
