# BenchItOut

Simple benchmarking project based on *BenchmarkDotNet*

## Requirements
- .NET 10 SDK

## Run

Run all benchmarks:

```bash
dotnet run --project BenchItOut
```

Run an individual benchmark:

```bash
dotnet run --project BenchItOut -- single-thread-crypto
dotnet run --project BenchItOut -- single-thread-cpu-bound
dotnet run --project BenchItOut -- multi-thread-cpu-bound
```

Benchmark results are written to `BenchmarkDotNet.Artifacts`.
