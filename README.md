# BenchItOut

BenchItOut is a collection of .NET microbenchmarks built with
[BenchmarkDotNet](https://benchmarkdotnet.org/). The project explores
single-threaded and multi-threaded CPU workloads, cryptographic hashing, and
branch prediction.

## Requirements

- .NET SDK 10.0 or later
- A supported operating system for .NET 10

The project currently targets `net10.0`.

## Dependencies

NuGet dependencies are declared in
[`BenchItOut/BenchItOut.csproj`](BenchItOut/BenchItOut.csproj):

- `BenchmarkDotNet` `0.15.8` - runs and measures the benchmarks.
- `ConsoleAppFramework` `5.7.13` - provides the command-line entry point.

Restore the dependencies from the repository root:

```bash
dotnet restore
```

## Running the benchmarks

Run a specific benchmark suite:

```bash
dotnet run --configuration Release --project BenchItOut/BenchItOut.csproj -- single-thread-crypto
dotnet run --configuration Release --project BenchItOut/BenchItOut.csproj -- single-thread-cpu-bound
dotnet run --configuration Release --project BenchItOut/BenchItOut.csproj -- multi-thread-cpu-bound
dotnet run --configuration Release --project BenchItOut/BenchItOut.csproj -- branch-predictor
```

Run all benchmark suites:

```bash
dotnet run --configuration Release --project BenchItOut/BenchItOut.csproj
```

Benchmarks should be run using the `Release` configuration. BenchmarkDotNet
then builds an optimized benchmark executable and performs warmup and
measurement iterations automatically. Do not use a debugger when collecting
final results.

## Benchmark suites

| Command | Description |
| --- | --- |
| `single-thread-crypto` | Compares MD5 and SHA-256 hashing for different input sizes. |
| `single-thread-cpu-bound` | Measures recursive Fibonacci calculations on one thread. |
| `multi-thread-cpu-bound` | Measures parallel Fibonacci calculations with different degrees of parallelism and operation counts. |
| `branch-predictor` | Compares a predictable alternating branch with a branch driven by pre-generated random input. |

## Results

BenchmarkDotNet writes reports and diagnostic files to
`BenchmarkDotNet.Artifacts/`. Reports are typically available as Markdown,
CSV, and HTML files under `BenchmarkDotNet.Artifacts/results/`.

Generated build output is stored in `bin/` and `obj/` and is ignored by Git.

## Build

Build the project without running benchmarks:

```bash
dotnet build BenchItOut/BenchItOut.csproj
```

For a release build:

```bash
dotnet build BenchItOut/BenchItOut.csproj --configuration Release
```
