using BookstoreManagment.Contracts;

namespace BookstoreManagment.Models
{
    /// <summary>
    /// The Book Printer prints the main menu of the application, books as a table or just a simple message
    /// </summary>
    public class BookPrinter : IBookPrinter
    {
        /// <summary>
        /// Prints a menu with bookstore manager options.
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine("\n========== Bookstore Management ==========");
            Console.WriteLine("1. Display Books\n");
            Console.WriteLine("2. Search Books\n");
            Console.WriteLine("3. Add New Book\n");
            Console.WriteLine("4. Calculate Total Value\n");
            Console.WriteLine("5. Apply Discounts\n");
            Console.WriteLine("6. Save\n");
            Console.WriteLine("7. Exit\n\n\n");
            Console.WriteLine("Enter your choice (1-7):");
        }

        /// <summary>
        /// Prints a string message to the console
        /// </summary>
        /// <param name="message">the message to be printed</param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints a collection of books in a table format.
        /// </summary>
        /// <param name="books">The collection of books to be printed as a table</param>
        public void PrintTable(ICollection<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine(ApplicationMessages.NoMatchingBooks);
                return;
            }

            int longestTitleLength = 5;
            int longestAuthorLength = 6;

            foreach (var b in books)
            {
                if (b.Title.Length > longestTitleLength)
                {
                    longestTitleLength = b.Title.Length;
                }

                if (b.Author.Length > longestAuthorLength)
                {
                    longestAuthorLength = b.Author.Length;
                }
            }

            //Calculates the spaces needed to make the table responsilbe and all columns equal
            Console.WriteLine($"\nID  | Title{new string(' ', longestTitleLength - 5)}| Author{new string(' ', longestAuthorLength - 6)}| Price  | Quantity  | Description\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

            foreach (Book book in books)
            {

                //Calculates the spaces needed to make the table responsilbe and all columns equal
                string id = book.Id <= 9 ? $"{book.Id}   " : $"{book.Id}  ";
                string price = book.Price <= 9.99M ? $" {book.Price:f2}   " : $" {book.Price:f2}  ";
                string quantity = book.Quantity <= 9 ? $" {book.Quantity}         " : $" {book.Quantity}        ";

                Console.WriteLine($"{id}| {book.Title}{new string(' ', longestTitleLength - book.Title.Length)}" +
                    $"| {book.Author}{new string(' ', longestAuthorLength - book.Author.Length)}" +
                    $"| {price}| {quantity}| {book.Description}\n");
            }

            Console.WriteLine();
        }
    }
}
