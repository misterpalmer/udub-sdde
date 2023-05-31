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
    public void InitializeMinHeapInteger_UsingEmptyConstructor_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<int>();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<int>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMinHeapChar_UsingEmptyConstructor_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<char>();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<char>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<char>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMinHeapInteger_WithDefaultComparer_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<int>(Comparer<int>.Default);
        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<int>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMinHeapChar_WithDefaultComparer_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<char>(Comparer<char>.Default);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<char>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<char>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMinHeapInteger_WithMinNodeComparer_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<int>(MinHeapNodeComparer<int>.Comparer);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<int>.Comparer);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMinHeapChar_WithMinNodeComparer_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<char>(MinHeapNodeComparer<char>.Comparer);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<char>.Comparer);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<char>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMaxHeapInteger_WithMaxNodeComparer_ReturnEmptyHeap()
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<int>(MaxHeapNodeComparer<int>.Comparer);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MaxHeapNodeComparer<int>.Comparer);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<int>.DEFAULT_CAPACITY);
    }

    [Fact]
    public void InitializeMaxHeapChar_WithMaxNodeComparer_ReturnEmptyHeap()
    {
        // Arrange

        // Act
        var heap = new MinMaxHeap<char>(MaxHeapNodeComparer<char>.Comparer);

        // Assert
        using var scope = new AssertionScope();
        heap.IsEmpty.Should().BeTrue();

        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<char>.DEFAULT_CAPACITY);
        heap.Comparer.Should().Be(MaxHeapNodeComparer<char>.Comparer);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeap), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeap), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithDefaultComparer_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values, Comparer<T>.Default);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeap), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithMinNodeComparer_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values, MinHeapNodeComparer<T>.Comparer);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MaxHeap), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMaxHeap_WithMaxNodeComparer_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values, MaxHeapNodeComparer<T>.Comparer);

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MaxHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        heap.Heap.Should().Equal(expectedHeap);
    }



    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.ClearHeap), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_Clear_ReturnHeapified<T>(IList<T> values) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values);
        heap.Clear();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(MinMaxHeap<T>.DEFAULT_CAPACITY);
        heap.Heap.Should().Equal(new T[MinMaxHeap<T>.DEFAULT_CAPACITY]);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.ClearHeap), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_RemoveAll_ReturnHeapified<T>(IList<T> values) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values);
        foreach (var _ in values)
            heap.Remove();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeTrue();
        heap.Count.Should().Be(0);
        heap.Capacity.Should().Be(values.Count());
        heap.Heap.Should().Equal(new T[values.Count()]);
    }



    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapLessX), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_RemoveX_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int numElementsToRemove = values.Count() - expectedHeap.Count();


        // Act
        var heap = new MinMaxHeap<T>(values);
        for (int i = 0; i < numElementsToRemove; i++)
            heap.Remove();

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(values.Count());
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapLessX), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithDefaultComparer_RemoveX_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int numElementsToRemove = values.Count() - expectedHeap.Count();

        // Act
        var heap = new MinMaxHeap<T>(values, Comparer<T>.Default);
        for (int i = 0; i < numElementsToRemove; i++)
            heap.Remove();

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(values.Count());
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapLessX), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithMinNodeComparer_RemoveX_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int numElementsToRemove = values.Count() - expectedHeap.Count();

        // Act
        var heap = new MinMaxHeap<T>(values, MinHeapNodeComparer<T>.Comparer);
        for (int i = 0; i < numElementsToRemove; i++)
            heap.Remove();

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(values.Count());
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MaxHeapLessX), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMaxHeap_WithMaxNodeComparer_RemoveX_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int numElementsToRemove = values.Count() - expectedHeap.Count();

        // Act
        var heap = new MinMaxHeap<T>(values, MaxHeapNodeComparer<T>.Comparer);
        for (int i = 0; i < numElementsToRemove; i++)
            heap.Remove();

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MaxHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(values.Count());
        actualValues.Should().Equal(expectedHeap);
    }



    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapWithInsertion), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_InsertX_ReturnHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCapacity = values.Count << 1;

        // Act
        var heap = new MinMaxHeap<T>(values);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(expectedCapacity);
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapWithInsertion), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithDefaultComparer_InsertX_ReturnHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCapacity = values.Count << 1;

        // Act
        var heap = new MinMaxHeap<T>(values, Comparer<T>.Default);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(expectedCapacity);
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapWithInsertion), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithMinNodeComparer_InsertX_ReturnsHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCapacity = values.Count << 1;

        // Act
        var heap = new MinMaxHeap<T>(values, MinHeapNodeComparer<T>.Comparer);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(expectedCapacity);
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MaxHeapWithInsertion), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMaxHeap_WithMaxNodeComparer_InsertX_ReturnsHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCapacity = values.Count << 1;

        // Act
        var heap = new MinMaxHeap<T>(values, MaxHeapNodeComparer<T>.Comparer);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MaxHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedHeap.Count());
        heap.Capacity.Should().Be(expectedCapacity);
        actualValues.Should().Equal(expectedHeap);
    }




    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapReinsert), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_Reinsert_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values);
        heap.Insert(heap.Remove());

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapReinsert), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithDefaultComparer_Reinsert_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values, Comparer<T>.Default);
        heap.Insert(heap.Remove());

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        // heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapReinsert), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithMinNodeComparer_Reinsert_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values, MinHeapNodeComparer<T>.Comparer);
        heap.Insert(heap.Remove());

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        // heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MaxHeapReinsert), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMaxHeap_WithMaxNodeComparer_Reinsert_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange


        // Act
        var heap = new MinMaxHeap<T>(values, MaxHeapNodeComparer<T>.Comparer);
        heap.Insert(heap.Remove());

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MaxHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(values.Count());
        heap.Capacity.Should().Be(values.Count());
        // heap.Heap.Should().Equal(expectedHeap);

    }


    // [Theory]
    // [MemberData(nameof(MinMaxHeapTestsData.MinHeap), MemberType = typeof(MinMaxHeapTestsData))]
    // public void BuildMinHeap_UsingDefaultComparer_InsertDuplicate_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    // {
    //     // Arrange


    //     // Act
    //     var heap = new MinMaxHeap<T>(values);
    //     heap.Insert(values.First());

    //     // Assert
    //     using var scope = new AssertionScope();
    //     heap.Comparer.Should().Be(Comparer<T>.Default);
    //     heap.IsEmpty.Should().BeFalse();
    //     heap.Count.Should().Be(values.Count());
    //     heap.Capacity.Should().Be(values.Count());
    //     heap.Heap.Should().Equal(expectedHeap);
    // }

    // [Theory]
    // [MemberData(nameof(MinMaxHeapTestsData.MinHeap), MemberType = typeof(MinMaxHeapTestsData))]
    // public void BuildMinHeap_WithDefaultComparer_InsertDuplicate_ReturnHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    // {
    //     // Arrange


    //     // Act
    //     var heap = new MinMaxHeap<T>(values, Comparer<T>.Default);
    //     heap.Insert(values.First());

    //     // Assert
    //     using var scope = new AssertionScope();
    //     heap.Comparer.Should().Be(Comparer<T>.Default);
    //     heap.IsEmpty.Should().BeFalse();
    //     heap.Count.Should().Be(values.Count());
    //     heap.Capacity.Should().Be(values.Count());
    //     heap.Heap.Should().Equal(expectedHeap);
    // }

    // [Theory]
    // [MemberData(nameof(MinMaxHeapTestsData.MinHeap), MemberType = typeof(MinMaxHeapTestsData))]
    // public void BuildMinHeap_WithMinNodeComparer_InsertDuplicate_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    // {
    //     // Arrange


    //     // Act
    //     var heap = new MinMaxHeap<T>(values, MinHeapNodeComparer<T>.Comparer);
    //     heap.Insert(values.First());

    //     // Assert
    //     using var scope = new AssertionScope();
    //     heap.Comparer.Should().Be(MinHeapNodeComparer<T>.Comparer);
    //     heap.IsEmpty.Should().BeFalse();
    //     heap.Count.Should().Be(values.Count());
    //     heap.Capacity.Should().Be(values.Count());
    //     heap.Heap.Should().Equal(expectedHeap);
    // }

    // [Theory]
    // [MemberData(nameof(MinMaxHeapTestsData.MaxHeap), MemberType = typeof(MinMaxHeapTestsData))]
    // public void BuildMaxHeap_WithMinNodeComparer_InsertDuplicate_ReturnsHeapified<T>(IList<T> values, IList<T> expectedHeap) where T : IComparable<T>
    // {
    //     // Arrange


    //     // Act
    //     var heap = new MinMaxHeap<T>(values, MaxHeapNodeComparer<T>.Comparer);
    //     heap.Insert(values.First());

    //     // Assert
    //     using var scope = new AssertionScope();
    //     heap.Comparer.Should().Be(MaxHeapNodeComparer<T>.Comparer);
    //     heap.IsEmpty.Should().BeFalse();
    //     heap.Count.Should().Be(values.Count());
    //     heap.Capacity.Should().Be(values.Count());
    //     heap.Heap.Should().Equal(expectedHeap);
    // }


    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapWithInsertionRemoval), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_UsingDefaultComparer_InsertX_RemoveX_ReturnHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCapacity = values.Count << 1;
        int expectedCount = values.Count() + insertValues.Count() - 1;

        // Act
        var heap = new MinMaxHeap<T>(values);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);
        heap.Remove();

        T [] actualValues = new T[heap.Count];
        for (int i = 0; i < actualValues.Length; i++)
            actualValues[i] = heap.Heap[i];

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedCount);
        heap.Capacity.Should().Be(expectedCapacity);
        actualValues.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapWithInsertionRemoval), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithDefaultComparer_InsertX_RemoveX_ReturnHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCount = values.Count() + insertValues.Count() - 1;
        int expectedCapacity = 0;

        // Act
        var heap = new MinMaxHeap<T>(values, Comparer<T>.Default);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);
        heap.Remove();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(Comparer<T>.Default);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedCount);
        // heap.Capacity.Should().Be(expectedCapacity);
        // heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MinHeapWithInsertionRemoval), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMinHeap_WithMinNodeComparer_InsertX_RemoveX_ReturnsHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCount = values.Count() + insertValues.Count() - 1;
        int expectedCapacity = 0;

        // Act
        var heap = new MinMaxHeap<T>(values, MinHeapNodeComparer<T>.Comparer);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);
        heap.Remove();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MinHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedCount);
        // heap.Capacity.Should().Be(expectedCapacity);
        // heap.Heap.Should().Equal(expectedHeap);
    }

    [Theory]
    [MemberData(nameof(MinMaxHeapTestsData.MaxHeapWithInsertionRemoval), MemberType = typeof(MinMaxHeapTestsData))]
    public void BuildMaxHeap_WithMaxNodeComparer_InsertX_RemoveX_ReturnsHeapified<T>(IList<T> values, IList<T> insertValues, IList<T> expectedHeap) where T : IComparable<T>
    {
        // Arrange
        int expectedCount = values.Count() + insertValues.Count() - 1;
        int expectedCapacity = values.Count() < MinMaxHeap<T>.DEFAULT_CAPACITY ? MinMaxHeap<T>.DEFAULT_CAPACITY : values.Count() >> 1;

        // Act
        var heap = new MinMaxHeap<T>(values, MaxHeapNodeComparer<T>.Comparer);
        foreach (var insertValue in insertValues)
            heap.Insert(insertValue);
        heap.Remove();

        // Assert
        using var scope = new AssertionScope();
        heap.Comparer.Should().Be(MaxHeapNodeComparer<T>.Comparer);
        heap.IsEmpty.Should().BeFalse();
        heap.Count.Should().Be(expectedCount);
        // heap.Capacity.Should().Be(expectedCapacity);
        // heap.Heap.Should().Equal(expectedHeap);
    }
}

