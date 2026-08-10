// <copyright file="MyLinq.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace LazyMyLinq;

/// <summary>
/// Static class MyLinq.
/// </summary>
public static class MyLinq
{
    /// <summary>
    /// Returning an infinite sequence of prime numbers.
    /// </summary>
    /// <returns>Sequence of prime numbers.</returns>
    public static IEnumerable<int> GetPrimes()
    {
        yield return 2;
        var primes = new List<int> { 2 };
        int next = 3;

        while (true)
        {
            bool isPrime = true;

            for (int i = 0; i < primes.Count; ++i)
            {
                if (next % primes[i] == 0)
                {
                    isPrime = false;
                    break;
                }

                if (primes[i] * primes[i] > next)
                {
                    break;
                }
            }

            if (isPrime)
            {
                primes.Add(next);
                yield return next;
            }

            next += 2;
        }
    }

    /// <summary>
    /// Returns a sequence of the first n elements
    /// of the sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in
    /// sequence.</typeparam>
    /// <param name="seq">Input sequence.</param>
    /// <param name="maxCount">The number of elemnts
    /// to take from the sequence.</param>
    /// <returns>A sequence of the first n elements.
    /// </returns>
    public static IEnumerable<T> Take<T>(
        this IEnumerable<T> seq, int maxCount)
    {
        int count = 0;

        foreach (var item in seq)
        {
            if (count >= maxCount)
            {
                yield break;
            }

            yield return item;
            count++;
        }
    }

    /// <summary>
    /// Returns a sequence equal to the first n elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in
    /// sequence.</typeparam>
    /// <param name="seq">Input sequence.</param>
    /// <param name="minCount">The number of elements
    /// to skip.</param>
    /// <returns>A sequence equal to the first n elements.
    /// </returns>
    public static IEnumerable<T> Skip<T>(
        this IEnumerable<T> seq, int minCount)
    {
        int count = 0;

        foreach (var item in seq)
        {
            if (count >= minCount)
            {
                yield return item;
            }

            count++;
        }
    }
}
