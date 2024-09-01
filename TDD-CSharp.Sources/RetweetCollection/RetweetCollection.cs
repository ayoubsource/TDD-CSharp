namespace TDD_CSharp.Sources.RetweetCollection;

public class RetweetCollection
{
    private bool _isEmpty;

    public RetweetCollection()
    {
        _isEmpty = true;
    }

    public bool IsEmpty()
    {
        return _isEmpty;
    }

    public void Add(Tweet tweet)
    {
        _isEmpty = false;
    }

    public uint Size()
    {
        return IsEmpty() ? 0u : 1u;
    }  
}