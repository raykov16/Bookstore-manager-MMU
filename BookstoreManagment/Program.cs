using static BookstoreManagment.ApplicationMessages;

namespace BookstoreManagment
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookstoreManager manager = new BookstoreManager(Config.jsonFilePath);

            LoadMenu(manager);
        }

        public static void LoadMenu(BookstoreManager manager)
        {
            Console.WriteLine("\n========== Bookstore Management ==========");
            Console.WriteLine("1. Display Books\n");
            Console.WriteLine("2. Search Books\n");
            Console.WriteLine("3. Add New Book\n");
            Console.WriteLine("4. Calculate Total Value\n");
            Console.WriteLine("5. Apply Discounts\n");
            Console.WriteLine("6. Save\n\n\n");
            Console.WriteLine("Enter your choice (1-6):");

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
                    LoadMenu(manager);

                    break;
                case 2:
                    Console.WriteLine(EnterKeyword);

                    string searchCriteria = Console.ReadLine();

                    var books = manager.SearchBooks(searchCriteria);

                    manager.PrintTable(books);

                    LoadMenu(manager);

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

                    LoadMenu(manager);
                    break;
                case 4:
                    decimal totalValue = manager.CalcualteTotalValue();

                    Console.WriteLine(string.Format(TotalBookstoreValue, totalValue));

                    LoadMenu(manager);
                    break;
                case 5:
                    manager.ApplyDiscounts();

                    Console.WriteLine(DiscountsApplied);

                    LoadMenu(manager);
                    break;
                case 6:
                    manager.Save();

                    Console.WriteLine(BookCollectionSaved);

                    LoadMenu(manager);
                    break;
                default:
                    Console.WriteLine(EnterNumberBetween);

                    LoadMenu(manager);
                    break;
            }
        }
    }
}