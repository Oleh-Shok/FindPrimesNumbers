using System.Collections.Concurrent;
using System.Threading.Tasks;

public static class PrimeFinderUsingParallelForEach
{
    public static async Task<List<int>> FindPrimesAsyncUsingParallelForEach(int n)
    {
        var primesParallelForEach = new ConcurrentBag<int>();
        IsPrimeCheck checker = new IsPrimeCheck();
        await Task.Run(() =>
        {
            Parallel.ForEach(Enumerable.Range(2, n - 1), number =>
            {
                if (checker.IsPrime(number))
                {
                    primesParallelForEach.Add(number);
                }
            });
        });
        return primesParallelForEach.ToList();
    }
}

