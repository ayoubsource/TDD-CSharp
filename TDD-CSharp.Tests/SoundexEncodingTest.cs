using TDD_CSharp.Sources;

namespace TDD_CSharp.Tests;
public class SoundexEncodingTest
{
    [Fact]
    public void RetainsSoleLetterOfOneLetterWord()
    {
        // Arrange
        var soundex = new Soundex();
        // Act
        var encoded = soundex.Encode("I");
        // Assert
        Assert.Equal("I000", encoded);
    }
}