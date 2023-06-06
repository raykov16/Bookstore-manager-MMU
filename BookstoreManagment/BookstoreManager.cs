using Newtonsoft.Json;

namespace BookstoreManagment
{
    /// <summary>
    /// The Bookstore Manager provides functionallity about working with a book collection.
    /// </summary>
    public class BookstoreManager
    {
        private string path;

        public BookstoreManager(string jsonPath)
        {
            path = jsonPath;
            BooksCollection = GetBooksFromJson();
        }

        public List<Book> BooksCollection { get; } = new List<Book>();

        /// <summary>
        /// Shows all available books in the books collection
        /// </summary>
        public void DisplayBooks()
        {
            PrintTable(BooksCollection);
        }

        /// <summary>
        /// Searches for a book by criteria case-insensitive.
        /// </summary>
        /// <param name="searchCriteria">The criteria that you search by.</param>
        /// <returns>A list of the books that matched the criteria. Returns empty list if no books are matched.</returns>
        public List<Book> SearchBooks(string searchCriteria)
        {
            searchCriteria = searchCriteria.ToLower();

            return BooksCollection
                .Where(
                    b => b.Title.ToLower().Contains(searchCriteria)
                    || b.Author.ToLower().Contains(searchCriteria))
                .ToList();
        }

        /// <summary>
        /// Adds new book to the books collection.
        /// </summary>
        /// <param name="title">The title of the new book. String with max length 50.</param>
        /// <param name="author">The author of the new book. String with max length 50.</param>
        /// <param name="price">The price of the new book. Decimal with positive value.</param>
        /// <param name="quantity">The quantity of the new book. Integer with positive value.</param>
        /// <param name="description">The description of the new book. String that is optional.</param>
        public void AddNewBook(string title, string author, decimal price, int quantity, string description)
        {
            int id = BooksCollection[BooksCollection.Count - 1].Id + 1;

            Book newBook = new Book()
            {
                Id = id,
                Title = title,
                Author = author,
                Price = price,
                Quantity = quantity,
                Description = description
            };

            BooksCollection.Add(newBook);
        }

        /// <summary>
        /// Calculates the total value of all books available.
        /// </summary>
        /// <returns>The sum of all books prices.</returns>
        public decimal CalcualteTotalValue()
        {
            decimal totalValue = BooksCollection.Sum(b => b.Quantity * b.Price);

            return totalValue;
        }

        /// <summary>
        /// Applies discount to all books prices.
        /// </summary>
        public void ApplyDiscounts()
        {
            foreach (var book in BooksCollection)
            {
                decimal discount = 0;

                if (book.Price < 15)
                {
                    discount = 0.05M;
                }
                else if (book.Price >= 15 && book.Price <= 25)
                {
                    discount = 0.1M;
                }
                else
                {
                    discount = 0.15M;
                }

                book.Price = book.Price - (book.Price * discount);
            }
        }

        /// <summary>
        /// Saves the current state of the books collection into a json file.
        /// </summary>
        /// <returns>The json file that is going to be saved as a string.</returns>
        public string Save()
        {
            JsonDTO dto = new JsonDTO()
            {
                Books = BooksCollection.ToArray()
            };

            string json = JsonConvert.SerializeObject(dto, Formatting.Indented);

            File.WriteAllText("../../../BookstoreManagementOutput.json", json);

            return json;
        }

        /// <summary>
        /// Converts a json to a list of books
        /// </summary>
        /// <returns>List of books</returns>
        private List<Book> GetBooksFromJson()
        {
            string json = File.ReadAllText(path);
            JsonDTO jsonObject = JsonConvert.DeserializeObject<JsonDTO>(json);

            return jsonObject.Books.ToList();
        }

        /// <summary>
        /// Prints a table with books.
        /// </summary>
        /// <param name="books">List of books to be printed.</param>
        public void PrintTable(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine(ApplicationMessages.NoMatchingBooks);
                return;
            }

            int longestTitleLength = 0;
            int longestAuthorLength = 0;

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
