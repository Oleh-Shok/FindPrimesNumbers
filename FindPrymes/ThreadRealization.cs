using System.Collections.Concurrent;
using System.Threading;

public static class PrimeFinderUsingThread
{
    public static ConcurrentBag<int> FindPrimesAsyncUsingThread(int k)
    {
        var bag = new ConcurrentBag<int>();
        var threads = new List<Thread>();
        var numbersPerThread = (k - 2) / Environment.ProcessorCount;
        IsPrimeCheck checker = new IsPrimeCheck();
        for (int i = 2; i <= k; i += numbersPerThread)
        {
            int start = i;
            int end = i + numbersPerThread - 1;
            if (end > k) end = k;

            var thread = new Thread(() =>
            {
                for (int j = start; j <= end; j++)
                {
                    if (checker.IsPrime(j))
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
}
