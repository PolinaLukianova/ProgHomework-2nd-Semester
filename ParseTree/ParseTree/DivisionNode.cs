﻿namespace ParseTree;

/// <summary>
/// Node in a parse tree that performs division.
/// </summary>
/// <param name="left">Left operand.</param>
/// <param name="right">Right operand.</param>
public class DivisionNode(Node left, Node right) : ExpressionNode(left, right)
{
    /// <summary>
    /// Returns value of the division.
    /// </summary>
    /// <returns>Value.</returns>
    public override int Calculate() =>
        this.LeftChild.Calculate() / this.RightChild.Calculate();

    /// <summary>
    /// Returns string value of the division.
    /// </summary>
    /// <returns>String value.</returns>
    public override string WriteExpression() =>
        $"( / {this.LeftChild.WriteExpression()} {this.RightChild.WriteExpression()} )";
}