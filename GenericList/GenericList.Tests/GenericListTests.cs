// <copyright file="NullCounter.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericList.Tests;

using NUnit.Framework.Legacy;

public class GenericListTests
{
    private static readonly int[] Actual = [1, 2, 3];
    private static readonly int[] Expected = [1, 2, 3];

    [Test]
    public void MyListAdd_ShouldReturnListWithElements()
    {
        MyList<int> list = [];
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.That(Actual, Is.EqualTo(list));
    }

    [Test]
    public void NullCounterCountNulls_ShouldReturnNumberOfNullElements()
    {
        MyList<int> list = [1, 2, 3, 0, 0];

        Assert.That(NullCounter.CountNulls(list, x => x == 0), Is.EqualTo(2));
    }

    [Test]
    public void Enumerator_ShouldWorkWithForeach()
    {
        MyList<int> list = [1, 2, 3];

        var result = new List<int>();
        foreach (var item in list)
        {
            result.Add(item);
        }

        Assert.That(result, Is.EqualTo(Expected).AsCollection);
    }
}
