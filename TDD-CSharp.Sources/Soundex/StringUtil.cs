namespace TDD_CSharp.Sources;

public  static class StringUtil
{
    public static string Head(string word)
    {
        return word.Substring(0, 1);
    }
    public static string Tail(string word)
    {
        return word.Length > 1 ? word.Substring(1) : string.Empty;
    }
    public static string ZeroPad(string word, int maxCodeLength)
    {
        var zerosNeeded = maxCodeLength - word.Length;
        return word + new string('0', zerosNeeded);
    }
    public static string UpperFront(string input)
    {
        return input.Length > 0 ? char.ToUpper(input[0]).ToString() : string.Empty;
    }
}