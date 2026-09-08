using BenchItOut;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SingleThreadCrypto>();
BenchmarkRunner.Run<SingleThreadCpuBound>();
BenchmarkRunner.Run<MultiThreadCpuBound>();