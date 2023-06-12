using BookstoreManagment.Contracts;

namespace BookstoreManagment.Models.DiscountAppliers
{
    public class FivePercentDiscountApplier : IDiscountApplier
    {
        private decimal _discount = 0.05M;

        public void ApplyDiscount(Book book)
        {
            book.Price = book.Price - (book.Price * _discount);
        }
    }
}
