namespace TDD_CSharp.Tests;

public class APlaceDescriptionService
{
    [Fact]
    public void ReturnsDescriptionForValidLocation()
    {
        // Arrange
        var httpStub = new HttpStub();
        var service = new PlaceDescriptionService(httpStub);

        // Act
        var description = service.SummaryDescription(ValidLatitude, ValidLongitude);

        // Assert
        Assert.Equal("Drury Ln, Fountain, CO, US", description);
    }
}