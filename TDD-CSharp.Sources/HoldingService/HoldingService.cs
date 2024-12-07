namespace TDD_CSharp.Sources.HoldingService;

public class HoldingService
{
    public void CheckIn(string barCode, DateTime date, string branchId)
    {
        Branch branch = new Branch(branchId);
        mBranchService.Find(branch);
        Holding holding = new Holding(barCode);
        FindByBarCode(holding);
        holding.CheckIn(date, branch);
        mCatalog.Update(holding);
        Patron patronWithBook = FindPatron(holding);
        patronWithBook.ReturnHolding(holding);
        if (IsLate(holding, date))
        {
            ApplyFine(patronWithBook, holding);
        }
        mPatronService.Update(patronWithBook);
    }
    
    public void ApplyFine(Patron patronWithHolding, Holding holding)
    {
        int daysLate = CalculateDaysPastDue(holding);
        ClassificationService service = new ClassificationService();
        Book book = service.RetrieveDetails(holding.Classification());

        switch (book.Type())
        {
            case Book.TYPE_BOOK:
                patronWithHolding.AddFine(Book.BOOK_DAILY_FINE * daysLate);
                break;

            case Book.TYPE_MOVIE:
            {
                int fine = 100 + Book.MOVIE_DAILY_FINE * daysLate;
                if (fine > 1000)
                {
                    fine = 1000;
                }
                patronWithHolding.AddFine(fine);
            }
                break;

            case Book.TYPE_NEW_RELEASE:
                patronWithHolding.AddFine(Book.NEW_RELEASE_DAILY_FINE * daysLate);
                break;
        }
    }
}