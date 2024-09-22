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
        var duplicate = new Tweet(tweet.Message, tweet.User);

        // Act
        _collection.Add(tweet);
        _collection.Add(duplicate);

        // Assert
        Assert.Equal(1u, _collection.Size());
    }
}

public class RetweetCollectionWithOneTweetTests
{
    private readonly RetweetCollection _collection;
    private readonly Tweet _tweet;

    // Constructor serves as the setup method
    public RetweetCollectionWithOneTweetTests()
    {
        _collection = new RetweetCollection();
        _tweet = new Tweet("msg", "@user");
        _collection.Add(_tweet);
    }

    [Fact]
    public void IsNoLongerEmpty()
    {
        Assert.False(_collection.IsEmpty());
    }

    [Fact]
    public void HasSizeOfOne()
    {
        Assert.Equal(1u, _collection.Size());
    }
    
    [Fact]
    public void IgnoresDuplicateTweetAdded()
    {
        // Arrange
        var duplicate = new Tweet(_tweet.Message, _tweet.User); // Duplicate tweet

        // Act
        _collection.Add(duplicate);
        var size = _collection.Size();

        // Assert
        Assert.Equal(1u, size);  // Size should remain 1
    }
}