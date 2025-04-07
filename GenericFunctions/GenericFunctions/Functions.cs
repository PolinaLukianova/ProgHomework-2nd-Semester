namespace GenericFunctions;

/// <summary>
/// Class with functions Map, Filter, Fold.
/// </summary>
public class Functions
{
    /// <summary>
    /// Transforms the elements of a list according to the passed function.
    /// </summary>
    /// <typeparam name="TList">The type of the input list elements.</typeparam>
    /// <typeparam name="TResult">The type of the output list elements.</typeparam>
    /// <param name="list">Input list.</param>
    /// <param name="func">Function, accepts values ​​of type TList, returns type TResult.</param>
    /// <returns>Transformed list.</returns>
    public static List<TResult> Map<TList, TResult>(List<TList> list, Func<TList, TResult> func)
    {
        var result = new List<TResult>();
        foreach (var item in list)
        {
            result.Add(func(item));
        }

        return result;
    }

    /// <summary>
    /// Filters elements according to the passed function.
    /// </summary>
    /// <typeparam name="TList">The type of the list elements.</typeparam>
    /// <param name="list">Input list.</param>
    /// <param name="func">Function, accepts values ​​of type TList, returns bool value.</param>
    /// <returns>Filtered list.</returns>
    public static List<TList> Filter<TList>(List<TList> list, Func<TList, bool> func)
    {
        var result = new List<TList>();
        foreach (var item in list)
        {
            if (func(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    /// <summary>
    /// Starting from the initial value, applies the function to each value in the list.
    /// </summary>
    /// <typeparam name="TList">The type of the input list elements.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="list">Input list.</param>
    /// <param name="value">Initial value.</param>
    /// <param name="func">Function that takes the current accumulated value and the current list element
    /// and returns the next accumulated value.</param>
    /// <returns>Returns the value obtained after the entire list traversal.</returns>
    public static TValue Fold<TList, TValue>(List<TList> list, TValue value, Func<TValue, TList, TValue> func)
    {
        TValue result = value;
        foreach (var item in list)
        {
            result = func(result, item);
        }

        return result;
    }
}