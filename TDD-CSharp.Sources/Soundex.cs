namespace TDD_CSharp.Sources;

public class Soundex
{
    public string Encode(string word)
    {
        return  ZeroPad(Head(word) + EncodedDigits(word));
    }

    private string EncodedDigits(string word)
    {
        return word.Length > 1 ? "1" : string.Empty;
    }

    private string Head(string word)
    {
        var encoded = word.Substring(0, 1);
        return encoded;
    }

    private string ZeroPad(string word)
    {
        var zerosNeeded = 4 - word.Length;
        return word + new string('0', zerosNeeded);
    }
}