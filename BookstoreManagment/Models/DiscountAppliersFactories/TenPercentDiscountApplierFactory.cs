using BookstoreManagment.Contracts;
using BookstoreManagment.Models.DiscountAppliers;

namespace BookstoreManagment.Models.DiscountAppliersFactories
{
    public class TenPercentDiscountApplierFactory : IDiscountApplierFactory
    {
        private TenPercentDiscountApplier _discountApplier;

        public IDiscountApplier GetDiscountApplier()
        {
            if (_discountApplier == null)
            {
                _discountApplier = new TenPercentDiscountApplier();
            }

            return _discountApplier;
        }
    }
}
