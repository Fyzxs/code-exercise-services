using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404PromotionalDisplayPrice : DisplayPrice
    {
        private readonly ITraderFoods404InputRecord _inputRecord;

        public TraderFoods404PromotionalDisplayPrice(ITraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType()
        {
            if(_inputRecord.IsPromotionalSplitPrice()) return new TraderFoods404SplitDisplayPrice(_inputRecord.PromotionalSplitPrice(), _inputRecord.PromotionalForQuantity());

            return new TraderFoods404SingularDisplayPrice(_inputRecord.PromotionalSingularPrice());
        }
    }
}