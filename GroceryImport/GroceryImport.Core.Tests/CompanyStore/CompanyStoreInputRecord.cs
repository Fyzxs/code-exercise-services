using System;
using GroceryImport.Core.Tests.BaseTypes;
using GroceryImport.Core.Tests.CompanyStore.Fields;

namespace GroceryImport.Core.Tests.CompanyStore
{
    internal sealed class CompanyStoreInputRecord
    {
        private readonly Record _record;

        public CompanyStoreInputRecord(string record) : this(new Record(record)) { }

        private CompanyStoreInputRecord(Record record) => _record = record;

        public NumberField ProductId() => new ProductId(_record);
        
        public StringField ProductDescription() => new ProductDescription(_record);
        
        public CurrencyField PromotionalSingularPrice() => new PromotionalSingularPrice(_record);
        public CurrencyField RegularSingularPrice() => new RegularSingularPrice(_record);
        public CurrencyField RegularSplitPrice() => new RegularSplitPrice(_record);
        public NumberField RegularForQuantity() => new RegularForQuantity(_record);
        
        public Flag IsPerWeight() => Flags().PerWeight();
        
        public Flag IsTaxable() => Flags().Taxable();
        
        private Flags Flags() => new Flags(_record);
    }

    public sealed class CompanyStoreProductRecord : ProductRecord
    {
        private readonly CompanyStoreInputRecord _inputRecord;

        public CompanyStoreProductRecord(string inputRecord) :this(new CompanyStoreInputRecord(inputRecord)){}

        private CompanyStoreProductRecord(CompanyStoreInputRecord inputRecord) => _inputRecord = inputRecord;

        public string CompanyId() => "THE_COMPANY_ID";
        public string StoreId() => "THE_COMPANY_STORE_ID";

        public int ProductId() => _inputRecord.ProductId();
        
        public string ProductDescription() => _inputRecord.ProductDescription();

        public double TaxRate() => new CompanyStoreTaxRate(_inputRecord.IsTaxable());

        public string RegularDisplayPrice()
        {
            //TODO: This should be a "CompanyStoreRegularDisplayPrice" object
            if (IsRegularSplitPrice()) return $"{_inputRecord.RegularForQuantity().AsSystemType()} for {_inputRecord.RegularSplitPrice().AsCurrencyString()}";

            return _inputRecord.RegularSplitPrice().AsCurrencyString();
        }
        private bool IsRegularSplitPrice() => _inputRecord.RegularForQuantity() > 0;

        public decimal RegularCalculatorPrice()
        {
            //TODO: This should be a "CalculatorPrice", maybe a "RegularCalculatorPrice"... probably.
            if (IsRegularSplitPrice())
            {
                decimal regularSplitPrice = _inputRecord.RegularSplitPrice().AsSystemType();
                
                return Math.Round(regularSplitPrice / _inputRecord.RegularForQuantity(), 4, MidpointRounding.ToNegativeInfinity);
            }

            return _inputRecord.RegularSingularPrice();
        }

    }

    public abstract class ProductRecord
    {
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