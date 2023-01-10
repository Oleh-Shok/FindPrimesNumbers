using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public static class PrimeFinderUsingTask
{
    public static async Task<List<int>> FindPrimesAsyncUsingTask(int m)
    {
        var tasks = new List<Task<List<int>>>();
        var segmentSize = 100;
        for (var i = 2; i < m; i += segmentSize)
        {
            var segmentStart = i;
            var segmentEnd = Math.Min(i + segmentSize, m);
            tasks.Add(Task.Run(() => FindPrimesInRange(segmentStart, segmentEnd)));
        }
        var results = await Task.WhenAll(tasks);
        return results.SelectMany(x => x).ToList();
    }

    private static List<int> FindPrimesInRange(int start, int end)
    {
        var primes = new List<int>();
        IsPrimeCheck checker = new IsPrimeCheck();
        for (var i = start; i < end; i++)
        {
            if (checker.IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes;
    }
}