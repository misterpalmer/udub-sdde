namespace Sdde.Algorithms.Tests.Unit.Data;


public class StreamingMedianCalculatorTestsData
{
    public static IEnumerable<object[]> StreamingMedianCalculatorTestData
    {
        get
        {
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 3 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6 }, 3.5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 4.5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5.5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5.5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6 }, 3.5 };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 3 };
            yield return new object[] { new int[] { 1, 2, 3, 4 }, 2.5 };
            yield return new object[] { new int[] { 1, 2, 3 }, 2 };
            yield return new object[] { new int[] { 1, 2 }, 1.5 };
            yield return new object[] { new int[] { 1, 16, 7, 9, 14, 27, 34, 15, 61, 43, 52 }, 16 };
            yield return new object[] { new int[] { 1, 16, 7, 9, 14, 27, 34, 15, 61, 43, 52, 11 }, 15.5 };
            yield return new object[] { new int[] { 1, 16, 7, 9, 14, 27, 34, 15, 61, 43, 52, 11, 22 }, 16 };
            yield return new object[] { new int[] { 1, 16, 7, 9, 14, 27, 34, 15, 61, 43, 52, 11, 22, 15 }, 15.5 };
        }
    }
}
