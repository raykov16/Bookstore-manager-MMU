using BookstoreManagment.Models;
namespace BookstoreManagment.Contracts
{
    public interface IBookstoreService
    {
        void DisplayBooks();
        List<Book> SearchBooks(string searchCriteria);
        void AddNewBook(string title, string author, decimal price, int quantity, string description);
        decimal CalcualteTotalValue();
        void ApplyDiscounts();
        string Save();
    }
}
