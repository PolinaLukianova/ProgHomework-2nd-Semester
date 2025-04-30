namespace Trie;

/// <summary>
/// A trie data structure that supports methods
/// such as Add, Contains, Remove, and HowManyStartsWithPrefix.
/// </summary>
public class Trie
{
    private readonly Node root = new();
    private int size;

    /// <summary>
    /// Gets the number of elements in the trie.
    /// </summary>
    public int Size => this.size;

    /// <summary>
    /// Gets a new string element to the trie.
    /// </summary>
    /// <param name="element">The string that is added to the tree.</param>
    /// <returns>True if string was added, else false.</returns>
    public bool Add(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        Node current = this.root;
        bool isNew = false;

        foreach (var item in element)
        {
            if (!current.Child.TryGetValue(item, out Node? next))
            {
                isNew = true;
                next = new Node(current, item);
                current.Child.Add(item, next);
            }

            current = next;

            if (isNew)
            {
                current.PrefixCount++;
            }
        }

        if (current.IsEnd)
        {
            return false;
        }

        if (!isNew)
        {
            Node node = this.root;
            foreach (var item in element)
            {
                node = node.Child[item];
                node.PrefixCount++;
            }
        }

        this.size++;
        current.IsEnd = true;
        return true;
    }

    /// <summary>
    /// Checks whether the string is contained in the trie.
    /// </summary>
    /// <param name="element">The string being checked.</param>
    /// <returns>True if trie contains this string, else false.</returns>
    public bool Contains(string element)
    {
        Node? current = this.root;
        foreach (var item in element)
        {
            if (!current.Child.TryGetValue(item, out current))
            {
                return false;
            }
        }

        return current.IsEnd;
    }

    /// <summary>
    /// Deletes given string from the trie.
    /// </summary>
    /// <param name="element">The line to be deleted.</param>
    /// <returns>True if string was deleted, else false.</returns>
    public bool Remove(string element)
    {
        Node? current = this.root;
        List<Node> visited = [];
        foreach (var item in element)
        {
            if (!current.Child.TryGetValue(item, out Node? next))
            {
                return false;
            }

            visited.Add(current);
            current = next;
        }

        if (!current.IsEnd)
        {
            return false;
        }

        current.IsEnd = false;
        this.size--;
        foreach (var item in visited)
        {
            item.PrefixCount--;
        }

        for (int i = visited.Count - 1; i >= 0; --i)
        {
            Node node = visited[i];
            if (node.Child.Count == 0 && !node.IsEnd && node.PrefixCount == 0)
            {
                node.Parent?.Child.Remove(node.Value);
            }
            else
            {
                break;
            }
        }

        return true;
    }

    /// <summary>
    /// Counts how many strings in the trie start with a given prefix.
    /// </summary>
    /// <param name="prefix">The prefix to search for.</param>
    /// <returns>The number of strings that start with a given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        Node? current = this.root;
        foreach (var item in prefix)
        {
            if (!current.Child.TryGetValue(item, out current))
            {
                return 0;
            }
        }

        return current.PrefixCount;
    }
}