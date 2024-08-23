namespace TDD_CSharp.Sources;

public class Soundex
{
    private const int MaxCodeLength = 4;
    public const string NotADigit = "*";
    public string Encode(string word)
    {
        return ZeroPad(UpperFront(Head(word)) + Tail(EncodedDigits(word)));
    }
    private string UpperFront(string input)
    {
        return input.Length > 0 ? char.ToUpper(input[0]).ToString() : string.Empty;
    }
    private string EncodedDigits(string word)
    {
        var encoding = string.Empty;
        EncodHead( ref encoding, word);
        EncodingTail(ref encoding,word);
        return encoding;
    }

    private void EncodingTail(ref string encoding, string word)
    {
        foreach (var letter in Tail(word))
        {
            if (!IsComplete(encoding)) 
                EncodeLetter(ref encoding, letter);
        }
    }
    
    private void EncodeLetter(ref string encoding, char letter)
    {
        var digit = EncodedDigit(letter);
        if (digit != NotADigit && digit != LastDigit(encoding))
            encoding += digit;
    }

    private void EncodHead(ref string encoding, string word)
    {
        encoding += EncodedDigit(word[0]);
    }

    private string LastDigit(string encoding)
    {
        return string.IsNullOrEmpty(encoding) ? NotADigit : encoding[^1].ToString();
    }
    private bool IsComplete(string encoding)
    {
        return encoding.Length == MaxCodeLength;
    }
    public string EncodedDigit(char letter)
    {
        var encoding = new Dictionary<char, string>
        { 
            {'b', "1"}, {'f', "1"}, {'p', "1"}, {'v', "1"},
            {'c', "2"}, {'g', "2"}, {'j', "2"}, {'k', "2"}, {'q', "2"},
            {'s', "2"}, {'x', "2"}, {'z', "2"},
            {'d', "3"}, {'t', "3"},
            {'l', "4"},
            {'m', "5"}, {'n', "5"},
            {'r', "6"}
        };
        var lowerCaseLetter = Lower(letter);
        return encoding.TryGetValue(lowerCaseLetter, out var digit) ? digit : NotADigit;
    }
    
    private string Head(string word)
    {
        var encoded = word.Substring(0, 1);
        return encoded;
    }
    private string Tail(string word)
    {
        return word.Substring(1);
    }
    private char Lower(char c)
    {
        return char.ToLower(c);
    }
    private string ZeroPad(string word)
    {
        var zerosNeeded = MaxCodeLength - word.Length;
        return word + new string('0', zerosNeeded);
    }
}