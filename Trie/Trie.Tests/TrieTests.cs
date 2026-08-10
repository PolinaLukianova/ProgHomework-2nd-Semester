namespace Trie.Tests;

public class TrieTests
{
    private Trie trie;

    [SetUp]
    public void Setup()
    {
        this.trie = new Trie();

        this.trie.Add("apple");
        this.trie.Add("app");
        this.trie.Add("ap");
        this.trie.Add("ban");
    }

    [Test]
    public void Trie_Add_ShouldReturnTrue()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Add("mango"), Is.True);
            Assert.That(this.trie.Add("banana"), Is.True);
        });
    }

    [Test]
    public void Trie_Add_ShouldReturnFalse()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Add("apple"), Is.False);
            Assert.That(this.trie.Add(string.Empty), Is.False);
        });
    }

    [Test]
    public void Trie_Contains_ShouldReturnTrue()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Contains("apple"), Is.True);
            Assert.That(this.trie.Contains("ap"), Is.True);
        });
    }

    [Test]
    public void Trie_Contains_ShouldReturnFalse()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Contains("appleapp"), Is.False);
            Assert.That(this.trie.Contains("a"), Is.False);
            Assert.That(this.trie.Contains(string.Empty), Is.False);
        });
    }

    [Test]
    public void Trie_Remove_ShouldReturnTrue()
    {
        Assert.That(this.trie.Contains("apple"), Is.True);
    }

    [Test]
    public void Trie_Remove_ShouldReturnFalse()
    {
        Assert.That(this.trie.Contains("appleapp"), Is.False);
    }

    [Test]
    public void Trie_HowManyStartsWithPrefix()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.HowManyStartsWithPrefix("apple"), Is.EqualTo(1));
            Assert.That(this.trie.HowManyStartsWithPrefix("a"), Is.EqualTo(3));
            Assert.That(this.trie.HowManyStartsWithPrefix("appleapple"), Is.EqualTo(0));
            Assert.That(this.trie.HowManyStartsWithPrefix("tomato"), Is.EqualTo(0));
        });
    }

    [Test]
    public void Trie_Size()
    {
        Assert.That(this.trie.Size, Is.EqualTo(4));
        this.trie.Add("mango");
        Assert.That(this.trie.Size, Is.EqualTo(5));
        this.trie.Remove("apple");
        Assert.That(this.trie.Size, Is.EqualTo(4));
    }
}
