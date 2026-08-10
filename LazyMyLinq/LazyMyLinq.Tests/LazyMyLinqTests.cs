// <copyright file="MyLinq.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace LazyMyLinq.Tests;

public class LazyMyLinqTests
{
    private static readonly int[] ExpectedTake = [1, 2, 3];
    private static readonly int[] ExpectedSkip = [4, 5, 6, 7];
    private static readonly int[] ExpectedGetPrimes = [2, 3, 5, 7];
    private static readonly int[] ExpectedGetPrimesFromTo = [7, 11, 13, 17];

    [Test]
    public void Take_ShouldReturnFirstThreeElements()
    {
        int[] seq = [1, 2, 3, 4, 5, 6, 7];

        Assert.That(seq.Take(3), Is.EqualTo(ExpectedTake));
    }

    [Test]
    public void Skip_ShouldReturnElementsStartingFromThird()
    {
        int[] seq = [1, 2, 3, 4, 5, 6, 7];

        Assert.That(seq.Skip(3), Is.EqualTo(ExpectedSkip));
    }

    [Test]
    public void GetPrimes_ShouldReturnSequenceOfPrimeNumbersUpToFourthElement()
        => Assert.That(MyLinq.GetPrimes().Take(4), Is.EqualTo(ExpectedGetPrimes));

    [Test]
    public void GetPrimes_ShouldReturnSequenceOfPrimeNumbersFromThirdToSeventhElement()
        => Assert.That(MyLinq.GetPrimes().Skip(3).Take(4), Is.EqualTo(ExpectedGetPrimesFromTo));
}
