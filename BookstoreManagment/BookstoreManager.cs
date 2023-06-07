using BookstoreManagment.Contracts;
using BookstoreManagment.Models;

namespace BookstoreManagment
{
    /// <summary>
    /// The Bookstore Manager provides functionallity about working with a book collection.
    /// </summary>
    public class BookstoreManager
    {
        private IBookstoreService _bookstoreService;
        private List<Book> _booksCollection;

        public BookstoreManager(IBookstoreService bookstoreService)
        {
            _bookstoreService = bookstoreService;
            _booksCollection = _bookstoreService.GetBooksFromJson();
        }

        public IReadOnlyList<Book> BooksCollection => _booksCollection;

        /// <summary>
        /// Shows all available books in the books collection
        /// </summary>
        public void DisplayBooks()
        {
            _bookstoreService.DisplayBooks(_booksCollection);
        }

        /// <summary>
        /// Searches for a book by criteria case-insensitive.
        /// </summary>
        /// <param name="searchCriteria">The criteria that you search by.</param>
        /// <returns>A list of the books that matched the criteria. Returns empty list if no books are matched.</returns>
        public List<Book> SearchBooks(string searchCriteria)
        {
            return _bookstoreService.SearchBooks(_booksCollection, searchCriteria);
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
            _bookstoreService.AddNewBook(title, author, price, quantity, description, _booksCollection);
        }

        /// <summary>
        /// Calculates the total value of all books available.
        /// </summary>
        /// <returns>The sum of all books prices.</returns>
        public decimal CalcualteTotalValue()
        {
            return _bookstoreService.CalcualteTotalValue(_booksCollection);
        }

        /// <summary>
        /// Applies discount to all books prices.
        /// </summary>
        public void ApplyDiscounts()
        {
            _bookstoreService.ApplyDiscounts(_booksCollection);
        }

        /// <summary>
        /// Saves the current state of the books collection into a json file.
        /// </summary>
        /// <returns>The json file that is going to be saved as a string.</returns>
        public string Save()
        {
            return _bookstoreService.Save(_booksCollection);
        }
    }
}
