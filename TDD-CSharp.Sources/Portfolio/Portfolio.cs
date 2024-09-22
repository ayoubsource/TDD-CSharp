namespace TDD_CSharp.Sources.Portfolio;

public class Portfolio
{
    private bool _isEmpty = true;
    private uint _shareCount = 0;

    public bool IsEmpty()
    {
        return _isEmpty;
    }

    public void Purchase(string symbol, uint shareCount)
    {
        _isEmpty = false;
        _shareCount = shareCount;
    }

    public uint ShareCount(string symbol)
    {
        return _shareCount;
    }
}
