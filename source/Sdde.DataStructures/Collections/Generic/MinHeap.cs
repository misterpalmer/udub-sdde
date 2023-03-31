namespace Sdde.Collections.Generic;

public class MinHeap<T>
{
    public IEnumerable<T> heap;

    public MinHeap(IEnumerable<T> array)
    {
        heap = buildHeap(array);
    }

    public IEnumerable<T> buildHeap(IEnumerable<T> array)
    {
        // Write your code here.
        return new List<T>();
    }

    public void siftDown(int currentIdx, int endIdx, List<int> heap)
    {
        // Write your code here.
    }

    public void siftUp(int currentIdx, List<int> heap)
    {
        // Write your code here.
    }

    public int Peek()
    {
        // Write your code here.
        return -1;
    }

    public int Remove()
    {
        // Write your code here.
        return -1;
    }

    public void Insert(int value)
    {
        // Write your code here.
    }
}