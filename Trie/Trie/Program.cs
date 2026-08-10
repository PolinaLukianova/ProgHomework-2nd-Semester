Trie.Trie trie = new();

Console.WriteLine($"Adding a word: {trie.Add("qwerty")}");
Console.WriteLine($"The word contains: {trie.Contains("qwerty")}");
Console.WriteLine($"The number of words starting with a given prefix: {trie.HowManyStartsWithPrefix("qwe")}");
Console.WriteLine($"The size of trie: {trie.Size}");
Console.WriteLine($"The word remove: {trie.Remove("qwerty")}");