``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1817/21H2/SunValley)
Intel Xeon E-2176M CPU 2.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  Job-AEPBIB : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Server=True  

```
|                        Method |     N |             Mean |          Error |         StdDev |         StdErr |              Min |              Max |               Q1 |               Q3 |           Median |         Op/s | Rank |    Gen0 | Allocated |
|------------------------------ |------ |-----------------:|---------------:|---------------:|---------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|-------------:|-----:|--------:|----------:|
| QuicksortPivotBitShiftInteger |   100 |         1.049 μs |      0.0208 μs |      0.0222 μs |      0.0052 μs |         1.023 μs |         1.083 μs |         1.030 μs |         1.070 μs |         1.040 μs | 952,947.0634 |    1 |       - |         - |
|   QuicksortPivotMiddleInteger |   100 |         1.071 μs |      0.0206 μs |      0.0314 μs |      0.0056 μs |         1.040 μs |         1.164 μs |         1.047 μs |         1.088 μs |         1.059 μs | 933,506.6574 |    1 |       - |         - |
|     QuicksortPivotLeftInteger |   100 |         5.213 μs |      0.0826 μs |      0.0772 μs |      0.0199 μs |         5.121 μs |         5.370 μs |         5.163 μs |         5.274 μs |         5.177 μs | 191,811.4478 |    2 |       - |         - |
|    QuicksortPivotRightInteger |   100 |         6.233 μs |      0.0495 μs |      0.0413 μs |      0.0115 μs |         6.169 μs |         6.309 μs |         6.209 μs |         6.245 μs |         6.234 μs | 160,438.4662 |    3 |       - |         - |
| QuicksortPivotBitShiftInteger |  1000 |        12.232 μs |      0.2432 μs |      0.4323 μs |      0.0684 μs |        11.749 μs |        13.650 μs |        11.903 μs |        12.496 μs |        12.115 μs |  81,755.0334 |    4 |       - |         - |
|   QuicksortPivotMiddleInteger |  1000 |        12.344 μs |      0.2403 μs |      0.3369 μs |      0.0648 μs |        11.808 μs |        13.006 μs |        11.987 μs |        12.543 μs |        12.396 μs |  81,010.7479 |    4 |       - |         - |
|   QuicksortPivotRandomInteger |   100 |        27.947 μs |      0.3273 μs |      0.3062 μs |      0.0791 μs |        27.558 μs |        28.355 μs |        27.604 μs |        28.235 μs |        27.951 μs |  35,781.9707 |    5 |  0.2441 |   21584 B |
| QuicksortPivotBitShiftStrings |   100 |        31.115 μs |      0.6769 μs |      1.9957 μs |      0.1996 μs |        27.972 μs |        36.444 μs |        29.260 μs |        32.222 μs |        31.621 μs |  32,138.7704 |    6 |       - |         - |
|   QuicksortPivotMiddleStrings |   100 |        31.664 μs |      0.5475 μs |      1.0806 μs |      0.1560 μs |        28.990 μs |        34.195 μs |        31.210 μs |        32.101 μs |        31.628 μs |  31,581.6588 |    6 |       - |         - |
|   QuicksortPivotRandomStrings |   100 |        61.469 μs |      1.2075 μs |      1.1859 μs |      0.2965 μs |        60.266 μs |        63.830 μs |        60.595 μs |        61.974 μs |        60.972 μs |  16,268.3023 |    7 |  0.2441 |   21584 B |
| QuicksortPivotBitShiftInteger | 10000 |       159.065 μs |      1.9745 μs |      1.8469 μs |      0.4769 μs |       157.078 μs |       162.707 μs |       157.696 μs |       160.166 μs |       158.339 μs |   6,286.7320 |    8 |       - |         - |
|   QuicksortPivotMiddleInteger | 10000 |       163.431 μs |      2.7795 μs |      4.5667 μs |      0.7719 μs |       158.630 μs |       175.723 μs |       160.401 μs |       165.241 μs |       161.899 μs |   6,118.8076 |    9 |       - |         - |
|     QuicksortPivotLeftStrings |   100 |       233.740 μs |      4.6146 μs |      5.6671 μs |      1.2082 μs |       216.768 μs |       241.739 μs |       232.514 μs |       237.459 μs |       234.665 μs |   4,278.2593 |   10 |       - |         - |
|    QuicksortPivotRightStrings |   100 |       236.369 μs |      4.7116 μs |      5.6088 μs |      1.2239 μs |       222.808 μs |       244.031 μs |       235.928 μs |       239.371 μs |       237.542 μs |   4,230.6780 |   10 |       - |         - |
|   QuicksortPivotRandomInteger |  1000 |       275.557 μs |      5.4453 μs |      9.8191 μs |      1.5335 μs |       262.303 μs |       299.572 μs |       267.451 μs |       281.460 μs |       274.610 μs |   3,629.0176 |   11 |  2.4414 |  213712 B |
|     QuicksortPivotLeftInteger |  1000 |       390.643 μs |      4.3475 μs |      3.8540 μs |      1.0300 μs |       384.147 μs |       396.649 μs |       388.024 μs |       392.568 μs |       390.829 μs |   2,559.8799 |   12 |       - |         - |
|    QuicksortPivotRightInteger |  1000 |       508.377 μs |      7.9772 μs |      7.0716 μs |      1.8900 μs |       501.153 μs |       522.604 μs |       502.596 μs |       514.056 μs |       505.231 μs |   1,967.0438 |   13 |       - |         - |
|   QuicksortPivotMiddleStrings |  1000 |       510.041 μs |     10.1950 μs |     21.7264 μs |      2.9296 μs |       484.993 μs |       572.255 μs |       491.011 μs |       524.857 μs |       504.878 μs |   1,960.6283 |   13 |       - |         - |
| QuicksortPivotBitShiftStrings |  1000 |       511.787 μs |      9.1070 μs |      8.9443 μs |      2.2361 μs |       495.960 μs |       529.462 μs |       506.283 μs |       516.762 μs |       512.846 μs |   1,953.9373 |   13 |       - |         - |
|   QuicksortPivotRandomStrings |  1000 |       840.916 μs |     16.4457 μs |     35.4011 μs |      4.7307 μs |       788.859 μs |       936.193 μs |       812.953 μs |       863.686 μs |       836.804 μs |   1,189.1791 |   14 |  1.9531 |  213712 B |
|   QuicksortPivotRandomInteger | 10000 |     2,813.714 μs |     25.9892 μs |     23.0388 μs |      6.1574 μs |     2,778.844 μs |     2,857.650 μs |     2,796.639 μs |     2,827.672 μs |     2,811.799 μs |     355.4022 |   15 | 23.4375 | 2124050 B |
|   QuicksortPivotMiddleStrings | 10000 |     6,908.393 μs |    135.6717 μs |    166.6171 μs |     35.5229 μs |     6,602.743 μs |     7,206.996 μs |     6,777.607 μs |     7,062.305 μs |     6,900.325 μs |     144.7515 |   16 |       - |       4 B |
| QuicksortPivotBitShiftStrings | 10000 |     7,256.466 μs |    144.6245 μs |    135.2818 μs |     34.9296 μs |     6,975.584 μs |     7,456.762 μs |     7,159.884 μs |     7,371.896 μs |     7,241.035 μs |     137.8081 |   17 |       - |       4 B |
|   QuicksortPivotRandomStrings | 10000 |    11,207.391 μs |    218.3605 μs |    358.7726 μs |     60.6436 μs |    10,756.856 μs |    11,955.450 μs |    10,932.234 μs |    11,496.177 μs |    11,122.830 μs |      89.2268 |   18 | 15.6250 | 2124056 B |
|     QuicksortPivotLeftStrings |  1000 |    22,253.602 μs |    419.1945 μs |    573.7982 μs |    112.5311 μs |    21,386.984 μs |    23,509.716 μs |    21,883.616 μs |    22,407.194 μs |    22,186.211 μs |      44.9365 |   19 |       - |      16 B |
|    QuicksortPivotRightStrings |  1000 |    23,328.189 μs |    463.1893 μs |    966.8486 μs |    132.8069 μs |    21,463.481 μs |    25,347.678 μs |    22,915.138 μs |    23,871.703 μs |    23,472.631 μs |      42.8666 |   20 |       - |      16 B |
|     QuicksortPivotLeftInteger | 10000 |    37,934.809 μs |    669.9031 μs |  1,207.9735 μs |    188.6538 μs |    36,750.706 μs |    41,707.706 μs |    37,125.062 μs |    38,383.019 μs |    37,528.938 μs |      26.3610 |   21 |       - |      32 B |
|    QuicksortPivotRightInteger | 10000 |    49,583.726 μs |    727.5577 μs |    680.5579 μs |    175.7193 μs |    48,847.009 μs |    50,976.103 μs |    48,999.516 μs |    50,047.156 μs |    49,574.709 μs |      20.1679 |   22 |       - |      32 B |
|     QuicksortPivotLeftStrings | 10000 | 2,443,801.944 μs | 37,926.9421 μs | 33,621.2463 μs |  8,985.6560 μs | 2,382,753.019 μs | 2,496,587.087 μs | 2,428,938.820 μs | 2,458,829.283 μs | 2,448,868.747 μs |       0.4092 |   23 |       - |      32 B |
|    QuicksortPivotRightStrings | 10000 | 2,467,579.780 μs | 48,767.4407 μs | 59,890.7967 μs | 12,768.7608 μs | 2,366,027.772 μs | 2,587,565.247 μs | 2,420,212.358 μs | 2,515,206.061 μs | 2,453,769.691 μs |       0.4053 |   23 |       - |      32 B |
