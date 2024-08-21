namespace TDD_CSharp.Sources;

public class Soundex
{
    private const int MaxCodeLength = 4;
    public string Encode(string word)
    {
        return ZeroPad(UpperFront(Head(word)) + EncodedDigits(Tail(word)));
    }
    private string UpperFront(string input)
    {
        return input.Length > 0 ? char.ToUpper(input[0]).ToString() : string.Empty;
    }
    private string EncodedDigits(string word)
    {
        var encoding = string.Empty;
        foreach (var letter in word)
        {
            if (IsComplete(encoding))
                break;

            if (EncodedDigit(letter) != LastDigit(encoding))
                encoding += EncodedDigit(letter);
        }

        return encoding;
    }

    private string LastDigit(string encoding)
    {
        return string.IsNullOrEmpty(encoding) ? string.Empty : encoding[^1].ToString();
    }
    private bool IsComplete(string encoding)
    {
        return encoding.Length == MaxCodeLength - 1;
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
        return encoding.TryGetValue(letter, out var digit) ? digit : string.Empty;
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
    private string ZeroPad(string word)
    {
        var zerosNeeded = MaxCodeLength - word.Length;
        return word + new string('0', zerosNeeded);
    }
}