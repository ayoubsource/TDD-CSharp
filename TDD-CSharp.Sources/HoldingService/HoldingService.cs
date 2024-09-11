namespace TDD_CSharp.Sources.HoldingService;

public class HoldingService
{
    public void ApplyFine(Patron patronWithHolding, Holding holding)
    {
        unsigned int daysLate = CalculateDaysPastDue(holding);
        ClassificationService service = new ClassificationService();
        Book book = service.RetrieveDetails(holding.Classification());

        // Delegate the fine calculation and application to the Patron class
        patronWithHolding.ApplyFine(book, daysLate);
    }
}