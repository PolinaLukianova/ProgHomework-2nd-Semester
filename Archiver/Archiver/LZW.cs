namespace Archiver;

/// <summary>
/// Implementation of the LZW data compression algorithm.
/// </summary>
public class LZW
{
    /// <summary>
    /// File compression.
    /// </summary>
    /// <param name="inputPath">Path to input file to compress.</param>
    /// <param name="outputPath">Path to output file.</param>
    public static void Compress(string inputPath, string outputPath)
    {
        Trie trie = new();
        trie.BaseInitialization();

        using var inputStream = File.OpenRead(inputPath);
        using var outputStream = File.Create(outputPath);
        using BinaryWriter writer = new(outputStream);

        Node current = trie.Root;
        int bitWidth = 9;
        List<int> indSet = [];
        int byteR;

        while ((byteR = inputStream.ReadByte()) != -1)
        {
            byte currentByte = (byte)byteR;

            if (current.Child.TryGetValue(currentByte, out Node? next))
            {
                current = next;
            }
            else
            {
                indSet.Add(current.Index);
                Node newNode = new(currentByte, trie.NextIndex);
                trie.NextIndex++;
                current.Child[currentByte] = newNode;

                if (trie.NextIndex >= (1 << bitWidth) && bitWidth < 16)
                {
                    bitWidth++;
                }

                if (trie.Root.Child.TryGetValue(currentByte, out Node? node))
                {
                    current = node;
                }
                else
                {
                    current = trie.Root;
                }
            }
        }

        if (current != trie.Root)
        {
            indSet.Add(current.Index);
        }

        writer.Write(bitWidth);

        foreach (var item in indSet)
        {
            byte[] buffer = BitConverter.GetBytes(item);
            int countBytes = (bitWidth + 7) / 8;
            writer.Write(buffer, 0, countBytes);
        }

        var inputLength = new FileInfo(inputPath).Length;
        var outputLength = outputStream.Length;

        Console.WriteLine($"Compression ratio: {(double)inputLength / outputLength:F3}");
    }

    /// <summary>
    /// Uncompressing a file.
    /// </summary>
    /// <param name="inputPath">Path to input file to uncompress.</param>
    /// <param name="outputPath">Path to output file.</param>
    public static void Uncompress(string inputPath, string outputPath)
    {
        using BinaryReader reader = new(File.OpenRead(inputPath));

        int bitWidth = reader.ReadInt32();
        List<int> set = [];

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            byte[] buffer = reader.ReadBytes((bitWidth + 7) / 8);
            set.Add(BitConverter.ToInt32([.. buffer, .. new byte[4 - buffer.Length]], 0));
        }

        Dictionary<int, string> dictionary = [];
        for (int i = 0; i < 256; ++i)
        {
            dictionary[i] = ((char)i).ToString();
        }

        string previous = dictionary[set[0]];
        List<byte> output = [.. previous.Select(item => (byte)item)];
        int nextIndex = 256;

        for (int i = 1; i < set.Count; ++i)
        {
            string entry;
            int index = set[i];

            if (dictionary.TryGetValue(index, out entry!))
            {
                output.AddRange(entry.Select(item => (byte)item));
            }
            else if (index == nextIndex)
            {
                entry = previous + previous[0];
                output.AddRange(entry.Select(item => (byte)item));
            }

            dictionary[nextIndex] = previous + entry[0];
            nextIndex++;
            previous = entry;
        }

        File.WriteAllBytes(outputPath, [.. output]);
    }
}