namespace Archiver;

/// <summary>
/// A trie data structure.
/// </summary>
public class Trie
{
    public int NextIndex;
    private Node root = new(0);
    private Node? current;

    /// <summary>
    /// Gets the root node of the Trie.
    /// </summary>
    public Node Root => this.root;

    /// <summary>
    /// Initializes the Trie with the first 256 ASCII characters.
    /// </summary>
    public void BaseInitialization()
    {
        for (int i = 0; i < 256; ++i)
        {
            this.Root.Child[(byte)i] = new Node((byte)i, i);
        }

        this.NextIndex = 256;
        this.current = this.Root;
    }

    /// <summary>
    /// Adds a new byte.
    /// </summary>
    /// <param name="nextByte">The byte to be added.</param>
    public void Add(byte nextByte)
    {
        this.current.Child[nextByte] = new(nextByte, this.NextIndex);
        this.NextIndex++;
        this.current = this.Root;
    }
}