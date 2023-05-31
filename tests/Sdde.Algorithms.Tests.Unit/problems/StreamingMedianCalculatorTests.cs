using AutoFixture;
using Sdde.Algorithms.Problems;
using Sdde.Algorithms.Tests.Unit.Data;

namespace Sdde.Algorithms.Tests.Unit;


public class StreamingMedianCalculatorTests
{
    private readonly ITestOutputHelper output;
    Fixture fixture = new Fixture();

    public StreamingMedianCalculatorTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [MemberData(nameof(StreamingMedianCalculatorTestsData.StreamingMedianCalculatorTestData), MemberType = typeof(StreamingMedianCalculatorTestsData))]
    public void InitializeUsingParameterlessConstructor_AddValues_ReturnMedian(int[] values, double expected)
    {
        // Arrange
        var sut = new StreamingMedianCalculator();

        // Act
        foreach (var value in values)
        {
            sut.Add(value);
        }

        var actual = sut.Median;

        // Assert
        using var scope = new AssertionScope();
        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(StreamingMedianCalculatorTestsData.StreamingMedianCalculatorTestData), MemberType = typeof(StreamingMedianCalculatorTestsData))]
    public void InitializeWithValues_AddValues_ReturnMedian(int[] values, double expected)
    {
        // Arrange
        var sut = new StreamingMedianCalculator(values);

        // Act
        var actual = sut.Median;

        // Assert
        using var scope = new AssertionScope();
        actual.Should().Be(expected);
    }
}
