using System.Diagnostics;
using Sdde.Collections.Generic;
using Sdde.DataStructures.Tests.Unit.Data;

namespace Sdde.Collections.Generic.Tests.Unit;

public class SinglyLinkedListTests
{
    private readonly ITestOutputHelper output;
    public SinglyLinkedListTests(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByNode_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddFirst(new SinglyNode<int>(index));
        }
        
        foreach(var element in sut)
        {
            actualNodeSum += element;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexEnd - 1);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByNode_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        IEnumerator<int> looper = sut.GetEnumerator();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddFirst(new SinglyNode<int>(index));
        }
        
        while(looper.MoveNext())
        {
            actualNodeSum += looper.Current;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexEnd - 1);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByValue_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddFirst(index);
        }
        
        foreach(var element in sut)
        {
            actualNodeSum += element;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexEnd - 1);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByValue_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        IEnumerator<int> looper = sut.GetEnumerator();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddFirst(index);
        }
        
        while(looper.MoveNext())
        {
            actualNodeSum += looper.Current;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexEnd - 1);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByNode_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddLast(new SinglyNode<int>(index));
        }
        
        foreach(var element in sut)
        {
            actualNodeSum += element;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexStart);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByNode_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        IEnumerator<int> looper = sut.GetEnumerator();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddLast(new SinglyNode<int>(index));
        }
        
        while(looper.MoveNext())
        {
            actualNodeSum += looper.Current;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexStart);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByValue_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddLast(index);
        }
        
        foreach(var element in sut)
        {
            actualNodeSum += element;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexStart);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType= typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByValue_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        ISinglyLinkedList<int> sut = new SinglyLinkedList<int>();
        IEnumerator<int> looper = sut.GetEnumerator();
        int expectedNodeCount = indexEnd - indexStart;
        int actualNodeSum = 0;

        // Act
        for (int index = indexStart; index < indexEnd; index++)
        {
            sut.AddLast(index);
        }
        
        while(looper.MoveNext())
        {
            actualNodeSum += looper.Current;
        }

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First!.Data.Should<int>().Be(indexStart);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType= typeof(LinkedListTestsData))]
    public void CreateListByNode_MultipleAddLast_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(new SinglyNode<T>(first));

        // Act
        sut.AddLast(second);
        sut.AddLast(new SinglyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(3);
        sut.First!.Data.Should().Be(first);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType= typeof(LinkedListTestsData))]
    public void CreateListByValue_MultipleAddLast_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(first);

        // Act
        sut.AddLast(second);
        sut.AddLast(new SinglyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(3);
        sut.First!.Data.Should().Be(first);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType= typeof(LinkedListTestsData))]
    public void CreateListByNode_MultipleAddFirst_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(new SinglyNode<T>(first));

        // Act
        sut.AddFirst(second);
        sut.AddFirst(new SinglyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(3);
        sut.First!.Data.Should().Be(third);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType= typeof(LinkedListTestsData))]
    public void CreateListByValue_MultipleAddFirst_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(first);

        // Act
        sut.AddFirst(second);
        sut.AddFirst(new SinglyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(3);
        sut.First!.Data.Should().Be(third);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType= typeof(LinkedListTestsData))]
    public void CreateListByNode_MultipleAddMixed_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(new SinglyNode<T>(first));

        // Act
        sut.AddLast(second);
        sut.AddFirst(new SinglyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(3);
        sut.First!.Data.Should().Be(third);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType= typeof(LinkedListTestsData))]
    public void CreateListByValue_MultipleAddMixed_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(first);

        // Act
        sut.AddLast(new SinglyNode<T>(second));
        sut.AddFirst(third);

        // Assert
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(3);
        sut.First!.Data.Should().Be(third);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.CreateLinkedListFromIEnumerableData), MemberType= typeof(LinkedListTestsData))]
    public void CreateList_FromIEnumerable_ReturnListProperties<T>(T[] values)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);

        // When

        // Then
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(values.Count());
        sut.First!.Data.Should().Be(values.First());
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.CreateLinkedListFromIEnumerableData), MemberType= typeof(LinkedListTestsData))]
    public void CreateList_FromIEnumerable_ClearList_ReturnListProperties<T>(T[] values)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);

        // When
        sut.Clear();
        
        // Then
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(0);
        sut.First!.Should().BeNull();
    }

    [Fact]
    public void AddAfterByValue()
    {
        // Arrange

        // Act

        //Assert
    }

    [Fact]
    public void AddNodeAfter()
    {
        // Arrange

        
        // Act


        //Assert

        
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.CreateLinkedListFromIEnumerableData), MemberType= typeof(LinkedListTestsData))]
    public void Contains_FindRandomIndexFromInput_ReturnsTrue<T>(T[] values)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        Random random = new Random();
        var index = random.Next(values.Count());

        // When
        var result = sut.Contains(values[index]);

        // Then
        using var scope = new AssertionScope();
        result.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.NegativeSearchData), MemberType= typeof(LinkedListTestsData))]
    public void Contains_FindRandomIndexFromInput_ReturnsFalse<T>(T[] values, T input)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);

        // When
        var result = sut.Contains(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.PositiveSearchDataSingleOccurrence), MemberType= typeof(LinkedListTestsData))]
    public void RemoveNode_FindValueSingleOccurrence_ReturnsNullLessOne<T>(T[] values, T input, int occurrences)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - 1;
        
        // When
        ISinglyNode<T> node = sut.Find(input);
        sut.Remove(node);
        var result = sut.Find(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().BeNull();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.PositiveSearchDataMultipleOccurrences), MemberType= typeof(LinkedListTestsData))]
    public void RemoveNode_FindValueMultipleOccurrence_ReturnsNotNullLessOne<T>(T[] values, T input, int occurrences)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - 1;
        
        // When
        ISinglyNode<T> node = sut.Find(input);
        sut.Remove(node);
        var result = sut.Find(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().NotBeNull();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.NegativeSearchData), MemberType= typeof(LinkedListTestsData))]
    public void RemoveNode_FindValueZeroOccurrences_ReturnsNullEqualCount<T>(T[] values, T input)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        
        // When
        ISinglyNode<T> node = new SinglyNode<T>(input);
        sut.Remove(node);
        var result = sut.Find(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().BeNull();
        sut.Count.Should<int>().Be(values.Length);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.PositiveSearchDataSingleOccurrence), MemberType= typeof(LinkedListTestsData))]
    public void RemoveValue_FindValueSingleOccurrence_ReturnsFalse<T>(T[] values, T input, int occurrences)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - 1;
        
        // When
        sut.Remove(input);
        var result = sut.Find(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().BeNull();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.PositiveSearchDataMultipleOccurrences), MemberType= typeof(LinkedListTestsData))]
    public void RemoveValue_FindValueMultipleOccurrences_ReturnsNotNullLessOne<T>(T[] values, T input, int occurrences)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - 1;
        
        // When
        sut.Remove(input);
        var result = sut.Find(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().NotBeNull();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.NegativeSearchData), MemberType= typeof(LinkedListTestsData))]
    public void RemoveValue_FindValueZeroOccurrences_ReturnsNullEqualCount<T>(T[] values, T input)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        
        // When
        sut.Remove(input);
        var result = sut.Find(input);

        // Then
        using var scope = new AssertionScope();
        result.Should().BeNull();
        sut.Count.Should<int>().Be(values.Length);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.PositiveSearchDataSingleOccurrence), MemberType= typeof(LinkedListTestsData))]
    public void RemoveAllValues_FindValueSingleOccurrence_ReturnsNullLessAllOccurrences<T>(T[] values, T input, int occurrences)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - occurrences;
        
        // When
        sut.RemoveAll(input);
        var result = sut.Find(input);

        // Then
        result.Should().BeNull();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.PositiveSearchDataSingleOccurrence), MemberType= typeof(LinkedListTestsData))]
    public void RemoveAllValues_FindValueMultipleOccurrence_ReturnsNullLessAllOccurrences<T>(T[] values, T input, int occurrences)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - occurrences;
        
        // When
        sut.RemoveAll(input);
        var result = sut.Find(input);

        // Then
        result.Should().BeNull();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
    
    [Theory]
    [MemberData(nameof(LinkedListTestsData.NegativeSearchData), MemberType= typeof(LinkedListTestsData))]
    public void RemoveAllValues_FindValueZeroOccurrences_ReturnsNullEqualCount<T>(T[] values, T input)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);

        // When
        sut.RemoveAll(input);
        var result = sut.Find(input);

        // Then
        result.Should().BeNull();
        sut.Count.Should<int>().Be(values.Length);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.CreateLinkedListFromIEnumerableData), MemberType= typeof(LinkedListTestsData))]
    public void RemoveFirst<T>(T[] values)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - 1;

        // When
        var node = sut.First;
        sut.RemoveFirst();

        // Then
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(expectedNodeCount);
        sut.First.Should().NotBe(node);
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.CreateLinkedListFromIEnumerableData), MemberType= typeof(LinkedListTestsData))]
    public void RemoveLast<T>(T[] values)
    {
        // Given
        ISinglyLinkedList<T> sut = new SinglyLinkedList<T>(values);
        int expectedNodeCount = values.Length - 1;

        // When
        sut.RemoveLast();

        // Then
        using var scope = new AssertionScope();
        sut.Count.Should<int>().Be(expectedNodeCount);
    }
}
