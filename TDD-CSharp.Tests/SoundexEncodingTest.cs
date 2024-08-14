using TDD_CSharp.Sources;

namespace TDD_CSharp.Tests;
public class SoundexEncodingTest
{
    [Fact]
    public void RetainsSoleLetterOfOneLetterWord()
    {
        var soundex = new Soundex();
        var encoded = soundex.Encode("A");
        Assert.Equal("A", encoded);
    }
}