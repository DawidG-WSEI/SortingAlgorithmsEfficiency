using UltimateSortingAlgorithmsTestWithBenchmark.SortingAlgorithm;
using BenchmarkDotNet;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

var summary = BenchmarkRunner.Run<MyBenchmark>();

[MemoryDiagnoser]
public class MyBenchmark()
{
    public int[]? _source;
    SortingAlgorithm sa = new SortingAlgorithm();

    [Params(100, 1_000, 100_000)]
    public int ListSize;

    [GlobalSetup]
    public void Setup()
    {
        _source = Generators.GenerateFewUnique(ListSize);
    }

    [Benchmark]
    public void InsertionSort()
    {
        var list = (int[])_source!.Clone();
        sa.InsertionSort(list);
    }

    [Benchmark]
    public void MergeSort()
    {
        var list = (int[])_source!.Clone();
        sa.MergeSort(list, 0, list.Length - 1);
    }

    [Benchmark]
    public void QuickSort()
    {
        var list = (int[])_source!.Clone();
        sa.QuickSort(list, 0, list.Length - 1);
    }

    [Benchmark]
    public void CSharpArraySort()
    {
        var list = (int[])_source!.Clone();
        sa.CSharpArraySort(list);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _source = [];
    }
}



