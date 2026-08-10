// <copyright file="SkipList.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericSkipList;

using System.Collections;

/// <summary>
/// Skip list data structure.
/// </summary>
/// <typeparam name="T">The type of items in the skip list.</typeparam>
public class SkipList<T> : IList<T>
{
    private const double Probability = 0.5;
    private readonly int maxLevel;
    private readonly Random random = new();
    private Node<T> head;
    private int count;
    private int changes = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    public SkipList()
    {
        this.maxLevel = 16;
        this.head = new Node<T>(this.maxLevel);
        for (int i = 0; i <= this.maxLevel; i++)
        {
            this.head.SkipLength[i] = 1;
        }
    }

    /// <summary>
    /// Gets the number of nodes in a skip list.
    /// </summary>
    public int Count => this.count;

    /// <summary>
    /// Gets a value indicating whether the skip list is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets or sets the item by index.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <returns>The item by index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws when index is out of range.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index));
            }

            var current = this.head;
            var passed = 0;

            for (var i = this.maxLevel; i >= 0; --i)
            {
                while (current.Next[i] != null
                       && passed + current.SkipLength[i] <= index)
                {
                    passed += current.SkipLength[i];
                    current = current.Next[i];
                }
            }

            return current.Next[0].Value!;
        }

        set
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index));
            }

            var current = this.head;
            var passed = 0;

            for (var i = this.maxLevel; i >= 0; --i)
            {
                while (current.Next[i] != null
                       && passed + current.SkipLength[i] <= index)
                {
                    passed += current.SkipLength[i];
                    current = current.Next[i];
                }
            }

            current.Next[0].Value = value;
            this.changes++;
        }
    }

    /// <summary>
    /// Adds an item at the end of skip list.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Add(T item)
    {
        this.Insert(this.count, item);
    }

    /// <summary>
    /// Insert an item by index.
    /// </summary>
    /// <param name="index">The index at which to insert the item.</param>
    /// <param name="item">The item to insert.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws when index is out of range.</exception>
    public void Insert(int index, T item)
    {
        if (index < 0 || index > this.count)
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(index));
        }

        var update = new Node<T>[this.maxLevel + 1];
        var current = this.head;
        var steps = new int[this.maxLevel + 1];
        var totalSteps = 0;

        for (var i = this.maxLevel; i >= 0; --i)
        {
            while (current.Next[i] != null
               && totalSteps + current.SkipLength[i] <= index)
            {
                totalSteps += current.SkipLength[i];
                current = current.Next[i];
            }

            update[i] = current;
            steps[i] = totalSteps;
        }

        var newNodeLevel = this.RandomLevel();
        var newNode = new Node<T>(newNodeLevel, item);

        for (var i = 0; i <= newNodeLevel; ++i)
        {
            newNode.Next[i] = update[i].Next[i];
            update[i].Next[i] = newNode;

            newNode.SkipLength[i] = update[i].SkipLength[i] - (totalSteps - steps[i]);
            update[i].SkipLength[i] = (totalSteps - steps[i]) + 1;
        }

        for (int i = newNodeLevel + 1; i <= this.maxLevel; i++)
        {
            update[i].SkipLength[i]++;
        }

        this.count++;
        this.changes++;
    }

    /// <summary>
    /// Removes the first item found, that matches the given one.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns>True if the item was removed;
    /// otherwise, false.</returns>
    public bool Remove(T item)
    {
        var index = this.IndexOf(item);
        if (index == -1)
        {
            return false;
        }

        this.RemoveAt(index);
        return true;
    }

    /// <summary>
    /// Remove the item by index.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws when index is out of range.</exception>
    /// <exception cref="InvalidOperationException">
    /// Throws when item is not found.</exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(index));
        }

        var update = new Node<T>[this.maxLevel + 1];
        Node<T> current = this.head;
        int totalSteps = 0;

        for (var i = this.maxLevel; i >= 0; i--)
        {
            while (current.Next[i] != null
                   && totalSteps + current.SkipLength[i] < index + 1)
            {
                totalSteps += current.SkipLength[i];
                current = current.Next[i];
            }

            update[i] = current;
        }

        var deleteNode = current.Next[0]
                         ?? throw new InvalidOperationException("Element not found");

        for (var i = 0; i <= this.maxLevel; ++i)
        {
            if (update[i].Next[i] == deleteNode)
            {
                update[i].Next[i] = deleteNode.Next[i];
                update[i].SkipLength[i] += deleteNode.SkipLength[i] - 1;
            }
            else
            {
                update[i].SkipLength[i]--;
            }
        }

        this.count--;
        this.changes++;
    }

    /// <summary>
    /// Clears all items.
    /// </summary>
    public void Clear()
    {
        this.head = new Node<T>(this.maxLevel);
        this.count = 0;
        this.changes = 0;
        for (var i = 0; i <= this.maxLevel; ++i)
        {
            this.head.SkipLength[i] = 1;
        }
    }

    /// <summary>
    /// Check if an item is contained in the skip list.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <returns>True if the value is found;
    /// otherwise, false.</returns>
    public bool Contains(T item)
    {
        return this.IndexOf(item) != -1;
    }

    /// <summary>
    /// Copies the elements to an array,
    /// starting at a particular array index.
    /// </summary>
    /// <param name="array">the array that is the destination
    /// for the copied elements.</param>
    /// <param name="index">The index in array at which storing
    /// elements will begin.</param>
    /// <exception cref="Exception">Throws when the number of elements
    /// is greater than the available space from index
    /// to the end of the destination array.</exception>
    public void CopyTo(T[] array, int index)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        if (array.Length - index < this.count)
        {
            throw new ArgumentException("Not enough space");
        }

        var current = this.head.Next[0];
        while (current != null)
        {
            array[index++] = current.Value!;
            current = current.Next[0];
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the skip list.
    /// </summary>
    /// <returns>An enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates through the skip list.
    /// </summary>
    /// <returns>An enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head.Next[0];
        while (current != null)
        {
            yield return current.Value!;
            current = current.Next[0];
        }
    }

    /// <summary>
    /// Returns the index of the first item found, that matches the given one.
    /// </summary>
    /// <param name="item">The item to get index.</param>
    /// <returns>The index of given item.</returns>
    public int IndexOf(T item)
    {
        int index = 0;
        var current = this.head.Next[0];
        var comparer = EqualityComparer<T>.Default;
        while (current != null)
        {
            if (comparer.Equals(current.Value, item))
            {
                return index;
            }

            current = current.Next[0];
            index++;
        }

        return -1;
    }

    private int RandomLevel()
    {
        int level = 0;
        while (this.random.NextDouble() < Probability && level < this.maxLevel)
        {
            level++;
        }

        return level;
    }
}
