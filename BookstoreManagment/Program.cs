using BookstoreManagment.Models;
using BookstoreManagment.Contracts;

namespace BookstoreManagment
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBookPrinter bookPrinter = new BookPrinter();
            IConfig config = new Config();
            IBookProvider bookProvider = new BookProvider(config);

            IBookstoreService bookstoreService = new BookstoreService(bookPrinter, bookProvider);

            MenuInteractor menuInteractor = new MenuInteractor(bookstoreService, bookPrinter);

            menuInteractor.Run();
        }
    }
}