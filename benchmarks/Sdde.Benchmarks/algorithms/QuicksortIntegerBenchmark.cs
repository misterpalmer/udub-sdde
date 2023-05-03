using AutoFixture;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using Sdde.Algorithms.Sorts;

namespace Sdde.Benchmarks.Algorithms.SortingBenchmarks;

// [InProcess]
[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
[GcServer(true)]
public class QuicksortIntegerBenchmark
{
    private readonly Fixture _fixture = new();
    [Params(100, 1000, 10000)]
    public int N { get; set; }
    public int[] Numbers { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        Numbers = _fixture.CreateMany<int>(N).ToArray();
    }

    [Benchmark]
    public void QuicksortPivotLeftInteger()
    {
        QuicksortArray.Execute(Numbers, QuicksortArray.PivotMethod.Left);
    }

    [Benchmark]
    public void QuicksortPivotRightInteger()
    {
        QuicksortArray.Execute(Numbers, QuicksortArray.PivotMethod.Right);
    }

    [Benchmark]
    public void QuicksortPivotMiddleInteger()
    {
        QuicksortArray.Execute(Numbers, QuicksortArray.PivotMethod.Middle);
    }

    [Benchmark]
    public void QuicksortPivotRandomInteger()
    {
        QuicksortArray.Execute(Numbers, QuicksortArray.PivotMethod.Random);
    }

    [Benchmark]
    public void QuicksortPivotBitShiftInteger()
    {
        QuicksortArray.Execute(Numbers, QuicksortArray.PivotMethod.BitShift);
    }
}
