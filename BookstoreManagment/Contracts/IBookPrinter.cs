using BookstoreManagment.Models;

namespace BookstoreManagment.Contracts
{
    public interface IBookPrinter
    {
        void PrintMenu();
        void PrintTable(ICollection<Book> books);
    }
}
