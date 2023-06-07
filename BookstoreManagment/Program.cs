using BookstoreManagment.Contracts;
using BookstoreManagment.Models;
using static BookstoreManagment.ApplicationMessages;

namespace BookstoreManagment
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBookPrinter bookPrinter = new BookPrinter();
            IConfig config = new Config();

            IBookstoreService bookstoreService = new BookstoreService(bookPrinter, config);

            BookstoreManager manager = new BookstoreManager(bookstoreService);

            LoadMenu(manager, bookPrinter);
        }

        public static void LoadMenu(BookstoreManager manager, IBookPrinter bookPrinter)
        {
            bookPrinter.PrintMenu();

            int option;
            bool isValid = int.TryParse(Console.ReadLine(), out option);

            while (!isValid)
            {
                Console.WriteLine(EnterValidNumber);
                isValid = int.TryParse(Console.ReadLine(), out option);
            }

            switch (option)
            {
                case 1:
                    manager.DisplayBooks();
                    LoadMenu(manager, bookPrinter);

                    break;
                case 2:
                    Console.WriteLine(EnterKeyword);

                    string searchCriteria = Console.ReadLine();

                    var books = manager.SearchBooks(searchCriteria);

                    bookPrinter.PrintTable(books);

                    LoadMenu(manager, bookPrinter);

                    break;
                case 3:
                    Console.WriteLine(AddBookMenu);

                    Console.WriteLine(EnterTitle);
                    string title = Console.ReadLine();

                    while (title.Length > 50)
                    {
                        Console.WriteLine(EnterValidTitle);
                        title = Console.ReadLine();
                    }

                    Console.WriteLine(EnterAuthor);
                    string author = Console.ReadLine();

                    while (author.Length > 50)
                    {
                        Console.WriteLine(EnterValidAuthor);
                        author = Console.ReadLine();
                    }

                    Console.WriteLine(EnterPrice);
                    decimal price;
                    bool validPrice = decimal.TryParse(Console.ReadLine(), out price);

                    while (!validPrice || price <= 0)
                    {
                        Console.WriteLine(EnterValidPrice);
                        validPrice = decimal.TryParse(Console.ReadLine(), out price);
                    }

                    Console.WriteLine(EnterQuantity);
                    int quantity;
                    bool validQuantity = int.TryParse(Console.ReadLine(), out quantity);

                    while (!validQuantity || quantity <= 0)
                    {
                        Console.WriteLine(EnterValidQuantity);
                        validQuantity = int.TryParse(Console.ReadLine(), out quantity);
                    }

                    Console.WriteLine(EnterDescription);
                    string description = Console.ReadLine();

                    while (description.Length > 200)
                    {
                        Console.WriteLine(EnterValidDescription);
                        description = Console.ReadLine();
                    }

                    manager.AddNewBook(title, author, price, quantity, description);

                    Console.WriteLine(NewBookAdded);

                    LoadMenu(manager, bookPrinter);
                    break;
                case 4:
                    decimal totalValue = manager.CalcualteTotalValue();

                    Console.WriteLine(string.Format(TotalBookstoreValue, totalValue));

                    LoadMenu(manager, bookPrinter);
                    break;
                case 5:
                    manager.ApplyDiscounts();

                    Console.WriteLine(DiscountsApplied);

                    LoadMenu(manager, bookPrinter);
                    break;
                case 6:
                    manager.Save();

                    Console.WriteLine(BookCollectionSaved);

                    LoadMenu(manager, bookPrinter);
                    break;
                default:
                    Console.WriteLine(EnterNumberBetween);

                    LoadMenu(manager, bookPrinter);
                    break;
            }
        }
    }
}