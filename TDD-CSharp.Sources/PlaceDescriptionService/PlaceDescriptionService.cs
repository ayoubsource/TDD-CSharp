namespace TDD_CSharp.Sources.PlaceDescriptionService;

public class PlaceDescriptionService
{
    private readonly Http _http;

    public PlaceDescriptionService(Http http)
    {
        _http = http;
    }

    public string SummaryDescription(string latitude, string longitude)
    {
        var getRequestUrl = "lat=" + latitude + "&lon=" + longitude;
        var jsonResponse = _http.Get(getRequestUrl);
        var extractor = new AddressExtractor();
        var address = extractor.AddressFrom(jsonResponse);
        return $"{address.Road}, {address.City}, {address.State}, {address.Country}";
    }
}