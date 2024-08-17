using TDD_CSharp.Sources;

namespace TDD_CSharp.Tests;
public class SoundexEncodingTest
{
    private readonly Soundex _soundex = new();

    [Fact]
    public void RetainsSoleLetterOfOneLetterWord()
    {
        // Act
        var encoded = _soundex.Encode("A");
        // Assert
        Assert.Equal("A000", encoded);
    }
    
    [Fact]
    public void PadsWithZerosToEnsureThreeDigits()
    {
        // Act
        var encoded = _soundex.Encode("I");
        // Assert
        Assert.Equal("I000", encoded);
    }
}