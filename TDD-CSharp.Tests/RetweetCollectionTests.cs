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
}