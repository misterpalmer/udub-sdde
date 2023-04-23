using AutoFixture;
using Sdde.Algorithms.Sorts;
using Sdde.Algorithms.Tests.Unit.Data;
// using AutoFixture;
// using AutoFixture.AutoMoq;
// using AutoFixture.Xunit2;
// using Xunit;
// using Xunit.Abstractions;


namespace Sdde.Algorithms.Tests.Unit;

public class QuicksortTests
{
    private readonly ITestOutputHelper output;
    Fixture fixture = new Fixture();

    public QuicksortTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Sorted_ReturnsTrue()
    {
        // Arrange
        int[] sut = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

        // Act
        QuicksortArray.Execute(sut, QuicksortArray.PivotMethod.Left);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.QuicksortAllTestData), MemberType = typeof(ArrayTestsData))]
    [MemberData(nameof(ArrayTestsData.QuicksortUnsortedTestData), MemberType = typeof(ArrayTestsData))]
    public void DescendingSorted_PartitionMiddle_ReturnsAscending<T>(T[] sut) where T : IComparable<T>
    {
        // Arrange

        // Act
        QuicksortArray.Execute<T>(sut, QuicksortArray.PivotMethod.Middle);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.QuicksortAllTestData), MemberType = typeof(ArrayTestsData))]
    [MemberData(nameof(ArrayTestsData.QuicksortUnsortedTestData), MemberType = typeof(ArrayTestsData))]
    public void DescendingSorted_PartitionLeft_ReturnsAscending<T>(T[] sut) where T : IComparable<T>
    {
        // Arrange

        // Act
        QuicksortArray.Execute<T>(sut, QuicksortArray.PivotMethod.Left);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }



    [Theory]
    [MemberData(nameof(ArrayTestsData.QuicksortAllTestData), MemberType = typeof(ArrayTestsData))]
    [MemberData(nameof(ArrayTestsData.QuicksortUnsortedTestData), MemberType = typeof(ArrayTestsData))]
    public void DescendingSorted_PartitionRight_ReturnsAscending<T>(T[] sut) where T : IComparable<T>
    {
        // Arrange

        // Act
        QuicksortArray.Execute(sut, QuicksortArray.PivotMethod.Right);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.QuicksortAllTestData), MemberType = typeof(ArrayTestsData))]
    [MemberData(nameof(ArrayTestsData.QuicksortUnsortedTestData), MemberType = typeof(ArrayTestsData))]
    public void DescendingSorted_PartitionRandom_ReturnsAscending<T>(T[] sut) where T : IComparable<T>
    {
        // Arrange

        // Act
        QuicksortArray.Execute(sut, QuicksortArray.PivotMethod.Random);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.QuicksortAllTestData), MemberType = typeof(ArrayTestsData))]
    [MemberData(nameof(ArrayTestsData.QuicksortUnsortedTestData), MemberType = typeof(ArrayTestsData))]
    public void DescendingSorted_PartitionBitShift_ReturnsAscending<T>(T[] sut) where T : IComparable<T>
    {
        // Arrange

        // Act
        QuicksortArray.Execute(sut, QuicksortArray.PivotMethod.BitShift);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.QuicksortRangeTestData), MemberType = typeof(ArrayTestsData))]
    public void Summation_ReturnsCorrectResult(int lower, int upper)
    {
        // Arrange
        var length = (upper - lower + 1);
        int[] sut = new int[length]; //Array.Empty<int>();
        for (int i = lower; i < length; i++)
        {
            sut[i] = fixture.Create<int>();
        }

        // Act
        QuicksortArray.Execute(sut, QuicksortArray.PivotMethod.Left);

        // Assert
        using var scope = new AssertionScope();
        sut.Should().BeInAscendingOrder();
    }
}
