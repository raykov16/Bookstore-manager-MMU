using BookstoreManagment.Contracts;
using Newtonsoft.Json;

namespace BookstoreManagment.Models
{
    public class BookstoreService : IBookstoreService
    {
        private IBookPrinter _bookPrinter;
        private IConfig _config;

        public BookstoreService(IBookPrinter bookPrinter, IConfig config)
        {
            _bookPrinter = bookPrinter;
            _config = config;
        }

        public void AddNewBook(string title, string author, decimal price, int quantity, string description, List<Book> booksCollection)
        {
            int id = booksCollection[booksCollection.Count - 1].Id + 1;

            Book newBook = new Book()
            {
                Id = id,
                Title = title,
                Author = author,
                Price = price,
                Quantity = quantity,
                Description = description
            };

            booksCollection.Add(newBook);
        }

        public void ApplyDiscounts(List<Book> books)
        {
            foreach (var book in books)
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

        public decimal CalcualteTotalValue(List<Book> books)
        {
            decimal totalValue = books.Sum(b => b.Quantity * b.Price);

            return totalValue;
        }

        public void DisplayBooks(List<Book> books)
        {
            _bookPrinter.PrintTable(books);
        }

        public List<Book> GetBooksFromJson()
        {
            try
            {
                string path = _config.GetJsonPath();
                string json = File.ReadAllText(path);
                JsonDTO jsonObject = JsonConvert.DeserializeObject<JsonDTO>(json);

                return jsonObject.Books.ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public string Save(List<Book> books)
        {
            try
            {
                JsonDTO dto = new JsonDTO()
                {
                    Books = books.ToArray()
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

        public List<Book> SearchBooks(List<Book> books, string searchCriteria)
        {
            searchCriteria = searchCriteria.ToLower();

            return books
                .Where(
                    b => b.Title.ToLower().Contains(searchCriteria)
                    || b.Author.ToLower().Contains(searchCriteria))
                .ToList();
        }
    }
}
