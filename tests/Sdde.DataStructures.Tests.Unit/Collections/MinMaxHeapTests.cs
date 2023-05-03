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
    public void InitializeConstructor_Empty_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<int>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(0);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.TestData), MemberType = typeof(MinMaxHeapTestsData))]
    public void InitializeConstructor_Data_HeapType_Comparer_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.TestData), MemberType = typeof(MinMaxHeapTestsData))]
    public void InitializeConstructor_Data_Returns<T>(IEnumerable<T> data) where T : IComparable<T>
    {
        // Arrange
        var values = fixture.CreateMany<T>().ToArray();
        var heap = new MinMaxHeap<T>(data, HeapType.Min, Comparer<T>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<int>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(10);
        heap.Capacity.Should().Be(10);
    }

    [Fact]
    public void InitializeConstructor_HeapType_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(HeapType.Min);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
    }

    [Fact]
    public void InitializeConstructor_Comparer_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(Comparer<int>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
    }

    [Fact]
    public void InitializeConstructor_Data_HeapType_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
    }

    [Fact]
    public void InitializeConstructor_Data_Comparer_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>();

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
    }

    [Fact]
    public void InitializeConstructor_HeapType_Comparer_Returns()
    {
        // Arrange
        var heap = new MinMaxHeap<int>(HeapType.Min, Comparer<int>.Default);

        // Act

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();
        heap.IsMinHeap.Should().BeTrue();
        heap.Count.Should().Be(0);
    }



    [Fact]
    public void Insert()
    {
    }

    public void Heapify()
    {
    }
}

// internal class MinMaxHeap
// {
//     private IEnumerable<object> data;

//     public MinMaxHeap(IEnumerable<object> data)
//     {
//         this.data = data;
//     }
// }
