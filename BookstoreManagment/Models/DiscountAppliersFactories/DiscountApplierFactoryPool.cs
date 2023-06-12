namespace BookstoreManagment.Models.DiscountAppliersFactories
{
    public class DiscountApplierFactoryPool
    {
        private FivePercentDiscountApplierFactory _fivePercentFactory;
        private TenPercentDiscountApplierFactory _tenPercentFactory;
        private FifteenPercentDiscountApplierFactory _fifteenPercentFactory;

        public FivePercentDiscountApplierFactory GetFivePercentFactory()
        {
            if (_fivePercentFactory == null)
            {
                _fivePercentFactory = new FivePercentDiscountApplierFactory();
            }

            return _fivePercentFactory;
        }

        public TenPercentDiscountApplierFactory GetTenPercentFactory()
        {
            if (_tenPercentFactory == null)
            {
                _tenPercentFactory = new TenPercentDiscountApplierFactory();
            }

            return _tenPercentFactory;
        }

        public FifteenPercentDiscountApplierFactory GetFifteenPercentFactory()
        {
            if (_fifteenPercentFactory == null)
            {
                _fifteenPercentFactory = new FifteenPercentDiscountApplierFactory();
            }

            return _fifteenPercentFactory;
        }
    }
}
