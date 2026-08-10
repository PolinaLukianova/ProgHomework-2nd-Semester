// <copyright file="BWTTests.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace BWT.Tests;

[TestClass]
public class BWTTests
{
    [TestMethod]
    public void TextEncodeOptimized_ShouldReturnEncodedStrAndEndPosition()
    {
        (string textEncode, int endPosition) = BWT.TextEncodeOptimized("banana");
        Assert.AreEqual("nnbaaa", textEncode);
        Assert.AreEqual(3, endPosition);
    }

    [TestMethod]
    public void TextEncodeOptimizedRepeatingLetters_ShouldReturnEncodedStrAndEndPosition()
    {
        (string textEncode, int endPosition) = BWT.TextEncodeOptimized("AAAAA");
        Assert.AreEqual("AAAAA", textEncode);
        Assert.AreEqual(0, endPosition);
    }

    [TestMethod]
    public void TextEncodeOptimizedOneLetters_ShouldReturnEncodedStrAndEndPosition()
    {
        (string textEncode, int endPosition) = BWT.TextEncodeOptimized("A");
        Assert.AreEqual("A", textEncode);
        Assert.AreEqual(0, endPosition);
    }

    [TestMethod]
    public void TextDecodeOptimized_ShouldReturnDecodedStr()
    {
        string textDecode = BWT.TextDecodeOptimized("nnbaaa", 3);
        Assert.AreEqual("banana", textDecode);
    }

    [TestMethod]
    public void TextDecodeOptimizedRepeatingLetters_ShouldReturnDecodedStr()
    {
        string textDecode = BWT.TextDecode("AAAAA", 0);
        Assert.AreEqual("AAAAA", textDecode);
    }

    [TestMethod]
    public void TextDecodeOptimizedOneLetter_ShouldReturnDecodedStr()
    {
        string textDecode = BWT.TextDecodeOptimized("A", 0);
        Assert.AreEqual("A", textDecode);
    }

    [TestMethod]
    public void TextWithLettersAndNumbers_ShouldMatchOriginalStr()
    {
        string text = "QWERTYUUUUIOPUUU34555DFGUU345";
        (string textEncode, int endPosition) = BWT.TextEncodeOptimized(text);
        string textDecode = BWT.TextDecodeOptimized(textEncode, endPosition);
        Assert.AreEqual(text, textDecode);
    }
}