using TDD_CSharp.Sources.Portfolio;

namespace TDD_CSharp.Tests;

public class APortfolio
{
    private const string Ibm = "IBM";
    private readonly Portfolio _portfolio = new();

    [Fact]
    public void IsEmptyWhenCreated()
    {
        Assert.True(_portfolio.IsEmpty());
    }

    [Fact]
    public void IsNotEmptyAfterPurchase()
    {
        _portfolio.Purchase(Ibm, 1);
        Assert.False(_portfolio.IsEmpty());
    }

    [Fact]
    public void AnswersZeroForShareCountOfUnpurchasedSymbol()
    {
        Assert.Equal(0u, _portfolio.ShareCount("AAPL"));
    }

    [Fact]
    public void AnswersShareCountForPurchasedSymbol()
    {
        _portfolio.Purchase(Ibm, 2);
        Assert.Equal(2u, _portfolio.ShareCount(Ibm));
    }

    [Fact]
    public void ThrowsOnPurchaseOfZeroShares()
    {
        Assert.Throws<InvalidPurchaseException>(() => _portfolio.Purchase(Ibm, 0));
    }
}