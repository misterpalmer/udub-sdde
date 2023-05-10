using AutoFixture;
using Sdde.DataStructures.Tests.Unit.Data;

namespace Sdde.Collections.Generic.Tests.Unit;

public class MinMaxHeapTests
{
    private readonly ITestOutputHelper output;
    Fixture fixture = new Fixture();

    public MinMaxHeapTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void InitializeConstructor_Default_EmptyMinDefault()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();;

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DefaultCapacity);
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.TestData), MemberType = typeof(MinMaxHeapTestsData))]
    public void InitializeConstructor_AllParameters_NonEmptyMinDefault<T>(IEnumerable<T> data) where T : IComparable<T>
    {
        // Arrange
        var heap = new MinMaxHeap<T>(data, HeapType.Min, Comparer<T>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(data.Count());
        heap.Capacity.Should().Be(data.Count());
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.TestData), MemberType = typeof(MinMaxHeapTestsData))]
    public void InitializeConstructor_TheoryDataWithDefaults_NonEmptyMinDefault<T>(IEnumerable<T> data) where T : IComparable<T>
    {
        // Arrange
        var heap = new MinMaxHeap<T>(data);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(data.Count());
        heap.Capacity.Should().Be(data.Count());
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_FixtureDataWithDefaults_NonEmptyMinDefault()
    {
        // Arrange
        var values = fixture.CreateMany<int>().ToArray();
        var heap = new MinMaxHeap<int>(values);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_MaxHeapType_EmptyMax()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(HeapType.Max);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DefaultCapacity);
        heap.IsMinHeap.Should().BeFalse();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_DefaultComparer_ReturnsDefault()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(Comparer<int>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DefaultCapacity);
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_FixtureDataWithMaxHeapType_Returns()
    {
        // Arrange
        var values = fixture.CreateMany<int>().ToArray();
        var heap = new MinMaxHeap<int>(values, HeapType.Max);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.IsMinHeap.Should().BeFalse();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_FixtureDataWithComparer_Returns()
    {
        // Arrange
        var values = fixture.CreateMany<int>().ToArray();
        var heap = new MinMaxHeap<int>(values, Comparer<int>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_HeapType_Comparer_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(HeapType.Max, Comparer<int>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DefaultCapacity);
        heap.IsMinHeap.Should().BeFalse();
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void BuildMaxHeap()
    {
        // Arrange
        int[] values = new int[] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17};
        int[] expectedValues = new int[] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 };
        values = new int[] {12, 2, 24, 51, 8, -5};
        expectedValues = new int[] { 51, 12, 24, 2, 8, -5 };

        // Act
        MinMaxHeap<int> heap = new MinMaxHeap<int>(values, HeapType.Max, Comparer<int>.Default);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.IsMinHeap.Should().BeFalse();
        heap.Comparer.Should().Be(Comparer<int>.Default);
        // heap.Should().BeEquivalentTo(expectedValues);
    }

    [Fact]
    public void BuildMinHeap()
    {
        // Arrange
        int[] values = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        int[] expectedValues = new int[] { 1, 20, 49, 57, 73, 99, 133 };

        // Act
        MinMaxHeap<int> heap = new MinMaxHeap<int>(values, HeapType.Min, Comparer<int>.Default);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.IsMinHeap.Should().BeTrue();
        heap.Comparer.Should().Be(Comparer<int>.Default);
        // heap.Should().BeEquivalentTo(expectedValues);
    }

    [Fact]
    public void TestIncreaseHeapSize()
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    public void Insert()
    {
    }

    [Fact]
    public void Remove()
    {
    }

    public void Heapify()
    {
    }
}

