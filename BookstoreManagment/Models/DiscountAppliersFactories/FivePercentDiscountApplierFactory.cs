using BookstoreManagment.Contracts;
using BookstoreManagment.Models.DiscountAppliers;

namespace BookstoreManagment.Models.DiscountAppliersFactories
{
    public class FivePercentDiscountApplierFactory : IDiscountApplierFactory
    {
        private FivePercentDiscountApplier _discountApplier;

        public IDiscountApplier GetDiscountApplier()
        {
            if (_discountApplier == null)
            {
                _discountApplier = new FivePercentDiscountApplier();
            }

            return _discountApplier;
        }
    }
}
