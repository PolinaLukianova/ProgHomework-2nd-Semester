namespace ParseTree;

/// <summary>
/// Node for numbers in parse tree.
/// </summary>
/// <param name="value">Operand.</param>
public class NumberNode(int value) : Node
{
    /// <summary>
    /// Gets the value of node.
    /// </summary>
    public int Value { get; } = value;

    /// <summary>
    /// Calculate the value of node.
    /// </summary>
    /// <returns>Returns value of node.</returns>
    public override int Calculate() => this.Value;

    /// <summary>
    /// Returns string value of node.
    /// </summary>
    /// <returns>String value.</returns>
    public override string WriteExpression() => this.Value.ToString();
}
