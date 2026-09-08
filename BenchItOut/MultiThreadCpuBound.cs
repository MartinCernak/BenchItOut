using BenchmarkDotNet.Attributes;

namespace BenchItOut;

[MarkdownExporter]
public class MultiThreadCpuBound
{
    [Params(1, 2, 4, 8)]
    public int DegreeOfParallelism;

    [Params(30)]
    public int N;

    [Params(16, 32, 64)]
    public int Operations;

    private int[] _results = null!;

    [GlobalSetup]
    public void Setup() => _results = new int[Operations];

    [Benchmark]
    public void ParallelFib()
    {
        Parallel.For(0, Operations,
            new ParallelOptions { MaxDegreeOfParallelism = DegreeOfParallelism },
            i => _results[i] = Helpers.Fib(N));
    }
}