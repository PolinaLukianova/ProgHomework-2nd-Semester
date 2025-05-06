// <copyright file="GenericSkipListTests.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericSkipList.Tests;

public class GenericSkipListTests
{
    private static readonly int[] ExpectedForRemove = [1, 2, 4, 5];
    private static readonly int[] ExpectedForAdd = [1, 2, 3, 4, 5, 10, 7];
    private static readonly int[] ExpectedForRemoveAt = [2, 3, 4, 5];
    private static readonly int[] ExpectedForCopyTo = [1, 2, 1, 2, 3, 4, 5];

    private SkipList<int> intSkipList;
    private SkipList<string> strSkipList;

    [SetUp]
    public void Setup()
    {
        this.intSkipList = [1, 2, 3, 4, 5];
        this.strSkipList = ["abc", "qwe", "zx", "p", "tp"];
    }

    [Test]
    public void Constructor_NewListShouldBeEmpty()
    {
        SkipList<int> emptySkipList = [];
        Assert.That(emptySkipList, Is.Empty);
        Assert.That(emptySkipList.IsReadOnly, Is.False);
    }

    [Test]
    public void Count_ShoulReturnNumberOfElements()
    {
        Assert.That(this.intSkipList.Count, Is.EqualTo(5));
    }

    [Test]
    public void Indexer_ShouldReturnCorrectValues() =>
        Assert.That(
            (this.intSkipList[0], this.intSkipList[2], this.intSkipList[4]),
            Is.EqualTo((1, 3, 5)));

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
    public void Insert_ShouldInsertItemInCorrectPlace()
    {
        this.intSkipList.Insert(0, 5);
        this.strSkipList.Insert(2, "qqq");
        Assert.Multiple(() =>
        {
            Assert.That(this.intSkipList[0], Is.EqualTo(5));
            Assert.That(this.strSkipList[2], Is.EqualTo("qqq"));
        });
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

    [Test]
    public void RemoveAt_ShouldRemoveItemByIndex()
    {
        this.intSkipList.RemoveAt(0);
        Assert.That(this.intSkipList, Is.EqualTo(ExpectedForRemoveAt));
    }

    [Test]
    public void Clear_ShouldReturnEmptyList()
    {
        this.intSkipList.Clear();
        Assert.That(this.intSkipList, Is.Empty);
    }

    [Test]
    public void Contains_ShouldReturnTrueForAddedItem()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.intSkipList.Contains(3), Is.True);
            Assert.That(this.intSkipList.Contains(10), Is.False);

            Assert.That(this.strSkipList.Contains("abc"), Is.True);
            Assert.That(this.strSkipList.Contains("qwerty"), Is.False);
        });
    }

    [Test]
    public void CopyTo_ShouldCopyAllItems()
    {
        var arrayFromBeg = new int[5];
        this.intSkipList.CopyTo(arrayFromBeg, 0);

        var arrayFromMid = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        this.intSkipList.CopyTo(arrayFromMid, 2);

        Assert.Multiple(() =>
        {
            Assert.That(arrayFromBeg, Is.EquivalentTo(this.intSkipList));
            Assert.That(arrayFromMid, Is.EquivalentTo(ExpectedForCopyTo));
        });
    }

    [Test]
    public void IndexOf_ShouldReturnIndexOfElement()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.intSkipList.IndexOf(1), Is.EqualTo(0));
            Assert.That(this.intSkipList.IndexOf(5), Is.EqualTo(4));

            Assert.That(this.strSkipList.IndexOf("qwe"), Is.EqualTo(1));
            Assert.That(this.strSkipList.IndexOf("p"), Is.EqualTo(3));
        });
    }
}
