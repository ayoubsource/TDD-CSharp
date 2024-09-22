namespace TDD_CSharp.Sources.Portfolio;

public class Portfolio
{
    private uint _shareCount = 0;

    public bool IsEmpty()
    {
        return _shareCount == 0;
    }

    public void Purchase(string symbol, uint shareCount)
    {
        _shareCount = shareCount;
    }

    public uint ShareCount(string symbol)
    {
        return _shareCount;
    }
}