// <copyright file="BWT.cs" company="Polina Lukianova">
// Copyright (c) Polina Lukianova. All rights reserved.
// </copyright>

namespace BWT;

public class BWT
{
    public static (string EncodedText, int EndPosition) TextEncode(string text)
    {
        List<string> permutations = [];
        for (int i = 0; i < text.Length; ++i)
        {
            permutations.Add(text[i..] + text[..i]);
        }

        permutations.Sort();

        string encodedText = string.Empty;
        int endPosition = 0;

        for (int i = 0; i < permutations.Count; ++i)
        {
            encodedText += permutations[i][^1];
            if (permutations[i] == text)
            {
                endPosition = i;
            }
        }

        return (encodedText, endPosition);
    }

    public static string TextDecode(string text, int endPosition)
    {
        List<string> rebuildPermutations = [];

        for (int i = 0; i < text.Length; ++i)
        {
            rebuildPermutations.Add(string.Empty);
        }

        for (int i = 0; i < rebuildPermutations.Count; ++i)
        {
            for (int j = 0; j < text.Length; ++j)
            {
                rebuildPermutations[j] = text[j] + rebuildPermutations[j];
            }

            rebuildPermutations.Sort();
        }

        return rebuildPermutations[endPosition];
    }

    public static (string EncodedText, int EndPosition) TextEncodeOptimized(string text)
    {
        int[] suffixes = new int[text.Length];
        for (int i = 0; i < text.Length; ++i)
        {
            suffixes[i] = i;
        }

        Array.Sort(suffixes, (i, j) =>
        {
            for (int k = 0; k < text.Length; ++k)
            {
                char charA = text[(i + k) % text.Length];
                char charB = text[(j + k) % text.Length];
                if (charA != charB)
                {
                    return charA.CompareTo(charB);
                }
            }

            return 0;
        });

        char[] result = new char[text.Length];
        int endPosition = 0;

        for (int i = 0; i < text.Length; ++i)
        {
            int index = (suffixes[i] + text.Length - 1) % text.Length;
            result[i] = text[index];
            if (suffixes[i] == 0)
            {
                endPosition = i;
            }
        }

        return (new string(result), endPosition);
    }

    public static string TextDecodeOptimized(string text, int endPosition)
    {
        int[] count = new int[256];
        int[] rank = new int[text.Length];

        for (int i = 0; i < text.Length; ++i)
        {
            rank[i] = count[text[i]];
            count[text[i]]++;
        }

        int[] start = new int[256];
        int sum = 0;

        for (int i = 0; i < 256; ++i)
        {
            start[i] = sum;
            sum += count[i];
        }

        char[] result = new char[text.Length];
        int index = endPosition;

        for (int i = text.Length - 1; i >= 0; --i)
        {
            char textValue = text[index];
            result[i] = textValue;
            index = start[textValue] + rank[index];
        }

        return new string(result);
    }
}
