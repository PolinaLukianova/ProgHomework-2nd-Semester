// <copyright file="NullCounter.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace GenericList;

/// <summary>
/// A static method to count elements in a list that satisfy a custom "null".
/// </summary>
public static class NullCounter
{
    /// <summary>
    /// Count null elements in the list.
    /// </summary>
    /// <typeparam name="T">Type of elements in the list.</typeparam>
    /// <param name="list">The list to search.</param>
    /// <param name="isNull">A function that determines whether an element is considered "null".</param>
    /// <returns>The number of null elements.</returns>
    public static int CountNulls<T>(
        MyList<T> list, Func<T, bool> isNull)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (isNull(item))
            {
                count++;
            }
        }

        return count;
    }
}
