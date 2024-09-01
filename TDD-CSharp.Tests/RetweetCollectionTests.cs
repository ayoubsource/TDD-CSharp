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
    public void IsNoLongerEmptyAfterTweetAdded()
    {
        // Arrange
        var tweet = new Tweet();

        // Act
        _collection.Add(tweet);

        // Assert
        Assert.False(_collection.IsEmpty());
    }

    [Fact]
    public void HasSizeOfOneAfterTweetAdded()
    {
        // Arrange
        var tweet = new Tweet();

        // Act
        _collection.Add(tweet);
        var size = _collection.Size();

        // Assert
        Assert.Equal(1u, size);
    }
    
    [Fact]
    public void IsEmptyWhenItsSizeIsZero()
    {
        // Arrange
        // The collection is initialized as empty.

        // Act
        var size = _collection.Size();
        var isEmpty = _collection.IsEmpty();

        // Assert
        Assert.Equal(0u, size);
        Assert.True(isEmpty);
    }

    [Fact]
    public void IsNotEmptyWhenItsSizeIsNonZero()
    {
        // Arrange
        var tweet = new Tweet();
        
        // Act
        _collection.Add(tweet);
        var size = _collection.Size();
        var isEmpty = _collection.IsEmpty();

        // Assert
        Assert.True(size > 0u);
        Assert.False(isEmpty);
    }
    
    [Fact]
    public void IgnoresDuplicateTweetAdded()
    {
        // Arrange
        var tweet = new Tweet("msg", "@user");
        var duplicate = new Tweet(tweet);

        // Act
        _collection.Add(tweet);
        _collection.Add(duplicate);
        var size = _collection.Size();

        // Assert
        Assert.Equal(1u, size);
    }
}