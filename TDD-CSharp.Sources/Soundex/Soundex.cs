namespace TDD_CSharp.Sources;
using System.Collections.Generic;

public class Soundex
{
    public const int MaxCodeLength = 4;
    private const string NotADigit = "*";

    public string Encode(string word)
    {
        return StringUtil.ZeroPad(
            StringUtil.UpperFront(StringUtil.Head(word)) + 
            StringUtil.Tail(EncodedDigits(word)), 
            MaxCodeLength);
    }
    public string EncodedDigit(char letter)
    {
        var encodings = new Dictionary<char, string>
        {
            {'b', "1"}, {'f', "1"}, {'p', "1"}, {'v', "1"},
            {'c', "2"}, {'g', "2"}, {'j', "2"}, {'k', "2"}, {'q', "2"},
            {'s', "2"}, {'x', "2"}, {'z', "2"},
            {'d', "3"}, {'t', "3"},
            {'l', "4"},
            {'m', "5"}, {'n', "5"},
            {'r', "6"}
        };

        var lowerCaseLetter = CharUtil.Lower(letter);
        return encodings.TryGetValue(lowerCaseLetter, out var digit) ? digit : NotADigit;
    }
   
    private string EncodedDigits(string word)
    {
        var encoding = string.Empty;
        EncodeHead(ref encoding, word);
        EncodeTail(ref encoding, word);
        return encoding;
    }
    private void EncodeHead(ref string encoding, string word)
    {
        encoding += EncodedDigit(word[0]);
    }
    private void EncodeTail(ref string encoding, string word)
    {
        for (var i = 1; i < word.Length; i++)
        {
            if (!IsComplete(encoding))
                EncodeLetter(ref encoding, word[i], word[i - 1]);
        }
    }
    private void EncodeLetter(ref string encoding, char letter, char lastLetter)
    {
        var digit = EncodedDigit(letter);
        if (digit != NotADigit &&
            (digit != LastDigit(encoding) || CharUtil.IsVowel(lastLetter)))
        {
            encoding += digit;
        }
    }
    private bool IsComplete(string encoding)
    {
        return encoding.Length == MaxCodeLength;
    }
    private string LastDigit(string encoding)
    {
        return string.IsNullOrEmpty(encoding) ? NotADigit : encoding[^1].ToString();
    }
}