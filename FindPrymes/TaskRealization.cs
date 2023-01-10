using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public static class PrimeFinderUsingTask
{
    public static async Task<int[]> FindPrimesAsyncUsingTask(int n)
    {
        var primesTask = new ConcurrentBag<int>();
        IsPrimeCheck checker = new IsPrimeCheck();

        await Task.WhenAll(
            Enumerable.Range(2, n - 1).Select(i =>
            {
                if (checker.IsPrime(i))
                {
                    primesTask.Add(i);
                }
                return Task.CompletedTask;
            })
        );

        return primesTask.ToArray();
    }
}