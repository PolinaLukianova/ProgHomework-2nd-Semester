using ParseTree;

string filePath = Console.ReadLine();

Node root = Tree.BuildTree(filePath);

Console.WriteLine(root.WriteExpression());
Console.WriteLine(root.Calculate());
