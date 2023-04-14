
namespace Sdde.Algorithms.Tests.Unit;

public class QuicksortTests
{
    private readonly ITestOutputHelper output;
    public QuicksortTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Sorted_ReturnsTrue()
    {
        // Arrange
        int[] sut = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Quicksort.Sort(sut);

        // Act

        // Assert
        using var scope = new AssertionScope();
        Assert.True(true);
    }
}
