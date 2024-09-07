namespace TDD_CSharp.Tests;

public class TweetTests
{
    [Fact]
    public void RequiresUserToStartWithAtSign()
    {
        // Arrange
        var invalidUser = "notStartingWith@";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Tweet("msg", invalidUser));
    }
}