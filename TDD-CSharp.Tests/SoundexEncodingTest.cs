using TDD_CSharp.Sources;

namespace TDD_CSharp.Tests;
public class SoundexEncodingTest
{
    private readonly Soundex _soundex = new();
    
    [Fact]
    public void RetainsSoleLetterOfOneLetterWord()
    {
        Assert.Equal("A000", _soundex.Encode("A"));
    }

    [Fact]
    public void PadsWithZerosToEnsureThreeDigits()
    {
        Assert.Equal("I000", _soundex.Encode("I"));
    }
    [Fact]
    public void ReplacesConsonantsWithAppropriateDigits()
    {
        Assert.Equal("A100", _soundex.Encode("Ab"));
        Assert.Equal("A200", _soundex.Encode("Ac"));
        Assert.Equal("A300", _soundex.Encode("Ad"));
        Assert.Equal("A200", _soundex.Encode("Ax"));
    }
    
    [Fact]
    public void IgnoresNonAlphabetics()
    {
        Assert.Equal("A000", _soundex.Encode("A#"));
    }
    
    [Fact]
    public void ReplacesMultipleConsonantsWithDigits()
    {
        Assert.Equal("A234", _soundex.Encode("Acdl"));  
    }
    [Fact]
    public void LimitsLengthToFourCharacters()
    {
        Assert.Equal(4, _soundex.Encode("Dcdlb").Length);
    }
    [Fact]
    public void IgnoresVowelLikeLetters()
    {
        Assert.Equal("B234", _soundex.Encode("BaAeEiIoOuUhHyYcdl"));
    }
    [Fact]
    public void CombinesDuplicateEncodings()
    {
        Assert.Equal(_soundex.EncodedDigit('b'), _soundex.EncodedDigit('f'));
        Assert.Equal(_soundex.EncodedDigit('c'), _soundex.EncodedDigit('g'));
        Assert.Equal(_soundex.EncodedDigit('d'), _soundex.EncodedDigit('t'));
        Assert.Equal("A123", _soundex.Encode("Abfcgdt"));    
    }
    
    [Fact]
    public void UppercasesFirstLetter()
    {
        Assert.StartsWith("A", _soundex.Encode("abcd"));
    }
    
    [Fact]
    public void IgnoresCaseWhenEncodingConsonants()
    {
        Assert.Equal(_soundex.Encode("BCDL"), _soundex.Encode("Bcdl"));
    }
    
    [Fact]
    public void CombinesDuplicateCodesWhenSecondLetterDuplicatesFirst()
    {
        Assert.Equal("B230", _soundex.Encode("Bbcd"));
    }
    
    [Fact]
    public void DoesNotCombineDuplicateEncodingsSeparatedByVowels()
    {
        Assert.Equal("J110", _soundex.Encode("Jbob"));
    }
}