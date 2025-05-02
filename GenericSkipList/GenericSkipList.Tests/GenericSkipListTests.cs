// <copyright file="GenericSkipListTests.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericSkipList.Tests;

public class GenericSkipListTests
{
    private static readonly int[] ExpectedForRemove = [1, 2, 4, 5];
    private static readonly int[] ExpectedForAdd = [1, 2, 3, 4, 5, 10, 7];
    private SkipList<int> intSkipList;
    private SkipList<string> strSkipList;

    [SetUp]
    public void Setup()
    {
        this.intSkipList = [1, 2, 3, 4, 5];
        this.strSkipList = ["abc", "qwe", "zx", "p", "tp"];
    }

    [Test]
    public void Indexer_ShouldReturnCorrectValues()
    {
        Assert.That((this.intSkipList[0], this.intSkipList[2], this.intSkipList[4]), Is.EqualTo((1, 3, 5)));
    }

    [Test]
    public void Add_ShouldReturnListWithAddedElements()
    {
        var newList = new List<int>();
        this.intSkipList.Add(10);
        this.intSkipList.Add(7);
        foreach (var item in this.intSkipList)
        {
            newList.Add(item);
        }

        Assert.That(newList, Is.EqualTo(ExpectedForAdd));
    }

    [Test]
    public void Remove_ShouldReturnListWithoutRemovedElements()
    {
        var newList = new List<int>();
        this.intSkipList.Remove(3);
        foreach (var item in this.intSkipList)
        {
            newList.Add(item);
        }

        Assert.That(newList, Is.EqualTo(ExpectedForRemove));
    }
}
