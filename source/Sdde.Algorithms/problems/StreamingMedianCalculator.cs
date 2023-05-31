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
