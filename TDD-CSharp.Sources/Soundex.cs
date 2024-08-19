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
        return word.Length > 1 ? EncodedDigit() : string.Empty;
    }

    private string EncodedDigit()
    {
        return "1";
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