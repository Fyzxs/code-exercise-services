using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404OutputRecord : ProductRecord
    {

        private readonly ITraderFoods404InputRecord _inputRecord;
        private readonly IChainInformation _chainInformation;

        public TraderFoods404OutputRecord(string inputRecord) :this(new TraderFoods404InputRecord(inputRecord), new TraderFoodsInformation()){}

        //Note: Future versions should make this ctor private as it shouldn't be used outside of tests. Use black magic for tests
        public TraderFoods404OutputRecord(ITraderFoods404InputRecord inputRecord, IChainInformation chainInformation)
        {
            _inputRecord = inputRecord;
            _chainInformation = chainInformation;
        }
        
        //Methods are Alphabetical

        public override string CompanyId() => _chainInformation.CompanyId();

        public override bool IsPromotional() => _inputRecord.HasPromotionalPricing();

        public override bool IsRegular() => _inputRecord.HasRegularPricing();
        
        public override int ProductId() => _inputRecord.ProductId();

        public override string ProductDescription() => _inputRecord.ProductDescription();

        public override string ProductSize() => _inputRecord.ProductSize();

        public override decimal PromotionalCalculatorPrice() => new TraderFoods404PromotionalCalculatorPrice(_inputRecord);

        public override string PromotionalDisplayPrice() => new TraderFoods404PromotionalDisplayPrice(_inputRecord);

        public override decimal RegularCalculatorPrice() => new TraderFoods404RegularCalculatorPrice(_inputRecord);

        public override string RegularDisplayPrice() => new TraderFoods404RegularDisplayPrice(_inputRecord);

        public override string StoreId() => new TraderFoods404StoreId(_chainInformation);

        public override double TaxRate() => new TraderFoods404TaxRate(_inputRecord.IsTaxable());
        
        public override string UnitOfMeasure() => new TraderFoods404UnitOfMeasure(_inputRecord);
    }
}