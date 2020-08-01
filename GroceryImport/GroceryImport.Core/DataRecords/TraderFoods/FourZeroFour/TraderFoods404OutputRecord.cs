using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404OutputRecord : ProductRecord
    {
        private const string StoreIdValue = "404";

        private readonly TraderFoods404InputRecord _inputRecord;
        private readonly IChainInformation _chainInformation;

        public TraderFoods404OutputRecord(string inputRecord) :this(new TraderFoods404InputRecord(inputRecord), new TraderFoodsInformation()){}

        private TraderFoods404OutputRecord(TraderFoods404InputRecord inputRecord, IChainInformation chainInformation)
        {
            _inputRecord = inputRecord;
            _chainInformation = chainInformation;
        }
        
        //Methods are Alphabetical

        //TODO: Prices are not correct for non-split
        public override string CompanyId() => _chainInformation.CompanyId();
        
        public override int ProductId() => _inputRecord.ProductId();

        public override string ProductDescription() => _inputRecord.ProductDescription();

        public override string ProductSize() => _inputRecord.ProductSize();

        public override decimal PromotionalCalculatorPrice() => new TraderFoods404PromotionalCalculatorPrice(_inputRecord);

        public override string PromotionalDisplayPrice() => new TraderFoods404PromotionalDisplayPrice(_inputRecord);

        public override decimal RegularCalculatorPrice() => new TraderFoods404RegularCalculatorPrice(_inputRecord);

        public override string RegularDisplayPrice() => new TraderFoods404RegularDisplayPrice(_inputRecord);
        
        public override string StoreId() => $"{CompanyId()}:{StoreIdValue}";

        public override double TaxRate() => new TraderFoods404TaxRate(_inputRecord.IsTaxable());
        
        public override string UnitOfMeasure() => new TraderFoods404UnitOfMeasure(_inputRecord);

    }
}