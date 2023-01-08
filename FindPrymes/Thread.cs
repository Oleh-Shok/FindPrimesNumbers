using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public static class PrimeFinderUsingThread
{
    public static Task<int[]> FindPrimesAsyncUsingThread(int k)
    {
        var tcs = new TaskCompletionSource<int[]>();
        var primesThread = new ConcurrentBag<int>();
        ThreadPool.QueueUserWorkItem(state =>
        {
            for (int i = 2; i <= k; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primesThread.Add(i);
                }
            }
            tcs.SetResult(primesThread.ToArray());
        });
        return tcs.Task;
    }
}
