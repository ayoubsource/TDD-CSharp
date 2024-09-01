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
    
    [Fact]
    public void DecreasesSizeAfterRemovingTweet()
    {
        var tweet = new Tweet();
        _collection.Add(tweet);
        _collection.Remove(tweet);
        
        Assert.Equal(0u, _collection.Size());
        Assert.True(_collection.IsEmpty()); // DON'T DO THIS
    }
}