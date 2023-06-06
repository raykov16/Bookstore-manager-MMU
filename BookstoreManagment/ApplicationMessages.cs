namespace BookstoreManagment
{
    public static class ApplicationMessages
    {
        public static string EnterKeyword = "\nEnter a keyword to search: ";

        public static string EnterValidNumber = "Enter a valid number!";
        public static string EnterNumberBetween = "Enter a valid number between 1 and 6!";

        public static string AddBookMenu = "\nThis is the add book menu: \n";

        public static string EnterTitle = "Enter title with maximum length of 50 characters:";
        public static string EnterValidTitle = "Please enter a valid title! Title:";

        public static string EnterAuthor = "Enter author name with maximum length of 50 characters:";
        public static string EnterValidAuthor = "Please enter a valid author! Author:";

        public static string EnterPrice = "Enter a price with a value greater than 0:";
        public static string EnterValidPrice = "Please enter a valid price! Price:";

        public static string EnterQuantity = "Enter quantity with a value greater than 0:";
        public static string EnterValidQuantity = "Please enter a valid quantity! quantity:";

        public static string EnterDescription = "Enter a description for the book with a maximum length of 200 characters(optional) : ";
        public static string EnterValidDescription = "Please enter a valid description! description:";

        public static string NewBookAdded = "\nNew book added successfully.";

        public static string TotalBookstoreValue = "\nTotal Bookstore Value: ${0:f2}";

        public static string DiscountsApplied = "\nDiscounts applied successfully.";

        public static string BookCollectionSaved = "\nBook collection saved to JSON file: BookstoreManagementOutput.json.";

        public static string NoMatchingBooks = "No matching books!";
    }
}
