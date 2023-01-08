using System.Collections.Concurrent;
using System.Threading;

public static class PrimeFinderUsingThread
{
    public static ConcurrentBag<int> FindPrimesAsyncUsingThread(int k)
    {
        var bag = new ConcurrentBag<int>();
        var thread = new Thread(() =>
        {
            for (int i = 2; i <= k; i++)
            {
                if (IsPrime(i))
                {
                    bag.Add(i);
                }
            }
        });
        thread.Start();
        thread.Join();
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
