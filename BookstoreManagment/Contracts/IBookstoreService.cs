using BookstoreManagment.Models;
namespace BookstoreManagment.Contracts
{
    public interface IBookstoreService
    {
        void DisplayBooks(List<Book> books);
        List<Book> SearchBooks(List<Book> books, string searchCriteria);
        void AddNewBook(string title, string author, decimal price, int quantity, string description, List<Book> booksCollection);
        decimal CalcualteTotalValue(List<Book> books);
        void ApplyDiscounts(List<Book> books);
        string Save(List<Book> books);
        List<Book> GetBooksFromJson();
    }
}
