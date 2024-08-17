namespace TDD_CSharp.Sources;

public class Soundex
{
    public string Encode(string word)
    {
        return ZeroPad(word);
    }
    
    private string ZeroPad(string word)
    {
        return word + "000";
    }
}