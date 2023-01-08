using System;
using System.Collections.Generic;

public static class PrimeFinderUsingEratosthenes
{
    public static Task<int[]> FindPrimesAsyncUsingEratosthenes(int l)
    {
        var tcs = new TaskCompletionSource<int[]>();
        ThreadPool.QueueUserWorkItem(state =>
        {
            bool[] isPrime = new bool[l + 1];
            for (int i = 2; i <= l; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i <= l; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j <= l; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            List<int> primesEratosthenes = new List<int>();
            for (int i = 2; i <= l; i++)
            {
                if (isPrime[i])
                {
                    primesEratosthenes.Add(i);
                }
            }

            tcs.SetResult(primesEratosthenes.ToArray());
        });
        return tcs.Task;
    }
}

