// <copyright file="MyList.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericList;

using System.Collections;

/// <summary>
/// Generic list.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MyList<T> : IEnumerable<T>, IEnumerable
{
    private T[] items;
    private int count;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyList{T}"/> class.
    /// </summary>
    public MyList()
    {
        this.items = new T[4];
        this.count = 0;
    }

    /// <summary>
    /// Adds elements to the end of the list.
    /// </summary>
    /// <param name="item">Element to be added.</param>
    public void Add(T item)
    {
        if (this.count == this.items.Length)
        {
            this.Resize();
        }

        this.items[this.count] = item;
        this.count++;
    }

    /// <summary>
    /// Returns a generic enumerator that iterates through the list.
    /// </summary>
    /// <returns>An enumerator for the list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.count; ++i)
        {
            yield return this.items[i];
        }
    }

    /// <summary>
    /// Returns a non-generic enumerator.
    /// </summary>
    /// <returns>An non-enumerator for the list.</returns>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private void Resize()
    {
        T[] newItems = new T[this.items.Length * 2];
        Array.Copy(this.items, newItems, this.count);
        this.items = newItems;
    }
}
