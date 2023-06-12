using BookstoreManagment.Contracts;

namespace BookstoreManagment.Models.DiscountAppliers
{
    public class TenPercentDiscountApplier : IDiscountApplier
    {
        private decimal _discount = 0.1M;

        public void ApplyDiscount(Book book)
        {
            book.Price = book.Price - (book.Price * _discount);
        }
    }
}
