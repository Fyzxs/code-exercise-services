using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404RegularDisplayPrice : DisplayPrice
    {
        private readonly TraderFoods404InputRecord _inputRecord;

        public TraderFoods404RegularDisplayPrice(TraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType() => new TraderFoods404DisplayPrice(_inputRecord.IsRegularSplitPrice(), _inputRecord.RegularSplitPrice(), _inputRecord.RegularForQuantity());
    }
}