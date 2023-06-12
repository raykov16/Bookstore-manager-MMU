using BookstoreManagment.Models;

namespace BookstoreManagment.Contracts
{
    public interface IBookProvider
    {
        List<Book> GetBooks();
    }
}
