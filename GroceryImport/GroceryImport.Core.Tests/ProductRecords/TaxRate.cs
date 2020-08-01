namespace GroceryImport.Core.Tests.ProductRecords
{
    public abstract class TaxRate : ToSystem<double>
    {
        private readonly double _rate;
        private readonly bool _isTaxable;

        protected TaxRate(bool isTaxable, double rate)
        {
            _isTaxable = isTaxable;
            _rate = rate;
        }

        public override double AsSystemType() => _isTaxable ? _rate : 0d;
    }
}