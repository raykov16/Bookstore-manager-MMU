using BookstoreManagment.Models;

namespace BookstoreManagment.Contracts
{
    public interface IBookPrinter
    {
        void PrintMenu();
        void PrintMessage(string message);
        void PrintTable(ICollection<Book> books);
    }
}
