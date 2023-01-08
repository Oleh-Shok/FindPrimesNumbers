using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public static class PrimeFinderUsingTask
{
    public static async Task<int[]> FindPrimesAsyncUsingTask(int n)
    {
        var primesTask = new ConcurrentBag<int>();

        await Task.WhenAll(
            Enumerable.Range(2, n - 1).Select(i =>
            {
                if (IsPrime(i))
                {
                    primesTask.Add(i);
                }
                return Task.CompletedTask;
            })
        );

        return primesTask.ToArray();
    }

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}