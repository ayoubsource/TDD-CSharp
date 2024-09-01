namespace TDD_CSharp.Sources.RetweetCollection;

public class RetweetCollection
{
    private uint _size;
    public RetweetCollection()
    {
        _size = 0;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public uint Size()
    {
        return _size;
    }

    public void Add(Tweet tweet)
    {
        _size = 1;
    }
}