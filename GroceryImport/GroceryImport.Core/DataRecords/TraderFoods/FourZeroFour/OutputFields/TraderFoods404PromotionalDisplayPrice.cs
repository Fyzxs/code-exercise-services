using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404PromotionalDisplayPrice : DisplayPrice
    {
        private readonly TraderFoods404InputRecord _inputRecord;

        public TraderFoods404PromotionalDisplayPrice(TraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType() => new TraderFoods404DisplayPrice(_inputRecord.IsPromotionalSplitPrice(), _inputRecord.PromotionalSplitPrice(), _inputRecord.PromotionalForQuantity());
    }
}