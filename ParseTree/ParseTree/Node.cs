namespace ParseTree;

/// <summary>
/// Abstract class for a node in a parse tree.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Abstract method to calculate the value of the node.
    /// </summary>
    /// <returns>Value.</returns>
    public abstract int Calculate();

    /// <summary>
    /// Abstract method to get a string value.
    /// </summary>
    /// <returns>String value.</returns>
    public abstract string WriteExpression();
}