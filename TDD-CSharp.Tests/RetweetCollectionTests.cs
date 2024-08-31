namespace TDD_CSharp.Tests;

public class RetweetCollectionTests
{
    [Fact]
    public void IsEmptyWhenCreated()
    {
        var retweets = new RetweetCollection();
    }
}