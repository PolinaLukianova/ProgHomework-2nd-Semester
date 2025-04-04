namespace ParseTree;

public class NumberNode(int value) : Node
{
    public int Value { get; } = value;

    public override int Calculate() => Value;

     public override string WriteExpression() => Value.ToString();
}
