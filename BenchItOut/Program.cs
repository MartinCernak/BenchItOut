using BenchItOut;
using BenchmarkDotNet.Running;
using ConsoleAppFramework;

var app = ConsoleApp.Create();

app.Add("single-thread-crypto", () => BenchmarkRunner.Run<SingleThreadCrypto>());
app.Add("single-thread-cpu-bound", () => BenchmarkRunner.Run<SingleThreadCpuBound>());
app.Add("multi-thread-cpu-bound", () => BenchmarkRunner.Run<MultiThreadCpuBound>());
app.Add("", () =>
{
    BenchmarkRunner.Run<SingleThreadCrypto>();
    BenchmarkRunner.Run<SingleThreadCpuBound>();
    BenchmarkRunner.Run<MultiThreadCpuBound>();
});

app.Run(args);
