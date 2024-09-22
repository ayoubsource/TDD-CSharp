using TDD_CSharp.Sources.Portfolio;

namespace TDD_CSharp.Tests;

public class APortfolio
{
    private readonly Portfolio _portfolio;

    public APortfolio()
    {
        _portfolio = new Portfolio();
    }

    [Fact]
    public void IsEmptyWhenCreated()
    {
        Assert.True(_portfolio.IsEmpty());
    }

    [Fact]
    public void IsNotEmptyAfterPurchase()
    {
        _portfolio.Purchase("IBM", 1);
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
        _portfolio.Purchase("IBM", 2);
        Assert.Equal(2u, _portfolio.ShareCount("IBM"));
    }
}