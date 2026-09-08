using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace BenchItOut;

[MarkdownExporter]
public class MultiThreadCpuBound
{
    [Params(1, 2, 4, 8)]
    public int DegreeOfParallelism;

    [Params(1000)]
    public int Operations;

    private byte[] _data = null!;
    private byte[][] _outputs = null!;

    [GlobalSetup]
    public void Setup()
    {
        _data = new byte[1000];
        _outputs = Enumerable.Range(0, Operations)
            .Select(_ => new byte[SHA256.HashSizeInBytes])
            .ToArray();
    }

    [Benchmark]
    public void ParallelSha256()
    {
        Parallel.For(0, Operations,
            new ParallelOptions { MaxDegreeOfParallelism = DegreeOfParallelism },
            i => SHA256.TryHashData(_data, _outputs[i], out _));
    }
}