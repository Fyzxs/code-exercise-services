using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404PromotionalCalculatorPrice : CalculatorPrice
    {
        private readonly ITraderFoods404InputRecord _inputRecord;

        public TraderFoods404PromotionalCalculatorPrice(ITraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override decimal AsSystemType()
        {
            if(_inputRecord.IsPromotionalSplitPrice()) return new TraderFoods404CalculatorSplitPrice(_inputRecord.PromotionalSplitPrice(), _inputRecord.PromotionalForQuantity());

            return new TraderFoods404CalculatorSingularPrice(_inputRecord.PromotionalSingularPrice());
        }
    }
}