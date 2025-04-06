namespace ParseTree;

/// <summary>
/// Abstract class for expression node in a parse tree.
/// </summary>
/// <param name="left">Left child node of the expression.</param>
/// <param name="right">Right child node of the expression.</param>
public abstract class ExpressionNode(Node left, Node right) : Node
{
    /// <summary>
    /// Gets the left child node.
    /// </summary>
    public Node LeftChild { get; } = left;

    /// <summary>
    /// Gets the right child node.
    /// </summary>
    public Node RightChild { get; } = right;
}