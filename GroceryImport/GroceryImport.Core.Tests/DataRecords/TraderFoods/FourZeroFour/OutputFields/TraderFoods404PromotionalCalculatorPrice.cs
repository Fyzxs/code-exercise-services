using GroceryImport.Core.Tests.DataRecords.ProductRecords;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404PromotionalCalculatorPrice : CalculatorPrice
    {
        private readonly TraderFoods404InputRecord _inputRecord;

        public TraderFoods404PromotionalCalculatorPrice(TraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override decimal AsSystemType() => new TraderFoods404CalculatorPrice(_inputRecord.IsPromotionalSplitPrice(), _inputRecord.PromotionalSplitPrice(), _inputRecord.PromotionalForQuantity());
    }
}