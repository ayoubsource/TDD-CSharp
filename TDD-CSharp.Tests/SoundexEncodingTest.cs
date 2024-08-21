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
    
    [Fact(Skip = "Temporarily disabled while developing multiple consonant encoding logic")]
    public void ReplacesMultipleConsonantsWithDigits()
    {
        Assert.Equal("A234", _soundex.Encode("Acdl"));
    }
}