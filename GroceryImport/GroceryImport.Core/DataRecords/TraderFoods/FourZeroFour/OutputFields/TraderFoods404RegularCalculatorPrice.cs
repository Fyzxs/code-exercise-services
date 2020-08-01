using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404RegularCalculatorPrice : CalculatorPrice
    {
        private readonly TraderFoods404InputRecord _inputRecord;

        public TraderFoods404RegularCalculatorPrice(TraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override decimal AsSystemType() => new TraderFoods404CalculatorPrice(_inputRecord.IsRegularSplitPrice(), _inputRecord.RegularSplitPrice(), _inputRecord.RegularForQuantity());
    }
}