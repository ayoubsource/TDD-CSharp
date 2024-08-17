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
}