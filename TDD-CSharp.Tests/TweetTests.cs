using TDD_CSharp.Sources.RetweetCollection;

namespace TDD_CSharp.Tests;

public class TweetTests
{
    [Fact]
    public void RequiresUserToStartWithAtSign()
    {
        // Arrange
        var invalidUser = "notStartingWith@";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Tweet("msg", invalidUser));
        
        // Assert that the exception message matches the expected value
        Assert.Equal("Invalid user: User must start with '@'.", exception.Message);
    }
}