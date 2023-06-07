namespace BookstoreManagment.Tests
{
    public class BookstoreManagerTests
    {
        [Test]
        public void SearchBooks_FindsTheCorrectBooks_IfTheyExist()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            var books = manager.SearchBooks("J.R.");

            //Assert
            Assert.That(books.Count == 2);
            Assert.That(books[0].Author.Contains("J.R."));
        }

        [Test]
        public void SearchBooks_ReturnsNothing_IfNoBooksMatched()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            var books = manager.SearchBooks("nonExisting");

            //Assert
            Assert.That(books.Count == 0);
        }

        [Test]
        public void AddNewBook_AddsTheBookToTheCollection_Successfully()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);
            string title = "New Book";
            string author = "New author";
            decimal price = 10.00M;
            int quantity = 10;
            string description = "Description";

            //Act
            manager.AddNewBook(title, author, price, quantity, description);

            //Assert
            Assert.That(manager.BooksCollection.Count == 51);
            Assert.That(manager.BooksCollection[manager.BooksCollection.Count - 1].Id == 51);
            Assert.That(manager.BooksCollection[manager.BooksCollection.Count - 1].Title == title);
            Assert.That(manager.BooksCollection[manager.BooksCollection.Count - 1].Author == author);
            Assert.That(manager.BooksCollection[manager.BooksCollection.Count - 1].Price == price);
            Assert.That(manager.BooksCollection[manager.BooksCollection.Count - 1].Quantity == quantity);
        }

        [Test]
        public void CalculateTotalValue_SumsTheValuesProperly()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            var value = manager.CalcualteTotalValue();

            //Assert
            Assert.That(value == 6609.02m);
        }

        [Test]
        public void ApplyDiscount_ReducesThePriceOfTheBooks()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);
            decimal normalValue = manager.CalcualteTotalValue();

            //Act
            manager.ApplyDiscounts();

            //Assert
            decimal valueAfterDiscounts = manager.CalcualteTotalValue();
            Assert.That(valueAfterDiscounts < normalValue);
        }

        [Test]
        public void ApplyDiscount_ReducesThePriceOfTheBooksBy5Percent_WhenBooksCostLessThan15()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            manager.ApplyDiscounts();

            //Assert
            Assert.That(manager.BooksCollection[47].Price == 9.4905m);
        }

        [Test]
        public void ApplyDiscount_ReducesThePriceOfTheBooksBy10Percent_WhenBooksCostBetween15And25()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            manager.ApplyDiscounts();

            //Assert
            Assert.That(manager.BooksCollection[0].Price == 17.991M);
        }

        [Test]
        public void ApplyDiscount_ReducesThePriceOfTheBooksBy15Percent_WhenBooksCostMoreThan25()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            manager.ApplyDiscounts();

            //Assert
            Assert.That(manager.BooksCollection[48].Price == 24.6415m);
        }

        [Test]
        public void Save_CreatesFileWithTheData()
        {
            //Arange
            BookstoreManager manager = new BookstoreManager(jsonPaths.jsonFilePathForTests);

            //Act
            string expectedOutput = manager.Save();

            //Assert
            string createdFileOutput = File.ReadAllText("../../../../BookstoreManagment/BookstoreManagementOutput.json");
            Assert.That(expectedOutput == createdFileOutput);
        }

    }
}