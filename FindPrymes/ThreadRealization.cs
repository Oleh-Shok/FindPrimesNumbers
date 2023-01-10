﻿using System.Collections.Concurrent;
using System.Threading;

public static class PrimeFinderUsingThread
{
    public static ConcurrentBag<int> FindPrimesAsyncUsingThread(int k)
    {
        var bag = new ConcurrentBag<int>();
        var threads = new List<Thread>();
        var numbersPerThread = (k - 2) / Environment.ProcessorCount;
        for (int i = 2; i <= k; i += numbersPerThread)
        {
            int start = i;
            int end = i + numbersPerThread - 1;
            if (end > k) end = k;

            var thread = new Thread(() =>
            {
                for (int j = start; j <= end; j++)
                {
                    if (IsPrime(j))
                    {
                        bag.Add(j);
                    }
                }
            });
            thread.Start();
            threads.Add(thread);
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return bag;
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
