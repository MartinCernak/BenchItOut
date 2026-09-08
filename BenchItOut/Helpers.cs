namespace BenchItOut;

public static class Helpers
{
    public static int Fib(int n)
    {
        if (n <= 1)
            return n;
        return Fib(n - 1) + Fib(n - 2);
    }
}