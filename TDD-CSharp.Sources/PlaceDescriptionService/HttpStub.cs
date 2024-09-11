namespace TDD_CSharp.Sources.PlaceDescriptionService;

public class HttpStub : Http
{
    public override void Initialize()
    {
        // No implementation needed for the stub
    }

    public override string Get(string url)
    {
        return @"{ ""address"": {
                    ""road"": ""Drury Ln"",
                    ""city"": ""Fountain"",
                    ""state"": ""CO"",
                    ""country"": ""US""
                 }}";
    }
}