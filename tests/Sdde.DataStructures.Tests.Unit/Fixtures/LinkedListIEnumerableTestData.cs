using System.Collections;

namespace Sdde.Tests.Data;

public class LinkedListIEnumerableTestData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 2, 3, 4, 5 };
        yield return new object[] { new string[] {"One", "Two", "Three", "Four", "Five"} };

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}






