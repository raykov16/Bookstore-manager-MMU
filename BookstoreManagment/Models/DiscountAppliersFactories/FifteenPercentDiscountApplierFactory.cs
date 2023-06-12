using BookstoreManagment.Contracts;
using BookstoreManagment.Models.DiscountAppliers;

namespace BookstoreManagment.Models.DiscountAppliersFactories
{
    public class FifteenPercentDiscountApplierFactory : IDiscountApplierFactory
    {
        private FifteenPercentDiscountApplier _discountApplier;

        public IDiscountApplier GetDiscountApplier()
        {
            if (_discountApplier == null)
            {
                _discountApplier = new FifteenPercentDiscountApplier();
            }

            return _discountApplier;
        }
    }
}
