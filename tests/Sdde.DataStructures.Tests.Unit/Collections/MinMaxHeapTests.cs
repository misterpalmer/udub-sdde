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
    public void InitializeConstructor_Default_ReturnDefaultEmptyArray()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();;

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.TestData), MemberType = typeof(MinMaxHeapTestsData))]
    public void InitializeConstructor_AllParameters_NonEmptyMinDefault<T>(IList<T> data) where T : IComparable<T>
    {
        // Arrange
        var heap = new MinMaxHeap<T>(data, Comparer<T>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(data.Count());
        heap.Capacity.Should().Be(data.Count());
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.TestData), MemberType = typeof(MinMaxHeapTestsData))]
    public void InitializeConstructor_TheoryDataWithDefaults_NonEmptyMinDefault<T>(IList<T> data) where T : IComparable<T>
    {
        // Arrange
        var heap = new MinMaxHeap<T>(data);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(data.Count());
        heap.Capacity.Should().Be(data.Count());
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
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_MaxHeapType_EmptyMax()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
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
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_FixtureDataWithMaxHeapType_Returns()
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
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void InitializeConstructor_HeapType_Comparer_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(Comparer<int>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
        heap.Comparer.Should().Be(Comparer<int>.Default);
    }

    [Fact]
    public void BuildMinHeap()
    {
        // Arrange
        int[] values = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        int[] expectedValues = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        // values = new int[] {12, 2, 24, 51, 8, -5};
        // expectedValues = new int[] { -5, 2, 8, 12, 24, 51 };
        // values = new int[] { 10, 1, 23, 50, 7, -4 };
        // expectedValues = new int[] { -4, 1, 7, 10, 23, 50 };
        // values = new int[] { 5, 9, 3, 1, 8, 6 };
        // expectedValues = new int[] { 1, 3, 5, 6, 8, 9 };
        // values = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
        // expectedValues = new int[] { 1, 2, 3, 4, 7, 9, 10, 14, 8, 16 };
        values = new int[] { 3, 9, 2, 1, 4, 5 };
        expectedValues = new int[] { 1, 3, 2, 9, 4, 5 };

        // Act
        MinMaxHeap<int> heap = new MinMaxHeap<int>(values, Comparer<int>.Default);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.Comparer.Should().Be(Comparer<int>.Default);
        // heap.Should().BeEquivalentTo<int[]>(expectedValues);
        heap.Heap.Should().Equal(expectedValues);
    }

    [Fact]
    public void BuildMinHeap_Comparer()
    {
        // Arrange
        int[] values = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        int[] expectedValues = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        values = new int[] { 3, 9, 2, 1, 4, 5 };
        expectedValues = new int[] { 1, 3, 2, 9, 4, 5 };

        // Act
        MinMaxHeap<int> heap = new MinMaxHeap<int>(values, MinHeapNodeComparer<int>.Comparer);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.Comparer.Should().Be(MinHeapNodeComparer<int>.Comparer);
        heap.Heap.Should().Equal(expectedValues);
    }

    [Fact]
    public void BuildMinHeap_CharArray()
    {
        // Arrange
        char[] values = new char[] { 'Z', 'E', 'X', 'C', 'D','P', 'R' };
        char[] expectedValues = new char[] { 'C', 'D', 'P', 'E', 'Z','X', 'R' };

        // Act
        MinMaxHeap<char> heap = new MinMaxHeap<char>(values, Comparer<char>.Default);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.Comparer.Should().Be(Comparer<char>.Default);
        heap.Heap.Should().Equal(expectedValues);
    }

    [Fact]
    public void BuildMinHeap_CharArray_MinComparer()
    {
        // Arrange
        char[] values = new char[] { 'Z', 'E', 'X', 'C', 'D','P', 'R' };
        char[] expectedValues = new char[] { 'C', 'D', 'P', 'E', 'Z','X', 'R' };

        // Act
        MinMaxHeap<char> heap = new MinMaxHeap<char>(values, MinHeapNodeComparer<char>.Comparer);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.Comparer.Should().Be(MinHeapNodeComparer<char>.Comparer);
        heap.Heap.Should().Equal(expectedValues);
    }

    [Fact]
    public void BuildMaxHeap()
    {
        // Arrange
        int[] values = new int[] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17};
        int[] expectedValues = new int[] { 17, 15, 13, 9, 6, 5, 10, 4, 8, 3, 1 };
        // values = new int[] {12, 2, 24, 51, 8, -5};
        // expectedValues = new int[] { 51, 12, 24, 2, 8, -5 };

        // Act
        MinMaxHeap<int> heap = new MinMaxHeap<int>(values, MaxHeapNodeComparer<int>.Comparer);

        // Assert
        heap.Count.Should().Be(values.Length);
        heap.Capacity.Should().Be(values.Length);
        heap.Comparer.Should().Be(MaxHeapNodeComparer<int>.Comparer);
        // heap.Should().BeEquivalentTo(expectedValues);
        heap.Heap.Should().Equal(expectedValues);
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
        // Arrange

        // Act

        // Assert

    }

    [Fact]
    public void Remove()
    {
        // Arrange

        // Act

        // Assert
    }

    public void Heapify()
    {
    }
}

