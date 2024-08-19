namespace TDD_CSharp.Sources;

public class Soundex
{
    public string Encode(string word)
    {
        var encoded = word.Substring(0, 1);
        if (word.Length > 1)
        {
            encoded += "1";
        }
        return ZeroPad(encoded);
    }
    
    private string ZeroPad(string word)
    {
        var zerosNeeded = 4 - word.Length;
        return word + new string('0', zerosNeeded);
    }
}