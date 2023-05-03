- You will be provided with a starting input of [1, 16, 7, 9, 14, 27, 34, 15, 61, 43, 52]
- Write a class StreamingMedianCalculator that takes this starting input and has a method AddNumberAndReturnMedian.
- AddNumberAndReturnMedian should take in an integer, and return the median of all the numbers seen so far as a double.
double AddNumberAndReturnMedian(int i)
Example:
1. AddNumberAndReturnMedian ( 11 ) 🡨 return the median of ALL numbers given so far (initial numbers and 11)
2. AddNumberAndReturnMedian ( 22 ) 🡨 return the median of ALL numbers given so far (initial numbers and 11 and 22)
3. AddNumberAndReturnMedian ( 15 ) 🡨 return the median of ALL numbers given so far (initial numbers and 11 and 22 and 15)
