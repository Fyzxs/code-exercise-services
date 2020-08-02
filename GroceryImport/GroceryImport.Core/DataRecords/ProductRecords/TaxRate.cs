using GroceryImport.Core.Library;

namespace GroceryImport.Core.DataRecords.ProductRecords
{
    /// <summary>
    /// Represents the TaxRate for an item. 
    /// </summary>
    public abstract class TaxRate : ToSystem<double>
    {
        private readonly double _rate;
        private readonly bool _isTaxable;

        protected TaxRate(bool isTaxable, double rate)
        {
            _isTaxable = isTaxable;
            _rate = rate;
        }

        //TODO: Consider if there should be a "TaxableTaxRate" and a "NonTaxableTaxRate" class.
        public override double AsSystemType() => _isTaxable ? _rate : 0d;
    }
}