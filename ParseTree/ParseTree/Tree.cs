using System.Text;

namespace ParseTree;

public class Tree
{
    public static Node Parser(StreamReader reader)
    {
        SkipChar(reader);
        int current = reader.Peek();
        if (current == -1)
        {
            throw new Exception("Empty file");
        }
        if (current == '(')
        {
            reader.Read();
            SkipChar(reader);

            string expressionOperator = ReadToken(reader);
            SkipChar(reader);


            Node leftChild = Parser(reader);
            SkipChar(reader);

            Node rightChild = Parser(reader);
            SkipChar(reader);

            char end = (char)reader.Read();
            if (end != ')')
            {
                throw new Exception("Missing closing bracket");
            }

            return expressionOperator switch
            {
                "+" => new AdditionNode(leftChild, rightChild),
                "-" => new SubtractionNode(leftChild, rightChild),
                "*" => new MultiplicationNode(leftChild, rightChild),
                "/" => new DivisionNode(leftChild, rightChild),
                _ => throw new Exception("The expression contains an unknown operation. Expected +, -, *, /"),
            };
        }
        else if (char.IsDigit((char)current))
        {
            if (int.TryParse(ReadToken(reader), out int value))
            {
                return new NumberNode(value);
            }
            else
            {
                throw new Exception("Incorrect expression");

            }
        }
        else
        {
            throw new Exception("Incorrect expression");
        }
    }

    public static void SkipChar(StreamReader reader)
    {
        while (reader.Peek() != -1 &&
            char.IsWhiteSpace((char)reader.Peek()))
        {
            reader.Read();
        }
    }

    public static string ReadToken(StreamReader reader)
    {
        StringBuilder token = new();
        int current;
        while ((current = reader.Peek()) != -1 &&
            (char)current != ')' &&
            (char)current != '(' &&
            !char.IsWhiteSpace((char)current)) 
        {
            token.Append((char)reader.Read());
        }

        return token.ToString();
    }

    public static Node BuildTree(string filePath)
    {
        StreamReader reader = new(filePath);
        return Parser(reader);
    }
}