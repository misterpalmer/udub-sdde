using AutoFixture;
using Sdde.Algorithms.Tests.Unit.Data;

namespace Sdde.Algorithms.Tests;

public class TwoIntegerTargetSumTests
{
    // int[] valuesTest1 = { 3, 5, -4, 8, 11, 1, -1, 6 };
    // var target = 10;
    // var response = ExecuteUsing(valuesTest1, target);

    // int[] valuesTest3 = { 1, 4, 6 };
    // target = 5;
    // //var response = ExecuteTwoNumbersSum(values, 10);
    // response = ExecuteUsing(valuesTest3, target);

    // int[] valuesTest5 = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    // target = 17;
    // //var response = ExecuteTwoNumbersSum(values, 10);
    // response = ExecuteUsing(valuesTest5, target);


    private readonly ITestOutputHelper output;
    Fixture fixture = new Fixture();

    public TwoIntegerTargetSumTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [MemberData(nameof(TargetSumTestsData.TwoIntegerTargetSumTestData), MemberType = typeof(TargetSumTestsData))]
    public void PositivePlusPositive()
    {
        // Arrange


        // Act


        // Assert
        using var scope = new AssertionScope();

    }

    [Theory]
    [MemberData(nameof(TargetSumTestsData.TwoIntegerTargetSumTestData), MemberType = typeof(TargetSumTestsData))]
    public void NegativePlusNegative()
    {
        // Arrange


        // Act


        // Assert
        using var scope = new AssertionScope();

    }

    [Theory]
    [MemberData(nameof(TargetSumTestsData.TwoIntegerTargetSumTestData), MemberType = typeof(TargetSumTestsData))]
    public void NegativePlusPositive()
    {
        // Arrange


        // Act


        // Assert
        using var scope = new AssertionScope();

    }

    [Theory]
    [MemberData(nameof(TargetSumTestsData.TwoIntegerTargetSumTestData), MemberType = typeof(TargetSumTestsData))]
    public void SumZero()
    {
        // Arrange


        // Act


        // Assert
        using var scope = new AssertionScope();

    }
}
