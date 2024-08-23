namespace TDD_CSharp.Sources;

public static class CharUtil
{
    public static bool IsVowel(char letter)
    {
        return "aeiouy".Contains(Lower(letter));
    }
    public static char Lower(char c)
    {
        return char.ToLower(c);
    }
}