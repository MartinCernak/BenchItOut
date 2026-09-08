using BenchmarkDotNet.Attributes;

namespace BenchItOut;

public class SingleThreadCpuBound
{
    [Params(10, 25, 40)]
    public int N;
    
    [Benchmark]
    public int Fib() => Helpers.Fib(N);
}