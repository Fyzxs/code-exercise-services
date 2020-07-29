using GroceryImport.Core.Tests.BaseTypes;
using GroceryImport.Core.Tests.CompanyStore.Fields;

namespace GroceryImport.Core.Tests.CompanyStore
{
    public sealed class CompanyStoreInputRecord
    {
        private readonly Record _record;

        public CompanyStoreInputRecord(string record) : this(new Record(record)) { }

        public CompanyStoreInputRecord(Record record) => _record = record;

        public NumberField ProductId() => new ProductId(_record);
        
        public StringField ProductDescription() => new ProductDescription(_record);
        
        public CurrencyField PromotionalSingularPrice() => new PromotionalSingularPrice(_record);
        
        public Flag IsPerWeight() => Flags().PerWeight();
        
        public Flag IsTaxable() => Flags().Taxable();
        
        private Flags Flags() => new Flags(_record);

        public TaxRate TaxRate() => new CompanyStoreTaxRate(IsTaxable());
    }

    public sealed class CompanyStoreTaxRate : TaxRate
    {
        private const double Rate = 7.775 / 100d;
        public CompanyStoreTaxRate(bool isTaxable):base(isTaxable, Rate){}
    }

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