using BookstoreManagment.Contracts;
using BookstoreManagment.DTOs;
using BookstoreManagment.Models.DiscountAppliersFactories;
using Newtonsoft.Json;

namespace BookstoreManagment.Models
{
    /// <summary>
    /// The Bookstore Service provides functionallity about working with a book collection.
    /// </summary>
    public class BookstoreService : IBookstoreService
    {
        private IBookPrinter _bookPrinter;
        private DiscountApplierFactoryPool _factoriesPool;
        private List<Book> _booksCollection;

        public BookstoreService(IBookPrinter bookPrinter, IBookProvider bookProvider)
        {
            _bookPrinter = bookPrinter;
            _factoriesPool = new DiscountApplierFactoryPool();

            _booksCollection = bookProvider.GetBooks();
        }

        public IReadOnlyList<Book> BooksCollection => _booksCollection;

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
            int id = _booksCollection[_booksCollection.Count - 1].Id + 1;

            Book newBook = new Book()
            {
                Id = id,
                Title = title,
                Author = author,
                Price = price,
                Quantity = quantity,
                Description = description
            };

            _booksCollection.Add(newBook);
        }

        /// <summary>
        /// Applies discount to all books prices.
        /// </summary>
        public void ApplyDiscounts()
        {
            foreach (var book in _booksCollection)
            {
                IDiscountApplierFactory factory;

                if (book.Price < 15)
                {
                    factory = _factoriesPool.GetFivePercentFactory();
                }
                else if (book.Price >= 15 && book.Price <= 25)
                {
                    factory = _factoriesPool.GetTenPercentFactory();
                }
                else
                {
                    factory = _factoriesPool.GetFifteenPercentFactory();
                }

                IDiscountApplier applier = factory.GetDiscountApplier();

                applier.ApplyDiscount(book);
            }
        }

        /// <summary>
        /// Calculates the total value of all books available.
        /// </summary>
        /// <returns>The sum of all books prices.</returns>
        public decimal CalcualteTotalValue()
        {
            decimal totalValue = _booksCollection.Sum(b => b.Quantity * b.Price);

            return totalValue;
        }

        /// <summary>
        /// Shows all available books in the books collection
        /// </summary>
        public void DisplayBooks()
        {
            _bookPrinter.PrintTable(_booksCollection);
        }

        /// <summary>
        /// Saves the current state of the books collection into a json file.
        /// </summary>
        /// <returns>The json file that is going to be saved as a string.</returns>
        public string Save()
        {
            try
            {
                JsonDTO dto = new JsonDTO()
                {
                    Books = _booksCollection.ToArray()
                };

                string json = JsonConvert.SerializeObject(dto, Formatting.Indented);

                File.WriteAllText(jsonPaths.jsonSaveBooksPath, json);

                return json;
            }
            catch (Exception e)
            {
                return string.Format(ApplicationMessages.BooksNotSaved, e.Message);
            }

        }

        /// <summary>
        /// Searches for a book by criteria case-insensitive.
        /// </summary>
        /// <param name="searchCriteria">The criteria that you search by.</param>
        /// <returns>A list of the books that matched the criteria. Returns empty list if no books are matched.</returns>
        public List<Book> SearchBooks(string searchCriteria)
        {
            searchCriteria = searchCriteria.ToLower();

            return _booksCollection
                .Where(
                    b => b.Title.ToLower().Contains(searchCriteria)
                    || b.Author.ToLower().Contains(searchCriteria))
                .ToList();
        }
    }
}
