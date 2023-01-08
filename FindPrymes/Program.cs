using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

// Parallel.ForEach method
int n = 100;
var primesParallelForEach = await PrimeFinderUsingParallelForEach.FindPrimesAsyncUsingParallelForEach(n);

Console.WriteLine("Prime numbers using realization Parallel.ForEach from 1 to " + n + ":");
foreach (int primeNumberParallelForEach in primesParallelForEach)
{
    Console.WriteLine(primeNumberParallelForEach);
}

// Task method
int m = 100;
var primesTask = await PrimeFinderUsingTask.FindPrimesAsyncUsingTask(m);

Console.WriteLine("Prime numbers using realization Task from 1 to " + m + ":");
foreach (int primeNumberTask in primesTask)
{
    Console.WriteLine(primeNumberTask);
}

// Thread method
int k = 100;
var primesThread = PrimeFinderUsingThread.FindPrimesAsyncUsingThread(k);

Console.WriteLine("Prime numbers using realization Thread from 1 to " + k + ":");
foreach (int primeNumberThread in primesThread)
{
    Console.WriteLine(primeNumberThread);
}

// The Sieve of Eratosthenes method
int l = 100;
var primesEratosthenes = await PrimeFinderUsingEratosthenes.FindPrimesAsyncUsingEratosthenes(l);

Console.WriteLine("Prime numbers using realization The Sieve of Eratosthenes from 1 to " + l + ":");
foreach (int primeNumberEratosthenes in primesEratosthenes)
{
    Console.WriteLine(primeNumberEratosthenes);
}
