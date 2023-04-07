using Xunit;
using FluentAssertions;
using Sdde.Collections.Generic;
using Sdde.DataStructures.Tests.Unit.Data;
using System.Collections;

namespace Sdde.Collections.Generic.Tests.Unit;

[Trait("Category", "Unit")]
[Trait("BaseDataStructure", "Array")]
public class StackTests
{
    private readonly ITestOutputHelper output;

    public StackTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Constructor_CheckSizeLessThanZero_Throw()
    {
        // Given
    
        // When
        Action act = () => new ArrayStack<int>(-1);
        
        // Then
        using var _ = new AssertionScope();
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Constructor_CheckNoSize_ReturnDefault()
    {
        // Given
        int expectedDefault = 128 * 1;

        // When
        var stack = new ArrayStack<int>();

        // Then
        using var _ = new AssertionScope();
        stack.Capacity.Should().Be(expectedDefault);
    }
    
    [Fact]
    public void Constructor_CheckRequestedSizeLessThanMax_ReturnRequested()
    {
        // Given
        int requestedSize = 16 * 2;

        // When
        var stack = new ArrayStack<int>(requestedSize);

        // Then
        using var _ = new AssertionScope();
        stack.Capacity.Should().Be(requestedSize);
    }
    
    [Fact]
    public void Constructor_CheckRequestedSizeEqualsMaxAllowed_ReturnRequestedSize()
    {
        // Given
        int requestedSize = 128 * 1;

        // When
        var stack = new ArrayStack<int>();

        // Then
        using var _ = new AssertionScope();
        stack.Capacity.Should().Be(requestedSize);
    }

    [Fact]
    public void Constructor_CheckRequestedSizeGreaterThanMax_ReturnException()
    {
        // Given
        int givenMax = 256 * 2 + 1;

        // When
        Action act = () => new ArrayStack<int>(givenMax);

        // Then
        using var _ = new AssertionScope();
        act.Should().Throw<OutOfMemoryException>();
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.CreateFromIEnumerableData), MemberType= typeof(ArrayTestsData))]
    public void Push_Pop_Peek<T>(T[] data )
    {
        // Arrange
        var stack = new ArrayStack<T>();
        var expect = new List<T>(data);

        // Act
        foreach (var item in data)
        {
            stack.Push(item);
        }

        var result = new List<T>();
        while (!stack.IsEmpty)
        {
            result.Add(stack.Pop());
        }

        // Assert
        using var _ = new AssertionScope();
        result.Should().BeEquivalentTo(expect);
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.CreateFromIEnumerableData), MemberType= typeof(ArrayTestsData))]
    public void Push_Peek<T>(T[] data)
    {
        // Arrange
        var stack = new ArrayStack<T>();
        var expect = new List<T>(data);

        // Act
        foreach (var item in data)
        {
            stack.Push(item);
        }

        var result = stack.Peek();

        // Assert
        using var _ = new AssertionScope();
        result.Should().BeEquivalentTo(expect.Last());
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.CreateFromIEnumerableData), MemberType= typeof(ArrayTestsData))]
    public void Push_Pop<T>(T[] data)
    {
        // Arrange
        var stack = new ArrayStack<T>();
        var expect = new List<T>(data);

        // Act
        foreach (var item in data)
        {
            stack.Push(item);
        }

        var result = new List<T>();
        while (!stack.IsEmpty)
        {
            result.Add(stack.Pop());
        }

        // Assert
        using var _ = new AssertionScope();
        result.Should().BeEquivalentTo(expect);
    }

    [Theory]
    [MemberData(nameof(ArrayTestsData.CreateFromIEnumerableData), MemberType= typeof(ArrayTestsData))]
    public void Push_Pop_Peek_WithNull<T>(T?[] data)
    {
        // Arrange
        var stack = new ArrayStack<T?>();
        var expect = new List<T?>(data);

        // Act
        foreach (var item in expect)
        {
            stack.Push(item);
        }

        var result = new List<T?>();
        while (!stack.IsEmpty)
        {
            result.Add(stack.Pop());
        }

        // Assert
        result.Should().BeEquivalentTo(expect);
    }

    
}
