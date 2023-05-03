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
public class QuicksortStringBenchmark
{
    private readonly Fixture _fixture = new();
    [Params(100, 1000, 10000)]
    public int N { get; set; }
    public string[] Words { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        Words = _fixture.CreateMany<string>(N).ToArray();
    }

    [Benchmark]
    public void QuicksortPivotLeftStrings()
    {
        QuicksortArray.Execute(Words, QuicksortArray.PivotMethod.Left);
    }

    [Benchmark]
    public void QuicksortPivotRightStrings()
    {
        QuicksortArray.Execute(Words, QuicksortArray.PivotMethod.Right);
    }

    [Benchmark]
    public void QuicksortPivotMiddleStrings()
    {
        QuicksortArray.Execute(Words, QuicksortArray.PivotMethod.Middle);
    }

    [Benchmark]
    public void QuicksortPivotRandomStrings()
    {
        QuicksortArray.Execute(Words, QuicksortArray.PivotMethod.Random);
    }

    [Benchmark]
    public void QuicksortPivotBitShiftStrings()
    {
        QuicksortArray.Execute(Words, QuicksortArray.PivotMethod.BitShift);
    }
}
