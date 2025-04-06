using ParseTree;

string? filePath = Console.ReadLine();

if (File.Exists(filePath))
{
    try
    {
        Node root = Tree.BuildTree(filePath);

        Console.WriteLine(root.WriteExpression());
        Console.WriteLine(root.Calculate());
    }
    catch (Exception exeption)
    {
        Console.WriteLine(exeption.Message);
    }
}
else
{
    Console.WriteLine("Incorrect file path");
}