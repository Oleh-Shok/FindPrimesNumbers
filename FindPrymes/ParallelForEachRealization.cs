using System.Collections.Concurrent;
using System.Threading.Tasks;

public static class PrimeFinderUsingParallelForEach
{
    public static async Task<List<int>> FindPrimesAsyncUsingParallelForEach(int n)
    {
        var primesParallelForEach = new ConcurrentBag<int>();
        await Task.Run(() =>
        {
            Parallel.ForEach(Enumerable.Range(2, n - 1), number =>
            {
                if (IsPrime(number))
                {
                    primesParallelForEach.Add(number);
                }
            });
        });
        return primesParallelForEach.ToList();
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

