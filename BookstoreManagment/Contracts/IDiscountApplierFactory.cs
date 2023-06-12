namespace BookstoreManagment.Contracts
{
    public interface IDiscountApplierFactory
    {
        IDiscountApplier GetDiscountApplier();
    }
}
