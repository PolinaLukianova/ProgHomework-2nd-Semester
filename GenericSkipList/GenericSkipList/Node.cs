// <copyright file="Node.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericSkipList;

/// <summary>
/// The node of skip list.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
/// <param name="level">The level of node.</param>
/// <param name="value">The value of node.</param>
public class Node<T>(int level, T? value = default)
{
    private readonly int[] skipLength = new int[level + 1];
    private readonly Node<T>[] next = new Node<T>[level + 1];
    private T? value = value;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public T? Value
    {
        get => this.value;
        set => this.value = value;
    }

    /// <summary>
    /// Gets the array of next nodes at each level.
    /// </summary>
    public Node<T>[] Next => this.next;

    /// <summary>
    /// Gets the array of skip lengths,
    /// displays the distance between nodes at each level.
    /// </summary>
    public int[] SkipLength => this.skipLength;
}