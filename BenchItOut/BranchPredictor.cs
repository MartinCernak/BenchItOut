using BenchmarkDotNet.Attributes;

namespace BenchItOut;

[MarkdownExporter]
public class BranchPredictor
{
    private int[] _predictableValues = null!;
    private int[] _randomValues = null!;

    [GlobalSetup]
    public void Setup()
    {
        _predictableValues = new int[Upper];
        _randomValues = new int[Upper];

        var random = new Random(42);
        for (var i = 0; i < Upper; i++)
        {
            _predictableValues[i] = i & 1;
            _randomValues[i] = random.Next(2);
        }
    }

    [Params(100, 1_000, 10_000)]
    public int Upper { get; set; }

    [Benchmark(Baseline = true)]
    public int Predictable()
    {
        var sum = 0;
        for (var i = 0; i < _predictableValues.Length; i++)
        {
            if (_predictableValues[i] != 0)
                sum++;
        }

        return sum;
    }

    [Benchmark]
    public int Random()
    {
        var sum = 0;
        for (var i = 0; i < _randomValues.Length; i++)
        {
            if (_randomValues[i] != 0)
                sum++;
        }

        return sum;
    }
}