namespace ParseTree;

public abstract class ExpressionNode(Node left, Node right): Node
{
    public Node LeftChild { get; } = left;
    public Node RightChild { get; } = right;

}
