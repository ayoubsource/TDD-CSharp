namespace TDD_CSharp.Sources.HoldingService;
public class Patron
{
    public void ApplyFine(Book book, unsigned int daysLate)
    {
        switch (book.Type())
        {
            case Book.TYPE_BOOK:
                AddFine(Book.BOOK_DAILY_FINE * daysLate);
                break;

            case Book.TYPE_MOVIE:
            {
                int fine = 100 + Book.MOVIE_DAILY_FINE * daysLate;
                if (fine > 1000)
                {
                    fine = 1000;
                }
                AddFine(fine);
            }
                break;

            case Book.TYPE_NEW_RELEASE:
                AddFine(Book.NEW_RELEASE_DAILY_FINE * daysLate);
                break;
        }
    }
}