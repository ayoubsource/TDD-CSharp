using TDD_CSharp.Sources.RetweetCollection;

namespace TDD_CSharp.Tests;

public class RetweetCollectionTests
{
    private readonly RetweetCollection _collection = new RetweetCollection();

    [Fact]
    public void IsEmptyWhenCreated()
    {
        Assert.True(_collection.IsEmpty());
    }

    [Fact]
    public void HasSizeZeroWhenCreated()
    {
        Assert.Equal(0u, _collection.Size());
    }

    [Fact]
    public void IsNoLongerEmptyAfterTweetAdded()
    {
        _collection.Add(new Tweet());
        Assert.False(_collection.IsEmpty());
    }
    
    [Fact]
    public void HasSizeOfOneAfterTweetAdded()
    {
        _collection.Add(new Tweet());
        Assert.Equal(1u, _collection.Size());
    }
    
    private void AssertHasSize(RetweetCollection collection, uint expectedSize)
    {
        Assert.Equal(expectedSize, collection.Size());
        Assert.Equal(expectedSize == 0, collection.IsEmpty());
    }

    [Fact]
    public void DecreasesSizeAfterRemovingTweet()
    {
        // Arrange
        var tweet = new Tweet();
        _collection.Add(tweet);

        // Act
        _collection.Remove(tweet);

        // Assert
        AssertHasSize(_collection, 0u);
    }
}