## Homework

Use the Quicksort code you wrote in the lab as a starting point.
For inputs, generate a sorted array of 10,000 elements, and an unsorted array of 10,000 elements.


1. Create a PickAPivotIndex function to always pick the first (or last) element in the start and end range.
- In other words, PickAPivotIndex simply returns start (or end).
- Run your quick sort and note the time.
- You can adjust the size of input to see how that affects overall time.


2. Now modify PickAPivotIndex to pick:
- middle index

  OR

- or a random index between start and end
- Run your quick sort on the same input as above, and note the time.
- How do the two times from #1 and #2 compare?
