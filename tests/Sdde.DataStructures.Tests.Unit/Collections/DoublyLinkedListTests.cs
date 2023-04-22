using Sdde.DataStructures.Tests.Unit.Data;

namespace Sdde.Collections.Generic.Tests.Unit;

public class DoublyLinkedListTests
{
    private readonly ITestOutputHelper output;

    public DoublyLinkedListTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByNode_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddFirst(new DoublyNode<int>(index));

        foreach (var element in tester) actualNodeSum += element;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Data.Should<int>().Be(indexStart);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByNode_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var looper = tester.GetEnumerator();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddFirst(new DoublyNode<int>(index));

        while (looper.MoveNext()) actualNodeSum += looper.Current;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Data.Should<int>().Be(indexStart);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByValue_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddFirst(index);

        foreach (var element in tester) actualNodeSum += element;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Data.Should<int>().Be(indexStart);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddFirstByValue_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var looper = tester.GetEnumerator();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddFirst(index);

        while (looper.MoveNext()) actualNodeSum += looper.Current;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Data.Should<int>().Be(indexStart);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByNode_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddLast(new DoublyNode<int>(index));

        foreach (var element in tester) actualNodeSum += element;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexStart);
        tester.Last!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByNode_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var looper = tester.GetEnumerator();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddLast(new DoublyNode<int>(index));

        while (looper.MoveNext()) actualNodeSum += looper.Current;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexStart);
        tester.Last!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByValue_UsingIEnumerable_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddLast(index);

        foreach (var element in tester) actualNodeSum += element;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexStart);
        tester.Last!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.SummationTestData), MemberType = typeof(LinkedListTestsData))]
    public void CreateEmptyList_AddLastByValue_UsingIEnumerator_ReturnSumOfNodesAndListProperties(
        int indexStart,
        int indexEnd,
        int expectedNodeSum)
    {
        // Arrange
        IDoublyLinkedList<int> tester = new DoublyLinkedList<int>();
        var looper = tester.GetEnumerator();
        var expectedNodeCount = indexEnd - indexStart;
        var actualNodeSum = 0;

        // Act
        for (var index = indexStart; index < indexEnd; index++) tester.AddLast(index);

        while (looper.MoveNext()) actualNodeSum += looper.Current;

        // Assert
        using var scope = new AssertionScope();
        actualNodeSum.Should<int>().Be(expectedNodeSum);
        tester.Count.Should<int>().Be(expectedNodeCount);
        tester.First!.Data.Should<int>().Be(indexStart);
        tester.Last!.Data.Should<int>().Be(indexEnd - 1);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType = typeof(LinkedListTestsData))]
    public void CreateListByNode_MultipleAddLast_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        IDoublyLinkedList<T> tester = new DoublyLinkedList<T>(new DoublyNode<T>(first));

        // Act
        tester.AddLast(second);
        tester.AddLast(new DoublyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        tester.Count.Should<int>().Be(3);
        tester.First!.Data.Should().Be(first);
        tester.Last!.Data.Should().Be(third);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType = typeof(LinkedListTestsData))]
    public void CreateListByValue_MultipleAddLast_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        IDoublyLinkedList<T> tester = new DoublyLinkedList<T>(first);

        // Act
        tester.AddLast(second);
        tester.AddLast(new DoublyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        tester.Count.Should<int>().Be(3);
        tester.First!.Data.Should().Be(first);
        tester.Last!.Data.Should().Be(third);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType = typeof(LinkedListTestsData))]
    public void CreateListByNode_MultipleAddFirst_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        IDoublyLinkedList<T> tester = new DoublyLinkedList<T>(new DoublyNode<T>(first));

        // Act
        tester.AddFirst(second);
        tester.AddFirst(new DoublyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        tester.Count.Should<int>().Be(3);
        tester.First!.Data.Should().Be(third);
        tester.Last!.Data.Should().Be(first);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType = typeof(LinkedListTestsData))]
    public void CreateListByValue_MultipleAddFirst_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        IDoublyLinkedList<T> tester = new DoublyLinkedList<T>(first);

        // Act
        tester.AddFirst(second);
        tester.AddFirst(new DoublyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        tester.Count.Should<int>().Be(3);
        tester.First!.Data.Should().Be(third);
        tester.Last!.Data.Should().Be(first);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType = typeof(LinkedListTestsData))]
    public void CreateListByNode_MultipleAddMixed_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        IDoublyLinkedList<T> tester = new DoublyLinkedList<T>(new DoublyNode<T>(first));

        // Act
        tester.AddLast(second);
        tester.AddFirst(new DoublyNode<T>(third));

        // Assert
        using var scope = new AssertionScope();
        tester.Count.Should<int>().Be(3);
        tester.First!.Data.Should().Be(third);
        tester.Last!.Data.Should().Be(second);
        tester.Last!.Next.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(LinkedListTestsData.ThreeNodeData), MemberType = typeof(LinkedListTestsData))]
    public void CreateListByValue_MultipleAddMixed_ReturnListProperties<T>(T first, T second, T third)
    {
        // Arrange
        IDoublyLinkedList<T> tester = new DoublyLinkedList<T>(first);

        // Act
        tester.AddLast(new DoublyNode<T>(second));
        tester.AddFirst(third);

        // Assert
        using var scope = new AssertionScope();
        tester.Count.Should<int>().Be(3);
        tester.First!.Data.Should().Be(third);
        tester.Last!.Data.Should().Be(second);
        tester.Last!.Next.Should().BeNull();
    }
}
