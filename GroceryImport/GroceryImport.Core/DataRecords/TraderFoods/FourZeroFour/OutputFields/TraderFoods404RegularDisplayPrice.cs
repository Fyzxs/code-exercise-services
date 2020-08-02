using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404RegularDisplayPrice : DisplayPrice
    {
        private readonly ITraderFoods404InputRecord _inputRecord;

        public TraderFoods404RegularDisplayPrice(ITraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType()
        {
            if (_inputRecord.IsRegularSplitPrice()) return new TraderFoods404SplitDisplayPrice(_inputRecord.RegularSplitPrice(), _inputRecord.RegularForQuantity());

            return new TraderFoods404SingularDisplayPrice(_inputRecord.RegularSingularPrice());
        }
    }
}