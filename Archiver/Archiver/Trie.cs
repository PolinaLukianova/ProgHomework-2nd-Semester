namespace Archiver;

/// <summary>
/// A trie data structure.
/// </summary>
public class Trie
{
    private readonly Node root = new(0);
    private int nextIndex;
    private Node? current;

    /// <summary>
    /// Gets the root node of the Trie.
    /// </summary>
    public Node Root => this.root;

    /// <summary>
    /// Gets or sets the next index.
    /// </summary>
    public int NextIndex
    {
        get => this.nextIndex;
        set => this.nextIndex = value;
    }

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

    /// <summary>
    /// Checking if a byte is in Trie.
    /// </summary>
    /// <param name="currentByte">The byte to be checked.</param>
    /// <returns>True if the byte is contained in Trie, otherwise false.</returns>
    public bool Contains(byte currentByte)
    {
        return this.Root.Child.ContainsKey(currentByte);
    }
}