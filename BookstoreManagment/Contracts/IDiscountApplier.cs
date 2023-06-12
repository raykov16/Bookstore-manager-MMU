using BookstoreManagment.Models;

namespace BookstoreManagment.Contracts
{
    public interface IDiscountApplier
    {
        void ApplyDiscount(Book book);
    }
}
