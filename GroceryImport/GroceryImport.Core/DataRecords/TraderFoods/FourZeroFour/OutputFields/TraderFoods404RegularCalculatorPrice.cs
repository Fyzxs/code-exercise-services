using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404RegularCalculatorPrice : CalculatorPrice
    {
        private readonly ITraderFoods404InputRecord _inputRecord;

        public TraderFoods404RegularCalculatorPrice(ITraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override decimal AsSystemType()
        {
            if (_inputRecord.IsRegularSplitPrice()) return new TraderFoods404CalculatorSplitPrice(_inputRecord.RegularSplitPrice(), _inputRecord.RegularForQuantity());

            return new TraderFoods404CalculatorSingularPrice(_inputRecord.RegularSingularPrice());
        }
    }
}