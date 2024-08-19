namespace TDD_CSharp.Sources;

public class Soundex
{
    private const int MaxCodeLength = 4;
    public string Encode(string word)
    {
        return  ZeroPad(Head(word) + EncodedDigits(word));
    }

    private string EncodedDigits(string word)
    {
        return word.Length > 1 ? EncodedDigit(word[1]) : string.Empty;
    }

    private string EncodedDigit(char letter)
    {
        var encoding = new Dictionary<char, string>
        {
            {'b', "1"},
            {'c', "2"},
            {'d', "3"}
        };
        return encoding.TryGetValue(letter, out var digit) ? digit : string.Empty;
    }
    
    private string Head(string word)
    {
        var encoded = word.Substring(0, 1);
        return encoded;
    }

    private string ZeroPad(string word)
    {
        var zerosNeeded = MaxCodeLength - word.Length;
        return word + new string('0', zerosNeeded);
    }
}