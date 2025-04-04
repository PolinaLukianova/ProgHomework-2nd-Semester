namespace ParseTree;

public class SubtractionNode(Node left, Node right): ExpressionNode(left, right)
{
    public override int Calculate() =>
       LeftChild.Calculate() - RightChild.Calculate();

    public override string WriteExpression() =>
        $"( - {LeftChild.WriteExpression()} {RightChild.WriteExpression()} )";
}
