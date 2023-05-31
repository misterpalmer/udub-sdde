// calculating the median of a stream of numbers for uptime monitoring
// need to use min heap
// use this: insertion sort
// other options to evaluate for sort: counting, radix sort, bubble sort, (selection sort, insertion sort, merge sort, quick sort, heap sort )

// there are 2 ways to solve this problem
// 1. use a min heap and a max heap
// 2. use a sorted list/array/object

// only one nuumber comes in at a time
// what about when multiple/array comes in at a time???

// kth largest problem
// quick select (what is complexity)
// what about a heap?
// using a heap is O(n log n) which is horrendous!!!
// this found using 3 parts: 1) remove half, 2) get the root element--which is the median, 3) add back the removed elements
// but let's look a little closer...
// it's the root element of the maxheap/left and the minheap/right that is the median
// so, we can use a maxheap and a minheap to solve this problem
// if the difference in sizes is more than 1 then need to move from one heap to the other
// if the difference in sizes is 1 then the median is the root of the larger heap
// if imbalanced then need to remove from the larger heap and add to the smaller heap
// pseudcode at 37/38 slide or 2:38:00 in video
// each heap has a method GetRoot() and Add() and Remove()
// each heap has a property Count(Size)
// each heap has a property IsEmpty
// each heap has a property IsFull
// each heap has a property Peek
// each heap has a property Capacity
// each heap has a property IsBalanced
// each heap has a property IsMinHeap
// each heap has a property IsMaxHeap
// each heap has a property IsHeap
// each heap has a property IsSorted
// each heap has a property


// heap better option than quick select time because it is O(1)
// BUT balancing has to be done which is O(log n)
// for streaming data the complexity is O(n log n) (what sajeev O(log n) ???)

using Sdde.Collections.Generic;

namespace Sdde.Algorithms.Problems;

public class StreamingMedianCalculator
{
    private MinMaxHeap<int> _lessThanMedian;
    private MinMaxHeap<int> _greaterThanMedian;
    private double _median;
    public double Median { get { return _median > 0 ? _median : 0; } private set { _median = value; } }

    public StreamingMedianCalculator()
    {
        this._lessThanMedian = new MinMaxHeap<int>(MaxHeapNodeComparer<int>.Comparer);
        this._greaterThanMedian = new MinMaxHeap<int>(MinHeapNodeComparer<int>.Comparer);
        this.Median = 0;
    }

    public void Add(int value)
    {
        if (_lessThanMedian.IsEmpty || value < _lessThanMedian.Peek())
        {
            _lessThanMedian.Insert(value);
        }
        else
        {
            _greaterThanMedian.Insert(value);
        }

        Rebalance();
        UpdateMedian();
    }

    private void Rebalance()
    {
        if (_lessThanMedian.Count - _greaterThanMedian.Count > 1)
        {
            _greaterThanMedian.Insert(_lessThanMedian.Remove());
        }
        else if (_greaterThanMedian.Count - _lessThanMedian.Count > 1)
        {
            _lessThanMedian.Insert(_greaterThanMedian.Remove());
        }
    }

    private void UpdateMedian()
    {
        if (_lessThanMedian.Count == _greaterThanMedian.Count)
        {
            Median = (_lessThanMedian.Peek() + _greaterThanMedian.Peek()) / 2.0;
        }
        else if (_lessThanMedian.Count > _greaterThanMedian.Count)
        {
            Median = _lessThanMedian.Peek();
        }
        else
        {
            Median = _greaterThanMedian.Peek();
        }
    }
}
