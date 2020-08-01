using GroceryImport.Core.Tests.BaseTypes;
using GroceryImport.Core.Tests.CompanyStore.Fields;
using GroceryImport.Core.Tests.CompanyStore.Maths;
using GroceryImport.Core.Tests.ProductRecords;

namespace GroceryImport.Core.Tests.CompanyStore
{
    public sealed class CompanyStoreInputRecord
    {
        private readonly Record _record;

        public CompanyStoreInputRecord(string record) : this(new Record(record)) { }

        private CompanyStoreInputRecord(Record record) => _record = record;

        public NumberField ProductId() => new ProductId(_record);
        
        public StringField ProductDescription() => new ProductDescription(_record);
        public CurrencyField RegularSingularPrice() => new RegularSingularPrice(_record);
        public CurrencyField PromotionalSingularPrice() => new PromotionalSingularPrice(_record);
        public CurrencyField RegularSplitPrice() => new RegularSplitPrice(_record);
        public CurrencyField PromotionalSplitPrice() => new PromotionalSplitPrice(_record);
        public NumberField RegularForQuantity() => new RegularForQuantity(_record);
        public NumberField PromotionalForQuantity() => new PromotionalForQuantity(_record);
        //Flags
        private Flags Flags() => new Flags(_record);
        public Flag IsPerWeight() => Flags().PerWeight();
        public Flag IsTaxable() => Flags().Taxable();
        //ProductSize

        public bool IsRegularSplitPrice() => RegularForQuantity() > 0;
        public bool IsPromotionalSplitPrice() => PromotionalForQuantity() > 0;
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

        public string RegularDisplayPrice() => new CompanyStoreRegularDisplayPrice(_inputRecord);

        public decimal RegularCalculatorPrice() => new CompanyStoreRegularCalculatorPrice(_inputRecord);

        public string PromotionalDisplayPrice() => new CompanyStorePromotionalDisplayPrice(_inputRecord);

        public decimal PromotionalCalculatorPrice() => new CompanyStorePromotionalCalculatorPrice(_inputRecord);

        //UnitOfMeasure
        //ProductSize
    }

    public sealed class CompanyStoreRegularCalculatorPrice : CalculatorPrice
    {
        private readonly IRounding _rounding;
        private readonly CompanyStoreInputRecord _inputRecord;

        public CompanyStoreRegularCalculatorPrice(CompanyStoreInputRecord inputRecord) : this(inputRecord,
            new InexactRounding())
        {}

        private CompanyStoreRegularCalculatorPrice(CompanyStoreInputRecord inputRecord, IRounding rounding)
        {
            _inputRecord = inputRecord;
            _rounding = rounding;
        }

        public override decimal AsSystemType() => new CompanyStoreCalculatorPrice(_inputRecord.IsRegularSplitPrice(), _inputRecord.RegularSplitPrice(), _inputRecord.RegularForQuantity());
    }

    public sealed class CompanyStorePromotionalCalculatorPrice : CalculatorPrice
    {
        private readonly IRounding _rounding;
        private readonly CompanyStoreInputRecord _inputRecord;

        public CompanyStorePromotionalCalculatorPrice(CompanyStoreInputRecord inputRecord) : this(inputRecord,
            new InexactRounding())
        { }

        private CompanyStorePromotionalCalculatorPrice(CompanyStoreInputRecord inputRecord, IRounding rounding)
        {
            _inputRecord = inputRecord;
            _rounding = rounding;
        }

        public override decimal AsSystemType() => new CompanyStoreCalculatorPrice(_inputRecord.IsPromotionalSplitPrice(), _inputRecord.PromotionalSplitPrice(), _inputRecord.PromotionalForQuantity());
    }

    public sealed class CompanyStoreDisplayPrice : DisplayPrice
    {
        private readonly bool _isSplitPrice;
        private readonly CurrencyField _splitPrice;
        private readonly NumberField _forQuantity;

        public CompanyStoreDisplayPrice(in bool isSplitPrice, CurrencyField splitPrice, NumberField forQuantity)
        {
            _isSplitPrice = isSplitPrice;
            _splitPrice = splitPrice;
            _forQuantity = forQuantity;
        }
        public override string AsSystemType()
        {
            if (_isSplitPrice) return $"{_forQuantity.AsSystemType()} for {_splitPrice.AsCurrencyString()}";

            return _splitPrice.AsCurrencyString();
        }
    }
    public sealed class CompanyStorePromotionalDisplayPrice : DisplayPrice
    {
        private readonly CompanyStoreInputRecord _inputRecord;

        public CompanyStorePromotionalDisplayPrice(CompanyStoreInputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType() => new CompanyStoreDisplayPrice(_inputRecord.IsPromotionalSplitPrice(), _inputRecord.PromotionalSplitPrice(), _inputRecord.PromotionalForQuantity());
    }
    public sealed class CompanyStoreRegularDisplayPrice : DisplayPrice
    {
        private readonly CompanyStoreInputRecord _inputRecord;

        public CompanyStoreRegularDisplayPrice(CompanyStoreInputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType() => new CompanyStoreDisplayPrice(_inputRecord.IsRegularSplitPrice(), _inputRecord.RegularSplitPrice(), _inputRecord.RegularForQuantity());
    }

    public sealed class CompanyStoreCalculatorPrice : CalculatorPrice
    {
        private readonly bool _isSplitPrice;
        private readonly CurrencyField _splitPrice;
        private readonly NumberField _forQuantity;
        private readonly IRounding _rounding;

        public CompanyStoreCalculatorPrice(bool isSplitPrice, CurrencyField splitPrice, NumberField forQuantity) : this(isSplitPrice, splitPrice, forQuantity, new InexactRounding()){}
        
        private CompanyStoreCalculatorPrice(in bool isSplitPrice, CurrencyField splitPrice, NumberField forQuantity, IRounding rounding)
        {
            _isSplitPrice = isSplitPrice;
            _splitPrice = splitPrice;
            _forQuantity = forQuantity;
            _rounding = rounding;
        }
        public override decimal AsSystemType()
        {
            if (_isSplitPrice) return _rounding.RoundForCalculator(_splitPrice / _forQuantity);

            return _splitPrice;
        }
    }

    public sealed class CompanyStoreTaxRate : TaxRate
    {
        private const double Rate = 7.775 / 100d;
        public CompanyStoreTaxRate(bool isTaxable):base(isTaxable, Rate){}
    }
}