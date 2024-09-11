namespace TDD_CSharp.Sources.PlaceDescriptionService;

public abstract class Http
{
    public abstract void Initialize();
    public abstract string Get(string url);
}