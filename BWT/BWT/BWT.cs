namespace BWT;

public class BWT
{
    // метод, преобразующий строку при помощи BWT
    // на вход подается строка
    // на выходе получается кортеж, содержащий преобразованную строку и позицию конца строки
    public static (string encodedText, int endPosition) TextEncode(string text)
    {
        List<string> permutations = new();
        for (int i = 0; i < text.Length; ++i)
        {
            permutations.Add(text[i..] + text[..i]);
        }

        permutations.Sort();

        string encodedText = string.Empty;
        int endPosition = 0;

        for (int i = 0; i < permutations.Count; ++i)
        {
            encodedText += permutations[i][permutations[i].Length - 1];
            if (permutations[i] == text)
            {
                endPosition = i;
            }
        }

        return (encodedText, endPosition);
    }

    // метод, выполняющий обратное преобразование строки
    // на вход подается строка и позиция конца исходной строки
    // на выходе получается исходная строка
    public static string TextDecode(string text, int endPosition)
    {
        List<string> rebuildPermutations = new();

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
}
