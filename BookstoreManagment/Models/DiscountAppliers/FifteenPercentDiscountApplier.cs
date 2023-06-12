using BookstoreManagment.Contracts;

namespace BookstoreManagment.Models.DiscountAppliers
{
    public class FifteenPercentDiscountApplier : IDiscountApplier
    {
        private decimal _discount = 0.15M;

        public void ApplyDiscount(Book book)
        {
            book.Price = book.Price - (book.Price * _discount);
        }
    }
}
