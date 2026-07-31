namespace Archiver;

/// <summary>
/// This is node for trie data structure.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Node"/> class.
/// </remarks>
/// <param name="value">The value of current node.</param>
/// <param name="index">The index of current node.</param>
public class Node(byte value, int index = -1)
{
    /// <summary>
    /// Gets the child nodes of the current node.
    /// </summary>
    public Dictionary<byte, Node> Child { get; } = [];

    /// <summary>
    /// Gets the value of the current node.
    /// </summary>
    public byte Value { get; } = value;

    /// <summary>
    /// Gets or sets the index of the current node.
    /// </summary>
    public int Index { get; set; } = index;
}