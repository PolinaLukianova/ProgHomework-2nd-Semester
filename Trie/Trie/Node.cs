namespace Trie;

/// <summary>
/// This is node for trie data structure.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Node"/> class.
/// </remarks>
/// <param name="parent">The parent node of the current node.</param>
/// <param name="value">The value of the current node.</param>
public class Node(Node? parent = null, char value = '-')
{
    /// <summary>
    /// Gets the child nodes of the current node.
    /// </summary>
    public Dictionary<char, Node> Child { get; } = [];

    /// <summary>
    /// Gets or sets a value indicating whether current node is the end of the word.
    /// </summary>
    public bool IsEnd { get; set; }

    /// <summary>
    /// Gets the value of the current node.
    /// </summary>
    public char Value { get; } = value;

    /// <summary>
    /// Gets the parent nodes of the current node.
    /// </summary>
    public Node? Parent { get; } = parent;

    /// <summary>
    /// Gets or sets the count of prefixes that pass through current node.
    /// </summary>
    public int PrefixCount { get; set; }
}