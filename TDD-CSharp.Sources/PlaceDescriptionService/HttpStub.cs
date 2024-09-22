using Xunit;

namespace TDD_CSharp.Sources.PlaceDescriptionService;

public class HttpStub : Http
{
    public override void Initialize()
    {
        // No implementation needed for the stub
    }

    public override string Get(string url)
    {
        Verify(url);
        return @"{ ""address"": {
                    ""road"": ""Drury Ln"",
                    ""city"": ""Fountain"",
                    ""state"": ""CO"",
                    ""country"": ""US""
                 }}";
    }

    private void Verify(string url)
    {
        const string urlStart = "http://open.mapquestapi.com/nominatim/v1/reverse?format=json&";
        var expected = urlStart + 
                       "lat=" + APlaceDescriptionService.ValidLatitude + "&" +
                       "lon=" + APlaceDescriptionService.ValidLongitude;
        Assert.Equal(expected, url);
    }
}