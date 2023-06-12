using BookstoreManagment.Enums;
using BookstoreManagment.Contracts;
using static BookstoreManagment.ApplicationMessages;

namespace BookstoreManagment.Models
{
    public class MenuInteractor
    {
        private IBookPrinter _bookPrinter;
        private IBookstoreService _bookstoreService;
        private bool exitFlag = false;

        public MenuInteractor(IBookstoreService bookstoreService, IBookPrinter bookPrinter)
        {
            _bookPrinter = bookPrinter;
            _bookstoreService = bookstoreService;
        }

        public void Run()
        {
            while (!exitFlag)
            {
                _bookPrinter.PrintMenu();

                int option;
                bool isValid = int.TryParse(Console.ReadLine(), out option);

                while (!isValid)
                {
                    _bookPrinter.PrintMessage(EnterValidNumber);
                    isValid = int.TryParse(Console.ReadLine(), out option);
                }

                switch ((MenuOptions)option)
                {
                    case MenuOptions.DisplayBooks:
                        DisplayBooks();
                        break;
                    case MenuOptions.SearchBooks:
                        SearchBooks();
                        break;
                    case MenuOptions.AddNewBook:
                        AddNewBook();
                        break;
                    case MenuOptions.CalcualteTotalValue:
                        CalculateTotalValue();
                        break;
                    case MenuOptions.ApplyDiscounts:
                        ApplyDiscounts();
                        break;
                    case MenuOptions.Save:
                        Save();
                        break;
                    case MenuOptions.Exit:
                        Exit();
                        break;
                    default:
                        _bookPrinter.PrintMessage(EnterNumberBetween);
                        break;
                }
            }
        }

        private void DisplayBooks()
        {
            _bookstoreService.DisplayBooks();
        }

        private void SearchBooks()
        {
            _bookPrinter.PrintMessage(EnterKeyword);

            string searchCriteria = Console.ReadLine();

            var books = _bookstoreService.SearchBooks(searchCriteria);

            _bookPrinter.PrintTable(books);
        }

        private void AddNewBook()
        {
            _bookPrinter.PrintMessage(AddBookMenu);

            _bookPrinter.PrintMessage(EnterTitle);
            string title = Console.ReadLine();

            while (title.Length > 50)
            {
                _bookPrinter.PrintMessage(EnterValidTitle);
                title = Console.ReadLine();
            }

            _bookPrinter.PrintMessage(EnterAuthor);
            string author = Console.ReadLine();

            while (author.Length > 50)
            {
                _bookPrinter.PrintMessage(EnterValidAuthor);
                author = Console.ReadLine();
            }

            _bookPrinter.PrintMessage(EnterPrice);
            decimal price;
            bool validPrice = decimal.TryParse(Console.ReadLine(), out price);

            while (!validPrice || price <= 0)
            {
                _bookPrinter.PrintMessage(EnterValidPrice);
                validPrice = decimal.TryParse(Console.ReadLine(), out price);
            }

            _bookPrinter.PrintMessage(EnterQuantity);
            int quantity;
            bool validQuantity = int.TryParse(Console.ReadLine(), out quantity);

            while (!validQuantity || quantity <= 0)
            {
                _bookPrinter.PrintMessage(EnterValidQuantity);
                validQuantity = int.TryParse(Console.ReadLine(), out quantity);
            }

            _bookPrinter.PrintMessage(EnterDescription);
            string description = Console.ReadLine();

            while (description.Length > 200)
            {
                _bookPrinter.PrintMessage(EnterValidDescription);
                description = Console.ReadLine();
            }

            _bookstoreService.AddNewBook(title, author, price, quantity, description);

            _bookPrinter.PrintMessage(NewBookAdded);
        }

        private void CalculateTotalValue()
        {
            decimal totalValue = _bookstoreService.CalcualteTotalValue();

            _bookPrinter.PrintMessage(string.Format(TotalBookstoreValue, totalValue));
        }

        private void ApplyDiscounts()
        {
            _bookstoreService.ApplyDiscounts();

            _bookPrinter.PrintMessage(DiscountsApplied);
        }

        private void Save()
        {
            _bookstoreService.Save();

            _bookPrinter.PrintMessage(BookCollectionSaved);
        }

        private void Exit()
        {
            exitFlag = true;
            _bookPrinter.PrintMessage(ExitingMenu);
        }
    }
}
